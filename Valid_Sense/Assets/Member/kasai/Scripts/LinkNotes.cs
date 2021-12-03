using System.Collections;
using UnityEngine;

public class LinkNotes : MonoBehaviour
{
    //private float timer;     //経過時間
    public long PlayTimer;
    [SerializeField]
    private float notestimer;   //ノーツの叩かれるべきタイミング
    private float judge;    //time-notestimer

    private bool process = false;

    //判定したNotesの数を数える変数
    private int judge_count = 0;
    //Notesが持っているLane番号を参照する変数
    private int lane_count = 0;

    LoadPositionScript load_Pos = new LoadPositionScript();
    Notes notes;

    //判定関連
    public float brilinatjudge = 0.8f;
    //public float greatjudge = 0.4f;
    //public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //早く押しすぎた場合にこのノーツの処理をスキップする

    private bool player1 = false;
    private bool player2 = false;

    EffectManager effectmanager = new EffectManager();
    // Start is called before the first frame update
    void Start()
    {
        // json 状にあるデータを vs に移す
        notes = load_Pos.LoadNotesDate(1);
        //Debug.Log(notes.TimeList[1]);
        notestimer = notes.TimeList[1];
        effectmanager = GetComponent<EffectManager>();

    }

    // Update is called once per frame
    void Update()
    {
        PlayTimer = MusicData.Timer;
        if (!player1)
        {
            if ((Input.GetKeyDown(KeyCode.A) && notes.LaneNumList[lane_count] == 0)
            || (Input.GetKeyDown(KeyCode.S) && notes.LaneNumList[lane_count] == 1))//player1側の処理
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
                    StartCoroutine(Poor());//ノーツが触られなかった場合の処理
                }
            }
        }

        if (!player2)
        {
            if ((Input.GetKeyDown(KeyCode.D)) || Input.GetKeyDown(KeyCode.F))//player2側の処理
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
                    StartCoroutine(Poor());//ノーツが触られなかった場合の処理
                }
            }
        }
        if (player1&&player2)
        {
            StartCoroutine(Briliant());
        }
        if (!player1||!player2||PlayTimer - notestimer > 1.1)
        {
            StartCoroutine(Poor());//ノーツが触られなかった場合の処理
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

            EffectManager.Instance.Effect(EffectManager.EffectState.Brilliant);
            yield return null;
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

            EffectManager.Instance.Effect(EffectManager.EffectState.Poor);
            yield return null;
            this.gameObject.SetActive(false);
        }
    }


}
