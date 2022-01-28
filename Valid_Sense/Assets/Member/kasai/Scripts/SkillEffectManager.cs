using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillEffectManager : MonoBehaviour
{
    public static SkillEffectManager Instance { get => _instance; }
    static SkillEffectManager _instance;

    [SerializeField] private GameObject SkillEffect;
    [SerializeField] private GameObject[] SkillGauge;//�X�L���Q�[�W
    private GameObject effectobj1;
    private GameObject effectobj2;

    public int SkillStats1=0;//�G�t�F�N�g�̃Q�[�W��    �u����������
    public int SkillStats2=0;//�G�t�F�N�g�̃Q�[�W��    �u����������

    // Start is called before the first frame update
    private void Awake()
    {
        _instance = this;

        effectobj1 = Instantiate(SkillEffect);
        effectobj1.transform.position = SkillGauge[0].transform.position;
        effectobj1.gameObject.SetActive(false);

        effectobj2 = Instantiate(SkillEffect);
        effectobj2.transform.position = SkillGauge[1].transform.position;
        effectobj2.gameObject.SetActive(false);

        //SkillStats1 = 100;//���V��p
        //SkillStats2 = 100;//���V��p
        Skill(1, true);//���V��p
        Skill(2, true);//���V��p

    }
    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Space))
        //{
        //    SkillStats1 = 0;
        //    SkillStats2 = 0;
        //}
        //if (SkillStats1 == 100)
        //{
        //    Skill(1,true);
        //}
    }

    public void Skill(int PlayerSerect, bool trigger)
    {
        if (PlayerSerect == 1)
        {
            if (trigger)
            {
                Debug.Log("true");
                effectobj1.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("false");
                effectobj1.gameObject.SetActive(false);
            }
        }
        else if(PlayerSerect==2)
        {
            if (trigger)
            {
                Debug.Log("true");
                effectobj2.gameObject.SetActive(true);
            }
            else
            {
                Debug.Log("false");
                effectobj2.gameObject.SetActive(false);
            }
        }
        else
        {
            Debug.Log("Error");
        }
    }
}
