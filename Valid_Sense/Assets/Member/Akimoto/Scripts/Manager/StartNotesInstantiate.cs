using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartNotesInstantiate : MonoBehaviour
{
    [SerializeField]
    private GameObject notes_obj;
    LoadManager load = new LoadManager();
    Notes _notes = new Notes();
    Notes notes_list;
    void Start()
    {
        if (load.LoadNotesDate(1) != null)
        {
            notes_list = load.LoadNotesDate(1);
            //transform_list 
            Debug.Log(notes_list.NotesList.Count);
        }
        for (int i = 0; i <= notes_list.NotesList.Count - 1; i++)
        {
            GameObject notes = Instantiate(notes_obj, new Vector3(notes_list.NotesList[i].x,
                                                                  notes_list.NotesList[i].y,
                                                                  notes_list.NotesList[i].z), Quaternion.identity);
            Ray ray = new Ray(notes.transform.position, notes_obj.transform.forward);
            Debug.Log(notes_obj.transform.position);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                notes.gameObject.transform.parent = hit.transform;
                notes.gameObject.transform.localScale = notes_obj.transform.localScale;
            }
        }
    }
}