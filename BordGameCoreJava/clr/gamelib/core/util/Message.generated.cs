//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameLib.Core.Util {
    
    
    #region Component Designer generated code 
    public partial class Message_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::GameLib.Core.Util.@__Message.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::GameLib.Core.Util.Message), typeof(global::GameLib.Core.Util.Message_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::GameLib.Core.Util.Message), typeof(global::GameLib.Core.Util.Message_))]
    internal sealed partial class @__Message : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__Message(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::GameLib.Core.Util.@__Message.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__Message);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getTime", "Time0", "()Lsystem/DateTime;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getSourceProperty", "SourceProperty1", "()Ljava/lang/String;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getSourceFile", "SourceFile2", "()Ljava/lang/String;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getSourceLine", "SourceLine3", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getType", "Type4", "()Lgamelib/core/util/MessageType;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getMessageText", "MessageText5", "()Ljava/lang/String;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "__ctorMessage0", "__ctorMessage0", "(Lnet/sf/jni4net/inj/IClrProxy;Ljava/lang/String;Ljava/lang/String;Ljava/lang/Str" +
                        "ing;ILgamelib/core/util/MessageType;)V"));
            return methods;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Time0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/DateTime;
            // ()LSystem/DateTime;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.DateTime>(@__env, @__real.Time);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle SourceProperty1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Ljava/lang/String;
            // ()LSystem/String;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2JString(@__env, @__real.SourceProperty);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle SourceFile2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Ljava/lang/String;
            // ()LSystem/String;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2JString(@__env, @__real.SourceFile);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int SourceLine3(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = ((int)(@__real.SourceLine));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Type4(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lgamelib/core/util/MessageType;
            // ()LGameLib/Core/Util/MessageType;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::GameLib.Core.Util.MessageType>(@__env, @__real.Type);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle MessageText5(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Ljava/lang/String;
            // ()LSystem/String;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.Message @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.Message>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2JString(@__env, @__real.MessageText);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void @__ctorMessage0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle messageText, global::net.sf.jni4net.utils.JniLocalHandle sourceProperty, global::net.sf.jni4net.utils.JniLocalHandle sourceFile, int sourceLine, global::net.sf.jni4net.utils.JniLocalHandle type) {
            // (Ljava/lang/String;Ljava/lang/String;Ljava/lang/String;ILgamelib/core/util/MessageType;)V
            // (LSystem/String;LSystem/String;LSystem/String;ILGameLib/Core/Util/MessageType;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.Message @__real = new global::GameLib.Core.Util.Message(global::net.sf.jni4net.utils.Convertor.StrongJ2CString(@__env, messageText), global::net.sf.jni4net.utils.Convertor.StrongJ2CString(@__env, sourceProperty), global::net.sf.jni4net.utils.Convertor.StrongJ2CString(@__env, sourceFile), sourceLine, global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.MessageType>(@__env, type));
            global::net.sf.jni4net.utils.Convertor.InitProxy(@__env, @__obj, @__real);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::GameLib.Core.Util.@__Message(@__env);
            }
        }
    }
    #endregion
}
