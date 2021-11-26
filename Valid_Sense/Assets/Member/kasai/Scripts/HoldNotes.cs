using System.Collections;
using UnityEngine;

public class HoldNotes : MonoBehaviour
{
    //private float timer;     //経過時間
    public long PlayTimer;
    [SerializeField] private float notestimer;   //ノーツの叩かれるべきタイミング
    [SerializeField]private float endtime;  //ホールドの継続時間(始点から＋秒数で表す)
    private float judge;    //time-notestimer  判定参照用

    //判定したNotesの数を数える変数
    private int judge_count = 0;
    //Notesが持っているLane番号を参照する変数
    private int lane_count = 0;

    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;


    private bool holdtrigger = false;   //ホールドを押しているかの判定
    private bool holdprocess = false;   
    private bool tap = false;
    private bool process = false;       //判定用のコルーチンが処理中の場合同じ処理を走らせないようにする

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

    //テキスト関連
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
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//始点のタップとしての判定
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
                
                tap = true;//これによって始点のタップ判定は最初の一回しか処理されない
            }

            holdtrigger = true;

            //tx.notehit = true;
        }
        if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//ホールド中に手が離れた場合
        {
            holdtrigger = false;

        }

        if (PlayTimer >= notestimer+poorjudge&&!tap)
        {
            tap = true;
            StartCoroutine(Poor());//ノーツが触られなかった場合の処理
        }

        if (PlayTimer >= notestimer && PlayTimer <= notestimer + endtime)
        {
            StartCoroutine(HoldJudge());//ホールドノーツの長押しの部分
        }
        else if(PlayTimer >= notestimer + endtime)
        {
            /*Destroy(this.gameObject);*/   //ホールドノーツが通り過ぎたらノーツを消す
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
        //        StartCoroutine(Poor());//ノーツが触られなかった場合の処理
        //    }
        //}

        //if (notestimer + endtime <= timer) おそらくホールドが判定線を越えた時の処理
        //{
        //    taptrigger = false;
        //    Destroy(this.gameObject);
        //}
    }
    
    IEnumerator HoldJudge()//ホールドの長押し部分の処理
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

    //始点の判定
    IEnumerator Briliant()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");

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


    //長押しの判定
    IEnumerator HoldBriliant()
    {
        if (!holdprocess)
        {
            holdprocess = true;
            Debug.Log("Briliant");

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
