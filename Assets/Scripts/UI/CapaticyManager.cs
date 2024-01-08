using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CapaticyManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusCanvas;
    public GameObject ScrollMineral;
    public GameObject CapacityNowObj;
    public GameObject CapacityBuyObj;

    public Text CapSize;
    public Image ShopCanvasFillImage;
    public Text FillPercent;
    public Text FillPercent1;
    public Text FillText;
    public Text FillText1;
    GlobalVariable gv;

    List<GameObject> listCapacityNow = new List<GameObject>();
    List<GameObject> listCapacityBuy = new List<GameObject>();
    List<GameObject> listMinerals = new List<GameObject>();
    int nCount = 1;

    List<Text> listTextOwnMineral = new List<Text>();
    List<Text> listCostMineral = new List<Text>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start() {
        initData();
    }
    public void initData()
    {
        listCapacityNow.Clear();
        listCapacityBuy.Clear();
        listMinerals.Clear();
        listTextOwnMineral.Clear();
        listCostMineral.Clear();
        for (int i = 1; i <= 18; i++)
        {
            string cap = "Capacity" + i;
            string Mineral = "Mineral" + i;
            if (i < 18)
            {
                listCapacityNow.Add(CapacityNowObj.transform.Find(cap).gameObject);
                listCapacityBuy.Add(CapacityBuyObj.transform.Find(cap).gameObject);
            }
            else
            {
                listCapacityNow.Add(CapacityNowObj.transform.Find(cap).gameObject);
            }
            listMinerals.Add(ScrollMineral.transform.Find(Mineral).gameObject);
            listTextOwnMineral.Add(listMinerals[listMinerals.Count - 1].transform.Find("TextDepthMineral").gameObject.GetComponent<Text>());
            //listCostMineral.Add(listMinerals[listMinerals.Count - 1].transform.Find("BtnMineral").gameObject.transform.Find("TextMineralCost").gameObject.GetComponent<Text>());
        }
        
        InitViewSetting();
        CapSize.text = gv.GetThousandCommaText(gv.listMaxCapacity[gv.iCapacityIndex+1]);
        SetMineralView();
    }
    void InitViewSetting()
    {
        for(int i=0; i< listCapacityNow.Count;i++ )
        {
            if(i == gv.iCapacityIndex)
            {
                listCapacityNow[i].SetActive(true);
                if (i < listCapacityBuy.Count)
                    listCapacityBuy[i].SetActive(true);
            }
            else
            {
                listCapacityNow[i].SetActive(false);
                if(i < listCapacityBuy.Count)
                    listCapacityBuy[i].SetActive(false);
            }
        }

        for(int i=1; i< listMinerals.Count; i++)
        {
            UnSetView(i);
        }

          
    }

    public void SellMineral(int number)
    {
        if(gv.listOwnMinerals[number-1] >0)
        {
            //gv.Money += gv.ListCostMinerals[number - 1] * gv.listOwnMinerals[number - 1];
            
            gv.CapacityNow -= gv.listOwnMinerals[number - 1];
            

            PlayerPrefs.SetFloat("CapacityNow", (float)gv.CapacityNow);
            PlayerPrefs.Save();
            //GameObject.Find("StatusCanvas").GetComponent<StatusUpdate>().SetMoney();
            MainStatusCanvas.GetComponent<CoinParticleManager>().StartCoinParticle(5, listMinerals[number - 1].transform.localPosition, number);

        }
        
    }


    public void EndCanvas()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressSellCanvas(2);
    }
    public void SetMineralView()
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

        nCount = 1;
        if (listMinerals.Count> 0)
        {
            for (int i = 1; i <= deptIndex; i++)
            {
                if (i == 2) { SetView(1); nCount++; }
                if (i == 3) { SetView(2); nCount++; }
                if (i == 4) { SetView(3); nCount++; }
                if (i == 5) { SetView(4); nCount++; }
                if (i == 7) { SetView(5); nCount++; }
                if (i == 10) { SetView(6); nCount++; }
                if (i == 12) { SetView(7); nCount++; }
                if (i == 14) { SetView(8); nCount++; }
                if (i == 17) { SetView(9); nCount++; }
                if (i == 20) { SetView(10); nCount++; }
                if (i == 24) { SetView(11); nCount++; }
                if (i == 28) { SetView(12); nCount++; }
                if (i == 32) { SetView(13); nCount++; }
                if (i == 36) { SetView(14); nCount++; }
                if (i == 40) { SetView(15); nCount++; }
                if (i == 42) { SetView(16); nCount++; }
                if (i == 46) { SetView(17); nCount++; }
            }
        }
       
    }

    void SetView(int i)
    {
        //listMinerals[i].transform.Find("BtnMineral").gameObject.SetActive(true);
        listMinerals[i].transform.Find("ImgMinral").gameObject.SetActive(true);
        //listMinerals[i].transform.Find("TextTitleMineral").gameObject.SetActive(true);
        //listMinerals[i].transform.Find("TextTitleMineral1").gameObject.SetActive(true);
        listMinerals[i].transform.Find("TextMineralCost").gameObject.SetActive(true);
        listMinerals[i].transform.Find("TextMineralCost1").gameObject.SetActive(true);
        listMinerals[i].transform.Find("Image").gameObject.SetActive(true);

        listMinerals[i].transform.Find("TextDepthMineral").gameObject.SetActive(true);
        //listMinerals[i].transform.Find("TextDept").gameObject.SetActive(false);
        listMinerals[i].transform.Find("ImgDepth").gameObject.SetActive(false);
    }
    void UnSetView(int i)
    {
        //listMinerals[i].transform.Find("BtnMineral").gameObject.SetActive(true);
        listMinerals[i].transform.Find("ImgMinral").gameObject.SetActive(false);
        //listMinerals[i].transform.Find("TextTitleMineral").gameObject.SetActive(true);
        //listMinerals[i].transform.Find("TextTitleMineral1").gameObject.SetActive(true);
        listMinerals[i].transform.Find("TextMineralCost").gameObject.SetActive(false);
        listMinerals[i].transform.Find("TextMineralCost1").gameObject.SetActive(false);
        listMinerals[i].transform.Find("Image").gameObject.SetActive(false);

        listMinerals[i].transform.Find("TextDepthMineral").gameObject.SetActive(false);
        //listMinerals[i].transform.Find("TextDept").gameObject.SetActive(false);
        listMinerals[i].transform.Find("ImgDepth").gameObject.SetActive(true);
    }
    public void PressBuyCapacity()
    {
        //돈이 어쩌고 많으면 구매완료
        if(gv.listMaxCapacity.Count <= gv.iCapacityIndex)
        {

        }
        else
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(1, "Capacity");

           
        }
    }

    public void BuyCompleteCapacity()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopUpgetEngineCanvas(1);
        GameObject.Find("PopupGetEngineCanvas").GetComponent<PopupGetEngine>().SetCapacity();
        listCapacityNow[gv.iCapacityIndex].SetActive(false);
        listCapacityBuy[gv.iCapacityIndex].SetActive(false);

        if(gv.MapType ==1)
        {
            gv.iCapacityIndex += 1;

            //광물보관함 저장
            PlayerPrefs.SetInt("iCapacityNormalIndex", gv.iCapacityIndex);
            PlayerPrefs.Save();
        }
        if (gv.MapType ==2)
        {
            gv.iCapacityIndex += 1;

            //광물보관함 저장
            PlayerPrefs.SetInt("iCapacityDesertIndex", gv.iCapacityIndex);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.iCapacityIndex += 1;

            //광물보관함 저장
            PlayerPrefs.SetInt("iCapacityIceIndex", gv.iCapacityIndex);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.iCapacityIndex += 1;

            //광물보관함 저장
            PlayerPrefs.SetInt("iCapacityForestIndex", gv.iCapacityIndex);
            PlayerPrefs.Save();
        }


        CapSize.text = gv.GetThousandCommaText(gv.listMaxCapacity[gv.iCapacityIndex + 1]);

        if (gv.iCapacityIndex < listCapacityNow.Count)
            listCapacityNow[gv.iCapacityIndex].SetActive(true);
        if (gv.iCapacityIndex < listCapacityBuy.Count)
            listCapacityBuy[gv.iCapacityIndex].SetActive(true);

        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCraftCanvas(0);
    }
	
	// Update is called once per frame
 
	void Update () {
        if(gv.CapacityNow < gv.listMaxCapacity[gv.iCapacityIndex])
        {
            if (gv.CapacityNow < 0)
                gv.CapacityNow = 0;
            string strCap;
            float percent = (float)gv.CapacityNow / gv.listMaxCapacity[gv.iCapacityIndex];
            strCap = gv.CapacityNow + " / " + gv.GetThousandCommaText(gv.listMaxCapacity[gv.iCapacityIndex]);
            FillText.text = strCap;
            FillPercent.text = Mathf.Round(percent*100).ToString() + " %";

            FillText1.text = strCap;
            FillPercent1.text = Mathf.Round(percent*100).ToString() + " %";

            ShopCanvasFillImage.fillAmount = percent;

            for(int i=0; i< nCount; i++)
            {
                if(listTextOwnMineral.Count>0)
                {
                    if(gv.listOwnMinerals[i] ==0)
                    {
                        listTextOwnMineral[i].text = "0";
                    }
                    else
                    {
                        listTextOwnMineral[i].text = gv.GetThousandCommaText((int)gv.listOwnMinerals[i]);
                    }
                    
                    //listCostMineral[i].text = gv.ChangeMoney(gv.ListCostMinerals[i] * gv.listOwnMinerals[i]);
                }
            
            }
        }
        else
        {
            string strCap;
            strCap = gv.CapacityNow + " / " + gv.GetThousandCommaText(gv.listMaxCapacity[gv.iCapacityIndex]);
            FillText.text = strCap;
            FillPercent.text = "100" + " %";

            FillText1.text = strCap;
            FillPercent1.text = "100" + " %";

            ShopCanvasFillImage.fillAmount = 1;
            for (int i = 0; i < nCount; i++)
            {
                if (gv.listOwnMinerals[i] == 0)
                {
                    listTextOwnMineral[i].text = "0";
                }
                else
                {
                    listTextOwnMineral[i].text = gv.GetThousandCommaText((int)gv.listOwnMinerals[i]);
                }
            }
        }        
	}
}

