using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeControl : MonoBehaviour
{
    public static JudgeControl Instance { get => _instance; }
    static JudgeControl _instance;
    public GameObject parent_Object = null;
    public bool judge_flag;
    private GameObject notes;
    private float time;
    void Awake()
    {
        _instance = this;
    }
    void Update()
    {
        if (judge_flag)
            StartTime();
    }
    private void OnTriggerEnter(Collider collision)
    {
        parent_Object = collision.transform.parent.gameObject;
        judge_flag = true;
        notes = collision.gameObject;
    }
    private void StartTime()
    {
        //time = 0;
        time += Time.deltaTime;
        Debug.Log(time);
        if (time <= 0.1)
            Debug.Log("Poor");
        else if (time > 0.20)
            Debug.Log("Good");
        else if (time > 0.15)
            Debug.Log("Great");
        else if (time > 0.1)
            Debug.Log("Briliant");
        else
            Debug.Log("Poor");
    }
    public void Hoge()
    {
        Destroy(notes.gameObject);
    }
}
