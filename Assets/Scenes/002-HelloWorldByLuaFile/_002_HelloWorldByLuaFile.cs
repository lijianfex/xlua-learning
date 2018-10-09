using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
public class _002_HelloWorldByLuaFile : MonoBehaviour {

    private LuaEnv env; 

	void Start () {
        env = new LuaEnv();
        //TextAsset ta = Resources.Load<TextAsset>("helloworld.lua");
        
        env.DoString("require 'helloworld'");

	}

    private void OnDestroy()
    {
        env.Dispose();
    }
}
