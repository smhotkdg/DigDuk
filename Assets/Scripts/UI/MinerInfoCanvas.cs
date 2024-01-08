using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerInfoCanvas : MonoBehaviour {

    // Use this for initialization
    public GameObject MinerSpecialTextObj;
    public Text MinerSpecialText;

    public GameObject NonMinerSpecialTextObj;
    public Text NonMinerSpecialText;


    public GameObject MiningSpeedObj;
    public Text TextBuffSpeed;
    public GameObject MiningAmountObj;
    public Text TextBuffAmount;
    public GameObject MinerObj;
    public GameObject NonMienrObj;

    public GameObject Buff1;
    public GameObject Buff2;
    public GameObject Buff3;
    public GameObject Buff4;

    public Text BuffText;

    public Text TextBuff;
    public Text TextNextBuff;
    Text TextMoney;
    public GameObject ImgBackGround;
    public Text TextMiningSpeed;
    public Text TextMiningSpeed2;
    public Text TextMiningSpeedUp;
    public Text TextMiningSpeedUp2;

    public Text TextMiningCount;
    public Text TextMiningCount2;
    public Text TextMiningCountUp;
    public Text TextMiningCountUp2;

    public Text MinerName;
    public Text MinerName2;

    public Text MinerCapacity1;
    public Text MinerCapacity2;

    List<GameObject> MinerList = new List<GameObject>();
    List<GameObject> RibbonList = new List<GameObject>();
    GlobalVariable gv;
    List<Image> ListProgass = new List<Image>();
    List<Text> ListPrograssText = new List<Text>();
    List<GameObject> ImageLevel = new List<GameObject>();
    int index = -1;
    int ribbonIndex = -1;
    public GameObject BtnNormal;
    public GameObject UniqueNormal;
    public GameObject BtnUpgrade;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitData();
	}

    private void InitData()
    {
        for(int i=0; i< 110; i++)
        {
            int index = i + 1;
            string strMiner = "Miner" + index;
            MinerList.Add(ImgBackGround.transform.Find(strMiner).gameObject);
            ListProgass.Add(MinerList[MinerList.Count - 1].transform.Find("PrograssBack").gameObject.transform.Find("Prograss").gameObject.GetComponent<Image>());
            ListPrograssText.Add(MinerList[MinerList.Count - 1].transform.Find("PrograssBack").gameObject.transform.Find("Prograss").gameObject.transform.Find("TextCount").GetComponent<Text>());
            ImageLevel.Add(MinerList[MinerList.Count - 1].transform.Find("ImageLevel").gameObject);
            if (i <7)
            {
                string strRibbon = "ImgRibbon" + index;
                RibbonList.Add(ImgBackGround.transform.Find(strRibbon).gameObject);
            }
        }
    }    

    
    public void SetData()
    {
        SetDisableData();
        if (gv.selectNumber > -1)
        {
            MinerSpecialTextObj.SetActive(true);
            NonMinerSpecialTextObj.SetActive(false);
            //if(gv.ListHireCount[gv.selectNumber] !=0)
            {
                if (gv.MiningType[gv.selectNumber] == 1)
                {
                    MinerObj.SetActive(true);
                    NonMienrObj.SetActive(false);
                    if(gv.selectNumber >95)
                    {
                        string strBuff = string.Empty;
                        for (int i = 0; i < gv.UniqueMinerList.Count; i++)
                        {
                            if (gv.UniqueMinerList[i] == gv.selectNumber)
                            {
                                switch (gv.UniqueMinerBuffTypeList[i])
                                {
                                    case "1.5":
                                        strBuff = "드릴파워 증가 x5";
                                        break;
                                    case "1.8":
                                        strBuff = "드릴파워 증가 x8";
                                        break;
                                    case "1.9":
                                        strBuff = "드릴파워 증가 x9";
                                        break;
                                    case "2.6":
                                        strBuff = "전체판매량 증가 x6";
                                        break;
                                    case "2.9":
                                        strBuff = "전체판매량 증가 x9";
                                        break;
                                    case "2.12":
                                        strBuff = "전체판매량 증가 x6";
                                        break;
                                    case "3.4":
                                        strBuff = "전체 호잇스톤 채굴량 x4";
                                        break;
                                    case "3.8":
                                        strBuff = "전체 호잇스톤 채굴량 x8";
                                        break;
                                    case "4.4":
                                        strBuff = "드릴파워 증가 x4\n전체판매량 증가 x4";
                                        break;
                                    case "4.8":
                                        strBuff = "드릴파워 증가 x8\n전체판매량 증가 x8";
                                        break;
                                    case "5.6":
                                        strBuff = "드릴파워 증가 x6\n전체 호잇스톤 채굴량 x6";
                                        break;
                                    case "5.8":
                                        strBuff = "드릴파워 증가 x8\n전체 호잇스톤 채굴량 x8";
                                        break;
                                    case "6.5":
                                        strBuff = "전체판매량 증가 x5\n전체 호잇스톤 채굴량 x5";
                                        break;
                                    case "6.8":
                                        strBuff = "전체판매량 증가 x8\n전체 호잇스톤 채굴량 x8";
                                        break;  
                                }
                                MinerSpecialText.text = strBuff;
                                MinerSpecialTextObj.SetActive(false);
                            }
                        }                                
                    }
                    else
                    {
                        MinerSpecialText.text = "채굴 속도 x 2배 (30초)";
                    }
                }
                else
                {
                    if (gv.selectNumber > 95)
                    {
                        string strBuff = string.Empty;
                        for (int i = 0; i < gv.UniqueMinerList.Count; i++)
                        {
                            if (gv.UniqueMinerList[i] == gv.selectNumber)
                            {
                                switch (gv.UniqueMinerBuffTypeList[i])
                                {
                                    case "1.5":
                                        strBuff = "드릴파워 증가 x5";
                                        break;
                                    case "1.8":
                                        strBuff = "드릴파워 증가 x8";
                                        break;
                                    case "1.9":
                                        strBuff = "드릴파워 증가 x9";
                                        break;
                                    case "2.6":
                                        strBuff = "전체판매량 증가 x6";
                                        break;
                                    case "2.9":
                                        strBuff = "전체판매량 증가 x9";
                                        break;
                                    case "2.12":
                                        strBuff = "전체판매량 증가 x6";
                                        break;
                                    case "3.4":
                                        strBuff = "전체 호잇스톤 채굴량 x4";
                                        break;
                                    case "3.8":
                                        strBuff = "전체 호잇스톤 채굴량 x8";
                                        break;
                                    case "4.4":
                                        strBuff = "드릴파워 증가 x4\n전체판매량 증가 x4";
                                        break;
                                    case "4.8":
                                        strBuff = "드릴파워 증가 x8\n전체판매량 증가 x8";
                                        break;
                                    case "5.6":
                                        strBuff = "드릴파워 증가 x6\n전체 호잇스톤 채굴량 x6";
                                        break;
                                    case "5.8":
                                        strBuff = "드릴파워 증가 x8\n전체 호잇스톤 채굴량 x8";
                                        break;
                                    case "6.5":
                                        strBuff = "전체판매량 증가 x5\n전체 호잇스톤 채굴량 x5";
                                        break;
                                    case "6.8":
                                        strBuff = "전체판매량 증가 x8\n전체 호잇스톤 채굴량 x8";
                                        break;
                                }
                                NonMinerSpecialText.text = strBuff;                                
                            }
                        }
                        NonMinerSpecialTextObj.SetActive(true);
                    }
                    else
                    {
                        NonMinerSpecialText.text = "채굴 속도 x 2배 (30초)";
                    }
                    MinerObj.SetActive(false);
                    NonMienrObj.SetActive(true);
                    string strbuff = string.Empty;
                    if (gv.BuffType[gv.selectNumber] == 5)
                    {
                        Buff1.SetActive(true);
                        Buff2.SetActive(false);
                        Buff3.SetActive(false);
                        Buff4.SetActive(false);
                        strbuff = "채굴량 증가";
                    }
                    if (gv.BuffType[gv.selectNumber] == 6)
                    {
                        Buff1.SetActive(false);
                        Buff2.SetActive(true);
                        Buff3.SetActive(false);
                        Buff4.SetActive(false);
                        strbuff = "드릴 파워 증가";
                    }
                    if (gv.BuffType[gv.selectNumber] == 7)
                    {
                        Buff1.SetActive(false);
                        Buff2.SetActive(false);
                        Buff3.SetActive(true);
                        Buff4.SetActive(false);
                        strbuff = "채굴 속도 증가";
                    }
                    if (gv.BuffType[gv.selectNumber] == 8)
                    {
                        Buff1.SetActive(false);
                        Buff2.SetActive(false);
                        Buff3.SetActive(false);
                        Buff4.SetActive(true);
                        strbuff = "판매 증가";
                    }
                    BuffText.text = strbuff;

                    float temp = Mathf.Round((gv.BuffPower[gv.selectNumber] * 10)) * 0.1f;
                    float temp2 = Mathf.Round((temp + (temp * 0.2f)) * 10) * 0.1f;
                    TextBuff.text = temp.ToString(("N1")) + " 배";
                    TextNextBuff.text = temp2.ToString(("N1")) + " 배";

                }
                MinerList[gv.selectNumber].SetActive(true);
                int equalCount = 0;
                for (int i = 0; i < gv.UniqueMinerList.Count; i++)
                {
                    if (gv.UniqueMinerList[i] == gv.selectNumber)
                    {
                        if (i == 9)
                        {
                            UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(false);
                            UniqueNormal.transform.Find("WinMark").gameObject.SetActive(false);
                            UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(true);
                        }
                        else if (i == 10)
                        {
                            UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(false);
                            UniqueNormal.transform.Find("WinMark").gameObject.SetActive(true);
                            UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(false);
                        }
                        else
                        {
                            UniqueNormal.transform.Find("BlackCoin").gameObject.SetActive(true);
                            UniqueNormal.transform.Find("WinMark").gameObject.SetActive(false);
                            UniqueNormal.transform.Find("LoseMark").gameObject.SetActive(false);
                        }
                        equalCount++;
                    }
                }
                if (equalCount == 0)
                {
                    BtnNormal.SetActive(true);
                    UniqueNormal.SetActive(false);
                    TextMoney = BtnNormal.transform.Find("TextMoney").gameObject.GetComponent<Text>();
                }
                else
                {
                    BtnNormal.SetActive(false);
                    UniqueNormal.SetActive(true);
                    TextMoney = UniqueNormal.transform.Find("TextMoney").gameObject.GetComponent<Text>();
                }

                if (gv.MapType == 1)
                {
                    if (gv.ListHireCount[gv.selectNumber] == 0)
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 0; color.g = 0; color.b = 0;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                    else
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 1; color.g = 1; color.b = 1;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                }
                if (gv.MapType == 2)
                {
                    if (gv.ListHireDesertCount[gv.selectNumber] == 0)
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 0; color.g = 0; color.b = 0;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                    else
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 1; color.g = 1; color.b = 1;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                }
                if (gv.MapType == 3)
                {
                    if (gv.ListHireIceCount[gv.selectNumber] == 0)
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 0; color.g = 0; color.b = 0;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                    else
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 1; color.g = 1; color.b = 1;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                }
                if (gv.MapType == 4)
                {
                    if (gv.ListHireForestCount[gv.selectNumber] == 0)
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 0; color.g = 0; color.b = 0;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                    else
                    {
                        Color color = new Color();
                        color = MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color;
                        color.r = 1; color.g = 1; color.b = 1;
                        MinerList[gv.selectNumber].transform.Find("Miner").GetComponent<Image>().color = color;
                    }
                }

                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextMiner("kor", MinerName, gv.selectNumber);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextMiner("kor", MinerName2, gv.selectNumber);


                MinerCapacity1.text = gv.listMaxMinerCapacity[gv.selectNumber].ToString("N0");

                float weight = gv.GetMinerWeight(gv.selectNumber);

                //레벨업
                float maxCapNext = gv.listMaxMinerCapacity[gv.selectNumber] + (gv.listMaxMinerCapacity[gv.selectNumber] * weight);
                MinerCapacity2.text = (maxCapNext).ToString("N0");

                ImageLevel[gv.selectNumber].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[gv.selectNumber] - 1];
                if (gv.ListHireLevel[gv.selectNumber] >= 7)
                {
                    ImageLevel[gv.selectNumber].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                    ImageLevel[gv.selectNumber].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                }
                else
                {
                    ImageLevel[gv.selectNumber].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.selectNumber];
                    ImageLevel[gv.selectNumber].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[gv.selectNumber];
                }

                double money_m = 0;

                for (int i = 0; i < gv.ListMinerClass.Count; i++)
                {
                    if (gv.ListMinerClass[i].m_position == gv.selectNumber + 1)
                    {
                        money_m = gv.ListHireCost[i];
                    }
                }
                if (equalCount == 0)
                    TextMoney.text = gv.ChangeMoney(money_m);
                else
                {
                    TextMoney.text = money_m.ToString();
                }


                //float speed = gv.ListMiningTime[gv.selectNumber];
                float speed = gv.ListDefaultListMiningTime[gv.selectNumber];

                if (gv.eachMiningSpeed[gv.selectNumber] > 0)
                {
                    MiningSpeedObj.SetActive(true);
                    TextBuffSpeed.text = "- " + gv.eachMiningSpeed[gv.selectNumber];
                }
                else
                {
                    MiningSpeedObj.SetActive(false);
                }

                if (gv.eachMiningPower[gv.selectNumber] > 0)
                {
                    MiningAmountObj.SetActive(true);
                    TextBuffAmount.text = "x " + gv.eachMiningPower[gv.selectNumber];
                }
                else
                {
                    MiningAmountObj.SetActive(false);
                }



                TextMiningSpeed.text = speed.ToString("N1");
                TextMiningSpeed2.text = speed.ToString("N1");

                TextMiningSpeedUp.text = (speed * 0.9).ToString("N1");
                TextMiningSpeedUp2.text = (speed * 0.9).ToString("N1");

                int Min = gv.ListMiningMin[gv.selectNumber];
                int Max = gv.ListMiningMax[gv.selectNumber];


                //TextMiningCount.text = Min.ToString() + " ~ " + Max.ToString();
                TextMiningCount.text = Max.ToString();
                //TextMiningCount2.text = Min.ToString() + " ~ " + Max.ToString();
                TextMiningCount2.text = Max.ToString();


                Min = gv.ListMiningMin[gv.selectNumber] + (int)(gv.ListMiningMin[gv.selectNumber] * weight);
                Max = gv.ListMiningMax[gv.selectNumber] + (int)Mathf.Round((gv.ListMiningMaxDefault[gv.selectNumber] * weight));

                //TextMiningCountUp.text = (Min).ToString() + " ~ " + (Max).ToString();
                //TextMiningCountUp2.text = (Min).ToString() + " ~ " + (Max).ToString();
                TextMiningCountUp.text = (Max).ToString();
                TextMiningCountUp2.text = (Max).ToString();

                if (gv.listMinerGrade[gv.selectNumber] == 1)
                {
                    ribbonIndex = 1;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 2)
                {
                    ribbonIndex = 2;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 3)
                {
                    ribbonIndex = 3;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 4)
                {
                    ribbonIndex = 4;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 5)
                {
                    ribbonIndex = 5;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 6)
                {
                    ribbonIndex = 6;
                }
                if (gv.listMinerGrade[gv.selectNumber] == 7)
                {
                    ribbonIndex = 7;
                }

                if (ribbonIndex > -1)
                {
                    RibbonList[ribbonIndex - 1].SetActive(true);
                }

                string strPrgassText = gv.ListHireCardOwnCount[gv.selectNumber] + " / 3";

                ListPrograssText[gv.selectNumber].text = strPrgassText;
                ListProgass[gv.selectNumber].fillAmount = (float)gv.ListHireCardOwnCount[gv.selectNumber] / 3;

                index = gv.selectNumber;
            }
            if (gv.ListHireCount[gv.selectNumber] == 0)
            {
                BtnNormal.SetActive(false);
                UniqueNormal.SetActive(false);
                BtnUpgrade.SetActive(false);
            }
            else
            {
                BtnUpgrade.SetActive(true);
            }
        }
    }
    public void SetDisableData()
    {
        if(index > -1)
        {
            MinerList[index].SetActive(false);
        }
        if (ribbonIndex > -1)
        {
            RibbonList[ribbonIndex - 1].SetActive(false);
        }
        for(int i=0; i< MinerList.Count; i++)
        {
            if(MinerList[i].activeSelf ==true)
            {
                MinerList[i].SetActive(false);
            }
        }
    }

    // Update is called once per frame
    void Update () {
		
	}
}

