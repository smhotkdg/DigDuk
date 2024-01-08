using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerDrillMouseDown : MonoBehaviour {

    // Use this for initialization    
    public GameObject MainStaus;
    GameObject TextCountObj =null;
    GameObject MineralsObj = null;

    List<GameObject> ListMinerals = new List<GameObject>();
    GlobalVariable gv;
    bool bSplit = false;
    int iMinerNumber = -1;
    float iTime = 0;
    public GameObject MiningAlgorithm;
    MiningAlgorithm myMining;
    bool bStartMinerAnim = false;
    float DefaultSpeed;

    List<Image> PrograssImg = new List<Image>();
    Text TextRemainTime = null;
    bool bMiningComplete = false;
    GameObject ZzImage;
    //List<GameObject> TextMineralCountObj = new List<GameObject>();
    List<Text> TextMineralCount = new List<Text>();
    List<GameObject> MineralsProgass = new List<GameObject>();
    float m_RemainTime = 0;
    bool bStartProgass = false;
    int PrevIndex = -1;
    Vector2 Pos;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
   
        if (tag == "Miner")
        {            
            MineralsObj = this.transform.Find("MineralsObj").gameObject;            
            TextCountObj = this.transform.Find("TextMiningCount").gameObject;
            myMining = MiningAlgorithm.GetComponent<MiningAlgorithm>();
            ZzImage = this.transform.Find("ZzImg").gameObject;
            for (int i=1; i<= 38; i++)
            {
                string Name = "Mineral" + i;
                ListMinerals.Add(MineralsObj.transform.Find(Name).gameObject);
                MineralsProgass.Add(ListMinerals[ListMinerals.Count - 1].transform.Find("Mineral1Prograss").gameObject);
                MineralsProgass[MineralsProgass.Count - 1].SetActive(true);
                PrograssImg.Add(ListMinerals[ListMinerals.Count-1].transform.Find("Mineral1Prograss").GetComponent<Image>());
                TextMineralCount.Add(ListMinerals[ListMinerals.Count - 1].transform.Find("TextTime").GetComponent<Text>());
            }
            
        }        

    }
    void Start () {
		
	}

    int iMineralIndex = -1;
    private void OnEnable()
    {
        bStartMinerAnim = false;
    }
    private void OnDisable()
    {
    }
    public void SetDefaultSpeed()
    {
        DefaultSpeed = gv.ListMiningTime[iMinerNumber - 1];
    }
    private void FixedUpdate()
    {
        if (tag == "Miner")
        {           
            if (bSplit == false)
            {
                iMinerNumber = SplitName(this.name);
                DefaultSpeed = gv.ListMiningTime[iMinerNumber - 1];
                bSplit = true;
            }
            if (iMinerNumber > 0 && gv.MiningType[iMinerNumber-1] == 1)
            {
                if (gv.ListCapacityNow[iMinerNumber - 1] < gv.listMaxMinerCapacity[iMinerNumber - 1])
                {
                    ZzImage.SetActive(false);
                    MineralsObj.SetActive(true);
                    if (gv.ListbStartMineralAnim.Count > 0 && iMinerNumber > -1)
                    {
                        if (gv.ListbStartMineralAnim[iMinerNumber - 1] == false)
                        {
                            if (PrevIndex > -1)
                            {
                                for (int i = 0; i < ListMinerals.Count; i++)
                                {
                                    if (ListMinerals[i].activeSelf == true)
                                        ListMinerals[i].SetActive(false);
                                }

                            }
                        }
                        else
                        {
                            if (iMineralIndex > -1)
                            {
                                //for (int i = 0; i < ListMinerals.Count; i++)
                                //{
                                //    if (ListMinerals[i].activeSelf == true)
                                //        ListMinerals[i].SetActive(false);
                                //}
                                //ListMinerals[iMineralIndex].SetActive(true);
                                StartMineralAnim(iMineralIndex);
                            }

                        }
                    }

                    if (iMinerNumber > 0 && gv.bStartMine == true)
                    {
                        //float RemainTime = gv.ListMiningTime[iMinerNumber - 1];
                        if(gv.eachMiningSpeed[iMinerNumber -1] >0)
                        {
                            gv.ListMiningTime[iMinerNumber - 1] = DefaultSpeed;
                            gv.ListMiningTime[iMinerNumber - 1] = gv.ListMiningTime[iMinerNumber - 1]- gv.eachMiningSpeed[iMinerNumber - 1];
                            if (gv.ListMiningTime[iMinerNumber - 1] <= 0)
                                gv.ListMiningTime[iMinerNumber - 1] = 0.5f;
                        }
                        else
                        {
                            gv.ListMiningTime[iMinerNumber - 1] = DefaultSpeed;
                        }
                        m_RemainTime = gv.ListMiningTime[iMinerNumber - 1];
                        if (iTime == 0)
                        {
                            iMineralIndex = myMining.GetMinersIndex();
                            if (bMiningComplete == true)
                            {
                                bMiningComplete = false;

                            }
                            bStartMinerAnim = false;
                        }
                        if (iMineralIndex > -1)
                        {
                            bStartProgass = true;
                            bMiningComplete = true;
                            if (bStartMinerAnim == false)
                            {
                                if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                    StartMineralAnim(iMineralIndex);
                                bStartMinerAnim = true;
                            }
                            iTime += Time.deltaTime;

                            if (m_RemainTime < iTime)
                            {
                                //StartCoroutine("DeleteText");
                                PrograssImg[iMineralIndex].fillAmount = 1;
                                //int Rand = Random.Range(gv.ListMiningMin[iMinerNumber - 1], gv.ListMiningMax[iMinerNumber - 1]);
                                int Rand = gv.ListMiningMax[iMinerNumber - 1];
                                int buffMineral =0;
                                if(gv.eachMiningPower[iMinerNumber-1] >0)
                                {
                                    buffMineral += (int)(Rand * gv.eachMiningPower[iMinerNumber - 1]);
                                }
                                if(gv.MiningBuffPower >0)
                                {
                                    buffMineral += (int)(Rand * gv.MiningBuffPower); 
                                }
                                if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                {

                                    Vector2 vec = new Vector2();
                                    vec = this.transform.localPosition;
                                    vec.x = 0;
                                    vec.y = 25;
                                    TextCountObj.SetActive(false);
                                    TextCountObj.SetActive(true);
                                    TextCountObj.GetComponent<Text>().color = gv.listTextColor[iMineralIndex];
                                    TextCountObj.GetComponent<Outline>().effectColor = gv.listTextOutlineColor[iMineralIndex];
                                    TextCountObj.transform.localPosition = vec;            
                                    if(buffMineral >0)
                                    {
                                        TextCountObj.GetComponent<Text>().text = "+ " + Rand.ToString()+ "  + " +buffMineral.ToString();
                                    }
                                    else
                                    {
                                        TextCountObj.GetComponent<Text>().text = "+ " + Rand.ToString();
                                    }
                                    
                                }

                                //gv.listOwnMinerals[iMineralIndex] += Rand;
                                int depth = 0;
                                float weight = 1;
                                if (gv.MapType == 1)
                                {
                                    depth = gv.Depth;
                                }
                                if (gv.MapType == 2)
                                {
                                    depth = gv.DesertDepth;

                                    weight = 5;
                                }
                                if (gv.MapType == 3)
                                {
                                    depth = gv.IceDepth;
                                    weight = 10;
                                }
                                if (gv.MapType == 4)
                                {
                                    depth = gv.ForestDepth;
                                    weight = 100;
                                }

                                if (buffMineral > 0)
                                {
                                    gv.ListMoney[iMinerNumber - 1] += (Rand * gv.ListCostMinerals[iMineralIndex] * weight) + (buffMineral* gv.ListCostMinerals[iMineralIndex] * weight);
                                }
                                else
                                {
                                    gv.ListMoney[iMinerNumber - 1] += Rand * (gv.ListCostMinerals[iMineralIndex]* weight);
                                }
                                gv.ListCapacityNow[iMinerNumber - 1] += (Rand + buffMineral);
                                float range = 1000;
                                if(gv.HoitStoneBuffPercent >0)
                                {
                                    range = 1000 - (range * gv.HoitStoneBuffPercent);
                                }
                                int randomHoitStone = Random.Range(0, (int)range);
                                if(randomHoitStone <= 3)
                                {
                                    //get HoitStone
                                    Vector2 vec;
                                    vec = this.transform.localPosition;
                                    vec.x = 0;
                                    vec.y = 150;                                    
                                    MainStaus.GetComponent<CoinParticleManager>().HoitStoneStart(vec, MineralsObj.transform);
                                    if(gv.HoitStoneBuffPower >0)
                                    {
                                        gv.HoitStoneCount += (int)gv.HoitStoneBuffPower;
                                    }
                                    else
                                    {
                                        gv.HoitStoneCount++;
                                    }

                                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 17)
                                    {                                        
                                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(17, gv.HoitStoneCount);
                                    }

                                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHoitStoneObj(1);
                                }

                                string MoneyCount = "Money" + iMinerNumber;
                                string strCapacityNow = "Capacity" + iMinerNumber;

                                PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[iMinerNumber-1]);
                                PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[iMinerNumber - 1]);

                                PlayerPrefs.Save();
                                iTime = 0;
                                iMineralIndex = -1;
                                bStartProgass = false;
                            }
                            else
                            {
                                if (iMineralIndex > -1)
                                {
                                    if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                    {
                                        PrograssImg[iMineralIndex].fillAmount = iTime / m_RemainTime;
                                        SetRemainTime(m_RemainTime - (float)iTime);
                                    }
                                }
                            }
                        }
                    }
                }
                else
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(iMinerNumber - 1, false);
                    {
                        ZzImage.SetActive(true);
                        MineralsObj.SetActive(false);
                        Vector2 vec;
                        //gv.MInerspeechObj.SetActive(true);
                        vec = this.transform.localPosition;
                        vec.y -= 180;
                        //gv.MInerspeechObj.transform.localPosition = vec;

                    }
                }
            }
        }
        if (tag == "Robot")
        {

        }
    }  
    private void Update()
    {
        if (iMinerNumber > 0 && gv.bStartMine == true)
        {
            if(gv.ListCapacityNow.Count >0)
            {
                if (gv.ListCapacityNow[iMinerNumber - 1] < gv.listMaxMinerCapacity[iMinerNumber - 1])
                {
                    if (bStartProgass == true)
                    {
                        iTime += Time.deltaTime;
                        if (iMineralIndex > -1)
                        {
                            if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                            {
                                PrograssImg[iMineralIndex].fillAmount = iTime / m_RemainTime;
                                SetRemainTime(m_RemainTime - (float)iTime);
                            }
                        }
                    }
                }

                if (gv.bMinerStatus == true)
                {
                    if(gv.selectNumber >=0)
                    {
                        gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = (float)gv.ListCapacityNow[gv.selectNumber] / (float)gv.listMaxMinerCapacity[gv.selectNumber];
                        if ((float)gv.ListCapacityNow[iMinerNumber - 1] <= 0)
                        {
                            //gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = 0;
                        }
                        gv.MinerCapacityProgassText.GetComponent<Text>().text = gv.ListCapacityNow[gv.selectNumber].ToString() + " / " + gv.listMaxMinerCapacity[gv.selectNumber].ToString();
                        gv.TextBtnMoney.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[gv.selectNumber]);
                    }                
                }
            }
        }
    }


    void StartMineralAnim(int i)
    {
        Vector2 vec = new Vector2();
        if(PrevIndex >-1)
        {
            ListMinerals[PrevIndex].SetActive(false);
        }
        PrevIndex = i;
        

        
        vec = this.transform.localPosition;
     
      
        vec.x = 0;
        
        vec.y = 150;
        ListMinerals[i].SetActive(true);
        ListMinerals[i].transform.localPosition = vec;
        
        TextRemainTime = TextMineralCount[i];

        
    }

    int SplitName(string name)
    {   
        string strTemp = this.name;
        string[] a = strTemp.Split('r');
        int Count = int.Parse(a[1]);
        return Count;
    }

    void SetRemainTime(float iRemainTime)
    {
        if (gv.ListbStartMineralAnim[iMinerNumber-1] == true)
        {
            int seconds = (int)(iRemainTime % 60);
            float fraction = iRemainTime * 1000;
            fraction = (fraction % 1000);
            fraction = fraction / 10;
            if (fraction <= 0)
            {
                fraction = 0;
            }
            string niceTime = string.Format("{0:00}:{1:00}", seconds, fraction);
            if(TextRemainTime !=null)
                TextRemainTime.text = niceTime;
        }
    }
    public void DrillTouch()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(1);
    }
    public void MinerTouch()
    {
        if(tag == "Miner")
        {
            gv.BtnSell.GetComponent<Animator>().SetBool("isSell", false);
            gv.BtnBuff.GetComponent<Animator>().SetBool("isBuff", false);
            gv.strCharacterSelect = this.name;
            int iMinerNumber = SplitName(this.name);
            if (gv.iMinerSelectStatus != iMinerNumber)
            {
                gv.TextMiningPower.SetActive(false);
                gv.iMinerSelectStatus = iMinerNumber;
                gv.selectNumber = iMinerNumber - 1;


                if (gv.MiningType[gv.selectNumber] == 1)
                {
                    gv.BtnSell.SetActive(true);
                    gv.BtnBuff.SetActive(true);
                    gv.MinerCapacityProgassBack.SetActive(true);
                }
                else if (gv.MiningType[gv.selectNumber] == 0)
                {
                    gv.BtnSell.SetActive(false);
                    gv.BtnBuff.SetActive(false);
                    gv.MinerCapacityProgassBack.SetActive(false);
                }

                if (gv.SaleBuffPower > 0 || gv.eachSellPower[gv.selectNumber] > 0)
                {
                    gv.TextMiningPower.SetActive(true);                    
                    gv.TextMiningPower.GetComponent<Text>().text = "x " + (gv.SaleBuffPower + gv.eachSellPower[gv.selectNumber]).ToString("N0");
                    
                }
                gv.MinerStatusViewObj.SetActive(true);


                int HomeIndex = 1;
                for (int i = 0; i <= 7; i++)
                {
                    if (i < 4)
                        gv.listMinerHomeIndex[i].SetActive(false);
                    //if (i < 7)
                    //gv.listMinerStatusRibbon[i].SetActive(false);
                    if (i < 7)
                        gv.listMinerStatusLv[i].SetActive(false);
                }
                for (int i = 0; i < gv.ListMinerClass.Count; i++)
                {
                    if (gv.ListMinerClass[i].m_position == iMinerNumber)
                    {
                        HomeIndex = gv.ListMinerClass[i].m_home;
                    }
                }
                int grade = gv.listMinerGrade[iMinerNumber - 1];

                if (HomeIndex > 1)
                    gv.listMinerHomeIndex[HomeIndex - 1].SetActive(true);
                //gv.listMinerStatusRibbon[grade - 1].SetActive(true);

                //레벨 추가해야됨

                gv.MinerStatusProgass.GetComponent<Image>().fillAmount = (float)gv.ListHireCardOwnCount[iMinerNumber - 1] / 3;

                string strPrgassText = gv.ListHireCardOwnCount[iMinerNumber - 1] + " / 3";


                gv.MinerStatusProgass.transform.Find("TextCount").gameObject.GetComponent<Text>().text = strPrgassText;

                gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = (float)gv.ListCapacityNow[iMinerNumber - 1] / (float)gv.listMaxMinerCapacity[iMinerNumber - 1];
                if ((float)gv.ListCapacityNow[iMinerNumber - 1] <= 0)
                {
                    gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = 0;
                }

                string maxcap = gv.listMaxMinerCapacity[iMinerNumber - 1].ToString("N0");
                string nowcap = gv.ListCapacityNow[iMinerNumber - 1].ToString("N0");

                gv.MinerCapacityProgassText.GetComponent<Text>().text = nowcap + " / " + maxcap;
                gv.TextBtnMoney.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[iMinerNumber - 1]);

                Vector2 vec = new Vector2();
                vec = this.transform.localPosition;
                vec.y -= 180;
                gv.MinerStatusViewObj.transform.localPosition = vec;

                StartCoroutine(StartActiveTrue());


            }

        }
    }
    private void OnMouseDown()
    {
        
        if (tag == "Miner")
        {
            gv.BtnSell.GetComponent<Animator>().SetBool("isSell", false);
            gv.BtnBuff.GetComponent<Animator>().SetBool("isBuff", false);

            int iMinerNumber = SplitName(this.name);
            //for(int i =0; i < gv.ListMinerClass.Count; i++)
            {
             
            }
            
            if (gv.iMinerSelectStatus != iMinerNumber)
            {
                
                gv.TextMiningPower.SetActive(false);
                gv.iMinerSelectStatus = iMinerNumber;
                gv.selectNumber = iMinerNumber - 1;


                if (gv.MiningType[gv.selectNumber] == 1)
                {
                    gv.BtnSell.SetActive(true);
                    gv.BtnBuff.SetActive(true);
                }
                else if (gv.MiningType[gv.selectNumber] == 0)
                {
                    gv.BtnSell.SetActive(false);
                    gv.BtnBuff.SetActive(false);
                }

                if (gv.SaleBuffPower > 0 || gv.eachSellPower[gv.selectNumber] > 0)
                {
                    gv.TextMiningPower.SetActive(true);
                    gv.TextMiningPower.GetComponent<Text>().text = "x " + (gv.SaleBuffPower + gv.eachSellPower[gv.selectNumber]) ;
                }
                gv.MinerStatusViewObj.SetActive(true);


                int HomeIndex = 1;
                for (int i = 0; i <= 7; i++)
                {
                    if (i < 4)
                        gv.listMinerHomeIndex[i].SetActive(false);
                    //if (i < 7)
                    //gv.listMinerStatusRibbon[i].SetActive(false);
                    if (i < 7)
                        gv.listMinerStatusLv[i].SetActive(false);
                }
                for (int i = 0; i < gv.ListMinerClass.Count; i++)
                {
                    if (gv.ListMinerClass[i].m_position == iMinerNumber)
                    {
                        HomeIndex = gv.ListMinerClass[i].m_home;
                    }
                }
                int grade = gv.listMinerGrade[iMinerNumber - 1];
                
                if (HomeIndex > 1)
                    gv.listMinerHomeIndex[HomeIndex - 1].SetActive(true);
                //gv.listMinerStatusRibbon[grade - 1].SetActive(true);

                //레벨 추가해야됨

                gv.MinerStatusProgass.GetComponent<Image>().fillAmount = (float)gv.ListHireCardOwnCount[iMinerNumber - 1] / 3;

                string strPrgassText = gv.ListHireCardOwnCount[iMinerNumber - 1] + " / 3";


                gv.MinerStatusProgass.transform.Find("TextCount").gameObject.GetComponent<Text>().text = strPrgassText;

                gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = (float)gv.ListCapacityNow[iMinerNumber-1]/(float)gv.listMaxMinerCapacity[iMinerNumber - 1] ;
                if((float)gv.ListCapacityNow[iMinerNumber - 1] <=0)
                {
                    gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = 0;
                }
                gv.MinerCapacityProgassText.GetComponent<Text>().text = gv.ListCapacityNow[iMinerNumber - 1].ToString() + " / " + gv.listMaxMinerCapacity[iMinerNumber - 1].ToString();
                gv.TextBtnMoney.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[iMinerNumber - 1]);

                Vector2 vec = new Vector2();
                vec = this.transform.localPosition;
                vec.y -= 180;
                gv.MinerStatusViewObj.transform.localPosition = vec;

                StartCoroutine(StartActiveTrue());
                
                
            }

        }
        if (tag == "Drill")
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(1);
        }
    }
    IEnumerator StartActiveTrue()
    {
        yield return new WaitForSeconds(0.2f);
        gv.bMinerStatus = true;
    }
    public void SetCollider(bool flag)
    {
        this.GetComponent<BoxCollider2D>().enabled = flag;
    }

    public void StartSkill()
    {
        StartCoroutine(SKillRoutine());
    }
    //맵 이동시 스킬 사용중인 마이너 초기화 해야됨//
    IEnumerator SKillRoutine()
    {
        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetSkillEffect(iMinerNumber - 1, true);
        gv.ListMiningTime[iMinerNumber - 1] = gv.ListMiningTime[iMinerNumber - 1] / 2;
        int skillPower = 0;
        if(gv.SkillRemainTimePower ==0)
        {
            skillPower = 30;
        }
        else
        {
            skillPower = 30+ (int)(30 * gv.SkillRemainTimePower);
        }
        yield return new WaitForSeconds(skillPower);
        gv.ListMiningTime[iMinerNumber - 1] = gv.ListMiningTime[iMinerNumber - 1] * 2;
        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetSpeedEnd(iMinerNumber-1, 1);
        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetSkillEffect(iMinerNumber - 1, false);
    }
}
