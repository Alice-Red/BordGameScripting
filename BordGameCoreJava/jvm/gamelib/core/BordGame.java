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
public class BordGame extends gamelib.core.Game {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected BordGame(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    protected BordGame() {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/Type;LSystem/Type;)V")
    public native void SetPlayer(system.Type pl1, system.Type pl2);
    
    @net.sf.jni4net.attributes.ClrMethod("()V")
    public native void Draw();
    
    public static system.Type typeof() {
        return gamelib.core.BordGame.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.core.BordGame.staticType = staticType;
    }
    //</generated-proxy>
}
