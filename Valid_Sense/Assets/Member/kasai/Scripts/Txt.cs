using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Txt : MonoBehaviour
{
    public Text txt;
    [HideInInspector]
    public string judgetxt = "test";
    private bool process = false;
    public bool notehit = false;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        txt.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (notehit)
        {
            StartCoroutine(judgedis());
        }

    }
    IEnumerator judgedis()
    {
        if (!process)
        {
            process = true;

            txt.enabled = true;//�e�L�X�g��\���ł���悤��
            txt.text = judgetxt;//����\��

            yield return null;

            txt.enabled = false;//�e�L�X�g���\����

            notehit = false;
            process = false;
        }
    }
}
