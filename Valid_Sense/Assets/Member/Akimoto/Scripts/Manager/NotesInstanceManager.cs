using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstanceManager : MonoBehaviour
{
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            // 通常ノーツの作成
            //NotesInstanceScriput.Instance.NotesPut();
            HoldNotesInstanceScriput.Instance.HoldNotesSet();
        }
       if(Input.GetMouseButton(0))
        {
            HoldNotesInstanceScriput.Instance.NotesExtend();
        }
    }
}
