using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judge : MonoBehaviour
{
    private BoxCollider cl;
    // Start is called before the first frame update
    void Start()
    {
        cl = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            cl.enabled = true;
            Debug.Log("a");
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            cl.enabled = false;
        }
    }
}
