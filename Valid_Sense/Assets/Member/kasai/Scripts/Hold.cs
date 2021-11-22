using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    private float timer;     //経過時間
    [SerializeField] private float hittime;   //ノーツの叩かれるべきタイミング
    [SerializeField]private float endtime;  //ホールドの継続時間(始点から＋秒数で表す)
    private float judge;    //time-hittime  判定参照用

    private bool holdtrigger = false;   //ホールドを押しているかの判定
    private bool holdprocess = false;   
    private bool holdstart = false;
    private bool process = false;       //判定用のコルーチンが処理中の場合同じ処理を走らせないようにする

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
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (!holdstart)
            {
                judge = timer - hittime;
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
                
                holdstart = true;//これによって始点のタップ判定は最初の一回しか処理されない
            }

            holdtrigger = true;

            //tx.notehit = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            holdtrigger = false;

        }

        if (timer >= hittime+poorjudge&&!holdstart)
        {
            holdstart = true;
            StartCoroutine(Poor());//ノーツが触られなかった場合の処理
        }

        if (timer>=hittime && timer <= hittime + endtime)
            
        {
            StartCoroutine(HoldJudge());//ホールドノーツの長押しの部分
        }
        else if(timer >= hittime + endtime)
        {
            Destroy(this.gameObject);   //ホールドノーツが通り過ぎたらノーツを消す
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

        //if (hittime + endtime <= timer) おそらくホールドが判定線を越えた時の処理
        //{
        //    holdstarttrigger = false;
        //    Destroy(this.gameObject);
        //}
    }
    
    IEnumerator HoldJudge()
    {
        if (!holdprocess)
        {
            holdprocess = true;
            if (holdtrigger)
            {
                StartCoroutine(Briliant());
            }
            else if (!holdtrigger)
            {
                StartCoroutine(Poor());
            }
            //tx.notehit = true;
            yield return null;
            holdprocess = false;
        }
    }

    IEnumerator Briliant()
    {
        if (!process)
        {
            process = true;
            Debug.Log("Briliant");
            
            GameObject effect1 = Instantiate(briliantEffect) as GameObject; //判定エフェクト生成
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack) as GameObject;   //エフェクト背景生成
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext) as GameObject;   //判定文字生成
            effect3.transform.position = this.transform.position;

            //ノーツの判定をどこかに加算する
            yield return new WaitForSeconds(destroytimer);
            Destroy(effect1.gameObject);//エフェクトを削除
            Destroy(effect2.gameObject);
            Destroy(effect3.gameObject);
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
            //tx.judgetxt = "Good";
            GameObject effect1 = Instantiate(greatEffect) as GameObject;
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(greatBack) as GameObject;
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(greattext) as GameObject;
            effect3.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            Destroy(effect1.gameObject);
            Destroy(effect2.gameObject);
            Destroy(effect3.gameObject);
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
            //tx.judgetxt = "Good";
            GameObject effect1 = Instantiate(greatEffect) as GameObject;
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(greatBack) as GameObject;
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(greattext) as GameObject;
            effect3.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            Destroy(effect1.gameObject);
            Destroy(effect2.gameObject);
            Destroy(effect3.gameObject);
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
            //tx.judgetxt = "Poor";
            GameObject effect = Instantiate(poortext) as GameObject;
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            Destroy(effect.gameObject);
            //Destroy(this.gameObject);
            process = false;
        }

    }
}
