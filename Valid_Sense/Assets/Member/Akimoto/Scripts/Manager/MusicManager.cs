using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private bool startflag = false;
    void Update()
    {
        StartCoroutine(StartOfMusic());
    }
    IEnumerator StartOfMusic()
    {
        yield return new WaitForSeconds(3.0f);
        if (!startflag)
        {
            MusicPlayer.instance.Music_Play(0);
            startflag = true;
        }
    }
}
