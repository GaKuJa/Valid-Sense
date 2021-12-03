using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get => _instance; }
    static EffectManager _instance;
    public float effecttimer=2;//�G�t�F�N�g�̏��ł܂ł̎���

    //�G�t�F�N�g�֘A
    [SerializeField] private GameObject BriliantEffect;//�u�����A���g�̃G�t�F�N�g
    [SerializeField] private GameObject BriliantBack;//�u�����A���g�̔w�i�G�t�F�N�g
    [SerializeField] private GameObject BriliantText;//�u�����A���g�̕����G�t�F�N�g

    [SerializeField] private GameObject GreatEffect;//�O���[�g�̃G�t�F�N�g
    [SerializeField] private GameObject GreatBack;//�O���[�g�̔w�i�G�t�F�N�g
    [SerializeField] private GameObject GreatText;//�O���[�g�̕����G�t�F�N�g

    [SerializeField] private GameObject GoodText;//�O�b�h�̕����G�t�F�N�g

    [SerializeField] private GameObject PoorText;//�v�A�[�̕����G�t�F�N�g

    [SerializeField] private GameObject LanePos;//�G�t�F�N�g�̐����ʒu
    private float EffectPosition=0;//�G�t�F�N�g�̐����ʒu�̕␳

    //Notes�������Ă���Lane�ԍ����Q�Ƃ���ϐ�
    private int lane_count = 0;

    public enum EffectState
    {
        Brilliant,
        Great,
        Good,
        Poor,
        Null
    }

    public EffectState effectstate = EffectState.Null;
    
    private void Awake()
    {
        _instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        switch(lane_count)
        {
            case 1:
                break;
            default:
                EffectPosition = 0;
                break;
        }
    }


    public void Effect(EffectState state)
    {
        effectstate = state;
        switch(state)
        {
            case EffectState.Brilliant:
                StartCoroutine(Brilliant());
                break;
            case EffectState.Great:
                StartCoroutine(Great());
                break;
            case EffectState.Good:
                StartCoroutine(Good());
                break;
            case EffectState.Poor:
                StartCoroutine(Poor());
                break;
        }
    }
    
    IEnumerator Brilliant()
    {
        Debug.Log("Briliant");

        GameObject effect1 = Instantiate(BriliantEffect); //����G�t�F�N�g����
        GameObject effect2 = Instantiate(BriliantBack);   //�G�t�F�N�g�w�i����
        GameObject effect3 = Instantiate(BriliantText);   //���蕶������

        effect1.transform.position = new Vector3(LanePos.transform.position.x+EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect2.transform.position = new Vector3(LanePos.transform.position.x+EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect3.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);

        effect1.gameObject.SetActive(true);//�������ɃI�u�W�F�N�g����A�N�e�B�u��ԂȂ̂ŃA�N�e�B�u�ɂ���
        effect2.gameObject.SetActive(true);
        effect3.gameObject.SetActive(true);

        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        effectstate = EffectState.Null;
    }
    IEnumerator Great()
    {
         Debug.Log("Great");

        GameObject effect1 = Instantiate(GreatEffect); //����G�t�F�N�g����
        GameObject effect2 = Instantiate(GreatBack);   //�G�t�F�N�g�w�i����
        GameObject effect3 = Instantiate(GreatText);   //���蕶������

        effect1.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect2.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect3.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);

        effect1.gameObject.SetActive(true);//�������ɃI�u�W�F�N�g����A�N�e�B�u��ԂȂ̂ŃA�N�e�B�u�ɂ���
        effect2.gameObject.SetActive(true);
        effect3.gameObject.SetActive(true);

        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        effectstate = EffectState.Null;
        //GameObject effect1 = Instantiate(GreatEffect);
        //GameObject effect2 = Instantiate(GreatBack);
        //GameObject effect3 = Instantiate(GreatText);

        //effect1.transform.position = LanePos.transform.position;
        //effect2.transform.position = LanePos.transform.position;
        //effect3.transform.position = LanePos.transform.position;

        //yield return new WaitForSeconds(effecttimer);
        ////yield return null;

        //effect1.gameObject.SetActive(false);
        //effect2.gameObject.SetActive(false);
        //effect3.gameObject.SetActive(false);

        //effectstate = EffectState.Null;

    }
    IEnumerator Good()
    {
        Debug.Log("Good");
        
        GameObject effect1 = Instantiate(GreatEffect);
        GameObject effect2 = Instantiate(GreatBack);
        GameObject effect3 = Instantiate(GoodText);

        effect1.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect2.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect3.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);

        effect1.gameObject.SetActive(true);//�������ɃI�u�W�F�N�g����A�N�e�B�u��ԂȂ̂ŃA�N�e�B�u�ɂ���
        effect2.gameObject.SetActive(true);
        effect3.gameObject.SetActive(true);

        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        effectstate = EffectState.Null;

    }
    IEnumerator Poor()
    {
        
        Debug.Log("Poor");
        
        GameObject effect1 = Instantiate(PoorText);

        effect1.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        
        effect1.gameObject.SetActive(true);//�������ɃI�u�W�F�N�g����A�N�e�B�u��ԂȂ̂ŃA�N�e�B�u�ɂ���
        
        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        
        effectstate = EffectState.Null;
    }
}
