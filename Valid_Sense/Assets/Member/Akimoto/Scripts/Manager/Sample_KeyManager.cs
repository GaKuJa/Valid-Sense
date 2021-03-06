using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample_KeyManager : MonoBehaviour
{
    private int count = 0;
    private bool fristCameraFlag = false;
    LoadTimingScript load_Time = new LoadTimingScript();
    Notes notes;
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            notes = load_Time.LoadNotesDate(1);
        }
        Debug.Log(count);
        //ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
    }
    void Update()
    {
        Change_pos();
    }
    private void Change_pos()
    {
        // Notesの場所関係
        if (Input.GetKeyDown(KeyCode.A))
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 0);
        if (Input.GetKeyDown(KeyCode.S))
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 1);
        if (Input.GetKeyDown(KeyCode.D))
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 2);
        if (Input.GetKeyDown(KeyCode.F))
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 3);
        if (Input.GetKeyDown(KeyCode.Delete))
            DeletScript.Instance.NotesDelet(0);
        // カメラ関係
        if (Input.GetKeyDown(KeyCode.Q))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_y;
        if (Input.GetKeyDown(KeyCode.W))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_z;
        if(!fristCameraFlag)
        {
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
            fristCameraFlag = true;
        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            count++;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }
        if(Input.GetKeyDown(KeyCode.Backspace))
        {
            count--;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }
    }
}
