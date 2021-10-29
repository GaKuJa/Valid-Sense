using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    public Notes LoadNotesDate(int date_num)
    {
        string date = "";
        if(File.Exists("Assets/Member/Akimoto/Resources/Datas/" + "notesData" + date_num + ".json") == true)
        {
            StreamReader reader = new StreamReader("Assets/Member/Akimoto/Resources/Datas/" + "notesData" + date_num + ".json");
            date = reader.ReadToEnd();
            reader.Close();
        }
        return JsonUtility.FromJson<Notes>(date);
    }
}
