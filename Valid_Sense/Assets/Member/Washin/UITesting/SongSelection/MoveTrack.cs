using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum TrackPosition
{
    Top,
    Middle,
    Bottom
}

public class MoveTrack : MonoBehaviour
{
    public static bool shouldPulse;
    [SerializeField] Transform top, middle, bottom;
    [SerializeField] TrackPosition currentPosition;
    [SerializeField] Vector3 minScaleSize = Vector3.one;
    [SerializeField] Vector3 maxScaleSize = new Vector3(1.1f,1.1f,1.1f);
    [SerializeField] float pulseSpeed = 1f;    
    float currentTime;
    bool isGrowing = true;

    float bpm = 138;

    private void Update()
    {
        if (shouldPulse) PulseTrackIcon();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            TrackManager.instance.StopCurrentSong();
            shouldPulse = false;
            MoveTrackUp();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            TrackManager.instance.StopCurrentSong();
            shouldPulse = false;
            MoveTrackDown();
        }
    }

    private void MoveTrackDown()
    {
        switch (currentPosition)
        {
            case TrackPosition.Top:
                currentPosition = TrackPosition.Middle;
                SetPosition(middle);
                break;
            case TrackPosition.Middle:
                currentPosition = TrackPosition.Bottom;
                SetPosition(bottom);
                break;
            case TrackPosition.Bottom:
                currentPosition = TrackPosition.Top;
                SetPosition(top);
                break;
            default:
                Debug.LogError("SomeThingWentWrong");
                break;
        }
    }

    private void MoveTrackUp()
    {
        switch (currentPosition)
        {
            case TrackPosition.Top:
                currentPosition = TrackPosition.Bottom;
                SetPosition(bottom);
                break;
            case TrackPosition.Middle:
                currentPosition = TrackPosition.Top;
                SetPosition(top);
                break;
            case TrackPosition.Bottom:
                currentPosition = TrackPosition.Middle;
                SetPosition(middle);
                break;
            default:
                Debug.LogError("SomeThingWentWrong");
                break;
        }
    }

    void SetPosition(Transform nextPosition)
    {
        transform.position = nextPosition.position;
        transform.rotation = nextPosition.rotation;
    }

    public void PulseTrackIcon()
    {
        if (currentPosition != TrackPosition.Middle) return;
        if(isGrowing)
            ChangeScale(minScaleSize, maxScaleSize);
        else ChangeScale(maxScaleSize, minScaleSize);
    }

    void ChangeScale(Vector3 startingScale, Vector3 endingScale)
    {
        transform.localScale = Vector3.Lerp(startingScale, endingScale, currentTime);
        currentTime += Time.deltaTime / (pulseSpeed/bpm);
        if (transform.localScale == endingScale)
        {
            isGrowing = !isGrowing;
            currentTime = 0;
        }
    }
}
