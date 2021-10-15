using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesModeControl : MonoBehaviour
{
    // 設置時のノーツモード
    enum Notes_mode
    {
        Normal,
        Hold_Start,
        Hold_End,
        Flick,
    }
    void Update()
    {
        Notes_mode notes_mode = Notes_mode.Normal;
        if (Input.GetKeyDown(KeyCode.Alpha1))
            notes_mode = Notes_mode.Hold_Start;
        if (Input.GetKeyDown(KeyCode.Alpha2))
            notes_mode = Notes_mode.Hold_Start;
        if (Input.GetKeyDown(KeyCode.Alpha3))
            notes_mode = Notes_mode.Flick;
        switch(notes_mode)
        {
            case Notes_mode.Normal:
                notes_mode = Notes_mode.Hold_Start;
                break;
            case Notes_mode.Hold_Start:
                notes_mode = Notes_mode.Flick;
                break;
            case Notes_mode.Hold_End:
                notes_mode = Notes_mode.Flick;
                break;
            case Notes_mode.Flick:
                break;
            default:
                Debug.Log("エラー");
                break;
        }
    }
}
