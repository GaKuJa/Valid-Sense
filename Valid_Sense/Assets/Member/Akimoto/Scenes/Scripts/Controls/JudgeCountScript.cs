using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JudgeCountScript : MonoBehaviour
{
    enum Judge_type
    {
        briliant,
        great,
        good,
        poor
    }
    public static JudgeCountScript Instance { get => _instance; }
    static JudgeCountScript _instance;
    private Judge_type judge_count;
    public int miss_conut = 0;
    void Awake()
    {
        _instance = this;
    }
}
