using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;
using System.Text;

public class Button : MonoBehaviour
{
    private Notes _notes = new Notes();
    private int _saveIndex = 1;
    public void OnClickButton()
    {
        _notes.NotesList.Remove(_notes.NotesList.Last());
        Debug.Log(_notes.NotesList.Count);
        string flieName = "Assets/Member/Akimoto/Resources/Datas/" + "notesData" + _saveIndex.ToString() + ".json";
        using (var streamWriter = new StreamWriter(flieName, false, Encoding.Default))
        {
            var jsonText = JsonUtility.ToJson(_notes);
            streamWriter.Write(jsonText);
        }
        _saveIndex++;
    }
}
