using UnityEngine;
using System.Collections;
using cReadConfigFile;

public class TestReadIni : MonoBehaviour
{
    public string tx1;
    public string tx;
    INIClass iniCls;
	// Use this for initialization
	void Start () {
        iniCls = new INIClass(Application.dataPath + "/config.ini");
        if (iniCls == null) Debug.LogError("");
        tx1 = iniCls.IniReadValue("Net", "port");
        tx = iniCls.IniReadValue("Net", "LaunchID");
        iniCls.IniWriteValue("Net", "LaunchI", "1234");
        Debug.LogError(tx1 + "--" + tx);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
