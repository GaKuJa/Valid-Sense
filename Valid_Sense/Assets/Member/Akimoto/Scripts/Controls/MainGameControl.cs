using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGameControl : MonoBehaviour
{
    [SerializeField]
    private GameObject notesParentObject;
    private bool parentFlag = false;
    void Update()
    {
        StartCoroutine(StartMoveNotes());
    }
    IEnumerator StartMoveNotes()
    {
        yield return new WaitForSeconds(3.0f);
        if(!parentFlag)
        {
            notesParentObject.SetActive(true);
            parentFlag = true;
        }
    }
}
