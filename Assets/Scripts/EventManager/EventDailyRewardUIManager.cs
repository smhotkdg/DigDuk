using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventDailyRewardUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject AutoSell;
    public GameObject MinerPotion;
    public GameObject DrillPotion;
    public GameObject BlackCoin;
    public GameObject SaleBuffPotion;
    public GameObject HoitStoen;
    public GameObject Gold;
    public GameObject FreeLvUp;
    public GameObject FreeDepth;


    public Text TimeText;

    public Button BtnGet;
    public int DailyRewardTime;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {
        DailyRewardTime = 3600;
    }
    private void OnEnable()
    {
        TimeText.text = "00:00:00";
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    AutoSell.SetActive(true);
                    if(gv.EventObjectNormal1Status <=4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 1:
                    MinerPotion.SetActive(true);
                    if (gv.EventObjectNormal2Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 2:
                    DrillPotion.SetActive(true);
                    if (gv.EventObjectNormal3Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 1:
                    AutoSell.SetActive(true);
                    if (gv.EventObjectDesert2Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 2:
                    BlackCoin.SetActive(true);
                    if (gv.EventObjectDesert3Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 3:
                    DrillPotion.SetActive(true);
                    if (gv.EventObjectDesert4Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 4:
                    SaleBuffPotion.SetActive(true);
                    if (gv.EventObjectDesert5Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    AutoSell.SetActive(true);
                    if (gv.EventObjectIce1Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 1:
                    DrillPotion.SetActive(true);
                    if (gv.EventObjectIce2Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 2:
                    SaleBuffPotion.SetActive(true);
                    if (gv.EventObjectIce3Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 3:
                    HoitStoen.SetActive(true);
                    if (gv.EventObjectIce4Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 4:
                    Gold.SetActive(true);
                    if (gv.EventObjectIce5Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    FreeLvUp.SetActive(true);
                    if (gv.EventObjectForest1Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    
                    break;
                case 1:                    
                    DrillPotion.SetActive(true);
                    if (gv.EventObjectForest2Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
                case 4:
                    FreeDepth.SetActive(true);
                    if (gv.EventObjectForest5Status <= 4)
                    {
                        BtnGet.interactable = false;
                    }
                    else
                    {
                        BtnGet.interactable = true;
                    }
                    break;
            }
        }
    }
  
    private void OnDisable()
    {
        AutoSell.SetActive(false);
        MinerPotion.SetActive(false);
        DrillPotion.SetActive(false);
        BlackCoin.SetActive(false);
        SaleBuffPotion.SetActive(false);
        HoitStoen.SetActive(false);
        Gold.SetActive(false);
        FreeLvUp.SetActive(false);
        FreeDepth.SetActive(false);
    }
    // Update is called once per frame
    public void GetItem()
    {
        bool eventPanel = false;
        float count = 0;
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);

                    gv.EventObjectNormal1Status = 4;
                    PlayerPrefs.SetInt("EventObjectNormal1Status", gv.EventObjectNormal1Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectNormal1StatusTime", DailyRewardTime);
                    PlayerPrefs.Save();
                    count = 1;
                    gv.strGetSomething = "AutoSell";
                    break;
                case 1:
                    gv.MiningPotionTotalCount++;
                    PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
                    gv.EventObjectNormal2Status = 4;
                    PlayerPrefs.SetInt("EventObjectNormal2Status", gv.EventObjectNormal2Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectNormal2StatusTime", DailyRewardTime);
                    PlayerPrefs.Save();
                    count = 1;
                    gv.strGetSomething = "MiningPotion";
                    break;
                case 2:                    
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    gv.EventObjectNormal3Status = 4;
                    PlayerPrefs.SetInt("EventObjectNormal3Status", gv.EventObjectNormal3Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectNormal3StatusTime", DailyRewardTime);
                    PlayerPrefs.Save();
                    count = 1;
                    gv.strGetSomething = "DrillPotion";
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 1:
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);

                    gv.EventObjectDesert2Status = 4;
                    PlayerPrefs.SetInt("EventObjectDesert2Status", gv.EventObjectDesert2Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectDesert2StatusTime", DailyRewardTime);

                    PlayerPrefs.Save();
                    count = 1;
                    gv.strGetSomething = "AutoSell";
                    break;
                case 2:
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    SIS.DBManager.IncreaseFunds("blackcoin", 5);
                    count = 5;
                    gv.EventObjectDesert3Status = 4;
                    PlayerPrefs.SetInt("EventObjectDesert3Status", gv.EventObjectDesert3Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectDesert3StatusTime", DailyRewardTime);
                    gv.strGetSomething = "BlackCoin";
                    break;
                case 3:
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    count = 1;
                    gv.EventObjectDesert4Status = 4;
                    PlayerPrefs.SetInt("EventObjectDesert4Status", gv.EventObjectDesert4Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectDesert4StatusTime", DailyRewardTime);
                    gv.strGetSomething = "DrillPotion";
                    PlayerPrefs.Save();
                    break;
                case 4:
                    gv.SalePotionTotalCount++;
                    PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                    count = 1;
                    gv.EventObjectDesert5Status = 4;
                    PlayerPrefs.SetInt("EventObjectDesert5Status", gv.EventObjectDesert5Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectDesert5StatusTime", DailyRewardTime);

                    gv.strGetSomething = "SalePotion";
                    PlayerPrefs.Save();
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    count = 1;
                    gv.EventObjectIce1Status = 4;
                    PlayerPrefs.SetInt("EventObjectIce1Status", gv.EventObjectIce1Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectIce1StatusTime", DailyRewardTime);

                    gv.strGetSomething = "AutoSell";
                    PlayerPrefs.Save();
                    break;
                case 1:
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    count = 1;
                    gv.EventObjectIce2Status = 4;
                    PlayerPrefs.SetInt("EventObjectIce2Status", gv.EventObjectIce2Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectIce2StatusTime", DailyRewardTime);
                    gv.strGetSomething = "DrillPotion";
                    PlayerPrefs.Save();
                    break;
                case 2:
                    gv.SalePotionTotalCount++;
                    PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                    count = 1;
                    gv.EventObjectIce3Status = 4;
                    PlayerPrefs.SetInt("EventObjectIce3Status", gv.EventObjectIce3Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectIce3StatusTime", DailyRewardTime);
                    gv.strGetSomething = "SalePotion";
                    PlayerPrefs.Save();
                    break;
                case 3:
                    gv.HoitStoneCount++;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    count = 1;
                    gv.EventObjectIce4Status = 4;
                    PlayerPrefs.SetInt("EventObjectIce4Status", gv.EventObjectIce4Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectIce4StatusTime", DailyRewardTime);

                    gv.strGetSomething = "HoitStone";
                    PlayerPrefs.Save();
                    break;
                case 4:                    
                    Gold.transform.Find("Count").gameObject.GetComponent<Text>().text = gv.ChangeMoney(gv.GetMoneyPos()/5);
                    gv.Money += gv.GetMoneyPos()/5;
                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    count = gv.GetMoneyPos()/5;
                    gv.EventObjectIce5Status = 4;
                    PlayerPrefs.SetInt("EventObjectIce5Status", gv.EventObjectIce5Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectIce5StatusTime", 86400);

                    gv.strGetSomething = "Gold";
                    PlayerPrefs.Save();
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    //FreeLvUp.SetActive(true);

                    gv.EventObjectForest1Status = 4;
                    PlayerPrefs.SetInt("EventObjectForest1Status", gv.EventObjectForest1Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectForest1StatusTime", 86400);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressFreeLvUPCanvas(1);                    
                    gv.strGetSomething = "LvUp";
                    count = 1;
                    eventPanel = true;
                    break;
                case 1:
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);

                    gv.EventObjectForest2Status = 4;
                    PlayerPrefs.SetInt("EventObjectForest2Status", gv.EventObjectForest2Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectForest2StatusTime", DailyRewardTime);
                    count = 1;
                    gv.strGetSomething = "DrillPotion";
                    PlayerPrefs.Save();
                    break;
                case 4:
                    FreeDepth.SetActive(true);
                    gv.EventObjectForest5Status = 4;
                    PlayerPrefs.SetInt("EventObjectForest5Status", gv.EventObjectForest5Status);
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("EventObjectForest5StatusTime", 86400);
                    PlayerPrefs.Save();
                    int deptIndex = 0;
                    if (gv.MapType == 1)
                    {
                        deptIndex = gv.Depth;
                    }
                    if (gv.MapType == 2)
                    {
                        deptIndex = gv.DesertDepth;
                    }
                    if (gv.MapType == 3)
                    {
                        deptIndex = gv.IceDepth;
                    }
                    if (gv.MapType == 4)
                    {
                        deptIndex = gv.ForestDepth;
                    }
                    //eventPanel = true;
                    gv.ExpNowForest += (gv.DepthExp[deptIndex]*10) / 2;                    
                    PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
                    PlayerPrefs.Save();
                    gv.strGetSomething = "DailyDepth";
                    count = 30;
                    break;
            }
        }

        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().CheckFalse();
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPanelDailyEvent(0);
        if(eventPanel == false)
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1,count);
    }
    void Update()
    {
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectNormal1StatusTime",TimeText, DailyRewardTime) ==-1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectNormal1Status = 5;
                        PlayerPrefs.SetInt("EventObjectNormal1Status", gv.EventObjectNormal1Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }                    
                    
                    break;
                case 1:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectNormal2StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectNormal2Status = 5;
                        PlayerPrefs.SetInt("EventObjectNormal2Status", gv.EventObjectNormal2Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }                    
                    break;
                case 2:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectNormal3StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectNormal3Status =5;
                        PlayerPrefs.SetInt("EventObjectNormal3Status", gv.EventObjectNormal3Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 1:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectDesert2StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectDesert2Status= 5;
                        PlayerPrefs.SetInt("EventObjectDesert2Status", gv.EventObjectDesert2Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 2:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectDesert3StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectDesert3Status = 5;
                        PlayerPrefs.SetInt("EventObjectDesert3Status", gv.EventObjectDesert3Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 3:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectDesert4StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectDesert4Status = 5;
                        PlayerPrefs.SetInt("EventObjectDesert4Status", gv.EventObjectDesert4Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 4:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectDesert5StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectDesert5Status = 5;
                        PlayerPrefs.SetInt("EventObjectDesert5Status", gv.EventObjectDesert5Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }                    
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectIce1StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectIce1Status= 5;
                        PlayerPrefs.SetInt("EventObjectIce1Status", gv.EventObjectIce1Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 1:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectIce2StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectIce2Status = 5;
                        PlayerPrefs.SetInt("EventObjectIce2Status", gv.EventObjectIce2Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 2:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectIce3StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectIce3Status = 5;
                        PlayerPrefs.SetInt("EventObjectIce3Status", gv.EventObjectIce3Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 3:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectIce4StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectIce4Status = 5;
                        PlayerPrefs.SetInt("EventObjectIce4Status", gv.EventObjectIce4Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 4:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectIce5StatusTime", TimeText, 86400) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectIce5Status = 5;
                        PlayerPrefs.SetInt("EventObjectIce5Status", gv.EventObjectIce5Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectForest1StatusTime", TimeText, 86400) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectForest1Status = 5;
                        PlayerPrefs.SetInt("EventObjectForest1Status", gv.EventObjectForest1Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 1:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectForest2StatusTime", TimeText, DailyRewardTime) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectForest2Status = 5;
                        PlayerPrefs.SetInt("EventObjectForest2Status", gv.EventObjectForest2Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
                case 4:
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("EventObjectForest5StatusTime", TimeText, 86400) == -1)
                    {
                        BtnGet.interactable = true;
                        gv.EventObjectForest5Status = 5;
                        PlayerPrefs.SetInt("EventObjectForest5Status", gv.EventObjectForest5Status);
                        PlayerPrefs.Save();
                        TimeText.text = "00:00:00";
                    }
                    break;
            }
        }
    }
}
