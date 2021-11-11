using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_KeyManager : MonoBehaviour
{
    private int count = 0;
    LoadTimingScript load_Time = new LoadTimingScript();
    Notes notes;
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            notes = load_Time.LoadNotesDate(1);
        }
        ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
    }
    void Update()
    {
        Change_pos();
    }
    private void Change_pos()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 0);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 1);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 2);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 3);
        }
        if(Input.GetKeyDown(KeyCode.Return))
        {
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
            count++;
        }
    }
}
