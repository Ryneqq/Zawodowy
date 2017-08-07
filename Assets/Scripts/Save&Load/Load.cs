using System.Collections.Generic;
using System.Text;
using UnityEngine;

public static class Load
{

    private static string path;        // ścieżka do pliku bazą 

    public static void Setup(){
        path = Application.persistentDataPath + "/";
        //Debug.Log(path);
    }

    public static List<string> StringToList(string read){
        List<string> list = new List<string>();
        string[] contents = read.Split('|');
        for(int i = 0; i < contents.Length; i++){
            list.Add(contents[i]);
        }
        return list;
    }

    public static string Read(string from){
        string filePath = path + from;
        string read = System.IO.File.ReadAllText(filePath); // usunąłem encoding.default
        if (read != null){
            return read;
        }
        return string.Empty;
    }

    public static void Delete(string what){
        string filePath = path + what;
        if(System.IO.File.Exists(filePath)){
            System.IO.File.Delete(filePath);
        }
    }

    public static bool Check(string what){
        string filePath = path + what;        
        if(System.IO.File.Exists(filePath)){
            return true;
        }
        return false;
    }
}
