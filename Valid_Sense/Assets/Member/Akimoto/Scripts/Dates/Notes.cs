using System;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Notes
{
    // �m�[�c�̏ꏊ
    public List<Vector3> NotesList = new List<Vector3>();
    // �m�[�c�̓����蔻��̎���
    public List<float> TimeList = new List<float>();
    public List<int> NotesTypeList = new List<int>();
    public List<float> HoldTimeList = new List<float>();
}