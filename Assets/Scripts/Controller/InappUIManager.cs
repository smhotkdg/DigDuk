using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class InappUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public Text TextMoney1;
    public Text TextMoney2;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
 
    public void SetMoney()
    {      
        TextMoney1.text = gv.ChangeMoney(gv.GetMoneyPos() * 5);
        TextMoney2.text = gv.ChangeMoney(gv.GetMoneyPos() * 50);
    }
    //스타터팩 1회 한정
    public void BuyStarterPack()
    {

        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 500);


        gv.SaleDoublePotionTotalCount +=5;
        gv.DrillDoublePotionTotalCount +=5;
        gv.AutoSellDoublePotionTotalCount += 5;
        PlayerPrefs.SetInt("SaleDoublePotionTotalCount", gv.SaleDoublePotionTotalCount);
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.Save();
        //GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 30);
        gv.isStaterPack = 1;
        PlayerPrefs.SetInt("isStaterPack", gv.isStaterPack);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //초급마이너팩 1회 한정
    public void BuylowMinerPack()
    {
        int hireNum = 104;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }


        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 300);        
        gv.MiningDoublePotionTotalCount += 2;        
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.Save();

        gv.isMinerPack1 = 1;
        PlayerPrefs.SetInt("isMinerPack1", gv.isMinerPack1);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //중급 마이너팩 1회 한정
    public void BuyMiddleMinerPack()
    {
        int hireNum = 101;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }


        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 500);        
        gv.MiningDoublePotionTotalCount += 4;        
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.Save();

        gv.isMinerPack2 = 1;
        PlayerPrefs.SetInt("isMinerPack2", gv.isMinerPack2);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //고급 마이너팩 1회 한정
    public void BuyHighMinerPack()
    {
        int hireNum = 103;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }



        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 1100);
        
        gv.MiningDoublePotionTotalCount += 4;        
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.Save();

        gv.isMinerPack3 = 1;
        PlayerPrefs.SetInt("isMinerPack3", gv.isMinerPack3);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);

        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //하급 매니저
    public void BuyLowManager()
    {
        gv.ManagerStatus1 = 1;
        PlayerPrefs.SetInt("ManagerStatus1", gv.ManagerStatus1);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().AutoSell();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().InitRutin();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetStamp();
    }
    //중급 매니저
    public void BuyMiddleMnanager()
    {
        gv.ManagerStatus2 = 1;
        PlayerPrefs.SetInt("ManagerStatus2", gv.ManagerStatus2);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().AutoSell();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().InitRutin();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetStamp();
    }
    //고급 매니저
    public void BuyHighManager()
    {
        gv.ManagerStatus3 = 1;
        PlayerPrefs.SetInt("ManagerStatus3", gv.ManagerStatus3);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().AutoSell();
        GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().InitRutin();

        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetStamp();
    }

    public void BuyDrillManager()
    {
        gv.DrillManagerStatus = 1;
        gv.DrillBuffPower += 20;
        PlayerPrefs.SetInt("DrillManagerStatus", gv.DrillManagerStatus);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetStamp();

        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetDrillManager();
    }
    public void BuyManagerPack()
    {
        BuyDrillManager();
        BuyHighManager();

        gv.ManagerPackStatus = 1;
        PlayerPrefs.SetInt("ManagerPackStatus", gv.ManagerPackStatus);
        PlayerPrefs.Save();
    }
    public void BuyNinja()
    {
        int hireNum = 97;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);

        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);

        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);

        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);

        }



        PlayerPrefs.Save();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyNinja2()
    {
        int hireNum = 98;
        if(gv.MapType==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }

        PlayerPrefs.Save();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyDino()
    {
        int hireNum = 99;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }

        PlayerPrefs.Save();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyPanda()
    {
        int hireNum = 100;
        if(gv.MapType ==1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }

        PlayerPrefs.Save();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressShop(0);
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }

    public void BuyRandomMinerPack1()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyRandomMinerPack2()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyRandomMinerPack3()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }

    public void BuySpecialMinerPack1()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuySpecialMinerPack2()
    {

    }
    public void BuyAtoSSMinerPack1()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    public void BuyAtoSSMinerPack2()
    {
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }

    public void BuyBlackCoin(int i)
    {

    }
    public void BuyPotion(int i)
    {
        
    }

    public void BuyGold(int i)
    {
        if(i ==1)
        {
            //10배
            gv.Money += gv.GetMoneyPos() * 5;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
        if(i ==2)
        {
            //100배
            gv.Money += gv.GetMoneyPos() * 50;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
    }
    //가성비팩 1회 한정
    public void BuyCostEffectivenessPack()
    {
        //람보
        int hireNum = 105;
        if (gv.MapType == 1)
        {
            if (gv.ListHireCount[hireNum - 1] < 0 || gv.ListHireCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[hireNum - 1] < 0 || gv.ListHireDesertCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[hireNum - 1] < 0 || gv.ListHireIceCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[hireNum - 1] < 0 || gv.ListHireForestCount[hireNum - 1] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[hireNum - 1] = 1;
                int index = hireNum;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[hireNum - 1]);
                PlayerPrefs.Save();
            }
            gv.ListHireCardOwnCount[hireNum - 1] += 1;
            int indexCard = hireNum;
            string strHireCardCount = "HireCardCount" + indexCard;
            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[hireNum - 1]);
        }


        gv.MiningDoublePotionTotalCount += 2;
        gv.DrillDoublePotionTotalCount += 2;
        gv.AutoSellDoublePotionTotalCount +=5;
        gv.ZzangDoublePotionTotalCount += 1;
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);

        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 1100);
        PlayerPrefs.Save();

        gv.isBuyCostPack = 1;
        PlayerPrefs.SetInt("isBuyCostPack", gv.isBuyCostPack);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        //gv.CardGetType = 3;
        gv.PakageCardType = 4;        

        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }

    //중급스패셜 1회 한정
    public void BuyMiddleSpeacialPack()
    {
        BuyNinja();

        gv.MiningDoublePotionTotalCount += 2;
        gv.DrillDoublePotionTotalCount += 2;
        gv.AutoSellDoublePotionTotalCount += 2;
        gv.ZzangDoublePotionTotalCount += 2;
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);


        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 1100);
        PlayerPrefs.Save();

        gv.isMiddelSpecialPack = 1;
        PlayerPrefs.SetInt("isMiddelSpecialPack", gv.isMiddelSpecialPack);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        gv.PakageCardType = 4;
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //고급 스패셜 1회 한정
    public void BuyHighSpecialPack()
    {
        //BuyNinja();
        BuyNinja2();

        gv.MiningDoublePotionTotalCount += 4;
        gv.DrillDoublePotionTotalCount += 4;
        gv.AutoSellDoublePotionTotalCount += 4;
        gv.ZzangDoublePotionTotalCount += 4;

        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);

        gv.isHighSpecialPack = 1;
        PlayerPrefs.SetInt("isHighSpecialPack", gv.isHighSpecialPack);
        PlayerPrefs.Save();
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 3500);
        PlayerPrefs.Save();

        gv.PakageCardType = 5;

        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }
    //최고급 1회 한정
    public void BuySpecialSpecialPack()
    {

        BuyDino();
        BuyPanda();

   


        gv.MiningDoublePotionTotalCount += 4;
        gv.DrillDoublePotionTotalCount += 4;
        gv.AutoSellDoublePotionTotalCount += 4;
        gv.ZzangDoublePotionTotalCount += 4;

        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);

        gv.isSperHighSpecialPack = 1;
        PlayerPrefs.SetInt("isSperHighSpecialPack", gv.isSperHighSpecialPack);
        PlayerPrefs.Save();

        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        SIS.DBManager.IncreaseFunds("blackcoin", 6200);
        PlayerPrefs.Save();

        gv.PakageCardType =6;

        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();
    }

    public void BuyCertificateGold()
    {
        gv.CertificateGold = 1;
        PlayerPrefs.SetInt("CertificateGold", gv.CertificateGold);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().CheckCertification();
    }
    public void BuyCertificateTime()
    {
        gv.CertificateTime = 1;
        PlayerPrefs.SetInt("CertificateTime", gv.CertificateTime);
        PlayerPrefs.Save();
        GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().CheckCertification();
    }

}
