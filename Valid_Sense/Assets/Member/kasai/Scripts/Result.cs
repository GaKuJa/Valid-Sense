using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Result : MonoBehaviour
{
    PlayerLanesAndTimings playerresult = new PlayerLanesAndTimings();

    public GameObject BrilantResult = null;
    public GameObject GreatResult = null;
    public GameObject GoodResult = null;
    public GameObject PoorResult = null;

    private int _brilliantCount = 0;
    private int _greatCount = 0;
    private int _goodCount = 0;
    private int _poorCount = 0;

    Text BriliantText;
    Text GreatText;
    Text GoodText;
    Text PoorText;
    private void Start()
    {
        playerresult = GetComponent<PlayerLanesAndTimings>();

        BriliantText = BrilantResult.GetComponent<Text>();
        GreatText = GreatResult.GetComponent<Text>();
        GoodText = GoodResult.GetComponent<Text>();
        PoorText = PoorResult.GetComponent<Text>();
        _brilliantCount = playerresult.brilliants;
        _greatCount = playerresult.greats;
        _goodCount = playerresult.goods;
        _poorCount = playerresult.poors;

    }

    // Update is called once per frame
    void Update()
    {
        BriliantText.text = "Briliant:" + _brilliantCount;
        GreatText.text = "Great:" + _greatCount;
        GoodText.text = "Good:" + _goodCount;
        PoorText.text = "Poor:" + _poorCount;

    }
}
