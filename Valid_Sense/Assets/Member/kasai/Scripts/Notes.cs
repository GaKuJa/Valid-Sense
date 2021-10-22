using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private float timer;     //経過時間
    public float hittime;   //ノーツの叩かれるべきタイミング
    private float judge;    //time-hittime
    public float HS = 1.0f;   //ハイスピ

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        //Debug.Log("経過時間"+timer);
        this.transform.position -= transform.up * HS * Time.deltaTime;//ノーツの移動
        ///
        /// ハイスピの調整の機能を考えるとおそらく今後変更する
        ///
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
        Destroy(this.gameObject);

    }


    IEnumerator Briliant()
    {
        Debug.Log("Briliant");
        //スコアと判定の数を増加させる処理
        yield return null;
    }
    IEnumerator Great()
    {
        Debug.Log("Great");
        yield return null;

    }
    IEnumerator Good()
    {
        Debug.Log("Good");
        yield return null;

    }
    IEnumerator Poor()
    {
        Debug.Log("Poor");
        yield return null;

    }
}
