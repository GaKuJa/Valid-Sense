using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesChangePositionScript : MonoBehaviour
{
    public static NotesChangePositionScript Instance { get => _instance; }
    static NotesChangePositionScript _instance;
    [SerializeField]
    private List<GameObject> leanobj_List = new List<GameObject>();
    public List<Vector3> notes_list = new List<Vector3>();
    LoadTimingScript load_Time = new LoadTimingScript();
    public Notes _notes;
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            _notes = load_Time.LoadNotesDate(1);
        }
    }
    public void ChangeNotes_positon_x(int list_num,int lean_num)
    {
         StartNotesTimingScript.Instance.notesObj_list[list_num].transform.position =
                                    new Vector3(leanobj_List[lean_num].transform.position.x,
                                                StartNotesTimingScript.Instance.notesObj_list[list_num].transform.position.y,
                                                StartNotesTimingScript.Instance.notesObj_list[list_num].transform.position.z);
        //_notes.NotesList.Add(StartNotesTimingScript.Instance.notesObj_list[list_num].transform.position);
    }
}
