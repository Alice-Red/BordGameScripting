using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Security;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RUtil.Tcp
{
    public class Server
    {
        public delegate void ServerAwakedHundler(Server sender, ServerAwakedArgs e);
        public event ServerAwakedHundler ServerAwaked;

        public delegate void MessageReceivedHundler(Server sender, MessageReceivedArgs e);
        public event MessageReceivedHundler MessageReceived;

        public delegate void ConnetionSuccessfullHundler(Server sender, ConnetionSuccessfullArgs e);
        public event ConnetionSuccessfullHundler ConnetionSuccessfull;

        public delegate void DisConnectedHundler(Server sender, DisConnectedArgs e);
        public event DisConnectedHundler DisConnected;

        public delegate void ConnectedCountChangedHundler(Server sender, ConnectedCountChangedArgs e);
        public event ConnectedCountChangedHundler ConnectedCountChanged;


        private int port;
        public int Port {
            get { return port; }
            set { port = value; }
        }

        private int connectedCount = 0;
        public int ConnectedCount {
            get { return connectedCount; }
            private set {
                if (connectedCount != value)
                    ConnectedCountChanged?.Invoke(this, new ConnectedCountChangedArgs(value));
                connectedCount = value;
            }
        }
        private Dictionary<int, Socket> ConnectingList = new Dictionary<int, Socket>();

        private int ID = 0;

        private bool forcedTermination = false;

        public Server() {
            connectedCount = 0;
        }

        public Server(int port) : base() {
            Create(port);
        }


        public void Create(int port) {
            Port = port;
        }

        public void Boot() {
            Socket socket = new Socket(SocketType.Stream, ProtocolType.IP);

            socket.Bind(new IPEndPoint(IPAddress.Any, Port));
            socket.Listen(8);

            Task.Factory.StartNew(() => {
                StartAccept(socket);
            });
        }

        private void StartAccept(Socket server) {
            // ホスト名を取得する
            string hostname = Dns.GetHostName();
            // ホスト名からIPアドレスを取得する
            IPAddress[] adrList = Dns.GetHostAddresses(hostname);
            ServerAwaked?.Invoke(this, new ServerAwakedArgs(string.Join(" || ", adrList.Select(s => s.ToString()))));
            server.BeginAccept(new AsyncCallback(AcceptCallback), server);
        }

        private void AcceptCallback(IAsyncResult ar) {
            Socket server = (Socket) ar.AsyncState;
            Socket client = null;
            int Id = ID;
            bool exit = false;
            string ipadd = "";
            try {
                client = server.EndAccept(ar);
                server.BeginAccept(new AsyncCallback(AcceptCallback), server);
                ConnetionSuccessfull?.Invoke(this, new ConnetionSuccessfullArgs(client.RemoteEndPoint.ToString()));
                ConnectingList.Add(ID, client);
                ID++;
                ConnectedCount++;
                //Console.WriteLine(client.LocalEndPoint);
                //Console.WriteLine(server.LocalEndPoint);
            } catch {
                //Console.WriteLine("閉じました。");
                return;
            }

            while (!exit && !forcedTermination) {
                ipadd = client.RemoteEndPoint.ToString();


                bool disconnected = false;
                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                byte[] resBytes = new byte[255];

                int resSize = 0;
                try {
                    do {
                        resSize = client.Receive(resBytes);
                        if (resSize == 0) {
                            disconnected = true;
                            //Console.WriteLine("クライアントが切断しました。");
                            break;
                        }
                        ms.Write(resBytes, 0, resSize);
                    } while (resBytes[resSize - 1] != '\n');
                    string resMsg = Encoding.UTF8.GetString(ms.ToArray()).Trim('\n');

                    //Console.WriteLine(resMsg);
                    if (Client.DisconnectKeyWord.Contains(resMsg)) {
                        exit = true;
                        break;
                    }
                    ms.Close();

                    if (!disconnected) {
                        MessageReceived?.Invoke(this, new MessageReceivedArgs(client.RemoteEndPoint.ToString(), resMsg));
                        //string sendMsg = resMsg.Length.ToString();
                        //SendAll($"{client.RemoteEndPoint.ToString()} : {resMsg}");
                        //byte[] sendBytes = Encoding.UTF8.GetBytes(sendMsg + '\n');
                        //client.Send(sendBytes);
                        //Console.WriteLine(sendMsg);
                    }

                    //client.Send(Encoding.UTF8.GetBytes($"returned [{resMsg}]"));

                } catch (Exception e) {
                    Console.WriteLine(e);
                    exit = true;
                }
            }
            DisConnected?.Invoke(this, new DisConnectedArgs(ipadd));
            client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            client.Close();
            ConnectingList.Remove(Id);
            ConnectedCount -= 1;
        }

        [Obsolete]
        public void Command(string cmd) {

        }

        public void SendAll(string message) {
            foreach (var item in ConnectingList) {
                Send(item.Value, message);
            }
        }

        public void Send(Socket target, string message) {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message + '\n');
            target.Send(sendBytes);
        }

        public void Send(Func<Socket, int, bool> target, string message) {
            byte[] sendBytes = Encoding.UTF8.GetBytes(message + '\n');
            for (int i = 0; i < ConnectingList.Count(); i++) {
                if (target(ConnectingList.ElementAt(i).Value, i))
                    ConnectingList.ElementAt(i).Value.Send(sendBytes);
            }
        }

        public void ShutDown() {
            forcedTermination = true;
            foreach (var item in ConnectingList) {
                item.Value.Shutdown(SocketShutdown.Both);
                item.Value.Close();
            }

        }

    }
}
