//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GameLib.Core.Base {
    
    
    #region Component Designer generated code 
    public partial class GridField_ {
        
        public static global::java.lang.Class _class {
            get {
                return global::GameLib.Core.Base.@__GridField.staticClass;
            }
        }
    }
    #endregion
    
    #region Component Designer generated code 
    [global::net.sf.jni4net.attributes.JavaProxyAttribute(typeof(global::GameLib.Core.Base.GridField), typeof(global::GameLib.Core.Base.GridField_))]
    [global::net.sf.jni4net.attributes.ClrWrapperAttribute(typeof(global::GameLib.Core.Base.GridField), typeof(global::GameLib.Core.Base.GridField_))]
    internal sealed partial class @__GridField : global::java.lang.Object {
        
        internal new static global::java.lang.Class staticClass;
        
        private @__GridField(global::net.sf.jni4net.jni.JNIEnv @__env) : 
                base(@__env) {
        }
        
        private static void InitJNI(global::net.sf.jni4net.jni.JNIEnv @__env, java.lang.Class @__class) {
            global::GameLib.Core.Base.@__GridField.staticClass = @__class;
        }
        
        private static global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> @__Init(global::net.sf.jni4net.jni.JNIEnv @__env, global::java.lang.Class @__class) {
            global::System.Type @__type = typeof(__GridField);
            global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod> methods = new global::System.Collections.Generic.List<global::net.sf.jni4net.jni.JNINativeMethod>();
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getWidth", "Width0", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getHeight", "Height1", "()I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getField", "Field2", "()[I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getItem", "Item3", "(II)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getItem", "Item4", "(Lgamelib/core/util/RawColumn;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "getItem", "Item5", "(Lsystem/ValueType;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Get", "Get6", "(II)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Get", "Get7", "(Lgamelib/core/util/RawColumn;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Get", "Get8", "(Lsystem/ValueType;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "InField", "InField9", "(Lgamelib/core/util/RawColumn;)Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "InField", "InField10", "(II)Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "OverWrite", "OverWrite11", "(Lgamelib/core/util/RawColumn;I)V"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Count", "Count12", "(I)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Count", "Count13", "(Lgamelib/core/base/PlayerColor2P;)I"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Canput", "Canput14", "(III)Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Canput", "Canput15", "(Lgamelib/core/util/RawColumn;I)Z"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "Exists", "Exists16", "()Lsystem/collections/IEnumerable;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "ScanRayRC", "ScanRayRC17", "(Lgamelib/core/util/RawColumn;)[[Lgamelib/core/util/RawColumn;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "ScanRayColor", "ScanRayColor18", "(Lgamelib/core/util/RawColumn;)[[Lgamelib/core/base/PlayerColor2P;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "RelativePosition", "RelativePosition19", "(Lgamelib/core/util/RawColumn;Lgamelib/core/util/RelativeName;I)Lgamelib/core/uti" +
                        "l/RawColumn;"));
            methods.Add(global::net.sf.jni4net.jni.JNINativeMethod.Create(@__type, "CheckWinner", "CheckWinner20", "()I"));
            return methods;
        }
        
        private static int Width0(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Width));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Height1(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Height));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Field2(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()[I
            // ()[I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayPrimC2J(@__env, @__real.Field);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Item3(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int raw, int column) {
            // (II)I
            // (II)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real[raw, column]));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Item4(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc) {
            // (Lgamelib/core/util/RawColumn;)I
            // (LGameLib/Core/Util/RawColumn;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real[global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc)]));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Item5(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lsystem/ValueType;)I
            // ([[[LSystem/ValueTuple`2;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real[global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.ValueTuple<int, int>>(@__env, value)]));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Get6(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int raw, int column) {
            // (II)I
            // (II)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Get(raw, column)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Get7(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc) {
            // (Lgamelib/core/util/RawColumn;)I
            // (LGameLib/Core/Util/RawColumn;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Get(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc))));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Get8(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle value) {
            // (Lsystem/ValueType;)I
            // ([[[LSystem/ValueTuple`2;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Get(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::System.ValueTuple<int, int>>(@__env, value))));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool InField9(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc) {
            // (Lgamelib/core/util/RawColumn;)Z
            // (LGameLib/Core/Util/RawColumn;)Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((bool)(@__real.InField(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc))));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool InField10(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int raw, int column) {
            // (II)Z
            // (II)Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((bool)(@__real.InField(raw, column)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static void OverWrite11(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle point, int value) {
            // (Lgamelib/core/util/RawColumn;I)V
            // (LGameLib/Core/Util/RawColumn;I)V
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__real.OverWrite(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, point), value);
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
        }
        
        private static int Count12(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int color) {
            // (I)I
            // (I)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Count(color)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int Count13(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle color) {
            // (Lgamelib/core/base/PlayerColor2P;)I
            // (LGameLib/Core/Base/PlayerColor2P;)I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.Count(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.PlayerColor2P>(@__env, color))));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool Canput14(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, int r, int c, int t) {
            // (III)Z
            // (III)Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((bool)(@__real.Canput(r, c, t)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static bool Canput15(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc, int t) {
            // (Lgamelib/core/util/RawColumn;I)Z
            // (LGameLib/Core/Util/RawColumn;I)Z
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            bool @__return = default(bool);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((bool)(@__real.Canput(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc), t)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle Exists16(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()Lsystem/collections/IEnumerable;
            // ()[[LSystem/Collections/Generic/IEnumerable`1;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.FullC2J<global::System.Collections.IEnumerable>(@__env, Mitza.Jni4Net.Convertor.ToIEnumerable(@__real.Exists()));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle ScanRayRC17(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc) {
            // (Lgamelib/core/util/RawColumn;)[[Lgamelib/core/util/RawColumn;
            // (LGameLib/Core/Util/RawColumn;)[[LGameLib/Core/Util/RawColumn;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayStrongC2Jp<global::GameLib.Core.Util.RawColumn[][], global::GameLib.Core.Util.RawColumn[]>(@__env, @__real.ScanRayRC(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle ScanRayColor18(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc) {
            // (Lgamelib/core/util/RawColumn;)[[Lgamelib/core/base/PlayerColor2P;
            // (LGameLib/Core/Util/RawColumn;)[[LGameLib/Core/Base/PlayerColor2P;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.ArrayStrongC2Jp<global::GameLib.Core.Base.PlayerColor2P[][], global::GameLib.Core.Base.PlayerColor2P[]>(@__env, @__real.ScanRayColor(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc)));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static global::net.sf.jni4net.utils.JniHandle RelativePosition19(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj, global::net.sf.jni4net.utils.JniLocalHandle rc, global::net.sf.jni4net.utils.JniLocalHandle rp, int c) {
            // (Lgamelib/core/util/RawColumn;Lgamelib/core/util/RelativeName;I)Lgamelib/core/util/RawColumn;
            // (LGameLib/Core/Util/RawColumn;LGameLib/Core/Util/RelativeName;I)LGameLib/Core/Util/RawColumn;
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            global::net.sf.jni4net.utils.JniHandle @__return = default(global::net.sf.jni4net.utils.JniHandle);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = global::net.sf.jni4net.utils.Convertor.StrongC2Jp<global::GameLib.Core.Util.RawColumn>(@__env, @__real.RelativePosition(global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RawColumn>(@__env, rc), global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Util.RelativeName>(@__env, rp), c));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        private static int CheckWinner20(global::System.IntPtr @__envp, global::net.sf.jni4net.utils.JniLocalHandle @__obj) {
            // ()I
            // ()I
            global::net.sf.jni4net.jni.JNIEnv @__env = global::net.sf.jni4net.jni.JNIEnv.Wrap(@__envp);
            int @__return = default(int);
            try {
            global::GameLib.Core.Base.GridField @__real = global::net.sf.jni4net.utils.Convertor.StrongJp2C<global::GameLib.Core.Base.GridField>(@__env, @__obj);
            @__return = ((int)(@__real.CheckWinner()));
            }catch (global::System.Exception __ex){@__env.ThrowExisting(__ex);}
            return @__return;
        }
        
        new internal sealed class ContructionHelper : global::net.sf.jni4net.utils.IConstructionHelper {
            
            public global::net.sf.jni4net.jni.IJvmProxy CreateProxy(global::net.sf.jni4net.jni.JNIEnv @__env) {
                return new global::GameLib.Core.Base.@__GridField(@__env);
            }
        }
    }
    #endregion
}
