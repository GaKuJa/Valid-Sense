using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesParentControl : MonoBehaviour
{
    [SerializeField]
    private GameObject notes_Parent;
    public void ParentSetActive(bool setActive_flag)
    {
        notes_Parent.gameObject.SetActive(setActive_flag);
    }
}
