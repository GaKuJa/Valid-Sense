using System.Collections;
using UnityEngine;

public class HoldNotes : MonoBehaviour
{
    //private float timer;     //経過時間
    public long PlayTimer;
    [SerializeField] private float notestimer;   //ノーツの叩かれるべきタイミング
    [SerializeField] private float endtime;  //ホールドの継続時間(始点から＋秒数で表す)
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

    //判定関連
    public float brilinatjudge = 0.2f;
    public float greatjudge = 0.4f;
    public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //早く押しすぎた場合にこのノーツの処理をスキップする

    //テキスト関連
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
        if ((Input.GetKeyUp(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyUp(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyUp(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyUp(KeyCode.F) && notes.LaneNumList[lane_count] == 3))//ホールド中に手が離れた場合
        {
            holdtrigger = false;

        }

        if (PlayTimer >= notestimer + poorjudge && !tap)
        {
            tap = true;
            StartCoroutine(Poor());//ノーツが触られなかった場合の処理
        }

        if (PlayTimer >= notestimer && PlayTimer <= notestimer + endtime)
        {
            StartCoroutine(HoldJudge());//ホールドノーツの長押しの部分
        }
        else if (PlayTimer >= notestimer + endtime)
        {
            /*Destroy(this.gameObject);*/   //ホールドノーツが通り過ぎたらノーツを消す
            this.gameObject.SetActive(false);
        }
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


    //長押しの判定
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
