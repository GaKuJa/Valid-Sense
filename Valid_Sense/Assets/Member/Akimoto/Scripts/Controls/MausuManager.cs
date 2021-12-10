using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausuManager : MonoBehaviour
{
    void Update()
    {
        switch(MousuControl.Instance.mousuCamera_Mode)
        {
            case MousuControl.MousuCamera_Mode.Change_Position_y:
                if (Input.mouseScrollDelta.y == 1)
                    MousuControl.Instance.MousuWheelUp_y();
                if (Input.mouseScrollDelta.y == -1)
                    MousuControl.Instance.MousuWheelDown_y();
                break;
            case MousuControl.MousuCamera_Mode.Change_Position_z:
                if (Input.mouseScrollDelta.y == 1)
                    MousuControl.Instance.MousuWheelUp_z();
                if (Input.mouseScrollDelta.y == -1)
                    MousuControl.Instance.MousuWheelDown_z();
                break;
        }
    }
}
