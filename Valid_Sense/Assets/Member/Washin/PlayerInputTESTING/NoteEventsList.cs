using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoteEventsList : MonoBehaviour
{

    public static NoteEventsList instance;

    public event Action OnLeftMostLaneButtonDown;

    public void LeftMostLaneButtonDown()
    {
        if(OnLeftMostLaneButtonDown != null)
        {
            OnLeftMostLaneButtonDown.Invoke();
        }
    }

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    private void Update()
    {
        
    }
}
