using System.Collections;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance { get => _instance; }
    static EffectManager _instance;
    public float effecttimer = 2;//エフェクトの消滅までの時間

    //エフェクト関連
    [SerializeField] private GameObject BriliantEffect;//ブリリアントのエフェクト
    [SerializeField] private GameObject BriliantBack;//ブリリアントの背景エフェクト
    [SerializeField] private GameObject BriliantText;//ブリリアントの文字エフェクト

    [SerializeField] private GameObject GreatEffect;//グレートのエフェクト
    [SerializeField] private GameObject GreatBack;//グレートの背景エフェクト
    [SerializeField] private GameObject GreatText;//グレートの文字エフェクト

    [SerializeField] private GameObject GoodText;//グッドの文字エフェクト

    [SerializeField] private GameObject PoorText;//プアーの文字エフェクト

    [SerializeField] private GameObject judgeLane;

    [SerializeField] private GameObject[] laneArray = new GameObject[4];
    private int effectNum = 0;

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

    //private void Update()
    //{
    //    if(Input.GetKeyDown(KeyCode.Space))
    //    {
    //        Effect(EffectState.Brilliant, 1);
    //    }
    //}
    public void Effect(EffectState state, int laneNum)
    {
        effectNum = laneNum;
        effectstate = state;
        switch (state)
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
        
        effect1.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect2.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect3.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        
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

        effect1.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect2.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect3.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);

        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする
        effect2.gameObject.SetActive(true);
        effect3.gameObject.SetActive(true);

        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);
        effect2.gameObject.SetActive(false);
        effect3.gameObject.SetActive(false);
        effectstate = EffectState.Null;

    }
    IEnumerator Good()
    {
        Debug.Log("Good");

        GameObject effect1 = Instantiate(GreatEffect);
        GameObject effect2 = Instantiate(GreatBack);
        GameObject effect3 = Instantiate(GoodText);

        effect1.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect2.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);
        effect3.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);

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

        effect1.transform.position = new Vector3(laneArray[effectNum].transform.position.x, judgeLane.transform.position.y, judgeLane.transform.position.z);

        effect1.gameObject.SetActive(true);//生成時にオブジェクトが非アクティブ状態なのでアクティブにする

        yield return new WaitForSeconds(effecttimer);
        effect1.gameObject.SetActive(false);

        effectstate = EffectState.Null;
    }
}
