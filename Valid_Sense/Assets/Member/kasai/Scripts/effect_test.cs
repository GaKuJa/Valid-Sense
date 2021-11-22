using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_test : MonoBehaviour
{
    //エフェクト関連
    [SerializeField] GameObject briliantEffect;//ブリリアントのエフェクト
    [SerializeField] GameObject briliantBack;//ブリリアントの背景エフェクト
    [SerializeField] GameObject brilianttext;//ブリリアントの文字エフェクト

    [SerializeField] GameObject greatEffect;//グレートのエフェクト
    [SerializeField] GameObject greatBack;//グレートの背景エフェクト
    [SerializeField] GameObject greattext;//グレートの文字エフェクト

    [SerializeField] GameObject goodtext;//グッドの文字エフェクト

    [SerializeField] GameObject poortext;//プアーの文字エフェクト

    [SerializeField] private float destroytimer = 5;//エフェクトが消えるまでの時間(仮置き)
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.W))
        {
            StartCoroutine(Briliant());
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(Great());
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            StartCoroutine(Good());
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            StartCoroutine(Poor());
        }
    }

    IEnumerator Briliant()
    {
            
           
            Debug.Log("Briliant");
            //tx.judgetxt = "Briliant";

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
            Destroy(this.gameObject);   //ノーツ削除
        }

    IEnumerator Great()
    {
        
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
            
        

    }
    IEnumerator Good()
    {
        
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
           

    }
    IEnumerator Poor()
    {
        
            
            GameObject effect = Instantiate(poortext) as GameObject;
            effect.transform.position = this.transform.position;

            yield return new WaitForSeconds(destroytimer);
            Destroy(effect.gameObject);
            
        
    }
}
