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

    //エフェクト関連
    [SerializeField] GameObject briliantEffect;//ブリリアントのエフェクト
    [SerializeField] GameObject briliantBack;//ブリリアントの背景エフェクト
    [SerializeField] GameObject brilianttext;//ブリリアントの文字エフェクト

    [SerializeField] GameObject poortext;//プアーの文字エフェクト

    [SerializeField] private float destroytimer = 0.3f;//エフェクトが消えるまでの時間(仮置き)

    //判定関連
    public float brilinatjudge = 0.8f;
    //public float greatjudge = 0.4f;
    //public float goodjudge = 0.8f;
    public float poorjudge = 1.0f;
    public float ignore = 1.2f; //早く押しすぎた場合にこのノーツの処理をスキップする

    private bool player1 = false;
    private bool player2 = false;
    // Start is called before the first frame update
    void Start()
    {
        // json 状にあるデータを vs に移す
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

            GameObject effect1 = Instantiate(briliantEffect); //判定エフェクト生成
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack);   //エフェクト背景生成
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext);   //判定文字生成
            effect3.transform.position = this.transform.position;

            //ノーツの判定をどこかに加算する
            //プレイヤー2人の判定を足す
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
