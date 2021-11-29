using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerInfo",menuName = "ScriptableObjects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    public Player currentPlayer;
    public Characters selectedCharacter;

    public LaneInfo leftMostLane;
    public LaneInfo leftMiddleLane;
    public LaneInfo rightMiddleLane;
    public LaneInfo rightMostLane;
}

public enum Characters
{
    sight,
    tactile,
    tasteAndSmell,
    hear
}

