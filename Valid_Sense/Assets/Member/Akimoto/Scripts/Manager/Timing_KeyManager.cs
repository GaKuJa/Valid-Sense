using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing_KeyManager : MonoBehaviour
{
    void Update()
    {
        // NormalNotes‚ÌSave
        if (Input.GetKeyDown(KeyCode.Space))
        {
            SaveTimingScriput.Instance.SetNotesTiming(1);
            //SaveNotesTypeScript.Instance.SaveNotesType(1);
        }
        // HoldNotes‚ÌSave
        if(Input.GetKeyDown(KeyCode.LeftShift))
        {
            SaveTimingScriput.Instance.StartHold(2);
        }
        if(Input.GetKeyUp(KeyCode.LeftShift))
        {
            SaveTimingScriput.Instance.FinishHold();
            //SaveNotesTypeScript.Instance.SaveNotesType(2);
        }
        // LinkNotes‚Ìsave
        if(Input.GetKeyDown(KeyCode.LeftAlt))
        {
            SaveTimingScriput.Instance.SetNotesTiming(3);
        }
        //
    }
}
