using UnityEngine;
using System.Collections;
public class test : MonoBehaviour {

	// Use this for initialization
	void Start () {
        MyLocalData.Instance().m_Data.test01 = 3;
        MyLocalData.Instance().Write();
     int k=6;
        k =MyLocalData.Instance().m_Data.test02;
     Debug.Log(k);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
