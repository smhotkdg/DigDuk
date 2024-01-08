using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject TouchText;
    public GameObject ResultTextObj;
    public GameObject BlackCoinParticle;
    public GameObject HoitStoneParticle;
    public Text ResultText;
    public GameObject RemovePanelImage;
    public GameObject BoxAnim;
    public GameObject CloseRemovePanelBtn;
    public GameObject RemovePanel;
    public List<GameObject> RemovePotionList;
    public Text HoitStoneText;
    public Text GodStoneText;
    public Text WinMarkText;
    public Text LoseMarkText;
    public GameObject CertiSale;
    public GameObject CertiTime;

    public GameObject PotionMiner;
    public GameObject PotionMinerDouble;

    public GameObject PotionDrill;
    public GameObject PotionDrillDouble;

    public GameObject PotionSale;
    public GameObject PotionSaleDouble;

    public GameObject PotionZzang;
    public GameObject PotionZaangDouble;

    public GameObject PotionBuff;
    public GameObject PotionBuffDouble;

    //20분
    public GameObject PotionAuto;
    //1시간
    public GameObject PotionAutoDouble;

    public Text PotionMinerText;
    public Text PotionMinerDoubleText;

    public Text PotionDrillText;
    public Text PotionDrillDoubleText;

    public Text PotionSaleText;
    public Text PotionSaleDoubleText;


    public Text PotionZzangText;
    public Text PotionZzangDoubleText;


    public Text PotionBuffText;
    public Text PotionBuffDoubleText;

    public Text PotionAutoText;
    public Text PotionAutoDoubleText;

    public GameObject InventoryMinerBuff1;
    public GameObject InventoryMinerBuff2;

    public GameObject InventoryDrillBuff1;
    public GameObject InventoryDrillBuff2;

    public GameObject InventorySaleBuff1;
    public GameObject InventorySaleBuff2;

    public GameObject InventoryZzangBuff1;
    public GameObject InventoryZzangBuff2;

    public GameObject InventorySkillBuff1;
    public GameObject InventorySkillBuff2;

    public GameObject InventoryAutoBuff1;
    public GameObject InventoryAutoBuff2;

    public List<Text> TextCountList;

    public GameObject UsePanel;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void FixedUpdate()
    {
        {
            if (gv.MapType == 1)
            {
                if (gv.isMiningPotion > 0)
                {
                    int drilltime = (gv.isMiningPotion - 1) * gv.MiningPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTime", PotionMinerText, gv.MiningPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTime", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {                 
                    }
                }
                else
                {
                    if (PotionMiner.activeSelf == true)
                    {
                        PotionMiner.SetActive(false);
                        
                    }
                }
                if (gv.isMiningPotionDouble > 0)
                {
                    int drilltime = (gv.isMiningPotionDouble - 1) * gv.MiningPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTime", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTime", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == 2)
                    {                 
                    }
                }
                else
                {
                    if (PotionMinerDouble.activeSelf == true)
                    {
                        PotionMinerDouble.SetActive(false);                    
                    }
                }


                if (gv.isDrillPotion > 0)
                {
                    int drilltime = (gv.isDrillPotion - 1) * gv.DrillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTime", PotionDrillText, gv.DrillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTime", PotionDrillText, gv.DrillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrill.activeSelf == true)
                    {
                        PotionDrill.SetActive(false);                 
                    }
                }
                if (gv.isDrillPotionDouble > 0)
                {
                    int drilltime = (gv.isDrillPotionDouble - 1) * gv.DrillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTime", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTime", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrillDouble.activeSelf == true)
                    {
                        PotionDrillDouble.SetActive(false);                        
                    }
                }

                if (gv.isSalePotion > 0)
                {
                    int drilltime = (gv.isSalePotion - 1) * gv.SalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTime", PotionSaleText, gv.SalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTime", PotionSaleText, gv.SalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSale.activeSelf == true)
                    {
                        PotionSale.SetActive(false);                     
                    }
                }
                if (gv.isSalePotionDouble > 0)
                {
                    int drilltime = (gv.isSalePotionDouble - 1) * gv.SalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTime", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTime", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSaleDouble.activeSelf == true)
                    {
                        PotionSaleDouble.SetActive(false);
                    
                    }
                }


                if (gv.isZzangPotion > 0)
                {
                    int drilltime = (gv.isZzangPotion - 1) * gv.ZzangPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTime", PotionZzangText, gv.ZzangPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTime", PotionZzangText, gv.ZzangPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZzang.activeSelf == true)
                    {
                        PotionZzang.SetActive(false);
                   
                    }

                }
                if (gv.isZzangPotionDouble > 0)
                {
                    int drilltime = (gv.isZzangPotionDouble - 1) * gv.ZzangPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTime", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTime", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZaangDouble.activeSelf == true)
                    {
                        PotionZaangDouble.SetActive(false);
                     
                    }
                }

                if (gv.isBuffPotion > 0)
                {
                    int drilltime = (gv.isBuffPotion - 1) * gv.SkillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTime", PotionBuffText, gv.SkillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTime", PotionBuffText, gv.SkillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuff.activeSelf == true)
                    {
                        PotionBuff.SetActive(false);                   
                    }
                }
                if (gv.isBuffPotionDouble > 0)
                {
                    int drilltime = (gv.isBuffPotionDouble - 1) * gv.SkillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTime", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTime", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuffDouble.activeSelf == true)
                    {
                        PotionBuffDouble.SetActive(false);
                    }
                }

                if (gv.isAutoSellPotion > 0)
                {
                    int drilltime = (gv.isAutoSellPotion - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTime", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTime", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                    }
                }
                if (gv.isAutoSellDoublePotion > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotion - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTime", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTime", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                    }
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.isMiningPotionDesert > 0)
                {
                    int drilltime = (gv.isMiningPotionDesert - 1) * gv.MiningPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeDesert", PotionMinerText, gv.MiningPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeDesert", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionMiner.activeSelf == true)
                    {
                        PotionMiner.SetActive(false);
                        gv.MiningBuffPower -= 2;
                    }
                }
                if (gv.isMiningPotionDoubleDesert > 0)
                {
                    int drilltime = (gv.isMiningPotionDoubleDesert - 1) * gv.MiningPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeDesert", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeDesert", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isMiningPotionDoubleDesert = 0;
                        PlayerPrefs.SetInt("isMiningPotionDoubleDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionMinerDouble.activeSelf == true)
                    {
                        PotionMinerDouble.SetActive(false);
                        gv.MiningBuffPower -= 10;
                    }
                }


                if (gv.isDrillPotionDesert > 0)
                {
                    int drilltime = (gv.isDrillPotionDesert - 1) * gv.DrillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeDesert", PotionDrillText, gv.DrillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeDesert", PotionDrillText, gv.DrillPotionTime + drilltime) == 2)
                    {
                        gv.isDrillPotionDesert = 0;
                        PlayerPrefs.SetInt("isDrillPotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionDrill.activeSelf == true)
                    {
                        PotionDrill.SetActive(false);
                        gv.DrillBuffPower -= 2;
                    }
                }
                if (gv.isDrillPotionDoubleDesert > 0)
                {
                    int drilltime = (gv.isDrillPotionDoubleDesert - 1) * gv.DrillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeDesert", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeDesert", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isDrillPotionDoubleDesert = 0;
                        PlayerPrefs.SetInt("isDrillPotionDoubleDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionDrillDouble.activeSelf == true)
                    {
                        PotionDrillDouble.SetActive(false);
                        gv.DrillBuffPower -= 10;
                    }
                }

                if (gv.isSalePotionDesert > 0)
                {
                    int drilltime = (gv.isSalePotionDesert - 1) * gv.SalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeDesert", PotionSaleText, gv.SalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeDesert", PotionSaleText, gv.SalePotionTime + drilltime) == 2)
                    {
                        gv.isSalePotionDesert = 0;
                        PlayerPrefs.SetInt("isSalePotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionSale.activeSelf == true)
                    {
                        PotionSale.SetActive(false);
                        gv.SaleBuffPower -= 2;
                    }
                }
                if (gv.isSalePotionDoubleDesert > 0)
                {
                    int drilltime = (gv.isSalePotionDoubleDesert - 1) * gv.SalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeDesert", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeDesert", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isSalePotionDoubleDesert = 0;
                        PlayerPrefs.SetInt("isSalePotionDoubleDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionSaleDouble.activeSelf == true)
                    {
                        PotionSaleDouble.SetActive(false);
                        gv.SaleBuffPower -= 10;
                    }
                }


                if (gv.isZzangPotionDesert > 0)
                {
                    int drilltime = (gv.isZzangPotionDesert - 1) * gv.ZzangPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeDesert", PotionZzangText, gv.ZzangPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeDesert", PotionZzangText, gv.ZzangPotionTime + drilltime) == 2)
                    {
                        gv.isZzangPotionDesert = 0;
                        PlayerPrefs.SetInt("isZzangPotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionZzang.activeSelf == true)
                    {
                        PotionZzang.SetActive(false);
                        gv.MiningBuffPower -= 2;
                        gv.DrillBuffPower -= 2;
                        gv.SaleBuffPower -= 2;
                        gv.buffBuffPower -= 2;
                    }
                }
                if (gv.isZzangPotionDoubleDesert > 0)
                {
                    int drilltime = (gv.isZzangPotionDoubleDesert - 1) * gv.ZzangPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeDesert", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeDesert", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isZzangPotionDoubleDesert = 0;
                        PlayerPrefs.SetInt("isZzangPotionDoubleDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionZaangDouble.activeSelf == true)
                    {
                        PotionZaangDouble.SetActive(false);
                        gv.MiningBuffPower -= 10;
                        gv.DrillBuffPower -= 10;
                        gv.SaleBuffPower -= 10;
                        gv.buffBuffPower -= 10;
                    }
                }

                if (gv.isBuffPotionDesert > 0)
                {
                    int drilltime = (gv.isBuffPotionDesert - 1) * gv.SkillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeDesert", PotionBuffText, gv.SkillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeDesert", PotionBuffText, gv.SkillPotionTime + drilltime) == 2)
                    {
                        gv.isBuffPotionDesert = 0;
                        PlayerPrefs.SetInt("isBuffPotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionBuff.activeSelf == true)
                    {
                        PotionBuff.SetActive(false);
                        gv.buffBuffPower -= 2;
                    }
                }
                if (gv.isBuffPotionDoubleDesert > 0)
                {
                    int drilltime = (gv.isBuffPotionDoubleDesert - 1) * gv.SkillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeDesert", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeDesert", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isBuffPotionDoubleDesert = 0;
                        PlayerPrefs.SetInt("isBuffPotionDoubleDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionBuffDouble.activeSelf == true)
                    {
                        PotionBuffDouble.SetActive(false);
                        gv.buffBuffPower -= 10;
                    }
                }

                if (gv.isAutoSellPotionDesert > 0)
                {
                    int drilltime = (gv.isAutoSellPotionDesert - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeDesert", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeDesert", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                    }
                }
                if (gv.isAutoSellDoublePotionDesert > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionDesert - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeDesert", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeDesert", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                    }
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.isMiningPotionIce > 0)
                {
                    int drilltime = (gv.isMiningPotionIce - 1) * gv.MiningPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeIce", PotionMinerText, gv.MiningPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeIce", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionMiner.activeSelf == true)
                    {
                        PotionMiner.SetActive(false);
                    
                    }
                }
                if (gv.isMiningPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isMiningPotionDoubleIce - 1) * gv.MiningPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeIce", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeIce", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionMinerDouble.activeSelf == true)
                    {
                        PotionMinerDouble.SetActive(false);
                     
                    }
                }


                if (gv.isDrillPotionIce > 0)
                {
                    int drilltime = (gv.isDrillPotionIce - 1) * gv.DrillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeIce", PotionDrillText, gv.DrillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeIce", PotionDrillText, gv.DrillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrill.activeSelf == true)
                    {
                        PotionDrill.SetActive(false);
                      
                    }
                }
                if (gv.isDrillPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isDrillPotionDoubleIce - 1) * gv.DrillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeIce", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeIce", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrillDouble.activeSelf == true)
                    {
                        PotionDrillDouble.SetActive(false);                        
                    }
                }

                if (gv.isSalePotionIce > 0)
                {
                    int drilltime = (gv.isSalePotionIce - 1) * gv.SalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeIce", PotionSaleText, gv.SalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeIce", PotionSaleText, gv.SalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSale.activeSelf == true)
                    {
                        PotionSale.SetActive(false);                        
                    }
                }
                if (gv.isSalePotionDoubleIce > 0)
                {
                    int drilltime = (gv.isSalePotionDoubleIce - 1) * gv.SalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeIce", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeIce", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSaleDouble.activeSelf == true)
                    {
                        PotionSaleDouble.SetActive(false);                    
                    }
                }


                if (gv.isZzangPotionIce > 0)
                {
                    int drilltime = (gv.isZzangPotionIce - 1) * gv.ZzangPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeIce", PotionZzangText, gv.ZzangPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeIce", PotionZzangText, gv.ZzangPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZzang.activeSelf == true)
                    {
                        PotionZzang.SetActive(false);                   
                    }
                }
                if (gv.isZzangPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isZzangPotionDoubleIce - 1) * gv.ZzangPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeIce", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeIce", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZaangDouble.activeSelf == true)
                    {
                        PotionZaangDouble.SetActive(false);
                    
                    }
                }

                if (gv.isBuffPotionIce > 0)
                {
                    int drilltime = (gv.isBuffPotionIce - 1) * gv.SkillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeIce", PotionBuffText, gv.SkillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeIce", PotionBuffText, gv.SkillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuff.activeSelf == true)
                    {
                        PotionBuff.SetActive(false);
                      
                    }
                }
                if (gv.isBuffPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isBuffPotionDoubleIce - 1) * gv.SkillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeIce", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeIce", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuffDouble.activeSelf == true)
                    {
                        PotionBuffDouble.SetActive(false);
                      
                    }
                }

                if (gv.isAutoSellPotionIce > 0)
                {
                    int drilltime = (gv.isAutoSellPotionIce - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeIce", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeIce", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                    }
                }
                if (gv.isAutoSellDoublePotionIce > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionIce - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeIce", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeIce", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                    }
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.isMiningPotionForest > 0)
                {
                    int drilltime = (gv.isMiningPotionForest - 1) * gv.MiningPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeForest", PotionMinerText, gv.MiningPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeForest", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionMiner.activeSelf == true)
                    {
                        PotionMiner.SetActive(false);
                      
                    }
                }
                if (gv.isMiningPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isMiningPotionDoubleForest - 1) * gv.MiningPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeForest", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeForest", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionMinerDouble.activeSelf == true)
                    {
                        PotionMinerDouble.SetActive(false);
                       
                    }
                }


                if (gv.isDrillPotionForest > 0)
                {
                    int drilltime = (gv.isDrillPotionForest - 1) * gv.DrillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeForest", PotionDrillText, gv.DrillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeForest", PotionDrillText, gv.DrillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrill.activeSelf == true)
                    {
                        PotionDrill.SetActive(false);
                        
                    }
                }
                if (gv.isDrillPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isDrillPotionDoubleForest - 1) * gv.DrillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeForest", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeForest", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionDrillDouble.activeSelf == true)
                    {
                        PotionDrillDouble.SetActive(false);
                        
                    }
                }

                if (gv.isSalePotionForest > 0)
                {
                    int drilltime = (gv.isSalePotionForest - 1) * gv.SalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeForest", PotionSaleText, gv.SalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeForest", PotionSaleText, gv.SalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSale.activeSelf == true)
                    {
                        PotionSale.SetActive(false);
                       
                    }
                }
                if (gv.isSalePotionDoubleForest > 0)
                {
                    int drilltime = (gv.isSalePotionDoubleForest - 1) * gv.SalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeForest", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeForest", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionSaleDouble.activeSelf == true)
                    {
                        PotionSaleDouble.SetActive(false);
                        
                    }
                }


                if (gv.isZzangPotionForest > 0)
                {
                    int drilltime = (gv.isZzangPotionForest - 1) * gv.ZzangPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeForest", PotionZzangText, gv.ZzangPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeForest", PotionZzangText, gv.ZzangPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZzang.activeSelf == true)
                    {
                        PotionZzang.SetActive(false);
                   
                    }
                }
                if (gv.isZzangPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isZzangPotionDoubleForest - 1) * gv.ZzangPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeForest", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeForest", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionZaangDouble.activeSelf == true)
                    {
                        PotionZaangDouble.SetActive(false);
                    
                    }
                }

                if (gv.isBuffPotionForest > 0)
                {
                    int drilltime = (gv.isBuffPotionForest - 1) * gv.SkillPotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeForest", PotionBuffText, gv.SkillPotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeForest", PotionBuffText, gv.SkillPotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuff.activeSelf == true)
                    {
                        PotionBuff.SetActive(false);
                      
                    }
                }
                if (gv.isBuffPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isBuffPotionDoubleForest - 1) * gv.SkillPotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeForest", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeForest", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionBuffDouble.activeSelf == true)
                    {
                        PotionBuffDouble.SetActive(false);
                       
                    }
                }

                if (gv.isAutoSellPotionForest > 0)
                {
                    int drilltime = (gv.isAutoSellPotionForest - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeForest", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeForest", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                    }
                }
                if (gv.isAutoSellDoublePotionForest > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionForest - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeForest", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeForest", PotionAutoDoubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                    }
                }
            }

        }
        CheckInitData();
    }
    public void CheckInitData()
    {
        if (gv.CertificateGold == 1)
        {
            CertiSale.SetActive(true);
            //gv.SaleBuffPower += 2f;
        }
        if (gv.CertificateTime == 1)
        {
            CertiTime.SetActive(true);
            //gv.ReTimePower += 2;
        }

        if (gv.MapType == 1)
        {
            if (gv.isMiningPotion > 0)
            {
                PotionMiner.SetActive(true);
            }
            if (gv.isDrillPotion > 0)
            {
                PotionDrill.SetActive(true);
            }
            if (gv.isSalePotion > 0)
            {
                PotionSale.SetActive(true);
            }
            if (gv.isZzangPotion > 0)
            {
                PotionZzang.SetActive(true);
            }
            if (gv.isBuffPotion > 0)
            {
                PotionBuff.SetActive(true);
            }

            if (gv.isMiningPotionDouble > 0)
            {
                PotionMinerDouble.SetActive(true);
            }
            if (gv.isDrillPotionDouble > 0)
            {
                PotionDrillDouble.SetActive(true);
            }
            if (gv.isSalePotionDouble > 0)
            {
                PotionSaleDouble.SetActive(true);
            }
            if (gv.isZzangPotionDouble > 0)
            {
                PotionZaangDouble.SetActive(true);
            }
            if (gv.isBuffPotionDouble > 0)
            {
                PotionBuffDouble.SetActive(true);
            }

            if(gv.isAutoSellPotion >0)
            {
                PotionAuto.SetActive(true);
            }
            if(gv.isAutoSellDoublePotion >0)
            {
                PotionAutoDouble.SetActive(true);
            }
            
        }

        if (gv.MapType == 2)
        {
            if (gv.isAutoSellPotionDesert > 0)
            {
                PotionAuto.SetActive(true);
            }
            if (gv.isAutoSellDoublePotionDesert > 0)
            {
                PotionAutoDouble.SetActive(true);
            }

            if (gv.isMiningPotionDesert > 0)
            {
                PotionMiner.SetActive(true);
            }
            if (gv.isDrillPotionDesert > 0)
            {
                PotionDrill.SetActive(true);
            }
            if (gv.isSalePotionDesert > 0)
            {
                PotionSale.SetActive(true);
            }
            if (gv.isZzangPotionDesert > 0)
            {
                PotionZzang.SetActive(true);
            }
            if (gv.isBuffPotionDesert > 0)
            {
                PotionBuff.SetActive(true);
            }

            if (gv.isMiningPotionDoubleDesert > 0)
            {
                PotionMinerDouble.SetActive(true);
            }
            if (gv.isDrillPotionDoubleDesert > 0)
            {
                PotionDrillDouble.SetActive(true);
            }
            if (gv.isSalePotionDoubleDesert > 0)
            {
                PotionSaleDouble.SetActive(true);
            }
            if (gv.isZzangPotionDoubleDesert > 0)
            {
                PotionZaangDouble.SetActive(true);
            }
            if (gv.isBuffPotionDoubleDesert > 0)
            {
                PotionBuffDouble.SetActive(true);
            }
        }

        if (gv.MapType == 3)
        {
            if (gv.isAutoSellPotionIce > 0)
            {
                PotionAuto.SetActive(true);
            }
            if (gv.isAutoSellDoublePotionIce > 0)
            {
                PotionAutoDouble.SetActive(true);
            }

            if (gv.isMiningPotionIce > 0)
            {
                PotionMiner.SetActive(true);
            }
            if (gv.isDrillPotionIce > 0)
            {
                PotionDrill.SetActive(true);
            }
            if (gv.isSalePotionIce > 0)
            {
                PotionSale.SetActive(true);
            }
            if (gv.isZzangPotionIce > 0)
            {
                PotionZzang.SetActive(true);
            }
            if (gv.isBuffPotionIce > 0)
            {
                PotionBuff.SetActive(true);
            }

            if (gv.isMiningPotionDoubleIce > 0)
            {
                PotionMinerDouble.SetActive(true);
            }
            if (gv.isDrillPotionDoubleIce > 0)
            {
                PotionDrillDouble.SetActive(true);
            }
            if (gv.isSalePotionDoubleIce > 0)
            {
                PotionSaleDouble.SetActive(true);
            }
            if (gv.isZzangPotionDoubleIce > 0)
            {
                PotionZaangDouble.SetActive(true);
            }
            if (gv.isBuffPotionDoubleIce > 0)
            {
                PotionBuffDouble.SetActive(true);
            }
        }

        if (gv.MapType == 4)
        {
            if (gv.isAutoSellPotionForest > 0)
            {
                PotionAuto.SetActive(true);
            }
            if (gv.isAutoSellDoublePotionForest > 0)
            {
                PotionAutoDouble.SetActive(true);
            }

            if (gv.isMiningPotionForest > 0)
            {
                PotionMiner.SetActive(true);
            }
            if (gv.isDrillPotionForest > 0)
            {
                PotionDrill.SetActive(true);
            }
            if (gv.isSalePotionForest > 0)
            {
                PotionSale.SetActive(true);
            }
            if (gv.isZzangPotionForest > 0)
            {
                PotionZzang.SetActive(true);
            }
            if (gv.isBuffPotionForest > 0)
            {
                PotionBuff.SetActive(true);
            }

            if (gv.isMiningPotionDoubleForest > 0)
            {
                PotionMinerDouble.SetActive(true);
            }
            if (gv.isDrillPotionDoubleForest > 0)
            {
                PotionDrillDouble.SetActive(true);
            }
            if (gv.isSalePotionDoubleForest > 0)
            {
                PotionSaleDouble.SetActive(true);
            }
            if (gv.isZzangPotionDoubleForest > 0)
            {
                PotionZaangDouble.SetActive(true);
            }
            if (gv.isBuffPotionDoubleForest > 0)
            {
                PotionBuffDouble.SetActive(true);
            }
        }

        if (gv.MiningPotionTotalCount > 0)
        {
            InventoryMinerBuff1.SetActive(true);
            TextCountList[0].text = gv.MiningPotionTotalCount.ToString();
        }
        if (gv.DrillPotionTotalCount > 0)
        {
            InventoryDrillBuff1.SetActive(true);
            TextCountList[2].text = gv.DrillPotionTotalCount.ToString();
        }
        if (gv.SalePotionTotalCount > 0)
        {
            InventorySaleBuff1.SetActive(true);
            TextCountList[4].text = gv.SalePotionTotalCount.ToString();
        }
        if (gv.ZzangPotionTotalCount > 0)
        {
            InventoryZzangBuff1.SetActive(true);
            TextCountList[6].text = gv.ZzangPotionTotalCount.ToString();
        }
        if (gv.SkillPotionTotalCount > 0)
        {
            InventorySkillBuff1.SetActive(true);
            TextCountList[8].text = gv.SkillPotionTotalCount.ToString();
        }
        if (gv.AutoSellPotionTotalCount > 0)
        {
            InventoryAutoBuff1.SetActive(true);
            TextCountList[10].text = gv.AutoSellPotionTotalCount.ToString();
        }

        if (gv.MiningDoublePotionTotalCount > 0)
        {
            InventoryMinerBuff2.SetActive(true);
            TextCountList[1].text = gv.MiningDoublePotionTotalCount.ToString();
        }
        if (gv.DrillDoublePotionTotalCount > 0)
        {
            InventoryDrillBuff2.SetActive(true);
            TextCountList[3].text = gv.DrillDoublePotionTotalCount.ToString();
        }
        if (gv.SaleDoublePotionTotalCount > 0)
        {
            InventorySaleBuff2.SetActive(true);
            TextCountList[5].text = gv.SaleDoublePotionTotalCount.ToString();
        }
        if (gv.ZzangDoublePotionTotalCount > 0)
        {
            InventoryZzangBuff2.SetActive(true);
            TextCountList[7].text = gv.ZzangDoublePotionTotalCount.ToString();
        }
        if (gv.SkillDoublePotionTotalCount > 0)
        {
            InventorySkillBuff2.SetActive(true);
            TextCountList[9].text = gv.SkillDoublePotionTotalCount.ToString();
        }     
        if(gv.AutoSellDoublePotionTotalCount >0)
        {
            InventoryAutoBuff2.SetActive(true);
            TextCountList[11].text = gv.AutoSellDoublePotionTotalCount.ToString();
        }


        WinMarkText.text = gv.WinMarkTotal.ToString();
        LoseMarkText.text = gv.LoseMarkTotal.ToString();
        HoitStoneText.text = gv.HoitStoneCount.ToString();
        GodStoneText.text = gv.GodStoneCount.ToString();
    }
    private void OnEnable()
    {
        CheckInitData();
      
    }
    public void DIsableEvent()
    {
        PotionMiner.SetActive(false);
        PotionMinerDouble.SetActive(false);

        PotionDrill.SetActive(false);
        PotionDrillDouble.SetActive(false);

        PotionSale.SetActive(false);
        PotionSaleDouble.SetActive(false);

        PotionZzang.SetActive(false);
        PotionZaangDouble.SetActive(false);

        PotionBuff.SetActive(false);
        PotionBuffDouble.SetActive(false);
        PotionAuto.SetActive(false);
        PotionAutoDouble.SetActive(false);

        InventoryMinerBuff1.SetActive(false);
        InventoryMinerBuff2.SetActive(false);

        InventoryDrillBuff1.SetActive(false);
        InventoryDrillBuff2.SetActive(false);

        InventorySaleBuff1.SetActive(false);
        InventorySaleBuff2.SetActive(false);

        InventoryZzangBuff1.SetActive(false);
        InventoryZzangBuff2.SetActive(false);

        InventorySkillBuff1.SetActive(false);
        InventorySkillBuff2.SetActive(false);
        InventoryAutoBuff1.SetActive(false);
        InventoryAutoBuff2.SetActive(false);

        for (int i = 0; i < PotionImageList.Count; i++)
        {
            PotionImageList[i].SetActive(false);
        }
    }
    private void OnDisable()
    {
        DIsableEvent();
    }
    // Update is called once per frame
    void Update () {
		
	}
    int selectNumber = 0;
    public void SelectPotion(int count)
    {
        PressUsePanel(1);
        for (int i = 0; i < PotionImageList.Count; i++)
        {
            if (i != count)
            {
                PotionImageList[i].SetActive(false);
            }
        }

        PotionImageList[count].SetActive(true);
        selectNumber = count;        
    }
    public int DeletePotionNumber = -1;
    public void DeletePotion(int count)
    {
        RemovePanel.SetActive(true);
        for (int i = 0; i < RemovePotionList.Count; i++)
        {
            if (i != count)
            {
                RemovePotionList[i].SetActive(false);
            }
        }
        RemovePotionList[count].SetActive(true);
        DeletePotionNumber = count;
    } 
    public void CloseDeletePanel()
    {
        bStartRemoveBox = false;
        RemovePanelImage.GetComponent<Animator>().SetBool("isClick", false);
        BoxAnim.GetComponent<Animator>().SetBool("isOpen", false);
        CloseRemovePanelBtn.SetActive(false);
        RemovePanel.SetActive(false);

        BlackCoinParticle.SetActive(false);
        HoitStoneParticle.SetActive(false);
        TouchText.SetActive(true);
        ResultTextObj.SetActive(false);
    }
    public void ClickOkDelete()
    {
        if(DeletePotionNumber >=0)
        {
            RemovePanelImage.GetComponent<Animator>().SetBool("isClick", true);
            switch (DeletePotionNumber)
            {
                case 0:
                    gv.MiningPotionTotalCount--;
                    PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
                    break;
                case 1:
                    gv.MiningDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
                    break;
                case 2:
                    gv.DrillPotionTotalCount--;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    break;
                case 3:
                    gv.DrillDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    break;
                case 4:
                    gv.SalePotionTotalCount--;
                    PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                    break;
                case 5:
                    gv.SaleDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("SaleDoublePotionTotalCount", gv.SaleDoublePotionTotalCount);
                    break;
                case 6:
                    gv.ZzangPotionTotalCount--;
                    PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
                    break;
                case 7:
                    gv.ZzangDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                    break;
                case 8:
                    gv.SkillPotionTotalCount--;
                    PlayerPrefs.SetInt("SkillPotionTotalCount", gv.SkillPotionTotalCount);
                    break;
                case 9:
                    gv.SkillDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("SkillDoublePotionTotalCount", gv.SkillDoublePotionTotalCount);
                    break;
                case 10:
                    gv.AutoSellPotionTotalCount--;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    break;
                case 11:
                    gv.AutoSellDoublePotionTotalCount--;
                    PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
                    break;
            }
        }
        PlayerPrefs.Save();
        CheckInitData();
        DeletePotionNumber = -1;
        DIsableEvent();
    }

    bool bStartRemoveBox = false;
    public void ClickRemoveBox()
    {
        if(bStartRemoveBox == false)
        {
            bStartRemoveBox = true;
            //여기서 랜덤 어쩌구 저쩌구
            int random = Random.Range(1, 100);
            int ResultBlackCoins = 0;
            int ResultHoitStoneCount = 0;
            int randCoins = -1;
            if (random < 30)
            {
                //블랙코인 짠
                randCoins = 0;
                int rangeBlackCoin = Random.Range(1, 3000);
                if (rangeBlackCoin < 2)
                {
                    ResultBlackCoins = Random.Range(60, 100);
                }
                else if (rangeBlackCoin < 40)
                {
                    ResultBlackCoins = Random.Range(40, 60);
                }
                else if (rangeBlackCoin < 100)
                {
                    ResultBlackCoins = Random.Range(20, 40);
                }
                else if (rangeBlackCoin < 300)
                {
                    ResultBlackCoins = Random.Range(10, 20);
                }
                else
                {
                    ResultBlackCoins = Random.Range(1, 10);
                }
            }
            else
            {
                //호잇스톤 짠
                randCoins = 1;
                int rangeBlackCoin = Random.Range(1, 700);
                if (rangeBlackCoin < 2)
                {
                    ResultHoitStoneCount = Random.Range(60, 100);
                }
                else if (rangeBlackCoin < 40)
                {
                    ResultHoitStoneCount = Random.Range(40, 60);
                }
                else if (rangeBlackCoin < 100)
                {
                    ResultHoitStoneCount = Random.Range(20, 40);
                }
                else if (rangeBlackCoin < 300)
                {
                    ResultHoitStoneCount = Random.Range(10, 20);
                }
                else
                {
                    ResultHoitStoneCount = Random.Range(10, 15);
                }
            }
            BoxAnim.GetComponent<Animator>().SetBool("isOpen", true);
            CloseRemovePanelBtn.SetActive(true);

            StartCoroutine(StartParticle(randCoins, ResultBlackCoins, ResultHoitStoneCount));
        }        
    }
    IEnumerator StartParticle(int i,int Blackcoins,int hoitstones)
    {
        yield return new WaitForSeconds(0.5f);
        TouchText.SetActive(false);
        ResultTextObj.SetActive(true);
        if (i == 0)
        {
            BlackCoinParticle.SetActive(true);
            ResultText.text = "블랙코인 + " + Blackcoins;
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", Blackcoins);
        }
        else
        {
            HoitStoneParticle.SetActive(true);
            ResultText.text = "호잇스톤 + " + hoitstones;
            gv.HoitStoneCount += hoitstones;
            PlayerPrefs.SetInt("HoitStoneCount",gv.HoitStoneCount);
            PlayerPrefs.Save();
        }
        
    }
  

    public List<GameObject> PotionImageList;
    public void UsePotion()
    {
        //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(5);
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("UsePotion");
        if (selectNumber ==0)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseMiningPotion1();
            PressUsePanel(0);
        }
        if (selectNumber == 1)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseMiningPotion2();
            PressUsePanel(0);
        }
        if (selectNumber == 2)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseDrillPotion1();
            PressUsePanel(0);
        }
        if (selectNumber == 3)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseDrillPotion2();
            PressUsePanel(0);
        }
        if (selectNumber == 4)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseSalePotion1();
            PressUsePanel(0);
        }
        if (selectNumber == 5)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseSalePotion2();
            PressUsePanel(0);
        }

        if (selectNumber == 6)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseZzangPotion1();
            PressUsePanel(0);
        }
        if (selectNumber == 7)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseZzangPotion2();
            PressUsePanel(0);
        }
        if (selectNumber == 8)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseSkillPotion1();
            PressUsePanel(0);
        }
        if (selectNumber == 9)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseSkillPotion2();
            PressUsePanel(0);
        }
        if(selectNumber ==10)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseAutoSellpotion1();
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 1)
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(1, 0);
            PressUsePanel(0);
        }
        if(selectNumber ==11)
        {
            GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().UseAutoSellpotion2();
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 1)
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(1, 0);
            PressUsePanel(0);
        }
        InventoryMinerBuff1.SetActive(false);
        InventoryMinerBuff2.SetActive(false);

        InventoryDrillBuff1.SetActive(false);
        InventoryDrillBuff2.SetActive(false);

        InventorySaleBuff1.SetActive(false);
        InventorySaleBuff2.SetActive(false);

        InventoryZzangBuff1.SetActive(false);
        InventoryZzangBuff2.SetActive(false);

        InventorySkillBuff1.SetActive(false);
        InventorySkillBuff2.SetActive(false);

        InventoryAutoBuff1.SetActive(false);
        InventoryAutoBuff2.SetActive(false);
        CheckInitData();

    }
    public void PressUsePanel(int i)
    {
        if(i ==1)
        {
            UsePanel.SetActive(true);
        }
        else
        {
            UsePanel.SetActive(false);
        }
    }
}
