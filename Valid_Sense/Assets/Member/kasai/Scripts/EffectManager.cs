using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get => _instance; }
    static EffectManager _instance;
    public float effecttimer=2;//エフェクトの消滅までの時間

    //エフェクト関連
    [SerializeField] private GameObject BriliantEffect;//ブリリアントのエフェクト
    [SerializeField] private GameObject BriliantBack;//ブリリアントの背景エフェクト
    [SerializeField] private GameObject BriliantText;//ブリリアントの文字エフェクト

    [SerializeField] private GameObject GreatEffect;//グレートのエフェクト
    [SerializeField] private GameObject GreatBack;//グレートの背景エフェクト
    [SerializeField] private GameObject GreatText;//グレートの文字エフェクト

    [SerializeField] private GameObject GoodText;//グッドの文字エフェクト

    [SerializeField] private GameObject PoorText;//プアーの文字エフェクト

    [SerializeField] private GameObject LanePos;//エフェクトの生成位置
    private float EffectPosition=0;//エフェクトの生成位置の補正

    //Notesが持っているLane番号を参照する変数
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

        GameObject effect1 = Instantiate(BriliantEffect); //判定エフェクト生成
        GameObject effect2 = Instantiate(BriliantBack);   //エフェクト背景生成
        GameObject effect3 = Instantiate(BriliantText);   //判定文字生成

        effect1.transform.position = new Vector3(LanePos.transform.position.x+EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect2.transform.position = new Vector3(LanePos.transform.position.x+EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect3.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);

        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする
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

        GameObject effect1 = Instantiate(GreatEffect); //判定エフェクト生成
        GameObject effect2 = Instantiate(GreatBack);   //エフェクト背景生成
        GameObject effect3 = Instantiate(GreatText);   //判定文字生成

        effect1.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect2.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);
        effect3.transform.position = new Vector3(LanePos.transform.position.x + EffectPosition, LanePos.transform.position.y, LanePos.transform.position.z);

        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする
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

        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする
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
        
        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする
        
        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        
        effectstate = EffectState.Null;
    }
}
