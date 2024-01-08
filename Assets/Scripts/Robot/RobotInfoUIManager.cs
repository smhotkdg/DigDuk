using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RobotInfoUIManager : MonoBehaviour {

    // Use this for initialization
    public Text AddSpecialBlackcoinCount;
    public Text ResetSpecialBlackcoinCount;
    public GameObject MainStatusObj;
    public Button ResetOk;
    public Button ResetClose;
    public Button ResetExit;

    public GameObject StartResetEffect1;
    public GameObject EndResetEffect1;

    public GameObject StartResetEffect2;
    public GameObject EndResetEffect2;

    public GameObject StartResetEffect3;
    public GameObject EndResetEffect3;

    public GameObject ResetTextNotification;
    public GameObject ResetAblity1;
    public GameObject ResetAblity2;
    public GameObject ResetAblity3;

    public GameObject Arrow1;
    public GameObject Arrow2;
    public GameObject Arrow3;

    public Text RobotTitle;
    public GameObject AddSpecialPopupObj;
    public GameObject ResetSpecialPopupObj;

    public GameObject NormalRobot;
    public GameObject DesertRobot;
    public GameObject IceRobot;
    public GameObject ForestRobot;

    public GameObject SpecialAblity1;
    public GameObject SpecialAblity2;
    public GameObject SpecialAblity3;

    public Text TextMiningSpeed;
    public Text TextMiningAmount;
    public Text TextAutosellTime;

    public GameObject TextMiningSpeedPlus;
    public GameObject TextMiningAmountPlus;
    public GameObject TextAutosellTimePlus; 

    public GameObject AddAblityObj;
    public Text AddAblityText;
    public Button AddOKbtn;
    public Button AddClosebtn;
    public Button CloseBtn;
    public GameObject GetEffect;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnDisable()
    {
        PressAddSpecialPopup(0);
        PrssResetSpecialPopup(0);
        gv.SelectRobotIndex = 0;
    }
    // Update is called once per frame
    private void OnEnable()
    {        
        SetInitType();
    }
    GameObject NowRobot;
    void SetInitType()
    {
        StartResetEffect1.SetActive(false);
        StartResetEffect2.SetActive(false);
        StartResetEffect3.SetActive(false);

        EndResetEffect1.SetActive(false);
        EndResetEffect2.SetActive(false);
        EndResetEffect3.SetActive(false);
        defaultBlackCoins = 70;
        AblityStatus = 0;
        NormalRobot.SetActive(false);
        DesertRobot.SetActive(false);
        IceRobot.SetActive(false);
        ForestRobot.SetActive(false);
        switch (gv.MapType)
        {
            case 1:
                RobotTitle.text = "Robot";
                NormalRobot.SetActive(true);
                break;
            case 2:
                RobotTitle.text = "Desert Robot";
                DesertRobot.SetActive(true);
                break;
            case 3:
                RobotTitle.text = "Ice Robot";
                IceRobot.SetActive(true);
                break;
            case 4:
                RobotTitle.text = "Jungle Robot";
                ForestRobot.SetActive(true);
                break;
        }

        
        if(gv.SelectRobotIndex !=0) 
        {
            NowRobot = GameObject.Find("MainCanvas").GetComponent<HireSettingController>().GetRobot(gv.SelectRobotIndex);
        }
        int Type = 0;
        string textName = string.Empty;
        if(NowRobot != null)
        {            
            if (NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1() <= 0)
            {
                SpecialAblity1.SetActive(false);
                ResetAblity1.SetActive(false);
            }
            else
            {                
                
                Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1();
                textName = GetRandomAblityString(Type);
                int type_result = Gettype(Type);
                if(type_result ==2 || type_result==6)
                {
                    SpecialAblity1.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N0");

                    ResetAblity1.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N0");
                }
                else
                {
                    SpecialAblity1.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N1");

                    ResetAblity1.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N1");
                }

                SpecialAblity1.SetActive(true);
                ResetAblity1.SetActive(true);
                AblityStatus++;
            }
            if (NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2() <= 0)
            {                
                SpecialAblity2.SetActive(false);
                ResetAblity2.SetActive(false);
            }
            else
            {
                Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2();
                textName = GetRandomAblityString(Type);
                int type_result = Gettype(Type);
                if (type_result == 2 || type_result == 6)
                {
                    SpecialAblity2.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N0");

                    ResetAblity2.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N0");
                }
                else
                {
                    SpecialAblity2.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N1");

                    ResetAblity2.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N1");
                }

                ResetAblity2.SetActive(true);
                SpecialAblity2.SetActive(true);
                AblityStatus++;
            }
            if (NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3() <= 0)
            {
                SpecialAblity3.SetActive(false);
                ResetAblity3.SetActive(false);
            }
            else
            {
                Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3();
                textName = GetRandomAblityString(Type);
                int type_result = Gettype(Type);
                if (type_result == 2 || type_result == 6)
                {
                    SpecialAblity3.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N0");

                    ResetAblity3.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N0");
                }
                else
                {
                    SpecialAblity3.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N1");

                    ResetAblity3.transform.Find("Text_Ability1").gameObject.GetComponent<Text>().text =
                    textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N1");
                }
                    

                SpecialAblity3.SetActive(true);
                ResetAblity3.SetActive(true);
                AblityStatus++;
            }
        }

        defaultBlackCoins = defaultBlackCoins * (AblityStatus + 1);
        AddSpecialBlackcoinCount.text = defaultBlackCoins.ToString("N0");

        LoadAblity();
    }
    int defaultBlackCoins = 70;
    void LoadAblity()
    {
        fMiningSpeed = 0;
        fMiningAmount = 0;
        fAutoselltime = 0;
        TextMiningSpeedPlus.SetActive(false);
        TextMiningAmountPlus.SetActive(false);
        TextAutosellTimePlus.SetActive(false);
        if(NowRobot != null)
        {
            int abilyttype1 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1();
            int abilyttype2 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2();
            int abilyttype3 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3();

            float abilyt1 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1();
            float abilyt2 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2();
            float abilyt3 = NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3();
            if (abilyttype1 > 0)
                SetAblityType(abilyttype1, abilyt1);
            if (abilyttype2 > 0)
                SetAblityType(abilyttype2, abilyt2);
            if (abilyttype3 > 0)
                SetAblityType(abilyttype3, abilyt3);

        }
    }
    void Update () {
		
	}
    public void AddSpecial()
    {        
        if (AblityStatus >= 3)
        {
            MainStatusObj.GetComponent<StatusUpdate>().SetNotification("특수능력은 3개까지 가능합니다.");
            return;
        }
        else
        {             
        }

        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        
        if (SIS.DBManager.GetFunds("blackcoin") >=defaultBlackCoins)
        {
            SIS.DBManager.IncreaseFunds("blackcoin", -defaultBlackCoins);
            AddAblityObj.SetActive(false);
            GetEffect.SetActive(false);
            AddOKbtn.interactable = false;
            AddClosebtn.interactable = false;
            CloseBtn.interactable = false;
            AddAblityObj.SetActive(true);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialStart");
            StartCoroutine(RandomAddRoutine());
        }
        else
        {
            MainStatusObj.GetComponent<PopUpManager>().NeedBlackCoinView(1);
        }
  
    }
    IEnumerator RandomAddRoutine()
    {
        int Type = 0;
        float randAbilty;
        string textName;
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialLoop");
        for (int i=0; i< 30; i++)
        {            
            int rand = Random.Range(0, 6);
            randAbilty = GetRandomAblityPower(rand);            
            textName = GetRandomAblityString(rand+1);
            AddAblityText.text = textName + " " + randAbilty.ToString("N1");
            yield return new WaitForSeconds(0.1f);
        }
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("AddSpecialLoop");

        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecial");
        if (AblityStatus ==0)
        {
            NowRobot.GetComponent<RobotMining>().SetAblity();
            Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1();
            int type_result = Gettype(Type);
            if (type_result == 2 || type_result == 6)
            {
                textName = GetRandomAblityString(Type);
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N0");
            }
            else
            {
                textName = GetRandomAblityString(Type);
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower1().ToString("N1");
            }
            
        }
        if (AblityStatus == 1)
        {
            NowRobot.GetComponent<RobotMining>().SetAblity();
            Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2();
            textName = GetRandomAblityString(Type);
            int type_result = Gettype(Type);
            if (type_result == 2 || type_result == 6)
            {
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N0");
            }
            else
            {
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower2().ToString("N1");
            }
                
        }
        if (AblityStatus == 2)
        {
            NowRobot.GetComponent<RobotMining>().SetAblity();
            Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3();
            textName = GetRandomAblityString(Type);
            int type_result = Gettype(Type);
            if (type_result == 2 || type_result == 6)
            {
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N0");
            }
            else
            {
                AddAblityText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower3().ToString("N1");
            }
                
        }        
        AddOKbtn.interactable = true;
        AddClosebtn.interactable = true;
        CloseBtn.interactable = true;
        GetEffect.SetActive(true);        
        SetInitType();
    }
    float fMiningSpeed =0;
    float fMiningAmount =0;
    float fAutoselltime =0;
    int Gettype(int type)
    {
        switch (type)
        {
            //채굴속도
            case 1:
                return 1;
                break;
            //채굴량
            case 2:         
                return 2;
                break;
            //자동판매시간 감소
            case 3:    
                return 3;
                break;
            //드릴파워증가
            case 4:
                return 4;
                break;
            //전체판매증가
            case 5:
                return 5;
                break;
            //호잇스톤 채굴량
            case 6:
                return 6;
                break;
        }
        return 0;
    }
    int SetAblityType(int type,float ablity)
    { 
        switch (type)
        {
            //채굴속도
            case 1:
                TextMiningSpeedPlus.SetActive(true);
                fMiningSpeed += ablity;
                TextMiningSpeedPlus.GetComponent<Text>().text = "-" + fMiningSpeed.ToString("N1");
                return 1;
                break;
            //채굴량
            case 2:
                TextMiningAmountPlus.SetActive(true);
                fMiningAmount += ablity;
                TextMiningAmountPlus.GetComponent<Text>().text = "+" + fMiningAmount.ToString("N0");
                return 2;
                break;
            //자동판매시간 감소
            case 3:
                TextAutosellTimePlus.SetActive(true);
                fAutoselltime += ablity;
                TextAutosellTimePlus.GetComponent<Text>().text = "-"+ fAutoselltime.ToString("N1");
                return 3;
                break;
            //드릴파워증가
            case 4:
                return 4;
                break;
            //전체판매증가
            case 5:
                return 5;
                break;
            //호잇스톤 채굴량
            case 6:
                return 6;
                break;
        }
        return 0;
    }
    string GetRandomAblityString(int rand)
    {
        string RandomAblitly = string.Empty;
        switch (rand)
        {
            //채굴속도
            case 1:
                RandomAblitly = "채굴속도 -";
                break;
            //채굴량
            case 2:
                RandomAblitly = "채굴량 +";
                break;
            //자동판매시간 감소
            case 3:
                RandomAblitly = "판매시간 -";
                break;
            //드릴파워증가
            case 4:
                RandomAblitly = "드릴파워 x";
                break;
            //전체판매증가
            case 5:
                RandomAblitly = "전체판매 x";
                break;
            //호잇스톤 채굴
            case 6:
                RandomAblitly = "호잇스톤 x";
                break;
        }
        return RandomAblitly;
    }
    float GetRandomAblityPower(int rand)
    {
        float RandomAblitlyPower =0;
        switch (rand)
        {
            //채굴속도
            case 0:
                RandomAblitlyPower = GetRand(10);                
                break;
            //채굴량
            case 1:
                RandomAblitlyPower = Mathf.Round(GetRand(500));                
                break;
            //자동판매시간 감소
            case 2:
                RandomAblitlyPower = GetRand(25);                
                break;
            //드릴파워증가
            case 3:
                RandomAblitlyPower = GetRand(7);                
                break;
            //전체판매증가
            case 4:
                RandomAblitlyPower = GetRand(7);                
                break;
            //호잇스톤
            case 5:
                RandomAblitlyPower = Mathf.Round(GetRand(30));
                break;
        }
        return RandomAblitlyPower;
    }
    float GetRand(float range)
    {
        float rand = 0;
        float split = range / 10;
        rand = Random.Range(1, 1000);

        if (rand < 10)
        {
            rand = Random.Range(split * 9, range);
        }
        else if (rand < 30)
        {
            rand = Random.Range(split * 5, split * 9);
        }
        else if (rand < 50)
        {
            rand = Random.Range(split * 3, split * 6);
        }
        else if (rand < 100)
        {
            rand = Random.Range(split * 2, split * 5);
        }
        else if (rand < 200)
        {
            rand = Random.Range(split, split * 3);
        }
        else
        {
            rand = Random.Range(1, split *2);
        }
        return rand;
    }

    int selectAblity =0;
    public void SelectNumber(int i)
    {
        StartResetEffect1.SetActive(false);
        StartResetEffect2.SetActive(false);
        StartResetEffect3.SetActive(false);

        EndResetEffect1.SetActive(false);
        EndResetEffect2.SetActive(false);
        EndResetEffect3.SetActive(false);
        Color InitColor = new Color();
        InitColor.r = 1; InitColor.g = 1; InitColor.b = 1; InitColor.a = 1;

        Color InitColorImage = new Color();
        InitColorImage.r = 0; InitColorImage.g = 0; InitColorImage.b = 0; InitColorImage.a = 1;


        Color UnSetColor = new Color();
        UnSetColor.r = 1; UnSetColor.g = 1; UnSetColor.b = 1; UnSetColor.a = 0.4f;

        switch (i)
        {
            case 1:
                Arrow1.SetActive(true);
                ResetAblity1.GetComponent<Image>().color = InitColorImage;
                ResetAblity1.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;

                Arrow2.SetActive(false);
                ResetAblity2.GetComponent<Image>().color = UnSetColor;
                ResetAblity2.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;

                Arrow3.SetActive(false);
                ResetAblity3.GetComponent<Image>().color = UnSetColor;
                ResetAblity3.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;
                break;
            case 2:
                Arrow1.SetActive(false);
                ResetAblity1.GetComponent<Image>().color = UnSetColor;
                ResetAblity1.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;

                Arrow2.SetActive(true);
                ResetAblity2.GetComponent<Image>().color = InitColorImage;
                ResetAblity2.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;

                Arrow3.SetActive(false);
                ResetAblity3.GetComponent<Image>().color = UnSetColor;
                ResetAblity3.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;
        
                break;
            case 3:
                Arrow1.SetActive(false);
                ResetAblity1.GetComponent<Image>().color = UnSetColor;
                ResetAblity1.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;

                Arrow2.SetActive(false);
                ResetAblity2.GetComponent<Image>().color = UnSetColor;
                ResetAblity2.transform.Find("Text_Ability1").GetComponent<Text>().color = UnSetColor;

                Arrow3.SetActive(true);
                ResetAblity3.GetComponent<Image>().color = InitColorImage;
                ResetAblity3.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;     
                break;
        }
        selectAblity = i;
    }
    public void ResetSpecial()
    {
        if (selectAblity == 0)
        {
            ResetTextNotification.SetActive(true);
            StartCoroutine(EndResetNotification());
        }
        else
        {
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            int defaultBlackCoins = 100;
            if (SIS.DBManager.GetFunds("blackcoin") >= defaultBlackCoins)
            {
                SIS.DBManager.IncreaseFunds("blackcoin", -defaultBlackCoins);
                ResetAblity();
            }
            else
            {
                MainStatusObj.GetComponent<PopUpManager>().NeedBlackCoinView(1);
            }
        }
    }
    public void ResetAblity()
    {
        ResetOk.interactable = false;
        ResetExit.interactable = false;
        ResetClose.interactable = false;
        Text myText = null;
        GameObject StartEffect= null;
        GameObject EndEffect = null; 
        switch(selectAblity)
        {
            case 1:
                myText = ResetAblity1.transform.Find("Text_Ability1").gameObject.GetComponent<Text>();
                StartEffect = ResetAblity1.transform.Find("StartEffect").gameObject;
                EndEffect = ResetAblity1.transform.Find("GetEffect").gameObject;
                EndEffect.SetActive(false);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialStart");
                StartCoroutine(RandomResetRoutine(myText, StartEffect, EndEffect, 1)); 
                break;
            case 2:
                myText = ResetAblity2.transform.Find("Text_Ability1").gameObject.GetComponent<Text>();
                StartEffect = ResetAblity2.transform.Find("StartEffect").gameObject;
                EndEffect = ResetAblity2.transform.Find("GetEffect").gameObject;
                EndEffect.SetActive(false);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialStart");
                StartCoroutine(RandomResetRoutine(myText, StartEffect, EndEffect, 2));    
                break;
            case 3:
                myText = ResetAblity3.transform.Find("Text_Ability1").gameObject.GetComponent<Text>();
                StartEffect = ResetAblity3.transform.Find("StartEffect").gameObject;
                EndEffect = ResetAblity3.transform.Find("GetEffect").gameObject;
                EndEffect.SetActive(false);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialStart");
                StartCoroutine(RandomResetRoutine(myText, StartEffect, EndEffect, 3));         
                break;
        }   
            
        ResetAblity1.transform.GetComponent<Button>().enabled = false;
        ResetAblity2.transform.GetComponent<Button>().enabled = false;
        ResetAblity3.transform.GetComponent<Button>().enabled = false;
        SetInitType();

        if (StartEffect != null)
        {
            StartEffect.SetActive(false);
            StartEffect.SetActive(true);
        }
    }

    IEnumerator RandomResetRoutine(Text myText,GameObject StartEffect,GameObject EndEffect,int ablityIndex)
    {
        int Type = 0;
        float randAbilty;
        string textName;
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecialLoop");
        for (int i = 0; i < 30; i++)
        {
            int rand = Random.Range(0, 6);
            randAbilty = GetRandomAblityPower(rand);
            textName = GetRandomAblityString(rand + 1);
            myText.text = textName + " " + randAbilty.ToString("N1");
            yield return new WaitForSeconds(0.1f);
        }
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().StopAudio("AddSpecialLoop");
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("AddSpecial");
        NowRobot.GetComponent<RobotMining>().ResetAblity(ablityIndex);        

        Type = NowRobot.GetComponent<RobotMining>().GetTypeOfAblity(ablityIndex);
        int type_result = Gettype(Type);
        if (type_result == 2 || type_result == 6)
        {
            textName = GetRandomAblityString(Type);
            myText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower(ablityIndex).ToString("N0");
        }
        else
        {
            textName = GetRandomAblityString(Type);
            myText.text = textName + " " + NowRobot.GetComponent<RobotMining>().GetTypeOfAblityPower(ablityIndex).ToString("N1");
        }

        ResetOk.interactable = true;
        ResetExit.interactable = true;
        ResetClose.interactable = true;
        EndEffect.SetActive(true);
        ResetAblity1.transform.GetComponent<Button>().enabled = true;
        ResetAblity2.transform.GetComponent<Button>().enabled = true;
        ResetAblity3.transform.GetComponent<Button>().enabled = true;
        StartCoroutine(EndResetRoutine());
              
    }
    IEnumerator EndResetRoutine()
    {
        yield return new WaitForSeconds(0.5f);
        SetInitType();
    }
    IEnumerator EndResetNotification()
    {
        yield return new WaitForSeconds(2.0f);
        ResetTextNotification.SetActive(false);
    }
    int AblityStatus = 0;
    public void PressAddSpecialPopup(int i)
    {
        if(i ==1)
        {
            if (NowRobot != null)
            {
                if (NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1() > 0 &&
                    NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2() > 0 &&
                    NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3() > 0)
                {
                    return;
                }

            }
        }

        if (i == 1)
        {
            gv.AddPanelPopup(AddSpecialPopupObj, "AddSpecialPopupObj");                        
            AddSpecialPopupObj.SetActive(true);
        }
        else
        {
            GetEffect.SetActive(false);
            AddOKbtn.interactable = true;
            AddClosebtn.interactable = true;
            CloseBtn.interactable = true;
            AddAblityObj.SetActive(false);
            gv.DeletePanelPopup("AddSpecialPopupObj");         
            AddSpecialPopupObj.SetActive(false);
        }
    }
    public void PrssResetSpecialPopup(int i)
    {
        if (i == 1)
        {
            if (NowRobot != null)
            {
                if (NowRobot.GetComponent<RobotMining>().GetTypeOfAblity1() != 0
               || NowRobot.GetComponent<RobotMining>().GetTypeOfAblity2() != 0
               || NowRobot.GetComponent<RobotMining>().GetTypeOfAblity3() != 0)
                {
                    gv.AddPanelPopup(ResetSpecialPopupObj, "ResetSpecialPopupObj");
                    ResetSpecialPopupObj.SetActive(true);
                }
            }
        }
        else
        {
            ResetData();
            gv.DeletePanelPopup("ResetSpecialPopupObj");
            ResetSpecialPopupObj.SetActive(false);
        }
    }
    void ResetData()
    {
        ResetAblity1.transform.GetComponent<Button>().enabled = true;
        ResetAblity2.transform.GetComponent<Button>().enabled = true;
        ResetAblity3.transform.GetComponent<Button>().enabled = true;

        AblityStatus = 0;
        selectAblity = 0;
        Arrow1.SetActive(false);
        Arrow2.SetActive(false);
        Arrow3.SetActive(false);

        Color InitColor = new Color();
        InitColor.r = 1; InitColor.g = 1; InitColor.b = 1; InitColor.a = 1;

        Color InitColorImage = new Color();
        InitColorImage.r = 0; InitColorImage.g = 0; InitColorImage.b = 0; InitColorImage.a = 1;

        ResetAblity1.GetComponent<Image>().color = InitColorImage;
        ResetAblity1.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;
                
        ResetAblity2.GetComponent<Image>().color = InitColorImage;
        ResetAblity2.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;
                
        ResetAblity3.GetComponent<Image>().color = InitColorImage;
        ResetAblity3.transform.Find("Text_Ability1").GetComponent<Text>().color = InitColor;
    }
}
