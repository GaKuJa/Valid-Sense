using System;
using UnityEngine;

public class TimingOffset : MonoBehaviour
{   
    [SerializeField]
    private double bpm = 0; 
    [SerializeField]
    private int beat = 1;
    private int minutes = 60;
    public float GetTimingOffset {get{return (float)Math.Round((double)((minutes/bpm)/beat),3);}}
    public static Func<float,float> fixTime;
    void Start()
    {
        fixTime = FixTime;
        Debug.Log(GetTimingOffset);
    }
    // 時間の調整
    public float FixTime(float notesTime)
    {
        int beatCount = (int)Math.Floor(notesTime/GetTimingOffset);
        float beatCountRemainder = notesTime%GetTimingOffset;
        if(GetTimingOffset / 2 < beatCountRemainder)
            beatCount += 1;
        notesTime = GetTimingOffset * beatCount;
        return notesTime;
    }
}
