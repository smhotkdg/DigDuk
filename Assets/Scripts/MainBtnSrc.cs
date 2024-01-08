using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Purchasing;

public class MainBtnSrc : MonoBehaviour
{

    // Use this for initialization
    public GameObject HoitHoitStartObj;
    public GameObject Dr;
    public GameObject DrAppViewObj;
    public GameObject RobotInfoCanvasObj;
    public GameObject RobotDrCanvasObj;
    public GameObject RobotSelectViewObj;
    public GameObject KingMIneralCanvsObj;
    public GameObject ReviewObj;
    public GameObject DrillManager;
    public Text GoldPerMineText;
    public GameObject HoitStoneObj;
    public GameObject FreeLvUPCanvasObj;
    public List<GameObject> EventCheckNormal;
    public List<GameObject> EventCheckDesert;
    public List<GameObject> EventCheckIce;
    public List<GameObject> EventCheckForest;
    public GameObject AdsBoxCanavsObj;
    public GameObject GetSomethingObj;
    public GameObject PanelDailyEventObj;
    public GameObject EventRewardPanelObj;
    public GameObject DialoguePanelObj;
    public GameObject NewEventPanelObj;
    public GameObject ComposeCanvasObj;
    public GameObject CompleteCraftEquipmentObj;
    public GameObject UnderConstructionCanvasObj;
    public GameObject DepthRewardBoxCanavsObj;
    public GameObject NewMineralObj;
    public GameObject DepthRewardPanel;
    public GameObject DayRewardObj;
    public GameObject DayRewardPopupObj;
    public GameObject MineInfoPanelObj;
    public GameObject CombiInfoObj;
    public GameObject BuyConfirmObj;
    public GameObject RewardViewObj;
    public GameObject PopupQuitApp;
    public GameObject TutorialManagerObj;
    public GameObject InappNotificationCanvas;
    public GameObject InventoryCanvasObj;
    public GameObject CardGetViewObj;
    public GameObject DynamiteCanvasObj;
    public GameObject OpeningCanvasObj;
    public GameObject CharacterSelectViewPanel;
    public GameObject QuestCanvasObj;
    public GameObject CombinationPopupObj;
    public GameObject CombinationCanvasObj;
    public GameObject LimitMiniGameObj;
    public GameObject NoticeUpgradeObj;
    public GameObject CraftCanvasObj;
    public GameObject MiniGameCanvasObj;
    public GameObject BGMSampleCanvasObj;
    public GameObject MinerInfoCanvasObj;
    public GameObject MainStatusObj;
    public GameObject MainCanvasPanel;
    public GameObject SettingCanvas;
    public GameObject QuestCanvas;
    public GameObject StatusTopCanvas;
    public GameObject PopUpgetEngineCanvas;
    public GameObject PopupGetCharectorCanvas;
    public GameObject PopupDepthBlackCoinCanvas;
    public GameObject LoadingCanvas;
    public GameObject HireShopCanvas;
    public GameObject DrillShopCanvas;
    public GameObject SellCanvas;
    public GameObject StatusCanvas;
    public GameObject ShopCanvas;
    public GameObject MapCanvas;
    public GameObject BtnShop;
    public GameObject BtnMap;
    public GameObject BtnHire;
    public GameObject BtnMove;
    public GameObject BtnStatusSetting;
    public GameObject BtnSetting;
    public GameObject BtnMiniGame;
    public GameObject BtnCapacity;
    public GameObject BtnCombination;

    private GameObject PopUpImg;
    private GameObject PopDownImg;
    private bool StatusMenuflag = false;
    private int loadingViewType = -1;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;

    }
    void Start()
    {
        PopUpImg = BtnStatusSetting.transform.Find("ImgPopUp").gameObject;
        PopDownImg = BtnStatusSetting.transform.Find("ImgPopUpDown").gameObject;

        //테스트 버전
        //gv.isOpening = 10;
        //PlayerPrefs.SetInt("Opening", 10);
        //PlayerPrefs.Save();


        //여기 정식 버전     
        if (gv.Depth > 2)
        {
            gv.isOpening = 10;
            PlayerPrefs.SetInt("Opening", 10);
            PlayerPrefs.Save();
        }
        if (gv.isOpening < 9)
        {
            PressOpeningCanvas(1);
        }

        KeyCheck();
        StartCoroutine(EventTimeCheck());
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetGoldPerSec();
        SetDrillManager();
        CheckDr();        
    }

    void CheckDr()
    {        
        if(gv.isDrStart >0)
        {
            Dr.SetActive(true);
        }
    }
    void KeyCheck()
    {
        if(gv.DesertDepth >20)
        {
            gv.IceKey = 1;
        }
        if(gv.IceDepth >20)
        {
            gv.ForestKey = 1;
        }
    }
    public void PressReview(int i)
    {
        if(i==1)
        {
            gv.AddPanelPopup(ReviewObj, "ReviewObj");
            ReviewObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("ReviewObj");
            ReviewObj.SetActive(false);
        }
    }
    public void PressReview()
    {
        Application.OpenURL("https://play.google.com/store/apps/details?id=com.Hoitstudio.HDigduk");
        PressReview(0);
    }
    public void SetDrillManager()
    {
        if (gv.DrillManagerStatus == 1)
        {
            DrillManager.SetActive(true);
        }
    }
    public void InitCheckEvent()
    {
        if (gv.MapType == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (gv.EventObjectNormal1Status > 4 || gv.EventObjectNormal1Status == 1)
                        {
                            EventCheckNormal[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectNormal2Status > 4 || gv.EventObjectNormal2Status == 1)
                        {
                            EventCheckNormal[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[1].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectNormal3Status > 4 || gv.EventObjectNormal3Status == 1)
                        {
                            EventCheckNormal[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[2].SetActive(false);
                        }
                        break;
                }
            }

        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        if (gv.EventObjectDesert2Status > 4 || gv.EventObjectDesert2Status == 1)
                        {
                            EventCheckDesert[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[0].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectDesert3Status > 4 || gv.EventObjectDesert3Status == 1)
                        {
                            EventCheckDesert[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[1].SetActive(false);
                        }
                        break;
                    case 3:
                        if (gv.EventObjectDesert4Status > 4 || gv.EventObjectDesert4Status == 1)
                        {
                            EventCheckDesert[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[2].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectDesert5Status > 4 || gv.EventObjectDesert5Status == 1)
                        {
                            EventCheckDesert[3].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[3].SetActive(false);
                        }
                        break;
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        if (gv.EventObjectIce1Status > 4 || gv.EventObjectIce1Status == 1)
                        {
                            EventCheckIce[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectIce2Status > 4 || gv.EventObjectIce2Status == 1)
                        {
                            EventCheckIce[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[1].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectIce3Status > 4 || gv.EventObjectIce3Status == 1)
                        {
                            EventCheckIce[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[2].SetActive(false);
                        }
                        break;
                    case 3:
                        if (gv.EventObjectIce4Status > 4 || gv.EventObjectIce4Status == 1)
                        {
                            EventCheckIce[3].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[3].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectIce5Status > 4 || gv.EventObjectIce5Status == 1)
                        {
                            EventCheckIce[4].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[4].SetActive(false);
                        }
                        break;
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (gv.iSelectDialogue)
                {
                    case 0:
                        if (gv.EventObjectForest1Status > 4 || gv.EventObjectForest1Status == 1)
                        {
                            EventCheckForest[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectForest2Status > 4 || gv.EventObjectForest2Status == 1)
                        {
                            EventCheckForest[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[1].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectForest5Status > 4 || gv.EventObjectForest5Status == 1)
                        {
                            EventCheckForest[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[2].SetActive(false);
                        }
                        break;
                }
            }
        }
    }

    IEnumerator EventTimeCheck()
    {
        if (gv.MapType == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                switch (i)
                {
                    case 0:
                        if (gv.EventObjectNormal1Status > 4 || gv.EventObjectNormal1Status == 1)
                        {
                            EventCheckNormal[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectNormal2Status > 4 || gv.EventObjectNormal2Status == 1)
                        {
                            EventCheckNormal[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[1].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectNormal3Status > 4 || gv.EventObjectNormal3Status == 1)
                        {
                            EventCheckNormal[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckNormal[2].SetActive(false);
                        }
                        break;
                }
            }

        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < 6; i++)
            {
                switch (i)
                {
                    case 1:
                        if (gv.EventObjectDesert2Status > 4 || gv.EventObjectDesert2Status == 1)
                        {
                            EventCheckDesert[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[0].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectDesert3Status > 4 || gv.EventObjectDesert3Status == 1)
                        {
                            EventCheckDesert[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[1].SetActive(false);
                        }
                        break;
                    case 3:
                        if (gv.EventObjectDesert4Status > 4 || gv.EventObjectDesert4Status == 1)
                        {
                            EventCheckDesert[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[2].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectDesert5Status > 4 || gv.EventObjectDesert5Status == 1)
                        {
                            EventCheckDesert[3].SetActive(true);
                        }
                        else
                        {
                            EventCheckDesert[3].SetActive(false);
                        }
                        break;
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (i)
                {
                    case 0:
                        if (gv.EventObjectIce1Status > 4 || gv.EventObjectIce1Status == 1)
                        {
                            EventCheckIce[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectIce2Status > 4 || gv.EventObjectIce2Status == 1)
                        {
                            EventCheckIce[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[1].SetActive(false);
                        }
                        break;
                    case 2:
                        if (gv.EventObjectIce3Status > 4 || gv.EventObjectIce3Status == 1)
                        {
                            EventCheckIce[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[2].SetActive(false);
                        }
                        break;
                    case 3:
                        if (gv.EventObjectIce4Status > 4 || gv.EventObjectIce4Status == 1)
                        {
                            EventCheckIce[3].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[3].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectIce5Status > 4 || gv.EventObjectIce5Status == 1)
                        {
                            EventCheckIce[4].SetActive(true);
                        }
                        else
                        {
                            EventCheckIce[4].SetActive(false);
                        }
                        break;
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < 5; i++)
            {
                switch (gv.iSelectDialogue)
                {
                    case 0:
                        if (gv.EventObjectForest1Status > 4 || gv.EventObjectForest1Status == 1)
                        {
                            EventCheckForest[0].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[0].SetActive(false);
                        }
                        break;
                    case 1:
                        if (gv.EventObjectForest2Status > 4 || gv.EventObjectForest2Status == 1)
                        {
                            EventCheckForest[1].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[1].SetActive(false);
                        }
                        break;
                    case 4:
                        if (gv.EventObjectForest5Status > 4 || gv.EventObjectForest5Status == 1)
                        {
                            EventCheckForest[2].SetActive(true);
                        }
                        else
                        {
                            EventCheckForest[2].SetActive(false);
                        }
                        break;
                }
            }
        }
        yield return new WaitForSeconds(10);
        StartCoroutine(EventTimeCheck());
    }

    public void CheckFalse()
    {
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:

                    {
                        EventCheckNormal[0].SetActive(false);
                    }
                    break;
                case 1:

                    {
                        EventCheckNormal[1].SetActive(false);
                    }
                    break;
                case 2:

                    {
                        EventCheckNormal[2].SetActive(false);
                    }
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 1:

                    {
                        EventCheckDesert[0].SetActive(false);
                    }
                    break;
                case 2:

                    {
                        EventCheckDesert[1].SetActive(false);
                    }
                    break;
                case 3:

                    {
                        EventCheckDesert[2].SetActive(false);
                    }
                    break;
                case 5:

                    {
                        EventCheckDesert[3].SetActive(false);
                    }
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:

                    {
                        EventCheckIce[0].SetActive(false);
                    }
                    break;
                case 1:

                    {
                        EventCheckIce[1].SetActive(false);
                    }
                    break;
                case 2:

                    {
                        EventCheckIce[2].SetActive(false);
                    }
                    break;
                case 3:

                    {
                        EventCheckIce[3].SetActive(false);
                    }
                    break;
                case 4:

                    {
                        EventCheckIce[4].SetActive(false);
                    }
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    {
                        EventCheckForest[0].SetActive(false);
                    }
                    break;
                case 1:
                    {
                        EventCheckForest[1].SetActive(false);
                    }
                    break;
                case 4:
                    {
                        EventCheckForest[2].SetActive(false);
                    }
                    break;
            }
        }
    }

    //사용안함
    public void PressSellCanvas(int i)
    {
        if (i == 1)
        {
            gv.bShowSellShop = true;
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            SellCanvas.SetActive(true);
            //GameObject.Find("SellCanvas").GetComponent<CapaticyManager>().SetMineralView();
            GameObject.Find("MineralsCanvas").GetComponent<CapaticyManager>().SetMineralView();
            SellCanvas.GetComponent<CapaticyManager>().initData();
            PressDrilShop(0);

        }
        else if (i == 0)
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            SellCanvas.GetComponent<Animator>().SetBool("isBack", true);
        }
        else
        {
            SellCanvas.SetActive(false);
        }
    }


    public void PressStatusMenu()
    {
        if (StatusMenuflag == false)
        {
            StatusMenuflag = true;
            StatusCanvas.GetComponent<Animator>().SetBool("SetMenu", true);
            //StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", true);
            PopDownImg.SetActive(false);
            PopUpImg.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            StatusMenuflag = false;
            StatusCanvas.GetComponent<Animator>().SetBool("SetMenu", false);
            //StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", false);
            PopDownImg.SetActive(true);
            PopUpImg.SetActive(false);
        }
    }
    public bool isActiveRobotview()
    {
        return RobotSelectViewObj.activeSelf;
    }
    public void PressRobotSelect(int i)
    {
        if (i == 1)
        {  
            StatusCanvas.GetComponent<Animator>().SetBool("SetMenu", true);
            StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", true);
            PressRobotDrCanvas(0);
            RobotSelectViewObj.SetActive(true);
            PressSellCanvas(0);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();            
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                        
            GameObject.Find("MainCanvas").GetComponent<RobotSelectUIManager>().UnSetCard();
            GameObject.Find("MainCanvas").GetComponent<RobotSelectUIManager>().SetDeleteCard();   
        }
        else
        {
            RobotSelectViewObj.SetActive(false);
            StatusCanvas.GetComponent<Animator>().SetBool("SetMenu", false);
            StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", false);
            GameObject.Find("MainCanvas").GetComponent<RobotSelectUIManager>().UnSetCard();
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);            
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
           
        }
    }
    public void PressCharacterSelect(int i)
    {
        if (i == 1)
        {

            CharacterSelectViewPanel.SetActive(true);
            PressSellCanvas(0);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            gv.strCharacterSelect = "";
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            StatusCanvas.GetComponent<Animator>().SetBool("SetMove", true);
            StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", true);
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().UnSetCard();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetDeleteCard();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().UpdateFlag(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetAnim(false);
            gv.bStartMine = false;
            PressDrilShop(0);
            if (gv.isOpening == 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            }
        }
        else
        {
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CharacterSelectViewPanel.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);

            StatusCanvas.GetComponent<Animator>().SetBool("SetMove", false);
            StatusTopCanvas.GetComponent<Animator>().SetBool("SetMenu", false);
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().UnSetCard();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().UpdateFlag(false);
            if (gv.CapacityNow < gv.listMaxCapacity[gv.iCapacityIndex])
            {
                GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().FalseView();
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetAnim(true);
            }
            gv.bStartMine = true;
            if (gv.isOpening == 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            }
            
            if (gv.isOpening == 2)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("SuperviseMiner");
                gv.bPlacementTutorial = true;
                gv.isOpening = 3;
                PlayerPrefs.SetInt("Opening", 3);
                PlayerPrefs.Save();
            }

            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetGoldPerSec();
        }
    }

    public void PressMap(int i)
    {
        if (i == 1)
        {
            PressSellCanvas(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            loadingViewType = 1;
            PressLoadingCanvas(1);
            PressDrilShop(0);
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            loadingViewType = 2;
            PressLoadingCanvas(1);
        }
    }

    //상점 오픈
    public void PressShop(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(ShopCanvas, "ShopCanvas");
            gv.DeletePanelPopupAll();
            PressHireShop(0);
            PressSellCanvas(0);
            PressMinerInfoCanvas(0);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("Main Camera").GetComponent<InappUIManager>().SetMoney();
            ShopCanvas.SetActive(true);
            ShopCanvas.GetComponent<ShopCanvas>().SetView();
            PressDrilShop(0);
        }
        else
        {
            gv.DeletePanel("ShopCanvas");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            ShopCanvas.GetComponent<ShopCanvas>().PressStaterPack(0);
            ShopCanvas.GetComponent<ShopCanvas>().PresslowMInerPack(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressMiddleMinerPack(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressHighMinerPack(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressLowManager(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressMiddleManager(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressHighManager(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressNinja(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressNinja2(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressDino(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressPanda(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressRandomMinerPack1(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressRandomMinerPack2(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressRandomMinerPack3(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressSpecialMinerPack1(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressSpecialMinerPack2(0);

            ShopCanvas.GetComponent<ShopCanvas>().PressCoinPack1(0);
            ShopCanvas.GetComponent<ShopCanvas>().PressCoinPack2(0);

            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            ShopCanvas.SetActive(false);

            if (gv.isOpening == 5)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                SIS.DBManager.IncreaseFunds("blackcoin", 12);
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("Dynamite");
                gv.isOpening = 6;
                PlayerPrefs.SetInt("Opening", 6);
                PlayerPrefs.Save();
            }
        }
    }

    IEnumerator bChangeFlag()
    {
        yield return new WaitForSeconds(0.2f);
        gv.bShowDrillShop = true;
    }
    //드릴샵
    public void PressDrilShop(int i)
    {
        if (i == 1)
        {
            if (gv.MapType == 1)
            {
                if (gv.isStartCraftEngineNormal == 1 || gv.isStartCraftBitNormal == 1)
                {
                    PressUnderConstructionCanvas(1);
                }
                else
                {
                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                    //MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                    PressSellCanvas(0);
                    DrillShopCanvas.SetActive(true);
                    this.GetComponent<Hire_Drill_Manager>().StartUpdate(true);
                    StartCoroutine(bChangeFlag());
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.isStartCraftEngineDesert == 1 || gv.isStartCraftBitDesert == 1)
                {
                    PressUnderConstructionCanvas(1);
                }
                else
                {
                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                    //MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                    PressSellCanvas(0);
                    DrillShopCanvas.SetActive(true);
                    this.GetComponent<Hire_Drill_Manager>().StartUpdate(true);
                    StartCoroutine(bChangeFlag());
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.isStartCraftEngineIce == 1 || gv.isStartCraftBitIce == 1)
                {
                    PressUnderConstructionCanvas(1);
                }
                else
                {
                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                    //MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                    PressSellCanvas(0);
                    DrillShopCanvas.SetActive(true);
                    this.GetComponent<Hire_Drill_Manager>().StartUpdate(true);
                    StartCoroutine(bChangeFlag());
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.isStartCraftEngineForest == 1 || gv.isStartCraftBitForest == 1)
                {
                    PressUnderConstructionCanvas(1);
                }
                else
                {
                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                    //MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                    PressSellCanvas(0);
                    DrillShopCanvas.SetActive(true);
                    this.GetComponent<Hire_Drill_Manager>().StartUpdate(true);
                    StartCoroutine(bChangeFlag());
                }
            }

            gv.AddPanel(DrillShopCanvas, "DrillShopCanvas");
        }
        else if (i == 2)
        {
            DrillShopCanvas.GetComponent<Animator>().SetBool("IsBack", true);

        }
        if (i == 0)
        {
            gv.DeletePanel("DrillShopCanvas");
            //MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            if (DrillShopCanvas.activeSelf == true)
            {
                gv.bShowDrillShop = false;
                DrillShopCanvas.SetActive(false);
                this.GetComponent<Hire_Drill_Manager>().StartUpdate(false);
            }
            if (gv.isOpening == 7)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().ScrollTop(1);
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("UsePotion");
                gv.isOpening = 8;
                PlayerPrefs.SetInt("Opening", 8);
                PlayerPrefs.Save();
            }
        }
    }
    //고용센터
    public void PressHireShop(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(HireShopCanvas, "HireShopCanvas");
            PressSellCanvas(0);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            Vector2 vec = new Vector2();
            vec.x = -1000;
            MainCanvasPanel.transform.localPosition = vec;
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            HireShopCanvas.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<HireController>().SetView();
            if (gv.isOpening == 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            }
            PressDrilShop(0);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
        }
        else
        {
            gv.DeletePanel("HireShopCanvas");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            Vector2 vec = new Vector2();
            vec.x = 0;
            MainCanvasPanel.transform.localPosition = vec;
            GameObject.Find("MainCanvas").GetComponent<HireController>().ResetSelectList();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            HireShopCanvas.SetActive(false);
        }
    }

    //로딩화면 
    public void PressLoadingCanvas(int i)
    {
        if (i == 1)
        {
            PressSellCanvas(0);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            LoadingCanvas.SetActive(true);
            PressDrilShop(0);
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            LoadingCanvas.SetActive(false);
        }
    }

    public void SetEndView()
    {
        if (loadingViewType == 2)
        {
            MapCanvas.SetActive(false);
            if (gv.bChangeMap == true)
                StartCoroutine(StartRewardView());

            loadingViewType = -1;
        }
    }
    IEnumerator StartRewardView()
    {
        yield return new WaitForSeconds(0.3f);
        GameObject.Find("MainCanvas").GetComponent<TimeRewardManager>().CheckTimeManager();
    }
    public void SetLoadingView()
    {
        if (loadingViewType == 1)
        {
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            MapCanvas.SetActive(true);
        }

    }

    //땅굴파는 슉슉
    bool isDepth = false;


    private void FixedUpdate()
    {        
        if (isDepth == true)
        {
            GameObject temp = PopupDepthBlackCoinCanvas.transform.Find("Panel").gameObject;
            temp = temp.transform.Find("BG").gameObject;
            temp = temp.transform.Find("TextBlackCoin").gameObject;
            float percent = 0;
            percent = GameObject.Find("MainCanvas").GetComponent<MapContorller>().GetTimePercent();
            PressDrilShop(0);
            if (gv.MapType == 1)
            {
                float a;
                a = (gv.Depth - 1) * (gv.Depth - 1) * 15 + 10;

                a = a * (1 - percent);
                a = (int)a;
                if (a == 0)
                {
                    a = 1;
                }
                temp.GetComponent<Text>().text = a.ToString();
            }
            if (gv.MapType == 2)
            {
                float a;
                a = (gv.DesertDepth - 1) * (gv.DesertDepth - 1) * 15 + 10;
                a = a * (1 - percent);
                a = (int)a;
                if (a == 0)
                {
                    a = 1;
                }
                temp.GetComponent<Text>().text = a.ToString();
            }
            if (gv.MapType == 3)
            {
                float a;
                a = (gv.IceDepth - 1) * (gv.IceDepth - 1) * 15 + 10;
                a = a * (1 - percent);
                a = (int)a;
                if (a == 0)
                {
                    a = 1;
                }
                temp.GetComponent<Text>().text = a.ToString();
            }
            if (gv.MapType == 4)
            {
                float a;
                a = (gv.ForestDepth - 1) * (gv.ForestDepth - 1) * 15 + 10;
                a = a * (1 - percent);
                a = (int)a;
                if (a == 0)
                {
                    a = 1;
                }
                temp.GetComponent<Text>().text = a.ToString();
            }
        }

        //if(gv.isOpening)
        Vector3 vec;
        if(this.transform.Find("ArrowModule_0") !=null)
        {
            vec = this.transform.Find("ArrowModule_0").gameObject.transform.localPosition;
            vec.z = 0;
            this.transform.Find("ArrowModule_0").gameObject.transform.localPosition = vec;
        }
        if (this.transform.Find("HighlightModule_0") != null)
        {
            vec = this.transform.Find("HighlightModule_0").gameObject.transform.localPosition;
            vec.z = 0;
            this.transform.Find("HighlightModule_0").gameObject.transform.localPosition = vec;
        }
        if (this.transform.Find("ImageModule_0") != null)
        {
            vec = this.transform.Find("ImageModule_0").gameObject.transform.localPosition;
            vec.z = 0;
            this.transform.Find("ImageModule_0").gameObject.transform.localPosition = vec;
        }
    }
    

    public void PressPopupDepthBlackCoinCanvas(int i)
    {
        if (i == 1)
        {
            if(gv.isOpening > 1)
            {
                if (this.GetComponent<MapContorller>().GetFill() >= 1)
                {

                    gv.AddPanelPopup(PopupDepthBlackCoinCanvas, "PopupDepthBlackCoinCanvas");
                    PressSellCanvas(0);
                    isDepth = true;

                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                    PopupDepthBlackCoinCanvas.SetActive(true);
                    GameObject temp = PopupDepthBlackCoinCanvas.transform.Find("Panel").gameObject;
                    temp = temp.transform.Find("BG").gameObject;
                    temp = temp.transform.Find("TextBlackCoin").gameObject;
                    float percent = 0;
                    percent = GameObject.Find("MainCanvas").GetComponent<MapContorller>().GetTimePercent();
                    PressDrilShop(0);
                    if (gv.MapType == 1)
                    {
                        float a;
                        a = (gv.Depth - 1) * (gv.Depth - 1) * 15 + 10;

                        a = a * (1 - percent);
                        a = (int)a;
                        if (a == 0)
                        {
                            a = 1;
                        }
                        temp.GetComponent<Text>().text = a.ToString();
                    }
                    if (gv.MapType == 2)
                    {
                        float a;
                        a = (gv.DesertDepth - 1) * (gv.DesertDepth - 1) * 15 + 10;
                        a = a * (1 - percent);
                        a = (int)a;
                        if (a == 0)
                        {
                            a = 1;
                        }
                        temp.GetComponent<Text>().text = a.ToString();
                    }
                    if (gv.MapType == 3)
                    {
                        float a;
                        a = (gv.IceDepth - 1) * (gv.IceDepth - 1) * 15 + 10;
                        a = a * (1 - percent);
                        a = (int)a;
                        if (a == 0)
                        {
                            a = 1;
                        }
                        temp.GetComponent<Text>().text = a.ToString();
                    }
                    if (gv.MapType == 4)
                    {
                        float a;
                        a = (gv.ForestDepth - 1) * (gv.ForestDepth - 1) * 15 + 10;
                        a = a * (1 - percent);
                        a = (int)a;
                        if (a == 0)
                        {
                            a = 1;
                        }
                        temp.GetComponent<Text>().text = a.ToString();
                    }

                    //if(gv.isOpening )
                    {


                    }
                }
                else
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("다이너마이트 설치 필요 !!\n(드릴 100% 필요)");
                }
            }
        }
        else
        {
            isDepth = false;
            gv.DeletePanelPopup("PopupDepthBlackCoinCanvas");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            PopupDepthBlackCoinCanvas.SetActive(false);
        }
    }
    //?? 이건 뭘까
    public void BoomClick()
    {
        //2번째에 들어오면 팝업띄우기
        PressPopupDepthBlackCoinCanvas(1);

    }

    //캐릭터 얻음
    public void PressPopupGetCharectorCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PopupGetCharectorCanvas, "PopupGetCharectorCanvas");
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            PopupGetCharectorCanvas.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

        }
        else
        {
            gv.DeletePanelPopup("PopupGetCharectorCanvas");
            PopupGetCharectorCanvas.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            //Debug.Log("end!!");
            GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();

            if (gv.isOpening == 1)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("PlacementTutorial");                
                gv.isOpening = 2;
                PlayerPrefs.SetInt("Opening", 2);
                PlayerPrefs.Save();
            }
            if(gv.isDrStart ==0)
            {
                int count = 0;
                for(int k=0; k< gv.ListHireCount.Count; k++)
                {
                    if(gv.ListHireCount[k] !=0)
                    {
                        count++;
                    }
                }
                if(count >4)
                {
                    PressDrView(1);
                }
            }
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 16)
            {
                int index2 = 0;
                for (int k = 0; k < gv.ListHireCount.Count; k++)
                {
                    if (gv.ListHireCount[k] != 0)
                    {
                        index2++;
                    }
                }
                
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(16, index2);

            }
            
        }
    }
    //두번째 캐릭터 얻음
    public void PressPopupGetCharectorCanvas(int i, int hirenum)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PopupGetCharectorCanvas, "PopupGetCharectorCanvas");
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            PopupGetCharectorCanvas.SetActive(true);
            GameObject.Find("PopupGetCharacterCanvas").GetComponent<PopupGetCharacter>().SetMinerImg(hirenum);
            if (gv.MapType == 1)
            {
                if (gv.ListHireCount[hirenum] != 0 && gv.ListHireCount[hirenum] != 1000)
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetBoard();
                }
                else
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetAnim();
                }
                if (gv.ListHireCount[gv.selectNumber] < 0 && gv.ListHireCount[hirenum] == 1000)
                {

                }
                else
                {
                    if (gv.ListHireCount[gv.selectNumber] == 0)
                        gv.ListHireCount[gv.selectNumber] = 1;
                    int index = gv.selectNumber + 1;
                    string strHireCount = "HireCount" + index;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[gv.selectNumber]);
                    PlayerPrefs.Save();
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.ListHireDesertCount[hirenum] != 0 && gv.ListHireDesertCount[hirenum] != 1000)
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetBoard();
                }
                else
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetAnim();
                }
                if (gv.ListHireDesertCount[gv.selectNumber] < 0 && gv.ListHireDesertCount[hirenum] == 1000)
                {

                }
                else
                {
                    gv.ListHireDesertCount[gv.selectNumber] = 1;
                    int index = gv.selectNumber + 1;
                    string strHireCount = "HireDesertCount" + index;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[gv.selectNumber]);
                    PlayerPrefs.Save();
                }
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 21)
                {
                    for (int k = 0; k < gv.ListMinerClass.Count; k++)
                    {
                        if (gv.ListMinerClass[k].m_position - 1 == gv.selectNumber)
                        {
                            if (gv.ListMinerClass[k].m_home == 2)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(21, 0);
                            }
                        }
                    }
                }             
            }
            if (gv.MapType == 3)
            {
                if (gv.ListHireIceCount[hirenum] != 0 && gv.ListHireIceCount[hirenum] != 1000)
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetBoard();
                }
                else
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetAnim();
                }
                if (gv.ListHireIceCount[gv.selectNumber] < 0 && gv.ListHireIceCount[hirenum] == 1000)
                {

                }
                else
                {
                    gv.ListHireIceCount[gv.selectNumber] = 1;
                    int index = gv.selectNumber + 1;
                    string strHireCount = "HireIceCount" + index;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[gv.selectNumber]);
                    PlayerPrefs.Save();
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.ListHireForestCount[hirenum] != 0 && gv.ListHireForestCount[hirenum] != 1000)
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetBoard();
                }
                else
                {
                    PopupGetCharectorCanvas.GetComponent<PopupGetCharacter>().SetAnim();
                }
                if (gv.ListHireForestCount[gv.selectNumber] < 0 && gv.ListHireForestCount[hirenum] == 1000)
                {

                }
                else
                {
                    gv.ListHireForestCount[gv.selectNumber] = 1;
                    int index = gv.selectNumber + 1;
                    string strHireCount = "HireForestCount" + index;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[gv.selectNumber]);
                    PlayerPrefs.Save();
                }
            }


            gv.ListHireCardOwnCount[gv.selectNumber] += 1;
            int indexCard = gv.selectNumber + 1;
            string strHireCardCount = "HireCardCount" + indexCard;

            PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[gv.selectNumber]);
            PlayerPrefs.Save();
        }
        else
        {
            if (gv.isDrStart == 0)
            {
                int count = 0;
                for (int k = 0; k < gv.ListHireCount.Count; k++)
                {
                    if (gv.ListHireCount[k] != 0)
                    {
                        count++;
                    }
                }
                if (count > 4)
                {
                    PressDrView(1);
                }
            }

            gv.DeletePanelPopup("PopupGetCharectorCanvas");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);

            PopupGetCharectorCanvas.SetActive(false);
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 16)
            {
                int index2 = 0;
                for (int k = 0; k < gv.ListHireCount.Count; k++)
                {
                    if (gv.ListHireCount[k] != 0)
                    {
                        index2++;
                    }
                }
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(16, index2);

            }
        }
    }

    //엔진 얻음
    public void PressPopUpgetEngineCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PopUpgetEngineCanvas, "PopUpgetEngineCanvas");
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<StoryManager>().SetTextEngine();
            PopUpgetEngineCanvas.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("PopUpgetEngineCanvas");
            PopUpgetEngineCanvas.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //퀘스트창
    public void PressQuestCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(QuestCanvas, "QuestCanvas");
            PressSellCanvas(0);

            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            QuestCanvas.SetActive(true);
        }
        else
        {
            gv.DeletePanel("QuestCanvas");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            QuestCanvas.SetActive(false);
        }
    }

    //셋팅창
    public void PressSettingCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(SettingCanvas, "SettingCanvas");
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            SettingCanvas.SetActive(true);
        }
        else
        {
            gv.DeletePanel("SettingCanvas");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            SettingCanvas.SetActive(false);
            SettingCanvas.GetComponent<SettingCanvasManager>().PressDayReward(0);
        }
    }

    //광부정보창
    public void PressMinerInfoCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(MinerInfoCanvasObj, "MinerInfoCanvasObj");
            PressSellCanvas(0);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            MinerInfoCanvasObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MinerInfoCanvas>().SetData();
            PressDrilShop(0);
        }
        else
        {
            gv.DeletePanel("MinerInfoCanvasObj");
            if (gv.listPanelDic.Count == 0)
            {
                MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            }
            GameObject.Find("MainCanvas").GetComponent<MinerInfoCanvas>().SetDisableData();
            MinerInfoCanvasObj.SetActive(false);
        }

    }

    //이건 노쓸모~!~!
    public void PressBGMSampleCanvas(int i)
    {
        if (i == 1)
        {
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            BGMSampleCanvasObj.SetActive(true);
        }
        else
        {
            BGMSampleCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //미니게임 창~!
    public void PressMiniGameCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(MiniGameCanvasObj, "MiniGameCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            PressSellCanvas(0);
            PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            MiniGameCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanel("MiniGameCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            MiniGameCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            if(gv.isOpening ==9)
            {
                //호잇호잇
                PressHoitHoitStartObj(1);
                gv.isOpening = 10;
                PlayerPrefs.SetInt("Opening", 10);
                PlayerPrefs.Save();
            }
            
        }
    }

    //이놈은 팝업 - 엔진
    public void PressCraftCanvas(int i)
    {
        if (i == 1)
        {
            //PressSellCanvas(0);
            gv.AddPanelPopup(CraftCanvasObj, "CraftCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            CraftCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CraftCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CraftCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }
    //이놈도 팝업 -엔진
    public void PressCraftCanvas(int i, string type)
    {
        if (i == 1)
        {
            //PressSellCanvas(0);
            gv.AddPanelPopup(CraftCanvasObj, "CraftCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            CraftCanvasObj.SetActive(true);
            CraftCanvasObj.GetComponent<CraftManager>().SetType(type);
        }
        else
        {
            gv.DeletePanelPopup("CraftCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CraftCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    public bool isNoticeUpgradeObj()
    {
        return NoticeUpgradeObj.activeSelf;
    }
    //업그레이드 할래~!?팝업
    public void ResetUpgradeProbability()
    {
        string str_temp = string.Empty;
        if (gv.ListHireLevel[gv.selectNumber] == 1)
        {
            str_temp = "100%";
        }
        if (gv.ListHireLevel[gv.selectNumber] == 2)
        {
            str_temp = "50%";
        }
        if (gv.ListHireLevel[gv.selectNumber] == 3)
        {
            str_temp = "40%";
        }
        if (gv.ListHireLevel[gv.selectNumber] == 4)
        {
            str_temp = "30%";
        }
        if (gv.ListHireLevel[gv.selectNumber] == 5)
        {
            str_temp = "15%";
        }
        if (gv.ListHireLevel[gv.selectNumber] == 6)
        {
            str_temp = "5%";
        }
        GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().setText(str_temp);
    }
    public void PressNoticeUpgrade(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(NoticeUpgradeObj, "NoticeUpgradeObj");
            //PressSellCanvas(0);
            //PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            string str_temp = string.Empty;
            if (gv.ListHireLevel[gv.selectNumber] == 1)
            {
                str_temp = "100%";
            }
            if (gv.ListHireLevel[gv.selectNumber] == 2)
            {
                str_temp = "50%";
            }
            if (gv.ListHireLevel[gv.selectNumber] == 3)
            {
                str_temp = "40%";
            }
            if (gv.ListHireLevel[gv.selectNumber] == 4)
            {
                str_temp = "30%";
            }
            if (gv.ListHireLevel[gv.selectNumber] == 5)
            {
                str_temp = "15%";
            }
            if (gv.ListHireLevel[gv.selectNumber] == 6)
            {
                str_temp = "5%";
            }
            GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().setText(str_temp);
            NoticeUpgradeObj.SetActive(true);
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().ChangeToggle(false);
            gv.DeletePanelPopup("NoticeUpgradeObj");
            GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().UnSetMiner(gv.selectNumber);
            NoticeUpgradeObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);

            if (gv.isOpening == 4)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("DailyMiner");
                gv.isOpening = 5;
                PlayerPrefs.SetInt("Opening", 5);
                PlayerPrefs.Save();

            }
        }
    }

    public void PressNoticeUpgrade(int i, string _text)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(NoticeUpgradeObj, "NoticeUpgradeObj");
            //PressSellCanvas(0);
            //PressDrilShop(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            NoticeUpgradeObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().setText(_text);
        }
        else
        {
            gv.DeletePanelPopup("NoticeUpgradeObj");
            GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().UnSetMiner(gv.selectNumber);
            NoticeUpgradeObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //미니게임 완료 팝업
    public void PressLimitMiniGame(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(LimitMiniGameObj, "NoticeUpgradeObj");
            LimitMiniGameObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("LimitMiniGameObj");
            LimitMiniGameObj.SetActive(false);
        }
    }

    //조합 창
    public void PressCombinationCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(CombinationCanvasObj, "CombinationCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            CombinationCanvasObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();

            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Collection");
        }
        else
        {
            gv.DeletePanel("CombinationCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CombinationCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //합성 팝업 확인
    public void PressCombinationPopupCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CombinationPopupObj, "CombinationPopupObj");
            CombinationPopupObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();

            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Collection");
        }
        else
        {
            gv.DeletePanelPopup("CombinationPopupObj");
            CombinationPopupObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);

        }
    }
    public void PressCombinationPopupCanvas(int i, int type, int combiCnt)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CombinationPopupObj, "CombinationPopupObj");
            CombinationPopupObj.SetActive(true);
            if (type == 1)
            {
                CombinationPopupObj.GetComponent<CombinationPopupManager>().SetCombiView(combiCnt);
            }
            if (type == 2)
            {
                CombinationPopupObj.GetComponent<CombinationPopupManager>().SetCollectionView(combiCnt);
            }
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Collect");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();

            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Collection");
        }
        else
        {
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("Collect");
            gv.DeletePanelPopup("CombinationPopupObj");
            CombinationPopupObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //퀘스트 창
    public void PressQuestViewCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(QuestCanvasObj, "QuestCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            QuestCanvasObj.SetActive(true);

            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanel("QuestCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            QuestCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    public void SetCollider(bool flag)
    {
        if (flag == true)
        {
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }
    //오프닝~
    public void PressOpeningCanvas(int i)
    {
        if (i == 1)
        {
            OpeningCanvasObj.SetActive(true);

            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            OpeningCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            //여기서 튜토리얼 시작
            //TutorialManagerStart(1);            
            if(gv.isOpening ==0)
            {              
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("HireTutorial");
                gv.isOpening = 1;
                PlayerPrefs.SetInt("Opening", 1);
                PlayerPrefs.Save();

                gv.AutoSellPotionTotalCount++;
                PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
            }

        }
    }

    //다이나마이트 100% 채워주는놈 팝업
    public void PressDynamiteCanvas(int i)
    {
        if (i == 1)
        {
            if(gv.MapType ==1)
            {
                if (gv.isStartCraftEngineNormal == 1 || gv.isStartCraftBitNormal == 1)
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("제작중에는 이용할 수 없습니다.");
                }
                else
                {
                    gv.AddPanel(DynamiteCanvasObj, "DynamiteCanvasObj");
                    DynamiteCanvasObj.SetActive(true);

                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                }
            }
            if (gv.MapType == 2)
            {
                if (gv.isStartCraftEngineDesert == 1 || gv.isStartCraftBitDesert== 1)
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("제작중에는 이용할 수 없습니다.");
                }
                else
                {
                    gv.AddPanel(DynamiteCanvasObj, "DynamiteCanvasObj");
                    DynamiteCanvasObj.SetActive(true);

                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                }
            }
            if (gv.MapType == 3)
            {
                if (gv.isStartCraftEngineIce == 1 || gv.isStartCraftBitIce == 1)
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("제작중에는 이용할 수 없습니다.");
                }
                else
                {
                    gv.AddPanel(DynamiteCanvasObj, "DynamiteCanvasObj");
                    DynamiteCanvasObj.SetActive(true);

                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                }
            }
            if (gv.MapType == 4)
            {
                if (gv.isStartCraftEngineForest == 1 || gv.isStartCraftBitForest == 1)
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("제작중에는 이용할 수 없습니다.");
                }
                else
                {
                    gv.AddPanel(DynamiteCanvasObj, "DynamiteCanvasObj");
                    DynamiteCanvasObj.SetActive(true);

                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

                    GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                }
            }


        }
        else
        {
            gv.DeletePanel("DynamiteCanvasObj");
            DynamiteCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //닫으면 안됨~! 카드 창
    public void PressCardGetView(int i, int type)
    {
        if (i == 1)
        {
            CardGetViewObj.SetActive(true);
            CardGetViewObj.GetComponent<GetCardManager>().SetCard(type);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {

            CardGetViewObj.GetComponent<GetCardManager>().UnsetCard();
            CardGetViewObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);

        }
    }
    public void PressCardGetView(int i)
    {
        if (i == 1)
        {
            CardGetViewObj.SetActive(true);
            CardGetViewObj.GetComponent<GetCardManager>().SetCard(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            CardGetViewObj.GetComponent<GetCardManager>().UnsetCard();
            gv.CardGetType = 0;
            CardGetViewObj.SetActive(false);
            if (gv.PakageCardType != 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, gv.PakageCardType);
                gv.PakageCardType = 0;
            }
            //GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    public void BlackcoinControll()
    {
        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 1))
        {
            Debug.Log("올레~!");
        }
    }

    //인벤토리창
    public void PressInventoryCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(InventoryCanvasObj, "InventoryCanvasObj");
            InventoryCanvasObj.SetActive(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanel("InventoryCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            InventoryCanvasObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            if (gv.isOpening == 8)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("Sadari");
                gv.isOpening = 9;
                PlayerPrefs.SetInt("Opening", 9);
                PlayerPrefs.Save();

            }
        }
    }

    //알람 팝업~!
    public void PressInappNotificationCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(InappNotificationCanvas, "InappNotificationCanvas");
            InappNotificationCanvas.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("InappNotificationCanvas");
            InappNotificationCanvas.SetActive(false);
        }
    }
    public void TutorialManagerStart(int i)
    {
        if (i == 1)
        {
            TutorialManagerObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            TutorialManagerObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    //앱 종료 팝업
    public void PressPopupQuitApp(int i)
    {
        if (i == 1)
        {
            PopupQuitApp.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.bGetKeydwon = false;
            PopupQuitApp.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }

    // 리워드 팝업~!
    public void PressRewardView(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RewardViewObj, "RewardViewObj");
            if (gv.isOpening >= 9)
            {
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                RewardViewObj.SetActive(true);
            }
        }
        else
        {
            if (gv.Depth > 4 && gv.isDrStart == 0 && gv.isOpening >= 10)
            {
                PressDrView(1);
                Dr.SetActive(true);
                gv.isDrStart = 1;
                PlayerPrefs.SetInt("isDrStart", gv.isDrStart);
                PlayerPrefs.Save();
            }

            gv.DeletePanelPopup("RewardViewObj");
            RewardViewObj.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        }
    }
    string buyStr = string.Empty;

    //구매 확인 창 팝업~!
    public void PressBuyConfimView(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(BuyConfirmObj, "BuyConfirmObj");
            BuyConfirmObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        if (i == 2)
        {
            BuyConfirmObj.SetActive(false);
            gv.DeletePanelPopup("BuyConfirmObj");
            if (buyStr == "U")
                GameObject.Find("MainCanvas").GetComponent<HireController>().BuyQniqueConfirm();
            if (buyStr == "M")
                GameObject.Find("MainCanvas").GetComponent<HireController>().ConfimeBuyMInerCoin();
            buyStr = string.Empty;
        }
        if (i == 0)
        {
            gv.DeletePanelPopup("BuyConfirmObj");
            BuyConfirmObj.SetActive(false);
        }
    }
    public void PressBuyConfimView(int i, string a)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(BuyConfirmObj, "BuyConfirmObj");
            BuyConfirmObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            buyStr = a;
        }

        if (i == 2)
        {
            gv.DeletePanelPopup("BuyConfirmObj");
            BuyConfirmObj.SetActive(false);
        }
        if (i == 0)
        {
            gv.DeletePanelPopup("BuyConfirmObj");
            BuyConfirmObj.SetActive(false);

        }
    }

    //조합 정보 확인~!~!
    public void PressCombiInfo(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CombiInfoObj, "CombiInfoObj");
            CombiInfoObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanelPopup("CombiInfoObj");
            CombiInfoObj.SetActive(false);
        }
    }

    public void PressCombiInfo(string name, int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CombiInfoObj, "CombiInfoObj");
            CombiInfoObj.SetActive(true);

            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanelPopup("CombiInfoObj");
            CombiInfoObj.SetActive(false);
        }
    }

    //광부 정보 패널
    public void PressMineInfoPanel(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(MineInfoPanelObj, "MineInfoPanelObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            MineInfoPanelObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanel("MineInfoPanelObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            MineInfoPanelObj.SetActive(false);
        }
    }
    //일일 보상 팝업
    public void PressDayReward(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(DayRewardObj, "DayRewardObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            DayRewardObj.SetActive(true);
            DayRewardObj.GetComponent<DayRewardUIController>().setButton(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanelPopup("DayRewardObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DayRewardObj.SetActive(false);
        }
    }
    //이건 닫으면 안됨
    public void PressDepthRewardPanel(int i)
    {
        if (i == 1)
        {
            DepthRewardPanel.SetActive(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            DepthRewardPanel.SetActive(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
        }
    }
    //새로운 광물 팝업
    public void PressNewMineralsPanel(int i)
    {
        if (i == 1)
        {
            int depth = 0;
            if (gv.MapType == 1)
            {
                depth = gv.Depth;
            }
            if (gv.MapType == 2)
            {
                depth = gv.DesertDepth;
            }
            if (gv.MapType == 3)
            {
                depth = gv.IceDepth;
            }
            if (gv.MapType == 4)
            {
                depth = gv.ForestDepth;
            }
            if (depth <= 38)
            {
                gv.AddPanelPopup(NewMineralObj, "NewMineralObj");
                NewMineralObj.SetActive(true);
                MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            }
            else
            {
                PressDepthRewardPanel(1);
            }
        }
        else
        {
            gv.DeletePanel("NewMineralObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            NewMineralObj.SetActive(false);
            PressDepthRewardPanel(1);
        }

    }
    //일일 보상
    public void PressDayReward2(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(DayRewardObj, "DayRewardObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            DayRewardObj.SetActive(true);
            DayRewardObj.GetComponent<DayRewardUIController>().setButton(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanel("DayRewardObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DayRewardObj.SetActive(false);
        }
    }
    //이것도 닫으면 안됨
    public void PressDepthRewardBoxCanavs(int i)
    {
        if (i == 1)
        {
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            DepthRewardBoxCanavsObj.SetActive(true);
        }
        else
        {
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DepthRewardBoxCanavsObj.SetActive(false);
            //Check New Event

            if (gv.MapType == 1)
            {
                for (int k = 0; k < gv.EventDepthNormal.Count; k++)
                {
                    if (gv.Depth == gv.EventDepthNormal[k])
                    {
                        PressNewEventPanel(1);
                        switch (k)
                        {
                            case 0:
                                gv.EventObjectNormal1Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal1Status", gv.EventObjectNormal1Status);
                                break;
                            case 1:
                                gv.EventObjectNormal2Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal2Status", gv.EventObjectNormal2Status);
                                break;
                            case 2:
                                gv.EventObjectNormal3Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal3Status", gv.EventObjectNormal3Status);
                                break;
                            case 3:
                                gv.EventObjectNormal4Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal4Status", gv.EventObjectNormal4Status);
                                break;
                            case 4:
                                gv.EventObjectNormal5Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal5Status", gv.EventObjectNormal5Status);
                                break;
                            case 5:
                                gv.EventObjectNormal6Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal6Status", gv.EventObjectNormal6Status);
                                break;
                            case 6:
                                gv.EventObjectNormal7Status = 1;
                                PlayerPrefs.SetInt("EventObjectNormal7Status", gv.EventObjectNormal7Status);
                                break;
                        }
                        PlayerPrefs.Save();
                    }
                }
            }
            if (gv.MapType == 2)
            {
                for (int k = 0; k < gv.EventDepthDesert.Count; k++)
                {
                    if (gv.DesertDepth == gv.EventDepthDesert[k])
                    {
                        PressNewEventPanel(1);
                        switch (k)
                        {
                            case 0:
                                gv.EventObjectDesert1Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert1Status", gv.EventObjectDesert1Status);
                                break;
                            case 1:
                                gv.EventObjectDesert2Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert2Status", gv.EventObjectDesert2Status);
                                break;
                            case 2:
                                gv.EventObjectDesert3Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert3Status", gv.EventObjectDesert3Status);
                                break;
                            case 3:
                                gv.EventObjectDesert4Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert4Status", gv.EventObjectDesert4Status);
                                break;
                            case 4:
                                gv.EventObjectDesert5Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert5Status", gv.EventObjectDesert5Status);
                                break;
                            case 5:
                                gv.EventObjectDesert6Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert6Status", gv.EventObjectDesert6Status);
                                break;
                            case 6:
                                gv.EventObjectDesert7Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert7Status", gv.EventObjectDesert7Status);
                                break;
                            case 7:
                                gv.EventObjectDesert8Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert8Status", gv.EventObjectDesert8Status);
                                break;
                            case 8:
                                gv.EventObjectDesert1Status = 1;
                                PlayerPrefs.SetInt("EventObjectDesert1Status", gv.EventObjectDesert1Status);
                                break;
                        }
                        PlayerPrefs.Save();
                    }
                }

            }
            if (gv.MapType == 3)
            {
                for (int k = 0; k < gv.EventDepthIce.Count; k++)
                {
                    if (gv.IceDepth == gv.EventDepthIce[k])
                    {
                        PressNewEventPanel(1);
                        switch (k)
                        {
                            case 0:
                                gv.EventObjectIce1Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce1Status", gv.EventObjectIce1Status);
                                break;
                            case 1:
                                gv.EventObjectIce2Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce2Status", gv.EventObjectIce2Status);
                                break;
                            case 2:
                                gv.EventObjectIce3Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce3Status", gv.EventObjectIce3Status);
                                break;
                            case 3:
                                gv.EventObjectIce4Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce4Status", gv.EventObjectIce4Status);
                                break;
                            case 4:
                                gv.EventObjectIce5Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce5Status", gv.EventObjectIce5Status);
                                break;
                            case 5:
                                gv.EventObjectIce6Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce6Status", gv.EventObjectIce6Status);
                                break;
                            case 6:
                                gv.EventObjectIce7Status = 1;
                                PlayerPrefs.SetInt("EventObjectIce7Status", gv.EventObjectIce7Status);
                                break;
                        }
                        PlayerPrefs.Save();
                    }
                }

            }
            if (gv.MapType == 4)
            {
                for (int k = 0; k < gv.EventDepthForest.Count; k++)
                {
                    if (gv.ForestDepth == gv.EventDepthForest[k])
                    {
                        PressNewEventPanel(1);
                        switch (k)
                        {
                            case 0:
                                gv.EventObjectForest1Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest1Status", gv.EventObjectForest1Status);
                                break;
                            case 1:
                                gv.EventObjectForest2Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest2Status", gv.EventObjectForest2Status);
                                break;
                            case 2:
                                gv.EventObjectForest3Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest3Status", gv.EventObjectForest3Status);
                                break;
                            case 3:
                                gv.EventObjectForest4Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest4Status", gv.EventObjectForest4Status);
                                break;
                            case 4:
                                gv.EventObjectForest5Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest5Status", gv.EventObjectForest5Status);
                                break;
                            case 5:
                                gv.EventObjectForest6Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest6Status", gv.EventObjectForest6Status);
                                break;
                            case 6:
                                gv.EventObjectForest7Status = 1;
                                PlayerPrefs.SetInt("EventObjectForest7Status", gv.EventObjectForest7Status);
                                break;
                        }
                        PlayerPrefs.Save();
                    }
                }
            }

            if (gv.isOpening == 6)
            {
                gv.DeletePanelAll();
                gv.DeletePanelPopupAll();
                GameObject.Find("MainCanvas").GetComponent<TutorialController>().StartTutorial("Craft");
                gv.isOpening = 7;
                PlayerPrefs.SetInt("Opening", 7);
                PlayerPrefs.Save();
            }
        }
    }

    public void SaveEventData(int index)
    {
        if (gv.iSelectDialogue < 0)
            return;
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.EventObjectNormal1Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal1Status", gv.EventObjectNormal1Status);
                    break;
                case 1:
                    gv.EventObjectNormal2Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal2Status", gv.EventObjectNormal2Status);
                    break;
                case 2:
                    gv.EventObjectNormal3Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal3Status", gv.EventObjectNormal3Status);
                    break;
                case 3:
                    gv.EventObjectNormal4Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal4Status", gv.EventObjectNormal4Status);
                    break;
                case 4:
                    gv.EventObjectNormal5Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal5Status", gv.EventObjectNormal5Status);
                    break;
                case 5:
                    gv.EventObjectNormal6Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal6Status", gv.EventObjectNormal6Status);
                    break;
                case 6:
                    gv.EventObjectNormal7Status = index;
                    PlayerPrefs.SetInt("EventObjectNormal7Status", gv.EventObjectNormal7Status);
                    break;
            }
            PlayerPrefs.Save();

        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.EventObjectDesert1Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert1Status", gv.EventObjectDesert1Status);
                    break;
                case 1:
                    gv.EventObjectDesert2Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert2Status", gv.EventObjectDesert2Status);
                    break;
                case 2:
                    gv.EventObjectDesert3Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert3Status", gv.EventObjectDesert3Status);
                    break;
                case 3:
                    gv.EventObjectDesert4Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert4Status", gv.EventObjectDesert4Status);
                    break;
                case 4:
                    gv.EventObjectDesert5Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert5Status", gv.EventObjectDesert5Status);
                    break;
                case 5:
                    gv.EventObjectDesert6Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert6Status", gv.EventObjectDesert6Status);
                    break;
                case 6:
                    gv.EventObjectDesert7Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert7Status", gv.EventObjectDesert7Status);
                    break;
                case 7:
                    gv.EventObjectDesert8Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert8Status", gv.EventObjectDesert8Status);
                    break;
                case 8:
                    gv.EventObjectDesert1Status = index;
                    PlayerPrefs.SetInt("EventObjectDesert1Status", gv.EventObjectDesert1Status);
                    break;
            }
            PlayerPrefs.Save();

        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.EventObjectIce1Status = index;
                    PlayerPrefs.SetInt("EventObjectIce1Status", gv.EventObjectIce1Status);
                    break;
                case 1:
                    gv.EventObjectIce2Status = index;
                    PlayerPrefs.SetInt("EventObjectIce2Status", gv.EventObjectIce2Status);
                    break;
                case 2:
                    gv.EventObjectIce3Status = index;
                    PlayerPrefs.SetInt("EventObjectIce3Status", gv.EventObjectIce3Status);
                    break;
                case 3:
                    gv.EventObjectIce4Status = index;
                    PlayerPrefs.SetInt("EventObjectIce4Status", gv.EventObjectIce4Status);
                    break;
                case 4:
                    gv.EventObjectIce5Status = index;
                    PlayerPrefs.SetInt("EventObjectIce5Status", gv.EventObjectIce5Status);
                    break;
                case 5:
                    gv.EventObjectIce6Status = index;
                    PlayerPrefs.SetInt("EventObjectIce6Status", gv.EventObjectIce6Status);
                    break;
                case 6:
                    gv.EventObjectIce7Status = index;
                    PlayerPrefs.SetInt("EventObjectIce7Status", gv.EventObjectIce7Status);
                    break;
            }
            PlayerPrefs.Save();

        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    gv.EventObjectForest1Status = index;
                    PlayerPrefs.SetInt("EventObjectForest1Status", gv.EventObjectForest1Status);
                    break;
                case 1:
                    gv.EventObjectForest2Status = index;
                    PlayerPrefs.SetInt("EventObjectForest2Status", gv.EventObjectForest2Status);
                    break;
                case 2:
                    gv.EventObjectForest3Status = index;
                    PlayerPrefs.SetInt("EventObjectForest3Status", gv.EventObjectForest3Status);
                    break;
                case 3:
                    gv.EventObjectForest4Status = index;
                    PlayerPrefs.SetInt("EventObjectForest4Status", gv.EventObjectForest4Status);
                    break;
                case 4:
                    gv.EventObjectForest5Status = index;
                    PlayerPrefs.SetInt("EventObjectForest5Status", gv.EventObjectForest5Status);
                    break;
                case 5:
                    gv.EventObjectForest6Status = index;
                    PlayerPrefs.SetInt("EventObjectForest6Status", gv.EventObjectForest6Status);
                    break;
                case 6:
                    gv.EventObjectForest7Status = index;
                    PlayerPrefs.SetInt("EventObjectForest7Status", gv.EventObjectForest7Status);
                    break;
            }
            PlayerPrefs.Save();

        }

        GameObject.Find("MainCanvas").GetComponent<EventDialogueController>().InitData();

    }
    //일일보상 팝업
    public void PressDayRewardPopup(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(DayRewardPopupObj, "DayRewardPopupObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            DayRewardPopupObj.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
        else
        {
            gv.DeletePanelPopup("DayRewardPopupObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DayRewardPopupObj.SetActive(false);

            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            switch (gv.DayRewardNext - 1)
            {
                case 0:
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    break;
                case 1:
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    break;
                case 2:
                    gv.ZzangPotionTotalCount++;
                    PlayerPrefs.SetInt("ZzangPotionTotalCount", gv.ZzangPotionTotalCount);
                    break;
                case 3:
                    SIS.DBManager.IncreaseFunds("blackcoin", 50);
                    break;
                case 4:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
                    break;
                case 5:
                    gv.AutoSellDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
                    break;
                case 6:
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    break;
                case 7:
                    gv.SaleDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("SaleDoublePotionTotalCount", gv.SaleDoublePotionTotalCount);
                    break;
                case 8:
                    SIS.DBManager.IncreaseFunds("blackcoin", 100);
                    break;
                case 9:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 2);
                    break;
                case 10:
                    gv.AutoSellDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
                    gv.MiningDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
                    break;
                case 11:
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    gv.ZzangDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                    break;
                case 12:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
                    break;
                case 13:
                    SIS.DBManager.IncreaseFunds("blackcoin", 150);
                    break;
                case 14:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 2);
                    break;
                case 15:
                    gv.ZzangDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                    gv.MiningDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("MiningDoublePotionTotalCount", gv.MiningDoublePotionTotalCount);
                    break;
                case 16:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
                    break;
                case 17:

                    gv.ZzangDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    break;
                case 18:
                    SIS.DBManager.IncreaseFunds("blackcoin", 200);
                    break;
                case 19:
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 3);
                    gv.DayRewardNext = 0;
                    PlayerPrefs.SetInt("DayRewardNext", gv.DayRewardNext);
                    for (int k = 0; k < 20; k++)
                    {
                        gv.ListDayRewardCount[k] = 0;
                        string strUpgradeTotalCount = "DayReward" + k;
                        PlayerPrefs.SetInt(strUpgradeTotalCount, gv.ListDayRewardCount[k]);
                    }

                    DayRewardObj.GetComponent<DayRewardUIController>().ReSetData();


                    break;

            }
            PlayerPrefs.Save();
        }
    }

    //제작중 팝업
    public void PressUnderConstructionCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(UnderConstructionCanvasObj, "UnderConstructionCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            UnderConstructionCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("UnderConstructionCanvasObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            UnderConstructionCanvasObj.SetActive(false);
        }
    }
    //제작완료 팝업
    public void PressCompleteCraftEquipmentObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(CompleteCraftEquipmentObj, "CompleteCraftEquipmentObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            CompleteCraftEquipmentObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CompleteCraftEquipmentObj");
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CompleteCraftEquipmentObj.SetActive(false);
        }
    }

    public void PressCompleteCraftEquipmentObj(int i, int type)
    {
        if (i == 1)
        {
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            CompleteCraftEquipmentObj.SetActive(true);
            CompleteCraftEquipmentObj.GetComponent<CompleteGetEquipmentCanvas>().SetType(type);
        }
        else
        {
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            CompleteCraftEquipmentObj.SetActive(false);
        }
    }

    //합성 창~!
    public void PressComposeCanvasObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanel(ComposeCanvasObj, "ComposeCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            ComposeCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanel("ComposeCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            ComposeCanvasObj.SetActive(false);
        }
    }
    //새로운 이벤트 팝업
    public void PressNewEventPanel(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(NewEventPanelObj, "NewEventPanelObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            NewEventPanelObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("NewEventPanelObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            NewEventPanelObj.SetActive(false);

            //여기서 파티클 팡 하고 이벤트 캐릭터 해금
            GameObject.Find("MainCanvas").GetComponent<EventDialogueController>().InitData();
        }
    }
    //대화창~! 닫으면 안됨 or 닫으시겠습니까?
    public void PressDialoguePanee(int i, bool isFirst)
    {
        if (i == 1)
        {
            if (isFirst == true)
            {
                gv.isFirstDialogue = true;
            }
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            DialoguePanelObj.SetActive(true);
            DialoguePanelObj.GetComponent<EventDialogueUIManager>().InitSetting();
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DialoguePanelObj.SetActive(false);
            if (isFirst == true)
            {
                SaveEventData(5);
                if (gv.MapType == 1)
                {
                    if (gv.iSelectDialogue != 5 && gv.iSelectDialogue > -1)
                    {
                        PressEventRewardPanel(1);
                    }
                }
                if (gv.MapType == 4)
                {
                    if (gv.iSelectDialogue != 0 && gv.iSelectDialogue > -1)
                    {
                        PressEventRewardPanel(1);
                    }
                }
                if (gv.MapType == 2)
                {
                    PressEventRewardPanel(1);
                }
                if (gv.MapType == 3)
                {
                    PressEventRewardPanel(1);
                }

            }
        }
    }
    //팝업
    public void PressGetSomethingObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(GetSomethingObj, "GetSomethingObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GetSomethingObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("GetSomethingObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            GetSomethingObj.SetActive(false);
            if(gv.bReview ==1)
            {
                PressReview(1);
                gv.bReview = 10;
                PlayerPrefs.SetInt("bReview", 10);
                PlayerPrefs.Save();
            }
        }
    }

    public void PressGetSomethingObj(int i, float count)
    {
        if (i == 1)
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            GetSomethingObj.SetActive(true);

            GetSomethingObj.transform.Find("PanelGetSomething").gameObject.GetComponent<GetSomethingUIManager>().SetObject(count);
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            GetSomethingObj.SetActive(false);
        }
    }



    //이벤트 보상 팝업
    public void PressEventRewardPanel(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(EventRewardPanelObj, "EventRewardPanelObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            EventRewardPanelObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("EventRewardPanelObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            EventRewardPanelObj.SetActive(false);

            //
            gv.iSelectDialogue = -1;

            if (gv.iSelectEventRewardMiner != -1)
            {
                if (gv.iSelectEventRewardMiner == 1)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 1);
                }
                if (gv.iSelectEventRewardMiner == 2)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 2);
                }
                if (gv.iSelectEventRewardMiner == 3)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 3);
                }
                if (gv.iSelectEventRewardMiner == 4)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 4);
                }
                if (gv.iSelectEventRewardMiner == 5)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 7);
                }
                if (gv.iSelectEventRewardMiner == 99)
                {
                    GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetDepthFree();
                }
                gv.iSelectEventRewardMiner = -1;
            }
            //Card 보여주기~!~!

        }
    }
    //매일 이벤트 보상 팝업
    public void PressPanelDailyEvent(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PanelDailyEventObj, "PanelDailyEventObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            PanelDailyEventObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("PanelDailyEventObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            PanelDailyEventObj.SetActive(false);
            //여기서 보상 확인창 슉슉
        }
    }
    public void PressAdsBoxCanavsObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(PanelDailyEventObj, "AdsBoxCanavsObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            AdsBoxCanavsObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("AdsBoxCanavsObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            AdsBoxCanavsObj.SetActive(false);
        }
    }
    public void ReDialogue()
    {
        gv.isFirstDialogue = false;
        PressPanelDailyEvent(0);
        PressDialoguePanee(1, false);
    }
    public void iSelectDialogueIndex(int index)
    {
        gv.iSelectDialogue = index;
        if (gv.MapType == 1)
        {
            switch (index)
            {
                case 0:
                    if (gv.EventObjectNormal1Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 1:
                    if (gv.EventObjectNormal2Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 2:
                    if (gv.EventObjectNormal3Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 3:
                    if (gv.EventObjectNormal4Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 4:
                    if (gv.EventObjectNormal5Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressComposeCanvasObj(1);
                    break;
                case 5:
                    if (gv.EventObjectNormal6Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 6:
                    if (gv.EventObjectNormal7Status == 1)
                        PressDialoguePanee(1, true);
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (index)
            {
                case 0:
                    if (gv.EventObjectDesert1Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 1:
                    if (gv.EventObjectDesert2Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 2:
                    if (gv.EventObjectDesert3Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 3:
                    if (gv.EventObjectDesert4Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 4:
                    if (gv.EventObjectDesert5Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 5:
                    if (gv.EventObjectDesert6Status == 1)
                        PressDialoguePanee(1, true);                    
                    break;
                case 6:
                    if (gv.EventObjectDesert7Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 7:
                    if (gv.EventObjectDesert8Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 8:
                    if (gv.EventObjectDesert9Status == 1)
                        PressDialoguePanee(1, true);
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (index)
            {
                case 0:
                    if (gv.EventObjectIce1Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 1:
                    if (gv.EventObjectIce2Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 2:
                    if (gv.EventObjectIce3Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 3:
                    if (gv.EventObjectIce4Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 4:
                    if (gv.EventObjectIce5Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 5:
                    if (gv.EventObjectIce6Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 6:
                    if (gv.EventObjectIce7Status == 1)
                        PressDialoguePanee(1, true);
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (index)
            {
                case 0:
                    if (gv.EventObjectForest1Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    //free lv up
                    break;
                case 1:
                    if (gv.EventObjectForest2Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    break;
                case 2:
                    if (gv.EventObjectForest3Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 3:
                    if (gv.EventObjectForest4Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 4:
                    if (gv.EventObjectForest5Status == 1)
                        PressDialoguePanee(1, true);
                    else
                        PressPanelDailyEvent(1);
                    //Depth + 50%
                    break;
                case 5:
                    if (gv.EventObjectForest6Status == 1)
                        PressDialoguePanee(1, true);
                    break;
                case 6:
                    if (gv.EventObjectForest7Status == 1)
                        PressDialoguePanee(1, true);
                    break;
            }
        }
    }

    public void InitView()
    {
        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
        MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
    }

    public void PressFreeLvUPCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(FreeLvUPCanvasObj, "FreeLvUPCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            FreeLvUPCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("FreeLvUPCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            FreeLvUPCanvasObj.SetActive(false);
        }
    }
    public void PressKingMIneralCanvs(int i)
    {
        if( i== 1)
        {
            if(gv.Depth >6)
            {
                PressRobotDrCanvas(0);
                gv.AddPanel(FreeLvUPCanvasObj, "PressKingMIneralCanvs");
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
                KingMIneralCanvsObj.SetActive(true);
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 23)
                {
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(23, 0);
                }
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 13)
                {
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(13, 0);
                }


                switch (gv.MapType)
                {
                    case 1:
                        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralNormal");
                        break;
                    case 2:
                        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralDesert");
                        break;
                    case 3:
                        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralIce");
                        break;
                    case 4:
                        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralForest");
                        break;
                }
            }
            else
            {
                MainStatusObj.GetComponent<StatusUpdate>().SetNotification("70km 달성 필요!!");
            }
        }
        else
        {
            switch (gv.MapType)
            {
                case 1:
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("BGKingMineralNormal");
                    break;
                case 2:
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("BGKingMineralDesert");
                    break;
                case 3:
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("BGKingMineralIce");
                    break;
                case 4:
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("BGKingMineralForest");
                    break;
            }
            gv.DeletePanel("PressKingMIneralCanvs");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            KingMIneralCanvsObj.SetActive(false);
        }
    }
    public void PressRobotInfoCanvas(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(RobotInfoCanvasObj, "RobotInfoCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            RobotInfoCanvasObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("RobotInfoCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            RobotInfoCanvasObj.SetActive(false);
        }
    }

    public void PressDrView(int i)
    {
        if (i == 1)
        {
            Dr.SetActive(true);
            gv.isDrStart = 1;
            PlayerPrefs.SetInt("isDrStart", gv.isDrStart);
            PlayerPrefs.Save();
            gv.AddPanelPopup(DrAppViewObj, "DrAppViewObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            DrAppViewObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("DrAppViewObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            DrAppViewObj.SetActive(false);
        }
    }

    public void PressHoitHoitStartObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(HoitHoitStartObj, "HoitHoitStartObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            HoitHoitStartObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("HoitHoitStartObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            HoitHoitStartObj.SetActive(false);
        }
    }

    public void PressRobotDrCanvas(int i)
    {
        if(i==1)
        {            
            gv.AddPanelPopup(RobotDrCanvasObj, "RobotDrCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            RobotDrCanvasObj.SetActive(true);
        }
        else
        {      
            gv.DeletePanelPopup("RobotDrCanvasObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            RobotDrCanvasObj.SetActive(false);
        }
    }

    public void PressHoitStoneObj(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(FreeLvUPCanvasObj, "HoitStoneObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(0);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            if (HoitStoneObj.activeSelf == false)
            {
                HoitStoneObj.SetActive(true);
                StartCoroutine(EndHoitStone());
            }

        }
        else
        {
            gv.DeletePanelPopup("HoitStoneObj");
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(true);
            MainStatusObj.GetComponent<PopUpManager>().PressBuffObj(1);
            StopCoroutine(EndHoitStone());
            HoitStoneObj.SetActive(false);
        }
    }
    IEnumerator EndHoitStone()
    {
        yield return new WaitForSeconds(3);
        PressHoitStoneObj(0);    
    }
    public void PressGetKey()
    {
        GameObject.Find("MainCanvas").GetComponent<MapContorller>().ScrollTop(1);
    }

    public void SetGoldPerSec()
    {
        GoldPerMineText.text = gv.ChangeMoney(gv.GetAverageMoneyPerMin(60)) +" / min";
}
}
