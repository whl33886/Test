using UnityEngine;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class MyFileStream
{
    FileStream file;

    StreamReader st;
    StreamWriter sw;

    public bool Open(string FileName, FileAccess Mode)
    {
        bool Success = false;
        string path = PathForDocumentsFile(FileName);

        if (Mode == FileAccess.Read)
        {
            if (File.Exists(path))
            {
                file = new FileStream(path, FileMode.Open, FileAccess.Read);
                if (file != null)
                {
                    st = new StreamReader(file);
                    Success = true;
                }
            }
        }
        else if (Mode == FileAccess.Write)
        {
            file = new FileStream(path, FileMode.Create, FileAccess.Write);
            if (file != null)
            {
                sw = new StreamWriter(file);
                Success = true;
            }
        }
        return Success;
    }

    public string ReadLine()
    {
        return st.ReadLine();
    }

    public void WriteLine(string Line)
    {
        sw.WriteLine(Line);
    }

    public void Close()
    {
        if (st != null)
        {
            st.Close();
            st = null;
        }
        if (sw != null)
        {
            sw.Close();
            sw = null;
        }
        if (file != null)
        {
            file.Close();
            file = null;
        }
    }

    public string PathForDocumentsFile(string filename)
    {
        //暂时只判断安卓和PC
        if (Application.platform == RuntimePlatform.Android)
        {
            string path = Application.persistentDataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
        else
        {
            string path = Application.dataPath;
            path = path.Substring(0, path.LastIndexOf('/'));
            return Path.Combine(path, filename);
        }
    }

}
