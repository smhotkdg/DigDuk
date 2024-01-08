using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpinWheelGameManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusObj;
    public GameObject BtnExit;
    public GameObject SpinningWheelImg;
    public GameObject MineralsListObj;
    List<GameObject> ListMineralsObj = new List<GameObject>();
    public Text OwnMineralsCnt;
    public Text DealMineralsCnt;

    public Animator StartBtn;
    public Animator SpinAnim;
    public List<Button> BtnPercentList;
    public List<Text> TextPercentList;
    GlobalVariable gv;
    bool bStartUpdate = false;
    public Text ResultX;
    public Text ResultMinerals;
    public GameObject MineralsList;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitImg();
        
    }
	
    void InitImg()
    {
        for(int i=1; i <= 18; i++)
        {
            string MineralsName = "Image_SelectedMineral" + i;
            ListMineralsObj.Add(MineralsListObj.transform.Find(MineralsName).gameObject);
        }
    }
    // Update is called once per frame
    void Update () {
		if(selectMineralNum >-1 && bStartUpdate == true)
        {
            if (gv.listOwnMinerals[selectMineralNum] <= 0)
            {
                OwnMineralsCnt.text = "0";
            }
            else
            {
                OwnMineralsCnt.text = gv.GetThousandCommaText(gv.listOwnMinerals[selectMineralNum]);
            }

            if(SelectDealCount >0)
            {
                if (SelectDealCount == 1)
                {
                    DealMinCount = (int)gv.listOwnMinerals[selectMineralNum] / 3;
                }
                if (SelectDealCount == 2)
                {
                    DealMinCount = (int)gv.listOwnMinerals[selectMineralNum] / 2;
                }
                if (SelectDealCount == 3)
                {
                    DealMinCount = (int)gv.listOwnMinerals[selectMineralNum];
                }
                DealMineralsCnt.text = gv.GetThousandCommaText(DealMinCount);
            }
        }
	}
    public void StartUpdate(bool flag)
    {
        bStartUpdate = flag;
    }
    public void ResetGame()
    {
        if(selectMineralNum >-1)
        {
            int index = selectMineralNum + 1;
            string Mineral = "Mineral" + index;
            MineralsList.transform.Find(Mineral).gameObject.SetActive(false);
        } 
        ResultX.text = "";
        for (int i = 0; i < 18; i++)
        {
            if (ListMineralsObj[i].activeSelf == true)
            {
                ListMineralsObj[i].SetActive(false);
            }
        }
        Color SelectColor;
        for (int k = 0; k < BtnPercentList.Count; k++)
        {
            SelectColor = BtnPercentList[k].GetComponent<Image>().color;
            SelectColor.a = 1f;
            BtnPercentList[k].GetComponent<Image>().color = SelectColor;
            BtnPercentList[k].GetComponent<Image>().color = SelectColor;
            BtnPercentList[k].GetComponent<Button>().interactable = true;
            SelectColor = TextPercentList[k].color;
            SelectColor.a = 1f;
            TextPercentList[k].color = SelectColor;
        }

        SpinSpeed = 20f;
        DealMineralsCnt.text = "";
        OwnMineralsCnt.text = "";
        selectMineralNum = -1;
        SelectDealCount = -1;
        DealMinCount = -1;
        StartBtn.SetBool("isSpin", false);
        SpinAnim.SetBool("isSpin", false);
        BtnExit.GetComponent<Button>().interactable = true;

        Quaternion vec = SpinningWheelImg.transform.localRotation;
        vec.z = 0;
        SpinningWheelImg.transform.localRotation = vec;
    }
    public void ResultGame()
    {
        
        int index = selectMineralNum + 1;
        string Mineral = "Mineral" + index;
        MineralsList.transform.Find(Mineral).gameObject.SetActive(true);
        if(resultNum ==1 || resultNum ==2)
        {   
            gv.listOwnMinerals[selectMineralNum] -= DealMinCount;
            gv.CapacityNow -= DealMinCount;

            
            
            PlayerPrefs.SetFloat("CapacityNow", (float)gv.CapacityNow);
            PlayerPrefs.SetFloat(Mineral, (float)gv.listOwnMinerals[selectMineralNum]);
            PlayerPrefs.Save();


            ResultMinerals.text = "";// gv.GetThousandCommaText(gv.listOwnMinerals[selectMineralNum]);
            StartCoroutine(MoneySetting(DealMinCount, -(DealMinCount * 0.025f)));
        }
        if(resultNum ==3)
        {
            ResultMinerals.text = "";// gv.GetThousandCommaText(DealMinCount * 2);
            gv.listOwnMinerals[selectMineralNum] += (DealMinCount *2);
            gv.CapacityNow += DealMinCount * 2;

            PlayerPrefs.SetFloat("CapacityNow", (float)gv.CapacityNow);
            PlayerPrefs.SetFloat(Mineral, (float)gv.listOwnMinerals[selectMineralNum]);
            PlayerPrefs.Save();

            StartCoroutine(MoneySetting(DealMinCount * 2, (DealMinCount * 2) * 0.025f));
        }
        if (resultNum == 4)
        {
            ResultMinerals.text = "";// gv.GetThousandCommaText(DealMinCount * 3);
            gv.listOwnMinerals[selectMineralNum] += (DealMinCount * 3);
            gv.CapacityNow += DealMinCount * 3;

            PlayerPrefs.SetFloat("CapacityNow", (float)gv.CapacityNow);
            PlayerPrefs.SetFloat(Mineral, (float)gv.listOwnMinerals[selectMineralNum]);
            PlayerPrefs.Save();
            StartCoroutine(MoneySetting(DealMinCount * 3, (DealMinCount * 3) * 0.025f));
        }
    }
    
    IEnumerator MoneySetting(int minerals,float p)
    {
        float percent = p;
        yield return new WaitForSeconds(1.0f);
        for (int i=0; i< 40; i++)
        {
            
            if(p >0)
            {
                ResultMinerals.text = DealMinCount.ToString()+" + " + gv.GetThousandCommaText(p);
                p += percent;
            }
            else
            {
                if(minerals + p <=0)
                {
                    ResultMinerals.text = "";
                }
                ResultMinerals.text = gv.GetThousandCommaText(minerals + p);
                p += percent;
            }
            
            yield return new WaitForSeconds(0.03f); //스코어 올라가는 시간 조절     
        }      
    }

    public void SpinWheelStart()
    {
        if (selectMineralNum == -1)
        {
            MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "광물을 선택 하세요.");
        }
        else if (DealMinCount <=0)
        {
            MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "광물이 부족 합니다.");
        }
        else
        {
            gv.SpinwheelCount++;
            PlayerPrefs.SetInt("SpinwheelCount", gv.SpinwheelCount);
            PlayerPrefs.Save();
            if (gv.SpinwheelCount <= 3)
            {
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("SpinWheelTimer", 21600);
            }
            bStartUpdate = false;
            StartBtn.SetBool("isSpin", true);
            SpinAnim.SetBool("isSpin", true);
            BtnExit.GetComponent<Button>().interactable = false;
            StartCoroutine(SpinWheelRoutine());
            resultNum = Random.Range(1, 5);
            // x0
            if(resultNum == 1 || resultNum ==2)
            {
                //10~ 80
                // 190 ~ 260                
                ResultX.text = "x 0";
                int zeroRand = Random.Range(1, 3);
                if(zeroRand ==1)
                {
                    Margin = Random.Range(3, 88);
                   
                }
                else
                {
                    Margin = Random.Range(183, 277);
                }
            }
            //x2
            if(resultNum ==3)
            {
                // 280 ~ 350                
                ResultX.text = "x 2";
                Margin = Random.Range(273, 357);
            }
            //x4
            if(resultNum ==4)
            {
                //100 ~ 170                
                ResultX.text = "x 3";
                Margin = Random.Range(93, 177);
            }
            
        }
        
    }
    int resultNum = -1;
    int Margin = 0;
    float z = 0;
    float SpinSpeed = 20f;
    IEnumerator SpinWheelRoutine()
    {
        yield return new WaitForSeconds(0.001f);
        Quaternion vec = SpinningWheelImg.transform.localRotation;
        transform.rotation = Quaternion.Slerp(transform.rotation, vec, 5.0f);        
        vec.eulerAngles = new Vector3(0, 0, z);
        z += SpinSpeed;
        
        SpinningWheelImg.transform.localRotation = vec;

        if ((360 * 4) + Margin - z < 720)
        {
            SpinSpeed = 6;
        }

        if ((360 * 4) + Margin -z < 360)
        {
            SpinSpeed = 4;
        }
        if ((360 * 4) + Margin - z < 180)
        {
            SpinSpeed = 2;
        }
        if ((360 * 4) + Margin - z < 90)
        {
            SpinSpeed = 0.8f;
        }
        if ((360 * 4) + Margin - z < 30)
        {
            SpinSpeed = 0.2f;
        }

        if (z <=(360 * 4) + Margin)
        {            
            StartCoroutine(SpinWheelRoutine());         
        }
        else
        {
            BtnExit.GetComponent<Button>().interactable = true;
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().PressSpinWheelResult(1);
            z = 0;
        }
    }
    void EndSpinGame()
    {        
        BtnExit.GetComponent<Button>().interactable = true;
    }
    public void DealMinerals(int iMineral)
    {
        for (int i =0; i < 18; i++)
        {
            if(ListMineralsObj[i].activeSelf == true)
            {
                ListMineralsObj[i].SetActive(false);
            }
        }
        ListMineralsObj[iMineral].SetActive(true);
        if(gv.listOwnMinerals[iMineral] <= 0)
        {
            OwnMineralsCnt.text = "0";
        }
        else
        {
            OwnMineralsCnt.text = gv.GetThousandCommaText(gv.listOwnMinerals[iMineral]);
        }
        
        DealMineralsCnt.text = "";
        selectMineralNum = iMineral;
    }
    int selectMineralNum =-1;
    int DealMinCount = 0;
    int SelectDealCount = -1;
    public void DealPercent(int i)
    {
        //1 30// 2 50 //3 100
        if(bStartUpdate ==true)
        {
            SelectDealCount = i;
            Color SelectColor;
            for (int k = 0; k < BtnPercentList.Count; k++)
            {
                SelectColor = BtnPercentList[k].GetComponent<Image>().color;
                SelectColor.a = 1f;
                BtnPercentList[k].GetComponent<Image>().color = SelectColor;
                BtnPercentList[k].GetComponent<Image>().color = SelectColor;
                BtnPercentList[k].GetComponent<Button>().interactable = true;
                SelectColor = TextPercentList[k].color;
                SelectColor.a = 1f;
                TextPercentList[k].color = SelectColor;
            }

            SelectColor = BtnPercentList[i - 1].GetComponent<Image>().color;
            SelectColor.a = 0.3f;
            BtnPercentList[i - 1].GetComponent<Image>().color = SelectColor;
            BtnPercentList[i - 1].GetComponent<Image>().color = SelectColor;
            BtnPercentList[i - 1].GetComponent<Button>().interactable = false;
            SelectColor = TextPercentList[i - 1].color;
            SelectColor.a = 0.3f;
            TextPercentList[i - 1].color = SelectColor;

            if (selectMineralNum == -1)
            {
                MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "광물을 선택 하세요.");
            }
            else
            {
                if (gv.listOwnMinerals[selectMineralNum] <= 0)
                {
                    MainStatusObj.GetComponent<PopUpManager>().PopupNotice(1, "광물이 부족 합니다.");
                }
                else
                {
                    if (i == 1)
                    {
                        DealMinCount = (int)gv.listOwnMinerals[selectMineralNum] / 3;
                    }
                    if (i == 2)
                    {
                        DealMinCount = (int)gv.listOwnMinerals[selectMineralNum] / 2;
                    }
                    if (i == 3)
                    {
                        DealMinCount = (int)gv.listOwnMinerals[selectMineralNum];
                    }
                    DealMineralsCnt.text = gv.GetThousandCommaText(DealMinCount);
                }
            }

        }
    }
      
}
