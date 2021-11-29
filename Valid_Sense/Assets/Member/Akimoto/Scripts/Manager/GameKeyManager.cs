using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeyManager : MonoBehaviour
{
    private int count = 0;
    private bool fristCameraFlag = false;
    // ノーツが持っているデータ数の限界flag
    private bool limitCountFlag = false;
    LoadTimingScript load_Time = new LoadTimingScript();
    Notes notes;
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            notes = load_Time.LoadNotesDate(1);
        }
    }
    void Update()
    {
        Change_pos();
        if (notes.TimeList.Count-1 <= count)
            limitCountFlag = true;
    }
    private void Change_pos()
    {
        // Notesの座標移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 0);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(0, count);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 1);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(1, count);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 2);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(2, count);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 3);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(3, count);
        }
        // Notesの削除
        if (Input.GetKeyDown(KeyCode.Delete))
            DeletScript.Instance.NotesDelet(0);
        // カメラ関係
        if (Input.GetKeyDown(KeyCode.Q))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_y;
        if (Input.GetKeyDown(KeyCode.W))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_z;
        // カメラを最初のNotesに移動
        if(!fristCameraFlag)
        {
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
            fristCameraFlag = true;
        }
        // Notesの座標を次のNotesに
        if (Input.GetKeyDown(KeyCode.Return) && !limitCountFlag)
        {
            count++;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }
        // Notesの座標を前のNotesに
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            count--;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }

    }
}
