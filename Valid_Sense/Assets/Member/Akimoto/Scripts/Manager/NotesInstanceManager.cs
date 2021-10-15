using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesInstanceManager : MonoBehaviour
{
    void Update()
    {
       if(Input.GetMouseButtonDown(0))
        {
            NotesInstanceScriput.Instance.NotesPut();
        }
    }
}
