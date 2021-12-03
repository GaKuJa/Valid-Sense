using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesTimingScript : MonoBehaviour
{
    public static StartNotesTimingScript Instance { get => _instance; }
    static StartNotesTimingScript _instance;
    // NormalNotes Object
    [SerializeField]
    private GameObject notes_Object;
    // HoldNotes Object
    [SerializeField]
    private GameObject holdnotes_object;
    // LinkNotes Object
    [SerializeField]
    private GameObject linknotes_object;
    // Notes�쐬���̍ŏ���Lane
    [SerializeField]
    private GameObject startLane;
    // Notes��y��������ׂ̕ϐ�
    private Vector3 notesObjZ;
    // HoldNotes��y��(Scale)������ׂ̕ϐ�
    private Vector3 plusScaleZ;
    // HoldNotes�̔z��ԍ����w�肷��ׂ̕ϐ�
    private int hold_count = 0;
    // ���[�h����Z�[�u�f�[�^�̔ԍ������w�肷��ϐ�
    public static int selectiondate_num = 1;
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
        if (load_Time.LoadNotesDate(selectiondate_num) != null)
        {
            notes = load_Time.LoadNotesDate(selectiondate_num);
        }
        for (int i = 0; i <= notes.TimeList.Count -1; i++)
        {
            notesObjZ.z = notes.TimeList[i] * 50.0f;
            if (notes.NotesTypeList[i] == 1)
            {
                GameObject new_NormalNotes = Instantiate(notes_Object, new Vector3(startLane.transform.position.x,
                                                                                   startLane.transform.position.y,
                                                                                   notesObjZ.z), Quaternion.identity);
                new_NormalNotes.name = ("notes " + i);
                notesObj_list.Add(new_NormalNotes);
            }
            if (notes.NotesTypeList[i] == 2)
            {
                GameObject new_HoldNotes = Instantiate(holdnotes_object, new Vector3(startLane.transform.position.x,
                                                                                     startLane.transform.position.y,
                                                                                     notesObjZ.z), Quaternion.identity);
                new_HoldNotes.name = ("holdnotes" + i);
                plusScaleZ = new_HoldNotes.transform.localScale;
                plusScaleZ.z += notes.HoldTimeList[hold_count] * 50;
                new_HoldNotes.transform.localScale = plusScaleZ;
                new_HoldNotes.transform.position = new Vector3(startLane.transform.position.x,
                                                               startLane.transform.position.y,
                                                               notesObjZ.z + notes.HoldTimeList[hold_count] * 50/2);
                notesObj_list.Add(new_HoldNotes);
            }
            if(notes.NotesTypeList[i] == 3)
            {
                GameObject new_LinkNotes = Instantiate(linknotes_object, new Vector3(0,
                                                                                     startLane.transform.position.y,
                                                                                     notesObjZ.z), Quaternion.identity);
                new_LinkNotes.name = ("linknotes" + i);
                notesObj_list.Add(new_LinkNotes);
            }
        }
    }
}
