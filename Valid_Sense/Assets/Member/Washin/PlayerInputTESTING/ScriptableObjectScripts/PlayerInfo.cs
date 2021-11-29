using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewPlayerInfo",menuName = "WashinScriptableObjects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    [Space]
    public Player currentPlayer;
    public Characters selectedCharacter;

    [Space]
    public SongResult firstSong;
    public SongResult secondSong;
    public SongResult thirdSong;
    
    [Space]
    public SongInfo selectedSong;
    public int selectedDifficulty;

    [Space]
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

