using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesInstantiate : MonoBehaviour
{
    public static StartNotesInstantiate Instance { get => _instance; }
    static StartNotesInstantiate _instance;
    [SerializeField]
    private GameObject notes_obj;
    private GameObject notes;
    LoadManager load = new LoadManager();
    Notes _notes = new Notes();
    Notes notes_list;
    public List<GameObject> instanctiate_notes_list = new List<GameObject>();
    void Awake()
    {
        _instance = this;
    }
    void Start()
    {
        if (load.LoadNotesDate(1) != null)
        {
            notes_list = load.LoadNotesDate(1);
        }
        for (int i = 0; i <= notes_list.NotesList.Count - 1; i++)
        {
            notes = Instantiate(notes_obj, new Vector3(notes_list.NotesList[i].x,
                                                                  notes_list.NotesList[i].y,
                                                                  notes_list.NotesList[i].z), Quaternion.identity);
            instanctiate_notes_list.Add(notes);
            Ray ray = new Ray(notes.transform.position, notes_obj.transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                notes.gameObject.transform.parent = hit.transform;
                notes.gameObject.transform.localScale = notes_obj.transform.localScale;
            }
        }
    }
}