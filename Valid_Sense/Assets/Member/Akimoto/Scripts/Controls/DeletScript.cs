using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeletScript : MonoBehaviour
{
    public static DeletScript Instance { get => _instance; }
    static DeletScript _instance;
    Notes _notes;
    void Awake()
    {
        _instance = this;
    }
    public void NotesDelet(int list_num)
    {
        _notes = StartNotesTimingScript.Instance.notes;

        _notes.NotesTypeList.Remove(_notes.NotesTypeList[list_num]);
        _notes.TimeList.Remove(_notes.NotesTypeList[list_num]);
        StartNotesTimingScript.Instance.notesObj_list[list_num].gameObject.SetActive(false);
        StartNotesTimingScript.Instance.notesObj_list.Remove(StartNotesTimingScript.Instance.notesObj_list[list_num]);
        Debug.Log(StartNotesTimingScript.Instance.notesObj_list[list_num].name);
    }
}
