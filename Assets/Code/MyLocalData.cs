using UnityEngine;
using System.Collections;

public class MyLocalData : MonoBehaviour
{
    private static MyLocalData _instance= new MyLocalData();
    public static MyLocalData Instance()
    {
        if (_instance == null)
        {
            _instance = new MyLocalData();
        }
        return _instance;
    }

    public class MyLocalSaveData
    {
        public int test01;
        public int test02;
        public int test03;
    }

    public MyLocalSaveData m_Data = new MyLocalSaveData();

    MyFileStream m_FS = new MyFileStream();

    string m_FileName = "LocalSaveData.txt";

    public void InitLoad()
    {
        if (m_FS.Open(m_FileName, System.IO.FileAccess.Read))
        {
            m_Data.test01 = 0;
            m_Data.test02 = 0;
            m_Data.test03 = 0;

            int Num = 0;
            if (int.TryParse(m_FS.ReadLine(), out Num))
            {
                m_Data.test01 = Num;
            }
            if (int.TryParse(m_FS.ReadLine(), out Num))
            {
                m_Data.test02 = Num;
            }
            if (int.TryParse(m_FS.ReadLine(), out Num))
            {
                m_Data.test03 = Num;
            }

            m_FS.Close();
        }

    }

    public void Write()
    {
        if (m_FS.Open(m_FileName, System.IO.FileAccess.Write))
        {
            m_FS.WriteLine(m_Data.test01.ToString());
            m_FS.WriteLine(m_Data.test02.ToString());
            m_FS.WriteLine(m_Data.test03.ToString());

            m_FS.Close();
        }
    }
}
