using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetNotesTimeScript : MonoBehaviour
{
    public  float notesTime = 0;
    private bool flag = false;
    private void FixedUpdate()
    {
        if(notesTime <= MusicData.Timer/1000 && !flag)
        {
            Debug.Log(this.gameObject.name + " OfPosition : " + this.transform.position);
            flag = true;
        }
    }
}
