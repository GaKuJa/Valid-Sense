using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLaneInfo", menuName = "WashinScriptableObjects/LaneInfo")]
public class LaneInfo : ScriptableObject
{
    [Space]
    public NotesLaneTypeScript.LaneType currentLane;
    public int hitTime = 11111;
}
