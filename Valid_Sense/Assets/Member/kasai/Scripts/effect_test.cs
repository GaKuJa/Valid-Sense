using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class effect_test : MonoBehaviour
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

    [SerializeField] private float destroytimer = 5;//�G�t�F�N�g��������܂ł̎���(���u��)
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

            GameObject effect1 = Instantiate(briliantEffect) as GameObject; //����G�t�F�N�g����
            effect1.transform.position = this.transform.position;
            GameObject effect2 = Instantiate(briliantBack) as GameObject;   //�G�t�F�N�g�w�i����
            effect2.transform.position = this.transform.position;
            GameObject effect3 = Instantiate(brilianttext) as GameObject;   //���蕶������
            effect3.transform.position = this.transform.position;

            //�m�[�c�̔�����ǂ����ɉ��Z����
            yield return new WaitForSeconds(destroytimer);
            Destroy(effect1.gameObject);//�G�t�F�N�g���폜
            Destroy(effect2.gameObject);
            Destroy(effect3.gameObject);
            Destroy(this.gameObject);   //�m�[�c�폜
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
