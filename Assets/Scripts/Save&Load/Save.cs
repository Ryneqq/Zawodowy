using System.Collections.Generic;
using System.IO;
using UnityEngine;

/// <Save>
/// Metoda pozwala na zapisanie aktualnej bazy do pliku tekstowego
/// nie jest ona kompatybilna z testownikiem na komputery
/// progress jest tylko na telefonie
/// </Save>
public static class Save {
    private static string path;
    
    public static void Setup(){
        path = Application.persistentDataPath + "/";
    }

    private static string ListToString(List<string> list){
        string contents = string.Empty;
        for (int i = 0; i < list.Count; i++){
            if(i!=0)
                contents +="|";
            contents += list[i];
        }
        return contents;
    }
    
    public static void Write(List<string> what, string to){
        string filePath = path + to;
        string contents = ListToString(what);

        if (System.IO.File.Exists(filePath)){
            System.IO.File.Delete(filePath);
        }

        using (StreamWriter file = new StreamWriter(filePath, true)){
            file.Write(contents);
            file.Close();
        }
    }
}
