using UnityEngine;
using System.Collections;
using IniFiles;

public class LocalDate : MonoBehaviour {
    public static int angle;
    public static float xMax;
    public static IniFile configIni = new IniFile();
    void Awake()
    {

        ByteReader br;

        br = LoadConfigFromFile("kk.txt");
        if (br != null)
        {
            configIni.LoadFromByteReader(br);
        }
        angle = configIni.GetInteger("K", "Angle");
        xMax = configIni.GetFloat("K", "XMax");
//        Debug.LogError(angle + "l" + xMax);
    }
    private const string CustomPath01 = "C:/kk/";
    private static string GetConfigRootPath()
    {
        switch (Application.platform)
        {
            case RuntimePlatform.Android:
                return Application.persistentDataPath + "/Config/";
            case RuntimePlatform.WindowsPlayer:
                // return Application.dataPath + "/Config/";
                return CustomPath01;
            case RuntimePlatform.WindowsEditor:
                // 放到Assets的上级目录，不影响提交SVN
                return Application.dataPath + "/../kk/";
            // return CustomPath01;
            default:
                return Application.dataPath + "/kk/";
        }
    }
    public static string GetFullFileName(string sCfgName)
    {
        string strPath = GetConfigRootPath();
        return strPath + sCfgName;
    }
    private static ByteReader LoadConfigFromFile(string sCfgFileName)
    {
        string strFullFileName = GetFullFileName(sCfgFileName);
        ByteReader res = null;
        try
        {
            if (System.IO.File.Exists(strFullFileName))
            {
                res = ByteReader.Open(strFullFileName);
            }
        }
        catch (System.IO.IOException)
        {
            res = null;
        }
        if (res == null)
        {
            Debug.LogWarning(string.Format("Warning: failed to open file: {0}", strFullFileName));
        }
        return res;
    }
	void Start () {
	
	}
	
	void Update () {
	
	}
}
