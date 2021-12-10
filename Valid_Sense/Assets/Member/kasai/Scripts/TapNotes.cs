using System.Collections;
using UnityEngine;

public class TapNotes : MonoBehaviour
{
    //private float PlayTimer;     //経過時間
    public float PlayTimer;
    public long test = 1000;
    [SerializeField]
    private float notestimer;   //ノーツの叩かれるべきタイミング
    public float Notestimer { get => notestimer; set => notestimer = value; }
    private float judge;    //time-notestimer

    private bool process = false;
    EffectManager effectmanager = new EffectManager();
    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;

    // test
    //判定したNotesの数を数える変数
    private int judge_count = 0;
    //Notesが持っているLane番号を参照する変数
    private int lane_count = 0;

    //判定関連
    public float brilinatjudge = 0.2f;
    public float greatjudge = 0.4f;
    public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //早く押しすぎた場合にこのノーツの処理をスキップする
    private bool isplay = false;


    // Start is called before the first frame update
    void Start()
    {
        // json 状にあるデータを vs に移す
        notes = load_Pos.LoadNotesDate(1);
        //Debug.Log(notes.TimeList[1]);
        //notestimer = notes.TimeList[1];
        effectmanager = GetComponent<EffectManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayTimer = MusicData.Timer / (float)test;

        if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1)
            || (Input.GetKeyDown(KeyCode.D) && notes.LaneNumList[lane_count] == 2)
            || (Input.GetKeyDown(KeyCode.F) && notes.LaneNumList[lane_count] == 3))
        {
            if (notes.TimeList.Count - 1 == judge_count)
                return;
            // List に入ってる時間を代入
            //notestimer = notes.TimeList[judge_count];
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
        }
    }


    IEnumerator Briliant()
    {
        Debug.Log(PlayTimer);
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");
            //tx.judgetxt = "Briliant";

            EffectManager.Instance.Effect(EffectManager.EffectState.Brilliant, 1);
            yield return null;
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

            //lane_count++;
            //judge_count++;

            EffectManager.Instance.Effect(EffectManager.EffectState.Great, 1);
            yield return null;
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

            //lane_count++;
            //judge_count++;

            //tx.judgetxt = "Good";
            EffectManager.Instance.Effect(EffectManager.EffectState.Good, 1);
            yield return null;
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }

    }
    IEnumerator Poor()
    {
        if (!process)
        {
            process = true;

            //lane_count++;
            //judge_count++;

            Debug.Log("Poor");
            //tx.judgetxt = "Poor";
            EffectManager.Instance.Effect(EffectManager.EffectState.Poor, 1);
            yield return null;
            //Destroy(this.gameObject);
            this.gameObject.SetActive(false);
        }
    }
}

