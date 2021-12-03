using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManagerWashin : MonoBehaviour
{
    [SerializeField] PlayerInfo player1;
    [SerializeField] PlayerInfo player2;

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
