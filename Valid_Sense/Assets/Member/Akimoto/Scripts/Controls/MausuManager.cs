using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausuManager : MonoBehaviour
{
    void Update()
    {
        if (Input.mouseScrollDelta.y == 1)
            Mousu.Instance.MousuWheelUp();
        if (Input.mouseScrollDelta.y == -1)
            Mousu.Instance.MousuWheelDown();
    }
}
