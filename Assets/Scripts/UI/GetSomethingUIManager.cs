using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetSomethingUIManager : MonoBehaviour {

    // Use this for initialization
    public GameObject DailyDepth;
    public GameObject Gold;
    public GameObject LvUp;
    public GameObject AutoSellPotion;
    public GameObject MinerPotion;
    public GameObject DrillPotion;

    public GameObject BlackCoins;
    public GameObject SaleBuffPotion;
    public GameObject HoitStone;
    public GameObject Depth;
    public GameObject Random1Miner;
    public GameObject Random5Miner;

    public GameObject ZzangPotion1;
    public GameObject GodStone;
    public GameObject MinerPotionDouble;

    public GameObject AutoSellDouble;
    public GameObject AtoSSMiner;
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnDisable()
    {
        if(Random5Miner.activeSelf == true)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 2);
        }
        if(Random1Miner.activeSelf == true)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
        }
        if(AtoSSMiner.activeSelf == true)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 4);
        }
        Gold.SetActive(false);
        LvUp.SetActive(false);
        AutoSellPotion.SetActive(false);
        MinerPotion.SetActive(false);
        DrillPotion.SetActive(false);

        BlackCoins.SetActive(false);
        SaleBuffPotion.SetActive(false);
        HoitStone.SetActive(false);
        Depth.SetActive(false);
        Random5Miner.SetActive(false);
        DailyDepth.SetActive(false);
        Random1Miner.SetActive(false);
        ZzangPotion1.SetActive(false);
        GodStone.SetActive(false);
        MinerPotionDouble.SetActive(false);
        AutoSellDouble.SetActive(false);
        AtoSSMiner.SetActive(false);
    }
    public void SaveObject(int count)
    {
        if (gv.strGetSomething == "Miner1")
        {
            Random1Miner.SetActive(true);
        }
        if (gv.strGetSomething == "Miner5")
        {
            Random5Miner.SetActive(true);
        }
        if (gv.strGetSomething == "AutoSell")
        {            
            gv.AutoSellPotionTotalCount+= count;
            PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
            PlayerPrefs.Save();
        }

        if (gv.strGetSomething == "MiningPotion")
        {            
            gv.MiningPotionTotalCount +=count;
            PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
            PlayerPrefs.Save();
        }
        if (gv.strGetSomething == "DrillPotion")
        {            
            gv.DrillPotionTotalCount+= count;
            PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
            PlayerPrefs.Save();
        }
        if (gv.strGetSomething == "BlackCoin")
        {
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", count);          
        }
        if (gv.strGetSomething == "SalePotion")
        {            
            gv.SalePotionTotalCount+= count;
            PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
            PlayerPrefs.Save();
        }
        if (gv.strGetSomething == "HoitStone")
        {            
            gv.HoitStoneCount+= count;
            PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
            PlayerPrefs.Save();
        }

        if (gv.strGetSomething == "ZzangPotion")
        {
            gv.ZzangPotionTotalCount += count;
            PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
            PlayerPrefs.Save();
        }

        if (gv.strGetSomething == "GodStone")
        {
            gv.GodStoneCount += count;
            PlayerPrefs.SetInt("GodStoneCount", gv.GodStoneCount);
            PlayerPrefs.Save();
        }

        if (gv.strGetSomething == "MinerPotionDouble")
        {
            gv.MiningDoublePotionTotalCount += count;
            PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
            PlayerPrefs.Save();
        }


    }
    public void SetObject(float count)
    {
        if(gv.strGetSomething == "DailyDepth")
        {
            DailyDepth.SetActive(true);
        }
        if(gv.strGetSomething == "AutoSell")
        {
            AutoSellPotion.SetActive(true);
            AutoSellPotion.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }

        if (gv.strGetSomething == "MiningPotion")
        {
            MinerPotion.SetActive(true);
            MinerPotion.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }
        if (gv.strGetSomething == "DrillPotion")
        {
            DrillPotion.SetActive(true);
            DrillPotion.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }
        if (gv.strGetSomething == "BlackCoin")
        {
            BlackCoins.SetActive(true);
            BlackCoins.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }
        if (gv.strGetSomething == "SalePotion")
        {
            SaleBuffPotion.SetActive(true);
            SaleBuffPotion.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }
        if (gv.strGetSomething == "HoitStone")
        {
            HoitStone.SetActive(true);
            HoitStone.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }
        if (gv.strGetSomething == "Gold")
        {
            Gold.SetActive(true);
            Gold.transform.Find("Count").gameObject.GetComponent<Text>().text = gv.ChangeMoney(count);
        }
        if (gv.strGetSomething == "LvUp")
        {
            LvUp.SetActive(true);
            
        }
        if(gv.strGetSomething == "Depth")
        {
            Depth.SetActive(true);
            Depth.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " Km";
        }
        if (gv.strGetSomething == "Miner5")
        {
            Random5Miner.SetActive(true);
        }
        if (gv.strGetSomething == "Miner1")
        {
            Random1Miner.SetActive(true);
        }

        if (gv.strGetSomething == "ZzangPotion")
        {
            ZzangPotion1.SetActive(true);
            ZzangPotion1.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }

        if (gv.strGetSomething == "GodStone")
        {
            GodStone.SetActive(true);
            GodStone.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }

        if (gv.strGetSomething == "MinerPotionDouble")
        {
            MinerPotionDouble.SetActive(true);
            MinerPotionDouble.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }

        if (gv.strGetSomething == "AutoSellDouble")
        {
            AutoSellDouble.SetActive(true);
            AutoSellDouble.transform.Find("Count").gameObject.GetComponent<Text>().text = count + " 개";
        }

        if (gv.strGetSomething == "AtoSS")
        {
            AtoSSMiner.SetActive(true);            
        }

    }
}
