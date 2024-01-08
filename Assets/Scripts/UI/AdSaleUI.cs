using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AdSaleUI : MonoBehaviour {

    // Use this for initialization
    public Image PrograssSale;

    
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
		if(bEnable ==true)
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
            }
            if (gv.MapType ==3)
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
