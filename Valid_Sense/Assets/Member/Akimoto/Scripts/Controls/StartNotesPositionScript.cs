using System;
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
      private GameObject linkNotes_object;
    [SerializeField]
    private GameObject[] lane_Arr = new GameObject[4];
    [SerializeField]
    private Transform notes_Holder;
    public List<GameObject> notesObjList = new List<GameObject>();
    // Notes��y��������ׂ̕ϐ�
    private Vector3 notes_obj_z;
    private int hold_count = 0;
    public static int selectionDateNum = 1;
    LoadPositionScript load_Pos = new LoadPositionScript();
    NotesLaneTypeScript notesLaneType;
    GetNotesTimeScript getNotesTime;
    Notes notes;
    void Start()
    {
        if (load_Pos.LoadNotesDate(1) != null)
        {
            notes = load_Pos.LoadNotesDate(selectionDateNum);
        }
        for (int i = 0; i <= notes.NotesTypeList.Count - 1; i++)
        {
            // ���Ԃ����y���w��
            notes_obj_z.z = notes.TimeList[i] * 50.0f;
            if (notes.NotesTypeList[i] == 1)
            {
                GameObject new_tapNotes = Instantiate(notes_object, new Vector3(lane_Arr[notes.LaneNumList[i]].transform.position.x,
                                                                                lane_Arr[notes.LaneNumList[i]].transform.position.y,
                                                                                notes_obj_z.z), Quaternion.identity, notes_Holder);
                new_tapNotes.name = ("notes" + i);
                int intNotesLaneType = notes.LaneNumList[i];
                var enumNotesLaneType = (NotesLaneTypeScript.LaneType)Enum.ToObject(typeof(NotesLaneTypeScript.LaneType), intNotesLaneType);
                notesObjList.Add(new_tapNotes);
                notesLaneType = notesObjList[i].GetComponent<NotesLaneTypeScript>();
                getNotesTime = notesObjList[i].GetComponent<GetNotesTimeScript>();
                notesLaneType.laneType = enumNotesLaneType;
                getNotesTime.notesTime = notes.TimeList[i];
            }
            if (notes.NotesTypeList[i] == 2)
            {
                GameObject new_HoldNotes = Instantiate(holdNotes_object, new Vector3(lane_Arr[notes.LaneNumList[i]].transform.position.x,
                                                                                     lane_Arr[notes.LaneNumList[i]].transform.position.y,
                                                                                     notes_obj_z.z), Quaternion.identity, notes_Holder);
                // ���݂̑傫������
                Vector3 plusScale_z = new_HoldNotes.transform.localScale;
                // �l�𑝂₵�đ��
                plusScale_z.z += notes.HoldTimeList[hold_count] * 50;
                // �I�u�W�F�N�g�ɃX�P�[������
                new_HoldNotes.transform.localScale = plusScale_z;
                new_HoldNotes.transform.position = new Vector3(new_HoldNotes.transform.position.x,
                                                               new_HoldNotes.transform.position.y,
                                                               new_HoldNotes.transform.position.z + plusScale_z.z / 2);
                new_HoldNotes.name = ("holdnotes" + hold_count);
                hold_count++;
                notesObjList.Add(new_HoldNotes);
                getNotesTime = notesObjList[i].GetComponent<GetNotesTimeScript>();
                getNotesTime.notesTime = notes.TimeList[i];
            }
            if (notes.NotesTypeList[i] == 3)
            {
                Vector3 centralPos = lane_Arr[1].transform.localScale * 2;
                GameObject new_LinkNotes = Instantiate(linkNotes_object, new Vector3((lane_Arr[0].transform.position.x + lane_Arr[3].transform.position.x) / 2,
                                                                                     lane_Arr[1].transform.position.y + 0.1f,
                                                                                     notes_obj_z.z), Quaternion.identity, notes_Holder);
                new_LinkNotes.name = ("linknotes" + i);
                notesObjList.Add(new_LinkNotes);
                getNotesTime = notesObjList[i].GetComponent<GetNotesTimeScript>();
                getNotesTime.notesTime = notes.TimeList[i];
            }
        }
    }
    public Notes GetNotes()
    {
        return notes;
    }
    public List<GameObject> GetListOfNotes()
    {
        return notesObjList;
    }
}
