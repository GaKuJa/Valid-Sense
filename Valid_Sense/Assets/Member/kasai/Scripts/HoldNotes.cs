using System.Collections;
using UnityEngine;

public class HoldNotes : MonoBehaviour
{
    //private float timer;     //�o�ߎ���
    public long PlayTimer;
    [SerializeField] private float notestimer;   //�m�[�c�̒@�����ׂ��^�C�~���O
    [SerializeField]private float endtime;  //�z�[���h�̌p������(�n�_����{�b���ŕ\��)
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

    //public enum NOTES_POSITION
    //{
    //    notespos0,
    //    notespos1,
    //    notespos2,
    //    notespos3,
    //    notespos4,
    //}
    //public NOTES_POSITION pos;  //�m�[�c�̏ꏊ��@���{�^����ݒ�ł���悤�ɂ���

    //private string inputconfig = "null";

    //�G�t�F�N�g�֘A
    [SerializeField] GameObject briliantEffect;//�u�����A���g�̃G�t�F�N�g
    [SerializeField] GameObject briliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
    [SerializeField] GameObject brilianttext;//�u�����A���g�̕����G�t�F�N�g

    [SerializeField] GameObject greatEffect;//�O���[�g�̃G�t�F�N�g
    [SerializeField] GameObject greatBack;//�O���[�g�̔w�i�G�t�F�N�g
    [SerializeField] GameObject greattext;//�O���[�g�̕����G�t�F�N�g

    [SerializeField] GameObject goodtext;//�O�b�h�̕����G�t�F�N�g

    [SerializeField] GameObject poortext;//�v�A�[�̕����G�t�F�N�g

    [SerializeField] private float destroytimer = 0.3f;//�G�t�F�N�g��������܂ł̎���(���u��)
    
    //����֘A
    public float brilinatjudge = 0.2f;
    public float greatjudge = 0.4f;
    public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //���������������ꍇ�ɂ��̃m�[�c�̏������X�L�b�v����

    //�e�L�X�g�֘A
    //GameObject text;
    //Txt tx;

    
   
    // Start is called before the first frame update
    void Start()
    {
        //text = GameObject.Find("Judgedis");
        //tx = text.GetComponent<Txt>();
        //Debug.Log(tx.judgetxt);
        //switch (pos)
        //{
        //    case NOTES_POSITION.notespos0:
        //        inputconfig = "space";
        //        break;
        //    case NOTES_POSITION.notespos1:
        //        inputconfig = "a";
        //        break;
        //    case NOTES_POSITION.notespos2:
        //        inputconfig = "s";
        //        break;
        //    case NOTES_POSITION.notespos3:
        //        inputconfig = "d";
        //        break;
        //    case NOTES_POSITION.notespos4:
        //        inputconfig = "f";
        //        break;
        //    default:
        //        Debug.Log("Error");
        //        break;
        //}
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
        if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//�z�[���h���Ɏ肪���ꂽ�ꍇ
        {
            holdtrigger = false;

        }

        if (PlayTimer >= notestimer+poorjudge&&!tap)
        {
            tap = true;
            StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
        }

        if (PlayTimer >= notestimer && PlayTimer <= notestimer + endtime)
        {
            StartCoroutine(HoldJudge());//�z�[���h�m�[�c�̒������̕���
        }
        else if(PlayTimer >= notestimer + endtime)
        {
            /*Destroy(this.gameObject);*/   //�z�[���h�m�[�c���ʂ�߂�����m�[�c������
            this.gameObject.SetActive(false);
        }


        //if (timer - endtime > 2)
        //{
        //    if(holdtrigger)
        //    {
        //        StartCoroutine(Briliant());
        //    }
        //    else if (!holdtrigger)
        //    {
        //        StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
        //    }
        //}

        //if (notestimer + endtime <= timer) �����炭�z�[���h����������z�������̏���
        //{
        //    taptrigger = false;
        //    Destroy(this.gameObject);
        //}
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

            GameObject effect1 = Instantiate(briliantEffect); //����G�t�F�N�g����
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack);   //�G�t�F�N�g�w�i����
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext);   //���蕶������
            effect3.transform.position = this.transform.position;

            //�m�[�c�̔�����ǂ����ɉ��Z����
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);   //�m�[�c�폜
            process = false;
        }


    }
    IEnumerator Great()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Good");

            lane_count++;
            judge_count++;
            //tx.judgetxt = "Good";
            GameObject effect1 = Instantiate(greatEffect);
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(greatBack);
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(greattext);
            effect3.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);
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

            //tx.judgetxt = "Good";
            GameObject effect1 = Instantiate(greatEffect);
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(greatBack);
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(goodtext);
            effect3.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);
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
            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext);
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect.gameObject.SetActive(false);
            //Destroy(this.gameObject);
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

            GameObject effect1 = Instantiate(briliantEffect); //����G�t�F�N�g����
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack);   //�G�t�F�N�g�w�i����
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext);   //���蕶������
            effect3.transform.position = this.transform.position;

            //�m�[�c�̔�����ǂ����ɉ��Z����
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);   //�m�[�c�폜
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
            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext);
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect.gameObject.SetActive(false);
            //Destroy(this.gameObject);
            holdprocess = false;
        }
    }
}
