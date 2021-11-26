using System.Collections;
using UnityEngine;

public class TapNotes : MonoBehaviour
{
    //private float scenetimer;     //経過時間
    public long PlayTimer;
    [SerializeField]
    private float notestimer;   //ノーツの叩かれるべきタイミング
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
    //public NOTES_POSITION pos;  //ノーツの場所や叩くボタンを設定できるようにする

    //private string inputconfig = "null";

    // test
    //判定したNotesの数を数える変数
    private int judge_count = 0;
    //Notesが持っているLane番号を参照する変数
    private int lane_count = 0;

    //エフェクト関連
    [SerializeField] GameObject briliantEffect;//ブリリアントのエフェクト
    [SerializeField] GameObject briliantBack;//ブリリアントの背景エフェクト
    [SerializeField] GameObject brilianttext;//ブリリアントの文字エフェクト

    [SerializeField] GameObject greatEffect;//グレートのエフェクト
    [SerializeField] GameObject greatBack;//グレートの背景エフェクト
    [SerializeField] GameObject greattext;//グレートの文字エフェクト

    [SerializeField] GameObject goodtext;//グッドの文字エフェクト

    [SerializeField] GameObject poortext;//プアーの文字エフェクト

    [SerializeField] private float destroytimer = 0.3f;//エフェクトが消えるまでの時間(仮置き)

    //判定関連
    public float brilinatjudge = 0.2f;
    public float greatjudge = 0.4f;
    public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //早く押しすぎた場合にこのノーツの処理をスキップする

    // Start is called before the first frame update
    void Start()
    {
        // json 状にあるデータを vs に移す
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
            // List に入ってる時間を代入
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
            StartCoroutine(Poor());//ノーツが触られなかった場合の処理
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

            GameObject effect1 = Instantiate(briliantEffect); //判定エフェクト生成
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack);   //エフェクト背景生成
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext);   //判定文字生成
            effect3.transform.position = this.transform.position;

            //ノーツの判定をどこかに加算する
            yield return new WaitForSeconds(destroytimer);
            effect1.gameObject.SetActive(false);
            effect2.gameObject.SetActive(false);
            effect3.gameObject.SetActive(false);
            //Destroy(this.gameObject);   //ノーツ削除
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

