using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstanceManager : MonoBehaviour
{
    private Notes notes = new Notes();
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {

            // 通常ノーツの作成
            NotesInstanceScriput.Instance.NotesPut();
            //HoldNotesInstanceScriput.Instance.HoldNotesSet();
        }
    }
}
