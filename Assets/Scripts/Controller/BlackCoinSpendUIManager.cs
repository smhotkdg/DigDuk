using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BlackCoinSpendUIManager : MonoBehaviour {

    // Use this for initialization
    public GameObject CertiSale;
    public GameObject CertiTime;
    public GameObject MainStatusObj;
    GlobalVariable gv;
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
    public GameObject PotionAuto;
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
    public Text PotionAutoDubleText;


    private void Awake()
    {
        gv = GlobalVariable.Instance;
        StartCoroutine(BuffCheck());
        
    }
    public void CheckCertification()
    {
        if(gv.CertificateGold ==1)
        {
            //CertiSale.SetActive(true);
            gv.SaleBuffPower += 2f;
        }
        if (gv.CertificateTime == 1)
        {
            //CertiTime.SetActive(true);
            gv.ReTimePower += 2;
        }
        if(gv.DrillManagerStatus ==1)
        {
            gv.DrillBuffPower += 20;
        }
    }
    public void ChangeMapPotion()
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
        CheckPotion();
    }

    public void CheckPotion()
    {
        if(gv.MapType ==1)
        {
            if (gv.isMiningPotion > 0)
            {
                if (PotionMiner.activeSelf == false) 
                {
                    PotionMiner.SetActive(true);
                    gv.MiningBuffPower += 2;
                }                
            }
            if (gv.isMiningPotionDouble> 0)
            {
                if(PotionMinerDouble.activeSelf == false)
                {
                    PotionMinerDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                }
            }
            if (gv.isDrillPotion > 0)
            {
                if(PotionDrill.activeSelf == false)
                {
                    PotionDrill.SetActive(true);
                    gv.DrillBuffPower += 2;
                }
            }
            if (gv.isDrillPotionDouble > 0)
            {
                if(PotionDrillDouble.activeSelf ==false)
                {
                    PotionDrillDouble.SetActive(true);
                    gv.DrillBuffPower += 10;
                }
            }
            if (gv.isSalePotion > 0)
            {
                if(PotionSale.activeSelf == false)
                {
                    PotionSale.SetActive(true);
                    gv.SaleBuffPower += 2;
                }
            }
            if (gv.isSalePotionDouble > 0)
            {
                if(PotionSaleDouble.activeSelf ==false)
                {
                    PotionSaleDouble.SetActive(true);
                    gv.SaleBuffPower += 10;
                }
            }
            if (gv.isZzangPotion > 0)
            {
                if(PotionZzang.activeSelf == false)
                {
                    PotionZzang.SetActive(true);
                    gv.MiningBuffPower += 2;
                    gv.DrillBuffPower += 2;
                    gv.SaleBuffPower += 2;
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isZzangPotionDouble > 0)
            {
                if(PotionZaangDouble.activeSelf == false)
                {
                    PotionZaangDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                    gv.DrillBuffPower += 10;
                    gv.SaleBuffPower += 10;
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isBuffPotion > 0)
            {
                if(PotionBuff.activeSelf == false)
                {
                    PotionBuff.SetActive(true);
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isBuffPotionDouble > 0)
            {
                if(PotionBuffDouble.activeSelf == false)
                {
                    PotionBuffDouble.SetActive(true);
                    gv.buffBuffPower += 10;
                }
            }

            if (gv.isAutoSellPotion > 0)
            {
                if (PotionAuto.activeSelf == false)
                {
                    PotionAuto.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
            if (gv.isAutoSellDoublePotion > 0)
            {
                if (PotionAutoDouble.activeSelf == false)
                {
                    PotionAutoDouble.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
        }

        if (gv.MapType == 2)
        {
            if (gv.isMiningPotionDesert > 0)
            {
                if (PotionMiner.activeSelf == false)
                {
                    PotionMiner.SetActive(true);
                    gv.MiningBuffPower += 2;
                }
            }
            if (gv.isMiningPotionDoubleDesert > 0)
            {
                if (PotionMinerDouble.activeSelf == false)
                {
                    PotionMinerDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                }
            }
            if (gv.isDrillPotionDesert > 0)
            {
                if (PotionDrill.activeSelf == false)
                {
                    PotionDrill.SetActive(true);
                    gv.DrillBuffPower += 2;
                }
            }
            if (gv.isDrillPotionDoubleDesert > 0)
            {
                if (PotionDrillDouble.activeSelf == false)
                {
                    PotionDrillDouble.SetActive(true);
                    gv.DrillBuffPower += 10;
                }
            }
            if (gv.isSalePotionDesert > 0)
            {
                if (PotionSale.activeSelf == false)
                {
                    PotionSale.SetActive(true);
                    gv.SaleBuffPower += 2;
                }
            }
            if (gv.isSalePotionDoubleDesert > 0)
            {
                if (PotionSaleDouble.activeSelf == false)
                {
                    PotionSaleDouble.SetActive(true);
                    gv.SaleBuffPower += 10;
                }
            }
            if (gv.isZzangPotionDesert > 0)
            {
                if (PotionZzang.activeSelf == false)
                {
                    PotionZzang.SetActive(true);
                    gv.MiningBuffPower += 2;
                    gv.DrillBuffPower += 2;
                    gv.SaleBuffPower += 2;
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isZzangPotionDoubleDesert > 0)
            {
                if (PotionZaangDouble.activeSelf == false)
                {
                    PotionZaangDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                    gv.DrillBuffPower += 10;
                    gv.SaleBuffPower += 10;
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isBuffPotionDesert > 0)
            {
                if (PotionBuff.activeSelf == false)
                {
                    PotionBuff.SetActive(true);
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isBuffPotionDoubleDesert > 0)
            {
                if (PotionBuffDouble.activeSelf == false)
                {
                    PotionBuffDouble.SetActive(true);
                    gv.buffBuffPower += 10;
                }
            }

            if (gv.isAutoSellPotionDesert > 0)
            {
                if (PotionAuto.activeSelf == false)
                {
                    PotionAuto.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
            if (gv.isAutoSellDoublePotionDesert > 0)
            {
                if (PotionAutoDouble.activeSelf == false)
                {
                    PotionAutoDouble.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
        }

        if (gv.MapType == 3)
        {
            if (gv.isMiningPotionIce > 0)
            {
                if (PotionMiner.activeSelf == false)
                {
                    PotionMiner.SetActive(true);
                    gv.MiningBuffPower += 2;
                }
            }
            if (gv.isMiningPotionDoubleIce > 0)
            {
                if (PotionMinerDouble.activeSelf == false)
                {
                    PotionMinerDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                }
            }
            if (gv.isDrillPotionIce > 0)
            {
                if (PotionDrill.activeSelf == false)
                {
                    PotionDrill.SetActive(true);
                    gv.DrillBuffPower += 2;
                }
            }
            if (gv.isDrillPotionDoubleIce > 0)
            {
                if (PotionDrillDouble.activeSelf == false)
                {
                    PotionDrillDouble.SetActive(true);
                    gv.DrillBuffPower += 10;
                }
            }
            if (gv.isSalePotionIce > 0)
            {
                if (PotionSale.activeSelf == false)
                {
                    PotionSale.SetActive(true);
                    gv.SaleBuffPower += 2;
                }
            }
            if (gv.isSalePotionDoubleIce > 0)
            {
                if (PotionSaleDouble.activeSelf == false)
                {
                    PotionSaleDouble.SetActive(true);
                    gv.SaleBuffPower += 10;
                }
            }
            if (gv.isZzangPotionIce > 0)
            {
                if (PotionZzang.activeSelf == false)
                {
                    PotionZzang.SetActive(true);
                    gv.MiningBuffPower += 2;
                    gv.DrillBuffPower += 2;
                    gv.SaleBuffPower += 2;
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isZzangPotionDoubleIce > 0)
            {
                if (PotionZaangDouble.activeSelf == false)
                {
                    PotionZaangDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                    gv.DrillBuffPower += 10;
                    gv.SaleBuffPower += 10;
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isBuffPotionIce > 0)
            {
                if (PotionBuff.activeSelf == false)
                {
                    PotionBuff.SetActive(true);
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isBuffPotionDoubleIce > 0)
            {
                if (PotionBuffDouble.activeSelf == false)
                {
                    PotionBuffDouble.SetActive(true);
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isAutoSellPotionIce > 0)
            {
                if (PotionAuto.activeSelf == false)
                {
                    PotionAuto.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
            if (gv.isAutoSellDoublePotionIce > 0)
            {
                if (PotionAutoDouble.activeSelf == false)
                {
                    PotionAutoDouble.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
        }

        if (gv.MapType == 4)
        {
            if (gv.isMiningPotionForest > 0)
            {
                if (PotionMiner.activeSelf == false)
                {
                    PotionMiner.SetActive(true);
                    gv.MiningBuffPower += 2;
                }
            }
            if (gv.isMiningPotionDoubleForest > 0)
            {
                if (PotionMinerDouble.activeSelf == false)
                {
                    PotionMinerDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                }
            }
            if (gv.isDrillPotionForest > 0)
            {
                if (PotionDrill.activeSelf == false)
                {
                    PotionDrill.SetActive(true);
                    gv.DrillBuffPower += 2;
                }
            }
            if (gv.isDrillPotionDoubleForest > 0)
            {
                if (PotionDrillDouble.activeSelf == false)
                {
                    PotionDrillDouble.SetActive(true);
                    gv.DrillBuffPower += 10;
                }
            }
            if (gv.isSalePotionForest > 0)
            {
                if (PotionSale.activeSelf == false)
                {
                    PotionSale.SetActive(true);
                    gv.SaleBuffPower += 2;
                }
            }
            if (gv.isSalePotionDoubleForest > 0)
            {
                if (PotionSaleDouble.activeSelf == false)
                {
                    PotionSaleDouble.SetActive(true);
                    gv.SaleBuffPower += 10;
                }
            }
            if (gv.isZzangPotionForest > 0)
            {
                if (PotionZzang.activeSelf == false)
                {
                    PotionZzang.SetActive(true);
                    gv.MiningBuffPower += 2;
                    gv.DrillBuffPower += 2;
                    gv.SaleBuffPower += 2;
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isZzangPotionDoubleForest > 0)
            {
                if (PotionZaangDouble.activeSelf == false)
                {
                    PotionZaangDouble.SetActive(true);
                    gv.MiningBuffPower += 10;
                    gv.DrillBuffPower += 10;
                    gv.SaleBuffPower += 10;
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isBuffPotionForest > 0)
            {
                if (PotionBuff.activeSelf == false)
                {
                    PotionBuff.SetActive(true);
                    gv.buffBuffPower += 2;
                }
            }
            if (gv.isBuffPotionDoubleForest > 0)
            {
                if (PotionBuffDouble.activeSelf == false)
                {
                    PotionBuffDouble.SetActive(true);
                    gv.buffBuffPower += 10;
                }
            }
            if (gv.isAutoSellPotionForest > 0)
            {
                if (PotionAuto.activeSelf == false)
                {
                    PotionAuto.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
            if (gv.isAutoSellDoublePotionForest > 0)
            {
                if (PotionAutoDouble.activeSelf == false)
                {
                    PotionAutoDouble.SetActive(true);
                    gv.AutoSellPower += 1;
                }
            }
        }

    }
    IEnumerator BuffCheck()
    {
        yield return new WaitForSeconds(1);
        {
            if (gv.MapType == 1)
            {
                if (gv.isMiningPotion > 0)
                {
                    int drilltime = (gv.isMiningPotion - 1) * gv.MiningPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTime", PotionMinerText, gv.MiningPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTime", PotionMinerText, gv.MiningPotionTime + drilltime) ==2)
                    {
                        gv.isMiningPotion = 0;
                        PlayerPrefs.SetInt("isMiningPotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionMiner.activeSelf == true)
                    {
                        PotionMiner.SetActive(false);
                        gv.MiningBuffPower -= 2;
                    }
                }
                if (gv.isMiningPotionDouble > 0)
                {
                    int drilltime = (gv.isMiningPotionDouble - 1) * gv.MiningPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTime", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTime", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isMiningPotionDouble = 0;
                        PlayerPrefs.SetInt("isMiningPotionDouble", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionMinerDouble.activeSelf == true)
                    {
                        PotionMinerDouble.SetActive(false);
                        gv.MiningBuffPower -= 10;
                    }
                }


                if (gv.isDrillPotion > 0)
                {
                    int drilltime = (gv.isDrillPotion - 1) * gv.DrillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTime", PotionDrillText, gv.DrillPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTime", PotionDrillText, gv.DrillPotionTime + drilltime) == 2)
                    {
                        gv.isDrillPotion = 0;
                        PlayerPrefs.SetInt("isDrillPotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionDrill.activeSelf == true)
                    {
                        PotionDrill.SetActive(false);
                        gv.DrillBuffPower -= 2;
                    }
                }
                if (gv.isDrillPotionDouble > 0)
                {
                    int drilltime = (gv.isDrillPotionDouble - 1) * gv.DrillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTime", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTime", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isDrillPotionDouble = 0;
                        PlayerPrefs.SetInt("isDrillPotionDouble", 0);
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

                if (gv.isSalePotion > 0)
                {
                    int drilltime = (gv.isSalePotion - 1) * gv.SalePotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTime", PotionSaleText, gv.SalePotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTime", PotionSaleText, gv.SalePotionTime + drilltime)==2)
                    {
                        gv.isSalePotion = 0;
                        PlayerPrefs.SetInt("isSalePotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionSale.activeSelf == true)
                    {
                        PotionSale.SetActive(false);
                        gv.SaleBuffPower -= 2;
                    }
                }
                if (gv.isSalePotionDouble > 0)
                {
                    int drilltime = (gv.isSalePotionDouble - 1) * gv.SalePotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTime", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTime", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) ==2)
                    {
                        gv.isSalePotionDouble = 0;
                        PlayerPrefs.SetInt("isSalePotionDouble", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionSaleDouble.activeSelf == true)
                    {
                        PotionSaleDouble.SetActive(false);
                        gv.SaleBuffPower -= 10;
                    }
                }


                if (gv.isZzangPotion > 0)
                {
                    int drilltime = (gv.isZzangPotion - 1) * gv.ZzangPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTime", PotionZzangText, gv.ZzangPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTime", PotionZzangText, gv.ZzangPotionTime + drilltime) == 2)
                    {
                        gv.isZzangPotion = 0;
                        PlayerPrefs.SetInt("isZzangPotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionZzang.activeSelf == true)
                    {
                        PotionZzang.SetActive(false);
                        gv.MiningBuffPower -= 2;
                        gv.DrillBuffPower -= 2;
                        gv.SaleBuffPower -= 2;
                        gv.buffBuffPower -= 2;
                    }
                    
                }
                if (gv.isZzangPotionDouble > 0)
                {
                    int drilltime = (gv.isZzangPotionDouble - 1) * gv.ZzangPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTime", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTime", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isZzangPotionDouble = 0;
                        PlayerPrefs.SetInt("isZzangPotionDouble", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionZaangDouble.activeSelf == true)
                    {
                        PotionZaangDouble.SetActive(false);
                        gv.MiningBuffPower -= 10;
                        gv.DrillBuffPower -= 10;
                        gv.SaleBuffPower -= 10;
                        gv.buffBuffPower -= 10;
                    }                    
                }

                if (gv.isBuffPotion > 0)
                {
                    int drilltime = (gv.isBuffPotion - 1) * gv.SkillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTime", PotionBuffText, gv.SkillPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTime", PotionBuffText, gv.SkillPotionTime + drilltime) == 2)
                    {
                        gv.isBuffPotion = 0;
                        PlayerPrefs.SetInt("isBuffPotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if(PotionBuff.activeSelf == true)
                    {
                        PotionBuff.SetActive(false);
                        gv.buffBuffPower -= 2;
                    }                    
                }
                if (gv.isBuffPotionDouble > 0)
                {
                    int drilltime = (gv.isBuffPotionDouble - 1) * gv.SkillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTime", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTime", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) == 2)
                    {
                        gv.isBuffPotionDouble = 0;
                        PlayerPrefs.SetInt("isBuffPotionDouble", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {                    
                    if(PotionBuffDouble.activeSelf == true)
                    {
                        PotionBuffDouble.SetActive(false);
                        gv.buffBuffPower -= 10;
                    }
                }

                if (gv.isAutoSellPotion > 0)
                {
                    int drilltime = (gv.isAutoSellPotion - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTime", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTime", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                        gv.isAutoSellPotion = 0;
                        PlayerPrefs.SetInt("isAutoSellPotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
                if (gv.isAutoSellDoublePotion > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotion - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTime", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTime", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isAutoSellDoublePotion = 0;
                        PlayerPrefs.SetInt("isAutoSellDoublePotion", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.isMiningPotionDesert > 0)
                {
                    int drilltime = (gv.isMiningPotionDesert - 1) * gv.MiningPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeDesert", PotionMinerText, gv.MiningPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeDesert", PotionMinerText, gv.MiningPotionTime + drilltime) ==2)
                    {
                        gv.isMiningPotionDesert = 0;
                        PlayerPrefs.SetInt("isMiningPotionDesert", 0);
                        PlayerPrefs.Save();
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeDesert", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeDesert", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) ==2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeDesert", PotionDrillText, gv.DrillPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeDesert", PotionDrillText, gv.DrillPotionTime + drilltime) ==2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeDesert", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeDesert", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeDesert", PotionSaleText, gv.SalePotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeDesert", PotionSaleText, gv.SalePotionTime + drilltime) ==2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeDesert", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeDesert", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime)== 2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeDesert", PotionZzangText, gv.ZzangPotionTime + drilltime) ==-1 ||
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeDesert", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==-1 ||
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeDesert", PotionBuffText, gv.SkillPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeDesert", PotionBuffText, gv.SkillPotionTime + drilltime) ==2)
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
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeDesert", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeDesert", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime)==2)
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
                        gv.isAutoSellPotionDesert = 0;
                        PlayerPrefs.SetInt("isAutoSellPotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
                if (gv.isAutoSellDoublePotionDesert > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionDesert - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeDesert", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeDesert", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isAutoSellDoublePotionDesert = 0;
                        PlayerPrefs.SetInt("isAutoSellDoublePotionDesert", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.isMiningPotionIce > 0)
                {
                    int drilltime = (gv.isMiningPotionIce - 1) * gv.MiningPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeIce", PotionMinerText, gv.MiningPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeIce", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {
                        gv.isMiningPotionIce = 0;
                        PlayerPrefs.SetInt("isMiningPotionIce", 0);
                        PlayerPrefs.Save();
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
                if (gv.isMiningPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isMiningPotionDoubleIce - 1) * gv.MiningPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeIce", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeIce", PotionMinerDoubleText, gv.MiningPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isMiningPotionDoubleIce = 0;
                        PlayerPrefs.SetInt("isMiningPotionDoubleIce", 0);
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


                if (gv.isDrillPotionIce > 0)
                {
                    int drilltime = (gv.isDrillPotionIce - 1) * gv.DrillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeIce", PotionDrillText, gv.DrillPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeIce", PotionDrillText, gv.DrillPotionTime + drilltime) ==2)
                    {
                        gv.isDrillPotionIce = 0;
                        PlayerPrefs.SetInt("isDrillPotionIce", 0);
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
                if (gv.isDrillPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isDrillPotionDoubleIce - 1) * gv.DrillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeIce", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeIce", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isDrillPotionDoubleIce = 0;
                        PlayerPrefs.SetInt("isDrillPotionDoubleIce", 0);
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

                if (gv.isSalePotionIce > 0)
                {
                    int drilltime = (gv.isSalePotionIce - 1) * gv.SalePotionTime; 
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeIce", PotionSaleText, gv.SalePotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeIce", PotionSaleText, gv.SalePotionTime + drilltime) ==2)
                    {
                        gv.isSalePotionIce = 0;
                        PlayerPrefs.SetInt("isSalePotionIce", 0);
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
                if (gv.isSalePotionDoubleIce > 0)
                {
                    int drilltime = (gv.isSalePotionDoubleIce - 1) * gv.SalePotionDoubleTime; 
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeIce", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeIce", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) ==2)
                    {
                        gv.isSalePotionDoubleIce = 0;
                        PlayerPrefs.SetInt("isSalePotionDoubleIce", 0);
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


                if (gv.isZzangPotionIce > 0)
                {
                    int drilltime = (gv.isZzangPotionIce - 1) * gv.ZzangPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeIce", PotionZzangText, gv.ZzangPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeIce", PotionZzangText, gv.ZzangPotionTime + drilltime) ==2)
                    {
                        gv.isZzangPotionIce = 0;
                        PlayerPrefs.SetInt("isZzangPotionIce", 0);
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
                if (gv.isZzangPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isZzangPotionDoubleIce - 1) * gv.ZzangPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeIce", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeIce", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isZzangPotionDoubleIce = 0;
                        PlayerPrefs.SetInt("isZzangPotionDoubleIce", 0);
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

                if (gv.isBuffPotionIce > 0)
                {
                    int drilltime = (gv.isBuffPotionIce - 1) * gv.SkillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeIce", PotionBuffText, gv.SkillPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeIce", PotionBuffText, gv.SkillPotionTime + drilltime) ==2)
                    {
                        gv.isBuffPotionIce = 0;
                        PlayerPrefs.SetInt("isBuffPotionIce", 0);
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
                if (gv.isBuffPotionDoubleIce > 0)
                {
                    int drilltime = (gv.isBuffPotionDoubleIce - 1) * gv.SkillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeIce", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeIce", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isBuffPotionDoubleIce = 0;
                        PlayerPrefs.SetInt("isBuffPotionDoubleIce", 0);
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
                if (gv.isAutoSellPotionIce > 0)
                {
                    int drilltime = (gv.isAutoSellPotionIce - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeIce", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeIce", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                        gv.isAutoSellPotionIce = 0;
                        PlayerPrefs.SetInt("isAutoSellPotionIce", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
                if (gv.isAutoSellDoublePotionIce > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionIce - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeIce", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeIce", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isAutoSellDoublePotionIce = 0;
                        PlayerPrefs.SetInt("isAutoSellDoublePotionIce", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.isMiningPotionForest > 0)
                {
                    int drilltime = (gv.isMiningPotionForest - 1) * gv.MiningPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeForest", PotionMinerText, gv.MiningPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeForest", PotionMinerText, gv.MiningPotionTime + drilltime) == 2)
                    {
                        gv.isMiningPotionForest = 0;
                        PlayerPrefs.SetInt("isMiningPotionForest", 0);
                        PlayerPrefs.Save();
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
                if (gv.isMiningPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isMiningPotionDoubleForest - 1) * gv.MiningPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeForest", PotionMinerDoubleText, gv.MiningPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeForest", PotionMinerDoubleText, gv.MiningPotionTime + drilltime) ==2)
                    {
                        gv.isMiningPotionDoubleForest = 0;
                        PlayerPrefs.SetInt("isMiningPotionDoubleForest", 0);
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


                if (gv.isDrillPotionForest > 0)
                {
                    int drilltime = (gv.isDrillPotionForest - 1) * gv.DrillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeForest", PotionDrillText, gv.DrillPotionTime + drilltime)==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeForest", PotionDrillText, gv.DrillPotionTime + drilltime) ==2)
                    {
                        gv.isDrillPotionForest = 0;
                        PlayerPrefs.SetInt("isDrillPotionForest", 0);
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
                if (gv.isDrillPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isDrillPotionDoubleForest - 1) * gv.DrillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeForest", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeForest", PotionDrillDoubleText, gv.DrillPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isDrillPotionDoubleForest = 0;
                        PlayerPrefs.SetInt("isDrillPotionDoubleForest", 0);
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

                if (gv.isSalePotionForest > 0)
                {
                    int drilltime = (gv.isSalePotionForest - 1) * gv.SalePotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeForest", PotionSaleText, gv.SalePotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeForest", PotionSaleText, gv.SalePotionTime + drilltime) ==2)
                    {
                        gv.isSalePotionForest = 0;
                        PlayerPrefs.SetInt("isSalePotionForest", 0);
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
                if (gv.isSalePotionDoubleForest > 0)
                {
                    int drilltime = (gv.isSalePotionDoubleForest - 1) * gv.SalePotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeForest", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeForest", PotionSaleDoubleText, gv.SalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isSalePotionDoubleForest = 0;
                        PlayerPrefs.SetInt("isSalePotionDoubleForest", 0);
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


                if (gv.isZzangPotionForest > 0)
                {
                    int drilltime = (gv.isZzangPotionForest - 1) * gv.ZzangPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeForest", PotionZzangText, gv.ZzangPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeForest", PotionZzangText, gv.ZzangPotionTime + drilltime) ==2)
                    {
                        gv.isZzangPotionForest = 0;
                        PlayerPrefs.SetInt("isZzangPotionForest", 0);
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
                if (gv.isZzangPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isZzangPotionDoubleForest - 1) * gv.ZzangPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeForest", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeForest", PotionZzangDoubleText, gv.ZzangPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isZzangPotionDoubleForest = 0;
                        PlayerPrefs.SetInt("isZzangPotionDoubleForest", 0);
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

                if (gv.isBuffPotionForest > 0)
                {
                    int drilltime = (gv.isBuffPotionForest - 1) * gv.SkillPotionTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeForest", PotionBuffText, gv.SkillPotionTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeForest", PotionBuffText, gv.SkillPotionTime + drilltime)==2)
                    {
                        gv.isBuffPotionForest = 0;
                        PlayerPrefs.SetInt("isBuffPotionForest", 0);
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
                if (gv.isBuffPotionDoubleForest > 0)
                {
                    int drilltime = (gv.isBuffPotionDoubleForest - 1) * gv.SkillPotionDoubleTime;
                    if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeForest", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) ==-1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeForest", PotionBuffDoubleText, gv.SkillPotionDoubleTime + drilltime) ==2)
                    {
                        gv.isBuffPotionDoubleForest = 0;
                        PlayerPrefs.SetInt("isBuffPotionDoubleForest", 0);
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

                if (gv.isAutoSellPotionForest > 0)
                {
                    int drilltime = (gv.isAutoSellPotionForest - 1) * gv.AutoSalePotionTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeForest", PotionAutoText, gv.AutoSalePotionTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeForest", PotionAutoText, gv.AutoSalePotionTime + drilltime) == 2)
                    {
                        gv.isAutoSellPotionForest = 0;
                        PlayerPrefs.SetInt("isAutoSellPotionForest", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAuto.activeSelf == true)
                    {
                        PotionAuto.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
                if (gv.isAutoSellDoublePotionForest > 0)
                {
                    int drilltime = (gv.isAutoSellDoublePotionForest - 1) * gv.AutoSalePotionDoubleTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeForest", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == -1 ||
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeForest", PotionAutoDubleText, gv.AutoSalePotionDoubleTime + drilltime) == 2)
                    {
                        gv.isAutoSellDoublePotionForest = 0;
                        PlayerPrefs.SetInt("isAutoSellDoublePotionForest", 0);
                        PlayerPrefs.Save();
                    }
                }
                else
                {
                    if (PotionAutoDouble.activeSelf == true)
                    {
                        PotionAutoDouble.SetActive(false);
                        gv.AutoSellPower -= 1;
                    }
                }
            }
           
        }
        StartCoroutine(BuffCheck());
    }
    void Start () {
        ChangeMapPotion();
        CheckPotion();
        CheckCertification();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void MiniGameResetByBlackCoin()
    {       
        if(gv.SelectMiniGame ==1)
        {
            gv.GhostLegCount = 0;
            gv.BlackCoinCount -= 10;
            PlayerPrefs.SetInt("GhostLegCount", gv.GhostLegCount);
            PlayerPrefs.SetInt("BlackCoin", gv.BlackCoinCount);
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
        if (gv.SelectMiniGame == 2)
        {
            gv.LottoCount = 0;
            gv.BlackCoinCount -= 10;
            PlayerPrefs.SetInt("LottoCount", gv.GhostLegCount);
            PlayerPrefs.SetInt("BlackCoin", gv.BlackCoinCount);
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
        if (gv.SelectMiniGame == 3)
        {
            gv.SpinwheelCount = 0;
            gv.BlackCoinCount -= 10;
            PlayerPrefs.SetInt("SpinwheelCount", gv.GhostLegCount);
            PlayerPrefs.SetInt("BlackCoin", gv.BlackCoinCount);
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
      
    }

    bool SpendBlackCoin(int CoinCount)
    {
        //if(gv.BlackCoinCount >= CoinCount)
        //{
        //    gv.BlackCoinCount -= CoinCount;
        //    PlayerPrefs.SetInt("BlackCoin", gv.BlackCoinCount);
        //    PlayerPrefs.Save();
        //    return true;
        //}
        //else
        //{
        //    MainStatusObj.GetComponent<PopUpManager>().NeedBlackCoinView(1);
        //    return false;
        //}
        return true;
    }

    public void UseDrillPotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isDrillPotion += 1;
            PlayerPrefs.SetInt("isDrillPotion", gv.isDrillPotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotion - 1) * gv.DrillPotionTime;
            if (gv.isDrillPotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionBuffTime", gv.DrillPotionTime);
                // PotionDrill.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTime", gv.DrillPotionTime + drilltime);
                //PotionDrill.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isDrillPotionDesert += 1;
            PlayerPrefs.SetInt("isDrillPotionDesert", gv.isDrillPotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionDesert - 1) * gv.DrillPotionTime;
            if (gv.isDrillPotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionBuffTimeDesert", gv.DrillPotionTime);
                //PotionDrill.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeDesert", gv.DrillPotionTime + drilltime);
                //PotionDrill.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isDrillPotionIce += 1;
            PlayerPrefs.SetInt("isDrillPotionIce", gv.isDrillPotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionIce - 1) * gv.DrillPotionTime;
            if (gv.isDrillPotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionBuffTimeIce", gv.DrillPotionTime);
                //PotionDrill.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeIce", gv.DrillPotionTime + drilltime);
                //PotionDrill.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isDrillPotionForest += 1;
            PlayerPrefs.SetInt("isDrillPotion", gv.isDrillPotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionForest - 1) * gv.DrillPotionTime;
            if (gv.isDrillPotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionBuffTimeForest", gv.DrillPotionTime);
                //PotionDrill.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionBuffTimeForest", gv.DrillPotionTime + drilltime);
                //PotionDrill.SetActive(true);
            }
        }
        CheckPotion();
        gv.DrillPotionTotalCount--;
        PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseDrillPotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isDrillPotionDouble += 1;
            PlayerPrefs.SetInt("isDrillPotionDouble", gv.isDrillPotionDouble);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionDouble - 1) * gv.DrillPotionDoubleTime;
            if (gv.isDrillPotionDouble == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionDoubleBuffTime", gv.DrillPotionDoubleTime);
                //PotionDrillDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTime", gv.DrillPotionDoubleTime + drilltime);
                //PotionDrillDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isDrillPotionDoubleDesert += 1;
            PlayerPrefs.SetInt("isDrillPotionDoubleDesert", gv.isDrillPotionDoubleDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionDoubleDesert - 1) * gv.DrillPotionDoubleTime;
            if (gv.isDrillPotionDoubleDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionDoubleBuffTimeDesert", gv.DrillPotionDoubleTime);
                // PotionDrillDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeDesert", gv.DrillPotionDoubleTime + drilltime);
                //PotionDrillDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isDrillPotionDoubleIce += 1;
            PlayerPrefs.SetInt("isDrillPotionDoubleIce", gv.isDrillPotionDoubleIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionDoubleIce - 1) * gv.DrillPotionDoubleTime;
            if (gv.isDrillPotionDoubleIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionDoubleBuffTimeIce", gv.DrillPotionDoubleTime);
                // PotionDrillDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeIce", gv.DrillPotionDoubleTime + drilltime);
                // PotionDrillDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isDrillPotionDoubleForest += 1;
            PlayerPrefs.SetInt("isDrillPotionDoubleForest", gv.isDrillPotionDoubleForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isDrillPotionDoubleForest - 1) * gv.DrillPotionDoubleTime;
            if (gv.isDrillPotionDoubleForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DrillPotionDoubleBuffTimeForest", gv.DrillPotionDoubleTime);
                //PotionDrillDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillPotionDoubleBuffTimeForest", gv.DrillPotionDoubleTime + drilltime);
                // PotionDrillDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.DrillDoublePotionTotalCount--;
        PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
        PlayerPrefs.Save();
    }
    public void UseMiningPotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isMiningPotion += 1;
            PlayerPrefs.SetInt("isMiningPotion", gv.isMiningPotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotion - 1) * gv.MiningPotionTime;
            if (gv.isMiningPotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionBuffTime", gv.MiningPotionTime);
                // PotionMiner.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTime", gv.MiningPotionTime + drilltime);
                //PotionMiner.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isMiningPotionDesert += 1;
            PlayerPrefs.SetInt("isMiningPotionDesert", gv.isMiningPotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionDesert - 1) * gv.MiningPotionTime;
            if (gv.isMiningPotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionBuffTimeDesert", gv.MiningPotionTime);
                //PotionMiner.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeDesert", gv.MiningPotionTime + drilltime);
                //PotionMiner.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isMiningPotionIce += 1;
            PlayerPrefs.SetInt("isMiningPotionIce", gv.isMiningPotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionIce - 1) * gv.MiningPotionTime;
            if (gv.isMiningPotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionBuffTimeIce", gv.MiningPotionTime);
                //PotionMiner.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeIce", gv.MiningPotionTime + drilltime);
                //PotionMiner.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isMiningPotionForest += 1;
            PlayerPrefs.SetInt("isDrillPotion", gv.isMiningPotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionForest - 1) * gv.MiningPotionTime;
            if (gv.isMiningPotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionBuffTimeForest", gv.MiningPotionTime);
                //PotionMiner.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionBuffTimeForest", gv.MiningPotionTime + drilltime);
                //PotionMiner.SetActive(true);
            }
        }
        CheckPotion();

        gv.MiningPotionTotalCount--;
        PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseMiningPotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isMiningPotionDouble += 1;
            PlayerPrefs.SetInt("isMiningPotionDouble", gv.isMiningPotionDouble);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionDouble - 1) * gv.MiningPotionDoubleTime;
            if (gv.isMiningPotionDouble == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionDoubleBuffTime", gv.MiningPotionDoubleTime);
                //PotionMinerDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTime", gv.MiningPotionDoubleTime + drilltime);
                //PotionMinerDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isMiningPotionDoubleDesert += 1;
            PlayerPrefs.SetInt("isMiningPotionDoubleDesert", gv.isMiningPotionDoubleDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionDoubleDesert - 1) * gv.MiningPotionDoubleTime;
            if (gv.isMiningPotionDoubleDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionDoubleBuffTimeDesert", gv.MiningPotionDoubleTime);
                //PotionMinerDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeDesert", gv.MiningPotionDoubleTime + drilltime);
                //PotionMinerDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isMiningPotionDoubleIce += 1;
            PlayerPrefs.SetInt("isMiningPotionDoubleIce", gv.isMiningPotionDoubleIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionDoubleIce - 1) * gv.MiningPotionDoubleTime;
            if (gv.isMiningPotionDoubleIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionDoubleBuffTimeIce", gv.MiningPotionDoubleTime);
                //PotionMinerDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeIce", gv.MiningPotionDoubleTime + drilltime);
                //PotionMinerDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isMiningPotionDoubleForest += 1;
            PlayerPrefs.SetInt("isMiningPotionDoubleForest", gv.isMiningPotionDoubleForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isMiningPotionDoubleForest - 1) * gv.MiningPotionDoubleTime;
            if (gv.isMiningPotionDoubleForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("MiningPotionDoubleBuffTimeForest", gv.MiningPotionDoubleTime);
                // PotionMinerDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("MiningPotionDoubleBuffTimeForest", gv.MiningPotionDoubleTime + drilltime);
                //PotionMinerDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.MiningDoublePotionTotalCount--;
        PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseSalePotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isSalePotion += 1;
            PlayerPrefs.SetInt("isSalePotion", gv.isSalePotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotion - 1) * gv.SalePotionTime;
            if (gv.isSalePotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionBuffTime", gv.SalePotionTime);
                //PotionSale.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTime", gv.SalePotionTime + drilltime);
                //PotionSale.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isSalePotionDesert += 1;
            PlayerPrefs.SetInt("isSalePotionDesert", gv.isSalePotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionDesert - 1) * gv.SalePotionTime;
            if (gv.isSalePotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionBuffTimeDesert", gv.SalePotionTime);
                //PotionSale.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeDesert", gv.SalePotionTime + drilltime);
                //PotionSale.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isSalePotionIce += 1;
            PlayerPrefs.SetInt("isSalePotionIce", gv.isSalePotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionIce - 1) * gv.SalePotionTime;
            if (gv.isSalePotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionBuffTimeIce", gv.SalePotionTime);
                // PotionSale.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionBuffTimeIce", gv.SalePotionTime + drilltime);
                //PotionSale.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isSalePotionForest += 1;
            PlayerPrefs.SetInt("isSalePotionForest", gv.isSalePotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionForest - 1) * gv.SalePotionTime;
            if (gv.isSalePotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isSalePotionForest", gv.SalePotionTime);
                //PotionSale.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isSalePotionForest", gv.SalePotionTime + drilltime);
                //PotionSale.SetActive(true);
            }
        }
        CheckPotion();

        gv.SalePotionTotalCount--;
        PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseSalePotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isSalePotionDouble += 1;
            PlayerPrefs.SetInt("isSalePotionDouble", gv.isSalePotionDouble);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionDouble - 1) * gv.SalePotionDoubleTime;
            if (gv.isSalePotionDouble == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionDoubleBuffTime", gv.SalePotionDoubleTime);
                // PotionSaleDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTime", gv.SalePotionDoubleTime + drilltime);
                // PotionSaleDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isSalePotionDoubleDesert += 1;
            PlayerPrefs.SetInt("isSalePotionDoubleDesert", gv.isSalePotionDoubleDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionDoubleDesert - 1) * gv.SalePotionDoubleTime;
            if (gv.isSalePotionDoubleDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionDoubleBuffTimeDesert", gv.SalePotionDoubleTime);
                //PotionSaleDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeDesert", gv.SalePotionDoubleTime + drilltime);
                // PotionSaleDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isSalePotionDoubleIce += 1;
            PlayerPrefs.SetInt("isSalePotionDoubleIce", gv.isSalePotionDoubleIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionDoubleIce - 1) * gv.SalePotionDoubleTime;
            if (gv.isSalePotionDoubleIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionDoubleBuffTimeIce", gv.SalePotionDoubleTime);
                // PotionSaleDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeIce", gv.SalePotionDoubleTime + drilltime);
                // PotionSaleDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isSalePotionDoubleForest += 1;
            PlayerPrefs.SetInt("isSalePotionDoubleForest", gv.isSalePotionDoubleForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isSalePotionDoubleForest - 1) * gv.SalePotionDoubleTime;
            if (gv.isSalePotionDoubleForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SalePotionDoubleBuffTimeForest", gv.SalePotionDoubleTime);
                //PotionSaleDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SalePotionDoubleBuffTimeForest", gv.SalePotionDoubleTime + drilltime);
                //PotionSaleDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.SaleDoublePotionTotalCount--;
        PlayerPrefs.SetInt("SaleDoublePotionTotalCount", gv.SaleDoublePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseZzangPotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isZzangPotion += 1;
            PlayerPrefs.SetInt("isZzangPotion", gv.isZzangPotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotion - 1) * gv.ZzangPotionTime;
            if (gv.isZzangPotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionBuffTime", gv.ZzangPotionTime);
                // PotionZzang.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTime", gv.ZzangPotionTime + drilltime);
                //PotionZzang.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isZzangPotionDesert += 1;
            PlayerPrefs.SetInt("isZzangPotionDesert", gv.isZzangPotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionDesert - 1) * gv.ZzangPotionTime;
            if (gv.isZzangPotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionBuffTimeDesert", gv.ZzangPotionTime);
                // PotionZzang.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeDesert", gv.ZzangPotionTime + drilltime);
                //PotionZzang.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isZzangPotionIce += 1;
            PlayerPrefs.SetInt("isZzangPotionIce", gv.isZzangPotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionIce - 1) * gv.ZzangPotionTime;
            if (gv.isZzangPotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionBuffTimeIce", gv.ZzangPotionTime);
                // PotionZzang.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeIce", gv.ZzangPotionTime + drilltime);
                //PotionZzang.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isZzangPotionForest += 1;
            PlayerPrefs.SetInt("isZzangPotionForest", gv.isZzangPotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionForest - 1) * gv.ZzangPotionTime;
            if (gv.isZzangPotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionBuffTimeForest", gv.ZzangPotionTime);
                // PotionZzang.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionBuffTimeForest", gv.ZzangPotionTime + drilltime);
                // PotionZzang.SetActive(true);
            }
        }
        CheckPotion();

        gv.ZzangPotionTotalCount--;
        PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseZzangPotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isZzangPotionDouble += 1;
            PlayerPrefs.SetInt("isZzangPotionDouble", gv.isZzangPotionDouble);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionDouble - 1) * gv.ZzangPotionDoubleTime;
            if (gv.isZzangPotionDouble == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionDoubleBuffTime", gv.ZzangPotionDoubleTime);
                //PotionZaangDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTime", gv.ZzangPotionDoubleTime + drilltime);
                //PotionZaangDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isZzangPotionDoubleDesert += 1;
            PlayerPrefs.SetInt("isZzangPotionDoubleDesert", gv.isZzangPotionDoubleDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionDoubleDesert - 1) * gv.ZzangPotionDoubleTime;
            if (gv.isZzangPotionDoubleDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionDoubleBuffTimeDesert", gv.ZzangPotionDoubleTime);
                // PotionZaangDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeDesert", gv.ZzangPotionDoubleTime + drilltime);
                //PotionZaangDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isZzangPotionDoubleIce += 1;
            PlayerPrefs.SetInt("isZzangPotionDoubleIce", gv.isZzangPotionDoubleIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionDoubleIce - 1) * gv.ZzangPotionDoubleTime;
            if (gv.isZzangPotionDoubleIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionDoubleBuffTimeIce", gv.ZzangPotionDoubleTime);
                //PotionZaangDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeIce", 1800 + drilltime);
                //PotionZaangDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isZzangPotionDoubleForest += 1;
            PlayerPrefs.SetInt("isZzangPotionDoubleForest", gv.isZzangPotionDoubleForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isZzangPotionDoubleForest - 1) * gv.ZzangPotionDoubleTime;
            if (gv.isZzangPotionDoubleForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("ZzangPotionDoubleBuffTimeForest", gv.ZzangPotionDoubleTime);
                //PotionZaangDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("ZzangPotionDoubleBuffTimeForest", gv.ZzangPotionDoubleTime + drilltime);
                //PotionZaangDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.ZzangDoublePotionTotalCount--;
        PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseSkillPotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isBuffPotion += 1;
            PlayerPrefs.SetInt("isBuffPotion", gv.isBuffPotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotion - 1) * gv.SkillPotionTime;
            if (gv.isBuffPotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionBuffTime", gv.SkillPotionTime);
                //PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTime", gv.SkillPotionTime + drilltime);
                //PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isBuffPotionDesert += 1;
            PlayerPrefs.SetInt("isBuffPotionDesert", gv.isBuffPotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionDesert - 1) * gv.SkillPotionTime;
            if (gv.isBuffPotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionBuffTimeDesert", gv.SkillPotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeDesert", gv.SkillPotionTime + drilltime);
                // PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isBuffPotionIce += 1;
            PlayerPrefs.SetInt("isBuffPotionIce", gv.isBuffPotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionIce - 1) * gv.SkillPotionTime;
            if (gv.isBuffPotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionBuffTimeIce", gv.SkillPotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeIce", gv.SkillPotionTime + drilltime);
                // PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isBuffPotionForest += 1;
            PlayerPrefs.SetInt("isBuffPotionForest", gv.isBuffPotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionForest - 1) * gv.SkillPotionTime;
            if (gv.isBuffPotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionBuffTimeForest", gv.SkillPotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionBuffTimeForest", gv.SkillPotionTime + drilltime);
                //PotionBuff.SetActive(true);
            }
        }
        CheckPotion();

        gv.SkillPotionTotalCount--;
        PlayerPrefs.SetInt("SkillPotionTotalCount", gv.SkillPotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseSkillPotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isBuffPotionDouble += 1;
            PlayerPrefs.SetInt("isBuffPotionDouble", gv.isBuffPotionDouble);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionDouble - 1) * gv.SkillPotionDoubleTime;
            if (gv.isBuffPotionDouble == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionDoubleBuffTime", gv.SkillPotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTime", gv.SkillPotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isBuffPotionDoubleDesert += 1;
            PlayerPrefs.SetInt("isBuffPotionDoubleDesert", gv.isBuffPotionDoubleDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionDoubleDesert - 1) * gv.SkillPotionDoubleTime;
            if (gv.isBuffPotionDoubleDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionDoubleBuffTimeDesert", gv.SkillPotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeDesert", gv.SkillPotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isBuffPotionDoubleIce += 1;
            PlayerPrefs.SetInt("isBuffPotionDoubleIce", gv.isBuffPotionDoubleIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionDoubleIce - 1) * gv.SkillPotionDoubleTime;
            if (gv.isBuffPotionDoubleIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionDoubleBuffTimeIce", gv.SkillPotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeIce", gv.SkillPotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isBuffPotionDoubleForest += 1;
            PlayerPrefs.SetInt("isBuffPotionDoubleForest", gv.isBuffPotionDoubleForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isBuffPotionDoubleForest - 1) * gv.SkillPotionDoubleTime;
            if (gv.isBuffPotionDoubleForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("BuffPotionDoubleBuffTimeForest", gv.SkillPotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("BuffPotionDoubleBuffTimeForest", gv.SkillPotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.SkillDoublePotionTotalCount--;
        PlayerPrefs.SetInt("SkillDoublePotionTotalCount", gv.SkillDoublePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void UseAutoSellpotion1()
    {
        if (gv.MapType == 1)
        {
            gv.isAutoSellPotion += 1;
            PlayerPrefs.SetInt("isAutoSellPotion", gv.isAutoSellPotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellPotion - 1) * gv.AutoSalePotionTime;
            if (gv.isAutoSellPotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellBuffTime", gv.AutoSalePotionTime);
                //PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTime", gv.AutoSalePotionTime + drilltime);
                //PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isAutoSellPotionDesert += 1;
            PlayerPrefs.SetInt("isAutoSellPotionDesert", gv.isAutoSellPotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellPotionDesert - 1) * gv.AutoSalePotionTime;
            if (gv.isAutoSellPotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellBuffTimeDesert", gv.AutoSalePotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeDesert", gv.AutoSalePotionTime + drilltime);
                // PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isAutoSellPotionIce += 1;
            PlayerPrefs.SetInt("isAutoSellPotionIce", gv.isAutoSellPotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellPotionIce - 1) * gv.AutoSalePotionTime;
            if (gv.isAutoSellPotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellBuffTimeIce", gv.AutoSalePotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeIce", gv.AutoSalePotionTime + drilltime);
                // PotionBuff.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isAutoSellPotionForest += 1;
            PlayerPrefs.SetInt("isAutoSellPotionForest", gv.isAutoSellPotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellPotionForest - 1) * gv.AutoSalePotionTime;
            if (gv.isAutoSellPotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellBuffTimeForest", gv.AutoSalePotionTime);
                // PotionBuff.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellBuffTimeForest", gv.AutoSalePotionTime + drilltime);
                //PotionBuff.SetActive(true);
            }
        }
        CheckPotion();

        gv.AutoSellPotionTotalCount--;
        PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
        PlayerPrefs.Save();
    }
    public void UseAutoSellpotion2()
    {
        if (gv.MapType == 1)
        {
            gv.isAutoSellDoublePotion += 1;
            PlayerPrefs.SetInt("isAutoSellDoublePotion", gv.isAutoSellDoublePotion);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellDoublePotion - 1) * gv.AutoSalePotionDoubleTime;
            if (gv.isAutoSellDoublePotion == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellDoubleBuffTime", gv.AutoSalePotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTime", gv.AutoSalePotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            gv.isAutoSellDoublePotionDesert += 1;
            PlayerPrefs.SetInt("isAutoSellDoublePotionDesert", gv.isAutoSellDoublePotionDesert);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellDoublePotionDesert - 1) * gv.AutoSalePotionDoubleTime;
            if (gv.isAutoSellDoublePotionDesert == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellDoubleBuffTimeDesert", gv.AutoSalePotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeDesert", gv.AutoSalePotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            gv.isAutoSellDoublePotionIce += 1;
            PlayerPrefs.SetInt("isAutoSellDoublePotionIce", gv.isAutoSellDoublePotionIce);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellDoublePotionIce - 1) * gv.AutoSalePotionDoubleTime;
            if (gv.isAutoSellDoublePotionIce == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellDoubleBuffTimeIce", gv.AutoSalePotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeIce", gv.AutoSalePotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            gv.isAutoSellDoublePotionForest += 1;
            PlayerPrefs.SetInt("isAutoSellDoublePotionForest", gv.isAutoSellDoublePotionForest);
            PlayerPrefs.Save();
            int drilltime = (gv.isAutoSellDoublePotionForest - 1) * gv.AutoSalePotionDoubleTime;
            if (gv.isAutoSellDoublePotionForest == 1)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("AutoSellDoubleBuffTimeForest", gv.AutoSalePotionDoubleTime);
                //PotionBuffDouble.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("AutoSellDoubleBuffTimeForest", gv.AutoSalePotionDoubleTime + drilltime);
                //PotionBuffDouble.SetActive(true);
            }
        }
        CheckPotion();

        gv.AutoSellDoublePotionTotalCount--;
        PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
        PlayerPrefs.Save();
    }

    public void BuyDrillPotion(int i)
    {
        if(i ==1)
        {
            if(SpendBlackCoin(100))
            {       
                //위에 사용으로 옮기면됨
                gv.DrillPotionTotalCount++;
                PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                PlayerPrefs.Save();

                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 24);
            }
            
        }
        if(i ==2)
        {
            if (SpendBlackCoin(250))
            {
                gv.DrillDoublePotionTotalCount++;
                PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 25);
            }
        }
    }

    public void BuyMiningPotion(int i)
    {
        if (i == 1)
        {
            if (SpendBlackCoin(100))
            {
                gv.MiningPotionTotalCount++;
                PlayerPrefs.SetInt("MiningPotionTotalCount", gv.MiningPotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 22);
            }

        }
        if (i == 2)
        {
            if (SpendBlackCoin(250))
            {
                gv.MiningDoublePotionTotalCount++;
                PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 23);
            }
        }
    }
    public void BuySalePotion(int i)
    {
        if (i == 1)
        {
            if (SpendBlackCoin(100))
            {
                gv.SalePotionTotalCount++;
                PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 26);
            }

        }
        if (i == 2)
        {
            if (SpendBlackCoin(250))
            {
                gv.SaleDoublePotionTotalCount++;
                PlayerPrefs.SetInt("SaleDoublePotionTotalCount", gv.SaleDoublePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 27);
            }
        }
    }
    public void BuyZaangPotion(int i)
    {
        if (i == 1)
        {
            if (SpendBlackCoin(250))
            {
                gv.ZzangPotionTotalCount++;
                PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 28);
            }

        }
        if (i == 2)
        {
            if (SpendBlackCoin(550))
            {
                gv.ZzangDoublePotionTotalCount++;
                PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 29);
            }
        }
    }
    public void BuyBuffPotion(int i)
    {
        if (i == 1)
        {
            if (SpendBlackCoin(50))
            {                
                gv.SkillPotionTotalCount++;
                PlayerPrefs.SetInt("SkillPotionTotalCount", gv.SkillPotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 30);
            }

        }
        if (i == 2)
        {
            if (SpendBlackCoin(200))
            {
                gv.SkillDoublePotionTotalCount++;
                PlayerPrefs.SetInt("SkillDoublePotionTotalCount", gv.SkillDoublePotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 31);
            }
        }
    }

    public void BuyAutoSellPotion(int i)
    {
        if (i == 1)
        {
            if (SpendBlackCoin(80))
            {
                gv.AutoSellPotionTotalCount++;
                PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 30);
            }

        }
        if (i == 2)
        {
            if (SpendBlackCoin(220))
            {
                gv.AutoSellDoublePotionTotalCount++;
                PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                PlayerPrefs.Save();
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1, 31);
            }
        }
    }


    public void BuyRandomPotion(int i)
    {

    }

    public void StartSpendBlackcoin()
    {
        //블랙코인으로 땅뚫기
        if (gv.selectIAPitem == 100)
        {
            GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetDepth();
        }
        gv.selectIAPitem = 0;
    }
}
