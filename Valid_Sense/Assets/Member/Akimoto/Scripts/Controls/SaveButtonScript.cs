using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveButtonScript : MonoBehaviour
{
    private int _saveTimingIndex = 1;
    private int _savePositionIndex = 1;
    private Notes _notes = new Notes();
    string fileName = "Assets/Member/Akimoto/Resources/Datas/SaveData/";
    void Start()
    {
        //time_notes = SaveTimingScriput.Instance._notes;
        //pos_notes = NotesChangePositionScript.Instance._notes;
    }
    public void ClickSaveTiming()
    {
        using (var streaWriter = new StreamWriter(fileName + "notesTimingDate" + _saveTimingIndex.ToString()+".json",false,Encoding.Default))
        {
            var jsonText = JsonUtility.ToJson(SaveTimingScriput.Instance._notes);
            streaWriter.Write(jsonText);
        }
        _saveTimingIndex++;
    }
    public void ClickSavePosition()
    {
        for(int i = 0; i < StartNotesTimingScript.Instance.notesObj_list.Count;i++)
        {
            _notes.NotesList.Add(NotesChangePositionScript.Instance.notes_list[i]);
        }
        using (var streaWriter = new StreamWriter(fileName + "notesPositionDate" + _savePositionIndex.ToString()+".json",false,Encoding.Default))
        {
            var jsonText = JsonUtility.ToJson(_notes.NotesList);
            streaWriter.Write(jsonText);
        }
        _savePositionIndex++;
    }
}