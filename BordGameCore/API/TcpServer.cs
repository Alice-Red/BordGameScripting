using RUtil;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace GameLib.API
{
    public class TcpServer
    {
        public delegate void TcpMessageReceivedHundler(object sender, TcpMessageReceivedArgs e);
        public event TcpMessageReceivedHundler TcpMessageReceived;

        private string hostAddress;

        public string HostAddress {
            get { return hostAddress; }
            set {

            }
        }

        private int port;
        public int Port {
            get { return port; }
            set {

            }

        }

        public int ReadTimeout { get; set; }
        public int WriteTimeout { get; set; }


        public void Boot() {
            Socket socket = new Socket(SocketType.Stream, ProtocolType.IP);

            socket.Listen(2);

            Task.Factory.StartNew(() => {
                StartAccept(socket);
            });

            //ipAdd = Regex.IsMatch(HostAddress, @"\d{1,3}\.\d{1,3}\.\d{1,3}\.\d{1,3}") ? IPAddress.Parse(HostAddress) : Dns.GetHostEntry(HostAddress).AddressList[0];
            //listener = new System.Net.Sockets.TcpListener(ipAdd, Port);
            //listener.Start();
        }
        //クライアントの接続待ちスタート
        private static void StartAccept(System.Net.Sockets.Socket server) {
            //接続要求待機を開始する
            server.BeginAccept(new AsyncCallback(AcceptCallback), server);
        }

        //BeginAcceptのコールバック
        private static void AcceptCallback(IAsyncResult ar) {
            //サーバーSocketの取得
            System.Net.Sockets.Socket server = (System.Net.Sockets.Socket) ar.AsyncState;

            //接続要求を受け入れる
            System.Net.Sockets.Socket client = null;
            try {
                //クライアントSocketの取得
                client = server.EndAccept(ar);
            } catch {
                Console.WriteLine("閉じました。");
                return;
            }
            

            //クライアントが接続した時の処理をここに書く
            //ここでは文字列を送信して、すぐに閉じている
            client.Send(Encoding.UTF8.GetBytes("こんにちは。"));
            client.Shutdown(System.Net.Sockets.SocketShutdown.Both);
            client.Close();

            //接続要求待機を再開する
            server.BeginAccept(new AsyncCallback(AcceptCallback), server);
        }

    }
}
