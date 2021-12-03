using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MausuManager : MonoBehaviour
{
    void Update()
    {
        switch(Mousu.Instance.mousuCamera_Mode)
        {
            case Mousu.MousuCamera_Mode.Change_Position_y:
                if (Input.mouseScrollDelta.y == 1)
                    Mousu.Instance.MousuWheelUp_y();
                if (Input.mouseScrollDelta.y == -1)
                    Mousu.Instance.MousuWheelDown_y();
                break;
            case Mousu.MousuCamera_Mode.Change_Position_z:
                if (Input.mouseScrollDelta.y == 1)
                    Mousu.Instance.MousuWheelUp_z();
                if (Input.mouseScrollDelta.y == -1)
                    Mousu.Instance.MousuWheelDown_z();
                break;
        }
    }
}
