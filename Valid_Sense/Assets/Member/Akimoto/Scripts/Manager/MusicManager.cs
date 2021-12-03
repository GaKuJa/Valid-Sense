using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private bool startflag = false;
    void Start()
    {
        
    }
    void Update()
    {
        if(!startflag)
        {
            MusicPlayer.instance.Music_Play(0);
            startflag = true;
        }
    }
}
