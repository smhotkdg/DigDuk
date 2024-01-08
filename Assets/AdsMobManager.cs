using System;
using UnityEngine;
using GoogleMobileAds.Api;

using UnityEngine.UI;

public class AdsMobManager : MonoBehaviour
{
    public RewardBasedVideoAd rewardBasedVideo;
    public Text text;
    GlobalVariable gv;
    public GameObject AdsManager;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    public void Start()
    {
#if UNITY_ANDROID
        string appId = "ca-app-pub-7939215518934371~9459958483";
#elif UNITY_IPHONE
        string appId = "ca-app-pub-3940256099942544~1458002511";
#else
        string appId = "unexpected_platform";
#endif

        //Get singleton reward based video ad reference.
        this.rewardBasedVideo = RewardBasedVideoAd.Instance;

        // Called when an ad request has successfully loaded.
        rewardBasedVideo.OnAdLoaded += HandleRewardBasedVideoLoaded;
        // Called when an ad request failed to load.
        rewardBasedVideo.OnAdFailedToLoad += HandleRewardBasedVideoFailedToLoad;
        // Called when an ad is shown.
        rewardBasedVideo.OnAdOpening += HandleRewardBasedVideoOpened;
        // Called when the ad starts to play.
        rewardBasedVideo.OnAdStarted += HandleRewardBasedVideoStarted;
        // Called when the user should be rewarded for watching a video.
        rewardBasedVideo.OnAdRewarded += HandleRewardBasedVideoRewarded;
        // Called when the ad is closed.
        rewardBasedVideo.OnAdClosed += HandleRewardBasedVideoClosed;
        // Called when the ad click caused the user to leave the application.
        rewardBasedVideo.OnAdLeavingApplication += HandleRewardBasedVideoLeftApplication;


        MobileAds.Initialize(appId);

        this.RequestRewardBasedVideo();
    }

    private void RequestRewardBasedVideo()
    {

#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-7939215518934371/8863564247";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-7939215518934371/8863564247";
#else
            string adUnitId = "unexpected_platform";
#endif

        // Create an empty ad request.
        //AdRequest request = new AdRequest.Builder().Build();
        AdRequest request = new AdRequest.Builder()
        .AddExtra("max_ad_content_rating", "G")
        .Build();
        //AdRequest request = new AdRequest.Builder()
        //.AddTestDevice(AdRequest.TestDeviceSimulator)       // Simulator.
        //.AddTestDevice("F488328D103C39348754DA2BF78354D5")  // My test device.
        //.Build();

        // Load the rewarded video ad with the request.
        this.rewardBasedVideo.LoadAd(request, adUnitId);
    }
    public void LoadAd()
    {
        RequestRewardBasedVideo();
    }
    public void HandleRewardBasedVideoLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLoaded event received");
    }

    public void HandleRewardBasedVideoFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardBasedVideoFailedToLoad event received with message: "
                             + args.Message);
    }

    public void HandleRewardBasedVideoOpened(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoOpened event received");
    }

    public void HandleRewardBasedVideoStarted(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoStarted event received");
    }

    public void HandleRewardBasedVideoClosed(object sender, EventArgs args)
    {
        //MonoBehaviour.print("HandleRewardBasedVideoClosed event received");
        this.RequestRewardBasedVideo();
    }

    public void HandleRewardBasedVideoRewarded(object sender, Reward args)
    {
        //Debug.Log("Reward !! ");
        this.RequestRewardBasedVideo();
        //1 DrillBuff
        //2 SaleBuff
        //3 10 Blackcoin
        //4 LimitGame
        //5 SadariMoney
        //105 광고보고 제작 시간 단축
        //9988 AdsBox
        if (gv.AdsType == 9988)
        {
            //AdsBox
            switch (gv.iSelectAdsBox)
            {
                case 0:
                    gv.strGetSomething = "Miner5";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    break;
                case 1:
                    gv.strGetSomething = "AutoSell";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 2);
                    gv.AutoSellPotionTotalCount += 2;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    gv.strGetSomething = "DrillPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.DrillPotionTotalCount += 1;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 3:
                    gv.strGetSomething = "Gold";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, gv.GetMoneyPos() * 2.5f);
                    gv.Money += gv.GetMoneyPos() * 2.5f;
                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 10);
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    SIS.DBManager.IncreaseFunds("blackcoin", 10);
                    break;
                case 5:
                    gv.strGetSomething = "HoitStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 3);
                    if (gv.strGetSomething == "HoitStone")
                    {
                        gv.HoitStoneCount += 3;
                        PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                        PlayerPrefs.Save();
                    }
                    break;
                case 6:
                    if (gv.MapType == 1)
                    {
                        gv.DynamiteAdsCount++;
                        PlayerPrefs.SetInt("DynamiteAdsCount", gv.DynamiteAdsCount);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 2)
                    {
                        gv.DynamiteAdsCountDesert++;
                        PlayerPrefs.SetInt("DynamiteAdsCountDesert", gv.DynamiteAdsCountDesert);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 3)
                    {
                        gv.DynamiteAdsCountIce++;
                        PlayerPrefs.SetInt("DynamiteAdsCountIce", gv.DynamiteAdsCountIce);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 4)
                    {
                        gv.DynamiteAdsCountForest++;
                        PlayerPrefs.SetInt("DynamiteAdsCountForest", gv.DynamiteAdsCountForest);
                        PlayerPrefs.Save();
                    }
                    break;
            }
        }
        if (gv.AdsType == 105)
        {
            if (gv.MapType == 1)
            {
                gv.CraftAdsCoolTimeCount = 1;
                gv.CrafttAdsCount++;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountTime", 300);
                PlayerPrefs.SetInt("CraftAdsCoolTimeCount", gv.CraftAdsCoolTimeCount);
                PlayerPrefs.SetInt("CrafttAdsCount", gv.CrafttAdsCount);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 2)
            {
                gv.CraftAdsCoolTimeCountDesert = 1;
                gv.CrafttAdsCountDesert++;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountDesertTime", 300);
                PlayerPrefs.SetInt("CraftAdsCoolTimeCountDesert", gv.CraftAdsCoolTimeCountDesert);
                PlayerPrefs.SetInt("CrafttAdsCountDesert", gv.CrafttAdsCountDesert);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 3)
            {
                gv.CraftAdsCoolTimeCountIce = 1;
                gv.CrafttAdsCountIce++;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountIceTime", 300);
                PlayerPrefs.SetInt("CraftAdsCoolTimeCountIce", gv.CraftAdsCoolTimeCountIce);
                PlayerPrefs.SetInt("CrafttAdsCountIce", gv.CrafttAdsCountIce);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 4)
            {
                gv.CraftAdsCoolTimeCountForest = 1;
                gv.CrafttAdsCountForest++;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountForestTime", 300);
                PlayerPrefs.SetInt("CraftAdsCoolTimeCountForest", gv.CraftAdsCoolTimeCountForest);
                PlayerPrefs.SetInt("CrafttAdsCountForest", gv.CrafttAdsCountForest);
                PlayerPrefs.Save();
            }
        }
        if (gv.AdsType == 99)
        {
            gv.AutoSellPotionTotalCount++;
            PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
            PlayerPrefs.Save();
            if (GameObject.Find("InventoryCanvas") != null)
                GameObject.Find("InventoryCanvas").GetComponent<InventoryUIManager>().CheckInitData();
            gv.strGetSomething = "AutoSell";
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);

        }
        if (gv.AdsType == 1)
        {
            AdsManager.GetComponent<AdManager>().SetDrillBuff();
        }
        if (gv.AdsType == 2)
        {
            AdsManager.GetComponent<AdManager>().SetSaleBuff();
        }
        if (gv.AdsType == 3)
        {
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", 10);
        }
        if (gv.AdsType == 4)
        {
            GameObject.Find("MainCanvas").GetComponent<AdsUIManager>().ResetMiniGameByAds();
        }
        if (gv.AdsType == 5)
        {
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().RestoreMoneybyAds();
        }
        if (gv.AdsType == 45)
        {
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().RestoreMoneybyAdsRandom();
        }
        if (gv.AdsType == 6)
        {
            float rewardPower = 0;
            if (gv.ReTimePower == 0)
            {
                rewardPower = 1;
            }
            else
            {
                rewardPower = gv.ReTimePower;
            }
            gv.HoitStoneCount += gv.rewardHoitStone;
            PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
            gv.Money += (gv.rewardMoney * 2 * rewardPower);
            if (gv.MapType == 1)
            {
                gv.ExpNow += (gv.rewardExp * 2 * rewardPower);
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
            }
            if (gv.MapType == 2)
            {
                gv.ExpNowDesert += (gv.rewardExp * 2 * rewardPower);
                PlayerPrefs.SetFloat("ExpNowDesert", (float)gv.ExpNowDesert);
            }
            if (gv.MapType == 3)
            {
                gv.ExpNowIce += (gv.rewardExp * 2 * rewardPower);
                PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
            }
            if (gv.MapType == 4)
            {
                gv.ExpNowForest += (gv.rewardExp * 2 * rewardPower);
                PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
            }
            gv.rewardExp = 0;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
            gv.rewardMoney = 0;
        }

        if (gv.AdsType == 565)
        {
            gv.TotalAdsRandomMiner1++;
            PlayerPrefs.SetInt("TotalBuyRandomMiner1", gv.TotalBuyRandomMiner1);

            gv.strGetSomething = "Miner1";
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
            if (GameObject.Find("ShopCanvas").activeSelf == true)
            {
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().AdsRandmomSet();
            }
        }

        gv.AdsType = -1;

        gv.AdsTotalCount++;
        string strUpgradeTotalCount = "AdsTotal";
        PlayerPrefs.SetInt(strUpgradeTotalCount, gv.AdsTotalCount);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckWatchAdsQuest());
        //text.text = "리워드 성공";
    }

    public void HandleRewardBasedVideoLeftApplication(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardBasedVideoLeftApplication event received");
    }
}
