using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HardCodeLab.TutorialMaster;
public class TutorialController : MonoBehaviour {

    // Use this for initialization

    GlobalVariable gv;

    public TutorialMasterManager tmManager;
    List<List<GameObject>> TutorialList = new List<List<GameObject>>();

    //Hire
    public List<GameObject> Stage1_1Obj;
    public List<GameObject> Stage1_2Obj;
    public List<GameObject> Stage1_3Obj;
    public List<GameObject> Stage1_4Obj;

    //Pacement
    public List<GameObject> Stage2_1Obj;
    public List<GameObject> Stage2_2Obj;
    public List<GameObject> Stage2_3Obj;
    public List<GameObject> Stage2_4Obj;

    //UsePotion
    public List<GameObject> Stage3_1Obj;
    public List<GameObject> Stage3_2Obj;
    public List<GameObject> Stage3_3Obj;    

    //DailyMiner
    public List<GameObject> StageDailyMiner_1obj;
    public List<GameObject> StageDailyMiner_2obj;
    public List<GameObject> StageDailyMiner_3obj;


    //Craft
    public List<GameObject> Stage5_1Obj;
    public List<GameObject> Stage5_2Obj;
    public List<GameObject> Stage5_3Obj;

    //Upgrade
    public List<GameObject> Stage6_1Obj;
    public List<GameObject> Stage6_2Obj;
    public List<GameObject> Stage6_3Obj;
    public List<GameObject> Stage6_4Obj;
    public List<GameObject> Stage6_5Obj;
    public List<GameObject> Stage6_6Obj;
    public List<GameObject> Stage6_7Obj;

    //Sadari
    public List<GameObject> Stage7_1Obj;
    public List<GameObject> Stage7_2Obj;
    public List<GameObject> Stage7_3Obj;
    public List<GameObject> Stage7_4Obj;
    public List<GameObject> Stage7_5Obj;

    //DailyMiner
    public List<GameObject> Stage8_1Obj;
    public List<GameObject> Stage8_2Obj;
    public List<GameObject> Stage8_3Obj;


    //Dynamite
    public List<GameObject> Stage9_1Obj;
    public List<GameObject> Stage9_2Obj;
    public List<GameObject> Stage9_3Obj;

    public GameObject PanelObj;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {
        //for(int i=0; i<StageCount; i++)



    }
    int tutorialCount = 0;
    public void StartTutorial()
    {
        if(TutorialList.Count >0)
        {
            for (int k = 0; k < TutorialList.Count; k++)
            {
                for (int i = 0; i < TutorialList[k].Count; i++)
                {
                    TutorialList[k][i].GetComponent<Button>().enabled = true;
                }
            }
            TutorialList.Clear();
        }

        if (tutorialCount >= tmManager.Tutorials.Count)
        {
            tutorialCount = 0;
        }
        tmManager.StartTutorial(tutorialCount);

        Tutorial t = tmManager.ActiveTutorial;
        if(t.Name == "HireTutorial")
        {
            TutorialList.Add(Stage1_1Obj);
            TutorialList.Add(Stage1_2Obj);
            TutorialList.Add(Stage1_3Obj);
            TutorialList.Add(Stage1_4Obj);
        }      
        if (t.Name == "PlacementTutorial")
        {
            TutorialList.Add(Stage2_1Obj);
            TutorialList.Add(Stage2_2Obj);
            TutorialList.Add(Stage2_3Obj);
            TutorialList.Add(Stage2_4Obj);
        }

        if (t.Name == "UsePotion")
        {            
            TutorialList.Add(Stage3_1Obj);
            TutorialList.Add(Stage3_2Obj);
            TutorialList.Add(Stage3_3Obj);
            
        }
        if(t.Name == "Craft")
        {
            TutorialList.Add(Stage5_1Obj);
            TutorialList.Add(Stage5_2Obj);
            TutorialList.Add(Stage5_3Obj);
        }
        if(t.Name == "MinerUpgrade")
        {
            TutorialList.Add(Stage6_1Obj);
            TutorialList.Add(Stage6_2Obj);
            TutorialList.Add(Stage6_3Obj);
            TutorialList.Add(Stage6_4Obj);
            TutorialList.Add(Stage6_5Obj);
            TutorialList.Add(Stage6_6Obj);
            TutorialList.Add(Stage6_7Obj);
        }
        if (t.Name == "Sadari")
        {
            TutorialList.Add(Stage7_1Obj);
            TutorialList.Add(Stage7_2Obj);
            TutorialList.Add(Stage7_3Obj);
            TutorialList.Add(Stage7_4Obj);
            TutorialList.Add(Stage7_5Obj);
        }

        if(t.Name == "DailyMiner")
        {
            TutorialList.Add(Stage8_1Obj);
            TutorialList.Add(Stage8_2Obj);
            TutorialList.Add(Stage8_3Obj);
        }

        if (t.Name == "Dynamite")
        {
            TutorialList.Add(Stage9_1Obj);
            TutorialList.Add(Stage9_2Obj);
            TutorialList.Add(Stage9_3Obj);
        }

        if (TutorialList.Count >0)
        {
            for (int i = 0; i < TutorialList[0].Count; i++)
            {
                TutorialList[0][i].GetComponent<Button>().enabled = false;
            }
        }
       
        PanelObj.SetActive(true);
        //tutorialCount++;
    }
    public void StartTutorial(string name)
    {
        switch(name)
        {
            case "HireTutorial":
                tutorialCount = 0;
                break;
            case "PlacementTutorial":
                tutorialCount = 1;
                break;
            case "UsePotion":
                tutorialCount = 2;
                break;
            case "SuperviseMiner":
                tutorialCount = 3;
                break;
            case "Craft":
                tutorialCount = 4;
                break;
            case "MinerUpgrade":
                tutorialCount = 5;
                break;
            case "Sadari":
                tutorialCount = 6;
                break;
            case "DailyMiner":
                tutorialCount = 7;
                break;
            case "Dynamite":
                tutorialCount = 8;
                break;
        }
        if (tutorialCount >= tmManager.Tutorials.Count)
        {
            return;
        }
        if (TutorialList.Count > 0)
        {
            for (int k = 0; k < TutorialList.Count; k++)
            {
                for (int i = 0; i < TutorialList[k].Count; i++)
                {
                    TutorialList[k][i].GetComponent<Button>().enabled = true;
                }
            }
            TutorialList.Clear();
        }

      
        tmManager.StartTutorial(tutorialCount);

        Tutorial t = tmManager.ActiveTutorial;
        if (t.Name == "HireTutorial")
        {
            TutorialList.Add(Stage1_1Obj);
            TutorialList.Add(Stage1_2Obj);
            TutorialList.Add(Stage1_3Obj);
            TutorialList.Add(Stage1_4Obj);
        }

        if (t.Name == "PlacementTutorial")
        {
            TutorialList.Add(Stage2_1Obj);
            TutorialList.Add(Stage2_2Obj);
            TutorialList.Add(Stage2_3Obj);
            TutorialList.Add(Stage2_4Obj);
        }

        if (t.Name == "UsePotion")
        {
            TutorialList.Add(Stage3_1Obj);
            TutorialList.Add(Stage3_2Obj);
            TutorialList.Add(Stage3_3Obj);            
        }
        if (t.Name == "Craft")
        {
            TutorialList.Add(Stage5_1Obj);
            TutorialList.Add(Stage5_2Obj);
            TutorialList.Add(Stage5_3Obj);
        }
        if (t.Name == "MinerUpgrade")
        {
            TutorialList.Add(Stage6_1Obj);
            TutorialList.Add(Stage6_2Obj);
            TutorialList.Add(Stage6_3Obj);
            TutorialList.Add(Stage6_4Obj);
            TutorialList.Add(Stage6_5Obj);
            TutorialList.Add(Stage6_6Obj);
            TutorialList.Add(Stage6_7Obj);
        }
        if (t.Name == "Sadari")
        {
            TutorialList.Add(Stage7_1Obj);
            TutorialList.Add(Stage7_2Obj);
            TutorialList.Add(Stage7_3Obj);
            TutorialList.Add(Stage7_4Obj);
            TutorialList.Add(Stage7_5Obj);
        }

        if (t.Name == "DailyMiner")
        {
            TutorialList.Add(Stage8_1Obj);
            TutorialList.Add(Stage8_2Obj);
            TutorialList.Add(Stage8_3Obj);
        }

        if (t.Name == "Dynamite")
        {
            TutorialList.Add(Stage9_1Obj);
            TutorialList.Add(Stage9_2Obj);
            TutorialList.Add(Stage9_3Obj);
        }

        if (TutorialList.Count > 0)
        {
            for (int i = 0; i < TutorialList[0].Count; i++)
            {
                TutorialList[0][i].GetComponent<Button>().enabled = false;
            }
        }

        PanelObj.SetActive(true);        
    }
    // Update is called once per frame
    void Update()
    {

    } 
    public void DisablePanel()
    {
        if (PanelObj.activeSelf == true)
            PanelObj.SetActive(false);
    }
    public void EndTutorial(int number)
    {
        string name = string.Empty;
        name = tmManager.Tutorials[number].Name;

        for (int k = 0; k < TutorialList.Count; k++)
        {
            for (int i = 0; i < TutorialList[k].Count; i++)
            {
                if (TutorialList[k][i].GetComponent<Button>() != null)
                    TutorialList[k][i].GetComponent<Button>().enabled = true;
            }
        }
        TutorialList.Clear();

        switch (name)
        {
            case "HireTutorial":
                tutorialCount = 0;
                break;
            case "PlacementTutorial":
                tutorialCount = 1;                
                break;
            case "UsePotion":
                tutorialCount = 2;                
                break;
            case "SuperviseMiner":
                tutorialCount = 3;
                if (gv.isOpening == 3)
                {
                    gv.DeletePanelAll();
                    gv.DeletePanelPopupAll();
                    GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("MinerUpgrade");
                    gv.bPlacementTutorial = false;
                    gv.isOpening = 4;
                    PlayerPrefs.SetInt("Opening", 4);
                    PlayerPrefs.Save();
                }
                break;
            case "Craft":
                tutorialCount = 4;                
                break;
            case "MinerUpgrade":
                tutorialCount = 5;                
                break;
            case "Sadari":
                tutorialCount = 6;                
                break;
            case "DailyMiner":
                tutorialCount = 7;                
                break;
            case "Dynamite":
                tutorialCount = 8;                
                break;
        }

        for (int i = 0; i < 9; i++)
        {
            string strMiniQuest = "MainTutorial" + i;
            PlayerPrefs.SetInt(strMiniQuest, gv.MainTutorialList[i]);
            PlayerPrefs.Save();
        }
    }
    public void OnEndTutorialStage(int number)
    {
        if (TutorialList.Count <= number)
        {
            for (int k = 0; k < TutorialList.Count; k++)
            {
                for (int i = 0; i < TutorialList[k].Count; i++)
                {
                    if (TutorialList[k][i].GetComponent<Button>() != null)
                        TutorialList[k][i].GetComponent<Button>().enabled = true;
                }
            }
            TutorialList.Clear();
            return;
        }
        else
        {
            if (number > 0)
            {
                for (int i = 0; i < TutorialList[number-1].Count; i++)
                {
                    if (TutorialList[number-1][i].GetComponent<Button>() != null)
                        TutorialList[number-1][i].GetComponent<Button>().enabled = true;
                }            
            }
            for (int i = 0; i < TutorialList[number].Count; i++)
            {
                if(TutorialList[number][i].GetComponent<Button>() !=null)
                    TutorialList[number][i].GetComponent<Button>().enabled = false;
            }
        }

    }

}
