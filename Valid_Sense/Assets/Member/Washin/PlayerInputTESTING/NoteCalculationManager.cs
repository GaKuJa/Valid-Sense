using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class NoteCalculationManager : MonoBehaviour
{
    [SerializeField] GameObject noteHolder;
    [SerializeField] StartNotesPositionScript noteSpawnerP1;
    [SerializeField] StartNotesPositionScript noteSpawnerP2;
    [SerializeField] HitAccuracyCalculator hitAccuracy;
    [SerializeField] PlayerInfo playerInfo1;
    [SerializeField] PlayerInfo playerInfo2;

    public float tempTimeFromCRI;

    List<GameObject> p1FullNoteList = new List<GameObject>();
    List<GameObject> p2FullNoteList = new List<GameObject>();
    bool hasLoadedNotes = false;

    public PlayerLanesAndTimings player1 = new PlayerLanesAndTimings();
    public PlayerLanesAndTimings player2 = new PlayerLanesAndTimings();


    ////////////////////////////////////////////////////////////////////////////////////////
    public static NoteCalculationManager instance;
    public float GETTEMPTIME()
    {
        return MusicData.Timer / 1000f;
    }
    private void Awake()
    {
        if (instance == null)
            instance = this;
    }
    ////////////////////////////////////////////////////////////////////////////////////////

    //private void Start()
    //{
    //    SetActiveNoteHolder(false);
    //}

    private void FixedUpdate()
    {
        if (!hasLoadedNotes)
        {
            //MusicPlayer.instance.Music_Play(0);
            GETNOTEINFOS();
            hasLoadedNotes = true;
        }
        tempTimeFromCRI = GETTEMPTIME();
    }

    public void GETNOTEINFOS()
    {
        SeparateNotesByLanes(ConvertGameObjectsToDisableNotes(noteSpawnerP1.GetListOfNotes(), playerInfo1.characterColor, playerInfo2.characterColor), noteSpawnerP1.GetNotes().TimeList, player1);
        hasLoadedNotes = true;
        SetActiveNoteHolder(true);
    }

    private void Update()
    {
        if (hasLoadedNotes)
        {
            if (player1.currentLane0Note < player1.lane0.Count && player1.laneTiming0[player1.currentLane0Note] < GETTEMPTIME())
            {
                player1.lane0[player1.currentLane0Note].SwitchColors();
                //player1.lane0[player1.currentLane0Note].HideNote();
                player1.misses++;
                player1.currentLane0Note++;
            }
            if (player1.currentLane1Note < player1.lane1.Count && player1.laneTiming1[player1.currentLane1Note] < GETTEMPTIME())
            {
                player1.lane1[player1.currentLane1Note].SwitchColors();
                //player1.lane1[player1.currentLane1Note].HideNote();
                player1.misses++;
                player1.currentLane1Note++;
            }
            if (player1.currentLane2Note < player1.lane2.Count && player1.laneTiming2[player1.currentLane2Note] < GETTEMPTIME())
            {
                player1.lane2[player1.currentLane2Note].SwitchColors();
                //player1.lane2[player1.currentLane2Note].HideNote();
                player1.misses++;
                player1.currentLane2Note++;
            }
            if (player1.currentLane3Note < player1.lane3.Count && player1.laneTiming3[player1.currentLane3Note] < GETTEMPTIME())
            {
                player1.lane3[player1.currentLane3Note].SwitchColors();
                //player1.lane3[player1.currentLane3Note].HideNote();
                player1.misses++;
                player1.currentLane3Note++;
            }
        }
        //if (!hasLoadedNotes && Input.GetKeyDown(KeyCode.Space))
        //{
        //    SeparateNotesByLanes(ConvertGameObjectsToDisableNotes(noteSpawnerP1.GetListOfNotes(), playerInfo1.characterColor, playerInfo2.characterColor), noteSpawnerP1.GetNotes().TimeList, player1);
        //    //SeparateNotesByLanes(noteSpawnerP2.GetListOfNotes(), noteSpawnerP2.GetNotes().TimeList, player2);
        //    hasLoadedNotes = true;
        //    SetActiveNoteHolder(true);
        //}

        //DEBUG SWITCH COLOR
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            FlipColors(player1.lane0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            FlipColors(player1.lane1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            FlipColors(player1.lane2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            FlipColors(player1.lane3);
        }
    }

    private void FlipColors(List<DisableNote> listOfNotes)
    {
        foreach (var note in listOfNotes)
        {
            note.SwitchColors();
        }
    }

    List<DisableNote> ConvertGameObjectsToDisableNotes(List<GameObject> listOfGameObjects, Color characterColor, Color opponentColor)
    {
        List<DisableNote> listOfDisableNoteScripts = new List<DisableNote>();
        foreach (var gameObject in listOfGameObjects)
        {
            DisableNote temp = gameObject.AddComponent<DisableNote>();
            listOfDisableNoteScripts.Add(temp);
            temp.SetNoteColors(characterColor, opponentColor);
        }
        return listOfDisableNoteScripts;
    }

    void SeparateNotesByLanes(List<DisableNote> listOfNotes, List<float> listOfNoteTimings, PlayerLanesAndTimings playerInfo)
    {
        for (int i = 0; i < listOfNotes.Count; i++)
        {
            NotesLaneTypeScript.LaneType laneNumber = listOfNotes[i].gameObject.GetComponent<NotesLaneTypeScript>().laneType;
            switch (laneNumber)
            {
                case NotesLaneTypeScript.LaneType.firstLane:
                    playerInfo.lane0.Add(listOfNotes[i]);
                    playerInfo.laneTiming0.Add(listOfNoteTimings[i]);
                    break;
                case NotesLaneTypeScript.LaneType.secondLane:
                    playerInfo.lane1.Add(listOfNotes[i]);
                    playerInfo.laneTiming1.Add(listOfNoteTimings[i]);
                    break;
                case NotesLaneTypeScript.LaneType.thirdLane:
                    playerInfo.lane2.Add(listOfNotes[i]);
                    playerInfo.laneTiming2.Add(listOfNoteTimings[i]);
                    break;
                case NotesLaneTypeScript.LaneType.fourthLane:
                    playerInfo.lane3.Add(listOfNotes[i]);
                    playerInfo.laneTiming3.Add(listOfNoteTimings[i]);
                    break;
                case NotesLaneTypeScript.LaneType.allLane:
                    playerInfo.laneAll.Add(listOfNotes[i]);
                    playerInfo.laneTimingAll.Add(listOfNoteTimings[i]);
                    break;
                default:
                    Debug.LogError("Wrong Lane Type");
                    break;
            }
        }
    }

    void SetActiveNoteHolder(bool setActive)
    {
        noteHolder.SetActive(setActive);
    }

    public bool CalculateIfNoteIsValid(List<DisableNote> listOfDisableScripts, List<float> listOfTimings, int currentNote, PlayerLanesAndTimings player)
    {
        if (currentNote == listOfDisableScripts.Count)
        {
            Debug.Log("No Notes Remaining " + GETTEMPTIME());
            return false;
        }

        //float hitTime = listOfTimings[currentNote];
        if (GETTEMPTIME() - listOfTimings[currentNote] < -hitAccuracy.poor)
        //&&Mathf.Abs(TEMPCRITIME - listOfTimings[currentNote]) < hitAccuracy.poor)
        {
            Debug.Log("Note Not Close Enough " + GETTEMPTIME() + " VS " + listOfTimings[currentNote] + " : " + Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]));
            return false;
        }
        else if (Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) < hitAccuracy.brilliant)
        {
            Debug.LogWarning("Brilliant " + GETTEMPTIME() + " VS " + listOfTimings[currentNote] + " : " + Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]));
            player.brilliants++;
            listOfDisableScripts[currentNote].HideNote();
            return true;
        }
        else if ((Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) < hitAccuracy.great) &&
                 (Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) > hitAccuracy.brilliant))
        {
            Debug.LogWarning("Great " + GETTEMPTIME() + " VS " + listOfTimings[currentNote] + " : " + Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]));
            player.greats++;
            listOfDisableScripts[currentNote].HideNote();
            return true;
        }
        else if ((Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) < hitAccuracy.good) &&
                 (Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) > hitAccuracy.great))
        {
            Debug.LogWarning("Good " + GETTEMPTIME() + " VS " + listOfTimings[currentNote] + " : " + Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]));
            player.goods++;
            listOfDisableScripts[currentNote].HideNote();
            return true;
        }
        else if ((Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) < hitAccuracy.poor) &&
                 (Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]) > hitAccuracy.good))
        {
            Debug.LogWarning("Poor " + GETTEMPTIME() + " VS " + listOfTimings[currentNote] + " : " + Mathf.Abs(GETTEMPTIME() - listOfTimings[currentNote]));
            player.poors++;
            listOfDisableScripts[currentNote].HideNote();
            return true;
        }
        else
        {
            Debug.Log("Else " + GETTEMPTIME());
            return false;
        }
    }
}
[Serializable]
public class PlayerLanesAndTimings
{
    public int brilliants;
    public int greats;
    public int goods;
    public int poors;
    public int misses;

    public int currentLane0Note;
    public int currentLane1Note;
    public int currentLane2Note;
    public int currentLane3Note;
    public int currentLaneAllNote;

    public List<DisableNote> lane0 = new List<DisableNote>();
    public List<float> laneTiming0 = new List<float>();
    public List<DisableNote> lane1 = new List<DisableNote>();
    public List<float> laneTiming1 = new List<float>();
    public List<DisableNote> lane2 = new List<DisableNote>();
    public List<float> laneTiming2 = new List<float>();
    public List<DisableNote> lane3 = new List<DisableNote>();
    public List<float> laneTiming3 = new List<float>();
    public List<DisableNote> laneAll = new List<DisableNote>();
    public List<float> laneTimingAll = new List<float>();
}
