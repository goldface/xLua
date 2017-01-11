using XLua;
using UnityEngine;

using System.Collections.Generic;
using System;
public class LuaEnvSingleton  {
	
	static private LuaEnv instance = null;
	static public LuaEnv Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new LuaEnv();
			}
			
			return instance;
		}
	}
}

[LuaCallCSharp]
public class LuaTestCommon
{
#if     UNITY_IOS || UNITY_IPHONE
    public static string resultPath = Application.persistentDataPath + "/";
	public static string xxxtdrfilepath = Application.dataPath + "/Raw" + "/testxxx.tdr";
	public static string xxxtdr2filepath = Application.dataPath + "/Raw" + "/testxxx2.tdr";
	public static bool android_platform = false;
#elif   UNITY_ANDROID
    public static string resultPath = "/sdcard/luatest/";
	public static string xxxtdrfilepath = Application.streamingAssetsPath + "/testxxx.tdr";
	public static string xxxtdr2filepath = Application.streamingAssetsPath + "/testxxx2.tdr";
	public static bool android_platform = true;
#elif   UNITY_EDITOR
    public static string resultPath = Application.dataPath + "/xLuaTest/";
	public static string xxxtdrfilepath = Application.dataPath + "/StreamingAssets" + "/testxxx.tdr";
	public static string xxxtdr2filepath = Application.dataPath + "/StreamingAssets" + "/testxxx2.tdr";
	public static bool android_platform = false;
#else
#endif
	
	public static bool IsMacPlatform()
	{
#if UNITY_EDITOR
        string os = System.Environment.OSVersion.ToString();
        if (os.Contains("Unix"))
        {
            return true;
        }
        else
        {
            return false;
        }
#else
        return false;
#endif
	}

	public static bool IsIOSPlatform()
	{
#if UNITY_IOS || UNITY_IPHONE
		return true;
#else
		return false;
#endif
	}
}

//注意：用户自己代码不建议在这里配置，建议通过标签来声明!!
public class TestCaseGenConfig : XLua.GenConfig
{

    //lua中要使用到C#库的配置，比如C#标准库，或者Unity API，第三方库等。
    public List<Type> LuaCallCSharp
    {
        get
        {
            return new List<Type>()
            {
                typeof(UnityEngine.TextAsset),
            };
        }
    }

    //C#静态调用Lua的配置（包括事件的原型），仅可以配delegate，interface
    public List<Type> CSharpCallLua {
        get
        {
            return null;
        }
    }

    //黑名单
    public List<List<string>> BlackList
    {
        get
        {
            return null;
        }
    }
}
