using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesColorControl : MonoBehaviour
{
    [SerializeField]
    private Material[] materialArr = new Material[4];
    [SerializeField]
    private GameObject player1, player2;
    public static int playerNum = 1;
    private StartNotesPositionScript player1Notes, player2Notes;
    void Start()
    {
    }
    private void Player1NotesChangeMaterial()
    {
        player1Notes = player1.GetComponent<StartNotesPositionScript>();
        foreach (GameObject note in player1Notes.notesObjList)
        {
            note.GetComponent<MeshRenderer>().material = materialArr[1];
        }
    }
    private void Player2NotesChangeMaterial()
    {
        player2Notes = player2.GetComponent<StartNotesPositionScript>();
        foreach (GameObject note in player2Notes.notesObjList)
        {
            note.GetComponent<MeshRenderer>().material = materialArr[1];
        }
    }
}