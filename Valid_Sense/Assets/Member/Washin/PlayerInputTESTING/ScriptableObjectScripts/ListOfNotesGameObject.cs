using System.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewListOfNoteGameObjects", menuName = "WashinScriptableObjects/ListOfNoteGameObjects")]
public class ListOfNoteGameObjects : ScriptableObject
{
    [Space]
    public List<GameObject> notesGO = new List<GameObject>();

    public GameObject ReturnNextNoteInList(int noteNumber)
    {
        return notesGO[noteNumber];
    }
    //public GameObject ReturnNextNoteInList()
    //{
    //    Debug.Log(notesGO.First().name);
    //    return notesGO.First();
    //}
}