using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class LoadPositionScript : MonoBehaviour
{
    private string pas = "Assets/Member/Akimoto/Resources/Datas/SaveData/";
    public Notes LoadNotesDate(int date__num)
    {
        string date = "";
        if(File.Exists(pas + "notesPositionDate" + date__num + ".json"))
        {
            var reader = new StreamReader(pas + "notesPositionDate" + date__num + ".json");
            date = reader.ReadToEnd();
            reader.Close();
        }
        return JsonUtility.FromJson<Notes>(date);
    }
}
