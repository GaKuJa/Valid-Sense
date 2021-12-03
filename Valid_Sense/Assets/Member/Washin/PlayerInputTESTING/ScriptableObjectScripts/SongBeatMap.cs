using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSongBeatMap", menuName = "WashinScriptableObjects/SongBeatMap")]
public class SongBeatMap : ScriptableObject
{
    public SongDifficulty songDifficulty;

    public List<GameObject> notes;
}

public enum SongDifficulty
{
    Natural,
    HighSense,
    SixthSense
}