using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameScenesManager : MonoBehaviour
{
    public void ChangeNotesPositionScene()
    {
        SceneManager.LoadScene("SetNotesPosition_Scene");
    }
    public void ChangeNotesTimingScene()
    {
        SceneManager.LoadScene("SetNotesTiming_Scene");
    }
    public void ChangeGameSampleScenen()
    {
        SceneManager.LoadScene("GameSampleScene");
    }
}
