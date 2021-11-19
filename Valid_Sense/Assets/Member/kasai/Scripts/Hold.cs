using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hold : MonoBehaviour
{
    private float timer;     //経過時間
    [SerializeField]
    private float hittime;   //ノーツの叩かれるべきタイミング
    private float endtime;  //ホールドの継続時間
    private float judge;    //time-hittime

    //エフェクト関連
    [SerializeField] GameObject briliantEffect;
    [SerializeField] GameObject briliantBack;
    [SerializeField] GameObject greatEffect;
    [SerializeField] GameObject greatBack;

    //テキスト関連
    GameObject text;
    Txt tx;
    public bool holdtrigger = false;
    private bool holdstarttrigger = false;
    private bool process = false;
   
    // Start is called before the first frame update
    void Start()
    {
        text = GameObject.Find("Judgedis");
        tx = text.GetComponent<Txt>();
        Debug.Log(tx.judgetxt);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        if (hittime + endtime <= timer)
        {
            holdstarttrigger = false;
            Destroy(this.gameObject);
        }
    }
    private void OnTriggerEnter(Collider collision)
    {
        judge = timer - hittime;
        Debug.Log(Mathf.Abs(judge));
        if (Mathf.Abs(judge) <= 0.0 && Mathf.Abs(judge) < 0.2)
        {
            StartCoroutine(Briliant());
        }
        else if (Mathf.Abs(judge) >= 0.2 && Mathf.Abs(judge) < 0.4)
        {
            StartCoroutine(Great());
        }
        else if (Mathf.Abs(judge) >= 0.4 && Mathf.Abs(judge) < 1.0)
        {
            StartCoroutine(Good());
        }
        else
        {
            StartCoroutine(Poor());
        }
        tx.notehit = true;
        holdstarttrigger = true;

        
    }
    private void OnTriggerStay(Collider collision)
    {
        holdtrigger = true;
        if (holdstarttrigger)
        {
            StartCoroutine(HoldJudge());
        }
    }
    private void OnTriggerExit(Collider collision)
    {
        holdtrigger = false;
        
     
    }
    IEnumerator HoldJudge()
    {
        if (!process)
        {
            process = true;
            if (holdtrigger)
            {
                StartCoroutine(Briliant());
            }
            else if (!holdtrigger)
            {
                StartCoroutine(Poor());
            }
            tx.notehit = true;
            yield return new WaitForSeconds(0.2f);
            process = false;
        }
    }
    IEnumerator Briliant()
    {
        Debug.Log("Briliant");
        tx.judgetxt = "Briliant";
        GameObject effect1 = Instantiate(briliantEffect) as GameObject;
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(briliantBack) as GameObject;
        effect2.transform.position = this.transform.position;


        yield return new WaitForSeconds(0.2f);
        Destroy(effect1.gameObject);
        Destroy(effect2.gameObject);

        
    }
    IEnumerator Great()
    {
        Debug.Log("Great");
        tx.judgetxt = "Great";

        GameObject effect1 = Instantiate(greatEffect) as GameObject;
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(greatBack) as GameObject;
        effect2.transform.position = this.transform.position;
        //SE.PlayOneShot(great);
        yield return new WaitForSeconds(0.2f);
        Destroy(effect1.gameObject);
        Destroy(effect2.gameObject);

    }
    IEnumerator Good()
    {
        Debug.Log("Good");
        tx.judgetxt = "Good";

        GameObject effect1 = Instantiate(greatEffect) as GameObject;
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(greatBack) as GameObject;
        effect2.transform.position = this.transform.position;
        
        yield return new WaitForSeconds(0.2f);
        Destroy(effect1.gameObject);
        Destroy(effect2.gameObject);

    }
    IEnumerator Poor()
    {
        Debug.Log("Poor");
        tx.judgetxt = "Poor";
       
        yield return null;

    }
}
