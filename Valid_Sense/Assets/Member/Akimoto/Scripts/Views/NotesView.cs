using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NotesView : MonoBehaviour
{
    [SerializeField]
    private GameObject judge_Lane;
    void Update()
    {
        if(judge_Lane.transform.position.y - 15.0f 
                        > this.transform.position.y)
        {
            this.gameObject.SetActive(false);
        }
    }
}
