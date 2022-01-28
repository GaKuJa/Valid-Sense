using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewPlayerInfo", menuName = "WashinScriptableObjects/PlayerInfo")]
public class PlayerInfo : ScriptableObject
{
    [Space]
    public Player currentPlayer;
    public Characters selectedCharacter;
    public Color characterColor { get => SetCharacterColor(); set => SetCharacterColor(); }

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
    public LaneInfo allLane;

    Color SetCharacterColor()
    {
        switch (selectedCharacter)
        {
            case Characters.sight:
                return Color.magenta;
            case Characters.tactile:
                return Color.green;
            case Characters.tasteAndSmell:
                return Color.red;
            case Characters.hear:
                return Color.yellow;
            default:
                return Color.black;
        }
    }
}

public enum Characters
{
    sight,
    tactile,
    tasteAndSmell,
    hear
}

