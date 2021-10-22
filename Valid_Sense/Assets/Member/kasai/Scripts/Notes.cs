using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notes : MonoBehaviour
{
    private float timer;     //�o�ߎ���
    public float hittime;   //�m�[�c�̒@�����ׂ��^�C�~���O
    private float judge;    //time-hittime
    public float HS = 1.0f;   //�n�C�X�s

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.time;
        //Debug.Log("�o�ߎ���"+timer);
        this.transform.position -= transform.up * HS * Time.deltaTime;//�m�[�c�̈ړ�
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
        Destroy(this.gameObject);

    }


    IEnumerator Briliant()
    {
        Debug.Log("Briliant");
        //�X�R�A�Ɣ���̐��𑝉������鏈��
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
