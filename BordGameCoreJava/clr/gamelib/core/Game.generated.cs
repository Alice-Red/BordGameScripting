//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameLib.Core {
    
    
    #region Component Designer generated code 
    public partial class Game_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::GameLib.Core.@__Game.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::GameLib.Core.Game), typeof(global::GameLib.Core.Game_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::GameLib.Core.Game), typeof(global::GameLib.Core.Game_))]
    internal sealed partial class @__Game : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__Game(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::GameLib.Core.@__Game.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__Game);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getMaxPlayer", "MaxPlayer0", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Run", "Run1", "()V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "StorePlayer", "StorePlayer2", "([Lgamelib/api/GameInputter;)V"));
            return methods;
        }
        
        private static int MaxPlayer0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Game @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Game>(@__env, @__obj);
            @__return = ((int)(@__real.MaxPlayer));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Run1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()V
            // ()V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Game @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Game>(@__env, @__obj);
            @__real.Run();
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static void StorePlayer2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle players) {
            // ([Lgamelib/api/GameInputter;)V
            // ([LGameLib/API/GameInputter;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Game @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Game>(@__env, @__obj);
            @__real.StorePlayer(global::net.sf.jni4net.utils.Convertor.ArrayStrongJp2C<global::GameLib.API.GameInputter[], global::GameLib.API.GameInputter>(@__env, players));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::GameLib.Core.@__Game(@__env);
            }
        }
    }
    #endregion
}