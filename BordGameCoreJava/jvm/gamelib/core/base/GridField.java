// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package gamelib.core.base;

@net.sf.jni4net.attributes.ClrType
public class GridField extends gamelib.api.GameField {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected GridField(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    protected GridField() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native int getWidth();
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native int getHeight();
    
    @net.sf.jni4net.attributes.ClrMethod("()[I")
    public native int[] getField();
    
    @net.sf.jni4net.attributes.ClrMethod("(II)I")
    public native int getItem(int raw, int column);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;)I")
    public native int getItem(gamelib.core.util.RawColumn rc);
    
    @net.sf.jni4net.attributes.ClrMethod("([[[LSystem/ValueTuple`2;)I")
    public native int getItem(system.ValueType value);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)I")
    public native int Get(int raw, int column);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;)I")
    public native int Get(gamelib.core.util.RawColumn rc);
    
    @net.sf.jni4net.attributes.ClrMethod("([[[LSystem/ValueTuple`2;)I")
    public native int Get(system.ValueType value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;)Z")
    public native boolean InField(gamelib.core.util.RawColumn rc);
    
    @net.sf.jni4net.attributes.ClrMethod("(II)Z")
    public native boolean InField(int raw, int column);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;I)V")
    public native void OverWrite(gamelib.core.util.RawColumn point, int value);
    
    @net.sf.jni4net.attributes.ClrMethod("(I)I")
    public native int Count(int color);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Base/PlayerColor2P;)I")
    public native int Count(gamelib.core.base.PlayerColor2P color);
    
    @net.sf.jni4net.attributes.ClrMethod("(III)Z")
    public native boolean Canput(int r, int c, int t);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;I)Z")
    public native boolean Canput(gamelib.core.util.RawColumn rc, int t);
    
    public java.lang.Iterable<gamelib.core.util.RawColumn> ExistsIterable() {
        return new mitza.jni4net.wrapper.Iterable<gamelib.core.util.RawColumn>(Exists());
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()[[LSystem/Collections/Generic/IEnumerable`1;")
    public native system.collections.IEnumerable Exists();
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;)[[LGameLib/Core/Util/RawColumn;")
    public native gamelib.core.util.RawColumn[][] ScanRayRC(gamelib.core.util.RawColumn rc);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;)[[LGameLib/Core/Base/PlayerColor2P;")
    public native gamelib.core.base.PlayerColor2P[][] ScanRayColor(gamelib.core.util.RawColumn rc);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Util/RawColumn;LGameLib/Core/Util/RelativeName;I)LGameLib/Core/Util/RawColumn;")
    public native gamelib.core.util.RawColumn RelativePosition(gamelib.core.util.RawColumn rc, gamelib.core.util.RelativeName rp, int c);
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native int CheckWinner();
    
    public static system.Type typeof() {
        return gamelib.core.base.GridField.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.core.base.GridField.staticType = staticType;
    }
    //</generated-proxy>
}
