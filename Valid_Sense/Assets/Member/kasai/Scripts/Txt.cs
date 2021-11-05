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

            txt.enabled = true;//テキストを表示できるように
            txt.text = judgetxt;//判定表示

            yield return null;

            txt.enabled = false;//テキストを非表示に

            notehit = false;
            process = false;
        }
    }
}
