using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
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
    public enum EffectState
    {
        Buriliant,
        Great,
        Good,
        Poor,
        Null
    }

    public EffectState effectstate = EffectState.Null;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void effect(EffectState state)
    {
        effectstate = state;
        switch(state)
        {
            case EffectState.Buriliant:
                Briliant();
                break;
            case EffectState.Great:
                Great();
                break;
            case EffectState.Good:
                Good();
                break;
            case EffectState.Poor:
                Poor();
                break;
        }
    }
    
    void Briliant()
    {
       
        
        Debug.Log("Briliant");
        
        GameObject effect1 = Instantiate(briliantEffect); //判定エフェクト生成
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(briliantBack);   //エフェクト背景生成
        effect2.transform.position = this.transform.position;
        GameObject effect3 = Instantiate(brilianttext);   //判定文字生成
        effect3.transform.position = this.transform.position;

        //ノーツの判定をどこかに加算する
        //yield return new WaitForSeconds(destroytimer);
       //yield return null;
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        effectstate = EffectState.Null;




    }
    void Great()
    {
         Debug.Log("Great");
        //tx.judgetxt = "Great";
        
        GameObject effect1 = Instantiate(greatEffect);
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(greatBack);
        effect2.transform.position = this.transform.position;
        GameObject effect3 = Instantiate(greattext);
        effect3.transform.position = this.transform.position;

        //yield return new WaitForSeconds(destroytimer);
        //yield return null;

        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        //Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        effectstate = EffectState.Null;

    }
    void Good()
    {
        //tx.judgetxt = "Good";
        GameObject effect1 = Instantiate(greatEffect);
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(greatBack);
        effect2.transform.position = this.transform.position;
        GameObject effect3 = Instantiate(greattext);
        effect3.transform.position = this.transform.position;

        //yield return new WaitForSeconds(destroytimer);
        //yield return null;
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        //Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        effectstate = EffectState.Null;

    }
void Poor()
    {
        
        Debug.Log("Poor");
        //tx.judgetxt = "Poor";
        GameObject effect1 = Instantiate(poortext);
        effect1.transform.position = this.transform.position;


        //yield return new WaitForSeconds(destroytimer);
        //yield return null;
        effect1.gameObject.SetActive(false);
        //Destroy(this.gameObject);
        //this.gameObject.SetActive(false);
        effectstate = EffectState.Null;
    }
}
