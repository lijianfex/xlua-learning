using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

[LuaCallCSharp]
public class BaseClass
{
    public static void BSFunc()
    {
        Debug.Log("运行基类静态方法, 静态属性：BSF = " + BSF);
    }

    public static int BSF = 1;

    public void BMFunc()
    {
        Debug.Log("运行基类成员方法, 成员属性：BMF = " + BMF);
    }

    public int BMF { get; set; }
}

public struct Param1
{
    public int x;
    public string y;
}

[LuaCallCSharp]
public class DrivenClass : BaseClass
{
    public void DMFunc()
    {
        Debug.Log("运行子类成员方法,成员属性： DMF = " + DMF);
    }

    public int DMF { get; set; }

    //复杂函数，参数的输入输出属性（out，ref）
    public double ComplexFunc(Param1 p1, ref int p2, out string p3, Action luafunc, out Action csfunc)
    {
        Debug.Log("P1 = {x=" + p1.x + ",y=" + p1.y + "},p2 = " + p2);
        luafunc();
        p2 = p2 * p1.x;
        p3 = "hello " + p1.y;
        csfunc = () =>
        {
            Debug.Log("csharp callback invoked!");
        };
        return 1.23;
    }

    //重载方法
    public void TestFunc(int i)
    {
        Debug.Log("TestFunc(int i)：参数为int类型");
    }

    public void TestFunc(string i)
    {
        Debug.Log("TestFunc(string i)：参数为string类型");
    }
}


public class _005_LuaCallCSharp : MonoBehaviour {

    private LuaEnv env;
	
	void Start ()
    {
        env = new LuaEnv();
        env.DoString("require 'LuaCallCSharp'");
    }
    

    private void Update()
    {
        if(env!=null)
        {
            env.Tick();
        }
    }

    private void OnDestroy()
    {
        env.Dispose();
    }

}
