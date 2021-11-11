using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesTimingScript : MonoBehaviour
{
    public static StartNotesTimingScript Instance { get => _instance; }
    static StartNotesTimingScript _instance;
    [SerializeField]
    private GameObject notes_Object;
    [SerializeField]
    private GameObject start_lane;
    private Vector3 notes_obj_y;
    public List<GameObject> notesObj_list = new List<GameObject>();
    LoadTimingScript load_Time = new LoadTimingScript();
    Notes notes;
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
        for (int i = 0; i <= notes.TimeList.Count - 1; i++)
        {
            notes_obj_y.y = notes.TimeList[i] * 50.0f;
            GameObject new_notesobj =Instantiate(notes_Object, new Vector3(start_lane.transform.position.x,
                                                  notes_obj_y.y,
                                                  start_lane.transform.position.z - 0.5f),Quaternion.identity);
            notesObj_list.Add(new_notesobj);
        }
        Debug.Log(notesObj_list.Count);
    }
}
