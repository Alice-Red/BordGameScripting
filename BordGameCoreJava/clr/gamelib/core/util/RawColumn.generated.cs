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
    public partial class RawColumn_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::GameLib.Core.Util.@__RawColumn.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::GameLib.Core.Util.RawColumn), typeof(global::GameLib.Core.Util.RawColumn_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::GameLib.Core.Util.RawColumn), typeof(global::GameLib.Core.Util.RawColumn_))]
    internal sealed partial class @__RawColumn : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__RawColumn(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::GameLib.Core.Util.@__RawColumn.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__RawColumn);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "CompareTo", "CompareTo0", "(Lgamelib/core/util/RawColumn;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getRaw", "Raw1", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setRaw", "Raw2", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getColumn", "Column3", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setColumn", "Column4", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getX", "X5", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setX", "X6", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getY", "Y7", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setY", "Y8", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getWidth", "Width9", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setWidth", "Width10", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getHeight", "Height11", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setHeight", "Height12", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getHorizontal", "Horizontal13", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setHorizontal", "Horizontal14", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getVertical", "Vertical15", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "setVertical", "Vertical16", "(I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getTuple", "Tuple17", "()Lsystem/ValueType;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "New", "New18", "(II)Lgamelib/core/util/RawColumn;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "New", "New19", "(Lsystem/ValueType;)Lgamelib/core/util/RawColumn;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "New", "New20", "(Lgamelib/core/util/RawColumn;)Lgamelib/core/util/RawColumn;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "__ctorRawColumn0", "__ctorRawColumn0", "(Lnet/sf/jni4net/inj/IClrProxy;II)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "__ctorRawColumn1", "__ctorRawColumn1", "(Lnet/sf/jni4net/inj/IClrProxy;Lsystem/ValueType;)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "__ctorRawColumn2", "__ctorRawColumn2", "(Lnet/sf/jni4net/inj/IClrProxy;Lgamelib/core/util/RawColumn;)V"));
            return methods;
        }
        
        private static int CompareTo0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle other) {
            // (Lgamelib/core/util/RawColumn;)I
            // (LGameLib/Core/Util/RawColumn;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(((global::System.IComparable<GameLib.Core.Util.RawColumn>)(@__real)).CompareTo(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, other))));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Raw1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Raw));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Raw2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Raw = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Column3(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Column));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Column4(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Column = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int X5(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.X));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void X6(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.X = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Y7(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Y));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Y8(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Y = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Width9(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Width));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Width10(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Width = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Height11(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Height));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Height12(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Height = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Horizontal13(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Horizontal));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Horizontal14(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Horizontal = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Vertical15(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = ((int)(@__real.Vertical));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void Vertical16(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int value) {
            // (I)V
            // (I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__real.Vertical = value;
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Tuple17(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/ValueType;
            // ()[[[LSystem/ValueTuple`2;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Util.RawColumn @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::System.ValueTuple<int, int>>(@__env, @__real.Tuple);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle New18(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, int Raw, int Column) {
            // (II)Lgamelib/core/util/RawColumn;
            // (II)LGameLib/Core/Util/RawColumn;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::GameLib.Core.Util.RawColumn>(@__env, global::GameLib.Core.Util.RawColumn.New(Raw, Column));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle New19(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lsystem/ValueType;)Lgamelib/core/util/RawColumn;
            // ([[[LSystem/ValueTuple`2;)LGameLib/Core/Util/RawColumn;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::GameLib.Core.Util.RawColumn>(@__env, global::GameLib.Core.Util.RawColumn.New(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.ValueTuple<int, int>>(@__env, value)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle New20(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lgamelib/core/util/RawColumn;)Lgamelib/core/util/RawColumn;
            // (LGameLib/Core/Util/RawColumn;)LGameLib/Core/Util/RawColumn;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::GameLib.Core.Util.RawColumn>(@__env, global::GameLib.Core.Util.RawColumn.New(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, value)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void @__ctorRawColumn0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int Raw, int Column) {
            // (II)V
            // (II)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = new global::GameLib.Core.Util.RawColumn(Raw, Column);
            global::net.sf.jni4net.utils.Convertor.InitProxy(@__env, @__obj, @__real);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static void @__ctorRawColumn1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lsystem/ValueType;)V
            // ([[[LSystem/ValueTuple`2;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = new global::GameLib.Core.Util.RawColumn(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.ValueTuple<int, int>>(@__env, value));
            global::net.sf.jni4net.utils.Convertor.InitProxy(@__env, @__obj, @__real);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static void @__ctorRawColumn2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__class, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lgamelib/core/util/RawColumn;)V
            // (LGameLib/Core/Util/RawColumn;)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Util.RawColumn @__real = new global::GameLib.Core.Util.RawColumn(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, value));
            global::net.sf.jni4net.utils.Convertor.InitProxy(@__env, @__obj, @__real);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::GameLib.Core.Util.@__RawColumn(@__env);
            }
        }
    }
    #endregion
}
