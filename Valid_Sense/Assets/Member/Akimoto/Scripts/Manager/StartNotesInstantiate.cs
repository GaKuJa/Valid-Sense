using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesInstantiate : MonoBehaviour
{
    LoadManager load = new LoadManager();
    Notes _notes = new Notes();
    [SerializeField]
    private GameObject notes_obj;
    Notes notes_list;
    void Start()
    {
        if (load.LoadNotesDate(0) != null)
        {
            notes_list = load.LoadNotesDate(0);
        }
        for (int i = 0; i <= notes_list.NotesList.Count - 1; i++)
        {
            Instantiate(notes_obj, new Vector3(notes_list.NotesList[i].x,
                                               notes_list.NotesList[i].y,
                                               notes_list.NotesList[i].z), Quaternion.identity);
        }
    }
}
