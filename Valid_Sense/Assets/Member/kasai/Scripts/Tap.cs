using System.Collections;
using UnityEngine;

    public class Tap : MonoBehaviour
    {
        private float timer;     //�o�ߎ���
        [SerializeField]
        private float hittime;   //�m�[�c�̒@�����ׂ��^�C�~���O
        private float judge;    //time-hittime

        private bool process=false;

        //�G�t�F�N�g�֘A
        [SerializeField] GameObject briliantEffect;//�u�����A���g�̃G�t�F�N�g
        [SerializeField] GameObject briliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
        [SerializeField] GameObject brilianttext;//�u�����A���g�̕����G�t�F�N�g

        [SerializeField] GameObject greatEffect;//�O���[�g�̃G�t�F�N�g
        [SerializeField] GameObject greatBack;//�O���[�g�̔w�i�G�t�F�N�g
        [SerializeField] GameObject greattext;//�O���[�g�̕����G�t�F�N�g

        [SerializeField] GameObject goodtext;//�O�b�h�̕����G�t�F�N�g

        [SerializeField] GameObject poortext;//�v�A�[�̕����G�t�F�N�g

        [SerializeField] private float destroytimer = 0.3f;//�G�t�F�N�g��������܂ł̎���(���u��)

        //����֘A
        public float brilinatjudge = 0.2f;
        public float greatjudge = 0.4f;
        public float goodjudge = 0.8f;
        public float poorjudge = 1.0f;
        public float ignore = 1.2f; //���������������ꍇ�ɂ��̃m�[�c�̏������X�L�b�v����

        //�e�L�X�g�֘A
        //GameObject text;
        //Txt tx;

    // Start is called before the first frame update
    void Start()
        {
            //text = GameObject.Find("Judgedis"); //�����͌�X�����Ă�����
            //tx = text.GetComponent<Txt>();
            //Debug.Log(tx.judgetxt);
        }

        // Update is called once per frame
        void Update()
        {
            timer = Time.time;

            if (Input.GetKeyDown(KeyCode.Space))
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
            
            //tx.notehit = true;
            }
            if(timer-hittime>2)
            {
                StartCoroutine(Poor());//�m�[�c���G���Ȃ������ꍇ�̏���
                //Debug.Log(timer - hittime);
            }
        }
        

        IEnumerator Briliant()
        {
            if (!process)
            {
                process = true;
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

        }
        IEnumerator Great()
        {
            if (!process)
            {
                process = true;
                Debug.Log("Great");
                //tx.judgetxt = "Great";
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
                Destroy(this.gameObject);
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
                Destroy(this.gameObject);
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
                Destroy(this.gameObject);
            }
        }
    }

