using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewLaneInfo", menuName = "WashinScriptableObjects/LaneInfo")]
public class LaneInfo : ScriptableObject
{
    [Space]
    public NotesLaneTypeScript.LaneType currentLane;
    //public ListOfNoteGameObjects listOfNotes;
    public List<GameObject> listOfNotes = new List<GameObject>();
    public List<float> noteTimings = new List<float>();
    public int hitTime = 11111;

    public void DiscardData()
    {
        listOfNotes = new List<GameObject>();
        noteTimings = new List<float>();
    }

    private void OnDisable()
    {
        DiscardData();
    }
}
