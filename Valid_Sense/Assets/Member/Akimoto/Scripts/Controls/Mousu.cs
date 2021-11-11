using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mousu : MonoBehaviour
{
    public static Mousu Instance { get => _instance; }
    static Mousu _instance;
    [SerializeField]
    private float camera_speed = 1.0f;
    void Awake()
    {
        _instance = this;
    }
    public void MousuWheelUp()
    {
        Camera.main.transform.Translate(0.0f, camera_speed, 0.0f);
    }
    public void MousuWheelDown()
    {
        Camera.main.transform.Translate(0.0f, -camera_speed, 0.0f);
    }
}
