using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerComposeManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusCanvas;
    GlobalVariable gv;
    public GameObject ComposeConfirmPanel;
    public Button BtnCompose;
    public Text BtnComposeText;
    public Text BtnComposeMoney;
    public Image ComposeImageMoney;
    EraseProgress erasePrograss;
    public GameObject MinerObj;
    public GameObject MinerListObj;
    List<GameObject> MinerList = new List<GameObject>();
    //List<GameObject> MinerCloneList = new List<GameObject>();
    GameObject[] MinerClonearr = new GameObject[2];
    public GameObject OwnCardMask;
    public ScrollRect Scrollrect;
    public GameObject Card1;
    public GameObject Card2;
    List<GameObject> ImageLevel = new List<GameObject>();

    
    public GameObject pScrach;    
    GameObject TempScrach;

    public ScratchDemoUI ScratchManager;
    int icard1 = -1;
    int icard2 = -1;
    float ProbabilityD = 0;
    float ProbabilityC = 0;
    float ProbabilityB = 0;
    float ProbabilityA = 0;
    float ProbabilityS = 0;
    float ProbabilitySS = 0;
    float ProbabilityU = 0;

    public Text TextProbabilityD;
    public Text TextProbabilityB;
    public Text TextProbabilityC;
    public Text TextProbabilityA;
    public Text TextProbabilityS;
    public Text TextProbabilitySS;
    public Text TextProbabilityU;
    public Button btnClick;
    public Image BtnArrow;

    public GameObject ComposeImage;
    public GameObject GetImage;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        if (MinerList.Count <= 0)
        {
            for (int i = 0; i < 110; i++)
            {
                int count = i + 1;
                string MinerName = "Miner" + count;
                MinerList.Add(MinerListObj.transform.Find(MinerName).gameObject);
                ImageLevel.Add(MinerList[MinerList.Count-1].transform.Find("ImageLevel").gameObject);
            }
        }
        for(int i=0; i< 110; i++)
        {
            if (gv.ListHireCount[i] != 0 || gv.ListHireDesertCount[i] != 0 || gv.ListHireIceCount[i] != 0 ||
              gv.ListHireForestCount[i] != 0)
            {
                MinerList[i].SetActive(true);


                ImageLevel[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
                if (gv.ListHireLevel[i] >= 7)
                {
                    ImageLevel[i].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                    ImageLevel[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                }
                else
                {
                    ImageLevel[i].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                    ImageLevel[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                }

            }
        }

        Scrollrect.verticalNormalizedPosition = 1;
    }
    private void OnDisable()
    {
        BtnComposeMoney.text = "--";
        Destroy(MinerClonearr[0]);
        MinerClonearr[0] = null;
        Destroy(MinerClonearr[1]);
        MinerClonearr[1] = null;
        for (int i=0; i< MinerList.Count; i++)
        {
            MinerList[i].SetActive(false);
        }

        btnClick.interactable = false;
        Color _color = BtnArrow.color;
        _color.a = 0.58f;
        BtnArrow.color = _color;
        
        ComposeImage.SetActive(true);
        GetImage.SetActive(false);
        ComposeConfirmPanel.SetActive(false);
        Destroy(temp);
        icard1 = -1;
        icard2 = -2;

        BtnCompose.interactable = false;
        _color = BtnComposeText.color;
        _color.a = 0.58f;
        BtnComposeText.color = _color;


        _color = BtnComposeMoney.color;
        _color.a = 0.58f;
        BtnComposeMoney.color = _color;


        _color = ComposeImageMoney.color;
        _color.a = 0.58f;
        ComposeImageMoney.color = _color;
        bstart = false;


        ProbabilityD = 0;
        ProbabilityC = 0;
        ProbabilityB = 0;
        ProbabilityA = 0;
        ProbabilityS = 0;
        ProbabilitySS = 0;
        ProbabilityU = 0;

        SetTextMenu();
    }
    // Update is called once per frame
    bool bstart = false;
    void Update () {
    	
	}

    public void OnEraseProgress(float progress)
    {
        if (bstart == true)
        {
            if (progress*100f >= 70)
            {
                btnClick.interactable = true;
                Color _color = BtnArrow.color;
                _color.a = 1;
                BtnArrow.color = _color;
            }
        }
    }

    void CheckProbability(int grade, int lv)
    {
        
        switch(grade)
        {
            case 1:
                if(lv ==1)
                {
                    ProbabilityD += 50;
                    ProbabilityC += 1;
                    ProbabilityB += 0;
                    ProbabilityA += 0;
                }
                if (lv == 2)
                {
                    ProbabilityD += 40;
                    ProbabilityC += 5;
                    ProbabilityB += 0;
                    ProbabilityA += 0;
                }
                if (lv == 3)
                {
                    ProbabilityD += 30;
                    ProbabilityC += 10;
                    ProbabilityB += 0;
                    ProbabilityA += 0;
                }
                if (lv == 4)
                {
                    ProbabilityD += 20;
                    ProbabilityC += 15;
                    ProbabilityB += 1;
                    ProbabilityA += 0;
                }
                if (lv == 5)
                {
                    ProbabilityD += 10;
                    ProbabilityC += 25;
                    ProbabilityB += 2;
                    ProbabilityA += 0;
                }
                if (lv == 6)
                {
                    ProbabilityD += 5;
                    ProbabilityC += 35;
                    ProbabilityB += 3;
                    ProbabilityA += 0;
                }
                if (lv == 7)
                {
                    ProbabilityD += 0;
                    ProbabilityC += 50;
                    ProbabilityB += 4;
                    ProbabilityA += 0.1f;
                }
                break;
            case 2:
                if (lv == 1)
                {
                    ProbabilityC += 50;
                    ProbabilityB += 1;
                    ProbabilityA += 0;
                    ProbabilityS += 0;
                }
                if (lv == 2)
                {
                    ProbabilityC += 40;
                    ProbabilityB += 5;
                    ProbabilityA += 0;
                    ProbabilityS += 0;
                }
                if (lv == 3)
                {
                    ProbabilityC += 30;
                    ProbabilityB += 10;
                    ProbabilityA += 0;
                    ProbabilityS += 0;
                }
                if (lv == 4)
                {
                    ProbabilityC += 20;
                    ProbabilityB += 15;
                    ProbabilityA += 1;
                    ProbabilityS += 0;
                }
                if (lv == 5)
                {
                    ProbabilityC += 10;
                    ProbabilityB += 25;
                    ProbabilityA += 2;
                    ProbabilityS += 0;
                }
                if (lv == 6)
                {
                    ProbabilityC += 5;
                    ProbabilityB += 35;
                    ProbabilityA += 3;
                    ProbabilityS += 0;
                }
                if (lv == 7)
                {
                    ProbabilityC += 0;
                    ProbabilityB += 50;
                    ProbabilityA += 4;
                    ProbabilityS += 0.1f;
                }
                break;
            case 3:
                if (lv == 1)
                {
                    ProbabilityB += 50;
                    ProbabilityA += 1;
                    ProbabilityS += 0;
                    ProbabilitySS += 0;
                }
                if (lv == 2)
                {
                    ProbabilityB += 40;
                    ProbabilityA += 5;
                    ProbabilityS += 0;
                    ProbabilitySS += 0;
                }
                if (lv == 3)
                {
                    ProbabilityB += 30;
                    ProbabilityA += 10;
                    ProbabilityS += 0;
                    ProbabilitySS += 0;
                }
                if (lv == 4)
                {
                    ProbabilityB += 20;
                    ProbabilityA += 15;
                    ProbabilityS += 1;
                    ProbabilitySS += 0;
                }
                if (lv == 5)
                {
                    ProbabilityB += 10;
                    ProbabilityA += 25;
                    ProbabilityS += 2;
                    ProbabilitySS += 0;
                }
                if (lv == 6)
                {
                    ProbabilityB += 5;
                    ProbabilityA += 35;
                    ProbabilityS += 3;
                    ProbabilitySS += 0;
                }
                if (lv == 7)
                {
                    ProbabilityB += 0;
                    ProbabilityA += 50;
                    ProbabilityS += 4;
                    ProbabilitySS += 0.1f;
                }
                break;
            case 4:
                if (lv == 1)
                {
                    ProbabilityA += 50;
                    ProbabilityS += 1;
                    ProbabilitySS += 0;
                    ProbabilityU += 0;
                }
                if (lv == 2)
                {
                    ProbabilityA += 40;
                    ProbabilityS += 5;
                    ProbabilitySS += 0;
                    ProbabilityU += 0;
                }
                if (lv == 3)
                {
                    ProbabilityA += 30;
                    ProbabilityS += 10;
                    ProbabilitySS += 0;
                    ProbabilityU += 0;
                }
                if (lv == 4)
                {
                    ProbabilityA += 20;
                    ProbabilityS += 15;
                    ProbabilitySS += 1;
                    ProbabilityU += 0;
                }
                if (lv == 5)
                {
                    ProbabilityA += 10;
                    ProbabilityS += 25;
                    ProbabilitySS += 2;
                    ProbabilityU += 0;
                }
                if (lv == 6)
                {
                    ProbabilityA += 5;
                    ProbabilityS += 35;
                    ProbabilitySS += 3;
                    ProbabilityU += 0;
                }
                if (lv == 7)
                {
                    ProbabilityA += 0;
                    ProbabilityS += 50;
                    ProbabilitySS += 4;
                    ProbabilityU += 0.1f;
                }
                break;
            case 5:
                if (lv == 1)
                {
                    ProbabilityS += 50;
                    ProbabilitySS += 1;
                    ProbabilityU += 0;                    
                }
                if (lv == 2)
                {
                    ProbabilityS += 40;
                    ProbabilitySS += 5;
                    ProbabilityU += 0;                    
                }
                if (lv == 3)
                {
                    ProbabilityS += 30;
                    ProbabilitySS += 10;
                    ProbabilityU += 0;                    
                }
                if (lv == 4)
                {
                    ProbabilityS += 20;
                    ProbabilitySS += 15;
                    ProbabilityU += 1;                    
                }
                if (lv == 5)
                {
                    ProbabilityS += 10;
                    ProbabilitySS += 25;
                    ProbabilityU += 2;                    
                }
                if (lv == 6)
                {
                    ProbabilityS += 5;
                    ProbabilitySS += 35;
                    ProbabilityU += 3;
                }
                if (lv == 7)
                {
                    ProbabilityS += 0;
                    ProbabilitySS += 50;
                    ProbabilityU += 4;                    
                }
                break;
            case 6:
                if (lv == 1)
                {
                    ProbabilitySS += 50;
                    ProbabilityU += 1;                    
                }
                if (lv == 2)
                {
                    ProbabilitySS += 40;
                    ProbabilityU += 5;                    
                }
                if (lv == 3)
                {
                    ProbabilitySS += 30;
                    ProbabilityU += 10;                    
                }
                if (lv == 4)
                {
                    ProbabilitySS += 20;
                    ProbabilityU += 15;                    
                }
                if (lv == 5)
                {
                    ProbabilitySS += 10;
                    ProbabilityU += 25;                    
                }
                if (lv == 6)
                {
                    ProbabilitySS += 5;
                    ProbabilityU += 35;                    
                }
                if (lv == 7)
                {
                    ProbabilitySS += 0;
                    ProbabilityU += 50;                    
                }
                break;
            case 7:
                if (lv == 1)
                {
                    ProbabilityA += 10;
                    ProbabilityS += 12;
                    ProbabilitySS += 15;
                    ProbabilityU += 50;                    
                }
                if (lv == 2)
                {
                    ProbabilityA += 15;
                    ProbabilityS += 20;
                    ProbabilitySS += 25;
                    ProbabilityU += 60;                    
                }
                if (lv == 3)
                {
                    ProbabilityA += 15;
                    ProbabilityS += 30;
                    ProbabilitySS += 35;
                    ProbabilityU += 70;                    
                }
                if (lv == 4)
                {
                    ProbabilityA += 20;
                    ProbabilityS += 40;
                    ProbabilitySS += 45;
                    ProbabilityU += 80;                    
                }
                if (lv == 5)
                {
                    ProbabilityA += 25;
                    ProbabilityS += 50;
                    ProbabilitySS += 55;
                    ProbabilityU += 90;                    
                }
                if (lv == 6)
                {
                    ProbabilityA += 30;
                    ProbabilityS += 50;
                    ProbabilitySS += 55;
                    ProbabilityU += 100;                    
                }
                if (lv == 7)
                {
                    ProbabilityA += 35;
                    ProbabilityS += 50;
                    ProbabilitySS += 65;
                    ProbabilityU += 110;                    
                }
                break;
        }
    }
    public void SelectCard(int i)
    {        
        if (icard1 < 0)
        {
            MinerClonearr[0] = (Instantiate(MinerList[i]));            
            //D B C A S SS U
            //1 2 3 4 5 6 7
            MinerClonearr[0].transform.SetParent(Card1.transform);
            icard1 = i;
            MinerList[i].SetActive(false);

            Vector2 localScale = MinerClonearr[0].transform.localScale;
            localScale.x = 1; localScale.y = 1;
            MinerClonearr[0].transform.localScale = localScale;
            localScale.x = 0; localScale.y = 0;
            MinerClonearr[0].transform.localPosition = localScale;
            MinerClonearr[0].SetActive(true);
            MinerClonearr[0].GetComponent<Button>().enabled = false;
            CheckProbability(gv.listMinerGrade[i], gv.ListHireLevel[i]);
            BtnComposeMoney.text = "--";
        }
        else if(icard2 < 0)
        {
            MinerClonearr[1] = (Instantiate(MinerList[i]));
            MinerClonearr[1].transform.SetParent(Card2.transform);
            icard2 = i;
            MinerList[i].SetActive(false);

            Vector2 localScale = MinerClonearr[1].transform.localScale;
            localScale.x = 1; localScale.y = 1;
            MinerClonearr[1].transform.localScale = localScale;
            localScale.x = 0; localScale.y = 0;
            MinerClonearr[1].transform.localPosition = localScale;
            MinerClonearr[1].SetActive(true);
            MinerClonearr[1].GetComponent<Button>().enabled = false;
            CheckProbability(gv.listMinerGrade[i], gv.ListHireLevel[i]);
            BtnComposeMoney.text = "--";
        }
        

        if(icard1 >=0 && icard2 >=0)
        {
            BtnCompose.interactable = true;
            Color _color = BtnComposeText.color;
            _color.a = 1;
            BtnComposeText.color = _color;


            _color = BtnComposeMoney.color;
            _color.a = 1;
            BtnComposeMoney.color = _color;


            _color = ComposeImageMoney.color;
            _color.a = 1;
            ComposeImageMoney.color = _color;

            float checkMoney = 0;
            for (int k = 0; k < gv.ListMinerClass.Count; k++)
            {
                if (gv.ListMinerClass[k].m_position == icard1)
                {
                    checkMoney += (float)gv.ListHireCost[k];
                }
                if (gv.ListMinerClass[k].m_position == icard2)
                {
                    checkMoney += (float)gv.ListHireCost[k];
                }
            }
            checkMoney = checkMoney * 15.5f;
            BtnComposeMoney.text = gv.ChangeMoney(checkMoney);
        }
        else
        {
            BtnComposeMoney.text = "--";
            BtnCompose.interactable = false;
            Color _color = BtnComposeText.color;
            _color.a = 0.58f;
            BtnComposeText.color = _color;


            _color = BtnComposeMoney.color;
            _color.a = 0.58f;
            BtnComposeMoney.color = _color;


            _color = ComposeImageMoney.color;
            _color.a = 0.58f;
            ComposeImageMoney.color = _color;
        }
        SetTextMenu();     
      
    }
    void SetTextMenu()
    {
        //if(icard1 >=0 && icard2 >=0)
        {
            Color color80 = new Color(255, 0, 0);
            Color color50 = new Color(85, 255, 0);
            Color color10 = new Color(115, 107, 255);
            Color color5 = new Color(240, 0, 255);
            Color Default = new Color(255, 255, 255);

            float totalProbabilty = ProbabilityD + ProbabilityC + ProbabilityB + ProbabilityA + ProbabilityS + ProbabilitySS + ProbabilityU;
            if(totalProbabilty >0)
            {
                float tempProD;
                float tempProC;
                float tempProB;
                float tempProA;
                float tempProS;
                float tempProSS;
                float tempProU;
                tempProD = ProbabilityD / totalProbabilty * 100;
                tempProC = ProbabilityC / totalProbabilty * 100;
                tempProB = ProbabilityB / totalProbabilty * 100;
                tempProA = ProbabilityA / totalProbabilty * 100;
                tempProS = ProbabilityS / totalProbabilty * 100;
                tempProSS = ProbabilitySS / totalProbabilty * 100;
                tempProU = ProbabilityU / totalProbabilty * 100;

                {
                    if (tempProD >= 80)
                        TextProbabilityD.color = color80;
                    else if (tempProD >= 50)
                        TextProbabilityD.color = color50;
                    else if (tempProD >= 10)
                        TextProbabilityD.color = color10;
                    else if (tempProD > 10)
                        TextProbabilityD.color = color5;
                    else
                        TextProbabilityD.color = Default;

                    if (tempProC >= 80)
                        TextProbabilityC.color = color80;
                    else if (tempProC >= 50)
                        TextProbabilityC.color = color50;
                    else if (tempProC >= 10)
                        TextProbabilityC.color = color10;
                    else if (tempProC >= 5)
                        TextProbabilityC.color = color5;
                    else
                        TextProbabilityC.color = Default;

                    if (tempProB >= 80)
                        TextProbabilityB.color = color80;
                    else if (tempProB >= 50)
                        TextProbabilityB.color = color50;
                    else if (tempProB >= 10)
                        TextProbabilityB.color = color10;
                    else if (tempProB >= 5)
                        TextProbabilityB.color = color5;
                    else
                        TextProbabilityB.color = Default;

                    if (tempProA >= 80)
                        TextProbabilityA.color = color80;
                    else if (tempProA >= 50)
                        TextProbabilityA.color = color50;
                    else if (tempProA >= 10)
                        TextProbabilityA.color = color10;
                    else if (tempProA >= 5)
                        TextProbabilityA.color = color5;
                    else
                        TextProbabilityA.color = Default;

                    if (tempProS >= 80)
                        TextProbabilityS.color = color80;
                    else if (tempProS >= 50)
                        TextProbabilityS.color = color50;
                    else if (tempProS >= 10)
                        TextProbabilityS.color = color10;
                    else if (tempProS >= 5)
                        TextProbabilityS.color = color5;
                    else
                        TextProbabilityS.color = Default;

                    if (tempProSS >= 80)
                        TextProbabilitySS.color = color80;
                    else if (tempProSS >= 50)
                        TextProbabilitySS.color = color50;
                    else if (tempProSS >= 10)
                        TextProbabilitySS.color = color10;
                    else if (tempProSS >= 5)
                        TextProbabilitySS.color = color5;
                    else
                        TextProbabilitySS.color = Default;


                    if (tempProU >= 80)
                        TextProbabilityU.color = color80;
                    else if (tempProU >= 50)
                        TextProbabilityU.color = color50;
                    else if (tempProU >= 10)
                        TextProbabilityU.color = color10;
                    else if (tempProU >= 5)
                        TextProbabilityU.color = color5;
                    else
                        TextProbabilityU.color = Default;

                }



                TextProbabilityD.text = "D: " + tempProD.ToString("N1") + " %";
                TextProbabilityC.text = "C: " + tempProC.ToString("N1") + " %";
                TextProbabilityB.text = "B: " + tempProB.ToString("N1") + " %";
                TextProbabilityA.text = "A: " + tempProA.ToString("N1") + " %";
                TextProbabilityS.text = "S: " + tempProS.ToString("N1") + " %";
                TextProbabilitySS.text = "SS: " + tempProSS.ToString("N1") + " %";
                TextProbabilityU.text = "U: " + tempProU.ToString("N1") + " %";
            }
            else
            {

                TextProbabilityU.color = Default;
                TextProbabilitySS.color = Default;
                TextProbabilityS.color = Default;
                TextProbabilityA.color = Default;
                TextProbabilityB.color = Default;
                TextProbabilityC.color = Default;
                TextProbabilityD.color = Default;

                TextProbabilityD.text = "D: " + 0.ToString("N1") + " %";
                TextProbabilityC.text = "C: " + 0.ToString("N1") + " %";
                TextProbabilityB.text = "B: " + 0.ToString("N1") + " %";
                TextProbabilityA.text = "A: " + 0.ToString("N1") + " %";
                TextProbabilityS.text = "S: " + 0.ToString("N1") + " %";
                TextProbabilitySS.text = "SS: " + 0.ToString("N1") + " %";
                TextProbabilityU.text = "U: " + 0.ToString("N1") + " %";
            }
           
        }
    }
    public void UnselectCard(int i)
    {
        if(i ==0)
        {
            ProbabilityD = 0;
            ProbabilityC = 0;
            ProbabilityB = 0;
            ProbabilityA = 0;
            ProbabilityS = 0;
            ProbabilitySS = 0;
            ProbabilityU = 0;

            MinerList[icard1].SetActive(true);
            icard1 = -1;
            Destroy(MinerClonearr[0]);
            MinerClonearr[0] = null;
            if (icard2 > -1)
                CheckProbability(gv.listMinerGrade[icard2], gv.ListHireLevel[icard2]);
            SetTextMenu();
        }
        if(i ==1)
        {
            ProbabilityD = 0;
            ProbabilityC = 0;
            ProbabilityB = 0;
            ProbabilityA = 0;
            ProbabilityS = 0;
            ProbabilitySS = 0;
            ProbabilityU = 0;

            MinerList[icard2].SetActive(true);
            icard2 = -1;
            Destroy(MinerClonearr[1]);
            MinerClonearr[1] = null;
            if(icard1 >-1)
                CheckProbability(gv.listMinerGrade[icard1], gv.ListHireLevel[icard1]);
            SetTextMenu();
        }

        if (icard1 >= 0 && icard2 >= 0)
        {
            BtnCompose.interactable = true;
            Color _color = BtnComposeText.color;
            _color.a = 1;
            BtnComposeText.color = _color;


            _color = BtnComposeMoney.color;
            _color.a = 1;
            BtnComposeMoney.color = _color;


            _color = ComposeImageMoney.color;
            _color.a = 1;
            ComposeImageMoney.color = _color;

            float checkMoney = 0;
            for (int k = 0; k < gv.ListMinerClass.Count; k++)
            {
                if (gv.ListMinerClass[k].m_position == icard1)
                {
                    checkMoney += (float)gv.ListHireCost[k];
                }
                if (gv.ListMinerClass[k].m_position == icard2)
                {
                    checkMoney += (float)gv.ListHireCost[k];
                }
            }
            checkMoney = checkMoney * 15.5f;
            BtnComposeMoney.text = gv.ChangeMoney(checkMoney);
        }
        else
        {
            BtnComposeMoney.text = "--";
            BtnCompose.interactable = false;
            Color _color = BtnComposeText.color;
            _color.a = 0.58f;
            BtnComposeText.color = _color;


            _color = BtnComposeMoney.color;
            _color.a = 0.58f;
            BtnComposeMoney.color = _color;


            _color = ComposeImageMoney.color;
            _color.a = 0.58f;
            ComposeImageMoney.color = _color;
        }
    }
    List<float> ProbabilityList = new List<float>();
    public void Confrim()
    {
        //돈확인
        float checkMoney = 0;        
        for (int i = 0; i < gv.ListMinerClass.Count; i++)
        {
            if (gv.ListMinerClass[i].m_position == icard1)
            {
                checkMoney += (float)gv.ListHireCost[i];
            }
            if (gv.ListMinerClass[i].m_position == icard2)
            {
                checkMoney += (float)gv.ListHireCost[i];
            }
        }        
        checkMoney = checkMoney * 15.5f;
        BtnComposeMoney.text = gv.ChangeMoney(checkMoney);
        if (gv.Money >= checkMoney)
        {
            gv.Money -= checkMoney;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
            ComposeConfirmPanel.SetActive(true);
        }
        else{
            MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "골드가 부족합니다.");
        }
    }
    public void CloseConfrim()
    {
        ComposeConfirmPanel.SetActive(false);
    }
    public void SetRandomCard()
    {
        float totalProbabilty = ProbabilityD + ProbabilityC + ProbabilityB + ProbabilityA + ProbabilityS + ProbabilitySS + ProbabilityU;
 

        ProbabilityList.Add(ProbabilityD / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilityC / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilityB / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilityA / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilityS / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilitySS / totalProbabilty * 100);
        ProbabilityList.Add(ProbabilityU / totalProbabilty * 100);

        int selectnumber = gv.Choose(ProbabilityList);

        if(selectnumber ==0)
        {
            Debug.Log("D 등급 획득!!" + "  확률 = " + ProbabilityD / totalProbabilty * 100 +" %");
            InitRandom1Card(1);
        }
        if (selectnumber == 1)
        {
            Debug.Log("C 등급 획득!!" + "  확률 = " + ProbabilityC / totalProbabilty * 100 + " %");
            InitRandom1Card(2);
        }
        if (selectnumber == 2)
        {
            Debug.Log("B 등급 획득!!" + "  확률 = " + ProbabilityB / totalProbabilty * 100 + " %");
            InitRandom1Card(3);
        }
        if (selectnumber == 3)
        {
            Debug.Log("A 등급 획득!!" + "  확률 = " + ProbabilityA / totalProbabilty * 100 + " %");
            InitRandom1Card(4);
        }
        if (selectnumber == 4)
        {
            Debug.Log("S 등급 획득!!" + "  확률 = " + ProbabilityS / totalProbabilty * 100 + " %");
            InitRandom1Card(5);
        }
        if (selectnumber == 5)
        {
            Debug.Log("SS 등급 획득!!" + "  확률 = " + ProbabilitySS / totalProbabilty * 100 + " %");
            InitRandom1Card(6);
        }
        if (selectnumber == 6)
        {
            Debug.Log("U 등급 획득!!" + "  확률 = " + ProbabilityU / totalProbabilty * 100 + " %");
            InitRandom1Card(7);
        }
        ProbabilityList.Clear();
        
        ComposeImage.SetActive(false);
        GetImage.SetActive(true);

        TempScrach = Instantiate(pScrach.gameObject);
        TempScrach.transform.SetParent(pScrach.transform.parent);
        TempScrach.transform.localScale = pScrach.transform.localScale;
        TempScrach.transform.localPosition = pScrach.transform.localPosition;
        TempScrach.SetActive(true);

        erasePrograss = TempScrach.transform.Find("Progress Camera").gameObject.GetComponent<EraseProgress>();


        erasePrograss.OnProgress += OnEraseProgress;

        ComposeConfirmPanel.SetActive(false);
        btnClick.interactable = false;
        
        Color _color = BtnArrow.color;
        _color.a = 0.58f;
        BtnArrow.color = _color;       

     
    }

    public void EndGet()
    {
        if (TempScrach != null)
        {
            Destroy(TempScrach);
        }
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressComposeCanvasObj(0);
    }
    GameObject temp;
    void InitRandom1Card(int grade)
    {     
        List<int> gradeList = new List<int>();
        for (int i = 0; i < gv.listMinerGrade.Count; i++)
        {
            if (gv.listMinerGrade[i] == grade)
            {
                gradeList.Add(i);
            }
        }

        int pos = Random.Range(0, gradeList.Count);

        pos = gradeList[pos];

        //등급별로 제대로 안나오는 이유
        //랜덤이 1~20 사이로 밖에 안돔
        temp = Instantiate(MinerList[pos]);
        temp.transform.SetParent(MinerObj.transform);
        Vector2 local;
        local = temp.transform.localScale;
        local.x = 1.8f; local.y = 1.8f;
        temp.transform.localScale = local;
        local.x = 0; local.y = 0;
        temp.transform.localPosition = local;
        temp.SetActive(true);
        gradeList.Clear();
        StartCoroutine("StartB");

        if (gv.MapType == 1)
        {
            if (gv.ListHireCount[icard1] < 0)
            {
                int index = gv.ListHireCount[icard1];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
            if (gv.ListHireCount[icard2] < 0)
            {
                int index = gv.ListHireCount[icard2];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
        }

        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[icard1] < 0)
            {
                int index = gv.ListHireDesertCount[icard1];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
            if (gv.ListHireDesertCount[icard2] < 0)
            {
                int index = gv.ListHireDesertCount[icard2];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
        }

        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[icard1] < 0)
            {
                int index = gv.ListHireIceCount[icard1];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
            if (gv.ListHireIceCount[icard2] < 0)
            {
                int index = gv.ListHireIceCount[icard2];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
        }

        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[icard1] < 0)
            {
                int index = gv.ListHireForestCount[icard1];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
            if (gv.ListHireForestCount[icard2] < 0)
            {
                int index = gv.ListHireForestCount[icard2];
                GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            }
        }

        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitCardSetting();
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();

        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DeleteCheckCollection(icard1);
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DeleteCheckCollection(icard2);



        gv.BuffPower[icard1] = gv.DefaultBuffPower[icard1];
        gv.BuffPower[icard2] = gv.DefaultBuffPower[icard2];

        gv.ListHireCount[icard1] = 0;
        int tempindexCard = icard1 + 1;
        string tempstr =  "HireCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard1]);
        PlayerPrefs.Save();

        gv.ListHireDesertCount[icard1] = 0;
        tempindexCard = icard1 + 1;
        tempstr = "HireDesertCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard1]);
        PlayerPrefs.Save();

        gv.ListHireIceCount[icard1] = 0;
        tempindexCard = icard1 + 1;
        tempstr = "HireIceCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard1]);
        PlayerPrefs.Save();

        gv.ListHireForestCount[icard1] = 0;
        tempindexCard = icard1 + 1;
        tempstr = "HireForestCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard1]);
        PlayerPrefs.Save();



        gv.ListHireCount[icard2] = 0;
        tempindexCard = icard2 + 1;
        tempstr = "HireCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard2]);
        PlayerPrefs.Save();

        gv.ListHireDesertCount[icard2] = 0;
        tempindexCard = icard2 + 1;
        tempstr = "HireDesertCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard2]);
        PlayerPrefs.Save();

        gv.ListHireIceCount[icard2] = 0;
        tempindexCard = icard2 + 1;
        tempstr = "HireIceCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard2]);
        PlayerPrefs.Save();

        gv.ListHireForestCount[icard2] = 0;
        tempindexCard = icard2 + 1;
        tempstr = "HireForestCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard2]);
        PlayerPrefs.Save();


        gv.ListHireCardOwnCount[icard1] = 0;
        tempindexCard = icard1 + 1;
        tempstr = "HireCardCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard1]);
        PlayerPrefs.Save();

        gv.ListHireCardOwnCount[icard2] = 0;
        tempindexCard = icard2 + 1;
        tempstr = "HireCardCount" + tempindexCard;
        PlayerPrefs.SetInt(tempstr, gv.ListHireCount[icard2]);
        PlayerPrefs.Save();

        gv.ListMiningMin[icard1] = gv.ListDefaultListMiningMin[icard1];
        gv.ListMiningMax[icard1] = gv.ListDefaultListMiningMax[icard1];        
        gv.ListMiningTime[icard1] =gv.ListDefaultListMiningTimeCompose[icard1];
        gv.ListDefaultListMiningTime[icard1] = gv.ListDefaultListMiningTimeCompose[icard1]; 
        gv.listMaxMinerCapacity[icard1] = gv.listMaxMinerCapacityDefault[icard1];
        
      
        gv.ListHireLevel[icard1] = 1;
        tempindexCard = icard1 + 1;
        string strHireLevel = "HireLevel" + tempindexCard;
        PlayerPrefs.SetInt(strHireLevel, gv.ListHireLevel[icard1]);
        PlayerPrefs.Save();


        gv.ListMiningMin[icard2] = gv.ListDefaultListMiningMin[icard2];
        gv.ListMiningMax[icard2] = gv.ListDefaultListMiningMax[icard2];
        gv.ListMiningTime[icard2] = gv.ListDefaultListMiningTimeCompose[icard2];
        gv.ListDefaultListMiningTime[icard2] = gv.ListDefaultListMiningTimeCompose[icard2];
        gv.listMaxMinerCapacity[icard2] = gv.listMaxMinerCapacityDefault[icard2];

        gv.ListHireLevel[icard2] = 1;
        tempindexCard = icard2 + 1;
        strHireLevel = "HireLevel" + tempindexCard;
        PlayerPrefs.SetInt(strHireLevel, gv.ListHireLevel[icard2]);
        PlayerPrefs.Save();


        


        if (gv.MapType == 1)
        {
            if (gv.ListHireCount[pos] != 0 && gv.ListHireCount[pos] != 1000)
            {                
            }
            else
            {                
            }
            if (gv.ListHireCount[pos] < 0 && gv.ListHireCount[pos] == 1000)
            {

            }
            else
            {
                if (gv.ListHireCount[pos] == 0)
                    gv.ListHireCount[pos] = 1;
                int index = pos + 1;
                string strHireCount = "HireCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[pos]);
                PlayerPrefs.Save();
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[pos] != 0 && gv.ListHireDesertCount[pos] != 1000)
            {                
            }
            else
            {                
            }
            if (gv.ListHireDesertCount[pos] < 0 && gv.ListHireDesertCount[pos] == 1000)
            {

            }
            else
            {
                gv.ListHireDesertCount[pos] = 1;
                int index = pos + 1;
                string strHireCount = "HireDesertCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[pos]);
                PlayerPrefs.Save();
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[pos] != 0 && gv.ListHireIceCount[pos] != 1000)
            {                
            }
            else
            {                
            }
            if (gv.ListHireIceCount[pos] < 0 && gv.ListHireIceCount[pos] == 1000)
            {

            }
            else
            {
                gv.ListHireIceCount[pos] = 1;
                int index = pos + 1;
                string strHireCount = "HireIceCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[pos]);
                PlayerPrefs.Save();
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[pos] != 0 && gv.ListHireForestCount[pos] != 1000)
            {                
            }
            else
            {                
            }
            if (gv.ListHireForestCount[pos] < 0 && gv.ListHireForestCount[pos] == 1000)
            {

            }
            else
            {
                gv.ListHireForestCount[pos] = 1;
                int index = pos + 1;
                string strHireCount = "HireForestCount" + index;
                PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[pos]);
                PlayerPrefs.Save();
            }
        }


        gv.ListHireCardOwnCount[pos] += 1;
        int indexCard = pos + 1;
        string strHireCardCount = "HireCardCount" + indexCard;

        PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[pos]);
        PlayerPrefs.Save();

        GameObject.Find("MainCanvas").GetComponent<HireSettingController>().InitSetHirePos(false);

    }
    IEnumerator StartB()
    {
        yield return new WaitForSeconds(0.2f);
        bstart = true;
    }
}
