// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package gamelib.api;

@net.sf.jni4net.attributes.ClrType
public class EventArgments extends system.Object {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected EventArgments(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrConstructor("()V")
    public EventArgments() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
        gamelib.api.EventArgments.__ctorEventArgments0(this);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    private native static void __ctorEventArgments0(net.sf.jni4net.inj.IClrProxy thiz);
    
    public static system.Type typeof() {
        return gamelib.api.EventArgments.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.api.EventArgments.staticType = staticType;
    }
    //</generated-proxy>
}
