using System.Collections;
using UnityEngine;

public class HoldNotes : MonoBehaviour
{
    //private float timer;     //�o�ߎ���
    public long PlayTimer;
    [SerializeField] private float notestimer;   //�m�[�c�̒@�����ׂ��^�C�~���O
    [SerializeField] private float endtime;  //�z�[���h�̌p������(�n�_����{�b���ŕ\��)
    private float judge;    //time-notestimer  ����Q�Ɨp

    //���肵��Notes�̐��𐔂���ϐ�
    private int judge_count = 0;
    //Notes�������Ă���Lane�ԍ����Q�Ƃ���ϐ�
    private int lane_count = 0;

    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;


    private bool holdtrigger = false;   //�z�[���h�������Ă��邩�̔���
    private bool holdprocess = false;
    private bool tap = false;
    private bool process = false;       //����p�̃R���[�`�����������̏ꍇ���������𑖂点�Ȃ��悤�ɂ���

    //����֘A
    public float brilinatjudge = 0.2f;
    public float greatjudge = 0.4f;
    public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //���������������ꍇ�ɂ��̃m�[�c�̏������X�L�b�v����

    //�e�L�X�g�֘A
    //GameObject text;
    //Txt tx;

    EffectManager effectmanager = new EffectManager();

    // Start is called before the first frame update
    void Start()
    {
        effectmanager = GetComponent<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTimer = MusicData.Timer;

        if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//�n�_�̃^�b�v�Ƃ��Ă̔���
        {
            if (!tap)
            {
                judge = PlayTimer - notestimer;
                //Debug.Log(Mathf.Abs(judge));
                if (Mathf.Abs(judge) <= 0.0 && Mathf.Abs(judge) < brilinatjudge)
                {
                    StartCoroutine(Briliant());
                }
                else if (Mathf.Abs(judge) >= brilinatjudge && Mathf.Abs(judge) < greatjudge)
                {
                    StartCoroutine(Great());
                }
                else if (Mathf.Abs(judge) >= greatjudge && Mathf.Abs(judge) < poorjudge)
                {
                    StartCoroutine(Good());
                }
                else if (Mathf.Abs(judge) >= poorjudge && Mathf.Abs(judge) < ignore)
                {
                    StartCoroutine(Poor());
                }

                tap = true;//����ɂ���Ďn�_�̃^�b�v����͍ŏ��̈�񂵂���������Ȃ�
            }

            holdtrigger = true;

            //tx.notehit = true;
        }
        if ((Input.GetKeyUp(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyUp(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyUp(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyUp(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//�z�[���h���Ɏ肪���ꂽ�ꍇ
        {
            holdtrigger = false;

        }

        if (PlayTimer >= notestimer + poorjudge && !tap)
        {
            tap = true;
            StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
        }

        if (PlayTimer >= notestimer && PlayTimer <= notestimer + endtime)
        {
            StartCoroutine(HoldJudge());//�z�[���h�m�[�c�̒������̕���
        }
        else if (PlayTimer >= notestimer + endtime)
        {
            /*Destroy(this.gameObject);*/   //�z�[���h�m�[�c���ʂ�߂�����m�[�c������
            this.gameObject.SetActive(false);
        }
    }

    IEnumerator HoldJudge()//�z�[���h�̒����������̏���
    {
        if (!holdprocess)
        {

            if (holdtrigger)
            {
                StartCoroutine(HoldBriliant());
            }
            else if (!holdtrigger)
            {
                StartCoroutine(HoldPoor());
            }
            //tx.notehit = true;
            yield return null;

        }
    }

    //�n�_�̔���
    IEnumerator Briliant()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");

            lane_count++;
            judge_count++;

            EffectManager.Instance.Effect(EffectManager.EffectState.Brilliant, 1);
            yield return null;

            process = false;
        }


    }
    IEnumerator Great()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Great");

            lane_count++;
            judge_count++;
            //tx.judgetxt = "Good";
            EffectManager.Instance.Effect(EffectManager.EffectState.Great, 1);
            yield return null;
            process = false;
        }

    }
    IEnumerator Good()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Good");

            lane_count++;
            judge_count++;


            EffectManager.Instance.Effect(EffectManager.EffectState.Good, 1);
            yield return null;
            process = false;
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
            EffectManager.Instance.Effect(EffectManager.EffectState.Poor, 1);
            yield return null;
            process = false;
        }

    }


    //�������̔���
    IEnumerator HoldBriliant()
    {
        if (!holdprocess)
        {
            holdprocess = true;
            Debug.Log("Briliant");

            judge_count++;

            EffectManager.Instance.Effect(EffectManager.EffectState.Brilliant, 1);
            yield return null;
            holdprocess = false;
        }
    }
    IEnumerator HoldPoor()
    {
        if (!holdprocess)
        {
            holdprocess = true;

            Debug.Log("Poor");

            judge_count++;

            EffectManager.Instance.Effect(EffectManager.EffectState.Poor, 1);
            yield return null;

            holdprocess = false;
        }
    }
}
