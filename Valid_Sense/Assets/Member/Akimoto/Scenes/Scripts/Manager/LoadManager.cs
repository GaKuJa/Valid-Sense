using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadManager : MonoBehaviour
{
    private string pas = "Assets/Member/Akimoto/Resources/Datas/SaveData/";
    public Notes LoadNotesDate(int date_num)
    {
        string date = "";
        if(File.Exists(pas + "notesData" + date_num + ".json"))
        {
            var reader = new StreamReader(pas + "notesData" + date_num + ".json");
            date = reader.ReadToEnd();
            reader.Close();
        }
        return JsonUtility.FromJson<Notes>(date);
    }
}
