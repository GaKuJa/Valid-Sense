using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    public static SkillEffectManager Instance { get => _instance; }
    static SkillEffectManager _instance;

    [SerializeField] private GameObject SkillEffect;
    [SerializeField] private GameObject SkillGauge;
    private GameObject effectobj;
    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;
        SkillGauge = GameObject.Find("SkillGauge");
        effectobj = Instantiate(SkillEffect);
        effectobj.transform.position = SkillGauge.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
