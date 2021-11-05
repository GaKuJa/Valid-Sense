using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWheelControl : MonoBehaviour
{
    public static CameraWheelControl Instance { get => _instance; }
    static CameraWheelControl _instance;
    [SerializeField]
    private float speed = 1.0f;
    void Awake()
    {
        _instance = this;
    }
    public void MouseWheelUp()
    {
        Camera.main.transform.Translate(0.0f, 1, 1);
    }
    public void MouseWheelDown()
    {
        Camera.main.transform.Translate(0.0f, -1, -1);
    }
}
