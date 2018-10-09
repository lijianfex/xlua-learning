
using UnityEngine;
using XLua;

/// <summary>
/// 使用C#执行Lua语句
/// </summary>

public class _001_HelloWorld : MonoBehaviour
{
    
    private LuaEnv env;

    void Start()
    {
        env = new LuaEnv();//创建Lua虚拟环境
        env.DoString("print('hello world')");//执行Lua语句
        env.DoString("CS.UnityEngine.Debug.Log('hello world')");//lua语句中调用unity中的C#方法

    }

    void Update()
    {

    }

    private void OnDestroy()
    {
        env.Dispose();
    }
}
