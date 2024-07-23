using System.IO;
using MoonSharp.Interpreter;
using UnityEngine;

public class ScriptParser : MonoBehaviour
{
    public Script luaScript;
    private DynValue luaUpdate;

    public void Start()
    {
        string path = PlayerPrefs.GetString("pathscript");
        string script = File.ReadAllText(path);

        luaScript = new Script();

        LUASceneManager LuaSceneManager = new LUASceneManager();
        UserData.RegisterType<LUASceneManager>();
        luaScript.Globals["scene"] = LuaSceneManager;

        LUAEcho LuaEcho = new LUAEcho();
        UserData.RegisterType<LUAEcho>();
        luaScript.Globals["echo"] = LuaEcho;

        LUAInput LuaInput = new LUAInput();
        UserData.RegisterType<LUAInput>();
        luaScript.Globals["input"] = LuaInput;

        LUACamera LuaCamera = new LUACamera();
        UserData.RegisterType<LUACamera>();
        luaScript.Globals["camera"] = LuaCamera;

        LUAGet LuaGet = new LUAGet();
        UserData.RegisterType<LUAGet>();
        luaScript.Globals["get"] = LuaGet;

        try 
        {
            luaScript.DoString(script);

            luaUpdate = luaScript.Globals.Get("Update");
        } catch {
            LUAEcho.EchoErr("An error occured in the script");
        }
    }

    public void Update()
    {
        try 
        {
            if (luaUpdate.Type == DataType.Function)
            {
                luaScript.Call(luaUpdate, Time.deltaTime);
            }
        } 
        catch 
        {
            LUAEcho.EchoErr("An error occured in update function");
        }
    }
}
