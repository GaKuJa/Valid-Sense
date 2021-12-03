using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerWashin : MonoBehaviour
{

    [SerializeField] NoteCalculationManager calculateNote;
    [SerializeField] PlayerInfo player1;
    [SerializeField] PlayerInfo player2;

    [SerializeField] KeyCode p1Lane0KeyCode;
    [SerializeField] KeyCode p1Lane1KeyCode;
    [SerializeField] KeyCode p1Lane2KeyCode;
    [SerializeField] KeyCode p1Lane3KeyCode;
    [SerializeField] KeyCode p2Lane0KeyCode;
    [SerializeField] KeyCode p2Lane1KeyCode;
    [SerializeField] KeyCode p2Lane2KeyCode;
    [SerializeField] KeyCode p2Lane3KeyCode;



    private void Update()
    {
        if (Input.GetKeyDown(p1Lane0KeyCode) && calculateNote.player1.currentLane0Note < calculateNote.player1.lane0.Count)
        {
            if(calculateNote.CalculateIfNoteIsValid(calculateNote.player1.lane0,calculateNote.player1.laneTiming0,calculateNote.player1.currentLane0Note,calculateNote.player1))
                calculateNote.player1.currentLane0Note++;
        }
        if (Input.GetKeyDown(p1Lane1KeyCode) && calculateNote.player1.currentLane1Note < calculateNote.player1.lane1.Count)
        {
            if (calculateNote.CalculateIfNoteIsValid(calculateNote.player1.lane1, calculateNote.player1.laneTiming1, calculateNote.player1.currentLane1Note, calculateNote.player1))
                calculateNote.player1.currentLane1Note++;
        }
        if (Input.GetKeyDown(p1Lane2KeyCode) && calculateNote.player1.currentLane1Note < calculateNote.player1.lane1.Count)
        {
            if (calculateNote.CalculateIfNoteIsValid(calculateNote.player1.lane2, calculateNote.player1.laneTiming2, calculateNote.player1.currentLane2Note, calculateNote.player1))
                calculateNote.player1.currentLane2Note++;
        }
        if (Input.GetKeyDown(p1Lane3KeyCode) && calculateNote.player1.currentLane1Note < calculateNote.player1.lane1.Count)
        {
            if (calculateNote.CalculateIfNoteIsValid(calculateNote.player1.lane3, calculateNote.player1.laneTiming3, calculateNote.player1.currentLane3Note, calculateNote.player1))
                calculateNote.player1.currentLane3Note++;
        }
    }

    private void Start()
    {
        Debug.Log(player1.leftMostLane.hitTime);
        //CheckWhichCharacterIsSelected();
    }

    
    private void CheckWhichCharacterIsSelected()
    {
        switch (player1.selectedCharacter)
        {
            case Characters.sight:
                //GetComponent<MeshRenderer>().material.color = Color.magenta;
                break;
            case Characters.tactile:
                //GetComponent<MeshRenderer>().material.color = Color.green;
                break;
            case Characters.tasteAndSmell:
                //GetComponent<MeshRenderer>().material.color = Color.red;
                break;
            case Characters.hear:
                //GetComponent<MeshRenderer>().material.color = Color.yellow;
                break;
            default:
                Debug.LogError("Error");
                break;
        }
    }
}

//public class NotePlayerInputManager : MonoBehaviour
//{
//    [SerializeField] Player currentPlayer;
//    [SerializeField] KeyCode leftMostLaneKey;
//    [SerializeField] KeyCode leftMiddleLaneKey;
//    [SerializeField] KeyCode rightMiddleLaneKey;
//    [SerializeField] KeyCode rightMostLaneKey;

//    void Update()
//    {
//        if (Input.GetKeyDown(leftMostLaneKey))
//        {
//            NoteEventsList.instance.LeftMostLaneButtonDown();
//        }
//    }

//    NotesLaneTypeScript.LaneType ConvertKeyToLane(KeyCode keyPressed)
//    {
//        if (keyPressed == leftMostLaneKey)
//        {
//            return NotesLaneTypeScript.LaneType.firstLane;
//        }
//        else if (keyPressed == leftMiddleLaneKey)
//        {
//            return NotesLaneTypeScript.LaneType.secondLane;
//        }
//        else if (keyPressed == rightMiddleLaneKey)
//        {
//            return NotesLaneTypeScript.LaneType.thirdLane;
//        }
//        else if (keyPressed == rightMostLaneKey)
//        {
//            return NotesLaneTypeScript.LaneType.fourthLane;
//        }
//        Debug.LogError("not a Valid Key");
//        return NotesLaneTypeScript.LaneType.ollLane;
//    }
//}
