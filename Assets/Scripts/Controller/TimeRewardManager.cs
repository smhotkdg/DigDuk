using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeRewardManager : MonoBehaviour {

    GlobalVariable gv;
    // Use this for initialization
    public Text TextRewardMoney;
    public Text TextRewardDepth;
    public Text RewardTimeText;
    public Text HoitStoneText;

    public GameObject MiningAlgorithm;
    MiningAlgorithm myMining;
    bool bStartApp = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    public void SetPreData(int preMap)
    {
        if (preMap == 1)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardTime");
        }
        if (preMap == 2)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardDesertTime");
        }
        if (preMap == 3)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardIceTime");
        }
        if (preMap == 4)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardForestTime");
        }
    }
    void Start() {
        myMining = MiningAlgorithm.GetComponent<MiningAlgorithm>();
        string timerKeyStr = "";
        if (gv.MapType ==1)
            timerKeyStr = "RewardTime";
        if (gv.MapType == 2)
            timerKeyStr = "RewardDesertTime";
        if (gv.MapType == 3)
            timerKeyStr = "RewardIceTime";
        if (gv.MapType == 4)
            timerKeyStr = "RewardForestTime";

        string startTimeStr = PlayerPrefs.GetString(timerKeyStr);
        if (string.IsNullOrEmpty(startTimeStr) == true)
        {
            //_txt.text = "미접속 수익 없음";
        }
        else
        {
            System.DateTime start = System.DateTime.Parse(startTimeStr);
            System.DateTime now = System.DateTime.Now;

            System.TimeSpan AAA = now - start;
            int times = (int)AAA.TotalSeconds;
            //time 이 몇초 이상이면 미접속 수익 주자 ->
            //
            //SetTextTime(times, _text);
            //if(times >600)
            if (times > 60)
            {
                CheckReward(times);
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressRewardView(1);
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTimeKor(times, RewardTimeText);
                
            }
                
        }
    }   
    public void ChangeMap()
    {
     
        
    }
    public void CheckTimeManager()
    {
        string timerKeyStr = "";
        if (gv.MapType == 1)
            timerKeyStr = "RewardTime";
        if (gv.MapType == 2)
            timerKeyStr = "RewardDesertTime";
        if (gv.MapType == 3)
            timerKeyStr = "RewardIceTime";
        if (gv.MapType == 4)
            timerKeyStr = "RewardForestTime";

        string startTimeStr = PlayerPrefs.GetString(timerKeyStr);
        if (string.IsNullOrEmpty(startTimeStr) == true)
        {
            //_txt.text = "미접속 수익 없음";
        }
        else
        {
            System.DateTime start = System.DateTime.Parse(startTimeStr);
            System.DateTime now = System.DateTime.Now;

            System.TimeSpan AAA = now - start;
            int times = (int)AAA.TotalSeconds;
            //time 이 몇초 이상이면 미접속 수익 주자 ->
            //
            //SetTextTime(times, _text);
            //if (times > 600)
            if (times > 60)
            {
                CheckReward(times);
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressRewardView(1);
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTimeKor(times, RewardTimeText);

            }

        }
    }
    void CheckReward(int times)
    {
        //최대 57600
        //맵별로 체크 
        if(gv.MapType ==1)
        {
            CheckMiner(gv.ListHireCount, times, TextRewardMoney);
            CheckDepth(gv.EngineNormalLv, gv.BitNormalLv,gv.Depth,gv.ExpNow, TextRewardDepth, times);

        }
        if (gv.MapType == 2)
        {
            CheckMiner(gv.ListHireDesertCount, times, TextRewardMoney);
            CheckDepth(gv.EngineDesertLv, gv.BitDesertLv, gv.DesertDepth, gv.ExpNowDesert, TextRewardDepth, times);
        }
        if (gv.MapType == 3)
        {
            CheckMiner(gv.ListHireIceCount, times, TextRewardMoney);
            CheckDepth(gv.EngineIceLv, gv.BitIceLv, gv.IceDepth, gv.ExpNowIce, TextRewardDepth, times);
        }
        if (gv.MapType == 4)
        {
            CheckMiner(gv.ListHireForestCount, times, TextRewardMoney);
            CheckDepth(gv.EngineForestLv, gv.BitLv,gv.ForestDepth, gv.ExpNowForest, TextRewardDepth, times);
        }
    }
    double rewardExp = 0;
    double CheckDepth(int enginelv, int bitlv, int depth, double exp,Text input,int time)
    {
        rewardExp = 0;
        rewardExp += (gv.ListBitPower[enginelv]);
        rewardExp += (gv.ListEnginePower[bitlv]);


        //최대 57600
        if (time > 57600)
        {
            rewardExp += (rewardExp * 57600) /10;
        }
        else
        {
            rewardExp += (time * rewardExp) /10;
        }

        //exp += rewardExp;
        gv.rewardExp = rewardExp;

        if (((float)rewardExp / (float)gv.DepthExp[depth]) < 1)
        {            
            input.text ="+ "+ ((float)rewardExp / (float)gv.DepthExp[depth] * 100).ToString("N2") + " %";            
        }
        else
        {
            input.text = "+ 100%";
        }

   
        return 0.0f;
    }
    double rewardMoney;
    double CheckMiner(List<int> minerList,int time,Text TextRewardMoney)
    {
        rewardMoney = 0;
        int iMineralIndex = 0;
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

        int hoitstoneCount = 0;
        for (int i=0; i< minerList.Count; i++)
        {
            if(minerList[i] <0)
            {
                iMineralIndex = myMining.GetMinersIndex();
                int Rand = gv.ListMiningMax[i];
                if(gv.SaleBuffPower >0)
                {
                    rewardMoney += (Rand * gv.ListCostMinerals[iMineralIndex] * weight) * gv.SaleBuffPower;
                }
                else
                {
                    rewardMoney += (Rand * gv.ListCostMinerals[iMineralIndex] * weight);
                }
                
                float range = 1000;
                if (gv.HoitStoneBuffPercent > 0)
                {
                    range = 1000 - (range * gv.HoitStoneBuffPercent);
                }
                int randomHoitStone = Random.Range(0, 1000);
                if (randomHoitStone <= 5)
                {
                    //get HoitStone                    
                    if (gv.HoitStoneBuffPower > 0)
                    {
                        gv.HoitStoneCount += (int)gv.HoitStoneBuffPower;
                    }
                    else
                    {
                        gv.HoitStoneCount++;
                    }
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    hoitstoneCount++;
                }
            }
        }
        
        //최대 57600
        if (time > 57600)
        {
            if(gv.DrillBuffPower >0)
            {
                rewardMoney += ((rewardMoney * (57600 / 10)) / 10) * gv.DrillBuffPower;
            }
            else
            {
                rewardMoney += ((rewardMoney * (57600 / 10)) / 10) ;
            }
            
        }
        else
        {
            if(gv.DrillBuffPower >0)
            {
                rewardMoney += (((time / 10) * rewardMoney) / 10) * gv.DrillBuffPower;
            }
            else
            {
                rewardMoney += (((time / 10) * rewardMoney) / 10);
            }
        }
        TextRewardMoney.text = gv.ChangeMoney(rewardMoney);        
        gv.rewardHoitStone = hoitstoneCount;
        gv.rewardMoney = rewardMoney;
        HoitStoneText.text = hoitstoneCount.ToString();
             
        return rewardMoney;
    }
    public void PressReward()
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

        gv.Money += (gv.rewardMoney * rewardPower);
        PlayerPrefs.SetFloat("Money", (float)gv.Money);
        PlayerPrefs.Save();
        gv.rewardMoney = 0;

      
        if(gv.MapType ==1)
        {
            gv.ExpNow += (gv.rewardExp * rewardPower);
            PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.ExpNowDesert += (gv.rewardExp * rewardPower);
            PlayerPrefs.SetFloat("ExpNowDesert", (float)gv.ExpNowDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.ExpNowIce += (gv.rewardExp * rewardPower);
            PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.ExpNowForest += (gv.rewardExp * rewardPower);
            PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
            PlayerPrefs.Save();
        }
        gv.rewardExp = 0;
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressRewardView(0);
    }
    public void PressRewardDouble()
    {     

        GameObject.Find("Main Camera").GetComponent<AdManager>().ShowReward(6);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressRewardView(0);
    }

    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(gv.bUpgrade ==false)
            {
                if (gv.listPanelPopupDic.Count > 0)
                {
                    GameObject temp = gv.listPanelPopupDic[gv.listPanelPopupDic.Count - 1].GetObj();
                    if (gv.listPanelPopupDic[gv.listPanelPopupDic.Count - 1].GetName() == "QuestPopup")
                    {
                        GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(0);
                    }
                    else if (gv.listPanelPopupDic[gv.listPanelPopupDic.Count - 1].GetName() == "NoticeUpgradeObj")
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                    }
                    if (gv.listPanelPopupDic[gv.listPanelPopupDic.Count - 1].GetName() == "KingMineralsGamePanel" && gv.isKingGameStart ==1)
                    {
                        GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralsGameSrc>().PressPause();
                        return;
                    }
                    if (gv.listPanelPopupDic[gv.listPanelPopupDic.Count - 1].GetName() == "PauseObj")
                    {
                        GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralsGameSrc>().ReStartGame();
                        return;
                    }
                    else
                    {                        
                        temp.SetActive(false);
                        gv.listPanelPopupDic.RemoveAt(gv.listPanelPopupDic.Count - 1);
                    }
                }
                else if (gv.listPanelDic.Count > 0)
                {
                    GameObject temp = gv.listPanelDic[gv.listPanelDic.Count - 1].GetObj();
                    if (gv.listPanelDic[gv.listPanelDic.Count - 1].GetName() == "HireShopCanvas")
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHireShop(0);
                    }
                    else
                    {
                        temp.SetActive(false);
                        gv.listPanelDic.RemoveAt(gv.listPanelDic.Count - 1);
                    }
                }
                else if (gv.bGetKeydwon == false)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupQuitApp(1);
                    gv.bGetKeydwon = true;
                }
                else if (gv.bGetKeydwon == true)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupQuitApp(0);
                    gv.bGetKeydwon = false;
                }

                if (gv.listPanelDic.Count == 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().InitView();
                }
            }          
        }
    }
    private void OnApplicationPause(bool pause)
    {
        if(pause ==true)
        {
            AddRewardTime();
            bStartApp = true;
        }
        if(pause == false)
        {
            if(bStartApp ==true)
            {                
                CheckTimeManager();
                bStartApp = false;
            }
        }
    }
    private void OnDestroy()
    {
        AddRewardTime(); 
    }

    public void AddRewardTime()
    {
        if(gv.MapType ==1)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardTime");
        }
        if (gv.MapType == 2)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardDesertTime");
        }
        if (gv.MapType == 3)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardIceTime");
        }
        if (gv.MapType == 4)
        {
            System.DateTime OldTRime = System.DateTime.Now;
            Add("RewardForestTime");
        }
    }
    public void EndApp()
    {
        AddRewardTime();
        Application.Quit();
    }

    public static void Add(string key)
    {
        string timerKeyStr = key;
        string now = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");
        PlayerPrefs.SetString(timerKeyStr, now);
        PlayerPrefs.Save();
    }
}
