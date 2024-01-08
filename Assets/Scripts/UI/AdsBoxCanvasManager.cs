using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdsBoxCanvasManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Dynamite;
    public GameObject Card1;
    public GameObject AutoSell;
    public GameObject DrillPotion;
    public GameObject Coin;
    public GameObject BlackCoin;
    public GameObject HoitStone;
    
    public Text AdsText;
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    private void OnEnable()
    {
        SetView();
    }
    public void SetView()
    {
        //번역
        switch (gv.iSelectAdsBox)
        {
            case 0:
                Card1.SetActive(true);
                AdsText.text = "랜덤광부 5장";
                break;
            case 1:
                AutoSell.SetActive(true);
                AdsText.text = "자동판매 포션 2개";
                break;
            case 2:
                DrillPotion.SetActive(true);
                AdsText.text = "드릴버프 포션 1개";
                break;
            case 3:
                Coin.SetActive(true);

                int depth = 0;
                float weight = 1;
                if (gv.MapType == 1)
                {
                    depth = gv.Depth;
                }
                if (gv.MapType == 2)
                {
                    depth = gv.DesertDepth;

                    weight = 5;
                }
                if (gv.MapType == 3)
                {
                    depth = gv.IceDepth;
                    weight = 10;
                }
                if (gv.MapType == 4)
                {
                    depth = gv.ForestDepth;
                    weight = 100;
                }
                float cost = (float)gv.ListCostMinerals[depth - 1] * weight * 1000;     
                string str_money =gv.ChangeMoney(cost);
                AdsText.text = str_money;
                break;
            case 4:
                BlackCoin.SetActive(true);
                AdsText.text = "블랙코인 10개";
                break;
            case 5:
                HoitStone.SetActive(true);
                AdsText.text = "호잇스톤 3개";
                break;
            case 6:
                Dynamite.SetActive(true);
                //남은시간이 30분 이하면 즉시 
                //30분 이상이면 30분 감소
                int nowDepth = 0;
                if (gv.MapType == 1)
                {
                    int decreaseTime = (1800 * gv.DynamiteAdsCount);
                    nowDepth = gv.Depth;
                    int time = 0;
                    if (nowDepth % 10 == 0)
                    {
                        if (gv.dynamiteReTime == 0)
                        {
                            time = 90 + ((nowDepth - 4) * 600);
                        }
                        else
                        {
                            time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                        }
                    }
                    double retime = GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("StartTimeDepth", time - decreaseTime);
                    if(retime <1800)
                    {
                        AdsText.text = "다이너마이트 시간\n즉시 완료";
                    }
                    else
                    {
                        AdsText.text = "다이너마이트 시간\n30분 감소 완료";
                    }
                }
                if (gv.MapType == 2)
                {
                    int decreaseTime = (1800 * gv.DynamiteAdsCountDesert);
                    nowDepth = gv.DesertDepth;
                    int time = 0;
                    if (nowDepth % 10 == 0)
                    {
                        if (gv.dynamiteReTime == 0)
                        {
                            time = 90 + ((nowDepth - 4) * 600);
                        }
                        else
                        {
                            time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                        }
                    }
                    double retime = GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthDesert", time- decreaseTime);
                    if (retime < 1800)
                    {
                        AdsText.text = "다이너마이트 시간\n즉시 완료";
                    }
                    else
                    {
                        AdsText.text = "다이너마이트 시간\n30분 감소 완료";
                    }
                }
                if (gv.MapType == 3)
                {
                    int decreaseTime = (1800 * gv.DynamiteAdsCountIce);
                    nowDepth = gv.IceDepth;
                    int time = 0;
                    if (nowDepth % 10 == 0)
                    {
                        if (gv.dynamiteReTime == 0)
                        {
                            time = 90 + ((nowDepth - 4) * 600);
                        }
                        else
                        {
                            time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                        }
                    }
                    double retime = GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthIce", time- decreaseTime);
                    if (retime < 1800)
                    {
                        AdsText.text = "다이너마이트 시간\n즉시 완료";
                    }
                    else
                    {
                        AdsText.text = "다이너마이트 시간\n30분 감소 완료";
                    }
                }
                if (gv.MapType == 4)
                {
                    int decreaseTime = (1800 * gv.DynamiteAdsCountForest);
                    nowDepth = gv.ForestDepth;
                    int time = 0;
                    if (nowDepth % 10 == 0)
                    {
                        if (gv.dynamiteReTime == 0)
                        {
                            time = 90 + ((nowDepth - 4) * 600);
                        }
                        else
                        {
                            time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                        }
                    }
                    double retime = GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthForest", time- decreaseTime);
                    if (retime < 1800)
                    {
                        AdsText.text = "다이너마이트 시간\n즉시 완료";
                    }
                    else
                    {
                        AdsText.text = "다이너마이트 시간\n30분 감소 완료";
                    }
                }
                break;
        }
    }
    private void OnDisable()
    {
        Card1.SetActive(false);
        AutoSell.SetActive(false);
        DrillPotion.SetActive(false);
        Coin.SetActive(false);
        BlackCoin.SetActive(false);
        HoitStone.SetActive(false);
        Dynamite.SetActive(false);
    }
    void Start()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
