using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;
using System.IO;
public class _003_DefineLoader : MonoBehaviour {


	
	void Start () {
        LuaEnv env = new LuaEnv();
        env.AddLoader(MyLoader);
        env.DoString("require 'downloadfile'");
	}


    private byte[] MyLoader(ref string filepath)
    {
        string path = Application.streamingAssetsPath + "/" + filepath + ".lua.txt";

        return File.ReadAllBytes(path);        
        
    }

	
}
