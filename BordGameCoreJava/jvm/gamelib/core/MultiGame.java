// ------------------------------------------------------------------------------
//  <autogenerated>
//      This code was generated by jni4net. See http://jni4net.sourceforge.net/ 
// 
//      Changes to this file may cause incorrect behavior and will be lost if 
//      the code is regenerated.
//  </autogenerated>
// ------------------------------------------------------------------------------

package gamelib.core;

@net.sf.jni4net.attributes.ClrType
public class MultiGame extends gamelib.core.Game {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected MultiGame(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    protected MultiGame() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/MultiGame+OnDrawHandler;)V")
    public native void addOnDraw(system.MulticastDelegate value);
    
    @net.sf.jni4net.attributes.ClrMethod("(LGameLib/Core/MultiGame+OnDrawHandler;)V")
    public native void removeOnDraw(system.MulticastDelegate value);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void Start();
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void UpDate();
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void End();
    
    public static system.Type typeof() {
        return gamelib.core.MultiGame.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.core.MultiGame.staticType = staticType;
    }
    //</generated-proxy>
}
