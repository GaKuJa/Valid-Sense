using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    public static SkillEffectManager Instance { get => _instance; }
    static SkillEffectManager _instance;

    [SerializeField] private GameObject SkillEffect;
    [SerializeField] private GameObject[] SkillGauge;//スキルゲージ
    private GameObject effectobj1;
    private GameObject effectobj2;

    public int SkillStats1=0;//エフェクトのゲージ量    置き換えあり
    public int SkillStats2=0;//エフェクトのゲージ量    置き換えあり

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        //SkillGauge = GameObject.Find("SkillGauge");
        effectobj1 = Instantiate(SkillEffect);
        effectobj1.transform.position = SkillGauge[0].transform.position;
        effectobj1.gameObject.SetActive(false);

        effectobj2 = Instantiate(SkillEffect);
        effectobj2.transform.position = SkillGauge[1].transform.position;
        effectobj2.gameObject.SetActive(false);

        SkillStats1 = 100;//試遊会用
        SkillStats2 = 100;//試遊会用

    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            SkillStats1 = 0;
            SkillStats2 = 0;
        }
        if (SkillStats1 == 100)
        {
            Debug.Log("true");
            effectobj1.gameObject.SetActive(true);
        }
        else if (SkillStats1 != 100)
        {
            Debug.Log("false");
            effectobj1.gameObject.SetActive(false);
        }

        if (SkillStats2 == 100)
        {
            Debug.Log("true");
            effectobj2.gameObject.SetActive(true);
        }
        else if (SkillStats2 != 100)
        {
            Debug.Log("false");
            effectobj2.gameObject.SetActive(false);
        }
    }

    IEnumerator Player1Skill()
    {
        effectobj1.gameObject.SetActive(true);
        yield return null;
    }
    IEnumerator Player2Skill()
    {
        yield return null;
    }
}
