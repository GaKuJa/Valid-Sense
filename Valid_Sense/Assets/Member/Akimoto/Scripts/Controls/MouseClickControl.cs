using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseClickControl : MonoBehaviour
{
    private Notes _notes = new Notes();
    void Update()
    {
        GetMousePosition();
    }
    private void GetMousePosition()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var pos = Camera.main.WorldToScreenPoint(Input.mousePosition);
            _notes.NotesList.Add(pos);
        }
    }
}
