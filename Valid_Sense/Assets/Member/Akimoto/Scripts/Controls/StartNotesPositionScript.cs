using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesPositionScript : MonoBehaviour
{
    [SerializeField]
    private GameObject notes_object;
    [SerializeField]
    private GameObject holdNotes_object;
    [SerializeField]
    private GameObject[] laneArr = new GameObject[4];
    // Notes‚Ìy²‚ğ“ü‚ê‚éˆ×‚Ì•Ï”
    private Vector3 notes_obj_y;
    private int hold_count = 0;
    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;
    void Start()
    {
        if(load_Pos.LoadNotesDate(1) != null)
        {
            notes = load_Pos.LoadNotesDate(1);
            Debug.Log("pos_date:"+notes.NotesTypeList.Count);
        }
        for(int i = 0;i <= notes.NotesTypeList.Count -1; i++)
        {
            notes_obj_y.y = notes.TimeList[i] * 50.0f;
            if (notes.NotesTypeList[i] == 1)
            {
                Instantiate(notes_object, new Vector3(laneArr[notes.LaneNumList[i]].transform.position.x,
                                                      notes_obj_y.y,
                                                      laneArr[notes.LaneNumList[i]].transform.position.z - 0.1f), Quaternion.identity);
            }
            if(notes.NotesTypeList[i] == 2)
            {
                GameObject new_HoldNotes = Instantiate(holdNotes_object, new Vector3(laneArr[notes.LaneNumList[i]].transform.position.x,
                                                                                     notes_obj_y.y,
                                                                                     laneArr[notes.LaneNumList[i]].transform.position.z - 0.1f), Quaternion.identity);
                Vector3 plusScale_y = new_HoldNotes.transform.localScale;
                plusScale_y.y += notes.HoldTimeList[hold_count] * 50 / 2;
                new_HoldNotes.transform.localScale = plusScale_y;
                new_HoldNotes.transform.position = new Vector3(new_HoldNotes.transform.position.x,
                                                               new_HoldNotes.transform.position.y + plusScale_y.y,
                                                               new_HoldNotes.transform.position.z -0.5f);
                hold_count++;
            }
        }
    }
}
