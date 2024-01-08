using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HireController : MonoBehaviour {

    // Use this for initialization

    public GameObject MainStatusCanvas;
    public GameObject TabNormal;
    public GameObject TabNormalClick;
    public GameObject TabSpecial;
    public GameObject TabSpecialClick;

    public GameObject ScrollSpecialPanel;
    public GameObject ScrollPanel;
    public GameObject ScrollList;
    public GameObject ScrollSpecialList;
    public List<GameObject> ListBtn;
    public List<GameObject> ListSpecialBtn;


    private List<GameObject> ListCharacterList = new List<GameObject>();


    private List<Text> CharacterCostList = new List<Text>();
    private List<Text> CharacterBlackCoinCostList = new List<Text>();

    private List<GameObject> ListTextLevel = new List<GameObject>();
    private List<GameObject> ListTextTitle = new List<GameObject>();
    private List<GameObject> ListPrograss = new List<GameObject>();
    private List<Image> ListProgassImage = new List<Image>();
    private List<Text> ListTextProgassText = new List<Text>();

    private List<GameObject> ListLv = new List<GameObject>();

    private List<int> ListiSeleted = new List<int>();

    

    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {

        InitSet();

    }
    public void ClickNormal()
    {
     

        ScrollPanel.SetActive(true);
        ScrollSpecialPanel.SetActive(false);

        TabNormalClick.SetActive(true);
        TabNormal.SetActive(false);
        TabSpecialClick.SetActive(false);
        TabSpecial.SetActive(true);

        for(int i=0;i<3;i++)
        {
            ListBtn[i].SetActive(false);
            ListSpecialBtn[i].SetActive(false);
        }
        if(gv.selectNumber > -1)
            SelectMiner(gv.selectNumber);

    }
    public void ClickSpecial()
    {
        TabNormalClick.SetActive(false);
        TabNormal.SetActive(true);
        TabSpecialClick.SetActive(true);
        TabSpecial.SetActive(false);
        ScrollPanel.SetActive(false);
        ScrollSpecialPanel.SetActive(true);

        for (int i = 0; i < 3; i++)
        {
            ListBtn[i].SetActive(false);
            ListSpecialBtn[i].SetActive(false);
        }
        if (gv.selectNumber > -1)
            SelectMiner(gv.selectNumber);
    }
    public void DeleteList()
    {
        ListCharacterList.Clear();
        CharacterCostList.Clear();
        CharacterBlackCoinCostList.Clear();
        ListTextLevel.Clear();
        ListTextTitle.Clear();
        ListPrograss.Clear();
        ListProgassImage.Clear();
        ListTextProgassText.Clear();
        ListLv.Clear();
        ListiSeleted.Clear();
    }
    public void ResetSelectList()
    {

        for(int i=0; i< ListiSeleted.Count; i++)
        {
            if (ListiSeleted[i] == 1)
            {
                Color ccColor = new Color();
                ccColor.r = 1; ccColor.g = 1; ccColor.b = 1; ccColor.a = 1;
                ListiSeleted[i] = 0;
                ListCharacterList[i].GetComponent<Image>().color = ccColor;
            }
            ListiSeleted[i] = 0;
        }
    }

    public void UpgradeColor()
    {
        //for(int i=0; i< )

        for(int i=0; i<ListLv.Count; i++)
        {
            int index = i;
            ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index] - 1];
            //ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index]];
            if (gv.ListHireLevel[index] >= 7)
            {
                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
            }
            else
            {
                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
            }
        }
    }

    public void UpgradeCountMiner()
    {
        

    }


    void InitSet()
    {
        if(ScrollList != null)
        { 
            for(int i=0; i< 96; i++)
            {
                int characterNum = i + 1;
                string characterName = "Miner" + characterNum;
                GameObject character = ScrollList.transform.Find(characterName).gameObject;
                ListCharacterList.Add(character);

                ListTextLevel.Add(character.transform.Find("TextLevel").gameObject);
                ListTextTitle.Add(character.transform.Find("TextTitle").gameObject);

                ListPrograss.Add(character.transform.Find("PrograssBack").gameObject);
                ListProgassImage.Add(ListPrograss[ListPrograss.Count - 1].transform.Find("Prograss").gameObject.GetComponent<Image>());
                ListTextProgassText.Add(ListProgassImage[ListProgassImage.Count - 1].transform.Find("TextCount").gameObject.GetComponent<Text>());
                ListiSeleted.Add(0);
                ListLv.Add(character.transform.Find("ImageLevel").gameObject);
            }

        }
        if (ScrollSpecialList != null)
        {
            for (int i = 96; i < 110; i++)
            {
                int characterNum = i + 1;
                string characterName = "Miner" + characterNum;

                GameObject character = ScrollSpecialList.transform.Find(characterName).gameObject;
                ListCharacterList.Add(character);

                ListTextLevel.Add(character.transform.Find("TextLevel").gameObject);
                ListTextTitle.Add(character.transform.Find("TextTitle").gameObject);

                ListPrograss.Add(character.transform.Find("PrograssBack").gameObject);
                ListProgassImage.Add(ListPrograss[ListPrograss.Count - 1].transform.Find("Prograss").gameObject.GetComponent<Image>());
                ListTextProgassText.Add(ListProgassImage[ListProgassImage.Count - 1].transform.Find("TextCount").gameObject.GetComponent<Text>());
                ListiSeleted.Add(0);
                ListLv.Add(character.transform.Find("ImageLevel").gameObject);
            }
        }
   
        //GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextMiner("kor", CharacterNameList);        
    }
    public void SetView()
    {
        int deptIndex = 0;
        if (gv.MapType == 1)
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
        for(int i=0; i< gv.ListMinerClass.Count;i++)
        {            
            ListTextLevel[i].SetActive(true);
            
            ListTextTitle[i].SetActive(false);
        }

        for(int i=0; i< gv.ListHireCount.Count; i++)
        {
            if (gv.ListHireCount[i] == 0)
            {
                Color cColor = new Color();
                cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                ListPrograss[i].SetActive(false);
                ListLv[i].SetActive(false);
            }
            if (gv.ListHireDesertCount[i] == 0)
            {
                Color cColor = new Color();
                cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                ListPrograss[i].SetActive(false);
                ListLv[i].SetActive(false);
            }
            if (gv.ListHireIceCount[i] == 0)
            {
                Color cColor = new Color();
                cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                ListPrograss[i].SetActive(false);
                ListLv[i].SetActive(false);
            }
            if (gv.ListHireForestCount[i] == 0)
            {
                Color cColor = new Color();
                cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                ListPrograss[i].SetActive(false);
                ListLv[i].SetActive(false);
            }
        }
      

        for (int i=0; i< gv.ListMinerClass.Count;i++)
        {
            if(gv.ListMinerClass[i].m_depth <= deptIndex)
            {
                int index = gv.ListMinerClass[i].m_position-1;
                if (gv.MapType == 1)
                {
                    //if (gv.MapType == gv.ListMinerClass[i].m_home || gv.ListMinerClass[i].m_home < 0 || gv.ListHireCount[index] != 0)
                   
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = true;
                        Color cColor = new Color();
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        if (gv.ListHireCount[index] != 0)
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);
                            if (ListTextTitle[index].activeSelf == true)
                                ListTextTitle[index].SetActive(false);

                            if (ListPrograss[index].activeSelf == false)
                                ListPrograss[index].SetActive(true);

                            if (ListLv[index].activeSelf == false)
                            {
                                ListLv[index].SetActive(true);
                            }

                            ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index] - 1];
                            //ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index]];
                            if (gv.ListHireLevel[index] >= 7)
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                            }
                            else
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                            }

                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            string strPrgassText = gv.ListHireCardOwnCount[index] + " / 3";

                            ListTextProgassText[index].text = strPrgassText;
                            ListProgassImage[index].fillAmount = (float)gv.ListHireCardOwnCount[index] / 3;
                        }
                        else
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);

                            if (ListTextTitle[index].activeSelf == false)
                                ListTextTitle[index].SetActive(true);

                            
                            cColor = new Color();
                            cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            ListPrograss[index].SetActive(false);                                                                                
                            ListLv[index].SetActive(false);                            
                        }
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;
                    }                  
                }
                if (gv.MapType == 2)
                {
                    //if (gv.MapType == gv.ListMinerClass[i].m_home || gv.ListMinerClass[i].m_home < 0 || gv.ListHireDesertCount[index] != 0)
                    if (gv.ListHireDesertCount[index] == 0)
                    {
                        Color cColor = new Color();
                        cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                        ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        ListPrograss[index].SetActive(false);
                        ListLv[index].SetActive(false);
                    }
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = true;
                        Color cColor = new Color();
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        if (gv.ListHireDesertCount[index] != 0)
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);
                            if (ListTextTitle[index].activeSelf == true)
                                ListTextTitle[index].SetActive(false);

                            if (ListPrograss[index].activeSelf == false)
                                ListPrograss[index].SetActive(true);

                            if (ListLv[index].activeSelf == false)
                            {
                                ListLv[index].SetActive(true);
                            }

                            ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index] - 1];
                            //ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index]];
                            if (gv.ListHireLevel[index] >= 7)
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                            }
                            else
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                            }

                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            string strPrgassText = gv.ListHireCardOwnCount[index] + " / 3";

                            ListTextProgassText[index].text = strPrgassText;
                            ListProgassImage[index].fillAmount = (float)gv.ListHireCardOwnCount[index] / 3;
                        }
                        else
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);

                            if (ListTextTitle[index].activeSelf == false)
                                ListTextTitle[index].SetActive(true);

                            
                            cColor = new Color();
                            cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            ListPrograss[index].SetActive(false);
                            ListLv[index].SetActive(false);
                        }
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;
                    }                 
                }
                if (gv.MapType == 3)
                {
                    //if (gv.MapType == gv.ListMinerClass[i].m_home || gv.ListMinerClass[i].m_home < 0 || gv.ListHireIceCount[index] != 0)
                    if(gv.ListHireIceCount[index] ==0)
                    {
                        Color cColor = new Color();
                        cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                        ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        ListPrograss[index].SetActive(false);
                        ListLv[index].SetActive(false);
                    }
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = true;
                        Color cColor = new Color();
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        if (gv.ListHireIceCount[index] != 0)
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);
                            if (ListTextTitle[index].activeSelf == true)
                                ListTextTitle[index].SetActive(false);

                            if (ListPrograss[index].activeSelf == false)
                                ListPrograss[index].SetActive(true);

                            if (ListLv[index].activeSelf == false)
                            {
                                ListLv[index].SetActive(true);
                            }

                            ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index] - 1];
                            //ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index]];
                            if (gv.ListHireLevel[index] >= 7)
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                            }
                            else
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                            }

                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            string strPrgassText = gv.ListHireCardOwnCount[index] + " / 3";

                            ListTextProgassText[index].text = strPrgassText;
                            ListProgassImage[index].fillAmount = (float)gv.ListHireCardOwnCount[index] / 3;
                        }
                        else
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);

                            if (ListTextTitle[index].activeSelf == false)
                                ListTextTitle[index].SetActive(true);

                            
                            cColor = new Color();
                            cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            ListPrograss[index].SetActive(false);
                            ListLv[index].SetActive(false);
                        }
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;
                    }                
                }
                if (gv.MapType == 4)
                {
                    //if (gv.MapType == gv.ListMinerClass[i].m_home || gv.ListMinerClass[i].m_home < 0 || gv.ListHireForestCount[index] != 0)
                    if (gv.ListHireForestCount[index] != 0)
                    {
                        Color cColor = new Color();
                        cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                        ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        ListPrograss[index].SetActive(false);
                        ListLv[index].SetActive(false);
                    }
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = true;
                        Color cColor = new Color();
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        if (gv.ListHireForestCount[index] != 0)
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);
                            if (ListTextTitle[index].activeSelf == true)
                                ListTextTitle[index].SetActive(false);

                            if (ListPrograss[index].activeSelf == false)
                                ListPrograss[index].SetActive(true);

                            if (ListLv[index].activeSelf == false)
                            {
                                ListLv[index].SetActive(true);
                            }

                            ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index] - 1];
                            //ListLv[index].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[index]];
                            if (gv.ListHireLevel[index] >= 7)
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                            }
                            else
                            {
                                ListLv[index].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                                ListLv[index].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[index];
                            }

                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            string strPrgassText = gv.ListHireCardOwnCount[index] + " / 3";

                            ListTextProgassText[index].text = strPrgassText;
                            ListProgassImage[index].fillAmount = (float)gv.ListHireCardOwnCount[index] / 3;
                        }
                        else
                        {
                            if (ListTextLevel[index].activeSelf == true)
                                ListTextLevel[index].SetActive(false);

                            if (ListTextTitle[index].activeSelf == false)
                                ListTextTitle[index].SetActive(true);

                            
                            cColor = new Color();
                            cColor.r = 0; cColor.g = 0; cColor.b = 0; cColor.a = 1f;
                            ListCharacterList[index].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                            ListPrograss[index].SetActive(false);
                            ListLv[index].SetActive(false);
                        }
                        cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;
                    }                   
                }

            }
            else
            {
                if(gv.MapType ==1)
                {
                    int index = gv.ListMinerClass[i].m_position - 1;
                    if (gv.ListHireCount[index] == 0)
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = false;
                        Color cColor = new Color();
                        cColor.r = 0.235f; cColor.g = 0.235f; cColor.b = 0.235f; cColor.a = 1f;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;       
                    }
                }
                if (gv.MapType == 2)
                {
                    int index = gv.ListMinerClass[i].m_position - 1;
                    if (gv.ListHireDesertCount[index] == 0)
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = false;
                        Color cColor = new Color();
                        cColor.r = 0.235f; cColor.g = 0.235f; cColor.b = 0.235f; cColor.a = 1f;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;             
                    }
                }
                if (gv.MapType == 3)
                {
                    int index = gv.ListMinerClass[i].m_position - 1;
                    if (gv.ListHireIceCount[index] == 0)
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = false;
                        Color cColor = new Color();
                        cColor.r = 0.235f; cColor.g = 0.235f; cColor.b = 0.235f; cColor.a = 1f;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;
                 
                    }
                }
                if (gv.MapType == 4)
                {
                    int index = gv.ListMinerClass[i].m_position - 1;
                    if (gv.ListHireForestCount[index] == 0)
                    {
                        ListCharacterList[index].GetComponent<Button>().enabled = false;
                        Color cColor = new Color();
                        cColor.r = 0.235f; cColor.g = 0.235f; cColor.b = 0.235f; cColor.a = 1f;
                        ListCharacterList[index].GetComponent<Image>().color = cColor;            
                    }
                }

            }
        

            int index2 = gv.ListMinerClass[i].m_position - 1;            
     
        }
        for (int i = 0; i < gv.ListHireCount.Count; i++) 
        {
            if (gv.MapType == 1)
            {
                if (gv.ListHireCount[i] != 0 || i > 95)
                {
                    ListCharacterList[i].GetComponent<Button>().enabled = true;
                    Color cColor = new Color();
                    cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                    if (gv.ListHireCount[i] != 0)
                    {
                        if (ListTextLevel[i].activeSelf == true)
                            ListTextLevel[i].SetActive(false);
                        if (ListTextTitle[i].activeSelf == true)
                            ListTextTitle[i].SetActive(false);

                        if (ListPrograss[i].activeSelf == false)
                            ListPrograss[i].SetActive(true);

                        if (ListLv[i].activeSelf == false)
                        {
                            ListLv[i].SetActive(true);
                        }

                        ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
                        //ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i]];
                        if (gv.ListHireLevel[i] >= 7)
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                        }
                        else
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                        }

                        ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                        ListTextProgassText[i].text = strPrgassText;
                        ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;
                    }
             

                    ListCharacterList[i].GetComponent<Image>().color = cColor;
                }
           
            }
            if (gv.MapType == 2)
            {
                if (gv.ListHireDesertCount[i] != 0 || i > 95)
                {
                    ListCharacterList[i].GetComponent<Button>().enabled = true;
                    Color cColor = new Color();
                    cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                    if (gv.ListHireDesertCount[i] != 0)
                    {
                        if (ListTextLevel[i].activeSelf == true)
                            ListTextLevel[i].SetActive(false);
                        if (ListTextTitle[i].activeSelf == true)
                            ListTextTitle[i].SetActive(false);

                        if (ListPrograss[i].activeSelf == false)
                            ListPrograss[i].SetActive(true);

                        if (ListLv[i].activeSelf == false)
                        {
                            ListLv[i].SetActive(true);
                        }

                        ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
                        //ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i]];
                        if (gv.ListHireLevel[i] >= 7)
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                        }
                        else
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                        }

                        ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                        ListTextProgassText[i].text = strPrgassText;
                        ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;
                    }
                 

                    ListCharacterList[i].GetComponent<Image>().color = cColor;
                }
             
            }
            if (gv.MapType == 3)
            {
                if (gv.ListHireIceCount[i] != 0 || i > 95)
                {
                    ListCharacterList[i].GetComponent<Button>().enabled = true;
                    Color cColor = new Color();
                    cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                    if (gv.ListHireIceCount[i] != 0)
                    {
                        if (ListTextLevel[i].activeSelf == true)
                            ListTextLevel[i].SetActive(false);
                        if (ListTextTitle[i].activeSelf == true)
                            ListTextTitle[i].SetActive(false);

                        if (ListPrograss[i].activeSelf == false)
                            ListPrograss[i].SetActive(true);

                        if (ListLv[i].activeSelf == false)
                        {
                            ListLv[i].SetActive(true);
                        }

                        ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
                        //ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i]];
                        if (gv.ListHireLevel[i] >= 7)
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                        }
                        else
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                        }

                        ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                        ListTextProgassText[i].text = strPrgassText;
                        ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;
                    }
                  

                    ListCharacterList[i].GetComponent<Image>().color = cColor;
                }
              
            }
            if (gv.MapType == 4)
            {
                if ( gv.ListHireForestCount[i] != 0 || i > 95)
                {
                    ListCharacterList[i].GetComponent<Button>().enabled = true;
                    Color cColor = new Color();
                    cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;
                    if (gv.ListHireForestCount[i] != 0)
                    {
                        if (ListTextLevel[i].activeSelf == true)
                            ListTextLevel[i].SetActive(false);
                        if (ListTextTitle[i].activeSelf == true)
                            ListTextTitle[i].SetActive(false);

                        if (ListPrograss[i].activeSelf == false)
                            ListPrograss[i].SetActive(true);

                        if (ListLv[i].activeSelf == false)
                        {
                            ListLv[i].SetActive(true);
                        }

                        ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
                        //ListLv[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i]];
                        if (gv.ListHireLevel[i] >= 7)
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Max";
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Max";
                        }
                        else
                        {
                            ListLv[i].transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                            ListLv[i].transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                        }

                        ListCharacterList[i].transform.Find("Miner").gameObject.GetComponent<Image>().color = cColor;
                        string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                        ListTextProgassText[i].text = strPrgassText;
                        ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;
                    }
                    

                    ListCharacterList[i].GetComponent<Image>().color = cColor;
                }             
            }
        }

        for (int i = 0; i < 3; i++)
        {
            ListBtn[i].SetActive(false);
            ListSpecialBtn[i].SetActive(false);
        }
    }
    public void ConfimeBuyMInerCoin()
    {
        if (gv.selectNumber > -1)
        {
            //추가 구매 상황 고려해야됨
            double money_m = 0;

            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == gv.selectNumber + 1)
                {
                    money_m = gv.ListHireCost[i];
                }
            }

            if (gv.Money >= money_m)
            {


                gv.Money -= money_m;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                PlayerPrefs.Save();
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupGetCharectorCanvas(1, gv.selectNumber);

                SetView();

                ListiSeleted[gv.selectNumber] = 0;


                gv.selectNumber = -1;
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressMinerInfoCanvas(0);
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHireShop(0);

                GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckHireQuest());
                GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 0)
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(0,0);
            }
            else
            {
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "골드가 부족합니다.");
            }

            if (gv.isOpening == 0)
            {                
                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
                GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
            }
        }
    }
    public void BuyMinerCoin()
    {
        if(gv.isOpening ==0)
        {
            ConfimeBuyMInerCoin();
        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressBuyConfimView(1, "M");
        }
        
    }
    
    public void SelectMiner(int number)
    {
        int indexNumber = number + 1;
        gv.strCharacterSelect = "Miner" + indexNumber;
        if(number < 96)
        {
            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == number + 1)
                {
                    if (gv.ListHireCount[number] == 0 && gv.ListHireDesertCount[number] == 0 && gv.ListHireIceCount[number] == 0 &&
                        gv.ListHireForestCount[number] == 0)
                    {
                        if (gv.MapType != gv.ListMinerClass[i].m_home || gv.ListMinerClass[i].m_home < 0)
                        {
                            if (gv.ListMinerClass[i].m_home == 1)
                                MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("기본 맵에서\n구매 가능합니다.");
                            if (gv.ListMinerClass[i].m_home == 2)
                                MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("사막 맵에서\n구매 가능합니다.");
                            if (gv.ListMinerClass[i].m_home == 3)
                                MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("얼음 맵에서\n구매 가능합니다.");
                            if (gv.ListMinerClass[i].m_home == 4)
                                MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("정글 맵에서\n구매 가능합니다.");
                            return;
                        }
                    }

                }
            }
        }
      
        int equalCount = 0;
        for (int i = 0; i < gv.UniqueMinerList.Count; i++)
        {
            if (gv.UniqueMinerList[i] == indexNumber -1)
            {
                Text TextMoney1 = null;                
             
                TextMoney1 = ListBtn[1].transform.Find("TextMoney").GetComponent<Text>();

                if (i ==9 )
                {
                    ListSpecialBtn[1].transform.Find("BlackCoin").gameObject.SetActive(false);
                    ListSpecialBtn[1].transform.Find("WinMark").gameObject.SetActive(false);
                    ListSpecialBtn[1].transform.Find("LoseMark").gameObject.SetActive(true);                    
                }
                else if (i == 10)
                {
                    ListSpecialBtn[1].transform.Find("BlackCoin").gameObject.SetActive(false);
                    ListSpecialBtn[1].transform.Find ("WinMark").gameObject.SetActive(true);
                    ListSpecialBtn[1].transform.Find("LoseMark").gameObject.SetActive(false);                    
                }
                else
                {
                    ListSpecialBtn[1].transform.Find("BlackCoin").gameObject.SetActive(true);
                    ListSpecialBtn[1].transform.Find("WinMark").gameObject.SetActive(false);
                    ListSpecialBtn[1].transform.Find("LoseMark").gameObject.SetActive(false);                   
                }
                equalCount++;
            }
        }

        if (ListiSeleted[number] == 0 )
        {
            gv.selectNumber = number;
            Color cColor = new Color();
            cColor.r = 1; cColor.g = 0.87f; cColor.b = 0.35f; cColor.a = 1;

            
            StartCoroutine("BtnAnim");
            Vector2 vec = new Vector2();
            ListCharacterList[number].GetComponent<Image>().color = cColor;
            vec = ListCharacterList[number].transform.localPosition;
            if (ScrollSpecialPanel.activeSelf == false)
            {
                vec.y = vec.y - 89;
                ListBtn[0].transform.localPosition = vec;
                vec.y = vec.y - 60;
                ListBtn[1].transform.localPosition = vec;
                vec.y = vec.y - 60;
                ListBtn[2].transform.localPosition = vec;
            }
            else
            {
                vec.y = vec.y - 89;
                ListSpecialBtn[0].transform.localPosition = vec;
                vec.y = vec.y - 60;
                ListSpecialBtn[1].transform.localPosition = vec;
                vec.y = vec.y - 60;
                ListSpecialBtn[2].transform.localPosition = vec;
            }

            for (int i = 0; i < ListiSeleted.Count; i++)
            {
                if (ListiSeleted[i] == 1)
                {
                    Color ccColor = new Color();
                    ccColor.r = 1; ccColor.g = 1; ccColor.b = 1; ccColor.a = 1;
                    ListiSeleted[i] = 0;
                    ListCharacterList[i].GetComponent<Image>().color = ccColor;
                }
            }
            Text TextMoney1 = null;
            Text TextMoney2 = null;
            if (ScrollSpecialPanel.activeSelf == false)
            {
                TextMoney1 = ListBtn[1].transform.Find("TextMoney").GetComponent<Text>();
                TextMoney2 = ListBtn[1].transform.Find("TextMoney2").GetComponent<Text>();
            }
            else
            {
                TextMoney1 = ListSpecialBtn[1].transform.Find("TextMoney").GetComponent<Text>();
                TextMoney2 = ListSpecialBtn[1].transform.Find("TextMoney2").GetComponent<Text>();
            }

            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == number + 1)
                {
                    if(equalCount ==0)
                    {
                        TextMoney1.text = gv.ChangeMoney(gv.ListHireCost[i]);
                        TextMoney2.text = gv.ChangeMoney(gv.ListHireCost[i]);
                    }
                    else
                    {
                        TextMoney1.text = gv.ListHireCost[i].ToString();
                        TextMoney2.text = gv.ListHireCost[i].ToString();
                    }
                    
                }
            }


            ListiSeleted[number] = 1;
        }
        else if (ListiSeleted[number] == 1)
        {
            gv.selectNumber = -1;
            Color cColor = new Color();
            cColor.r = 1; cColor.g = 1; cColor.b = 1; cColor.a = 1;

            ListiSeleted[number] = 0;
            for (int i = 0; i < 3; i++)
            {
                ListBtn[i].GetComponent<Animator>().SetBool("isBack", true);
                ListSpecialBtn[i].GetComponent<Animator>().SetBool("isBack", true);
            }
            ListCharacterList[number].GetComponent<Image>().color = cColor;
        }
     
        if (gv.isOpening ==0)
        {            
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetCollider(false);
            GameObject.Find("MainCanvas").GetComponent<MainPanelMouseDown>().InputGame();
        }
    }
    
    IEnumerator BtnAnim()
    {
        for(int i=0; i< 3;i++)
        {
            ListBtn[i].SetActive(false);
            ListSpecialBtn[i].SetActive(false);
        }        
        if(gv.selectNumber >-1)
        {
        
            ListBtn[0].SetActive(true);
            ListSpecialBtn[0].SetActive(true);
        }
            
        yield return new WaitForSeconds(0.1f);
        if (gv.selectNumber > -1)
        {
            if (gv.ListHireCount[gv.selectNumber] != 0 && gv.selectNumber >=96)
            {
                ListBtn[1].SetActive(true);
                ListSpecialBtn[1].SetActive(true);
            }
            else if(gv.selectNumber < 96)
            {
                ListBtn[1].SetActive(true);
                ListSpecialBtn[1].SetActive(true);
            }
            
        }
        
        yield return new WaitForSeconds(0.1f);
        if (gv.selectNumber > -1)
        {
            if (gv.ListHireCount[gv.selectNumber] != 0 && gv.selectNumber >=96)
            {
                ListBtn[2].SetActive(true);
                ListSpecialBtn[2].SetActive(true);
            }
            else if (gv.selectNumber < 96)
            {
                ListBtn[2].SetActive(true);
                ListSpecialBtn[2].SetActive(true);
            }
        }
        

    }
    void BuyMark(int type,int count)
    {
        if(type == 0)
        {
            if(gv.WinMarkTotal >= count)
            {
                gv.WinMarkTotal -= count;
                string strUpgradeTotalCount = "WinMark";
                PlayerPrefs.SetInt(strUpgradeTotalCount, gv.WinMarkTotal);
                PlayerPrefs.Save();
                GetMinerUnique();
            }
            else
            {
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "승리의 증표가 부족 합니다.\n(미니 게임 승리로 획득가능)");
            }
        }
        if(type ==1)
        {
            if(gv.LoseMarkTotal >= count)
            {
                gv.LoseMarkTotal -= count;
                string strUpgradeTotalCount = "LoseMark";
                PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LoseMarkTotal);
                PlayerPrefs.Save();
                GetMinerUnique();
            }
            else
            {
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "패배의 증표가 부족 합니다.\n(미니 게임 패배로 획득가능)");
            }
        }
    }
    void GetMinerUnique()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupGetCharectorCanvas(1, gv.selectNumber);

        SetView();

        ListiSeleted[gv.selectNumber] = 0;


        gv.selectNumber = -1;
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressMinerInfoCanvas(0);
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHireShop(0);

        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckHireQuest());
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
    }
    void BuyBlackCoin(int count)
    {
        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        if (0 != SIS.DBManager.IncreaseFunds("blackcoin", -count))
        {
            GetMinerUnique();
        }
        else
        {
            MainStatusCanvas.GetComponent<PopUpManager>().NeedBlackCoinView(1);
        }
    }

    public void BuyQniqueConfirm()
    {
        if (gv.selectNumber > -1)
        {
            int money =0;
            for (int i = 0; i < gv.ListMinerClass.Count; i++)
            {
                if (gv.ListMinerClass[i].m_position == gv.selectNumber + 1)
                {
                    money = (int)gv.ListHireCost[i];
                }
            }

            int SelectNumber = -1;
            for (int i = 0; i < gv.UniqueMinerList.Count; i++)
            {
                if (gv.UniqueMinerList[i] == gv.selectNumber)
                {
                    SelectNumber = i;
                }
            }
            if (SelectNumber >= 0)
            {
                if (SelectNumber == 9)
                {
                    BuyMark(1, money);
                }
                else if (SelectNumber == 10)
                {
                    BuyMark(0, money);
                }
                else
                {                    
                    BuyBlackCoin(money);
                }
            }
        }
    }
    public void BuyMinerUnique()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressBuyConfimView(1,"U");
    }

    public void UpgradeMiner()
    {
        if (gv.selectNumber > -1)
        {
            if (gv.ListHireCardOwnCount[gv.selectNumber] < 3)
            {
                //MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "마이너 카드 3장이 필요합니다.");
                if(gv.ListHireCount[gv.selectNumber] !=0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(1);
                    GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().SetMiner(gv.selectNumber);
                }
                else if (gv.ListHireDesertCount[gv.selectNumber] != 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(1);
                    GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().SetMiner(gv.selectNumber);
                }
                else if (gv.ListHireIceCount[gv.selectNumber] != 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(1);
                    GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().SetMiner(gv.selectNumber);
                }
                else if (gv.ListHireForestCount[gv.selectNumber] != 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(1);
                    GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().SetMiner(gv.selectNumber);
                }
                else
                {
                    MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "광부를 구매해야 합니다.");
                }
            }
            else
            {
                if(gv.ListHireLevel[gv.selectNumber] <7)
                {
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNoticeUpgrade(1);
                    GameObject.Find("MainCanvas").GetComponent<MinerUpgradeManager>().SetMiner(gv.selectNumber);
                }
                else
                {
                    MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "최대레벨 입니다.");
                }
                
            }
        }
        
    }
  
}
