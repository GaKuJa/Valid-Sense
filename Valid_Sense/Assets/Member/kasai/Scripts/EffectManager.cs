using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    //�G�t�F�N�g�֘A
    [SerializeField] GameObject briliantEffect;//�u�����A���g�̃G�t�F�N�g
    [SerializeField] GameObject briliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
    [SerializeField] GameObject brilianttext;//�u�����A���g�̕����G�t�F�N�g

    [SerializeField] GameObject greatEffect;//�O���[�g�̃G�t�F�N�g
    [SerializeField] GameObject greatBack;//�O���[�g�̔w�i�G�t�F�N�g
    [SerializeField] GameObject greattext;//�O���[�g�̕����G�t�F�N�g

    [SerializeField] GameObject goodtext;//�O�b�h�̕����G�t�F�N�g

    [SerializeField] GameObject poortext;//�v�A�[�̕����G�t�F�N�g
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
        
        GameObject effect1 = Instantiate(briliantEffect); //����G�t�F�N�g����
        effect1.transform.position = this.transform.position;
        GameObject effect2 = Instantiate(briliantBack);   //�G�t�F�N�g�w�i����
        effect2.transform.position = this.transform.position;
        GameObject effect3 = Instantiate(brilianttext);   //���蕶������
        effect3.transform.position = this.transform.position;

        //�m�[�c�̔�����ǂ����ɉ��Z����
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
