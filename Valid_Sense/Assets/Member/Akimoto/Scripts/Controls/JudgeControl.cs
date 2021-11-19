using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeControl : MonoBehaviour
{
    public static JudgeControl Instance { get => _instance; }
    static JudgeControl _instance;
    public GameObject parent_Object = null;
    public bool judge_flag = true;
    private GameObject notes;
    private float time;
    void Awake()
    {
        _instance = this;
    }
    private void OnTriggerEnter(Collider collision)
    {
        parent_Object = collision.transform.parent.gameObject;
        judge_flag = true;
        notes = collision.gameObject;
    }
    private void StartTime()
    {
        
    }
    public void Hoge()
    {
        Destroy(notes.gameObject);
    }
}
