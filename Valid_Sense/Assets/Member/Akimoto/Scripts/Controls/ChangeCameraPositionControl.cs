using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeCameraPositionControl : MonoBehaviour
{
    public static ChangeCameraPositionControl Instance { get => _instance; }
    static ChangeCameraPositionControl _instance;
    void Awake()
    {
        _instance = this;
    }
    public void ChangeCameraPos(int notes_pos)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
                                                     StartNotesTimingScript.Instance.notesObj_list[notes_pos].transform.position.y,
                                                     Camera.main.transform.position.z);
    }
}
