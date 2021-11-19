using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialPlayer : MonoBehaviour

{
    public long Timer;
    public Text Timing;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
       {
            MusicPlayer.instance.Music_Play(0);
        } 
        if(Input.GetKeyDown(KeyCode.D))
        {
            MusicPlayer.instance.SE_Tap(0);
        }
        if(Input.GetKeyDown(KeyCode.F))
        {
            MusicPlayer.instance.SE_Tap(1);
        }
        Timer = MusicData.Timer;
        Timing.text = Timer + "ms";
    }
}
