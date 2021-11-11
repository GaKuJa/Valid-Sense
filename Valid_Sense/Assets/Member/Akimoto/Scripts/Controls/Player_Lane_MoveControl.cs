using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Lane_MoveControl : MonoBehaviour
{
    [SerializeField]
    private float move_Speed = 1.0f;
    [SerializeField]
    private bool move_Flag = false;
    void Start()
    {
        move_Flag = true;
    }
    private void FixedUpdate()
    {
        if (move_Flag)
            LaneMove();
    }
    private void LaneMove()
    {
        this.transform.Translate(0.0f, -move_Speed, 0, 0f);
    }
}
