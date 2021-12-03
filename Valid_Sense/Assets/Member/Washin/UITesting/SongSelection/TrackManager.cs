using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrackManager : MonoBehaviour
{
    public static TrackManager instance;
    //CriAtomExAcb exAcb;
    //MusicPlayer musicPlayer;

    [SerializeField] float waitTimeForSongPreview;
    bool isPlaying = false;
    //bool hasWaitedForTime = false;
    float currentTime;
    int currentTrack = 100;

    int bpm;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else Destroy(this.gameObject);
    }

    private void Start()
    {
        this.gameObject.AddComponent<MusicPlayer>();
    }

    private void Update()
    {
        if (!isPlaying && HasWaitedLongEnough())
        {
            GetTrackInfo();
            currentTime = 0;
            Debug.Log(currentTime);

            isPlaying = true;
            MusicPlayer.instance.Music_Play(currentTrack);
            Debug.Log("Playing Song");
            MoveTrack.shouldPulse = true;
        }
    }

    bool HasWaitedLongEnough()
    {
        if (currentTime >= waitTimeForSongPreview)
        {
            return true;
        }

        currentTime += Time.deltaTime;
        Debug.Log(currentTime);
        return false;
    }

    public void StopCurrentSong()
    {
        if (currentTrack != 100)
        {
            MusicPlayer.instance.StopCurrentSong();
            Debug.Log("Stopped Track " + currentTrack);

            isPlaying = false;
        }
        else Debug.Log("No Song Is Playing");
    }

    void GetTrackInfo()
    {
        currentTrack = 0;
        //bpm = 138;
    }


}
