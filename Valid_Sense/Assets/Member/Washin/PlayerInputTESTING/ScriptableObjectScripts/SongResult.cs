using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="NewSongResult",menuName = "WashinScriptableObjects/SongResult")]
public class SongResult : ScriptableObject
{

    [Space]
    public bool won;
    public SongInfo playedSong;
    public int difficulty;

    [Space]
    public int maxComboCount;
    public int brillant;
    public int great;
    public int good;
    public int poor;
    public int miss;
}
