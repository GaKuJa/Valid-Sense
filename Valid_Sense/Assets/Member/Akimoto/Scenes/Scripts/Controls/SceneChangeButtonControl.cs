using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeButtonControl : MonoBehaviour
{
    SaveButtonScript saveButton = new SaveButtonScript();
    public int selection_num;
    public void SelectionScenen()
    {
        SaveButtonScript.saveNum = selection_num;
        StartNotesTimingScript.selectiondate_num = selection_num;
        StartNotesPositionScript.selectiondate_num = selection_num;
        SceneManager.LoadScene("SetNotesTiming_Scene");
    }
}