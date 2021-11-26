using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveNotesTypeScript : MonoBehaviour
{
    public static SaveNotesTypeScript Instance { get => _instance; }
    static SaveNotesTypeScript _instance;
    public Notes _notes = new Notes();
    void Awake()
    {
        _instance = this;
    }
    public void SaveNotesType(int notesType_num)
    {
        _notes.NotesTypeList.Add(notesType_num);
    }
}
