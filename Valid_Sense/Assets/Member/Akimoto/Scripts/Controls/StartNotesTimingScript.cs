using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesTimingScript : MonoBehaviour
{
    public static StartNotesTimingScript Instance { get => _instance; }
    static StartNotesTimingScript _instance;
    // NormalNotes object
    [SerializeField]
    private GameObject notes_Object;
    // HoldNotes Object
    [SerializeField]
    private GameObject holdnotes_object;
    // Notes�쐬���̍ŏ���Lane
    [SerializeField]
    private GameObject start_lane;
    // Notes��y��������ׂ̕ϐ�
    private Vector3 notes_obj_y;
    // HoldNotes��y��(Scale)������ׂ̕ϐ�
    private Vector3 plusScale_y;
    // HoldNotes�̔z��ԍ����w�肷��ׂ̕ϐ�
    private int hold_count = 0;
    // ��������Notes���o��������ׂ̕ϐ�
    public List<GameObject> notesObj_list = new List<GameObject>();
    LoadTimingScript load_Time = new LoadTimingScript();
    public Notes notes;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            notes = load_Time.LoadNotesDate(1);
        }
        for (int i = 0; i <= notes.TimeList.Count -1; i++)
        {
            notes_obj_y.y = notes.TimeList[i] * 50.0f;
            if (notes.NotesTypeList[i] == 1)
            {
                GameObject new_NormalNotes = Instantiate(notes_Object, new Vector3(start_lane.transform.position.x,
                                                                                   notes_obj_y.y,
                                                                                   start_lane.transform.position.z), Quaternion.identity);
                Debug.Log(i);
                new_NormalNotes.name = ("notes " + i);
                notesObj_list.Add(new_NormalNotes);
            }
            if (notes.NotesTypeList[i] == 2)
            {
                GameObject new_HoldNotes = Instantiate(holdnotes_object, new Vector3(start_lane.transform.position.x,
                                                                                     notes_obj_y.y,
                                                                                     start_lane.transform.position.z), Quaternion.identity);
                new_HoldNotes.name = ("holdnotes" + i);
                plusScale_y = new_HoldNotes.transform.localScale;
                plusScale_y.y += notes.HoldTimeList[hold_count] * 50 /2;
                new_HoldNotes.transform.localScale = plusScale_y;
                new_HoldNotes.transform.position = new Vector3(start_lane.transform.position.x,
                                                               notes_obj_y.y + notes.HoldTimeList[hold_count] * 50/2,
                                                               start_lane.transform.position.z - 0.1f);
                notesObj_list.Add(new_HoldNotes);
            }
        }
    }
}
