using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnderConstructionManager : MonoBehaviour {

    // Use this for initialization
    public GameObject ImgUnderConstruction;
    public GameObject PrograssBack;
    public GameObject Progass;
    public Text TimeText;

    int decreaseTime;

    public GameObject Particle;
    public Image HammerImage;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        SetUnderConstruction();
    }


    // Update is called once per frame
    void Update () {
		
	}
    public void EndConstruction()
    {
        HammerImage.GetComponent<Animator>().enabled = false;
        Particle.SetActive(false);
    }
    private void FixedUpdate()
    {
        if (gv.MapType == 1)
        {
            decreaseTime = (900 * gv.CrafttAdsCount);
            if (gv.isStartCraftEngineNormal == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftEngineNormalTime",
                    TimeText, gv.ListCraftTime[gv.EngineLv] - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = (gv.ListCraftTime[gv.EngineLv]  - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("isStartCraftEngineNormalTime", gv.ListCraftTime[gv.EngineLv] - decreaseTime))) / gv.ListCraftTime[gv.EngineLv] ;               
                }
            }
            if (gv.isStartCraftBitNormal == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftBitNormalTime", TimeText, gv.ListCraftTime[gv.BitLv] - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = (gv.ListCraftTime[gv.BitLv]  - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitNormalTime", gv.ListCraftTime[gv.BitLv] - decreaseTime))) / gv.ListCraftTime[gv.BitLv] ;
                }
            }
        }
        if (gv.MapType == 2)
        {
            decreaseTime = (900 * gv.CrafttAdsCountDesert);
            if (gv.isStartCraftEngineDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftEngineDesertTime", 
                    TimeText, gv.ListCraftTime[gv.EngineLv] * 2 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";

                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.EngineLv] * 2 ) -(float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftEngineDesertTime", gv.ListCraftTime[gv.EngineLv] * 2 - decreaseTime))) / (gv.ListCraftTime[gv.EngineLv] * 2 );

                }
            }
            if (gv.isStartCraftBitDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftBitDesertTime", TimeText, gv.ListCraftTime[gv.BitLv] * 2 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 2 ) -(float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitDesertTime", gv.ListCraftTime[gv.BitLv] * 2  -decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 2 );

                }
            }
        }
        if (gv.MapType == 3)
        {
            decreaseTime = (900 * gv.CrafttAdsCountIce);
            if (gv.isStartCraftEngineIce == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftEngineIceTime", TimeText, gv.ListCraftTime[gv.EngineLv] * 4 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.EngineLv] * 4 ) -(float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftEngineIceTime", gv.ListCraftTime[gv.EngineLv] * 4 - decreaseTime))) / (gv.ListCraftTime[gv.EngineLv] * 4 );
                    

                }
            }
            if (gv.isStartCraftBitIce == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftBitIceTime", TimeText, gv.ListCraftTime[gv.BitLv] * 4 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 4 ) -(float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitIceTime", gv.ListCraftTime[gv.BitLv] * 4 - decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 4 );
                    

                }
            }
        }
        if (gv.MapType == 4)
        {
            decreaseTime = (900 * gv.CrafttAdsCountForest);
            if (gv.isStartCraftEngineForest == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftEngineForestTime", TimeText, gv.ListCraftTime[gv.EngineLv] * 8 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.EngineLv] * 8 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftEngineForestTime", gv.ListCraftTime[gv.EngineLv] * 8 - decreaseTime))) / (gv.ListCraftTime[gv.EngineLv] * 8 );
                    

                }
            }
            if (gv.isStartCraftBitForest == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("isStartCraftBitForestTime", TimeText, gv.ListCraftTime[gv.BitLv] * 8 - decreaseTime) == -1)
                {
                    EndConstruction();
                    Progass.GetComponent<Image>().fillAmount = 1;
                    TimeText.text = "완료 !!";
                }
                else
                {
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 8 ) -(float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitForestTime", gv.ListCraftTime[gv.BitLv] * 8 - decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 8 );
                    

                }
            }
        }
    }

    public void HammerControll()
    {        
        HammerImage.GetComponent<Animator>().enabled = true;
        Particle.SetActive(true);
    }
    public void SetUnderConstruction()
    {
        
        if (gv.MapType ==1)
        {
            if(gv.isStartCraftEngineNormal ==1 || gv.isStartCraftBitNormal == 1)
            {
                ImgUnderConstruction.SetActive(true);
                PrograssBack.SetActive(true);
                Progass.SetActive(true);
            }
            else
            {
                ImgUnderConstruction.SetActive(false);
                PrograssBack.SetActive(false);
                Progass.SetActive(false);
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.isStartCraftEngineDesert == 1 || gv.isStartCraftBitDesert==1)
            {
                ImgUnderConstruction.SetActive(true);
                PrograssBack.SetActive(true);
                Progass.SetActive(true);
            }
            else
            {
                ImgUnderConstruction.SetActive(false);
                PrograssBack.SetActive(false);
                Progass.SetActive(false);
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.isStartCraftEngineIce== 1 || gv.isStartCraftBitIce== 1)
            {
                ImgUnderConstruction.SetActive(true);
                PrograssBack.SetActive(true);
                Progass.SetActive(true);
            }
            else
            {
                ImgUnderConstruction.SetActive(false);
                PrograssBack.SetActive(false);
                Progass.SetActive(false);
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.isStartCraftEngineForest== 1 || gv.isStartCraftBitForest== 1)
            {
                ImgUnderConstruction.SetActive(true);
                PrograssBack.SetActive(true);
                Progass.SetActive(true);
            }
            else
            {
                ImgUnderConstruction.SetActive(false);
                PrograssBack.SetActive(false);
                Progass.SetActive(false);
            }
        }
    }


}
