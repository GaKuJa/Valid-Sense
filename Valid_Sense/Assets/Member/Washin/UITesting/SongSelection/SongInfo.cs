using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewTrackInfo",menuName ="ScriptableObjects/TrackInfo")]
public class SongInfo : ScriptableObject
{
    public string songName;
    public string artistName;
    public int bpm;
    public string chartDesigner;
    public string jacketArt;
    public int songNumberInList;
}
