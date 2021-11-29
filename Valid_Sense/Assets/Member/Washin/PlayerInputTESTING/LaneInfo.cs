using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLaneInfo", menuName = "ScriptableObjects/LaneInfo")]
public class LaneInfo : ScriptableObject
{
    public NotesLaneTypeScript.LaneType currentLane;
    public int hitTime = 11111;
}
