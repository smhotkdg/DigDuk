using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject ImgScroll;
    List<GameObject> QuestList = new List<GameObject>();

    List<GameObject> BtnBrown = new List<GameObject>();
    List<GameObject> BtnGreen = new List<GameObject>();
    List<GameObject> BtnComplete = new List<GameObject>();

    List<GameObject> PrgBar = new List<GameObject>();
    List<GameObject> Star = new List<GameObject>();

    List<GameObject> TextReward = new List<GameObject>();
    List<GameObject> TextQuest = new List<GameObject>();
    public Text DepthText;
    public GameObject Exclamationmark;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		for(int i=0; i< 13; i++)
        {
            int index = i + 1;
            string strQuest = "Quest" + index;
            QuestList.Add(ImgScroll.transform.Find(strQuest).gameObject);
            BtnBrown.Add(QuestList[QuestList.Count - 1].transform.Find("ButtonBrown").gameObject);
            BtnGreen.Add(QuestList[QuestList.Count - 1].transform.Find("ButtonGreen").gameObject);
            BtnComplete.Add(QuestList[QuestList.Count - 1].transform.Find("ButtonComplete").gameObject);

            PrgBar.Add(QuestList[QuestList.Count - 1].transform.Find("List").gameObject.transform.Find("prgBg").gameObject.transform.Find("prgBar").gameObject);
            Star.Add(QuestList[QuestList.Count - 1].transform.Find("List").gameObject.transform.Find("star").gameObject.transform.Find("star1").gameObject);


            TextQuest.Add(QuestList[QuestList.Count - 1].transform.Find("List").gameObject.transform.Find("Text (1)").gameObject);
            TextReward.Add(QuestList[QuestList.Count - 1].transform.Find("RewardIcon").gameObject.transform.Find("Reward").gameObject);

            Vector2 myVec = new Vector2();
            myVec = Star[i].GetComponent<Image>().transform.localPosition;

            myVec.x += (gv.QuestCompleteIndex[i] * 40 / 2);
            Star[i].GetComponent<Image>().transform.localPosition = myVec;

            RectTransform rt = Star[i].GetComponent<RectTransform>();
            rt.sizeDelta = new Vector2((gv.QuestCompleteIndex[i] + 1) * 41, 41);
        }

    }
	
	// Update is called once per frame
    public void SetExclamationmark(bool flag)
    {
        Exclamationmark.SetActive(flag);
    }

    void Update () {
		
	}
    //float defaultMoney = 1500f; // *10
    float defaultMoney = 1500f; // *10
    int defaultReardMoney = 5;
    
    public void GetReward(int i)
    {
   
        int index = i + 1;
        string strCombi;          
        strCombi = "QuestComplete" + index;
        gv.QuestCompleteIndex[i] = gv.QuestCompleteIndex[i] + 1;

        Vector2 myVec = new Vector2();
        myVec = Star[i].GetComponent<Image>().transform.localPosition;

        myVec.x += 20;
        Star[i].GetComponent<Image>().transform.localPosition = myVec;

        RectTransform rt = Star[i].GetComponent<RectTransform>();
        rt.sizeDelta = new Vector2((gv.QuestCompleteIndex[i] + 1) * 41, 41);


        PlayerPrefs.SetInt(strCombi, gv.QuestCompleteIndex[i]);
        PlayerPrefs.Save();     
        
        string temp;
        int rewardCount = 0;
        if(i !=2)
            rewardCount = int.Parse(TextReward[i].GetComponent<Text>().text);
        if(i ==0)
        {
            //판매 증가 표션 1개
            temp = "판매증가 포션 1 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "SellBuff");
            gv.SalePotionTotalCount += 1;
            PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
            PlayerPrefs.Save();
        }
        if(i ==3)
        {
            //드릴 버프 포션 1개
            temp = "드릴 포션 1 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "DrillPotion");
            gv.DrillPotionTotalCount += 1;
            PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
            PlayerPrefs.Save();
        }
        if (i ==10 || i ==11)
        {
            return;
        }
        if(i ==1)
        {
            temp = "광부 포션 " + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "MinerPotion");
            gv.MiningPotionTotalCount += rewardCount;
            PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
            PlayerPrefs.Save();
        }
        if (i == 2)
        {
            float QuestLvUpCount = (gv.QuestCompleteIndex[2]-1);       
            
            if(QuestLvUpCount <=0)
            {
                QuestLvUpCount = 1;
            }
            
            float RewardCount = ((gv.GetMoneyPos() / 4) * QuestLvUpCount) / 2;
            string str_money = gv.ChangeMoney(RewardCount);
            temp = "골드 " + str_money;
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "Money");
            gv.Money += RewardCount;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
        if (i == 4)
        {
            temp = "자동 판매 포션 " + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "AutoSell");
            gv.AutoSellPotionTotalCount+= rewardCount;
            PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
            PlayerPrefs.Save();
        }
        if(i ==5)
        {
            temp = "드릴 포션 " + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "DrillPotion");
            gv.DrillPotionTotalCount += rewardCount;
            PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
            PlayerPrefs.Save();
        }

        if (i == 6 || i==12 )
        {
            temp = "랜덤광부 10장" + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "MinerCard");
        }
        if (i == 7)
        {
            temp = "짱짱 포션 " + 1 + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "GoodPotion");
            gv.ZzangPotionTotalCount += 1;
            PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
            PlayerPrefs.Save();
        }
        if (i == 8)
        {
            temp = "승리의 증표 " + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "WinMark");
            gv.WinMarkTotal += rewardCount;
            string strUpgradeTotalCount = "WinMark";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.WinMarkTotal);
            PlayerPrefs.Save();

        }
        if (i == 9)
        {
            temp = "패배의 증표 " + rewardCount + " 개 ";
            GameObject.Find("QuestCanvas").GetComponent<QuestCanvasManager>().SetQuesetPopup(1, temp, "LoseMark");
            gv.LoseMarkTotal+= rewardCount;
            string strUpgradeTotalCount = "LoseMark";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LoseMarkTotal);

            PlayerPrefs.Save();
        }
        CheckView();
    }
    public void CheckView()
    {
        CheckMoneyQuest();
        CheckHireQuest();
        //CheckLvlUpQuest();
        CheckDIgDepthQuest();
        CheckBuyEngineQuset();
        CheckBuyDrillQuest();
        CheckMoveMapQuest();
        CheckBuyUniqueMinerQuest();
        CheckSadariGameQuset();
        CheckLottoGameQuest();
        CheckWinMarkQuest();
        CheckLoseMarkQuset();
        CheckWatchAdsQuest();
    }
    public bool CheckMoneyQuest()
    {
        //
        int QuestIndex = 0;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            float QuestMoney = gv.QuestCompleteIndex[QuestIndex] * 100;
            if(QuestMoney < defaultMoney)
            {
                //QuestMoney = Mathf.Pow(defaultMoney, gv.QuestCompleteIndex[QuestIndex]);
                QuestMoney = Mathf.Pow(defaultMoney, (float)(gv.QuestCompleteIndex[QuestIndex]+2) *0.5f);
                //QuestMoney += 1500f;
            }
            else
            {
                QuestMoney = defaultMoney;
            }
            
            int RewardCount = defaultReardMoney + gv.QuestCompleteIndex[QuestIndex];
            TextQuest[QuestIndex].GetComponent<Text>().text = gv.ChangeMoney(QuestMoney) + " 골드 수집";
            TextReward[QuestIndex].GetComponent<Text>().text = "1";

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = (float)gv.Money / QuestMoney;

            if (gv.Money >= QuestMoney)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
        
     
    }
    int defaultHireQuestReward = 1;
    public bool CheckHireQuest()
    {
        int QuestIndex = 1;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int hirecount = 0;
            for(int i=0;  i < gv.ListHireCount.Count; i++)
            {
                if(gv.ListHireCount[i] !=0)
                {
                    hirecount++;
                }
            }
            float QuestHireCount = (gv.QuestCompleteIndex[QuestIndex]+1) * 10;
        

            int RewardCount = defaultHireQuestReward + gv.QuestCompleteIndex[QuestIndex];
            TextQuest[QuestIndex].GetComponent<Text>().text = "광부 "+ QuestHireCount.ToString() + "명 고용";
            TextReward[QuestIndex].GetComponent<Text>().text = 1.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = hirecount / QuestHireCount;

            if (hirecount >= QuestHireCount)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckLvlUpQuest()
    {
        int QuestIndex = 2;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int LvCount = gv.UpgradeTotalCount;         
            float QuestLvUpCount = gv.QuestCompleteIndex[QuestIndex] *10;            
            if (QuestLvUpCount <=0)
            {
                QuestLvUpCount = 1;
            }

            //여기 돈 잘 조절해보자 
            float RewardCount = ((gv.GetMoneyPos() / 4) * QuestLvUpCount) / 20;
            TextQuest[QuestIndex].GetComponent<Text>().text = "광부 업그레이드" + QuestLvUpCount.ToString() + "번 달성";
            TextReward[QuestIndex].GetComponent<Text>().text = gv.ChangeMoney(RewardCount);

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = LvCount / QuestLvUpCount;

            if (LvCount >= QuestLvUpCount)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckDIgDepthQuest()
    {
        int QuestIndex = 3;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int DepthCount = gv.Depth;

            float QuestDepthCount = (gv.QuestCompleteIndex[QuestIndex]+1) *2;         
            float RewardCount = 10;
            TextQuest[QuestIndex].GetComponent<Text>().text = (QuestDepthCount * 10).ToString() + " Km 달성";
            DepthText.text = (QuestDepthCount*10).ToString() + " Km";
            TextReward[QuestIndex].GetComponent<Text>().text = "1";

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = DepthCount / QuestDepthCount;

            if (DepthCount >= QuestDepthCount)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckBuyEngineQuset()
    {
        int QuestIndex = 4;
        if (gv.QuestCompleteIndex[QuestIndex] >= 13)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
         
            float RewardCount = gv.EngineLv+1;
            
            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", TextQuest[QuestIndex].GetComponent<Text>(), (int)gv.QuestCompleteIndex[QuestIndex]);
            TextQuest[QuestIndex].GetComponent<Text>().text += " 구입";

            TextReward[QuestIndex].GetComponent<Text>().text = 1.ToString(); 

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount =  gv.EngineLv  / (gv.QuestCompleteIndex[QuestIndex] + 1);

            if (gv.EngineLv >= (gv.QuestCompleteIndex[QuestIndex] + 1))
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckBuyDrillQuest()
    {
        int QuestIndex = 5;
        if (gv.QuestCompleteIndex[QuestIndex] >= 13)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {

            float RewardCount = gv.BitLv + 1;

            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", TextQuest[QuestIndex].GetComponent<Text>(), (int)gv.QuestCompleteIndex[QuestIndex]);
            TextQuest[QuestIndex].GetComponent<Text>().text += " 구입";

            TextReward[QuestIndex].GetComponent<Text>().text = 1.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = gv.BitLv / (gv.QuestCompleteIndex[QuestIndex] + 1);

            if (gv.BitLv >= (gv.QuestCompleteIndex[QuestIndex] + 1))
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckMoveMapQuest()
    {
        int QuestIndex = 6;
        if (gv.QuestCompleteIndex[QuestIndex] >=2)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {

            float RewardCount = 1;

            if(gv.QuestCompleteIndex[QuestIndex] ==0)
            {
                TextQuest[QuestIndex].GetComponent<Text>().text = "사막맵 이동";
                if(gv.MapType ==2)
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount =1;
                    BtnGreen[QuestIndex].SetActive(true);
                    BtnBrown[QuestIndex].SetActive(false);
                    return true;
                }
                else
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount = 0;
                    BtnGreen[QuestIndex].SetActive(false);
                    BtnBrown[QuestIndex].SetActive(true);
                    return false;
                }
            }
                
            if (gv.QuestCompleteIndex[QuestIndex] == 1)
            {
                TextQuest[QuestIndex].GetComponent<Text>().text = "얼음맵 이동";
                if (gv.MapType == 3)
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount = 1;
                    BtnGreen[QuestIndex].SetActive(true);
                    BtnBrown[QuestIndex].SetActive(false);
                    return true;
                }
                else
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount = 0;
                    BtnGreen[QuestIndex].SetActive(false);
                    BtnBrown[QuestIndex].SetActive(true);
                    return false;
                }
            }
                
            if (gv.QuestCompleteIndex[QuestIndex] == 2)
            {
                TextQuest[QuestIndex].GetComponent<Text>().text = "정글맵 이동";
                if (gv.MapType == 4)
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount = 1;
                    BtnGreen[QuestIndex].SetActive(true);
                    BtnBrown[QuestIndex].SetActive(false);
                    return true;
                }
                else
                {
                    PrgBar[QuestIndex].GetComponent<Image>().fillAmount = 0;
                    BtnGreen[QuestIndex].SetActive(false);
                    BtnBrown[QuestIndex].SetActive(true);
                    return false;
                }
            }
            return false;

            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString();            
       
        }
    }
    public bool CheckBuyUniqueMinerQuest()
    {
        int QuestIndex = 7;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int hirecount = 0;
            for (int i = 0; i < gv.listMinerGrade.Count; i++)
            {
                if (gv.listMinerGrade[i] == 7)
                {
                    if(gv.ListHireCount[i] !=0)
                    {
                        hirecount++;
                    }
                }
            }
            float QuestHireCount = (gv.QuestCompleteIndex[QuestIndex] + 1);


            int RewardCount = 2 + gv.QuestCompleteIndex[QuestIndex];


            //TextQuest[QuestIndex].GetComponent<Text>().text = "유니크 광부 고용";

            TextReward[QuestIndex].GetComponent<Text>().text = 1.ToString();
            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = hirecount / QuestHireCount;

            if (hirecount >= QuestHireCount)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }

    public bool CheckSadariGameQuset()
    {
        int QuestIndex = 8;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int SadariCount = gv.SadariTotalWinCount;

            float QuestSadari = gv.QuestCompleteIndex[QuestIndex] * 5;
            if (QuestSadari <= 0)
            {
                QuestSadari = 5;
            }

            //여기 돈 잘 조절해보자
            float RewardCount = 10;
            TextQuest[QuestIndex].GetComponent<Text>().text = "사다리 게임 승리 " + QuestSadari.ToString() + "회";
            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString(); ;

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = SadariCount / QuestSadari;

            if (SadariCount >= QuestSadari)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckLottoGameQuest()
    {
        int QuestIndex =9;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int LottoCount = gv.LottoTotalWinCount;

            float QuestLotto = gv.QuestCompleteIndex[QuestIndex] * 3;
            if (QuestLotto <= 0)
            {
                QuestLotto = 3;
            }

            //여기 돈 잘 조절해보자
            float RewardCount = 10;
            TextQuest[QuestIndex].GetComponent<Text>().text = "로또 게임 당첨 " + QuestLotto.ToString() + "회";
            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = LottoCount / QuestLotto;

            if (LottoCount >= QuestLotto)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }

    public bool CheckWinMarkQuest()
    {
        int QuestIndex = 10;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int WinMark = gv.WinMarkTotal;

            float QuestWinMark = gv.QuestCompleteIndex[QuestIndex] * 15;
            if (QuestWinMark <= 0)
            {
                QuestWinMark = 15;
            }

            //여기 돈 잘 조절해보자
            float RewardCount = 5;
            TextQuest[QuestIndex].GetComponent<Text>().text = "승리의 증표 " + QuestWinMark.ToString() + "개 획득";
            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = WinMark / QuestWinMark;

            if (WinMark >= QuestWinMark)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckLoseMarkQuset()
    {
        int QuestIndex = 11;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int LoseMark = gv.LoseMarkTotal;

            float QuestLoseMark = gv.QuestCompleteIndex[QuestIndex] * 15;
            if (QuestLoseMark <= 0)
            {
                QuestLoseMark = 15;
            }

            //여기 돈 잘 조절해보자
            float RewardCount = 5;
            //번역
            TextQuest[QuestIndex].GetComponent<Text>().text = "패배의 증표 " + QuestLoseMark.ToString() + "개 획득";
            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = LoseMark / QuestLoseMark;

            if (LoseMark >= QuestLoseMark)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
    public bool CheckWatchAdsQuest()
    {
        int QuestIndex = 12;
        if (gv.QuestCompleteIndex[QuestIndex] >= 200)
        {
            BtnGreen[QuestIndex].SetActive(false);
            BtnBrown[QuestIndex].SetActive(false);
            BtnComplete[QuestIndex].SetActive(true);
            TextQuest[QuestIndex].GetComponent<Text>().text = "완료";
            return false;
        }
        else
        {
            int AdsCount = gv.AdsTotalCount;

            float QuestAdsCount = gv.QuestCompleteIndex[QuestIndex] * 200;
            if (QuestAdsCount <= 0)
            {
                QuestAdsCount = 200;
            }

            //여기 돈 잘 조절해보자
            float RewardCount = 1;
            TextQuest[QuestIndex].GetComponent<Text>().text = "광고 " + QuestAdsCount.ToString() + "회 시청";
            TextReward[QuestIndex].GetComponent<Text>().text = RewardCount.ToString();

            PrgBar[QuestIndex].GetComponent<Image>().fillAmount = AdsCount / QuestAdsCount;

            if (AdsCount >= QuestAdsCount)
            {
                BtnGreen[QuestIndex].SetActive(true);
                BtnBrown[QuestIndex].SetActive(false);
                return true;
            }
            else
            {
                BtnGreen[QuestIndex].SetActive(false);
                BtnBrown[QuestIndex].SetActive(true);
                return false;
            }
        }
    }
}
