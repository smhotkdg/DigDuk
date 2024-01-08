using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CraftManager : MonoBehaviour
{

    // Use this for initialization
    public GameObject ObjHoitStone;
    public GameObject MainStatusObj;
    public Text Mineral1Text;
    public Text Mineral2Text;
    public Slider Mineral1Slider;
    public Slider Mineral2Slider;
    public GameObject CraftBG;
    public Text Title;
    GlobalVariable gv;
    List<GameObject> ListEngineImg = new List<GameObject>();
    List<GameObject> ListDrillImg = new List<GameObject>();
    List<GameObject> ListCapacityImg = new List<GameObject>();
    string typeStr = "";
    List<GameObject> MineralsList = new List<GameObject>();
    public GameObject CraftMineralsBG;

    public GameObject Prograss1Back;
    public GameObject ProgassFrame1;

    public GameObject Prograss2Back;
    public GameObject ProgassFrame2;

    public Image Fill2Image;
    public Image Fill1Image;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        InitData();
    }
    void Start()
    {

    }

    private void OnDisable()
    {
        for (int i = 0; i < MineralsList.Count; i++)
        {
            MineralsList[i].SetActive(false);
        }
        Prograss1Active(false);
        //Prograss2Active(false);
        ObjHoitStone.SetActive(false);
    }
    public void Prograss1Active(bool flag)
    {
        Prograss1Back.SetActive(flag);
        ProgassFrame1.SetActive(flag);
    }
    public void Prograss2Active(bool flag)
    {
        Prograss2Back.SetActive(flag);
        ProgassFrame2.SetActive(flag);
    }
    void InitData()
    {
        //Prograss1Active(false);
        //Prograss2Active(false);     
        for (int i = 1; i <= 17; i++)
        {
            string EngineName = "DrillLv" + i;
            string DrillName = "BitLv" + i;
            string CapacityName = "Capacity" + i;
            if (i < 15)
            {
                ListEngineImg.Add(CraftBG.transform.Find(EngineName).gameObject);
                ListDrillImg.Add(CraftBG.transform.Find(DrillName).gameObject);
            }
            ListCapacityImg.Add(CraftBG.transform.Find(CapacityName).gameObject);
        }
    }

    // Update is called once per frame
    void Update()
    {
        int recipeIndex = 0;
        if (typeStr == "Engine")
        {
            recipeIndex = gv.EngineLv * 2;
        }
        if (typeStr == "Drill")
        {
            recipeIndex = gv.BitLv * 2 + 1;
        }
        if (typeStr == "Capacity")
        {
            //recipeIndex = gv.iCapacityIndex * 3 + 2;
        }

        if (typeStr == "Engine")
        {
            float Cost = 0;
            int weightHoitStone = 1;
            if(gv.MapType ==1)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex];
            }
            if(gv.MapType ==2)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] *10;
                weightHoitStone = 5;
            }
            if (gv.MapType == 3)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 100;
                weightHoitStone = 10;
            }
            if (gv.MapType == 4)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 1000;
                weightHoitStone = 50;
            }

            Mineral1Slider.value = (float)gv.Money / Cost;
            Mineral1Text.text = gv.ChangeMoney(gv.Money) + " / " + gv.ChangeMoney(Cost) + "  (" + (Mineral1Slider.value * 100).ToString("N2") + " %)";


            Mineral2Slider.value = (float)gv.HoitStoneCount  / (gv.EquipmentHoitStoneCost[recipeIndex] * weightHoitStone);
            Mineral2Text.text = gv.HoitStoneCount  + " / " + gv.EquipmentHoitStoneCost[recipeIndex]*weightHoitStone + "  (" + (Mineral2Slider.value * 100).ToString("N2") + " %)";
        }
        if (typeStr == "Drill")
        {
            float Cost = 0;
            int weightHoitStone = 1;
            if (gv.MapType == 1)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex];                
            }
            if (gv.MapType == 2)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 10;
                weightHoitStone = 5;
            }
            if (gv.MapType == 3)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 100;
                weightHoitStone = 10;
            }
            if (gv.MapType == 4)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 1000;
                weightHoitStone = 50;
            }
            Mineral1Slider.value = (float)gv.Money / Cost;
            Mineral1Text.text = gv.ChangeMoney(gv.Money) + " / " + gv.ChangeMoney(Cost) + "  (" + (Mineral1Slider.value * 100).ToString("N2") + " %)";

            Mineral2Slider.value = (float)gv.HoitStoneCount  / (gv.EquipmentHoitStoneCost[recipeIndex] * weightHoitStone);
            Mineral2Text.text = gv.HoitStoneCount + " / " + gv.EquipmentHoitStoneCost[recipeIndex] * weightHoitStone + "  (" + (Mineral2Slider.value * 100).ToString("N2") + " %)";

        }
        if (typeStr == "Capacity")
        {
                
        }
    }
    public void SetType(string type)
    {
        int recipeIndex = 0;
        typeStr = type;
        if (typeStr == "Engine")
        {
            recipeIndex = gv.EngineLv * 2;
        }
        if (typeStr == "Drill")
        {
            recipeIndex = gv.BitLv * 2 + 1;
        }
        if (typeStr == "Capacity")
        {
            //recipeIndex = gv.iCapacityIndex * 3 + 2;
        }
        
        if(ListEngineImg.Count ==0)
        {
            for (int i = 1; i <= 17; i++)
            {
                string EngineName = "DrillLv" + i;
                string DrillName = "BitLv" + i;
                string CapacityName = "Capacity" + i;
                if (i < 15)
                {
                    ListEngineImg.Add(CraftBG.transform.Find(EngineName).gameObject);
                    ListDrillImg.Add(CraftBG.transform.Find(DrillName).gameObject);
                }
                ListCapacityImg.Add(CraftBG.transform.Find(CapacityName).gameObject);
            }
        }
        for (int i = 0; i < 17; i++)
        {
            if (i < 14)
            {
                if (ListEngineImg[i].activeSelf == true)
                {
                    ListEngineImg[i].SetActive(false);
                }
                if (ListDrillImg[i].activeSelf == true)
                {
                    ListDrillImg[i].SetActive(false);
                }
            }
            if (ListCapacityImg[i].activeSelf == true) 
            {
                ListCapacityImg[i].SetActive(false);
            }
        }

        if (type == "Engine")
        {
            ListEngineImg[gv.EngineLv].SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", Title, gv.EngineLv);         
            Prograss1Active(true);
            if(gv.EquipmentHoitStoneCost[recipeIndex] !=0)
            {
                ObjHoitStone.SetActive(true);
            }
          
        }
        if (type == "Drill")
        {
            ListDrillImg[gv.BitLv].SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", Title, gv.BitLv);
            //int index = -1;
            //if (gv.recipe[gv.BitLv * 3 + 1].Mineral1[0] != 0)
            //{
            //    index++;
            //    MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral1[0] - 1].SetActive(true);
            //    Vector2 vec = new Vector2();
            //    vec = MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral1[0] - 1].transform.localPosition;
            //    vec.x = -160;
            //    vec.y = 55;
            //    MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral1[0] - 1].transform.localPosition = vec;
                Prograss1Active(true);
            //    Prograss2Active(false);
            //    Fill1Image.color = gv.listTextColor[gv.recipe[gv.BitLv * 3 + 1].Mineral1[0] - 1];
            //}
            //if (gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] != 0)
            //{

            //    MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1].SetActive(true);
            //    Vector2 vec = new Vector2();
            //    vec = MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1].transform.localPosition;

            //    if (index < 0)
            //    {
            //        vec.x = -160;
            //        vec.y = 55;
            //        Prograss1Active(true);
            //        Prograss2Active(false);
            //        MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1].transform.localPosition = vec;
            //        Fill1Image.color = gv.listTextColor[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1];
            //    }
            //    else
            //    {
            //        Prograss1Active(true);
            //        Prograss2Active(true);
            //        vec.x = -160;
            //        vec.y = -65;
            //        MineralsList[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1].transform.localPosition = vec;
            //        Fill2Image.color = gv.listTextColor[gv.recipe[gv.BitLv * 3 + 1].Mineral2[0] - 1];
            //    }
            //}
            if (gv.EquipmentHoitStoneCost[recipeIndex] != 0)
            {
                ObjHoitStone.SetActive(true);
            }
        }    
       
    }

    public void PressCraft()
    {
        int recipeIndex = 0;     
        if (typeStr == "Engine")
        {
            recipeIndex = gv.EngineLv * 2;
        }
        if (typeStr == "Drill")
        {
            recipeIndex = gv.BitLv * 2 + 1;
        }
        if (typeStr == "Capacity")
        {
            //recipeIndex = gv.iCapacityIndex * 3 + 2;
        }
        
        {

            float Cost = 0;
            int weightHoitStone = 1;
            if (gv.MapType == 1)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex];
            }
            if (gv.MapType == 2)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 10;
                weightHoitStone = 5;
            }
            if (gv.MapType == 3)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 100;
                weightHoitStone = 10;
            }
            if (gv.MapType == 4)
            {
                Cost = (float)gv.EquipmentCost[recipeIndex] * 1000;
                weightHoitStone = 50;
            }

            if (gv.Money >= Cost && gv.HoitStoneCount >= (gv.EquipmentHoitStoneCost[recipeIndex] * weightHoitStone))
            {
                if (typeStr == "Engine")
                {
                    GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftEngine();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 3)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(3, 0);
                }

                if (typeStr == "Drill")
                {
                    GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().CraftDrill();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 9)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(9, 0);
                }

                if (gv.EngineLv >= 4 && gv.BitLv >= 4)
                {
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 15)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(15, 0);
                    }
                }

                gv.HoitStoneCount -= (gv.EquipmentHoitStoneCost[recipeIndex] * weightHoitStone);
                gv.Money -= Cost;

                PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                PlayerPrefs.Save();

            }      
            else if( gv. Money < Cost)
            {   
                MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "골드가 부족합니다.");
            }
            else if(gv.HoitStoneCount < gv.EquipmentHoitStoneCost[recipeIndex])
            {
                MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "HoitStone이 부족 합니다.\n(광부들이 일정 확률로 채굴 합니다.)");
            }
        }   
    }
}
