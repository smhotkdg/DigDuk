using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KingMineralUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    
    public GameObject StartMineralsBG;
    public GameObject KingMineralsGamePanel;
    public GameObject RewardBG;
    public GameObject MinerContent;
    public List<GameObject> MinerList;
    public GameObject StageStartConfimPanelObj;
    public GameObject PanelSelectMinerObj;
    public GameObject NotificationPanelObj;

    public Text StageText;

    public GameObject DefaultStageMap;
    public GameObject DefaultStageMapParent;
    public ScrollRect MapScroll;

    public Text MineralsEnergyText;
    
    List<GameObject> MinerClons = new List<GameObject>();
    
    private void OnDisable()
    {
        UnsetMiner();
    }
    void Start()
    {
        MapScroll.verticalNormalizedPosition = 0;
    }
    void UnsetMiner()
    {
        for (int i = 0; i < MinerClons.Count; i++)
        {
            Destroy(MinerClons[i]);
        }
        MinerClons.Clear();
    }
    public void SetLvUp()
    {
        switch(gv.MapType)
        {
            case 1:
                gv.KingMineralStageNormal++;
                PlayerPrefs.SetInt("KingMineralStageNormal", gv.KingMineralStageNormal);
                break;
            case 2:
                gv.KingMineralStageDesert++;
                PlayerPrefs.SetInt("KingMineralStageDesert", gv.KingMineralStageDesert);
                break;
            case 3:
                gv.KingMineralStageIce++;
                PlayerPrefs.SetInt("KingMineralStageIce", gv.KingMineralStageIce);
                break;
            case 4:
                gv.KingMineralStageForest++;
                PlayerPrefs.SetInt("KingMineralStageForest", gv.KingMineralStageForest);
                break;
        }
        PlayerPrefs.Save();
        UnsetMiner();
        InitStageList(true);
    }
    private void OnEnable()
    {
        ChangeMap();
        InitStageList(true);        
    }
    void SetMiner()
    {
        for(int i=0; i< 6; i++)
        {
            if(gv.KingMineralMiners[i] >0)
            {
                string strName = "Miner" + gv.KingMineralMiners[i];
                GameObject temp = Instantiate(MinerContent.transform.Find(strName).gameObject);                
                Vector2 myVec = new Vector2();
                temp.transform.SetParent(MinerList[i].transform);
                myVec.x = 0.8f; myVec.y = 0.7f;
                temp.transform.localScale = myVec;
                myVec.x = 0; myVec.y = 0;
                temp.transform.localPosition = myVec;                
                
                
                temp.transform.Find("ImageLevel").gameObject.GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[gv.KingMineralMiners[i]-1] - 1];

                temp.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.KingMineralMiners[i]-1];
                temp.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.KingMineralMiners[i]-1];              



                temp.transform.Find("ImageLevel").gameObject.GetComponent<Image>().color =  gv.lvColorList[gv.ListHireLevel[gv.KingMineralMiners[i]-1] - 1];
                temp.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.KingMineralMiners[i]-1];
                temp.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.KingMineralMiners[i]-1];

                temp.SetActive(true);
                MinerClons.Add(temp);
            }
        }
    }
    public void SetStageText(string Name)
    {
        StageText.text = Name;
    }
    public List<GameObject> StageMapList = new List<GameObject>();
    //20 * 11 = 220 stage
    
    int stageCount = 20;
    public void SelectMinerComplete()
    {
        PressPanelSelectMiner(0);
        PressStartStagePanel(1);
    }
    void CheckDefaultChip(int type,int chiptype)
    {
        switch (type)
        {
            //칩셋
            case 1:
                if (chiptype != 0)
                {
                    gv.RewardKingMineralsChip2 = 0;                    
                }
                else
                {
                    gv.RewardKingMineralsChip1 = 0;                    
                }
                break;
            //호잇스톤
            case 2:
                gv.RewardKingMineralsHoitstone = 1;                
                break;
        }
    }
    string GetRewardCount(int type,int chiptype = 0)
    {
        string strReward = string.Empty;
        //int defaultValue = gv.KingMineralsStage / 11;
        int defaultValue = 10;
        //defaultValue += 1;
        //defaultValue = defaultValue * 10;
        switch (gv.MapType)
        {
            case 1:
                if (gv.KingMineralStageNormal > gv.KingMineralsStage)
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    
                    return strReward;
                }
                break;
            case 2:
                if (gv.KingMineralStageDesert > gv.KingMineralsStage)
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
            case 3:
                if (gv.KingMineralStageIce > gv.KingMineralsStage)
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
            case 4:
                if (gv.KingMineralStageForest > gv.KingMineralsStage)
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
        }
        switch(type)
        {
            //칩셋
            case 1:
                if(chiptype !=0)
                {
                    gv.RewardKingMineralsChip2 = 10;
                    strReward = gv.RewardKingMineralsChip2.ToString("N0");
                }
                else
                {
                    gv.RewardKingMineralsChip1 = 10;
                    strReward = gv.RewardKingMineralsChip1.ToString("N0");
                }
                break;
            //호잇스톤
            case 2:
                gv.RewardKingMineralsHoitstone = 2;
                strReward = gv.RewardKingMineralsHoitstone.ToString("N0");
                break;
        }

        return strReward;        
    }
    void SetReward(bool flag)
    {
        //int index = (gv.KingMineralsStage - 1) % 38;
        int index = (gv.KingMineralsStage) / 5;
        index = index + 1;
        string strMinerals = "Mineral" + index;
        StartMineralsBG.transform.Find(strMinerals).gameObject.SetActive(flag);
        switch (gv.MapType)
        {
            case 1:
                RewardBG.transform.Find("Reward1").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if(flag == true)
                {
                    RewardBG.transform.Find("Reward1").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 2:
                RewardBG.transform.Find("Reward1").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward2").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward1").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward2").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1,2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 3:
                RewardBG.transform.Find("Reward2").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward3").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward2").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward3").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1,2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 4:
                RewardBG.transform.Find("Reward3").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward4").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward3").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward4").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1,2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
        }
    }
    void SetMineralsAndReward()
    {
        if(gv.KingMineralsStage !=-1)
        {
            SetReward(true);
        }
    }
    void UnSetMineralsAndReward()
    {
        if (gv.KingMineralsStage != -1)
        {
            SetReward(false);
        }
    }
    float NowMineralEnergy = 0;
    public float GetNowMineralEnergy()
    {
        return NowMineralEnergy;
    }
    void SetMineralsEnergy()
    {
        //MineralsEnergyText.text = 
        switch(gv.MapType)
        {
            case 1:
                NowMineralEnergy = Mathf.Round(gv.KingMIneralsEnergy[gv.KingMineralsStage-1]);
                MineralsEnergyText.text = NowMineralEnergy.ToString("N0");
                gv.NowMineralEnergy = NowMineralEnergy;
                break;
            case 2:
                NowMineralEnergy = Mathf.Round(gv.KingMIneralsEnergy[gv.KingMineralsStage - 1] * 5);
                MineralsEnergyText.text = NowMineralEnergy.ToString("N0");
                gv.NowMineralEnergy = NowMineralEnergy;
                break;
            case 3:
                NowMineralEnergy = Mathf.Round(gv.KingMIneralsEnergy[gv.KingMineralsStage - 1] * 10);
                MineralsEnergyText.text = NowMineralEnergy.ToString("N0");
                gv.NowMineralEnergy = NowMineralEnergy;
                break;
            case 4:
                NowMineralEnergy = Mathf.Round(gv.KingMIneralsEnergy[gv.KingMineralsStage - 1] * 20);
                MineralsEnergyText.text = NowMineralEnergy.ToString("N0");
                gv.NowMineralEnergy = NowMineralEnergy;
                break;
        }
    }
    public void PressStartStagePanel(int i)
    {
        if( i==1)
        {
            SetMineralsAndReward();
            SetMineralsEnergy();
            SetMiner();
            gv.AddPanelPopup(StageStartConfimPanelObj, "StageStartConfimPanelObj");
            StageStartConfimPanelObj.SetActive(true);
        }
        else
        {
            UnsetMiner();
            UnSetMineralsAndReward();
            gv.DeletePanelPopup("StageStartConfimPanelObj");
            StageStartConfimPanelObj.SetActive(false);
        }
    }
    public void challengeKingMIneral()
    {
        gv.KingDps = 0;
        for (int i=0; i< 6; i++)
        {
            if(gv.KingMineralMiners[i] <=0)
            {
                PressNotificationPanel(1);
                return;
            }
        }
        PressKingMineralsGamePanel(1);
        this.GetComponent<KingMineralsGameSrc>().ViewGame();
    }
    public void PressKingMineralsGamePanel(int i)
    {
        if( i ==1)
        {
            PressStartStagePanel(0);
            gv.AddPanelPopup(KingMineralsGamePanel, "KingMineralsGamePanel");
            KingMineralsGamePanel.SetActive(true);
        }
        else
        {
            gv.isKingGameStart = 0;
            gv.DeletePanelPopup("KingMineralsGamePanel",1);
            KingMineralsGamePanel.SetActive(false);
        }
    }
    public void PressPanelSelectMiner(int i)
    {
        if (i == 1)
        {
            PressNotificationPanel(0);
            PressStartStagePanel(0);
            GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralSelectMinerSrc>().SetMiner();
            gv.AddPanelPopup(PanelSelectMinerObj, "PanelSelectMinerObj");
            PanelSelectMinerObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("PanelSelectMinerObj");
            PanelSelectMinerObj.SetActive(false);
        }
    }

    public void PressNotificationPanel(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(NotificationPanelObj, "NotificationPanelObj");
            NotificationPanelObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("NotificationPanelObj");
            NotificationPanelObj.SetActive(false);
        }
    }

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
   
	
	// Update is called once per frame
	void Update () {
		
	}
    void ChangeMap()
    {
        InitStageList(false);
    }
    void InitStageList(bool flag)
    {
        DefaultStageMap.SetActive(false);
        if (StageMapList.Count == 0)
        {
            int mapPos = 0;
            string strStageName = string.Empty;
            for (int i = stageCount; i > 0; i--)
            {
                mapPos = i;
                strStageName = "Map" + mapPos;
                GameObject temp = Instantiate(DefaultStageMap);
                temp.transform.SetParent(DefaultStageMap.transform.parent);
                temp.transform.localScale = DefaultStageMap.transform.localScale;
                temp.transform.localPosition = DefaultStageMap.transform.localPosition;
                temp.name = strStageName;
                StageMapList.Add(temp);
                StageMapList[StageMapList.Count - 1].SetActive(true);
            }

            string strPosName = string.Empty;
            int PosnameIndex = 0;
            int ListIndex = 0;
            for (int i = StageMapList.Count - 1; i >= 0; i--)
            {
                int stageIndex = (i + 1) * 11;
                for (int j = 10; j >= 0; j--)
                {
                    PosnameIndex = j + 1;
                    strPosName = "Pos" + PosnameIndex;
                    StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.Find("Text_stage").GetComponent<Text>().text = "Stage " + stageIndex.ToString();
                    stageIndex--;
                    Color myColor = new Color();
                    if(flag == true)
                    {
                        myColor.r = 1; myColor.g = 1; myColor.b = 1; myColor.a = 1;
                    }                        
                    else
                    {
                        myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                    }   
                    switch (gv.MapType)
                    {
                        case 1:
                            if (gv.KingMineralStageNormal == 0)
                            {
                                gv.KingMineralStageNormal = 1;
                                PlayerPrefs.SetInt("KingMineralStageNormal", gv.KingMineralStageNormal);
                            }
                            if (gv.KingMineralStageNormal > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 2:
                            if (gv.KingMineralStageDesert == 0)
                            {
                                gv.KingMineralStageDesert = 1;
                                PlayerPrefs.SetInt("KingMineralStageDesert", gv.KingMineralStageDesert);
                            }
                            if (gv.KingMineralStageDesert > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 3:
                            if (gv.KingMineralStageIce == 0)
                            {
                                gv.KingMineralStageIce = 1;
                                PlayerPrefs.SetInt("KingMineralStageIce", gv.KingMineralStageIce);
                            }
                            if (gv.KingMineralStageIce > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 4:
                            if (gv.KingMineralStageForest == 0)
                            {
                                gv.KingMineralStageForest = 1;
                                PlayerPrefs.SetInt("KingMineralStageForest", gv.KingMineralStageForest);
                            }
                            if (gv.KingMineralStageForest > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                    }
                }
                ListIndex++;
            }
        }
        else
        {   
            string strStageName = string.Empty;        

            string strPosName = string.Empty;
            int PosnameIndex = 0;
            int ListIndex = 0;
            for (int i = StageMapList.Count - 1; i >= 0; i--)
            {
                int stageIndex = (i + 1) * 11;
                for (int j = 10; j >= 0; j--)
                {
                    PosnameIndex = j + 1;
                    strPosName = "Pos" + PosnameIndex;
                    StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.Find("Text_stage").GetComponent<Text>().text = "Stage " + stageIndex.ToString();
                    stageIndex--;
                    Color myColor = new Color();
                    if (flag == true)
                    {
                        myColor.r = 1; myColor.g = 1; myColor.b = 1; myColor.a = 1;
                    }
                    else
                    {
                        myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                    }
                    switch (gv.MapType)
                    {
                        case 1:
                            if(gv.KingMineralStageNormal ==0)
                            {
                                gv.KingMineralStageNormal = 1;
                                PlayerPrefs.SetInt("KingMineralStageNormal", gv.KingMineralStageNormal);

                            }
                            if (gv.KingMineralStageNormal > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 2:
                            if (gv.KingMineralStageDesert == 0)
                            {
                                gv.KingMineralStageDesert = 1;
                                PlayerPrefs.SetInt("KingMineralStageDesert", gv.KingMineralStageDesert);
                            }
                            if (gv.KingMineralStageDesert > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 3:
                            if (gv.KingMineralStageIce == 0)
                            {
                                gv.KingMineralStageIce = 1;
                                PlayerPrefs.SetInt("KingMineralStageIce", gv.KingMineralStageIce);
                            }
                            if (gv.KingMineralStageIce > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                        case 4:
                            if (gv.KingMineralStageForest == 0)
                            {
                                gv.KingMineralStageForest = 1;
                                PlayerPrefs.SetInt("KingMineralStageForest", gv.KingMineralStageForest);
                            }
                            if (gv.KingMineralStageForest > stageIndex)
                            {
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = flag;
                            }
                            else
                            {
                                myColor.r = 0; myColor.g = 0; myColor.b = 0; myColor.a = 1;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Image>().color = myColor;
                                StageMapList[ListIndex].transform.Find(strPosName).gameObject.transform.GetComponent<Button>().enabled = false;
                            }
                            break;
                    }
                }
                ListIndex++;
            }
        }
        PlayerPrefs.Save();
    }
}
