using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RobotMoveManager : MonoBehaviour {

    // Use this for initialization
    public GameObject GetRobotPanel;
    public GameObject GetRobot1;
    public GameObject GetRobot2;
    public GameObject GetRobot3;
    public GameObject GetRobot4;
    GlobalVariable gv;
    public GameObject CraftAlreadOwnObj;
    public GameObject CraftRobotPanelObj;
    public GameObject CraftRobotNotificationPanelObj;
    public GameObject SemiConductor_1;
    public GameObject SemiConductor_2;
    public GameObject SemiConductor_3;
    public GameObject SemiConductor_4;

    public GameObject NeedSemiconductor_1;
    public GameObject NeedSemiconductor_2;
    public GameObject NeedSemiconductor_3;
    public GameObject NeedSemiconductor_4;

    public Text RobotTitleText;

    public Text RobotMiningPower;
    public Text RobotMiningSpeed;
    public Text RobotMiningCapacity;

    public GameObject RobotImage1;
    public GameObject RobotImage2;
    public GameObject RobotImage3;
    public GameObject RobotImage4;
    int defaultSemiconductor1 = 100;
    int DefaultSemin_ = 100;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {

    }

    // Update is called once per frame
    void Update() {

    }
    private void OnEnable()
    {
        
    }

    void SetSemiconductor()
    {
        defaultSemiconductor1 = DefaultSemin_;
        SemiConductor_1.SetActive(false);
        SemiConductor_2.SetActive(false);
        SemiConductor_3.SetActive(false);
        SemiConductor_4.SetActive(false);
        float fill;
        switch (gv.MapType)
        {
            case 1:
                for(int i=0; i< gv.RobotNormal.Count; i++)
                {
                    if(gv.RobotNormal[i] !=0)
                    {
                        defaultSemiconductor1 += 20;
                    }
                }
                SemiConductor_1.SetActive(true);
                SemiConductor_1.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor1.ToString("N0") +" / " + defaultSemiconductor1.ToString();
                fill = (float)gv.Semiconductor1 / defaultSemiconductor1;
                SemiConductor_1.transform.Find("FillImage").GetComponent<Image>().fillAmount= fill;
                break;
            case 2:
                for (int i = 0; i < gv.RobotDesert.Count; i++)
                {
                    if (gv.RobotDesert[i] != 0)
                    {
                        defaultSemiconductor1 += 20;
                    }
                }
                SemiConductor_1.SetActive(true);
                SemiConductor_2.SetActive(true);
                SemiConductor_1.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor1.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                fill = (float)gv.Semiconductor1 / defaultSemiconductor1;
                SemiConductor_1.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;

                fill = (float)gv.Semiconductor2 / defaultSemiconductor1;
                SemiConductor_2.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor2.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                SemiConductor_2.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;
                break;
            case 3:
                for (int i = 0; i < gv.RobotIce.Count; i++)
                {
                    if (gv.RobotIce[i] != 0)
                    {
                        defaultSemiconductor1 += 20;
                    }
                }
                SemiConductor_2.SetActive(true);
                SemiConductor_3.SetActive(true);
                fill = (float)gv.Semiconductor2 / defaultSemiconductor1;
                SemiConductor_2.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor2.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                SemiConductor_2.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;
                fill = (float)gv.Semiconductor3 / defaultSemiconductor1;
                SemiConductor_3.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor3.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                SemiConductor_3.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;
                break;
            case 4:
                for (int i = 0; i < gv.RobotForest.Count; i++)
                {
                    if (gv.RobotForest[i] != 0)
                    {
                        defaultSemiconductor1 += 20;
                    }
                }
                SemiConductor_3.SetActive(true);
                SemiConductor_4.SetActive(true);
                fill = (float)gv.Semiconductor3 / defaultSemiconductor1;
                SemiConductor_3.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor3.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                SemiConductor_3.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;
                fill = (float)gv.Semiconductor4 / defaultSemiconductor1;
                SemiConductor_4.transform.Find("Text").GetComponent<Text>().text = gv.Semiconductor4.ToString("N0") + " / " + defaultSemiconductor1.ToString();
                SemiConductor_4.transform.Find("FillImage").GetComponent<Image>().fillAmount = fill;
                break;
        }
    }
    public void Initdata()
    {
        RobotImage1.SetActive(false);
        RobotImage2.SetActive(false);
        RobotImage3.SetActive(false);
        RobotImage4.SetActive(false);
        SemiConductor_1.SetActive(false);
        SemiConductor_2.SetActive(false);
        SemiConductor_3.SetActive(false);
        SemiConductor_4.SetActive(false);

        switch (gv.MapType)
        {
            case 1:
                RobotTitleText.text = "도시 로봇";
                SemiConductor_1.SetActive(true);
                RobotImage1.SetActive(true);
                break;
            case 2:
                RobotTitleText.text = "사막 로봇";
                SemiConductor_1.SetActive(true);
                SemiConductor_2.SetActive(true);
                RobotImage2.SetActive(true);
                break;
            case 3:
                RobotTitleText.text = "얼음 로봇";
                SemiConductor_2.SetActive(true);
                SemiConductor_3.SetActive(true);
                RobotImage3.SetActive(true);
                break;
            case 4:
                RobotTitleText.text = "정글 로봇";
                SemiConductor_3.SetActive(true);
                SemiConductor_4.SetActive(true);
                RobotImage4.SetActive(true);
                break;
        }
    }
    int _MapType = -1;
    public void CraftRobot(int maptype)
    {
        if (index != 9991)
        { 
            if(RobotName != string.Empty)
            {
                if (gv.bPlacementMiner == true)
                {
                    _MapType = maptype;
                    GameObject.Find("MainCanvas").GetComponent<RobotMoveManager>().PressCraftAlreadOwn(1);
                }
                else
                {              

                    GetRobotSemiconductor(maptype);  
                }
            }            
        }
    }
    void GetRobotSemiconductor(int maptype)
    {
        GetRobot1.SetActive(false);
        GetRobot2.SetActive(false);
        GetRobot3.SetActive(false);
        GetRobot4.SetActive(false);
        switch (maptype)
        {
            case 1:
                GetRobot1.SetActive(true);
                gv.Semiconductor1 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor1", gv.Semiconductor1);
                PlayerPrefs.Save();
                break;
            case 2:
                GetRobot2.SetActive(true);
                gv.Semiconductor1 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor1", gv.Semiconductor1);

                gv.Semiconductor2 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor2", gv.Semiconductor2);
                PlayerPrefs.Save();
                break;
            case 3:
                GetRobot3.SetActive(true);
                gv.Semiconductor2 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor2", gv.Semiconductor2);

                gv.Semiconductor3 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor3", gv.Semiconductor3);
                PlayerPrefs.Save();
                break;
            case 4:
                GetRobot4.SetActive(true);
                gv.Semiconductor3 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor3", gv.Semiconductor3);

                gv.Semiconductor4 -= defaultSemiconductor1;
                PlayerPrefs.SetInt("Semiconductor4", gv.Semiconductor4);
                PlayerPrefs.Save();
                break;
        }

        GameObject.Find("MainCanvas").GetComponent<HireSettingController>().AddRobotLIst(index, OriPos);
        GameObject.Find("MainCanvas").GetComponent<HireSettingController>().SetRobotPos(RobotName, index);

        GameObject.Find("MainCanvas").GetComponent<RobotSelectUIManager>().UnSetCard();
        GameObject.Find("MainCanvas").GetComponent<RobotSelectUIManager>().SetDeleteCard();

        //여기서 획득 이팩트 팍!
        PressCraftRobotPanel(0);
        PressGetRobotPanel(1);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressRobotSelect(0);
      
    }
    public void PressGetRobotPanel(int i)
    {
        if (i == 1)
        {
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("RobotGet");
            gv.AddPanelPopup(GetRobotPanel, "GetRobotPanel");
            GetRobotPanel.SetActive(true);
        }
        else
        {
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("RobotGet");
            gv.DeletePanelPopup("GetRobotPanel");
            GetRobotPanel.SetActive(false);

            if (gv.MapType == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 14)
                {
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(14, 0);                    
                }

            }
            if (gv.MapType == 2)
            {
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 24)
                {
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(24, 0);                    
                }

            }
        }
    }
    public void CraftRobot()
    {
        
        switch (gv.MapType)
        {
            case 1:
                if(gv.Semiconductor1 >= defaultSemiconductor1)
                {                    
                    CraftRobot(1);
                }
                else
                {
                    PressCraftNotificationPanel(1);
                    NeedSemiconductor_1.SetActive(true);                    
                }
                break;
            case 2:
                if (gv.Semiconductor1 >= defaultSemiconductor1 && gv.Semiconductor2 >= defaultSemiconductor1)
                {             
                    CraftRobot(2);
                }
                else
                {
                    PressCraftNotificationPanel(1);
                    NeedSemiconductor_1.SetActive(true);
                    NeedSemiconductor_2.SetActive(true);
                }
                break;
            case 3:
                if (gv.Semiconductor2 >= defaultSemiconductor1 && gv.Semiconductor3 >= defaultSemiconductor1)
                {                 
                    CraftRobot(3);
                }
                else
                {
                    PressCraftNotificationPanel(1);
                    NeedSemiconductor_2.SetActive(true);
                    NeedSemiconductor_3.SetActive(true);
                }
                break;
            case 4:
                if (gv.Semiconductor3 >= defaultSemiconductor1 && gv.Semiconductor4 >= defaultSemiconductor1)
                {
                    CraftRobot(4);
                }
                else
                {                    
                    PressCraftNotificationPanel(1);
                    NeedSemiconductor_3.SetActive(true);
                    NeedSemiconductor_4.SetActive(true);
                }
                break;
        }
    }
 
    public void PressCraftAlreadOwn(int i)
    {
        if(i==1)
        {
            gv.AddPanelPopup(CraftAlreadOwnObj, "CraftAlreadOwnObj");
            CraftAlreadOwnObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CraftAlreadOwnObj");
            CraftAlreadOwnObj.SetActive(false);
        }
    }
    public void Setindex(int k,string name,int pos)
    {
        index = k;
        RobotName = name;
        OriPos = pos-1;
    }
    string RobotName = string.Empty;
    int index = 9991;
    int OriPos = -1;
    public void PlaacementRemove()
    {
        if(index != 9991)
        {
            GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            PressCraftAlreadOwn(0);
            GetRobotSemiconductor(_MapType);     
        }
    }
    public void PressCraftRobotPanel(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(CraftRobotPanelObj, "CraftRobotPanelObj");
            SetSemiconductor();
            CraftRobotPanelObj.SetActive(true);
            Initdata();
        }
        else
        {
            gv.DeletePanelPopup("CraftRobotPanelObj");
            CraftRobotPanelObj.SetActive(false);
        }
    }
    public void PressCraftNotificationPanel(int i)
    {
        if(i ==1)
        {
            PressCraftRobotPanel(0);
            gv.AddPanelPopup(CraftRobotNotificationPanelObj, "CraftRobotNotificationPanelObj");
            CraftRobotNotificationPanelObj.SetActive(true);
           
        }
        else
        {
            NeedSemiconductor_1.SetActive(false);
            NeedSemiconductor_2.SetActive(false);
            NeedSemiconductor_3.SetActive(false);
            NeedSemiconductor_4.SetActive(false);
            gv.DeletePanelPopup("CraftRobotNotificationPanelObj");
            CraftRobotNotificationPanelObj.SetActive(false);
        }
    }

}
