using System.Collections;
using UnityEngine;



    public class Tap : MonoBehaviour
    {
        private float timer;     //�o�ߎ���
        [SerializeField]
        private float hittime;   //�m�[�c�̒@�����ׂ��^�C�~���O
        private float judge;    //time-hittime
                                //[SerializeField]
                                //private float HS = 1.0f;   //�n�C�X�s
                                //[SerializeField]
                                //private float offset = 0;  //�I�t�Z�b�g
        //�G�t�F�N�g�֘A
        [SerializeField] GameObject briliantEffect;
        [SerializeField] GameObject briliantBack;
        [SerializeField] GameObject greatEffect;
        [SerializeField] GameObject greatBack;
        //�e�L�X�g�֘A
        GameObject text;
        Txt tx;

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
            //Debug.Log("�o�ߎ���"+timer);
            //this.transform.position -= transform.up * HS * Time.deltaTime;//�m�[�c�̈ړ�
            ///
            /// �n�C�X�s�̒����̋@�\���l����Ƃ����炭����ύX����
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
            tx.notehit = true;
        
            Destroy(this.gameObject);

        }


        IEnumerator Briliant()
        {
            Debug.Log("Briliant");
            tx.judgetxt = "Briliant";
            //SE.PlayOneShot(briliant);
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
        //SE.PlayOneShot(great);
        yield return new WaitForSeconds(0.2f);
        Destroy(effect1.gameObject);
        Destroy(effect2.gameObject);

    }
        IEnumerator Poor()
        {
            Debug.Log("Poor");
            tx.judgetxt = "Poor";
            //SE.PlayOneShot(great);
            yield return null;

        }
    }

