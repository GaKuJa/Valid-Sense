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
    public void ChangeCameraPos(int notesPos)
    {
        Camera.main.transform.position = new Vector3(Camera.main.transform.position.x,
                                                     Camera.main.transform.position.y,
                                                     StartNotesTimingScript.Instance.notesObj_list[notesPos].transform.position.z);
    }
}
