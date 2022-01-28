using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempSTARTSONG : MonoBehaviour
{
    public float tempTime;
    private bool isPlaying = false;

    private void Update()
    {
        if (isPlaying) { ReturnTimer(); return; }

        //PressSpaceToStart();
        if (Input.GetKeyDown(KeyCode.A))
            MusicPlayer.instance.Music_Play(0);
    }

    private void ReturnTimer() => tempTime = MusicData.Timer;

    void PressSpaceToStart()
    {
        if (!isPlaying && Input.GetKeyDown(KeyCode.Space))
        {
            isPlaying = true;
            MusicPlayer.instance.Music_Play(0);
        }
    }
}

