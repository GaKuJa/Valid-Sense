using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimingMusicManager : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
            MusicPlayer.instance.Music_Play(0);
    }
}
