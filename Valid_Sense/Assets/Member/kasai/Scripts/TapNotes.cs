using System.Collections;
using UnityEngine;

public class TapNotes : MonoBehaviour
{
    //private float scenetimer;     //�o�ߎ���
    public long PlayTimer;
    [SerializeField]
    private float notestimer;   //�m�[�c�̒@�����ׂ��^�C�~���O
    private float judge;    //time-notestimer

    private bool process = false;

    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;

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

    // test
    //���肵��Notes�̐��𐔂���ϐ�
    private int judge_count = 0;
    //Notes�������Ă���Lane�ԍ����Q�Ƃ���ϐ�
    private int lane_count = 0;

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

    // Start is called before the first frame update
    void Start()
    {
        // json ��ɂ���f�[�^�� vs �Ɉڂ�
        notes = load_Pos.LoadNotesDate(1);
        Debug.Log(notes.TimeList[1]);
        notestimer = notes.TimeList[1];
        
        //switch (pos)
        //    {
        //        case NOTES_POSITION.notespos0:
        //            inputconfig = "space";
        //            break;
        //        case NOTES_POSITION.notespos1:
        //            inputconfig = "a";
        //            break;
        //        case NOTES_POSITION.notespos2:
        //            inputconfig = "s";
        //            break;
        //        case NOTES_POSITION.notespos3:
        //            inputconfig = "d";
        //            break;
        //        case NOTES_POSITION.notespos4:
        //            inputconfig = "f";
        //            break;
        //        default:
        //            Debug.Log("Error");
        //            break;
        //    }
    }

    // Update is called once per frame
    void Update()
    {
        //scenetimer = Time.time;
        PlayTimer = MusicData.Timer;

        //if (Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 1)
        //{
        //    lane_count++;
        //}
        //if (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 2)
        //{
        //    lane_count++;
        //}
        //if (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 3)
        //{
        //    lane_count++;
        //}
        //if (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 4)
        //{
        //    lane_count++;
        //}

        if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))
        {
            if (notes.TimeList.Count - 1 == judge_count)
                return;
            // List �ɓ����Ă鎞�Ԃ���
            notestimer = notes.TimeList[judge_count];
            judge = PlayTimer - notestimer;
            //Debug.Log(Mathf.Abs(judge));
            if (Mathf.Abs(judge) < brilinatjudge)
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
            else if (Mathf.Abs(judge) > ignore)
            {

            }

            //tx.notehit = true;
        }
        if (PlayTimer - notestimer > 1.1)
        {
            StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
            //Debug.Log(timer - notestimer);
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
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);   //�m�[�c�폜
            this.gameObject.SetActive(false);
        }

    }
    IEnumerator Great()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Great");
            //tx.judgetxt = "Great";

            lane_count++;
            judge_count++;

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
            this.gameObject.SetActive(false);
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
            GameObject effect3 = Instantiate(greattext);
            effect3.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
    IEnumerator Poor()
    {
        if (!process)
        {
            process = true;

            lane_count++;
            judge_count++;
            Debug.Log("Poor");
            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext);
            effect.transform.position = this.transform.position;


            yield return new WaitForSeconds(destroytimer);
            effect.gameObject.SetActive(false);
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}

