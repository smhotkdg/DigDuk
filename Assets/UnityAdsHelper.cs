using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.UI;
public class UnityAdsHelper : MonoBehaviour
{
    GlobalVariable gv;
    private const string android_game_id = "2900113";
    private const string ios_game_id = "2900111";

    private const string rewarded_video_id = "rewardedVideo";
    public Text _Text;
    public GameObject AdsManager;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {
        Initialize();
    }

    private void Initialize()
    {
#if UNITY_ANDROID
        Advertisement.Initialize(android_game_id);
#elif UNITY_IOS
        Advertisement.Initialize(ios_game_id);
#endif
    }

    public void ShowRewardedAd()
    {
        if (Advertisement.IsReady(rewarded_video_id))
        {
            var options = new ShowOptions { resultCallback = HandleShowResult };

            Advertisement.Show(rewarded_video_id, options);
        }
    }

    private void HandleShowResult(ShowResult result)
    {
        switch (result)
        {
            case ShowResult.Finished:
                {
                    Debug.Log("The ad was successfully shown.");

                    // to do ...
                    // 광고 시청이 완료되었을 때 처리
                    _Text.text = "Unity Ad 완료";
                    //1 DrillBuff
                    //2 SaleBuff
                    //3 10 Blackcoin                 
                    //4 LimitGame
                    //5 SadariMoney
                    //9988 AdsBox
                    if(gv.AdsType ==9988)
                    {
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

                                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, cost);
                                gv.Money += cost;
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
                    if (gv.AdsType ==99)
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
                    if(gv.AdsType ==5)
                    {
                        GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().RestoreMoneybyAds();                        
                    }
                    if(gv.AdsType ==45)
                    {
                        GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().RestoreMoneybyAdsRandom();
                    }
                    if(gv.AdsType ==6)
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

                        gv.Money += (gv.rewardMoney*2 * rewardPower);
                        gv.HoitStoneCount += gv.rewardHoitStone;
                        PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                        if (gv.MapType ==1)
                        {
                            gv.ExpNow += (gv.rewardExp*2 * rewardPower);
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
                    gv.AdsTotalCount++;
                    string strUpgradeTotalCount = "AdsTotal";
                    PlayerPrefs.SetInt(strUpgradeTotalCount, gv.AdsTotalCount);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckWatchAdsQuest());
                    gv.AdsType = -1;
                    break;
                }
            case ShowResult.Skipped:
                {
                    Debug.Log("The ad was skipped before reaching the end.");

                    // to do ...
                    // 광고가 스킵되었을 때 처리

                    break;
                }
            case ShowResult.Failed:
                {
                    Debug.LogError("The ad failed to be shown.");

                    // to do ...
                    // 광고 시청에 실패했을 때 처리

                    break;
                }
        }
    }
}
