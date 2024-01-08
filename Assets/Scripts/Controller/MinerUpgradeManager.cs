using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerUpgradeManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> GodStoneParticle;
    public Text GodStoneText;
    public Toggle GodStoneToggleBottom;
    public Toggle GodStoneToggleTop;

    public GameObject UniqueNormal;
    public GameObject BtnNormal;

    public GameObject TextMiner;
    public GameObject TextUpgrade;

    Text TotalMoney;


    public GameObject MainStatusCanvas;
    public GameObject loseParticle;
    public GameObject winParticleParticle;
    public GameObject Particle;
    public GameObject TouchText;
    public GameObject BtnEixt;
    public GameObject CardBack;
    public GameObject MinerList;
    public GameObject UpgradeViewObj;
    
    public Text MainText;
    public GameObject BackGroundUpImage;
    GlobalVariable gv;
    Vector2 nowPos = new Vector2();
    Vector2 nextPos = new Vector2();

    Vector2 nowOriPos = new Vector2();
    Vector2 NextPriPos = new Vector2();
    bool bStartView = false;
    int Level = -1;
    bool isGoodStone = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitLvData();
    }
    public void IsChangeToggleGodStoneTop()
    {
        if (gv.GodStoneCount > 0)
        {
            if (GodStoneToggleTop.isOn == false)
            {
                GodStoneToggleBottom.isOn = false;
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().ResetUpgradeProbability();
                isGoodStone = false;
            }
            if (GodStoneToggleTop.isOn == true)
            {
                GodStoneToggleBottom.isOn = true;
                for (int i = 0; i < GodStoneParticle.Count; i++)
                {
                    GodStoneParticle[i].SetActive(true);
                }
                StartCoroutine(StopGodStone());
                MainText.text = "100%";
                isGoodStone = true;
            }
        }
        else
        {
            GodStoneToggleTop.isOn = false;
            GodStoneToggleBottom.isOn = false;
        }
    }
    public void ChangeToggle(bool flag)
    {
        GodStoneToggleTop.isOn = flag;
        GodStoneToggleBottom.isOn = flag;
    }
    public void IsChangeToggleGodStone()
    {
        if(gv.GodStoneCount >0)
        {
            if (GodStoneToggleBottom.isOn == true)
            {
                GodStoneToggleTop.isOn = true;
                for (int i = 0; i < GodStoneParticle.Count; i++)
                {
                    GodStoneParticle[i].SetActive(true);
                }
                MainText.text = "100%";
                isGoodStone = true;
            }
            if (GodStoneToggleBottom.isOn == false)
            {
                GodStoneToggleTop.isOn = false;
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().ResetUpgradeProbability();
                isGoodStone = false;
            }          
        }
        else
        {
            GodStoneToggleTop.isOn = false;
            GodStoneToggleBottom.isOn = false;
        }
    }
    IEnumerator StopGodStone()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < GodStoneParticle.Count; i++)
        {
            GodStoneParticle[i].SetActive(false);
        }
    }

    public void InitLvData()
    {
        for (int i = 0; i < gv.ListHireLevel.Count; i++)
        {
            for (int k = 1; k < gv.ListHireLevel[i]; k++)
            {
                float weight = gv.GetMinerWeight(i);
                gv.ListMiningMin[i] = gv.ListMiningMin[i] + (int)(gv.ListMiningMin[i] * weight);
                gv.ListMiningMax[i] += (int)Mathf.Round((gv.ListMiningMaxDefault[i] * weight));
                gv.ListMiningTime[i] = gv.ListMiningTime[i] * 0.9f;
                gv.ListDefaultListMiningTime[i] = gv.ListMiningTime[i];
                //레벨업
                gv.listMaxMinerCapacity[i] = gv.listMaxMinerCapacity[i] + (int)(gv.listMaxMinerCapacity[i] * weight);

                //setAblity
                if (gv.BuffType[i] == 5)
                {
                    gv.BuffPower[i] = gv.BuffPower[i] + (gv.BuffPower[i] * 0.2f);
                }
                if (gv.BuffType[i] == 6)
                {                    
                    gv.BuffPower[i] = gv.BuffPower[i] + (gv.BuffPower[i] * 0.2f);                    
                }
                if (gv.BuffType[i] == 7)
                {
                    gv.BuffPower[i] = gv.BuffPower[i] + (gv.BuffPower[i] * 0.2f);                    
                }
                if (gv.BuffType[i] == 8)
                {
                    gv.BuffPower[i] = gv.BuffPower[i] + (gv.BuffPower[i] * 0.2f);                    
                }
            }
        }

    }
    public void CheckBuff(List<int> MinerList, int isBUffMinerIndex,int MinerIndex)
    {     
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBUffMinerIndex)
            {
                if (MinerList[i] == isBUffMinerIndex)
                {

                    if (gv.BuffType[MinerIndex - 1] == 5)
                    {                        
                        for (int k=0; k< gv.ListHireLevel[MinerIndex-1]; k++)
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }                        
                        gv.eachMiningPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 6)
                    {
                        for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.DrillBuffPower += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 7)
                    {
                        for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachMiningSpeed[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 8)
                    {
                        for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachSellPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                }
            }
        }
    }
    public void CheckBuffLvUp(List<int> MinerList, int isBUffMinerIndex, int MinerIndex)
    {
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBUffMinerIndex)
            {
                if (MinerList[i] == isBUffMinerIndex)
                {

                    if (gv.BuffType[MinerIndex - 1] == 5)
                    {
                        //for (int k = 0; i < gv.ListHireLevel[MinerIndex - 1]; k++)
                        gv.eachMiningPower[i] -= gv.BuffPower[MinerIndex - 1];
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachMiningPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 6)
                    {
                        //for (int k = 0; i < gv.ListHireLevel[MinerIndex - 1]; k++)
                        gv.DrillBuffPower -= gv.BuffPower[MinerIndex - 1];
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.DrillBuffPower += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 7)
                    {
                        //for (int k = 0; i < gv.ListHireLevel[MinerIndex - 1]; k++)
                        gv.eachMiningSpeed[i] -= gv.BuffPower[MinerIndex - 1];
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachMiningSpeed[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 8)
                    {
                        //for (int k = 0; i < gv.ListHireLevel[MinerIndex - 1]; k++)
                        gv.eachSellPower[i] -= gv.BuffPower[MinerIndex - 1];
                        {
                            gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachSellPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                }
            }
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
    GameObject MinerNow;
    GameObject MinerNext;
    public void setText(string _text)
    {
        //확률 100 %

        //도전 하시겠습니까?
        MainText.text = _text;
        GodStoneText.text = "" + gv.GodStoneCount;
    }
    int MinerIndex = -1;
    int equalCount = 0;
    //1 winmark 2//losemark 3 blackcoin
    int uniqueType = 0;
    public void SetMiner(int Index)
    {
        //최종 강화부분 예외처리 해야됨
        equalCount = 0;
        uniqueType = 0;
        for (int i = 0; i < gv.UniqueMinerList.Count; i++)
        {
            if (gv.UniqueMinerList[i] == Index)
            {
                if (i == 9)
                {
                    UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(false);
                    UniqueNormal.transform.Find("WinMark").gameObject.SetActive(false);
                    UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(true);
                    uniqueType = 2;
                }
                else if (i == 10)
                {
                    UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(false);
                    UniqueNormal.transform.Find("WinMark").gameObject.SetActive(true);
                    UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(false);
                    uniqueType = 1;
                }
                else
                {
                    UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(true);
                    UniqueNormal.transform.Find("WinMark").gameObject.SetActive(false);
                    UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(false);
                    uniqueType = 3;
                }
                equalCount++;
            }
        }
        if (equalCount == 0)
        {
            BtnNormal.SetActive(true);
            UniqueNormal.SetActive(false);
            TotalMoney = BtnNormal.transform.Find("TextMoney").gameObject.GetComponent<Text>();
        }
        else
        {
            BtnNormal.SetActive(false);
            UniqueNormal.SetActive(true);
            TotalMoney = UniqueNormal.transform.Find("TextMoney").gameObject.GetComponent<Text>();
        }

        MinerIndex = Index + 1;

        if (gv.ListHireCardOwnCount[MinerIndex -1] < 3)
        {
            TextMiner.SetActive(true);
            TextUpgrade.SetActive(true);

            //여기 수정 가ㅣ중
            //Upgrade Cost = HireCost  * (lv *12.5f)
            int MinerPos = -1;
            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == MinerIndex)
                {
                    MinerPos = i;
                }
            }
            if(equalCount ==0)
            {
                TextMiner.transform.Find("Miner").gameObject.GetComponent<Text>().text = "(같은 광부 3장 필요 - " + (3 - gv.ListHireCardOwnCount[MinerIndex - 1]) + "장 자동 구매)";
                TextMiner.transform.Find("Gold").gameObject.GetComponent<Text>().text = gv.ChangeMoney((gv.ListHireCost[MinerPos] * (3 - gv.ListHireCardOwnCount[MinerIndex - 1])));
                TextUpgrade.transform.Find("UpgradeGold").gameObject.GetComponent<Text>().text = gv.ChangeMoney(gv.ListHireCost[MinerPos] * 12.5f * gv.ListHireLevel[MinerIndex - 1]);
                gv.UpgradeCost = (gv.ListHireCost[MinerPos] * (3 - gv.ListHireCardOwnCount[MinerIndex - 1])) + gv.ListHireCost[MinerPos] * 12.5f * gv.ListHireLevel[MinerIndex - 1];
                TotalMoney.text = gv.ChangeMoney(gv.UpgradeCost);
            }
            else
            {
                TextMiner.transform.Find("Miner").gameObject.GetComponent<Text>().text = "(같은 광부 3장 필요 - " + (3 - gv.ListHireCardOwnCount[MinerIndex - 1]) + "장 자동 구매)";
                TextMiner.transform.Find("Gold").gameObject.GetComponent<Text>().text = ((gv.ListHireCost[MinerPos] * (3 - gv.ListHireCardOwnCount[MinerIndex - 1]))).ToString();
                TextUpgrade.transform.Find("UpgradeGold").gameObject.GetComponent<Text>().text = (gv.ListHireCost[MinerPos] * 3f * gv.ListHireLevel[MinerIndex - 1]).ToString();
                gv.UpgradeCost = (gv.ListHireCost[MinerPos] * (3 - gv.ListHireCardOwnCount[MinerIndex - 1])) + gv.ListHireCost[MinerPos] * 3f * gv.ListHireLevel[MinerIndex - 1];
                TotalMoney.text = (gv.UpgradeCost).ToString();
            }
     
        }
        else
        {
            TextMiner.SetActive(false);
            TextUpgrade.SetActive(true);
            int MinerPos = -1;
            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == MinerIndex)
                {
                    MinerPos = i;
                }
            }
            if (equalCount == 0)
            {   
                TextUpgrade.transform.Find("UpgradeGold").gameObject.GetComponent<Text>().text = gv.ChangeMoney(gv.ListHireCost[MinerPos] * 12.5f * gv.ListHireLevel[MinerIndex - 1]);
                gv.UpgradeCost = gv.ListHireCost[MinerPos] * 12.5f * gv.ListHireLevel[MinerIndex - 1];
                TotalMoney.text = gv.ChangeMoney(gv.UpgradeCost);
            }
            else
            {     
                TextUpgrade.transform.Find("UpgradeGold").gameObject.GetComponent<Text>().text = (gv.ListHireCost[MinerPos] * 3f * gv.ListHireLevel[MinerIndex - 1]).ToString();
                gv.UpgradeCost = gv.ListHireCost[MinerPos] * 3f * gv.ListHireLevel[MinerIndex - 1];
                TotalMoney.text = (gv.UpgradeCost).ToString();
            }

        }


        if ((gv.ListHireLevel[MinerIndex - 1]) >= 7)
        {
            string Minerstr = "Miner" + MinerIndex;
            string NextMinerStr = "Miner" + MinerIndex + " (1)";
            MinerNow = MinerList.transform.Find(Minerstr).gameObject;
            MinerNext = MinerList.transform.Find(NextMinerStr).gameObject;

            MinerNow.transform.Find("ImageLevel").GetComponent<Image>().color = gv.lvColorList[5];
            MinerNext.transform.Find("ImageLevel").GetComponent<Image>().color = gv.lvColorList[6];

            MinerNow.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Max";
            MinerNow.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
            MinerNext.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Max";
            MinerNext.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Max";

            nowOriPos = MinerList.transform.Find(Minerstr).gameObject.transform.localPosition;
            NextPriPos = MinerList.transform.Find(NextMinerStr).gameObject.transform.localPosition;

        }
        else
        {
            string Minerstr = "Miner" + MinerIndex;
            string NextMinerStr = "Miner" + MinerIndex + " (1)";
            MinerNow = MinerList.transform.Find(Minerstr).gameObject;
            MinerNext = MinerList.transform.Find(NextMinerStr).gameObject;

            MinerNow.transform.Find("ImageLevel").GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[MinerIndex - 1] - 1];
            MinerNext.transform.Find("ImageLevel").GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[MinerIndex - 1]];

            MinerNow.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + (gv.ListHireLevel[MinerIndex - 1]).ToString();
            MinerNow.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + (gv.ListHireLevel[MinerIndex - 1]).ToString();
            MinerNext.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + (gv.ListHireLevel[MinerIndex - 1] + 1).ToString();
            MinerNext.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + (gv.ListHireLevel[MinerIndex - 1] + 1).ToString();

            nowOriPos = MinerList.transform.Find(Minerstr).gameObject.transform.localPosition;
            NextPriPos = MinerList.transform.Find(NextMinerStr).gameObject.transform.localPosition;
        }
     



        MinerNow.SetActive(true);
        MinerNext.SetActive(true);
    }

    public void UnSetMiner(int MinerIndex)
    {

        TextMiner.SetActive(false);
        TextUpgrade.SetActive(false);

        Vector3 vec = new Vector3();
        vec = MinerNow.transform.localPosition;
        vec.x = 202.5f;
        MinerNow.transform.localPosition = nowPos; 
        
        vec = MinerNext.transform.localPosition;
        vec.x = 491.5f;
        MinerNext.transform.localPosition = nextPos;
        bStartView = false;
        vec.x = 1;
        vec.y = 1;
        vec.z = 1;
        MinerNext.transform.localScale = vec;
        MinerNow.transform.localScale = vec;
        vec.x = 700;
        vec.y = 400;
        vec.z = 1;
        BackGroundUpImage.GetComponent<RectTransform>().sizeDelta = vec;
        BtnEixt.SetActive(false);
        vec.x = 1;
        vec.y = 1;
        vec.z = 1;


        int index = MinerIndex + 1;
        string Minerstr = "Miner" + index;
        string NextMinerStr = "Miner" + index + " (1)";
        MinerNow = MinerList.transform.Find(Minerstr).gameObject;
        MinerNext = MinerList.transform.Find(NextMinerStr).gameObject;


        MinerList.transform.Find(Minerstr).gameObject.transform.localPosition = nowOriPos;
        MinerList.transform.Find(NextMinerStr).gameObject.transform.localPosition = NextPriPos;


        MinerNext.SetActive(false);
        MinerNow.SetActive(false);
        BackGroundUpImage.transform.localScale = vec;
        TouchText.SetActive(false);
        CardBack.GetComponent<Image>().fillAmount =0f;
        CardBack.SetActive(false);

        loseParticle.SetActive(false);
        winParticleParticle.SetActive(false);
        Particle.SetActive(false);

        StopCoroutine(MoveMinerCard());
        StopCoroutine(MinerUpBackground());

        StopCoroutine(MoveMinerCard2());
        StopCoroutine(ScaleBackGroundChange());
        StopCoroutine(ScaleChangeCard());
        StopCoroutine(ScaleChangeCardNow());
        StopCoroutine(StartCardBack());
    }

    public void SetUpgradeView()
    {
        if (equalCount == 0)
        {
            if ((gv.ListHireLevel[MinerIndex - 1]) >= 7)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "최대레벨 입니다.");
            }
            else if (gv.Money < gv.UpgradeCost)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "골드가 부족합니다.");
            }
            else
            {
                gv.ListHireCardOwnCount[MinerIndex - 1] += (3 - gv.ListHireCardOwnCount[MinerIndex - 1]);
                string strHireCardCount = "HireCardCount" + MinerIndex;
                PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[MinerIndex - 1]);                

                gv.Money -= gv.UpgradeCost;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                PlayerPrefs.Save();
                gv.ListHireCardOwnCount[MinerIndex - 1] -= 3;
                Level = gv.ListHireLevel[MinerIndex - 1];
                strHireCardCount = "HireCardCount" + MinerIndex;
                PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[MinerIndex - 1]);
                PlayerPrefs.Save();

                UniqueNormal.SetActive(false);
                BtnNormal.SetActive(false);

                UpgradeViewObj.SetActive(true);
                gv.bUpgrade = true;
                //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHireShop(0);
                //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressMinerInfoCanvas(0);

                MainStatusCanvas.GetComponent<PopUpManager>().PressBuffObj(0);

                nextPos = MinerNext.transform.localPosition;
                nowPos = MinerNow.transform.localPosition;
                StartCoroutine(MoveMinerCard());
                StartCoroutine(MoveMinerCard2());
                StartCoroutine(MinerUpBackground());
            }
        }
        else
        {
            if ((gv.ListHireLevel[MinerIndex - 1]) >= 7)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "최대레벨 입니다.");
            }
            else
            {
                if (uniqueType == 1)
                {
                    if (gv.WinMarkTotal < gv.UpgradeCost)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                        MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "승리의 증표가 부족 합니다.\n(미니 게임 승리로 획득가능)");
                    }
                    else
                    {
                        gv.WinMarkTotal -= (int)gv.UpgradeCost;
                        PlayerPrefs.SetInt("WinMarkTotal", gv.WinMarkTotal);
                        PlayerPrefs.Save();
                        QniqueUpgrade(2);
                    }
                }
                if (uniqueType == 2)
                {
                    if (gv.LoseMarkTotal < gv.UpgradeCost)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
                        MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "패배의 증표가 부족 합니다.\n(미니 게임 패배로 획득가능)");
                    }
                    else
                    {
                        gv.LoseMarkTotal -= (int)gv.UpgradeCost;
                        PlayerPrefs.SetInt("LoseMarkTotal", gv.LoseMarkTotal);
                        PlayerPrefs.Save();
                        QniqueUpgrade(2);
                    }

                }
                if (uniqueType == 3)
                {
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", -(int)gv.UpgradeCost))
                    {
                        QniqueUpgrade(3);
                    }
                    else
                    {
                        MainStatusCanvas.GetComponent<PopUpManager>().NeedBlackCoinView(1);
                        
                    }
                  
                }
            }
        }
    }
    public void QniqueUpgrade(int type)
    {
        gv.ListHireCardOwnCount[MinerIndex - 1] += 3 - gv.ListHireCardOwnCount[MinerIndex - 1];
        string strHireCardCount = "HireCardCount" + MinerIndex;
        PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[MinerIndex - 1]);
  
        gv.ListHireCardOwnCount[MinerIndex - 1] -= 3;
        Level = gv.ListHireLevel[MinerIndex - 1];
        strHireCardCount = "HireCardCount" + MinerIndex;
        PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[MinerIndex - 1]);
        PlayerPrefs.Save();

        UniqueNormal.SetActive(false);
        BtnNormal.SetActive(false);

        UpgradeViewObj.SetActive(true);
        gv.bUpgrade = true;
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHireShop(0);
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressMinerInfoCanvas(0);

        MainStatusCanvas.GetComponent<PopUpManager>().PressBuffObj(0);

        nextPos = MinerNext.transform.localPosition;
        nowPos = MinerNow.transform.localPosition;
        StartCoroutine(MoveMinerCard());
        StartCoroutine(MoveMinerCard2());
        StartCoroutine(MinerUpBackground());
    }
    public void EndUpgradeView()
    {
        UpgradeViewObj.SetActive(false);
        
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(0);
        MainStatusCanvas.GetComponent<PopUpManager>().PressBuffObj(1);
        gv.bUpgrade = false;
    }
    IEnumerator MoveMinerCard()
    {
        yield return new WaitForSeconds(0.001f);
        Vector2 vec = new Vector2();
        vec = MinerNow.transform.localPosition;
        vec.x += 4;
        MinerNow.transform.localPosition = vec;
        if (MinerNow.transform.localPosition.x < 0)
        {
            StartCoroutine(MoveMinerCard());
        }
        else
        {
            StartCoroutine(ScaleChangeCardNow());
        }
    }
    IEnumerator MinerUpBackground()
    {
        //500
        yield return new WaitForSeconds(0.01f);
        Vector2 vec = new Vector2();
        vec = BackGroundUpImage.GetComponent<RectTransform>().sizeDelta;
        vec.x -= 20f;
        BackGroundUpImage.GetComponent<RectTransform>().sizeDelta = vec;
        if (BackGroundUpImage.GetComponent<RectTransform>().sizeDelta.x > 500)
        {
            StartCoroutine(MinerUpBackground());
        }
       
        //1.5 y
    }
    IEnumerator MoveMinerCard2()
    {
        yield return new WaitForSeconds(0.01f);
        Vector2 vec = new Vector2();
        vec = MinerNext.transform.localPosition;
        vec.x -= 4;
        MinerNext.transform.localPosition = vec;
        if (MinerNext.transform.localPosition.x > 0)
        {
            StartCoroutine(MoveMinerCard2());
        }
        else
        {
            StartCoroutine(ScaleChangeCard());
            StartCoroutine(ScaleBackGroundChange());
        }
    }

    IEnumerator ScaleBackGroundChange()
    {
        yield return new WaitForSeconds(0.02f);
        Vector3 vec = new Vector3();
        vec = BackGroundUpImage.transform.localScale;        
        vec.y += 0.08f;        
        BackGroundUpImage.transform.localScale = vec;
        if (BackGroundUpImage.transform.localScale.y < 1.5)
        {
            StartCoroutine(ScaleBackGroundChange());
        }
    }
    IEnumerator ScaleChangeCard()
    {
        yield return new WaitForSeconds(0.01f);
        Vector3 vec = new Vector3();
        vec = MinerNext.transform.localScale;
        vec.x += 0.08f;
        vec.y += 0.08f;
        vec.z += 0.08f;
        MinerNext.transform.localScale = vec;
        if(MinerNext.transform.localScale.x <2)
        {
            StartCoroutine(ScaleChangeCard());
        }
    }
    IEnumerator ScaleChangeCardNow()
    {
        yield return new WaitForSeconds(0.01f);
        Vector3 vec = new Vector3();
        vec = MinerNow.transform.localScale;
        vec.x += 0.08f;
        vec.y += 0.08f;
        vec.z += 0.08f;
        MinerNow.transform.localScale = vec;
        if (MinerNow.transform.localScale.x < 2)
        {
            StartCoroutine(ScaleChangeCardNow());
        }
        else
        {
            CardBack.SetActive(true);
            StartCoroutine(StartCardBack());
        }
    }

    IEnumerator StartCardBack()
    {
        yield return new WaitForSeconds(0.001f);
        CardBack.GetComponent<Image>().fillAmount += 0.09f;
        if(CardBack.GetComponent<Image>().fillAmount <1 )
        {
            StartCoroutine(StartCardBack());
        }
        else
        {
            bStartView = true;
            TouchText.SetActive(true);
        }
    }

    public void StartCardView()
    {
        if(bStartView == true)
        {
            //강화 확률
            if (Level > 0)
            {
                
                int rand = 0;
                if(Level ==1)
                {
                    rand = 1;
                }
                if(Level ==2)
                {
                    rand = Random.Range(0, 2);
                }
                if (Level == 3)
                {
                    rand = Random.Range(0, 3);
                }
                if (Level == 4)
                {
                    rand = Random.Range(0, 3);
                }
                if (Level == 5)
                {
                    rand = Random.Range(0, 16);
                }
                if (Level == 6)
                {
                    rand = Random.Range(0, 21);
                }
                Level = -1;
                CardBack.SetActive(false);
                //성공
                if (rand == 1 || isGoodStone == true)
                {
                    if(isGoodStone ==true)
                    {
                        gv.GodStoneCount--;
                        PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
                        PlayerPrefs.Save();
                    }
                    MinerNext.SetActive(true);
                    Vector3 vec = new Vector3();
                    MinerNow.transform.localPosition = vec;
                    vec.x = 1;
                    vec.y = 1;
                    vec.z = 1;
                    MinerNow.transform.localScale = vec;
                    MinerNow.SetActive(false);
                    Particle.SetActive(true);
                    winParticleParticle.SetActive(true);
                    //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(0);
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("UpgradeSuccess");
                    gv.ListHireLevel[MinerIndex - 1]++;
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 12)
                    {
                        if (gv.ListHireLevel[MinerIndex - 1] >= 5)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(12, 0);
                        }
                    }
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 19)
                    {
                        if (gv.ListHireLevel[MinerIndex - 1] >= 7)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(19, 0);
                        }
                    }
                  
                    string strHireLevel = "HireLevel" + MinerIndex;

                    PlayerPrefs.SetInt(strHireLevel, gv.ListHireLevel[MinerIndex - 1]);
                    PlayerPrefs.Save();

                    float weight = gv.GetMinerWeight(MinerIndex - 1);
                    gv.ListMiningMin[MinerIndex - 1] = gv.ListMiningMin[MinerIndex - 1] + (int)(gv.ListMiningMin[MinerIndex - 1] * weight);
                    
                    gv.ListMiningMax[MinerIndex -1] += (int)Mathf.Round((gv.ListMiningMaxDefault[MinerIndex-1] * weight));

                    //gv.ListMiningTime[MinerIndex-1] = gv.ListMiningTime[MinerIndex-1] * 0.9f;
                    gv.ListMiningTime[MinerIndex - 1] = gv.ListDefaultListMiningTime[MinerIndex - 1] * 0.9f;

                    gv.ListDefaultListMiningTime[MinerIndex-1] = gv.ListMiningTime[MinerIndex-1];

                    GameObject.Find("MainCanvas").GetComponent<HireSettingController>().SetDefaultSpeed(MinerIndex - 1);
                    //레벨업
                    gv.listMaxMinerCapacity[MinerIndex - 1] = gv.listMaxMinerCapacity[MinerIndex - 1] + (gv.listMaxMinerCapacity[MinerIndex - 1] * weight);

                    
                    if (gv.MiningType[MinerIndex - 1] == 0)
                    {
                        
                        int isBuffMinerIndex = -1;
                        int index = 0;
                        if (gv.MapType == 1)
                            index = gv.ListHireCount[MinerIndex - 1];
                        if (gv.MapType == 2)
                            index = gv.ListHireDesertCount[MinerIndex - 1];
                        if (gv.MapType == 3)
                            index = gv.ListHireIceCount[MinerIndex - 1];
                        if (gv.MapType == 4)
                            index = gv.ListHireForestCount[MinerIndex - 1];
                        if (index < 0)
                        {       

                            if (Mathf.Abs(index) % 2 == 0)
                            {
                                isBuffMinerIndex = index + 1;
                            }
                            else
                            {
                                isBuffMinerIndex = index - 1;
                            }


                            if (gv.MapType == 1)
                                CheckBuffLvUp(gv.ListHireCount, isBuffMinerIndex, MinerIndex);
                            if (gv.MapType == 2)
                                CheckBuffLvUp(gv.ListHireDesertCount, isBuffMinerIndex, MinerIndex);
                            if (gv.MapType == 3)
                                CheckBuffLvUp(gv.ListHireIceCount, isBuffMinerIndex, MinerIndex);
                            if (gv.MapType == 4)
                                CheckBuffLvUp(gv.ListHireForestCount, isBuffMinerIndex, MinerIndex);

                        }
                        else
                        {
                            if (gv.BuffType[MinerIndex - 1] == 5)
                            {
                                gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                            }
                            if (gv.BuffType[MinerIndex - 1] == 6)
                            {
                                gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                            }
                            if (gv.BuffType[MinerIndex - 1] == 7)
                            {
                                gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                            }
                            if (gv.BuffType[MinerIndex - 1] == 8)
                            {
                                gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                            }
                        }
                    }
               
                    GameObject.Find("MainCanvas").GetComponent<MinerInfoCanvas>().SetDisableData();
                    GameObject.Find("MainCanvas").GetComponent<MinerInfoCanvas>().SetData();
                    GameObject.Find("MainCanvas").GetComponent<HireController>().UpgradeColor();
                    GameObject.Find("MainCanvas").GetComponent<HireController>().SetView();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 6)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(6, 0);
                    gv.UpgradeTotalCount++;
                    string strUpgradeTotalCount = "TotalUpgrade";
                    PlayerPrefs.SetInt(strUpgradeTotalCount, gv.UpgradeTotalCount);

                    //GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckLvlUpQuest());
                    isGoodStone = false;
                }
                else
                {
                    Vector3 vec = new Vector3();
                    MinerNext.transform.localPosition = vec;
                    vec.x = 1;
                    vec.y = 1;
                    vec.z = 1;
                    MinerNext.transform.localScale = vec;

                    MinerNext.SetActive(false);
                    MinerNow.SetActive(true);
                    Particle.SetActive(true);
                    loseParticle.SetActive(true);
                    //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(1);
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("UpgradeFail");
                }
                AfterTouch();
            }
        }
    }

    void AfterTouch()
    {
        TouchText.SetActive(false);
        BtnEixt.SetActive(true);
    }
}
