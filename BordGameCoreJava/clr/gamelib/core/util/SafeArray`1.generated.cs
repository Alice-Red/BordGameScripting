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
    public partial class SafeArray`1_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::GameLib.Core.Util.@__SafeArray<>.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::GameLib.Core.Util.SafeArray<>), typeof(global::GameLib.Core.Util.SafeArray<>_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::GameLib.Core.Util.SafeArray<>), typeof(global::GameLib.Core.Util.SafeArray<>_))]
    internal sealed partial class @__SafeArray`1 : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__SafeArray`1(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::GameLib.Core.Util.@__SafeArray<>.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__SafeArray`1);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getLength", "Length0", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getArray", "Array1", "()[Lsystem/Object;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getItem", "Item2", "(II)Lsystem/Object;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Debug", "Debug3", "()Ljava/lang/String;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "__ctorSafeArray`10", "__ctorSafeArray`10", "(Lnet/sf/jni4net/inj/IClrProxy;I)V"));
            return methods;
        }
        
        private static int Length0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.SafeArray<> @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.SafeArray<>>(@__env, @__obj);
            @__return = ((int)(@__real.Length));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Array1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()[Lsystem/Object;
            // ()[L;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.SafeArray<> @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.SafeArray<>>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayStrongC2Jp<global::[], void>(@__env, @__real.Array);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Item2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int x, int y) {
            // (II)Lsystem/Object;
            // (II)
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.SafeArray<> @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.SafeArray<>>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<void>(@__env, @__real[x, y]);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Debug3(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Ljava/lang/String;
            // ()LSystem/String;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.SafeArray<> @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.SafeArray<>>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2JString(@__env, @__real.Debug());
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void @__ctorSafeArray`10(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int length) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.SafeArray<> @__real = new global::GameLib.Core.Util.SafeArray<>(length);
            global::net.sf.jni4net.utils.Convertor.InitProxy(@__env, @__obj, @__real);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::GameLib.Core.Util.@__SafeArray<>(@__env);
            }
        }
    }
    #endregion
}
