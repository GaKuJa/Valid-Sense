using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class NoteCalculationManager : MonoBehaviour
{
    [SerializeField] GameObject noteHolder;
    [SerializeField] StartNotesPositionScript noteSpawnerP1;
    [SerializeField] StartNotesPositionScript noteSpawnerP2;
    List<GameObject> p1FullNoteList = new List<GameObject>();
    List<GameObject> p2FullNoteList = new List<GameObject>();

    public List<GameObject> p1Lane0 = new List<GameObject>();
    public List<GameObject> p1Lane1 = new List<GameObject>();
    public List<GameObject> p1Lane2 = new List<GameObject>();
    public List<GameObject> p1Lane3 = new List<GameObject>(); 
    public List<GameObject> p1LaneAll = new List<GameObject>(); 
    
    public List<GameObject> p2Lane0 = new List<GameObject>();
    public List<GameObject> p2Lane1 = new List<GameObject>();
    public List<GameObject> p2Lane2 = new List<GameObject>();
    public List<GameObject> p2Lane3 = new List<GameObject>();
    public List<GameObject> p2LaneAll = new List<GameObject>();


    private void Start()
    {
        SetActiveNoteHolder(false);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SeparateNotesByLanes(noteSpawnerP1.GetListOfNotes(), p1Lane0, p1Lane1, p1Lane2, p1Lane3, p1LaneAll);
            SeparateNotesByLanes(noteSpawnerP2.GetListOfNotes(), p2Lane0, p2Lane1, p2Lane2, p2Lane3, p2LaneAll);
        }

        if(Input.GetKeyDown(KeyCode.D))
        {
            foreach (var note in p1Lane2)
            {
                note.GetComponent<MeshRenderer>().material.color = Random.ColorHSV();
            }
        }
    }

    void SeparateNotesByLanes(List<GameObject> listOfNotes, List<GameObject> lane0, List<GameObject> lane1, List<GameObject> lane2, List<GameObject> lane3, List<GameObject> laneAll )
    {
        foreach (var note in listOfNotes)
        {
            NotesLaneTypeScript.LaneType laneNumber = note.GetComponent<NotesLaneTypeScript>().laneType;
            switch (laneNumber)
            {
                case NotesLaneTypeScript.LaneType.firstLane:
                    lane0.Add(note);
                    break;
                case NotesLaneTypeScript.LaneType.secondLane:
                    lane1.Add(note);
                    break;
                case NotesLaneTypeScript.LaneType.thirdLane:
                    lane2.Add(note);
                    break;
                case NotesLaneTypeScript.LaneType.fourthLane:
                    lane3.Add(note);
                    break;
                case NotesLaneTypeScript.LaneType.ollLane:
                    laneAll.Add(note);
                    break;
                default:
                    Debug.LogError("Wrong Lane Type");
                    break;
            }
        }
    }

    void SetActiveNoteHolder( bool setActive )
    {
        noteHolder.SetActive(setActive);
    }


    public void CalculateIfNoteIsValid(NotesLaneTypeScript.LaneType laneButton)
    {
        switch (laneButton)
        {
            case NotesLaneTypeScript.LaneType.firstLane:
                p1Lane0.First();
                break;
            case NotesLaneTypeScript.LaneType.secondLane:
                break;
            case NotesLaneTypeScript.LaneType.thirdLane:
                break;
            case NotesLaneTypeScript.LaneType.fourthLane:
                break;
            case NotesLaneTypeScript.LaneType.ollLane:
                break;
            default:
                break;
        }
    }
}
