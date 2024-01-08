using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Hire_Drill_Manager : MonoBehaviour {

    // Use this for initialization

    public Image Progass;
    public Text FillText;
    public Text FillText2;
    public Text percentText;
    public Text percentText2;

    public GameObject Equipment;

    public GameObject EquipNow;
    public GameObject Drills;
    public GameObject Bits;

    public Text EnginePowerNow;
    public Text EnginePowerPlus;
    public Text BitPowerNow;
    public Text BitPowerPlus;

    public Text EnginePower;
    public Text BitPower;

    public Text EngineName1;
    public Text EngineName2;

    public Text BitName1;
    public Text BitName2;

    private List<GameObject> ListEngineNow = new List<GameObject>();
    private List<GameObject> ListBitNow = new List<GameObject>();

    private List<GameObject> ListEngine = new List<GameObject>();
    private List<GameObject> ListBit = new List<GameObject>();

    bool bStartStatus = false;

    int defaultY = -170;
    int marginY = -350;
    GlobalVariable gv;

    //엔진이 13이면 비트는 13A 나머지는 비트 13
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitData();
        SetDrillPos();
        
    }
    public void StartUpdate(bool flag)
    {
        bStartStatus = flag;
    }
    private void FixedUpdate()
    { 
        if(bStartStatus ==true)
        {
            int deptIndex = 0;
            if(gv.MapType ==1)
            {
                deptIndex = gv.Depth;
            }
            if (gv.MapType == 2)
            {
                deptIndex = gv.DesertDepth;
            }
            if (gv.MapType == 3)
            {
                deptIndex = gv.IceDepth;
            }
            if (gv.MapType == 4)
            {
                deptIndex = gv.ForestDepth;
            }
            if(gv.MapType ==1)
            {
                if (gv.ExpNow <= gv.DepthExp[deptIndex])
                {
                    Progass.fillAmount = (float)gv.ExpNow / (float)gv.DepthExp[deptIndex];

                    if (((float)gv.ExpNow / (float)gv.DepthExp[deptIndex ]) < 1)
                    {
                        percentText.text = ((float)gv.ExpNow / (float)gv.DepthExp[deptIndex ] * 100).ToString("N2") + " %";
                        percentText2.text = ((float)gv.ExpNow / (float)gv.DepthExp[deptIndex ] * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        percentText.text = 100 + " %";
                        percentText2.text = 100 + " %";
                        Progass.fillAmount = 1;
                    }
                    FillText.text = gv.ChangeMoney(gv.ExpNow * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex] * gv.scaleFactor);
                    
                }
                else
                {
                    percentText.text = 100 + " %";
                    percentText2.text = 100 + " %";
                    Progass.fillAmount = 1;
                    FillText.text = gv.ChangeMoney(gv.DepthExp[deptIndex] * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex ] * gv.scaleFactor);
                    
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.ExpNowDesert <= gv.DepthExp[deptIndex] * 3)
                {
                    Progass.fillAmount = (float)gv.ExpNowDesert / ((float)gv.DepthExp[deptIndex ] * 3);

                    if (((float)gv.ExpNowDesert / ((float)gv.DepthExp[deptIndex] * 3)) < 1)
                    {
                        float lv = (float)gv.ExpNowDesert / ((float)gv.DepthExp[deptIndex] * 3);
                        percentText2.text = (lv * 100).ToString("N2") + " %";
                        percentText.text = (lv * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        percentText.text = 100 + " %";
                        percentText2.text = 100 + " %";
                        Progass.fillAmount = 1;
                    }
                    FillText.text = gv.ChangeMoney(gv.ExpNowDesert * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex] * 3 * gv.scaleFactor);
                    
                }
                else
                {
                    percentText.text = 100 + " %";
                    percentText2.text = 100 + " %";
                    Progass.fillAmount = 1;
                    FillText.text = gv.ChangeMoney(gv.DepthExp[deptIndex * 10] * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex ] * 3 * gv.scaleFactor);
                    
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.ExpNowIce <= gv.DepthExp[deptIndex] * 6)
                {
                    Progass.fillAmount = (float)gv.ExpNowIce / ((float)gv.DepthExp[deptIndex ] * 6);

                    if (((float)gv.ExpNowIce / ((float)gv.DepthExp[deptIndex] * 6)) < 1)
                    {
                        float lv = (float)gv.ExpNowIce / ((float)gv.DepthExp[deptIndex] * 6);
                        percentText2.text = (lv * 100).ToString("N2") + " %";
                        percentText.text = (lv * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        percentText.text = 100 + " %";
                        percentText2.text = 100 + " %";
                        Progass.fillAmount = 1;
                    }
                    FillText.text = gv.ChangeMoney(gv.ExpNowIce * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex ] * 6 * gv.scaleFactor);
                    
                }
                else
                {
                    percentText.text = 100 + " %";
                    percentText2.text = 100 + " %";
                    Progass.fillAmount = 1;
                    FillText.text = gv.ChangeMoney(gv.DepthExp[deptIndex * 10] * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex] * 6 * gv.scaleFactor);
                    
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.ExpNowForest <= gv.DepthExp[deptIndex] * 10)
                {
                    Progass.fillAmount = (float)gv.ExpNowForest / (float)gv.DepthExp[deptIndex ] * 10;

                    if (((float)gv.ExpNowForest / ((float)gv.DepthExp[deptIndex] * 10)) < 1)
                    {
                        float lv = (float)gv.ExpNowForest / ((float)gv.DepthExp[deptIndex] * 10);
                        percentText2.text = (lv * 100).ToString("N2") + " %";
                        percentText.text = (lv * 100).ToString("N2") + " %";
                    }
                    else
                    {
                        percentText.text = 100 + " %";
                        percentText2.text = 100 + " %";
                        Progass.fillAmount = 1;
                    }
                    FillText.text = gv.ChangeMoney(gv.ExpNowForest * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex ] * 10 * gv.scaleFactor);
                    
                }
                else
                {
                    percentText.text = 100 + " %";
                    percentText2.text = 100 + " %";
                    Progass.fillAmount = 1;
                    FillText.text = gv.ChangeMoney(gv.DepthExp[deptIndex * 10] * gv.scaleFactor) + " / " + gv.ChangeMoney(gv.DepthExp[deptIndex ] * 10 * gv.scaleFactor);
                    
                }
            }

        }      
    }
  

    public void DeleteList()
    {
        ListEngineNow.Clear();
        ListBitNow.Clear();
        ListEngine.Clear();
        ListBit.Clear();
    }

    public void InitData()
    {
        GameObject DrillsList = Drills.transform.Find("Drill").gameObject;
        GameObject BitsList = Bits.transform.Find("Bit").gameObject;

        ListEngineNow.Add(EquipNow.transform.Find("DrillLvDefault").gameObject);
        ListBitNow.Add(EquipNow.transform.Find("BitLvDefault").gameObject);

        for (int i=0; i < 14; i++)
        {           
            int index = i + 1;
            string strBit = "BitLv" + index;
            string strEngine= "DrillLv" + index;
            ListEngineNow.Add(EquipNow.transform.Find(strEngine).gameObject);
            ListBitNow.Add(EquipNow.transform.Find(strBit).gameObject);

            ListEngine.Add(DrillsList.transform.Find(strEngine).gameObject);
            ListBit.Add(BitsList.transform.Find(strBit).gameObject);

        }
        ListEngineNow.Add(EquipNow.transform.Find("BitLv13A").gameObject);


        SetActiveObj();
        SetText();

    }
	
  

    void SetActiveObj()
    {        
        for(int i=0; i< 14; i++)
        {
            if (i == gv.EngineLv)
            {
                
                ListEngine[i].SetActive(true);
                ListEngineNow[i].SetActive(true);
            }
            else
            {
                ListEngine[i].SetActive(false);
                ListEngineNow[i].SetActive(false);
            }
            if (i == gv.BitLv)
            {
                ListBit[i].SetActive(true);
                ListBitNow[i].SetActive(true);
            }
            else
            {
                ListBit[i].SetActive(false);
                ListBitNow[i].SetActive(false);
            }
        }
        GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetEngine();
    }

    private void SetText()
    {
        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", EngineName1, gv.EngineLv);
        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", EngineName2, gv.EngineLv);
        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", BitName1, gv.BitLv);
        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", BitName2, gv.BitLv);
        if(gv.ListEnginePower.Count >0)
            EnginePowerNow.text = gv.ChangeMoney(gv.ListEnginePower[gv.EngineLv]* 0.000000000000000001f);
        if (gv.ListBitPower.Count > 0)
            BitPowerNow.text = gv.ChangeMoney(gv.ListBitPower[gv.BitLv] * 0.000000000000000001f);

        if (gv.ListEnginePower.Count > 0)
            EnginePower.text = gv.ChangeMoney(gv.ListEnginePower[gv.EngineLv+1] * 0.000000000000000001f);
        if (gv.ListBitPower.Count > 0)
            BitPower.text = gv.ChangeMoney(gv.ListBitPower[gv.BitLv+1] * 0.000000000000000001f);
    }

    public void SetDrillPos()
    {
        if(gv.MapType ==1)
        {
            int depth = gv.Depth - 1;

            Vector3 pos = new Vector3();
            pos.x = 0; pos.z = 0;
            pos.y = defaultY + (depth * marginY);

            Equipment.transform.localPosition = pos;
        }
        if(gv.MapType ==2)
        {
            int depth = gv.DesertDepth - 1;

            Vector3 pos = new Vector3();
            pos.x = 0; pos.z = 0;
            pos.y = defaultY + (depth * marginY);

            Equipment.transform.localPosition = pos;
        }
        if (gv.MapType == 3)
        {
            int depth = gv.IceDepth - 1;

            Vector3 pos = new Vector3();
            pos.x = 0; pos.z = 0;
            pos.y = defaultY + (depth * marginY);

            Equipment.transform.localPosition = pos;
        }
        if (gv.MapType == 4)
        {
            int depth = gv.ForestDepth - 1;

            Vector3 pos = new Vector3();
            pos.x = 0; pos.z = 0;
            pos.y = defaultY + (depth * marginY);

            Equipment.transform.localPosition = pos;
        }

    }

    public void BuyEngine()
    {
        if (gv.EngineLv < 14)
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(1,"Engine");
        //gv.EngineLv++;
        //SetActiveObj();
        //SetText();
        //GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetEngine();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        //GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetEngine();
    }
    public void CraftTimeEngine()
    {
        if (gv.MapType == 1)
        {
            gv.EngineLv++;
            //엔진 레벨 저장
            PlayerPrefs.SetInt("EngineLv", gv.EngineLv);
            PlayerPrefs.SetInt("EngineNormalLv", gv.EngineLv);
            PlayerPrefs.Save();        
            
        }
        if (gv.MapType == 2)
        {
            gv.EngineLv++;
            //엔진 레벨 저장
            PlayerPrefs.SetInt("EngineLv", gv.EngineLv);
            PlayerPrefs.SetInt("EngineDesertLv", gv.EngineLv);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.EngineLv++;
            //엔진 레벨 저장
            PlayerPrefs.SetInt("EngineLv", gv.EngineLv);
            PlayerPrefs.SetInt("EngineIceLv", gv.EngineLv);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.EngineLv++;
            //엔진 레벨 저장
            PlayerPrefs.SetInt("EngineLv", gv.EngineLv);
            PlayerPrefs.SetInt("EngineForestLv", gv.EngineLv);
            PlayerPrefs.Save();
        }
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyEngineQuset());
        SetActiveObj();
        SetText();
        GameObject.Find("MainCanvas").GetComponent<AnimCheckSrc>().SetBDrillStart(false);
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(0);
        GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetEngine();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        //GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetEngine();
    }
    public void CraftEngine()
    {
        //GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyEngineQuset());
        //SetActiveObj();
        SetText();
        GameObject.Find("MainCanvas").GetComponent<AnimCheckSrc>().SetBDrillStart(false);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(0);
        //GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetEngine();
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        gv.EngineLv++;
        GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetEngine();
        gv.EngineLv--;
        if(gv.MapType ==1)
        {
            gv.isStartCraftEngineNormal = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftEngineNormalTime", gv.ListCraftTime[gv.EngineLv]);
            PlayerPrefs.SetInt("isStartCraftEngineNormal", gv.isStartCraftEngineNormal);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.isStartCraftEngineDesert = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftEngineDesertTime", gv.ListCraftTime[gv.EngineLv] * 2);
            PlayerPrefs.SetInt("isStartCraftEngineDesert", gv.isStartCraftEngineDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.isStartCraftEngineIce = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftEngineIceTime", gv.ListCraftTime[gv.EngineLv] * 4);
            PlayerPrefs.SetInt("isStartCraftEngineIce", gv.isStartCraftEngineIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.isStartCraftEngineForest = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftEngineForestTime", gv.ListCraftTime[gv.EngineLv] * 8);
            PlayerPrefs.SetInt("isStartCraftEngineForest", gv.isStartCraftEngineForest);
            PlayerPrefs.Save();
        }

        GameObject.Find("MainCanvas").GetComponent<UnderConstructionManager>().SetUnderConstruction();
    }
    public void CraftTimeBit()
    {
        if (gv.MapType == 1)
        {
            gv.BitLv++;
            //비트 레벨 저장
            PlayerPrefs.SetInt("BitLv", gv.BitLv);
            PlayerPrefs.SetInt("BitNormalLv", gv.BitLv);
            PlayerPrefs.Save();
           
            
        }
        if (gv.MapType == 2)
        {
            gv.BitLv++;
            //비트 레벨 저장
            PlayerPrefs.SetInt("BitLv", gv.BitLv);
            PlayerPrefs.SetInt("BitDesertLv", gv.BitLv);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.BitLv++;
            //비트 레벨 저장
            PlayerPrefs.SetInt("BitLv", gv.BitLv);
            PlayerPrefs.SetInt("BitIceLv", gv.BitLv);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.BitLv++;
            //비트 레벨 저장
            PlayerPrefs.SetInt("BitLv", gv.BitLv);
            PlayerPrefs.SetInt("BitForestLv", gv.BitLv);
            PlayerPrefs.Save();
        }
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyDrillQuest());
        SetActiveObj();
        SetText();
        GameObject.Find("MainCanvas").GetComponent<AnimCheckSrc>().SetBDrillStart(false);
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(0);
        GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetDrill();
        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);

        //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        //GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetBit();
    }
    public void CraftDrill()
    {       
        //GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyDrillQuest());
        //SetActiveObj();
        SetText();
        GameObject.Find("MainCanvas").GetComponent<AnimCheckSrc>().SetBDrillStart(false);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(0);
        //GameObject.Find("MainCanvas").GetComponent<SelectEngine>().SetDrill();
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);

        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        gv.BitLv++;
        GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetBit();
        gv.BitLv--;

        if (gv.MapType == 1)
        {
            gv.isStartCraftBitNormal = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftBitNormalTime", gv.ListCraftTime[gv.BitLv]);
            PlayerPrefs.SetInt("isStartCraftBitNormal", gv.isStartCraftBitNormal);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.isStartCraftBitDesert = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftBitDesertTime", gv.ListCraftTime[gv.BitLv] * 2);
            PlayerPrefs.SetInt("isStartCraftBitDesert", gv.isStartCraftBitDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.isStartCraftBitIce = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftBitIceTime", gv.ListCraftTime[gv.BitLv] * 4);
            PlayerPrefs.SetInt("isStartCraftBitIce", gv.isStartCraftBitIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.isStartCraftBitForest = 1;
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("isStartCraftBitForestTime", gv.ListCraftTime[gv.BitLv] *8);
            PlayerPrefs.SetInt("isStartCraftBitForest", gv.isStartCraftBitForest);
            PlayerPrefs.Save();
        }

        GameObject.Find("MainCanvas").GetComponent<UnderConstructionManager>().SetUnderConstruction();
    }

    public void BuyDrill()
    {        
        if(gv.BitLv < 14)
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(1, "Drill");        
    }
 
}
