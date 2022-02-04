using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTest : MonoBehaviour
{
    [SerializeField] public RectTransform Rect; 

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.UpArrow))
        {
            StartCoroutine("ScrollUp");
        }
        else if(Input.GetKeyDown(KeyCode.DownArrow))
        {
            StartCoroutine("ScrollDown");
        }
    }

    IEnumerator ScrollUp()
    {
        for(int i = 0;i<10;i++)
        {
            Rect.position += new Vector3(0,-100,0);
            yield return null;
        }
    }
    IEnumerator ScrollDown()
    {
        for(int i = 0;i<10;i++)
        {
            Rect.position += new Vector3(0,100,0);
            yield return null;
        }
    }
}
