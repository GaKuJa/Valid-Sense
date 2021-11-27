using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraWheelManager : MonoBehaviour
{
    void Update()
    {
        if (Input.mouseScrollDelta.y == 1)
            CameraWheelControl.Instance.MouseWheelUp();
        if (Input.mouseScrollDelta.y == -1)
            CameraWheelControl.Instance.MouseWheelDown();
    }
}
