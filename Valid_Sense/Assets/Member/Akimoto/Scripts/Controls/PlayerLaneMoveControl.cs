using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLaneMoveControl : MonoBehaviour
{
    [SerializeField]
    private float move_Speed = 1.0f;
    [SerializeField]
    private bool moveFlag = false;
    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.P))
            moveFlag = true;
        if (moveFlag)
            LaneMove();
    }
    private void LaneMove()
    {
        this.transform.Translate(0.0f, 0.0f, -move_Speed);
    }
}
