using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UnderConstructionUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public List<GameObject> EngineList;
    public List<GameObject> BitList;
    public Text RibbonText;
    public GameObject Particle;
    public Button BtnComplete;
    public Text TextComplete;
    public Text TimeText;
    public GameObject Progass;


    public Button BtnAds;
    public Text TextAds;
    public int adsCooltime = 300;
    int decreaseTime;
    //번역
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //0201 bug fix test code
        //EndConstruction();
        /// bug fix test code
        /// 


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
                    Progass.GetComponent<Image>().fillAmount = (gv.ListCraftTime[gv.EngineLv] - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("isStartCraftEngineNormalTime", gv.ListCraftTime[gv.EngineLv]- decreaseTime))) / gv.ListCraftTime[gv.EngineLv] ;
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
            if(gv.CraftAdsCoolTimeCount ==1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("CraftAdsCoolTimeCountTime", TextAds, adsCooltime) == -1)
                {                    
                    gv.CraftAdsCoolTimeCount = 0;
                    PlayerPrefs.SetInt("CraftAdsCoolTimeCount", gv.CraftAdsCoolTimeCount);
                    PlayerPrefs.Save();
                    BtnAds.interactable = true;
                    setAdsCoolTime(lv);
                }
            }             
            if(gv.CraftAdsCoolTimeCount ==1)
            {
                BtnAds.interactable = false;
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
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.EngineLv] * 2 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
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
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 2 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitDesertTime", gv.ListCraftTime[gv.BitLv] * 2 - decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 2 );

                }
            }
            if (gv.CraftAdsCoolTimeCountDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("CraftAdsCoolTimeCountDesertTime", TextAds, adsCooltime) == -1)
                {                    
                    gv.CraftAdsCoolTimeCountDesert = 0;
                    PlayerPrefs.SetInt("CraftAdsCoolTimeCountDesert", gv.CraftAdsCoolTimeCountDesert);
                    PlayerPrefs.Save();
                    BtnAds.interactable = true;
                    setAdsCoolTime(lv);
                }
            }
            if (gv.CraftAdsCoolTimeCountDesert == 1)
            {
                BtnAds.interactable = false;
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
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.EngineLv] * 4 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
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
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 4 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitIceTime", gv.ListCraftTime[gv.BitLv] * 4 - decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 4 );

                }
            }
            if (gv.CraftAdsCoolTimeCountIce == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("CraftAdsCoolTimeCountIce", TextAds, adsCooltime) == -1)
                {                    
                    gv.CraftAdsCoolTimeCountIce = 0;
                    PlayerPrefs.SetInt("CraftAdsCoolTimeCountIce", gv.CraftAdsCoolTimeCountIce);
                    PlayerPrefs.Save();
                    BtnAds.interactable = true;
                    setAdsCoolTime(lv);
                }
            }
            if (gv.CraftAdsCoolTimeCountIce == 1)
            {
                BtnAds.interactable = false;
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
                    Progass.GetComponent<Image>().fillAmount = ((gv.ListCraftTime[gv.BitLv] * 8 ) - (float)(GameObject.Find("MainCanvas").GetComponent<TimerManager>().
                        GetRemantsTime("isStartCraftBitForestTime", gv.ListCraftTime[gv.BitLv] * 8 - decreaseTime))) / (gv.ListCraftTime[gv.BitLv] * 8 );

                }
            }
            if (gv.CraftAdsCoolTimeCountForest == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("CraftAdsCoolTimeCountForest", TextAds, adsCooltime) == -1)
                {                    
                    gv.CraftAdsCoolTimeCountForest = 0;
                    PlayerPrefs.SetInt("CraftAdsCoolTimeCountForest", gv.CraftAdsCoolTimeCountForest);
                    PlayerPrefs.Save();
                    BtnAds.interactable = true;
                    setAdsCoolTime(lv);
                }
            }
            if (gv.CraftAdsCoolTimeCountForest == 1)
            {
                BtnAds.interactable = false;
            }

        }
    }
    public void EndConstruction()
    {       
        CompleteCraft();
    }
    int lv;
    private void OnEnable()
    {
        
        Particle.SetActive(false);
        if (gv.MapType ==1)
        {
            if(gv.isStartCraftEngineNormal ==1)
            {
                EngineList[gv.EngineLv].SetActive(true);
                EngineList[gv.EngineLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", RibbonText, gv.EngineLv);
                //RibbonText.text += " 제작 중";
                lv = gv.EngineLv;
            }
            if(gv.isStartCraftBitNormal ==1)
            {
                BitList[gv.BitLv].SetActive(true);
                BitList[gv.BitLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", RibbonText, gv.BitLv);
                //RibbonText.text += " 제작 중";

                lv = gv.BitLv;
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.isStartCraftEngineDesert== 1)
            {
                EngineList[gv.EngineLv].SetActive(true);
                EngineList[gv.EngineLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", RibbonText, gv.EngineLv);
                //RibbonText.text += " 제작 중";
                lv = gv.EngineLv;
            }
            if (gv.isStartCraftBitDesert== 1)
            {
                BitList[gv.BitLv].SetActive(true);
                BitList[gv.BitLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", RibbonText, gv.BitLv);
                //RibbonText.text += " 제작 중";
                lv = gv.BitLv;
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.isStartCraftEngineIce== 1)
            {
                EngineList[gv.EngineLv].SetActive(true);
                EngineList[gv.EngineLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", RibbonText, gv.EngineLv);
                //RibbonText.text += " 제작 중";
                lv = gv.EngineLv;
            }
            if (gv.isStartCraftBitIce== 1)
            {
                BitList[gv.BitLv].SetActive(true);
                BitList[gv.BitLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", RibbonText, gv.BitLv);
                //RibbonText.text += " 제작 중";
                lv = gv.BitLv;
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.isStartCraftEngineForest== 1)
            {
                EngineList[gv.EngineLv].SetActive(true);
                EngineList[gv.EngineLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", RibbonText, gv.EngineLv);
                //RibbonText.text += " 제작 중";
                lv = gv.EngineLv;
            }
            if (gv.isStartCraftBitForest == 1)
            {
                BitList[gv.BitLv].SetActive(true);
                BitList[gv.BitLv].GetComponent<Animator>().SetBool("isMine", true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", RibbonText, gv.BitLv);
                //RibbonText.text += " 제작 중";
                lv = gv.BitLv;
            }
        }

        setAdsCoolTime(lv);
    }

    void setAdsCoolTime(int lvint)
    {
        if(gv.MapType ==1)
        {
            if (gv.CraftAdsCoolTimeCount == 0)
            {
                BtnAds.interactable = true;
                if (gv.ListCraftTime[lvint] <= 900)
                {
                    //TextAds.text = "광고 보고\n즉시 완료";
                }
                else
                {
                    //TextAds.text = "광보 보고\n15분 단축";
                }
            }
            else
            {
                BtnAds.interactable = false;
                //TextAds.text = "클릭";
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.CraftAdsCoolTimeCountDesert == 0)
            {
                BtnAds.interactable = true;
                if (gv.ListCraftTime[lvint] <= 900)
                {
                    //TextAds.text = "광고 보고\n즉시 완료";
                }
                else
                {
                    //TextAds.text = "광보 보고\n15분 단축";
                }
            }
            else
            {
                BtnAds.interactable = false;
                //TextAds.text = "클릭";
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.CraftAdsCoolTimeCountIce == 0)
            {
                BtnAds.interactable = true;
                if (gv.ListCraftTime[lvint] <= 900)
                {
                    //TextAds.text = "광고 보고\n즉시 완료";
                }
                else
                {
                    //TextAds.text = "광보 보고\n15분 단축";
                }
            }
            else
            {
                BtnAds.interactable = false;
                //TextAds.text = "클릭";
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.CraftAdsCoolTimeCountForest == 0)
            {
                BtnAds.interactable = true;
                if (gv.ListCraftTime[lvint] <= 900)
                {
                    //TextAds.text = "광고 보고\n즉시 완료";
                }
                else
                {
                    //TextAds.text = "광보 보고\n15분 단축";
                }
            }
            else
            {
                BtnAds.interactable = false;
                //TextAds.text = "클릭";
            }
        }

    }
    private void OnDisable()
    {
        
        for (int i=0; i< EngineList.Count; i++)
        {
            EngineList[i].SetActive(false);            
            EngineList[i].GetComponent<Animator>().SetBool("isMine", false);
        }
        for(int i=0; i< BitList.Count; i++)
        {
            BitList[i].SetActive(false);            
            BitList[i].GetComponent<Animator>().SetBool("isMine", false);
        }
        BtnComplete.interactable = false;
        Color _color;
        _color = TextComplete.color;
        _color.a = 0.58f;
        TextComplete.color = _color;
    }

    public void CompleteCraft()
    {
        BtnComplete.interactable = true;
        Color _color;
        _color = TextComplete.color;
        _color.a = 1;
        TextComplete.color = _color;
    }

    public void PressComplete()
    {
        int type = -1;
        if (gv.MapType == 1)
        {
            if (gv.isStartCraftEngineNormal == 1)
            {
                gv.isStartCraftEngineNormal = 0;
                PlayerPrefs.SetInt("isStartCraftEngineNormal", gv.isStartCraftEngineNormal);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeEngine();
                type = 1;
            }
            if (gv.isStartCraftBitNormal == 1)
            {
                gv.isStartCraftBitNormal = 0;
                PlayerPrefs.SetInt("isStartCraftBitNormal", gv.isStartCraftBitNormal);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeBit();
                type = 2;
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.isStartCraftEngineDesert == 1)
            {
                gv.isStartCraftEngineDesert = 0;
                PlayerPrefs.SetInt("isStartCraftEngineDesert", gv.isStartCraftEngineDesert);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeEngine();
                type = 1;
            }
            if (gv.isStartCraftBitDesert == 1)
            {
                gv.isStartCraftBitDesert = 0;
                PlayerPrefs.SetInt("isStartCraftBitDesert", gv.isStartCraftBitDesert);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeBit();
                type = 2;
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.isStartCraftEngineIce == 1)
            {
                gv.isStartCraftEngineIce = 0;
                PlayerPrefs.SetInt("isStartCraftEngineIce", gv.isStartCraftEngineIce);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeEngine();
                type = 1;
            }
            if (gv.isStartCraftBitIce == 1)
            {
                gv.isStartCraftBitIce = 0;
                PlayerPrefs.SetInt("isStartCraftBitIce", gv.isStartCraftBitIce);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeBit();
                type = 2;
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.isStartCraftEngineForest == 1)
            {
                gv.isStartCraftEngineForest = 0;
                PlayerPrefs.SetInt("isStartCraftEngineForest", gv.isStartCraftEngineForest);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeEngine();
                type = 1;
            }
            if (gv.isStartCraftBitForest == 1)
            {
                gv.isStartCraftBitForest = 0;
                PlayerPrefs.SetInt("isStartCraftBitForest", gv.isStartCraftBitForest);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftTimeBit();
                type = 2;
            }
        }


        GameObject.Find("MainCanvas").GetComponent<UnderConstructionManager>().SetUnderConstruction();
        GameObject.Find("MainCanvas").GetComponent<UnderConstructionManager>().HammerControll();
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressUnderConstructionCanvas(0);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCompleteCraftEquipmentObj(1, type);
        //Particle.SetActive(true);


        if (gv.MapType == 1)
        {
            gv.CraftAdsCoolTimeCount = 0;
            gv.CrafttAdsCount = 0;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountTime", 600);
            PlayerPrefs.SetInt("CraftAdsCoolTimeCount", gv.CraftAdsCoolTimeCount);
            PlayerPrefs.SetInt("CrafttAdsCount", gv.CrafttAdsCount);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.CraftAdsCoolTimeCountDesert = 0;
            gv.CrafttAdsCountDesert = 0;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountDesertTime", 600);
            PlayerPrefs.SetInt("CraftAdsCoolTimeCountDesert", gv.CraftAdsCoolTimeCountDesert);
            PlayerPrefs.SetInt("CrafttAdsCountDesert", gv.CrafttAdsCountDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.CraftAdsCoolTimeCountIce = 0;
            gv.CrafttAdsCountIce = 0;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountIceTime", 600);
            PlayerPrefs.SetInt("CraftAdsCoolTimeCountIce", gv.CraftAdsCoolTimeCountIce);
            PlayerPrefs.SetInt("CrafttAdsCountIce", gv.CrafttAdsCountIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.CraftAdsCoolTimeCountForest = 0;
            gv.CrafttAdsCountForest = 0;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("CraftAdsCoolTimeCountForestTime", 600);
            PlayerPrefs.SetInt("CraftAdsCoolTimeCountForest", gv.CraftAdsCoolTimeCountForest);
            PlayerPrefs.SetInt("CrafttAdsCountForest", gv.CrafttAdsCountForest);
            PlayerPrefs.Save();
        }
    }
}
