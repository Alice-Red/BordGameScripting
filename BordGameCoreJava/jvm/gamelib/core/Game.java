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
public class Game extends system.Object {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected Game(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    protected Game() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("()I")
    public native int getMaxPlayer();
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void Run();
    
    @net.sf.jni4net.attributes.ClrMethod("([LGameLib/API/GameInputter;)V")
    public native void StorePlayer(gamelib.api.GameInputter[] players);
    
    public static system.Type typeof() {
        return gamelib.core.Game.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.core.Game.staticType = staticType;
    }
    //</generated-proxy>
}
