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
public class LibraryLoader extends system.Object {
    
    //<generated-proxy>
    private static system.Type staticType;
    
    protected LibraryLoader(net.sf.jni4net.inj.INJEnv __env, long __handle) {
            super(__env, __handle);
    }
    
    @net.sf.jni4net.attributes.ClrConstructor("(LSystem/String;)V")
    public LibraryLoader(java.lang.String path) {
            super(((net.sf.jni4net.inj.INJEnv)(null)), 0);
        gamelib.api.LibraryLoader.__ctorLibraryLoader0(this, path);
    }
    
    @net.sf.jni4net.attributes.ClrMethod("(Ljava/lang/String;)V")
    private native static void __ctorLibraryLoader0(net.sf.jni4net.inj.IClrProxy thiz, java.lang.String path);
    
    @net.sf.jni4net.attributes.ClrMethod("()[LGameLib/API/LibraryObject;")
    public native gamelib.api.LibraryObject[] getLibs();
    
    @net.sf.jni4net.attributes.ClrMethod("()[LSystem/Reflection/Assembly;")
    public native system.reflection.Assembly[] getGames();
    
    @net.sf.jni4net.attributes.ClrMethod("()[LSystem/Reflection/Assembly;")
    public native system.reflection.Assembly[] getInputters();
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)[LSystem/Reflection/Assembly;")
    public native system.reflection.Assembly[] Inpuuters(java.lang.String id);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)LGameLib/API/LibraryObject;")
    public native static gamelib.api.LibraryObject LoadFile(java.lang.String file);
    
    @net.sf.jni4net.attributes.ClrMethod("(LSystem/String;)[LGameLib/API/LibraryObject;")
    public native static gamelib.api.LibraryObject[] LoadFolder(java.lang.String folder);
    
    public static system.Type typeof() {
        return gamelib.api.LibraryLoader.staticType;
    }
    
    private static void InitJNI(net.sf.jni4net.inj.INJEnv env, system.Type staticType) {
        gamelib.api.LibraryLoader.staticType = staticType;
    }
    //</generated-proxy>
}
