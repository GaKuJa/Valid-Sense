using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewSongInfo",menuName = "WashinScriptableObjects/SongInfo")]
public class SongInfo : ScriptableObject
{
    [Space]
    public string songName;
    public string artistName;
    public int bpm;
    public string chartDesigner;
    public string jacketArt;

    [Space]
    public int songNumberInList;
    public int easy;
    public int medium;
    public int hard;
}