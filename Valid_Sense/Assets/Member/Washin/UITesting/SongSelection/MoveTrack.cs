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
    [SerializeField] Transform top, middle, bottom;
    [SerializeField] TrackPosition currentPosition;
    bool isMoving = false;

    private void Update()
    {
        if (!isMoving && Input.GetKeyDown(KeyCode.UpArrow))
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
        else if (!isMoving && Input.GetKeyDown(KeyCode.DownArrow))
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
    }

    void SetPosition(Transform nextPosition)
    {
        transform.position = nextPosition.position;
        transform.rotation = nextPosition.rotation;
    }
}
