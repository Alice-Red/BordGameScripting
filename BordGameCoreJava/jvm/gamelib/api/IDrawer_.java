// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package gamelib.api;

@net.sf.jni4net.attributes.ClrTypeInfo
public final class IDrawer_ {
    
    //<generated-static>
    private static system.Type staticType;
    
    public static system.Type typeof() {
        return gamelib.api.IDrawer_.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.api.IDrawer_.staticType = staticType;
    }
    //</generated-static>
}

//<generated-proxy>
@net.sf.jni4net.attributes.ClrProxy
class __IDrawer extends system.Object implements gamelib.api.IDrawer {
    
    protected __IDrawer(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Base/GridField;)V")
    public native void DrawPanel(gamelib.core.base.GridField field);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/Base/GridField;)V")
    public native void DrawConsole(gamelib.core.base.GridField field);
}
//</generated-proxy>