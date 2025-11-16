using UnityEngine;
using System.IO;

public class FileUtilities {

    public static byte[] ReadFile(string path) {
        FileStream fs = new FileStream(path, FileMode.Open, FileAccess.Read);
        byte[] thebytes = new byte[(int)fs.Length];
        fs.Read(thebytes, 0, (int)fs.Length);
        fs.Close();
        return thebytes;
    }

    public static void WriteFile(string path, byte[] bytes) {
        Debug.Log("Attempting to write file " + path);
        FileStream fs = new System.IO.FileStream(path, FileMode.Create);
        fs.Write(bytes, 0, bytes.Length);
        fs.Close();
    }

    public static bool FileExists(string path) {
        return File.Exists(path);
    }
}
