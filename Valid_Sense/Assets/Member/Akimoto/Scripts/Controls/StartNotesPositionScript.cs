using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesPositionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject notes_object;
    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;
    private void Start()
    {
        if(load_Pos.LoadNotesDate(1) != null)
        {
            notes = load_Pos.LoadNotesDate(1);
        }
        for(int i = 0;i <= notes.NotesList.Count -1; i++)
        {
            Instantiate(notes_object, new Vector3(notes.NotesList[i].x,
                                                 notes.NotesList[i].y,
                                                 notes.NotesList[i].z - 0.5f), Quaternion.identity);
        }
    }
}
