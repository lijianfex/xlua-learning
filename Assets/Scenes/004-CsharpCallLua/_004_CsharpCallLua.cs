using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XLua;

public class _004_CsharpCallLua : MonoBehaviour
{

    private LuaEnv env;

    [CSharpCallLua]
    public delegate void addNum();
    

    [CSharpCallLua]
    private delegate void Add(int a,int b);

    [CSharpCallLua]
    public  delegate int AddRes(int a, int b,out int c, out int d);
    public event AddRes AddResEvent;

    void Start()
    {
        env = new LuaEnv();

        env.DoString("require 'CSharpCallLua'");

        //int a = env.Global.Get<int>("a"); //获取lua中的全局变量a
        //print(a);

        //string name = env.Global.Get<string>("name"); //获取lua中的全局变量name
        //print(name);

        //bool isDie = env.Global.Get<bool>("isDie"); //获取lua中的全局变量isDie
        //print(isDie);

        //1,通过class(struct)

        //Person p = env.Global.Get<Person>("person");
        //print(p.name);
        //print(p.age);

        //2，通过interface

        //IPerson p = env.Global.Get<IPerson>("person");
        //print(p.name);
        //print(p.age);

        //p.name = "hello fex";
        //env.DoString("print(person.name)");

        //p.eat(10, 10);

        //3.通过Dictionary<> 与 List<>

        //Dictionary<string, object> dict = env.Global.Get<Dictionary<string, object>>("person");
        //foreach(string key in dict.Keys)
        //{
        //    print(key + ":" + dict[key]);
        //}

        //print("-------------");
        //List<object> list = env.Global.Get<List<object>>("person");
        //foreach(object o in list)
        //{
        //    print(o);
        //}

        //4.通过xLua提供的LuaTable

        //LuaTable luaTable = env.Global.Get<LuaTable>("person");
        //string name= luaTable.Get<string>("name");
        //print(name);

        //print(luaTable.Length);

        //访问function:映射到delegate

        ////1、 可映射lua中的无参，无返回值function
        //addNum addNum = env.Global.Get<addNum>("AddNum");
        //addNum();
        //addNum = null;//将委托注销

        //print("-----------------------------------");
        //2、 可映射lua中的有参，无返回值function
        //Add add = env.Global.Get<Add>("Add");
        //add(12, 13);
        //add = null;//将委托注销

        //print("-----------------------------------");
        // 3、可映射lua中的有参，有返回值function,可以将取得委托存在事件中
        //AddResEvent = env.Global.Get<AddRes>("AddRes");        
        //int a, b;
        //int res = AddResEvent(12, 13, out a, out b);
        //print(res);
        //print(a);
        //print(b);
        //AddResEvent = null;//将委托注销

        //访问function 通过LuaFunction 
        LuaFunction func = env.Global.Get<LuaFunction>("AddRes");
        object[] os= func.Call(3, 7);
        foreach(object o in os)
        {
            print(o);
        }

    }

    private void OnDestroy()
    {
        env.Dispose();
    }

    class Person
    {
        public string name;
        public int age;
    }

    [CSharpCallLua]
    interface IPerson
    {
        string name { get; set; }
        int age { get; set; }
        void eat(int a, int b);
    }
}
