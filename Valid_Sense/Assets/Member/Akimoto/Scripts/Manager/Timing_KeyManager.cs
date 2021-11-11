using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timing_KeyManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SaveTimingScriput.Instance.SetNotesTiming();
    }
}
