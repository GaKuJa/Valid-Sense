using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MousuControl : MonoBehaviour 
{
    public enum MousuCamera_Mode
    {
        Change_Position_y,
        Change_Position_z,
    }
    public MousuCamera_Mode mousuCamera_Mode;
    public static MousuControl Instance { get => _instance; }
    static MousuControl _instance;
    [SerializeField]
    private float camera_speed = 1.0f;
    void Awake()
    {
        _instance = this;
    }
    public void MousuWheelUp_y()
    {
        Camera.main.transform.Translate(0.0f, camera_speed, 0.0f);
    }
    public void MousuWheelDown_y()
    {
        Camera.main.transform.Translate(0.0f, -camera_speed, 0.0f);
    }
    public void MousuWheelUp_z()
    {
        Camera.main.transform.Translate(0.0f, 0.0f, camera_speed);
    }
    public void MousuWheelDown_z()
    {
        Camera.main.transform.Translate(0.0f, 0.0f, -camera_speed);
    }
}
