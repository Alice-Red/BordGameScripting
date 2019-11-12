@echo off
if not exist target mkdir target
if not exist target\classes mkdir target\classes


echo compile classes
javac -nowarn -d target\classes -sourcepath jvm -cp "d:\library\jni4net-0-8-generics\distributable\jni4net.j-0.8.7.0.jar"; "jvm\gamelib/api\IInputObjectContainer.java" "jvm\gamelib/api\IInputObjectContainer_.java" "jvm\gamelib/api\IDrawer.java" "jvm\gamelib/api\IDrawer_.java" "jvm\rutil\Utility.java" "jvm\rutil\IO.java" "jvm\rutil\Decimal32.java" "jvm\gamelib/core\Game.java" "jvm\gamelib/core\BordGame.java" "jvm\gamelib/core\MultiGame.java" "jvm\gamelib/core\OnDrawArgs.java" "jvm\gamelib/core\OnInputArgs.java" "jvm\gamelib/core\SingleGame.java" "jvm\gamelib/core/util\ConsoleOut.java" "jvm\gamelib/core/util\Converter.java" "jvm\gamelib/core/util\Message.java" "jvm\gamelib/core/util\MessageType.java" "jvm\gamelib/core/util\RawColumn.java" "jvm\gamelib/core/util\RawColumnUtil.java" "jvm\gamelib/core/util\RelativeName.java" "jvm\gamelib/core/util\Relative.java" "jvm\gamelib/core/util\SafeArray`1.java" "jvm\gamelib/core/base\BordGameArgmentObjectContainer.java" "jvm\gamelib/api\GameField.java" "jvm\gamelib/core/base\GridField.java" "jvm\gamelib/core/base\PlayerColor1P.java" "jvm\gamelib/core/base\PlayerColor2P.java" "jvm\gamelib/core/base\PlayerColor4P.java" "jvm\gamelib/api\EventArgments.java" "jvm\gamelib/api\GameAddonAttribute.java" "jvm\gamelib/api\GameClient.java" "jvm\gamelib/api\LibraryLoader.java" "jvm\gamelib/api\LibraryObject.java" "jvm\gamelib/api\LibraryType.java" "jvm\gamelib/api\Util.java" "jvm\gamelib/api\GameInputter.java" "jvm\gamelib/api\IO.java" 
IF %ERRORLEVEL% NEQ 0 goto end


echo GameLib.j4n.jar 
jar cvf GameLib.j4n.jar  -C target\classes "gamelib\api\IInputObjectContainer.class"  -C target\classes "gamelib\api\IInputObjectContainer_.class"  -C target\classes "gamelib\api\__IInputObjectContainer.class"  -C target\classes "gamelib\api\IDrawer.class"  -C target\classes "gamelib\api\IDrawer_.class"  -C target\classes "gamelib\api\__IDrawer.class"  -C target\classes "rutil\Utility.class"  -C target\classes "rutil\IO.class"  -C target\classes "rutil\Decimal32.class"  -C target\classes "gamelib\core\Game.class"  -C target\classes "gamelib\core\BordGame.class"  -C target\classes "gamelib\core\MultiGame.class"  -C target\classes "gamelib\core\OnDrawArgs.class"  -C target\classes "gamelib\core\OnInputArgs.class"  -C target\classes "gamelib\core\SingleGame.class"  -C target\classes "gamelib\core\util\ConsoleOut.class"  -C target\classes "gamelib\core\util\Converter.class"  -C target\classes "gamelib\core\util\Message.class"  -C target\classes "gamelib\core\util\MessageType.class"  -C target\classes "gamelib\core\util\RawColumn.class"  -C target\classes "gamelib\core\util\RawColumnUtil.class"  -C target\classes "gamelib\core\util\RelativeName.class"  -C target\classes "gamelib\core\util\Relative.class"  -C target\classes "gamelib\core\util\SafeArray`1.class"  -C target\classes "gamelib\core\base\BordGameArgmentObjectContainer.class"  -C target\classes "gamelib\api\GameField.class"  -C target\classes "gamelib\core\base\GridField.class"  -C target\classes "gamelib\core\base\PlayerColor1P.class"  -C target\classes "gamelib\core\base\PlayerColor2P.class"  -C target\classes "gamelib\core\base\PlayerColor4P.class"  -C target\classes "gamelib\api\EventArgments.class"  -C target\classes "gamelib\api\GameAddonAttribute.class"  -C target\classes "gamelib\api\GameClient.class"  -C target\classes "gamelib\api\LibraryLoader.class"  -C target\classes "gamelib\api\LibraryObject.class"  -C target\classes "gamelib\api\LibraryType.class"  -C target\classes "gamelib\api\Util.class"  -C target\classes "gamelib\api\GameInputter.class"  -C target\classes "gamelib\api\IO.class"  > nul 
IF %ERRORLEVEL% NEQ 0 goto end


echo GameLib.j4n.dll 
csc /nologo /warn:0 /t:library /out:GameLib.j4n.dll /recurse:clr\*.cs  /reference:"D:\Java_Cs\Visual Studio 2019\Projects\BordGameScripting\BordGameCore\bin\Debug\GameLib.dll" /reference:"D:\Library\jni4net-0-8-generics\distributable\jni4net.n-0.8.7.0.dll"
IF %ERRORLEVEL% NEQ 0 goto end


:end
