using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;

public class SaveButtonScript : MonoBehaviour
{
    private int _saveTimingIndex = 1;
    private int _savePositionIndex = 1;
    // セーブする番号を指定する為の変数
    public static int saveNum = 1;
    private int saveCount = 0;
    private bool saveFlag = false;
    private Notes _notes;
    private NotesLaneTypeScript lane_type_script;
    string fileName = "Assets/Member/Akimoto/Resources/Datas/SaveData/";
    void Update()
    {
        if (saveFlag)
        {
            AddSavePosition();
            saveCount++;
            if (saveCount > StartNotesTimingScript.Instance.notesObj_list.Count - 1)
            {
                using (var streaWriter = new StreamWriter(fileName + "notesPositionDate" + saveNum.ToString() + ".json", false, Encoding.Default))
                {
                    var jsonText = JsonUtility.ToJson(_notes);
                    streaWriter.Write(jsonText);
                }
                saveFlag = false;
            }
        }
    }
    private void AddSavePosition()
    {
        lane_type_script = StartNotesTimingScript.Instance.notesObj_list[saveCount].GetComponent<NotesLaneTypeScript>();
        int lane_num = (int)lane_type_script.laneType;
        _notes.LaneNumList.Add(lane_num);
    }
    // TimingSceneのサーブボタン
    public void ClickSaveTiming()
    {
        using (var streaWriter = new StreamWriter(fileName + "notesTimingDate" + saveNum.ToString() + ".json", false, Encoding.Default))
        {
            var jsonText = JsonUtility.ToJson(SaveTimingScriput.Instance._notes);
            streaWriter.Write(jsonText);
        }
        _saveTimingIndex++;
    }
    // PositionSceneのセーブボタン
    public void ClickSavePosition()
    {
        _notes = StartNotesTimingScript.Instance.notes;
        saveFlag = true;
    }
}