using System.Collections;
using UnityEngine;

public class LinkNotes : MonoBehaviour
{
    //private float timer;     //�o�ߎ���
    public long PlayTimer;
    [SerializeField]
    private float notestimer;   //�m�[�c�̒@�����ׂ��^�C�~���O
    private float judge;    //time-notestimer

    private bool process = false;

    //���肵��Notes�̐��𐔂���ϐ�
    private int judge_count = 0;
    //Notes�������Ă���Lane�ԍ����Q�Ƃ���ϐ�
    private int lane_count = 0;

    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;

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
        // json ��ɂ���f�[�^�� vs �Ɉڂ�
        notes = load_Pos.LoadNotesDate(1);
        //Debug.Log(notes.TimeList[1]);
        notestimer = notes.TimeList[1];

    }

    // Update is called once per frame
    void Update()
    {
        PlayTimer = MusicData.Timer;
        if (!player1)
        {
            if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1))//player1���̏���
            {
                judge = PlayTimer - notestimer;
                //Debug.Log(Mathf.Abs(judge));
                if (Mathf.Abs(judge) < brilinatjudge)
                {
                    player1 = true;
                }

                else if (Mathf.Abs(judge) >= poorjudge && Mathf.Abs(judge) < ignore)
                {
                    StartCoroutine(Poor());
                }
                if (PlayTimer - notestimer > 1.1)
                {
                    StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
                }
            }
        }

        if (!player2)
        {
            if ((Input.GetKeyDown(KeyCode.D)) || Input.GetKeyDown(KeyCode.F))//player2���̏���
            {
                judge = PlayTimer - notestimer;
                //Debug.Log(Mathf.Abs(judge));
                if (Mathf.Abs(judge) < brilinatjudge)
                {
                    player2 = true;
                }

                else if (Mathf.Abs(judge) >= poorjudge && Mathf.Abs(judge) < ignore)
                {
                    StartCoroutine(Poor());
                }
                if (PlayTimer - notestimer > 1.1)
                {
                    StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
                }
            }
        }
        if (player1&&player2)
        {
            StartCoroutine(Briliant());
        }
        if (!player1||!player2||PlayTimer - notestimer > 1.1)
        {
            StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
        }

    }
    IEnumerator Briliant()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");
            //tx.judgetxt = "Briliant";

            lane_count++;
            judge_count++;

            GameObject effect1 = Instantiate(briliantEffect); //����G�t�F�N�g����
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack);   //�G�t�F�N�g�w�i����
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext);   //���蕶������
            effect3.transform.position = this.transform.position;

            //�m�[�c�̔�����ǂ����ɉ��Z����
            //�v���C���[2�l�̔���𑫂�
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }

    }
    IEnumerator Poor()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Poor");

            lane_count++;
            judge_count++;

            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext);
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect.gameObject.SetActive(false);
            this.gameObject.SetActive(false);
        }
    }


}
