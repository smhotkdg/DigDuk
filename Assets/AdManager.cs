using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusObj;
    public GameObject MainCamara;
    int index = 0;
    public Text _text;
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;

        if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isDailyAdsCountTime", 86400) ==2)
        {
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isDailyAdsCountTime", 86400);
        }
    }
    void Start() {
        MainCamara.GetComponent<AdsMobManager>().LoadAd();

        if (MainCamara.GetComponent<AdsMobManager>().rewardBasedVideo.IsLoaded())
        {

        }
        else
        {
            StartCoroutine(LoadAd());
            //MainCamara.GetComponent<UnityAdsHelper>().ShowRewardedAd();
        }
    }


    // Update is called once per frame
    private void FixedUpdate()
    {
        if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isDailyAdsCountTime", 86400) ==-1 && gv.iAdsDailyCount >=0)
        {
            gv.iAdsDailyCount = 0;
            PlayerPrefs.SetInt("iAdsDailyCount", gv.iAdsDailyCount);
            PlayerPrefs.Save();
        }
    }
    void Update() {

    }
    public void SetDrillBuff()
    {
        //+7200
        if(gv.MapType ==1)
        {
            gv.DrillBuffCount += 1;
            PlayerPrefs.SetInt("DrillBuffCount", gv.DrillBuffCount);
            PlayerPrefs.Save();
            int drilltime = (gv.DrillBuffCount - 1) * gv.iAdDrillBuffTime;
            if (gv.DrillBuffCount == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillBuffTime", gv.iAdDrillBuffTime);
        
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTime", gv.iAdDrillBuffTime + drilltime);
            }
        }

        if (gv.MapType == 2)
        {
            gv.DrillBuffCountDesert += 1;
            PlayerPrefs.SetInt("DrillBuffCountDesert", gv.DrillBuffCountDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.DrillBuffCountDesert - 1) * gv.iAdDrillBuffTime;
            if (gv.DrillBuffCountDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillBuffTimeDesert", gv.iAdDrillBuffTime); 
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeDesert", gv.iAdDrillBuffTime + drilltime);
            }
        }

        if (gv.MapType == 3)
        {
            gv.DrillBuffCountIce += 1;
            PlayerPrefs.SetInt("DrillBuffCountIce", gv.DrillBuffCountIce);
            PlayerPrefs.Save();
            int drilltime = (gv.DrillBuffCountIce - 1) * gv.iAdDrillBuffTime;
            if (gv.DrillBuffCountIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillBuffTimeIce", gv.iAdDrillBuffTime);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeIce", gv.iAdDrillBuffTime + drilltime);
            }
        }

        if (gv.MapType == 4)
        {
            gv.DrillBuffCountForest += 1;
            PlayerPrefs.SetInt("DrillBuffCountForest", gv.DrillBuffCountForest);
            PlayerPrefs.Save();
            int drilltime = (gv.DrillBuffCount - 1) * gv.iAdDrillBuffTime;
            if (gv.DrillBuffCountForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillBuffTimeForest", gv.iAdDrillBuffTime);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeForest", gv.iAdDrillBuffTime + drilltime);
            }
        }



    }

    public void SetSaleBuff()
    {
        //+7200
        if(gv.MapType ==1)
        {
            gv.SaleBuffCount += 1;
            PlayerPrefs.SetInt("SaleBuffCount", gv.SaleBuffCount);
            PlayerPrefs.Save();
            int saleTime = (gv.SaleBuffCount - 1) * gv.iAdSaleBuffTime;            
            if (gv.SaleBuffCount == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SaleBuffTime", gv.iAdSaleBuffTime);                
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTime", gv.iAdSaleBuffTime + saleTime);                
            }
        }

        if (gv.MapType == 2)
        {
            gv.SaleBuffCountDesert += 1;
            PlayerPrefs.SetInt("SaleBuffCountDesert", gv.SaleBuffCountDesert);
            PlayerPrefs.Save();
            int saleTime = (gv.SaleBuffCountDesert - 1) * gv.iAdSaleBuffTime;
            if (gv.SaleBuffCountDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SaleBuffTimeDesert", gv.iAdSaleBuffTime);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeDesert", gv.iAdSaleBuffTime + saleTime);
            }
        }

        if (gv.MapType == 3)
        {
            gv.SaleBuffCountIce += 1;
            PlayerPrefs.SetInt("SaleBuffCountIce", gv.SaleBuffCountIce);
            PlayerPrefs.Save();
            int saleTime = (gv.SaleBuffCountIce - 1) * gv.iAdSaleBuffTime;
            if (gv.SaleBuffCountIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SaleBuffTimeIce", gv.iAdSaleBuffTime);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeIce", gv.iAdSaleBuffTime + saleTime);
            }
        }

        if (gv.MapType == 4)
        {
            gv.SaleBuffCountForest += 1;
            PlayerPrefs.SetInt("SaleBuffCountForest", gv.SaleBuffCountForest);
            PlayerPrefs.Save();
            int saleTime = (gv.SaleBuffCountForest - 1) * gv.iAdSaleBuffTime;
            if (gv.SaleBuffCountForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SaleBuffTimeForest", gv.iAdSaleBuffTime);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeForest", gv.iAdSaleBuffTime + saleTime);
            }
        }

    }


    public void CheckDailyTime()
    {
        //86400 50
        if(gv.iAdsDailyCount >=50)
        {
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isDailyAdsCountTime", 86400);
        }
    }
    public void ShowReward(int number)
    {
        //1 DrillBuff
        //2 SaleBuff
        //3 10 Blackcoin
        //45 randomMoney
        //105 광고 보고 제작 시간 단축
        //9988 AdsBox
        //565 Ads Miner

        //test 용
        //gv.AdsType = number;
        //MainCamara.GetComponent<UnityAdsHelper>().ShowRewardedAd();

        //실제

        if (gv.iAdsDailyCount < 50)
        {
            gv.AdsType = number;
            //if (gv.iAdsDailyCount %2 ==1)
            //{
            //    MainCamara.GetComponent<UnityAdsHelper>().ShowRewardedAd();
            //    gv.iAdsDailyCount++;
            //    PlayerPrefs.SetInt("iAdsDailyCount", gv.iAdsDailyCount);
            //    PlayerPrefs.Save();
            //    if (gv.AdsType == 9988)
            //    {
            //        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressAdsBoxCanavsObj(0);
            //    }
            //    CheckDailyTime();
            //}
            if(MainCamara.GetComponent<AdsMobManager>().rewardBasedVideo.IsLoaded())
            {
                MainCamara.GetComponent<AdsMobManager>().rewardBasedVideo.Show();
                gv.iAdsDailyCount++;
                PlayerPrefs.SetInt("iAdsDailyCount", gv.iAdsDailyCount);
                PlayerPrefs.Save();
                CheckDailyTime();
                if (gv.AdsType == 9988)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressAdsBoxCanavsObj(0);
                }
            }
            else
            {
                StartCoroutine(LoadAd());
                MainCamara.GetComponent<UnityAdsHelper>().ShowRewardedAd();
                gv.iAdsDailyCount++;
                PlayerPrefs.SetInt("iAdsDailyCount", gv.iAdsDailyCount);
                PlayerPrefs.Save();
                CheckDailyTime();
                if (gv.AdsType == 9988)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressAdsBoxCanavsObj(0);
                }
            }
            index++;
        }
        else
        {
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetTimerString("isDailyAdsCountTime", 86400) != string.Empty)
            {
                string temp = GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetTimerString("isDailyAdsCountTime", 86400);
                string notifistr = "일일 광고 초과\n" + temp + " 후 초기화";
                MainStatusObj.GetComponent<StatusUpdate>().SetNotification(notifistr);
            }

        }

    }
    IEnumerator LoadAd()
    {
        MainCamara.GetComponent<AdsMobManager>().LoadAd();
        yield return new WaitForSeconds(30);
        if (MainCamara.GetComponent<AdsMobManager>().rewardBasedVideo.IsLoaded() == false)
        {
            StartCoroutine(LoadAd());
        }
    }
}

