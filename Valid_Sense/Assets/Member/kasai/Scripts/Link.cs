using System.Collections;
using UnityEngine;

public class Link : MonoBehaviour
{
    private float timer;     //�o�ߎ���
    [SerializeField]
    private float hittime;   //�m�[�c�̒@�����ׂ��^�C�~���O
    private float judge;    //time-hittime

    private bool process = false;

    public enum NOTES_POSITION
    {
        notespos0,
        notespos1,
        notespos2,
        notespos3,
        notespos4,
    }
    public enum NOTES_POSITION2
    {
        notespos0,
        notespos1,
        notespos2,
        notespos3,
        notespos4,
    }
    public enum NOTES_POSITION3
    {
        notespos0,
        notespos1,
        notespos2,
        notespos3,
        notespos4,
    }
    public enum NOTES_POSITION4
    {
        notespos0,
        notespos1,
        notespos2,
        notespos3,
        notespos4,
    }

    public NOTES_POSITION pos;
    public NOTES_POSITION2 pos2;
    public NOTES_POSITION3 pos3;
    public NOTES_POSITION4 pos4;

    private string inputconfig1 = "null";
    private string inputconfig2 = "null";
    private string inputconfig3 = "null";
    private string inputconfig4 = "null";

    //�G�t�F�N�g�֘A
    [SerializeField] GameObject briliantEffect;//�u�����A���g�̃G�t�F�N�g
    [SerializeField] GameObject briliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
    [SerializeField] GameObject brilianttext;//�u�����A���g�̕����G�t�F�N�g

    [SerializeField] GameObject poortext;//�v�A�[�̕����G�t�F�N�g

    [SerializeField] private float destroytimer = 0.3f;//�G�t�F�N�g��������܂ł̎���(���u��)

    //����֘A
    public float brilinatjudge = 0.8f;
    //public float greatjudge = 0.4f;
    //public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //���������������ꍇ�ɂ��̃m�[�c�̏������X�L�b�v����

    private bool player1 = false;
    private bool player2 = false;
    // Start is called before the first frame update
    void Start()
    {
        switch (pos)
        {
            case NOTES_POSITION.notespos0:
                inputconfig1 = "space";
                break;
            case NOTES_POSITION.notespos1:
                inputconfig1 = "a";
                break;
            case NOTES_POSITION.notespos2:
                inputconfig1 = "s";
                break;
            case NOTES_POSITION.notespos3:
                inputconfig1 = "d";
                break;
            case NOTES_POSITION.notespos4:
                inputconfig1 = "f";
                break;
            default:
                Debug.Log("Error");
                break;
        }
        switch (pos2)
        {
            case NOTES_POSITION2.notespos0:
                inputconfig2 = "space";
                break;
            case NOTES_POSITION2.notespos1:
                inputconfig2 = "a";
                break;
            case NOTES_POSITION2.notespos2:
                inputconfig2 = "s";
                break;
            case NOTES_POSITION2.notespos3:
                inputconfig2 = "d";
                break;
            case NOTES_POSITION2.notespos4:
                inputconfig2 = "f";
                break;
            default:
                Debug.Log("Error");
                break;
        }
        switch (pos3)
        {
            case NOTES_POSITION3.notespos0:
                inputconfig3 = "space";
                break;
            case NOTES_POSITION3.notespos1:
                inputconfig3 = "a";
                break;
            case NOTES_POSITION3.notespos2:
                inputconfig3 = "s";
                break;
            case NOTES_POSITION3.notespos3:
                inputconfig3 = "d";
                break;
            case NOTES_POSITION3.notespos4:
                inputconfig3 = "f";
                break;
            default:
                Debug.Log("Error");
                break;
        }
        switch (pos4)
        {
            case NOTES_POSITION4.notespos0:
                inputconfig4 = "space";
                break;
            case NOTES_POSITION4.notespos1:
                inputconfig4 = "a";
                break;
            case NOTES_POSITION4.notespos2:
                inputconfig4 = "s";
                break;
            case NOTES_POSITION4.notespos3:
                inputconfig4 = "d";
                break;
            case NOTES_POSITION4.notespos4:
                inputconfig4 = "f";
                break;
            default:
                Debug.Log("Error");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        if (!player1)
        {
            if (Input.GetKeyDown(inputconfig1) || Input.GetKeyDown(inputconfig2))//player1���̏���
            {
                judge = timer - hittime;
                //Debug.Log(Mathf.Abs(judge));
                if (Mathf.Abs(judge) <= 0.0 && Mathf.Abs(judge) < brilinatjudge)
                {
                    player1 = true;
                }

                else if (Mathf.Abs(judge) >= poorjudge && Mathf.Abs(judge) < ignore)
                {
                    StartCoroutine(Poor());
                }
                if (timer - hittime > 2)
                {
                    StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
                }
            }
        }

        if (!player2)
        {
            if (Input.GetKeyDown(inputconfig3) || Input.GetKeyDown(inputconfig4))//player2���̏���
            {
                judge = timer - hittime;
                //Debug.Log(Mathf.Abs(judge));
                if (Mathf.Abs(judge) <= 0.0 && Mathf.Abs(judge) < brilinatjudge)
                {
                    player2 = true;
                }

                else if (Mathf.Abs(judge) >= poorjudge && Mathf.Abs(judge) < ignore)
                {
                    StartCoroutine(Poor());
                }
                if (timer - hittime > 2)
                {
                    StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
                }
            }
        }
        if (player1&&player2)
        {
            StartCoroutine(Briliant());
        }
        
    }
    IEnumerator Briliant()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");
            //tx.judgetxt = "Briliant";

            GameObject effect1 = Instantiate(briliantEffect) as GameObject; //����G�t�F�N�g����
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack) as GameObject;   //�G�t�F�N�g�w�i����
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext) as GameObject;   //���蕶������
            effect3.transform.position = this.transform.position;

            //�m�[�c�̔�����ǂ����ɉ��Z����
            //�v���C���[2�l�̔���𑫂�
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            Destroy(this.gameObject);   //�m�[�c�폜
        }

    }
    IEnumerator Poor()
    {
        if (!process)
        {
            process = true;

            Debug.Log("Poor");
            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext) as GameObject;
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect.gameObject.SetActive(false);
            Destroy(this.gameObject);
        }
    }


}
