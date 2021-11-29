using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyManager : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> gamelist = new List<GameObject>();
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) && 
            JudgeControl.Instance.parent_Object == gamelist[0]&&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.S) &&
            JudgeControl.Instance.parent_Object == gamelist[1] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.D) && 
            JudgeControl.Instance.parent_Object == gamelist[2] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.F) && 
            JudgeControl.Instance.parent_Object == gamelist[3] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.H) && 
            JudgeControl.Instance.parent_Object == gamelist[4] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.J) && 
            JudgeControl.Instance.parent_Object == gamelist[5] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.K) && 
            JudgeControl.Instance.parent_Object == gamelist[6] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
        if (Input.GetKeyDown(KeyCode.L) && 
            JudgeControl.Instance.parent_Object == gamelist[7] &&
            JudgeControl.Instance.judge_flag)
            JudgeControl.Instance.Hoge();
    }
}