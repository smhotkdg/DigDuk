using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FreeLvUpUIManager : MonoBehaviour {

    // Use this for initialization
    public GameObject OwnCardBG;
    public GameObject BtnClose;
    public GameObject BtnCompose;
    public GameObject MinerListBG;
    public GameObject BtnClose2;
    public GameObject Effect;

    public GameObject MainStatusCanvas;            
    public GameObject MinerListObj;
    public GameObject Card1;
    List<GameObject> ImageLevel = new List<GameObject>();
    public ScrollRect Scrollrect;
    List<GameObject> MinerList = new List<GameObject>();

    GameObject MinerClone;
    GlobalVariable gv;
    int selectNumber = -1;
    bool bSelectCard = false;
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
                ImageLevel.Add(MinerList[MinerList.Count - 1].transform.Find("ImageLevel").gameObject);
            }
        }
        for (int i = 0; i < 110; i++)
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
    // Update is called once per frame
    private void OnDisable()
    {
        OwnCardBG.SetActive(true);
        BtnClose.SetActive(true);
        BtnCompose.SetActive(true);
        MinerListBG.SetActive(true);
        Effect.SetActive(false);
        BtnClose2.SetActive(false);
        bSelectCard = true;
        UnSelectCard();
        selectNumber = -1;
    }
    void Update () {
		
	}
    public void SelectCard(int i)
    {
        UnSelectCard();
        selectNumber = i;

        MinerClone = (Instantiate(MinerList[i]));

        MinerClone.transform.SetParent(Card1.transform);        
        MinerList[i].SetActive(false);

        Vector2 localScale = MinerClone.transform.localScale;
        localScale.x = 1; localScale.y = 1;
        MinerClone.transform.localScale = localScale;
        localScale.x = 0; localScale.y = 0;
        MinerClone.transform.localPosition = localScale;
        MinerClone.SetActive(true);
        MinerClone.GetComponent<Button>().enabled = false;
        bSelectCard = true;
    }
    public void UnSelectCard()
    {
        if (bSelectCard == true)
        {
            MinerList[selectNumber].SetActive(true);
            Destroy(MinerClone);
            bSelectCard = false;
        }
    }
    public void SelectFreeLvUp()
    {
        if(bSelectCard ==true)
        {
            bSelectCard = false;
            OwnCardBG.SetActive(false);
            BtnClose.SetActive(false);
            BtnCompose.SetActive(false);
            MinerListBG.SetActive(false);
            Effect.SetActive(true);
            BtnClose2.SetActive(true);

            gv.ListHireLevel[selectNumber]++;
            int MinerIndex = selectNumber + 1;
            string strHireLevel = "HireLevel" + MinerIndex;
            PlayerPrefs.SetInt(strHireLevel, gv.ListHireLevel[selectNumber]);
            PlayerPrefs.Save();

            MinerClone.transform.Find("ImageLevel").gameObject.GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[selectNumber] - 1];            
            if (gv.ListHireLevel[selectNumber] >= 7)
            {                
                MinerClone.transform.Find("ImageLevel").transform.Find("TextLevel").gameObject.GetComponent<Text>().text = "Max";
                MinerClone.transform.Find("ImageLevel").transform.Find("TextLevel2").gameObject.GetComponent<Text>().text = "Max";
            }
            else
            {
                MinerClone.transform.Find("ImageLevel").transform.Find("TextLevel").gameObject.GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[selectNumber];
                MinerClone.transform.Find("ImageLevel").transform.Find("TextLevel2").gameObject.GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[selectNumber];
            }            
        }
        else
        {
            MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "레벨업할 광부카드를\n 선택하세요.");
        }
    }
}
