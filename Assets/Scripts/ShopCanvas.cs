using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ShopCanvas : MonoBehaviour
{
    public GameObject ManagerPackStamp;
    public GameObject DrillManagerStamp;
    public GameObject LowManagerStamp;
    public GameObject MiddleManagerStamp;
    public GameObject HighManagerStamp;


    public GameObject ManagerPackPanel;
    public GameObject DrillManagerPanel;
    public GameObject MainStatusObj;
    public GameObject MainCameraObj;

    public Text AdsMinerText;
    public Text MoneyMinerText;
    public Text MoneyText_miner;

    public GameObject CoinPack1Obj;
    public GameObject CoinPack2Obj;
    public GameObject isCoinPack1;
    public GameObject isCoinPack2;

    public GameObject isCostPack;
    public GameObject isMiddlePack;
    public GameObject isHighPack;
    public GameObject isUltraPack;

    public GameObject isStartPack;
    public GameObject isMiner1Pack;
    public GameObject isMiner2Pack;
    public GameObject isMiner3Pack;

    public GameObject Tab1;
    public GameObject Tab2;
    public GameObject Tab3;
    public GameObject Tab4;
    public GameObject Tab5;

    public GameObject SelectTab1;
    public GameObject SelectTab2;
    public GameObject SelectTab3;
    public GameObject SelectTab4;
    public GameObject SelectTab5;

    public GameObject ImgTab1;
    public GameObject ImgTab2;
    public GameObject ImgTab3;
    public GameObject ImgTab4;
    public GameObject ImgTab5;

    public List<GameObject> CompleteList;
    public Text CompleteText;
    public GameObject CompleteBuyObj;
    public GameObject SpeacialPack1;
    public GameObject SpeacialPack2;
    public GameObject CostEffectivnessPack;
    public GameObject MiddlePack;
    public GameObject HightPack;
    public GameObject UltraPack;

    public GameObject MinerPotion;
    public GameObject DrillPotion;
    public GameObject SalePotion;

    public GameObject GoodGoodPotion;
    public GameObject SkillCoolPotion;
    public GameObject RandomPotion;

    public GameObject EternalSale;
    public GameObject ReturnSale;

    public GameObject StartPack;
    public GameObject LowMinerPack;
    public GameObject MiddleMinerPack;
    public GameObject HighMinerPack;

    public GameObject LowManager;
    public GameObject MiddleManager;
    public GameObject HightManager;


    public GameObject StarterPackObj;
    public GameObject lowMInerPackObj;
    public GameObject MiddleMinerPackObj;
    public GameObject HighMinerPackObj;

    public GameObject LowManagerObj;
    public GameObject MiddleManagerObj;
    public GameObject HighManagerObj;

    public GameObject NinjaObj;
    public GameObject Ninja2Obj;
    public GameObject DinoObj;
    public GameObject PandaObj;

    public GameObject RandomMinerPack1;
    public GameObject RandomMinerPack2;
    public GameObject RandomMinerPack3;

    public GameObject SpecialMinerPack1;
    public GameObject SpecialMinerPack2;

    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {


    }


    private void FixedUpdate()
    {
        if (gv.TotalBuyRandomMiner1 == 8)
        {
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalBuyRandomMiner1Time", 86400) == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalBuyRandomMiner1Time", MoneyMinerText, 86400);
            }
            else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalBuyRandomMiner1Time", 86400) == -1
                && gv.TotalBuyRandomMiner1 >= 3)
            {
                gv.TotalBuyRandomMiner1 = 0;
                PlayerPrefs.SetInt("TotalBuyRandomMiner1", gv.TotalBuyRandomMiner1);
                PlayerPrefs.Save();
                MoneyMinerText.text = "매일\n(" + gv.TotalBuyRandomMiner1 + "/3)";
                SetTextMinerText();
            }
            
        }
        else if (gv.TotalBuyRandomMiner1 < 3)
        {
            MoneyMinerText.text = "매일\n(" + gv.TotalBuyRandomMiner1 + "/3)";
            float money = (gv.GetMoneyPos()/50) * (gv.TotalBuyRandomMiner1 + 1);
            MoneyText_miner.text = gv.ChangeMoney(money);
        }

        if (gv.TotalAdsRandomMiner1 == 8)
        {
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalAdsRandomMiner1Time", 86400) == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalAdsRandomMiner1Time", AdsMinerText, 86400);
            }
            else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("TotalAdsRandomMiner1Time", 86400) == -1
                && gv.TotalAdsRandomMiner1 >= 3)
            {
                gv.TotalAdsRandomMiner1 = 0;
                PlayerPrefs.SetInt("TotalAdsRandomMiner1", gv.TotalAdsRandomMiner1);
                PlayerPrefs.Save();
                AdsMinerText.text = "매일\n(" + gv.TotalAdsRandomMiner1 + "/3)";
                SetTextMinerText();
            }
            
        }
        else if (gv.TotalAdsRandomMiner1 < 3)
        {
            AdsMinerText.text = "매일\n(" + gv.TotalAdsRandomMiner1 + "/3)";
        }

    }
    public void SetTextMinerText()
    {
        if (gv.TotalBuyRandomMiner1 == 8)
        {            
            MoneyMinerText.text = "일일 사용 초과";
        }
        else
        {            
            MoneyMinerText.text = "매일\n(" + gv.TotalBuyRandomMiner1 + "/3)";
        }
        if(gv.TotalAdsRandomMiner1 ==8)
        {
            AdsMinerText.text = "일일 사용 초과";
        }
        else
        {
            AdsMinerText.text = "매일\n(" + gv.TotalAdsRandomMiner1 + "/3)";
        }
        
        int depth_Pos =1;
        if(gv.Depth <=1)
        {
            depth_Pos = 1;
        }
        else
        {
            depth_Pos = gv.Depth;
        }
        float money = (gv.GetMoneyPos()/50) * (gv.TotalBuyRandomMiner1 + 1);
        MoneyText_miner.text = gv.ChangeMoney(money);
    }

    public void BuyAdsRandomMiner()
    {
        //
        if (gv.TotalAdsRandomMiner1 < 3)
        {
            MainCameraObj.GetComponent<AdManager>().ShowReward(565);
        }
    }
    public void AdsRandmomSet()
    {
        if (gv.TotalAdsRandomMiner1 == 3)
        {
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("TotalAdsRandomMiner1Time", 86400);
            gv.TotalAdsRandomMiner1 = 8;
            PlayerPrefs.SetInt("TotalAdsRandomMiner1", gv.TotalAdsRandomMiner1);
            PlayerPrefs.Save();
        }
        if (gv.TotalAdsRandomMiner1 < 3)
            SetTextMinerText();
    }
    public void BuyDailyRandomMiner()
    {
        //
        //float money = (gv.GetMoneyPos() / 50) * (gv.TotalBuyRandomMiner1 + 1);
        //MoneyText_miner.text = gv.ChangeMoney(money);

        if (gv.TotalBuyRandomMiner1 < 3)
        {
            //buy
            float cost = 0;
            //if (gv.MapType == 1)
            //{
            //    cost = gv.ListCostMinerals[gv.Depth - 1] * 10000000;
            //}
            //if (gv.MapType == 2)
            //{
            //    cost = gv.ListCostMinerals[gv.DesertDepth - 1] * 10000000;
            //}
            //if (gv.MapType == 3)
            //{
            //    cost = gv.ListCostMinerals[gv.IceDepth - 1] * 10000000;
            //}
            //if (gv.MapType == 4)
            //{
            //    cost = gv.ListCostMinerals[gv.ForestDepth - 1] * 10000000;
            //}

            cost = (gv.GetMoneyPos() / 50) * (gv.TotalBuyRandomMiner1 + 1);


            //float money = (float)(cost) * (gv.TotalBuyRandomMiner1 + 1);
            float money = cost;
            if (gv.Money >= money)
            {
                gv.Money -= money;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);

                gv.TotalBuyRandomMiner1++;
                PlayerPrefs.SetInt("TotalBuyRandomMiner1", gv.TotalBuyRandomMiner1);
                PlayerPrefs.Save();
                gv.strGetSomething = "Miner1";
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressGetSomethingObj(1, 1);

            }
            else
            {
                MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "골드가 부족합니다.");
            }
        }
        if (gv.TotalBuyRandomMiner1 == 3)
        {
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("TotalBuyRandomMiner1Time", 86400);
            gv.TotalBuyRandomMiner1 = 8;
            PlayerPrefs.SetInt("TotalBuyRandomMiner1", gv.TotalBuyRandomMiner1);
            PlayerPrefs.Save();
        }
        if (gv.TotalBuyRandomMiner1 < 3)
            SetTextMinerText();
    }

    public void SelectTab(int i)
    {
        if (i == 0)
        {

            SelectTab1.SetActive(true);
            SelectTab2.SetActive(false);
            SelectTab3.SetActive(false);
            SelectTab4.SetActive(false);
            SelectTab5.SetActive(false);

            ImgTab1.SetActive(true);
            ImgTab2.SetActive(false);
            ImgTab3.SetActive(false);
            ImgTab4.SetActive(false);
            ImgTab5.SetActive(false);
        }
        if (i == 1)
        {


            SelectTab2.SetActive(true);
            SelectTab1.SetActive(false);
            SelectTab3.SetActive(false);
            SelectTab4.SetActive(false);
            SelectTab5.SetActive(false);

            ImgTab2.SetActive(true);
            ImgTab1.SetActive(false);
            ImgTab3.SetActive(false);
            ImgTab4.SetActive(false);
            ImgTab5.SetActive(false);
        }
        if (i == 2)
        {


            SelectTab3.SetActive(true);
            SelectTab2.SetActive(false);
            SelectTab1.SetActive(false);
            SelectTab4.SetActive(false);
            SelectTab5.SetActive(false);

            ImgTab3.SetActive(true);
            ImgTab2.SetActive(false);
            ImgTab1.SetActive(false);
            ImgTab4.SetActive(false);
            ImgTab5.SetActive(false);
        }
        if (i == 3)
        {


            SelectTab4.SetActive(true);
            SelectTab2.SetActive(false);
            SelectTab3.SetActive(false);
            SelectTab1.SetActive(false);
            SelectTab5.SetActive(false);

            ImgTab4.SetActive(true);
            ImgTab2.SetActive(false);
            ImgTab3.SetActive(false);
            ImgTab1.SetActive(false);
            ImgTab5.SetActive(false);
        }
        if (i == 4)
        {
            SelectTab5.SetActive(true);
            SelectTab2.SetActive(false);
            SelectTab3.SetActive(false);
            SelectTab4.SetActive(false);
            SelectTab1.SetActive(false);

            ImgTab5.SetActive(true);
            ImgTab2.SetActive(false);
            ImgTab3.SetActive(false);
            ImgTab4.SetActive(false);
            ImgTab1.SetActive(false);
        }
    }


    public void SetView()
    {
        if (gv.isCoinPack1 == 1)
        {
            isCoinPack1.SetActive(false);
        }
        if (gv.isCoinPack2 == 1)
        {
            isCoinPack2.SetActive(false);
        }
        if (gv.isBuyCostPack == 1)
        {
            isCostPack.SetActive(false);
        }
        if (gv.isMiddelSpecialPack == 1)
        {
            isMiddlePack.SetActive(false);
        }
        if (gv.isHighSpecialPack == 1)
        {
            isHighPack.SetActive(false);
        }
        if (gv.isSperHighSpecialPack == 1)
        {
            isUltraPack.SetActive(false);
        }
        if (gv.isStaterPack == 1)
        {
            isStartPack.SetActive(false);
        }
        if (gv.isMinerPack1 == 1)
        {
            isMiner1Pack.SetActive(false);
        }
        if (gv.isMinerPack2 == 1)
        {
            isMiner2Pack.SetActive(false);
        }
        if (gv.isMinerPack3 == 1)
        {
            isMiner3Pack.SetActive(false);
        }

    }

    public void PressCoinPack1(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CoinPack1Obj, "CoinPack1Obj");
            CoinPack1Obj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CoinPack1Obj");
            CoinPack1Obj.SetActive(false);
        }
    }
    public void PressCoinPack2(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CoinPack2Obj, "CoinPack2Obj");
            CoinPack2Obj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CoinPack2Obj");
            CoinPack2Obj.SetActive(false);
        }
    }


    public void PressStaterPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(StarterPackObj, "StarterPackObj");
            StarterPackObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("StarterPackObj");
            StarterPackObj.SetActive(false);
        }
    }
    public void PressManagerPack(int i)
    {
        if (gv.ManagerPackStatus == 0)
        {
            if (i == 1)
            {
                gv.AddPanelPopup(lowMInerPackObj, "ManagerPackPanel");
                ManagerPackPanel.SetActive(true);
            }
            else
            {
                gv.DeletePanelPopup("ManagerPackPanel");
                ManagerPackPanel.SetActive(false);
            }
        }
        else
        {
            gv.DeletePanelPopup("ManagerPackPanel");
            ManagerPackPanel.SetActive(false);
        }
    }

    public void PressDrillManagerPack(int i)
    {
        if (gv.DrillManagerStatus == 0)
        {
            if (i == 1)
            {
                gv.AddPanelPopup(lowMInerPackObj, "DrillManagerPanel");
                DrillManagerPanel.SetActive(true);
            }
            else
            {
                gv.DeletePanelPopup("DrillManagerPanel");
                DrillManagerPanel.SetActive(false);
            }
        }
        else
        {
            gv.DeletePanelPopup("DrillManagerPanel");
            DrillManagerPanel.SetActive(false);
        }
    }
    public void PresslowMInerPack(int i)
    {       
        if (i == 1)
        {
            gv.AddPanelPopup(lowMInerPackObj, "lowMInerPackObj");
            lowMInerPackObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("lowMInerPackObj");
            lowMInerPackObj.SetActive(false);
        }   
    }
    public void PressMiddleMinerPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(MiddleMinerPackObj, "MiddleMinerPackObj");
            MiddleMinerPackObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("MiddleMinerPackObj");
            MiddleMinerPackObj.SetActive(false);
        }
    }
    public void PressHighMinerPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(HighMinerPackObj, "HighMinerPackObj");
            HighMinerPackObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("HighMinerPackObj");
            HighMinerPackObj.SetActive(false);
        }
    }

    public void PressLowManager(int i)
    {
        if (gv.ManagerStatus1 == 0)
        {
            if (i == 1)
            {
                gv.AddPanelPopup(LowManagerObj, "LowManagerObj");
                LowManagerObj.SetActive(true);
            }
            else
            {
                gv.DeletePanelPopup("LowManagerObj");
                LowManagerObj.SetActive(false);
            }
        }
        else
        {
            gv.DeletePanelPopup("LowManagerObj");
            LowManagerObj.SetActive(false);
        }
    }
    public void PressMiddleManager(int i)
    {
        if (gv.ManagerStatus2 == 0)
        {
            if (i == 1)
            {
                gv.AddPanelPopup(MiddleManagerObj, "MiddleManagerObj");
                MiddleManagerObj.SetActive(true);
            }
            else
            {
                gv.DeletePanelPopup("MiddleManagerObj");
                MiddleManagerObj.SetActive(false);
            }
        }
        else
        {
            gv.DeletePanelPopup("MiddleManagerObj");
            MiddleManagerObj.SetActive(false);
        }
    }
    public void PressHighManager(int i)
    {
        if (gv.ManagerStatus3 == 0)
        {
            if (i == 1)
            {
                gv.AddPanelPopup(HighManagerObj, "HighManagerObj");
                HighManagerObj.SetActive(true);
            }
            else
            {
                gv.DeletePanelPopup("HighManagerObj");
                HighManagerObj.SetActive(false);
            }
        }
        else
        {
            gv.DeletePanelPopup("HighManagerObj");
            HighManagerObj.SetActive(false);
        }
    }

    public void PressNinja(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(NinjaObj, "NinjaObj");
            NinjaObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("NinjaObj");
            NinjaObj.SetActive(false);
        }
    }
    public void PressNinja2(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(Ninja2Obj, "Ninja2Obj");
            Ninja2Obj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("Ninja2Obj");
            Ninja2Obj.SetActive(false);
        }
    }
    public void PressDino(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(DinoObj, "DinoObj");
            DinoObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("DinoObj");
            DinoObj.SetActive(false);
        }
    }
    public void PressPanda(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PandaObj, "PandaObj");
            PandaObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("PandaObj");
            PandaObj.SetActive(false);
        }
    }

    public void PressRandomMinerPack1(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RandomMinerPack1, "RandomMinerPack1");
            RandomMinerPack1.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("RandomMinerPack1");
            RandomMinerPack1.SetActive(false);
        }
    }
    public void PressRandomMinerPack2(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RandomMinerPack2, "RandomMinerPack2");
            RandomMinerPack2.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("RandomMinerPack2");
            RandomMinerPack2.SetActive(false);
        }
    }
    public void PressRandomMinerPack3(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RandomMinerPack3, "RandomMinerPack3");
            RandomMinerPack3.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("RandomMinerPack3");
            RandomMinerPack3.SetActive(false);
        }
    }

    public void PressSpecialMinerPack1(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SpecialMinerPack1, "SpecialMinerPack1");
            SpecialMinerPack1.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SpecialMinerPack1");
            SpecialMinerPack1.SetActive(false);
        }
    }
    public void PressSpecialMinerPack2(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SpecialMinerPack2, "SpecialMinerPack2");
            SpecialMinerPack2.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SpecialMinerPack2");
            SpecialMinerPack2.SetActive(false);
        }
    }

    public void PressCostEffectivenessPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CostEffectivnessPack, "CostEffectivnessPack");
            CostEffectivnessPack.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CostEffectivnessPack");
            CostEffectivnessPack.SetActive(false);
        }
    }

    public void PressMiddlePack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(MiddlePack, "MiddlePack");
            MiddlePack.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("MiddlePack");
            MiddlePack.SetActive(false);
        }
    }

    public void PressHightPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(HightPack, "HightPack");
            HightPack.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("HightPack");
            HightPack.SetActive(false);
        }
    }

    public void PressUltraPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(UltraPack, "UltraPack");
            UltraPack.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("UltraPack");
            UltraPack.SetActive(false);
        }
    }

    private void OnEnable()
    {
        SetTextMinerText();
        PressMinerPotion(0);
        PressDrillPotion(0);
        PressSalePotion(0);
        PressGoodGoodPotion(0);
        PressSkillCoolPotionPack(0);
        PressRandomPotionPack(0);
        temp = false;
        SetStamp();
    }
    public void SetStamp()
    {
        if(gv.ManagerStatus1 == 1)
        {
            LowManagerStamp.SetActive(true);
        }
        if (gv.ManagerStatus2 == 1)
        {
            MiddleManagerStamp.SetActive(true);
        }
        if (gv.ManagerStatus3 == 1)
        {
            HighManagerStamp.SetActive(true);
        }

        if (gv.DrillManagerStatus == 1)
        {
            DrillManagerStamp.SetActive(true);
        }

        if (gv.DrillManagerStatus == 1 && gv.ManagerStatus3 == 1)
        {
            ManagerPackStamp.SetActive(true);
        }
    }
    public void PressMinerPotion(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(MinerPotion, "MinerPotion");
            MinerPotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("MinerPotion");
            MinerPotion.SetActive(false);
        }
    }

    public void PressDrillPotion(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(DrillPotion, "DrillPotion");
            DrillPotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("DrillPotion");
            DrillPotion.SetActive(false);
        }
    }

    public void PressSalePotion(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SalePotion, "SalePotion");
            SalePotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SalePotion");
            SalePotion.SetActive(false);
        }
    }


    public void PressGoodGoodPotion(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(GoodGoodPotion, "GoodGoodPotion");
            GoodGoodPotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("GoodGoodPotion");
            GoodGoodPotion.SetActive(false);
        }
    }

    public void PressSkillCoolPotionPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SkillCoolPotion, "SkillCoolPotion");
            SkillCoolPotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SkillCoolPotion");
            SkillCoolPotion.SetActive(false);
        }
    }

    public void PressRandomPotionPack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RandomPotion, "RandomPotion");
            RandomPotion.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("RandomPotion");
            RandomPotion.SetActive(false);
        }
    }


    public void PressEternalSalePack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(EternalSale, "EternalSale");
            EternalSale.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("EternalSale");
            EternalSale.SetActive(false);
        }
    }

    public void PressReturnSalePack(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(ReturnSale, "ReturnSale");
            ReturnSale.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("ReturnSale");
            ReturnSale.SetActive(false);
        }
    }

    public void PressSpeacialPack1(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SpeacialPack1, "SpeacialPack1");
            SpeacialPack1.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SpeacialPack1");
            SpeacialPack1.SetActive(false);
        }
    }

    public void PressSpeacialPack2(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(SpeacialPack2, "SpeacialPack2");
            SpeacialPack2.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SpeacialPack2");
            SpeacialPack2.SetActive(false);
        }
    }


    public void PressCompleteBuy(int i, int Pos)
    {
        if (i == 1)
        {
            if (Pos > 0)
            {
                gv.AddPanelPopup(CompleteBuyObj, "CompleteBuyObj");
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Open");
                CompleteBuyObj.SetActive(true);
            }
        }
        else
        {
            gv.DeletePanelPopup("CompleteBuyObj");
            CompleteBuyObj.SetActive(false);
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(4);

        }
    }
    bool temp = false;

    private void OnDisable()
    {
        temp = true;
    }
    public void PressCompleteBuy(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CompleteBuyObj, "CompleteBuyObj");
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Open");
            CompleteBuyObj.SetActive(true);
        }
        else
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(4);
            gv.DeletePanelPopup("CompleteBuyObj");
            for (int k = 0; k < CompleteList.Count; k++)
            {
                CompleteList[k].SetActive(false);
            }
            CompleteBuyObj.SetActive(false);
            if (gv.PakageCardType > 0)
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, gv.PakageCardType);
            if (gv.PakageCardType == 6)
            {
                gv.PakageCardType = 5;
            }
            else
            {
                gv.PakageCardType = 0;
            }
            //if (gv.CardGetType != 0)
            //{
            //    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
            //}

        }
    }
 

    public void setIAPItem(int i)
    {
        for (int k = 0; k < CompleteList.Count; k++)
        {
            CompleteList[k].SetActive(false);
        }

        if (gv.selectIAPitem > 0)
        {
            if (gv.selectIAPitem <= CompleteList.Count)
            {
                //여기 랜덤버프 부터 순서 늘려야됨               
                CompleteList[gv.selectIAPitem - 1].SetActive(true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextShopItem("kor", CompleteText, gv.selectIAPitem - 1);
            }
            if (i != 0)
            {
                if (gv.selectIAPitem == 1)
                {
                    PressCostEffectivenessPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyCostEffectivenessPack();
                }
                if (gv.selectIAPitem == 2)
                {
                    PressMiddlePack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyMiddleSpeacialPack();
                }
                if (gv.selectIAPitem == 3)
                {
                    PressHightPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyHighSpecialPack();
                }
                if (gv.selectIAPitem == 4)
                {
                    PressUltraPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuySpecialSpecialPack();
                }


                if (gv.selectIAPitem == 5)
                {
                    PressStaterPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyStarterPack();
                }
                if (gv.selectIAPitem == 6)
                {
                    PresslowMInerPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuylowMinerPack();
                }
                if (gv.selectIAPitem == 7)
                {
                    PressMiddleMinerPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyMiddleMinerPack();
                }
                if (gv.selectIAPitem == 8)
                {
                    PressHighMinerPack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyHighMinerPack();
                }


                if (gv.selectIAPitem == 9)
                {
                    PressLowManager(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyLowManager();
                }
                if (gv.selectIAPitem == 10)
                {
                    PressMiddleManager(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyMiddleMnanager();
                }
                if (gv.selectIAPitem == 11)
                {
                    PressHighManager(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyHighManager();
                }

                if (gv.selectIAPitem == 47)
                {
                    PressMiddleManager(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyDrillManager();
                }
                if (gv.selectIAPitem == 48)
                {
                    PressHighManager(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyManagerPack();
                }


                if (gv.selectIAPitem == 12)
                {
                    //blackcoin1
                    //SIS.DBManager.IncreaseFunds("blackcoin", 300);
                }
                if (gv.selectIAPitem == 13)
                {
                    //blackcoin2
                    PressCoinPack1(0);
                    //SIS.DBManager.IncreaseFunds("blackcoin", 500);
                }
                if (gv.selectIAPitem == 14)
                {
                    //blackcoin3
                    PressCoinPack2(0);
                    //SIS.DBManager.IncreaseFunds("blackcoin", 2000);
                }
                if (gv.selectIAPitem == 15)
                {
                    //blackcoin4
                    //SIS.DBManager.IncreaseFunds("blackcoin", 6500);
                }
                if (gv.selectIAPitem == 16)
                {
                    //blackcoin5
                    //SIS.DBManager.IncreaseFunds("blackcoin", 12000);
                }
                if (gv.selectIAPitem == 17)
                {
                    //blackcoin6
                    //SIS.DBManager.IncreaseFunds("blackcoin", 25000);
                }

                if (gv.selectIAPitem == 18)
                {
                    PressNinja(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyNinja();
                }
                if (gv.selectIAPitem == 19)
                {
                    PressNinja2(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyNinja2();
                }
                if (gv.selectIAPitem == 20)
                {
                    PressDino(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyDino();
                }
                if (gv.selectIAPitem == 21)
                {
                    PressPanda(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyPanda();
                }

                if (gv.selectIAPitem == 22)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyMiningPotion(1);
                }
                if (gv.selectIAPitem == 23)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyMiningPotion(2);
                }
                if (gv.selectIAPitem == 24)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyDrillPotion(1);
                }
                if (gv.selectIAPitem == 25)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyDrillPotion(2);
                }
                if (gv.selectIAPitem == 26)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuySalePotion(1);
                }
                if (gv.selectIAPitem == 27)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuySalePotion(2);
                }
                if (gv.selectIAPitem == 28)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyZaangPotion(1);
                }
                if (gv.selectIAPitem == 29)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyZaangPotion(2);
                }
                if (gv.selectIAPitem == 30)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyBuffPotion(1);
                }
                if (gv.selectIAPitem == 31)
                {
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyBuffPotion(2);
                }
                if (gv.selectIAPitem == 32)
                {
                    //자동 판매 포션
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyAutoSellPotion(1);
                }
                if (gv.selectIAPitem == 33)
                {
                    //자동 판매 포션
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().BuyAutoSellPotion(2);
                }


                if (gv.selectIAPitem == 34)
                {
                    PressEternalSalePack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyCertificateGold();
                }
                if (gv.selectIAPitem == 35)
                {
                    PressReturnSalePack(0);
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyCertificateTime();
                }


                if (gv.selectIAPitem == 36)
                {
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyGold(1);
                }
                if (gv.selectIAPitem == 37)
                {
                    GameObject.Find("Main Camera").GetComponent<InappUIManager>().BuyGold(2);
                }
            }
            if (i == 0)
            {
                if (gv.selectIAPitem == 38)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
                }
                if (gv.selectIAPitem == 39)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 2);
                }

                if (gv.selectIAPitem == 40)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 3);
                }
                if (gv.selectIAPitem == 43)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 4);
                }

                if (gv.selectIAPitem == 44)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 5);
                }
                if (gv.selectIAPitem == 41)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 6);
                }

                if (gv.selectIAPitem == 42)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 7);
                }

                if (gv.selectIAPitem == 45)
                {
                    gv.GodStoneCount += 5;
                    PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
                    PlayerPrefs.Save();
                }
                if (gv.selectIAPitem == 46)
                {
                    gv.GodStoneCount += 12;                    
                    PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
                    PlayerPrefs.Save();
                }

                gv.selectIAPitem = 0;
            }
            
        }

    }

}

