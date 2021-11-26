using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoteEditControl : MonoBehaviour
{
    public long Timer;
    public Text Timing;
    // Start is called before the first frame update
    private bool Started;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Timer = MusicData.Timer;
        Timing.text = Timer + "ms";
        if(!Started)
        {
            MusicPlayer.instance.Music_Play(0);
            Started = true;
        }
    }
    void Music_Start()
    {
        MusicPlayer.instance.Music_Play(0);
    }
}
