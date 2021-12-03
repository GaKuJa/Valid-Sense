using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameKeyManager : MonoBehaviour
{
    private int count = 0;
    private bool fristCameraFlag = false;
    // �m�[�c�������Ă���f�[�^���̌��Eflag
    private bool limitCountFlag = false;
    LoadTimingScript load_Time = new LoadTimingScript();
    Notes notes;
    void Start()
    {
        if (load_Time.LoadNotesDate(1) != null)
        {
            notes = load_Time.LoadNotesDate(1);
        }
    }
    void Update()
    {
        Change_pos();
        if (notes.TimeList.Count-1 <= count)
            limitCountFlag = true;
    }
    private void Change_pos()
    {
        // Notes�̍��W�ړ�
        if (Input.GetKeyDown(KeyCode.A))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 0);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(0, count);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 1);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(1, count);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 2);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(2, count);
        }
        if (Input.GetKeyDown(KeyCode.F))
        {
            NotesChangePositionScript.Instance.ChangeNotes_positon_x(count, 3);
            Change_Lane_Type_Control.Instance.Change_Lane_Type(3, count);
        }
        // Notes�̍폜
        if (Input.GetKeyDown(KeyCode.Delete))
            DeletScript.Instance.NotesDelet(0);
        // �J�����֌W
        if (Input.GetKeyDown(KeyCode.Q))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_y;
        if (Input.GetKeyDown(KeyCode.W))
            Mousu.Instance.mousuCamera_Mode = Mousu.MousuCamera_Mode.Change_Position_z;
        // �J�������ŏ���Notes�Ɉړ�
        if(!fristCameraFlag)
        {
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
            fristCameraFlag = true;
        }
        // Notes�̍��W������Notes��
        if (Input.GetKeyDown(KeyCode.Return) && !limitCountFlag)
        {
            count++;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }
        // Notes�̍��W��O��Notes��
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            count--;
            ChangeCameraPositionControl.Instance.ChangeCameraPos(count);
        }

    }
}
