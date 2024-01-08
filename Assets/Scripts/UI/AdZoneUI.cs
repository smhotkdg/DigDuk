using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdZoneUI : MonoBehaviour {

    // Use this for initialization
    public Image PrograssDrill;    
    public Image PrograssSale;

    public Text PrograssDrillText;
    public Text PrograssSaleText;
    GlobalVariable gv;
    bool bEnable = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (bEnable == true)
        {
            if(gv.MapType ==1)
            {
                if (gv.SaleBuffCount > 0)
                {
                    int Saletime = (gv.SaleBuffCount - 1) * gv.iAdSaleBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTime", PrograssSaleText, gv.iAdSaleBuffTime + Saletime) == -1)
                    {
                        gv.SaleBuffCount = 0;
                        PlayerPrefs.SetInt("SaleBuffCount", 0);
                        PlayerPrefs.Save();
                        PrograssSale.fillAmount = 0;
                    }
                    else
                    {
                        PrograssSale.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("SaleBuffTime", gv.iAdSaleBuffTime + Saletime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssSale.fillAmount = 0;
                    PrograssSaleText.text = "";
                }

                if (gv.DrillBuffCount > 0)
                {
                    int drilltime = (gv.DrillBuffCount - 1) * gv.iAdDrillBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTime", PrograssDrillText, gv.iAdDrillBuffTime + drilltime) == -1)
                    {
                        gv.DrillBuffCount = 0;
                        PlayerPrefs.SetInt("DrillBuffCount", 0);
                        PlayerPrefs.Save();
                        PrograssDrill.fillAmount = 0;
                    }
                    else
                    {
                        PrograssDrill.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("DrillBuffTime", gv.iAdDrillBuffTime + drilltime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssDrill.fillAmount = 0;
                    PrograssDrillText.text = "";
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.SaleBuffCountDesert > 0)
                {
                    int Saletime = (gv.SaleBuffCountDesert - 1) * gv.iAdSaleBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeDesert", PrograssSaleText, gv.iAdSaleBuffTime + Saletime) == -1)
                    {
                        gv.SaleBuffCountDesert = 0;
                        PlayerPrefs.SetInt("SaleBuffCountDesert", 0);
                        PlayerPrefs.Save();
                        PrograssSale.fillAmount = 0;
                    }
                    else
                    {
                        PrograssSale.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("SaleBuffTimeDesert", gv.iAdSaleBuffTime + Saletime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssSale.fillAmount = 0;
                    PrograssSaleText.text = "";
                }

                if (gv.DrillBuffCountDesert > 0)
                {
                    int drilltime = (gv.DrillBuffCountDesert - 1) * gv.iAdDrillBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeDesert", PrograssDrillText, gv.iAdDrillBuffTime + drilltime) == -1)
                    {
                        gv.DrillBuffCountDesert = 0;
                        PlayerPrefs.SetInt("DrillBuffCountDesert", 0);
                        PlayerPrefs.Save();
                        PrograssDrill.fillAmount = 0;
                    }
                    else
                    {
                        PrograssDrill.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("DrillBuffTimeDesert", gv.iAdDrillBuffTime + drilltime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssDrill.fillAmount = 0;
                    PrograssDrillText.text = "";
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.SaleBuffCountIce > 0)
                {
                    int Saletime = (gv.SaleBuffCountIce - 1) * gv.iAdSaleBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeIce", PrograssSaleText, gv.iAdSaleBuffTime + Saletime) == -1)
                    {
                        gv.SaleBuffCountIce = 0;
                        PlayerPrefs.SetInt("SaleBuffCountIce", 0);
                        PlayerPrefs.Save();
                        PrograssSale.fillAmount = 0;
                    }
                    else
                    {
                        PrograssSale.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("SaleBuffTimeIce", gv.iAdSaleBuffTime + Saletime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssSale.fillAmount = 0;
                    PrograssSaleText.text = "";
                }

                if (gv.DrillBuffCountIce > 0)
                {
                    int drilltime = (gv.DrillBuffCountIce - 1) * gv.iAdDrillBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeIce", PrograssDrillText, gv.iAdDrillBuffTime + drilltime) == -1)
                    {
                        gv.DrillBuffCountIce = 0;
                        PlayerPrefs.SetInt("DrillBuffCountIce", 0);
                        PlayerPrefs.Save();
                        PrograssDrill.fillAmount = 0;
                    }
                    else
                    {
                        PrograssDrill.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("DrillBuffTimeIce", gv.iAdDrillBuffTime + drilltime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssDrill.fillAmount = 0;
                    PrograssDrillText.text = "";
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.SaleBuffCountForest > 0)
                {
                    int Saletime = (gv.SaleBuffCountForest - 1) * gv.iAdSaleBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SaleBuffTimeForest", PrograssSaleText, gv.iAdSaleBuffTime + Saletime) == -1)
                    {
                        gv.SaleBuffCountForest = 0;
                        PlayerPrefs.SetInt("SaleBuffCountForest", 0);
                        PlayerPrefs.Save();
                        PrograssSale.fillAmount = 0;
                    }
                    else
                    {
                        PrograssSale.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("SaleBuffTimeForest", gv.iAdSaleBuffTime + Saletime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssSale.fillAmount = 0;
                    PrograssSaleText.text = "";
                }

                if (gv.DrillBuffCountForest > 0)
                {
                    int drilltime = (gv.DrillBuffCountForest - 1) * gv.iAdDrillBuffTime;
                    if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DrillBuffTimeForest", PrograssDrillText, gv.iAdDrillBuffTime + drilltime) == -1)
                    {
                        gv.DrillBuffCountForest = 0;
                        PlayerPrefs.SetInt("DrillBuffCountForest", 0);
                        PlayerPrefs.Save();
                        PrograssDrill.fillAmount = 0;
                    }
                    else
                    {
                        PrograssDrill.fillAmount = (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().GetRemantsTime("DrillBuffTimeForest", gv.iAdDrillBuffTime + drilltime)) / (float)86400;
                    }
                }
                else
                {
                    PrograssDrill.fillAmount = 0;
                    PrograssDrillText.text = "";
                }
            }

        }
    }
    private void OnEnable()
    {
        bEnable = true;
    }
    private void OnDisable()
    {
        bEnable = false;
    }
}
