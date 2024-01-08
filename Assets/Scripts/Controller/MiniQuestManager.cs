using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniQuestManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject Finger;
    public Text TextQuest;
    public Text TextQuestEng;
    public GameObject MiniQuestObj;
    List<double> QuestCount = new List<double>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        QuestCount.Add(3);
        QuestCount.Add(1);
        QuestCount.Add(3000 * gv.scaleFactor);
        QuestCount.Add(1);
        QuestCount.Add(100);
        QuestCount.Add(1);
        QuestCount.Add(3);
        QuestCount.Add(1);
        QuestCount.Add(2);
        QuestCount.Add(1);
        QuestCount.Add(1);

        //여기서 부터가 신규
        QuestCount.Add(1); //우는애 만나기
        QuestCount.Add(1); // 광부 렙업 5
        QuestCount.Add(1); // 원정대 출동
        QuestCount.Add(1); // 로봇 제작하기
        QuestCount.Add(1); // 드럼엔진 & 드럼 드릴 제작하기
        QuestCount.Add(30); // 광부 30명 고용하기
        QuestCount.Add(100); // 호잇스톤 누적 100개
        QuestCount.Add(1); // 사막으로 이동하기
        QuestCount.Add(1); // 광부 레벨 7만들기
        QuestCount.Add(1); // 새로운 컬렉션 만들기

        QuestCount.Add(1); // 사막 광부 고용하기
        QuestCount.Add(1); // 사막 40km 돌파
        QuestCount.Add(1); // 사막 원정대 출동
        QuestCount.Add(1); // 사막 로봇 제작하기
        QuestCount.Add(1); // 사막신 만나보기(60km)
        QuestCount.Add(1); // 사막신 만나보기(100km)
        QuestCount.Add(1); // 새로운 조합 찾기
        QuestCount.Add(1); // 얼음맵 가기


        //QuestCount.Add(1); // 얼음맵 40km 돌파
        //QuestCount.Add(1); // 얼음 원정대 출동
        //QuestCount.Add(1); // 얼음 로봇 제작하기
        //QuestCount.Add(1); // 펭귄 만나기
        //QuestCount.Add(1); // 정글맵으로 떠니가

    }
    public void DebugInit()
    {
        int pos = GetCurrentPosData();

        if (pos != -1)
        {
            CheckText(pos);
            MiniQuestObj.SetActive(true);
            gv.bStartMiniQuest = true;
            if (pos == 5 || pos == 2)
            {
                bStartUpdate = true;
            }
            if (pos == 17)
            {
                bHoitStoneUpdate = true;
            }
            if (pos == 16)
            {
                int index = 0;
                for (int i = 0; i < gv.ListHireCount.Count; i++)
                {
                    if (gv.ListHireCount[i] != 0)
                    {
                        index++;
                    }
                }
                SetMiniQuest(16, index);
            }
            if (pos == 22)
            {
                if (gv.DesertDepth >= 4)
                {
                    SetMiniQuest(22, 0);
                }
            }
        }
        else
        {
            MiniQuestObj.SetActive(false);
            gv.bStartMiniQuest = false;
        }
    }
    void Start () {
        int pos = GetCurrentPosData();
        
        if(pos !=-1)
        {
            CheckText(pos);
            MiniQuestObj.SetActive(true);
            gv.bStartMiniQuest = true;
            if (pos == 5 || pos == 2)
            {
                bStartUpdate = true;
            }
            if (pos == 17)
            {
                bHoitStoneUpdate = true;
            }
            if (pos == 16)
            {
                int index = 0;
                for (int i = 0; i < gv.ListHireCount.Count; i++)
                {
                    if (gv.ListHireCount[i] != 0)
                    {
                        index++;
                    }
                }
                SetMiniQuest(16, index);
            }
            if (pos == 22)
            {
                if (gv.DesertDepth >= 4)
                { 
                    SetMiniQuest(22, 0);
                }
            }
            if (pos == 15)
            {
                if (gv.EngineLv >= 4 && gv.BitLv >= 4)
                {
                    SetMiniQuest(15, 0);
                }
                else
                {
                    bCraft = true;
                }
                
            }
        }
        else
        {
            MiniQuestObj.SetActive(false);
            gv.bStartMiniQuest = false;
        }

    }
  
    public void CheckText(int pos)
    {
        Color _color = new Color(255, 0, 0);
        Color _DefaultColor = new Color(255, 255, 255);
        if (gv.MiniQuestIndex[pos] >= QuestCount[pos])
        {
            TextQuest.color = _color;
            MiniQuestObj.GetComponent<Button>().enabled = true;
            if(pos ==0 || pos ==1)
            {
                Finger.SetActive(true);
            }
        }
        else
        {
            TextQuest.color = _DefaultColor;
            MiniQuestObj.GetComponent<Button>().enabled = false;
            Finger.SetActive(false);
        }
        switch (pos)
        {
            case 0:
                TextQuest.text = "Quest 1 - 광부 고용 (" + gv.MiniQuestIndex[pos] + "/" +QuestCount[pos] +")";
                break;
            case 1:
                TextQuest.text = "Quest 2 - 자동판매 포션 사용 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 2:
                TextQuest.text = "Quest 3 - 골드 수집 (" + gv.ChangeMoney(gv.Money) + "/" + gv.ChangeMoney(QuestCount[pos]) + ")";
                break;
            case 3:
                TextQuest.text = "Quest 4 - 엔진 제작 완료 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";                
                break;
            case 4:
                TextQuest.text = "Quest 5 - 터치하여 골드 수집 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 5:
                TextQuest.text = "Quest 6 - 40 Km 돌파";
                break;
            case 6:
                TextQuest.text = "Quest 7 - 광부 업그레이드 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 7:
                TextQuest.text = "Quest 8 - 사다리 게임 승리 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 8:
                TextQuest.text = "Quest 9 - 로또 게임 진행 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 9:
                TextQuest.text = "Quest 10 - 드릴 제작 완료 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 10:
                TextQuest.text = "Quest 11- 새로운 조합 획득 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ") \n - Hint 손땅이 + 슈나우저 -";
                break;

            //여기서 부터 신규
            case 11:
                TextQuest.text = "Quest 12- 우는아이 달래주기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ") \n - 대화하기 -";
                break;
            case 12:               
                TextQuest.text = "Quest 13- 광부 레벨 5 만들기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 13:
                TextQuest.text = "Quest 14- 원정대 출발하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos]+ ")";
                break;
            case 14:
                TextQuest.text = "Quest 15- 도시로봇 제작하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 15:
                TextQuest.text = "Quest 16- 드럼 엔진 & 드릴 제작 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 16:     
                TextQuest.text = "Quest 17- 광부 누적 30명 고용 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 17:
                TextQuest.text = "Quest 18- 호잇스톤 100개 모으기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 18:
                TextQuest.text = "Quest 19- 사막으로 이동하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 19:
                TextQuest.text = "Quest 20- 광부 레벨 7 만들기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 20:
                TextQuest.text = "Quest 21- 새로운 컬렉션 만들기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;

            //사막
            case 21:
                TextQuest.text = "Quest 22- 사막 광부 고용하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 22:               
                            
                TextQuest.text = "Quest 23- 사막 40km 돌파 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 23:
                TextQuest.text = "Quest 24- 사막 왕보석 원정출동 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 24:
                TextQuest.text = "Quest 25- 사막로봇 제작하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 25:
                TextQuest.text = "Quest 26- 사막신 만나보기(50km) (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ") \n - 대화하기 -";
                break;
            case 26:
                TextQuest.text = "Quest 27- 사막신2 만나보기(100km) (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ") \n - 대화하기 -";
                break;
            case 27:
                TextQuest.text = "Quest 28- 새로운 조합 찾기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
            case 28:
                TextQuest.text = "Quest 29- 얼음맵으로 이동하기 (" + gv.MiniQuestIndex[pos] + "/" + QuestCount[pos] + ")";
                break;
        }
    }
    public int GetCurrentPosData()
    {        
        for(int i=0; i< gv.MiniQuestIndex.Count; i++)
        {          
            if(gv.MiniQuestIndex[i] != -9999)
            {
                return i;
            }
        }
        return -1;
    }
    public void SetMiniQuest(int index,float money)
    {
        int currentPos = GetCurrentPosData();
        if(currentPos !=-1)
        {
            if (currentPos == index)
            {
                if (money == 0)
                {
                    gv.MiniQuestIndex[index]++;
                    string strMiniQuest = "MiniQuest" + index;
                    PlayerPrefs.SetFloat(strMiniQuest, gv.MiniQuestIndex[index]);
                    PlayerPrefs.Save();
                    CheckText(index);
                }
                else
                {
                    gv.MiniQuestIndex[index] = money;
                    string strMiniQuest = "MiniQuest" + index;
                    PlayerPrefs.SetFloat(strMiniQuest, gv.MiniQuestIndex[index]);
                    PlayerPrefs.Save();
                    CheckText(index);
                }
            }
        }        
    }
    public void CheckMiniQuest()
    {

    }
    bool bHoitStoneUpdate = false;
    bool bCraft = false;
 
    private void FixedUpdate()
    {
        if(bStartUpdate ==true)
        {
            if(gv.Depth >=4)
            {
                SetMiniQuest(5, 0);
                bStartUpdate = false;
            }
            SetMiniQuest(2,(float)gv.Money);
        }
        if(bHoitStoneUpdate == true)
        {
            SetMiniQuest(17,gv.HoitStoneCount);
        }
        if(bCraft == true)
        {
            if (gv.EngineLv >= 4 && gv.BitLv >= 4)
            {
                SetMiniQuest(15, 0);
            }
        }
    }
    bool bStartUpdate = false;
    
    public void PressCompleteQuest()
    {
        //여기서 선물 뿅~!~!      
        
        int pos = GetCurrentPosData();        
        if (pos >= 0)
        {
            gv.MiniQuestIndex[pos] = -9999;
            string strMiniQuest_2 = "MiniQuest" + pos;
            PlayerPrefs.SetFloat(strMiniQuest_2, gv.MiniQuestIndex[pos]);
            PlayerPrefs.Save();



            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            switch (pos)
            {
                case 0:
                    gv.strGetSomething = "DrillPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 1:
                    gv.strGetSomething = "AutoSell";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    gv.strGetSomething = "MiningPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.MiningPotionTotalCount++;
                    PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 3:
                    gv.strGetSomething = "DrillPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    gv.strGetSomething = "Gold";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 2.0E-15f);
                    break;
                case 5:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 30);
                    SIS.DBManager.IncreaseFunds("blackcoin", 30);
                    break;
                case 6:
                    gv.strGetSomething = "HoitStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 2);
                    gv.HoitStoneCount += 2;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    break;
                case 7:
                    gv.strGetSomething = "Gold";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 6.0E-15f);
                    break;
                case 8:
                    gv.strGetSomething = "AutoSell";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 9:
                    gv.strGetSomething = "DrillPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    gv.bReview = 1;
                    break;
                case 10:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 30);
                    SIS.DBManager.IncreaseFunds("blackcoin", 30);
                    //EndQuest();                   
                    break;

                //여기서 부터 신규
                case 11:
                    gv.strGetSomething = "ZzangPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.ZzangPotionTotalCount += 1;
                    PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 12:
                    gv.strGetSomething = "GodStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 2);
                    gv.GodStoneCount += 2;
                    PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
                    PlayerPrefs.Save();
                    break;
                case 13:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 50);
                    SIS.DBManager.IncreaseFunds("blackcoin", 50);
                    break;
                case 14:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    SIS.DBManager.IncreaseFunds("blackcoin", 100);                    
                    break;
                case 15:
                    gv.strGetSomething = "Gold";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 0.000000001f);
                    bCraft = false;
                    break;
                case 16:
                    gv.strGetSomething = "MinerPotionDouble";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.MiningDoublePotionTotalCount += 1;
                    PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 17:
                    gv.strGetSomething = "HoitStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    gv.HoitStoneCount += 100;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    bHoitStoneUpdate = false;
                    break;
                case 18:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    SIS.DBManager.IncreaseFunds("blackcoin", 100);
                    break;
                case 19:
                    gv.strGetSomething = "GodStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 5);
                    gv.GodStoneCount += 5;
                    PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
                    PlayerPrefs.Save();
                    break;
                case 20:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 200);
                    SIS.DBManager.IncreaseFunds("blackcoin", 200);
                    break;

                //사막 오브젝트
                case 21:
                    gv.strGetSomething = "AutoSellDouble";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.AutoSellDoublePotionTotalCount += 1;
                    PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 22:
                    gv.strGetSomething = "SalePotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.SalePotionTotalCount += 1;
                    PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 23:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 50);
                    SIS.DBManager.IncreaseFunds("blackcoin", 50);
                    break;
                case 24:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    SIS.DBManager.IncreaseFunds("blackcoin", 100);
                    break;
                case 25:
                    gv.strGetSomething = "HoitStone";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    gv.HoitStoneCount += 100;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    break;
                case 26:
                    gv.strGetSomething = "ZzangPotion";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);
                    gv.ZzangPotionTotalCount += 1;
                    PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 27:
                    gv.strGetSomething = "AtoSS";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);             
                    break;
                case 28:
                    gv.strGetSomething = "BlackCoin";
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 100);
                    SIS.DBManager.IncreaseFunds("blackcoin", 100);
                    EndQuest();
                    break;
            }
        }
        int nextpos = GetCurrentPosData();
        if(nextpos <0)
        {

        }
        else
        {
            CheckText(nextpos);
            if (nextpos == 5 || nextpos == 2)
            {
                bStartUpdate = true;
            }
            else
            {
                bStartUpdate = false;
            }
            if(nextpos == 16)
            {
                int index = 0;
                for (int i = 0; i < gv.ListHireCount.Count; i++)
                {
                    if (gv.ListHireCount[i] != 0)
                    {
                        index++;
                    }
                }
                SetMiniQuest(16, index);
            }
            if (nextpos == 22)
            {
                if (gv.DesertDepth >= 4)
                {
                    SetMiniQuest(22, 0);
                }
            }
            if(nextpos ==17)
            {
                bHoitStoneUpdate = true;
            }
            else
            {
                bHoitStoneUpdate = false;
            }
            if(nextpos == 15)
            {
                if (gv.EngineLv >= 4 && gv.BitLv >= 4)
                {
                   SetMiniQuest(15, 0);
                }
                else
                {
                    bCraft = true;
                }
            }
            else
            {
                bCraft = false;
            }
        }   
    }
    void EndQuest()
    {
        MiniQuestObj.SetActive(false);
        StartCoroutine(FalseView());
        gv.bStartMiniQuest = false;
    }
    IEnumerator FalseView()
    {
        if (MiniQuestObj.activeSelf == true)
        {
            StartCoroutine(FalseView());
            MiniQuestObj.SetActive(false);
        }
        yield return new WaitForSeconds(0.5f);
    }
	// Update is called once per frame
	void Update () {
		
	}
}
