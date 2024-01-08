using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CharacterListControll : MonoBehaviour {

    // Use this for initialization
    public ScrollRect scrollRect;
    public GameObject ScrollMinerList;
    public GameObject SelectObj;
    //public GameObject InfoObj;

    //private GameObject BtnInfo;
    //private GameObject BtnUp;
    private List<GameObject> MinerList = new List<GameObject>();
    private List<Text> ListTextCount1 = new List<Text>();
    private List<Image> ListProgassImage = new List<Image>();

    private List<Text> ListTextLv = new List<Text>();
    private List<Text> ListTextLv2 = new List<Text>();
    private List<Image> LvImageList = new List<Image>();
    GlobalVariable gv;
    //Vector2 InfoPos = new Vector2();
    //private GameObject InfoClone;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitList();
	}
	
    public void DeleteList()
    {
        MinerList.Clear();
        ListTextCount1.Clear();
        ListProgassImage.Clear();
    }

    public void InitList()
    {
        
        for (int i=0; i< 110; i++)
        {
            int MinerCount = i + 1; 
            string name = "Miner" + MinerCount;
            MinerList.Add(ScrollMinerList.transform.Find(name).gameObject);
            ListTextCount1.Add(ScrollMinerList.transform.Find(name).gameObject.transform.Find("PrograssBack").gameObject.transform.Find("Prograss").gameObject.transform.Find("TextCount").gameObject.GetComponent<Text>());
            ListProgassImage.Add(ScrollMinerList.transform.Find(name).gameObject.transform.Find("PrograssBack").gameObject.transform.Find("Prograss").gameObject.GetComponent<Image>());
            ListTextLv.Add(ScrollMinerList.transform.Find(name).gameObject.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").gameObject.GetComponent<Text>());
            ListTextLv2.Add(ScrollMinerList.transform.Find(name).gameObject.transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").gameObject.GetComponent<Text>());
            LvImageList.Add(ScrollMinerList.transform.Find(name).gameObject.transform.Find("ImageLevel").gameObject.GetComponent<Image>());
        }
        
    }

    public void SetDeleteCard()
    {
        SelectObj.SetActive(true);
        SetCardView();

        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(true);
                    }
                }
            }
            for (int i = 0; i < gv.RobotNormal.Count; i++)
            {
                if (gv.RobotNormal[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotNormal[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireDesertCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(true);
                    }
                }
            }
            for (int i = 0; i < gv.RobotDesert.Count; i++)
            {
                if (gv.RobotDesert[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotDesert[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireIceCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(true);
                    }
                }
            }
            for (int i = 0; i < gv.RobotIce.Count; i++)
            {
                if (gv.RobotIce[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotIce[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireForestCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(true);
                    }
                }
            }
            for (int i = 0; i < gv.RobotForest.Count; i++)
            {
                if (gv.RobotForest[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotForest[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }

        

    }
    public void SetCard(string name)
    {
        int count = 0;
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i].name != name)
            {
                if(MinerList[i].activeSelf == true)
                {
                    MinerList[i].GetComponent<Animator>().SetBool("isCard", false);
                    Color color = MinerList[i].GetComponent<Image>().color;
                    color.r = 1;
                    color.g = 1;
                    color.b = 1;
                    MinerList[i].GetComponent<Image>().color = color;
                    count++;
                }
            }
            else
            {
                MinerList[i].GetComponent<Animator>().SetBool("isCard", true);
                Color color = MinerList[i].GetComponent<Image>().color;
                color.r = 1f;
                color.g = 0.87f;
                color.b = 0.35f;
                MinerList[i].GetComponent<Image>().color = color;
                gv.strCharacterSelect = name;
                SetCardView();    
            }
        }
    }

    public void UpdateFlag(bool flag)
    {
        //startScroll = flag;

        //for (int i = 0; i < gv.ListHireCount.Count; i++)
        //{
        //    MinerList[i].SetActive(false);
        //}
    }
    public void UnSetCard()
    {
        
        for (int i = 0; i < MinerList.Count; i++)
        {
            MinerList[i].GetComponent<Animator>().SetBool("isCard", false);
            Color color = MinerList[i].GetComponent<Image>().color;
            color.r = 1;
            color.g = 1;
            color.b = 1;
            MinerList[i].GetComponent<Image>().color = color;
        }
        DeleteCard();
    }

    public void ViewCardReset()
    {
        //Destroy(InfoClone);
        for (int i = 0; i < MinerList.Count; i++)
        {
            MinerList[i].GetComponent<Animator>().SetBool("isCard", false);
            Color color = MinerList[i].GetComponent<Image>().color;
            color.r = 1;
            color.g = 1;
            color.b = 1;
            MinerList[i].GetComponent<Image>().color = color;
        }
    }
    public void FalseView()
    {
        SelectObj.SetActive(false);
    }
    public void SetInfoCanvas(int iPos)
    {
        //Destroy(InfoClone);
        //InfoClone = Instantiate(InfoObj as GameObject);
        //InfoClone.transform.SetParent(SelectCardClone[iPos - 1].transform);
        //InfoClone.transform.localScale = InfoObj.transform.localScale;
        //InfoClone.transform.localPosition = InfoObj.transform.localPosition;
        int depth =0;
        if (iPos == 1 || iPos == 2)
            depth = 1;
        if (iPos == 3 || iPos == 4)
            depth = 2;
        if (iPos == 5 || iPos == 6)
            depth = 3;
        if (iPos == 7 || iPos == 8)
            depth = 4;
        if (iPos == 9 || iPos == 10)
            depth = 5;
        if (iPos == 11 || iPos == 12)
            depth = 6;
        if (iPos == 13 || iPos == 14)
            depth = 7;
        if (iPos == 15 || iPos == 16)
            depth = 8;
        if (iPos == 17 || iPos == 18)
            depth = 9;
        if (iPos == 19 || iPos == 20)
            depth = 10;
        if (iPos == 21 || iPos == 22)
            depth = 11;
        if (iPos == 23 || iPos == 24)
            depth = 12;
        if (iPos == 25 || iPos == 26)
            depth = 13;
        if (iPos == 27 || iPos == 28)
            depth = 14;

        if (iPos == 29 || iPos == 30)
            depth = 15;
        if (iPos == 31 || iPos == 32)
            depth = 16;
        if (iPos == 33 || iPos == 34)
            depth = 17;
        if (iPos == 35 || iPos == 36)
            depth = 18;
        if (iPos == 37 || iPos == 38)
            depth = 19;
        if (iPos == 39 || iPos == 40)
            depth = 20;
        if (iPos == 41 || iPos == 42)
            depth = 21;
        if (iPos == 43 || iPos == 44)
            depth = 22;
        if (iPos == 45 || iPos == 46)
            depth = 23;
        if (iPos == 47 || iPos == 48)
            depth = 24;
        if (iPos == 49 || iPos == 50)
            depth = 25;
        if (iPos == 51 || iPos == 52)
            depth = 26;
        if (iPos == 53 || iPos == 54)
            depth = 27;
        if (iPos == 55 || iPos == 56)
            depth = 28;

        if (iPos == 57 || iPos == 58)
            depth = 29;
        if (iPos == 59 || iPos == 60)
            depth = 30;
        if (iPos == 61 || iPos == 62)
            depth = 31;
        if (iPos == 63 || iPos == 64)
            depth = 32;
        if (iPos == 65 || iPos == 66)
            depth = 33;
        if (iPos == 67 || iPos == 68)
            depth = 34;
        if (iPos == 69 || iPos == 70)
            depth = 35;
        if (iPos == 71 || iPos == 72)
            depth = 36;
        if (iPos == 73 || iPos == 74)
            depth = 37;
        if (iPos == 75 || iPos == 76)
            depth = 38;
        if (iPos == 77 || iPos == 78)
            depth = 39;

        if (iPos == 79 || iPos == 80)
            depth = 40;
        if (iPos == 81 || iPos == 82)
            depth = 41;
        if (iPos == 83 || iPos == 84)
            depth = 42;
        if (iPos == 85 || iPos == 86)
            depth = 43;
        if (iPos == 87 || iPos == 88)
            depth = 44;
        if (iPos == 89 || iPos == 90)
            depth = 45;
        if (iPos == 91 || iPos == 92)
            depth = 46;
        if (iPos == 93 || iPos == 94)
            depth = 47;
        if (iPos == 95 || iPos == 96)
            depth = 48;
        if (iPos == 97 || iPos == 98)
            depth = 49;
        if (iPos == 99 || iPos == 100)
            depth = 50;

        if (iPos == 101 || iPos == 102)
            depth = 51;
        if (iPos == 103 || iPos == 104)
            depth = 52;
        if (iPos == 105 || iPos == 106)
            depth = 53;
        if (iPos == 107 || iPos == 108)
            depth = 54;
        if (iPos == 109 || iPos == 110)
            depth = 55;
        if (iPos == 111 || iPos == 112)
            depth = 56;
        if (iPos == 113 || iPos == 114)
            depth = 57;
        if (iPos == 115 || iPos == 116)
            depth = 58;


        //UnsetPrograssClone();
        Vector3 InfoVec = new Vector3();
    
        //PrograssClone[iPos-1].SetActive(true);
    
        InfoVec.x = 285;
           
        InfoVec.y = 10;

        
        //InfoClone.transform.localPosition = InfoVec;
        //InfoClone.SetActive(false);
        //InfoClone.SetActive(true);
    }

    void UnsetPrograssClone()
    {
        //Destroy(InfoClone);
        for (int i = 0; i < PrograssClone.Count; i++)
        {
            PrograssClone[i].SetActive(false);
        }
        if(PrograssClone.Count >0)
        {
            if(gv.MapType ==1)
            {
                for (int i = 0; i < gv.ListHireCount.Count; i++)
                {
                    if (gv.ListHireCount[i] < 0)
                    {
                        PrograssClone[Mathf.Abs(gv.ListHireCount[i] + 1)].SetActive(true);
                    }
                }
            }
            if (gv.MapType == 2)
            {
                for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
                {
                    if (gv.ListHireDesertCount[i] < 0)
                    {
                        PrograssClone[Mathf.Abs(gv.ListHireDesertCount[i] + 1)].SetActive(true);
                    }
                }
            }
            if (gv.MapType == 3)
            {
                for (int i = 0; i < gv.ListHireIceCount.Count; i++)
                {
                    if (gv.ListHireIceCount[i] < 0)
                    {
                        PrograssClone[Mathf.Abs(gv.ListHireIceCount[i] + 1)].SetActive(true);
                    }
                }
            }
            if (gv.MapType == 4)
            {
                for (int i = 0; i < gv.ListHireForestCount.Count; i++)
                {
                    if (gv.ListHireForestCount[i] < 0)
                    {
                        PrograssClone[Mathf.Abs(gv.ListHireForestCount[i] + 1)].SetActive(true);
                    }
                }
            }

        }
       
    }
    //List<int> MinerScrollList = new List<int>();
    //bool startScroll = false;
    //int InitXPos;
    //int margin = 170;
    //int prevI =-1;
    //private void FixedUpdate()
    //{
    //    //if(startScroll ==true)
    //    //{
    //    //    int posNow = (int)ScrollMinerList.transform.localPosition.x;
    //    //    int i = (InitXPos - posNow) / margin;            
    //    //    if(prevI != i)
    //    //    {
    //    //        prevI = i;
    //    //        for (int k = 0; k < gv.ListHireCount.Count; k++)
    //    //        {                    
    //    //            if (i == k || i+1 ==k || i+2 ==k || i+3 ==k || i+4 ==k || i+5 ==k)
    //    //            {
    //    //                MinerList[MinerScrollList[k]].SetActive(true);
    //    //            }                   
    //    //            else
    //    //            {
    //    //                MinerList[k].SetActive(false);
    //    //            }
    //    //        }
    //    //    }          
    //    //}
    //}
    public void InitSettingCard()
    {
        //UnsetPrograssClone();     

        int hireCount = 0;
        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] > 0 && gv.ListHireCount[i] != 1000)
                {
                    hireCount++;
                    MinerList[i].SetActive(true);
                    //MinerScrollList.Add(i);
                }
                else
                {
                    MinerList[i].SetActive(false);
                }
                string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                ListTextCount1[i].text = strPrgassText;
                ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;

                ListTextLv[i].text = "Lv. " + gv.ListHireLevel[i];
                ListTextLv2[i].text = "Lv. " + gv.ListHireLevel[i];

                if (gv.ListHireLevel[i] >= 7)
                {
                    ListTextLv[i].text = "Max";
                    ListTextLv2[i].text = "Max";
                }
                else
                {
                    ListTextLv[i].text = "Lv. " + gv.ListHireLevel[i];
                    ListTextLv2[i].text = "Lv. " + gv.ListHireLevel[i];
                }
                LvImageList[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] > 0 && gv.ListHireDesertCount[i] != 1000)
                {
                    hireCount++;
                    MinerList[i].SetActive(true);
                    //MinerScrollList.Add(i);
                }
                else
                {
                    MinerList[i].SetActive(false);
                }
                string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                ListTextCount1[i].text = strPrgassText;
                ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;

                if (gv.ListHireLevel[i] >= 7)
                {
                    ListTextLv[i].text = "Max";
                    ListTextLv2[i].text = "Max";
                }
                else
                {
                    ListTextLv[i].text = "Lv. " + gv.ListHireLevel[i];
                    ListTextLv2[i].text = "Lv. " + gv.ListHireLevel[i];
                }
                LvImageList[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] > 0 && gv.ListHireIceCount[i] != 1000)
                {
                    hireCount++;
                    MinerList[i].SetActive(true);
                    //MinerScrollList.Add(i);
                }
                else
                {
                    MinerList[i].SetActive(false);
                }
                string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                ListTextCount1[i].text = strPrgassText;
                ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;

                if (gv.ListHireLevel[i] >= 7)
                {
                    ListTextLv[i].text = "Max";
                    ListTextLv2[i].text = "Max";
                }
                else
                {
                    ListTextLv[i].text = "Lv. " + gv.ListHireLevel[i];
                    ListTextLv2[i].text = "Lv. " + gv.ListHireLevel[i];
                }
                LvImageList[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] > 0 && gv.ListHireForestCount[i] != 1000)
                {
                    hireCount++;
                    MinerList[i].SetActive(true);
                    //MinerScrollList.Add(i);
                }
                else
                {
                    MinerList[i].SetActive(false);
                }
                string strPrgassText = gv.ListHireCardOwnCount[i] + " / 3";

                ListTextCount1[i].text = strPrgassText;
                ListProgassImage[i].fillAmount = (float)gv.ListHireCardOwnCount[i] / 3;
                if (gv.ListHireLevel[i] >= 7)
                {
                    ListTextLv[i].text = "Max";
                    ListTextLv2[i].text = "Max";
                }
                else
                {
                    ListTextLv[i].text = "Lv. " + gv.ListHireLevel[i];
                    ListTextLv2[i].text = "Lv. " + gv.ListHireLevel[i];
                }
                LvImageList[i].GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];
            }
        }

        if (hireCount > 4)
        {
            RectTransform rt = ScrollMinerList.GetComponent<RectTransform>();
            int width = (hireCount-4) * 190;
            rt.sizeDelta = new Vector2(800 + width, 241);
        }
        if(bStartCard == false)
        {
            scrollRect.horizontalNormalizedPosition = 0;
            bStartCard = true;
        }
        
        //InitXPos = (int)ScrollMinerList.transform.localPosition.x;
    }
    bool bStartCard = false;
    List<GameObject> ArrowClone = new List<GameObject>();
    List<GameObject> SelectCardClone = new List<GameObject>();
    List<GameObject> DeleteClone = new List<GameObject>();
    List<GameObject> PrograssClone = new List<GameObject>();

    void SetCardView()
    {

        GameObject Arrow = SelectObj.transform.Find("Arrow.0").gameObject;
        GameObject SelectCard = SelectObj.transform.Find("Card.0").gameObject;
        GameObject Delete = SelectObj.transform.Find("Delete").gameObject;
        GameObject Prograss = SelectObj.transform.Find("PrograssBack").gameObject;
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

        for (int i = 0; i < deptIndex; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 ArrowVec = new Vector3();
                Vector3 VectorCard = new Vector3();
                Vector3 DeleteVec = new Vector3();
                Vector3 PrograssVec = new Vector3();
                if (j == 0)
                {
                    ArrowVec.x = -215f;
                    ArrowVec.y = 75f - ((i) * 350);
                    VectorCard.x = -215f;
                    VectorCard.y = -80f - ((i) * 350);
                    DeleteVec.x = -215f;
                    DeleteVec.y = 75f - ((i) * 350);

                    PrograssVec.x = -215;
                    PrograssVec.y = -145 - ((i) * 350);
                }
                else if (j == 1)
                {
                    ArrowVec.x = 10;
                    ArrowVec.y = 75f - ((i) * 350);
                    VectorCard.x = 10;
                    VectorCard.y = -80f - ((i) * 350);
                    DeleteVec.x = 10;
                    DeleteVec.y = 75f - ((i) * 350);

                    PrograssVec.x = 10;
                    PrograssVec.y = -145 - ((i) * 350);
                }


                ArrowClone.Add(Instantiate(Arrow));
                ArrowClone[ArrowClone.Count - 1].name = "Arrow." + (ArrowClone.Count - 1);
                ArrowClone[ArrowClone.Count - 1].transform.SetParent(SelectObj.transform);
                ArrowClone[ArrowClone.Count - 1].transform.localScale = Arrow.transform.localScale;
                ArrowClone[ArrowClone.Count - 1].transform.localPosition = ArrowVec;


                SelectCardClone.Add(Instantiate(SelectCard));
                SelectCardClone[SelectCardClone.Count - 1].name = "Card." + (SelectCardClone.Count - 1);
                SelectCardClone[SelectCardClone.Count - 1].transform.SetParent(SelectObj.transform);
                SelectCardClone[SelectCardClone.Count - 1].transform.localScale = SelectCard.transform.localScale;
                SelectCardClone[SelectCardClone.Count - 1].transform.localPosition = VectorCard;


                DeleteClone.Add(Instantiate(Delete));
                DeleteClone[DeleteClone.Count - 1].name = "Delete." + (DeleteClone.Count - 1);
                DeleteClone[DeleteClone.Count - 1].transform.SetParent(SelectObj.transform);
                DeleteClone[DeleteClone.Count - 1].transform.localScale = Delete.transform.localScale;
                DeleteClone[DeleteClone.Count - 1].transform.localPosition = DeleteVec;


                //PrograssClone.Add(Instantiate(Prograss));
                //PrograssClone[PrograssClone.Count - 1].name = "Prograss." + (PrograssClone.Count - 1);
                //PrograssClone[PrograssClone.Count - 1].transform.SetParent(SelectObj.transform);
                //PrograssClone[PrograssClone.Count - 1].transform.localScale = Prograss.transform.localScale;
                //PrograssClone[PrograssClone.Count - 1].transform.localPosition = PrograssVec;
                //PrograssClone[PrograssClone.Count - 1].SetActive(false);
            }
        }
        //UnsetPrograssClone();
        InitCardSetting();
    }

    public void InitCardSetting()
    {

        //InfoPos.x = -600;
        //InfoPos.y = 0;
        //InfoObj.transform.localPosition = InfoPos;        
        for (int i = 0; i < DeleteClone.Count; i++)
        {
            {
                DeleteClone[i].SetActive(false);
                ArrowClone[i].SetActive(true);

            }          
        }

        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                        
                    }
                }              
            }
            for(int i =0; i<gv.RobotNormal.Count; i++)
            {
                if (gv.RobotNormal[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotNormal[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
            
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireDesertCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                    }
                }              
            }
            for (int i = 0; i < gv.RobotDesert.Count; i++)
            {
                if (gv.RobotDesert[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotDesert[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireIceCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                    }
                }            
            }
            for (int i = 0; i < gv.RobotIce.Count; i++)
            {
                if (gv.RobotIce[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotIce[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] < 0)
                {
                    int index = Mathf.Abs(gv.ListHireForestCount[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(true);
                        ArrowClone[index - 1].SetActive(false);
                    }
                }               
            }
            for (int i = 0; i < gv.RobotForest.Count; i++)
            {
                if (gv.RobotForest[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotForest[i]);
                    if (index - 1 < DeleteClone.Count)
                    {
                        DeleteClone[index - 1].SetActive(false);
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
    }

    void DeleteCard()
    {
        
        for(int i=0; i < ArrowClone.Count; i++)
        {
            Destroy(ArrowClone[i]);
            Destroy(SelectCardClone[i]);
            Destroy(DeleteClone[i]);
            //Destroy(PrograssClone[i]);
        }
        //Destroy(InfoClone);
        ArrowClone.Clear();
        SelectCardClone.Clear();
        DeleteClone.Clear();        
        //PrograssClone.Clear();
    }
}
