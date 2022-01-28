using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    public GameObject briliant_result = null;
    public GameObject great_result = null;
    public GameObject good_result = null;
    public GameObject poor_result = null;

    private int briliant_count = 0;
    private int great_count = 0;
    private int good_count = 0;
    private int poor_count = 0;

    Text briliant_text;
    Text great_text;
    Text good_text;
    Text poor_text;
    private void Start()
    {
        briliant_text = briliant_result.GetComponent<Text>();
        great_text = great_result.GetComponent<Text>();
        good_text = good_result.GetComponent<Text>();
        poor_text = poor_result.GetComponent<Text>();
        //briliant_count=別スクリプトの値
        //great_count=
        //good_count=
        //poor_count=

    }

    // Update is called once per frame
    void Update()
    {
        //// オブジェクトからTextコンポーネントを取得
        //Text score_text = score_object.GetComponent<Text>();
        //// テキストの表示を入れ替える
        //score_text.text = "000000";
        briliant_text.text = "Briliant:" + briliant_text;
        great_text.text = "Great:" + great_text;
        good_text.text = "Good:" + good_text;
        poor_text.text = "Poor:" + poor_text;

    }
}
