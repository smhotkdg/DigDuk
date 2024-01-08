using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RobotMining : MonoBehaviour {

    // Use this for initialization

    public GameObject MiningAlgorithm;
    public GameObject MainStaus;
    GlobalVariable gv;
    float MiningSpeed = 13;
    float MiningPower = 100;
    float MiningAutoSell = 30;
    double MiningMoney = 0;
    int hoitstonePower =0;
    GameObject TextResult;
    MiningAlgorithm myMining;
    List<GameObject> ListMinerals = new List<GameObject>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start() {
        LoadAblityData();
        ButtonInfo = this.transform.Find("BtnInfo").gameObject;
        InitData();
        StartCoroutine(AutuSellRobot(MiningAutoSell));
        //StartCoroutine(Mininig(MiningSpeed));
        float starttime = Random.Range(0.5f, 4f);
        StartCoroutine(StartRobot(starttime));        
    }
    IEnumerator StartRobot(float time)
    {
        yield return new WaitForSeconds(0.1f);
        MiningStart();
    }
    void InitData()
    {
        myMining = MiningAlgorithm.GetComponent<MiningAlgorithm>();
        TextResult = this.transform.Find("TextMiningCount").gameObject;
        GameObject MineralsObj = this.transform.Find("MineralsObj").gameObject;
        for (int i = 1; i <= 38; i++)
        {
            string strMineral = "Mineral" + i;
            ListMinerals.Add(MineralsObj.transform.Find(strMineral).gameObject);
        }
    }
    IEnumerator AutuSellRobot(float time)
    {
        yield return new WaitForSeconds(time);
        //여기서 자동판매 쇽쇽        
        if(MiningMoney >0)
        {
            GameObject.Find("MainCanvas").GetComponent<MineralSellManager>().SellMineralRobot(this.gameObject, (float)MiningMoney);
        }
        MiningMoney = 0;
        StartCoroutine(AutuSellRobot(MiningAutoSell));
    }
    int iMineralIndex;
    bool bStartMining = false;
    Image PrograssImg;
    Text TextRemainTime;
    float iTime = 0;
    GameObject ButtonInfo;
    void SetObj()
    {
        for (int i = 0; i < ListMinerals.Count; i++)
        {
            if (ListMinerals[i].activeSelf == true)
                ListMinerals[i].SetActive(false);
        }
        Vector2 vec = new Vector2();
        vec = this.transform.localPosition;
        vec.x = 0;
        vec.y = 0;
        ListMinerals[iMineralIndex].transform.localPosition = vec;
        ListMinerals[iMineralIndex].SetActive(true);        
        PrograssImg = ListMinerals[iMineralIndex].transform.Find("Mineral1Prograss").gameObject.GetComponent<Image>();
        TextRemainTime = ListMinerals[iMineralIndex].transform.Find("TextTime").gameObject.GetComponent<Text>();        
    }
    void MiningStart()
    {        
        iMineralIndex = myMining.GetMinersIndex();
        SetObj();
        StartCoroutine(startMiningRoutine());
    }
    IEnumerator startMiningRoutine()
    {
        yield return new WaitForSeconds(0.1f);
        iTime = 0;
        bStartMining = true;
    }
    // Update is called once per frame
    void Update()
    {
        if (bStartMining == true)
        {
            iTime += Time.deltaTime;
            PrograssImg.fillAmount = iTime / MiningSpeed;
            SetRemainTime(MiningSpeed - (float)iTime);
        }
    }
    void EndMining()
    {
        //여기서 돈주기

        float range = 1000;
        if (gv.HoitStoneBuffPercent > 0)
        {
            range = 1000 - (range * gv.HoitStoneBuffPercent);
        }
        int randomHoitStone = Random.Range(0, (int)range);
        if (randomHoitStone <= 3)
        {
            //get HoitStone
            GameObject MineralsObj = this.transform.Find("MineralsObj").gameObject;
            Vector2 vec;
            vec = this.transform.localPosition;
            vec.x = 0;
            vec.y = 150;
            MainStaus.GetComponent<CoinParticleManager>().HoitStoneStart(vec, MineralsObj.transform);
            if (gv.HoitStoneBuffPower > 0)
            {
                gv.HoitStoneCount += ((int)gv.HoitStoneBuffPower + hoitstonePower);
            }            
            else
            {
                gv.HoitStoneCount += (1+ hoitstonePower);
            }
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 17)
            {
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(17, gv.HoitStoneCount);
            }
            PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressHoitStoneObj(1);
        }
        if (gv.MiningBuffPower > 0)
        {
            MiningMoney += (gv.ListCostMinerals[iMineralIndex] * (MiningPower * gv.MiningBuffPower));
        }
        else
        {
            MiningMoney += (gv.ListCostMinerals[iMineralIndex] * MiningPower) ;
        }
        
        TextResult.SetActive(false);
        TextResult.SetActive(true);
        TextResult.GetComponent<Text>().color = gv.listTextColor[iMineralIndex];
        TextResult.GetComponent<Outline>().effectColor = gv.listTextOutlineColor[iMineralIndex];        
        if (gv.MiningBuffPower > 0)
        {
            TextResult.GetComponent<Text>().text = "+ " + MiningPower.ToString() + "  + " + (MiningPower * gv.MiningBuffPower).ToString("N0");
        }
        else
        {
            TextResult.GetComponent<Text>().text = "+ " + MiningPower.ToString("N0");
        }        
        StartCoroutine(EndMiningRoutine());
    }
    IEnumerator EndMiningRoutine()
    {
        yield return new WaitForSeconds(0.1f);        
        MiningStart();
    }
    void SetRemainTime(float iRemainTime)
    {        
        if(bStartMining == true)
        {
            int seconds = (int)(iRemainTime % 60);
            float fraction = iRemainTime * 1000;
            fraction = (fraction % 1000);
            fraction = fraction / 10;
            if (fraction <= 0)
            {
                bStartMining = false;
                fraction = 0;
                EndMining();
            }
            string niceTime = string.Format("{0:00}:{1:00}", seconds, fraction);
            if (TextRemainTime != null)
                TextRemainTime.text = niceTime;

        }
    }
    bool bClick = false;
    int SplicName(string name)
    {
        string strTemp = this.name;
        string[] a = strTemp.Split('.');
        int Count = int.Parse(a[1]);
        return Count;
    }
    public void MinerClick()
    {
        GameObject.Find("MainCanvas").GetComponent<HireSettingController>().UnsetInfoBtn();
        if (bClick ==false)
        {
            gv.SelectRobotIndex = SplicName(this.name);
            Debug.Log(gv.SelectRobotIndex);
            ButtonInfo.SetActive(true);
            bClick = true;
            gv.bMinerStatus = true;
        }
        else
        {
            gv.SelectRobotIndex = 0;
            ButtonInfo.SetActive(false);
            bClick = false;
            gv.bMinerStatus = false;
        }
    }
    public void UnSetInfo()
    {
        if(ButtonInfo!=null)
        {            
            ButtonInfo.SetActive(false);
            bClick = false;
            gv.bMinerStatus = false;
        }  
    }
    float iSpeacialAblity1 = 0;
    float iSpeacialAblity2 = 0;
    float iSpeacialAblity3 = 0;

    int SpeacialAblity_Type1 = 0;
    int SpeacialAblity_Type2 = 0;
    int SpeacialAblity_Type3 = 0;

    void LoadAblityData()
    {
        string mapType = string.Empty;
        switch (gv.MapType)
        {
            case 1:
                mapType = "Normal";
                break;
            case 2:
                mapType = "Desert";
                break;
            case 3:
                mapType = "Ice";
                break;
            case 4:
                mapType = "Forest";
                break;
        }
        int index = SplicName(this.name);

        string SaveName = string.Empty;

        SaveName = mapType + "SpeacialAblity_Type1" + index;
        SpeacialAblity_Type1 = PlayerPrefs.GetInt(SaveName);

        SaveName = mapType + "iSpeacialAblity1" + index;
        iSpeacialAblity1 = PlayerPrefs.GetFloat(SaveName);

        SaveName = mapType + "SpeacialAblity_Type2" + index;
        SpeacialAblity_Type2 = PlayerPrefs.GetInt(SaveName);

        SaveName = mapType + "iSpeacialAblity2" + index;
        iSpeacialAblity2 = PlayerPrefs.GetFloat(SaveName);

        SaveName = mapType + "SpeacialAblity_Type3" + index;
        SpeacialAblity_Type3 = PlayerPrefs.GetInt(SaveName);

        SaveName = mapType + "iSpeacialAblity3" + index;
        iSpeacialAblity3 = PlayerPrefs.GetFloat(SaveName);

        if (SpeacialAblity_Type1 > 0)
            SetAblityType(SpeacialAblity_Type1, iSpeacialAblity1);
        if (SpeacialAblity_Type2 > 0)
            SetAblityType(SpeacialAblity_Type2, iSpeacialAblity2);
        if (SpeacialAblity_Type3 > 0)
            SetAblityType(SpeacialAblity_Type3, iSpeacialAblity3);
    }

    int SetAblityType(int type, float ablity)
    {
        switch (type)
        {
            //채굴속도
            case 1:
                MiningSpeed -= ablity;
                if(MiningSpeed <0.5f)
                {
                    MiningSpeed = 0.5f;
                }
                return 1;
                break;
            //채굴량
            case 2:
                MiningPower += ablity;
                return 2;
                break;
            //자동판매시간 감소
            case 3:
                MiningAutoSell -= ablity;
                if(MiningPower <1)
                {
                    MiningPower = 1;
                }
                return 3;
                break;
            //드릴파워증가
            case 4:
                gv.DrillBuffPower += ablity;
                return 4;
                break;
            //전체판매증가
            case 5:
                gv.SaleBuffPower += ablity;
                return 5;
                break;
            //호잇스톤 채굴량
            case 6:
                hoitstonePower += (int)ablity;
                return 6;
                break;
        }
        return 0;
    }
    void CheckAblity(int type,string mapType,float RandomAblitlyPower)
    {
        string SaveName = string.Empty;
        int index = SplicName(this.name);
        if (SpeacialAblity_Type1 ==0)
        {
            SpeacialAblity_Type1 = type;
            SaveName = mapType + "SpeacialAblity_Type1"+ index;
            PlayerPrefs.SetInt(SaveName, SpeacialAblity_Type1);

            iSpeacialAblity1 = Mathf.Round(RandomAblitlyPower*10) *0.1f;
            SaveName = mapType + "iSpeacialAblity1" + index;
            PlayerPrefs.SetFloat(SaveName, iSpeacialAblity1);
        }
        else if(SpeacialAblity_Type2 == 0)
        {
            SpeacialAblity_Type2 = type;
            SaveName = mapType + "SpeacialAblity_Type2" + index;
            PlayerPrefs.SetInt(SaveName, SpeacialAblity_Type2);

            iSpeacialAblity2 = Mathf.Round(RandomAblitlyPower*10) * 0.1f;
            SaveName = mapType + "iSpeacialAblity2" + index;
            PlayerPrefs.SetFloat(SaveName, iSpeacialAblity2);
        }
        else if(SpeacialAblity_Type3 ==0)
        {
            SpeacialAblity_Type3 = type;
            SaveName = mapType + "SpeacialAblity_Type3" + index;
            PlayerPrefs.SetInt(SaveName, SpeacialAblity_Type3);

            iSpeacialAblity3 = Mathf.Round(RandomAblitlyPower*10)*0.1f;
            SaveName = mapType + "iSpeacialAblity3" + index;
            PlayerPrefs.SetFloat(SaveName, iSpeacialAblity3);
        }
        else
        {
            return;
        }
    }

    public float GetTypeOfAblityPower1()
    {
        return iSpeacialAblity1;
    }
    public float GetTypeOfAblityPower2()
    {
        return iSpeacialAblity2;
    }
    public float GetTypeOfAblityPower3()
    {
        return iSpeacialAblity3;
    }

    public int GetTypeOfAblity1()
    {
        return SpeacialAblity_Type1;
    }
    public int GetTypeOfAblity2()
    {
        return SpeacialAblity_Type2;
    }
    public int GetTypeOfAblity3()
    {
        return SpeacialAblity_Type3;
    }
    public static int RATIO_CHANCE_DRILL = 5;
    public static int RATIO_CHANCE_SELL = 8;
    public static int RATIO_CHANCE_HOITSTONE = 12;
    public static int RATIO_CHANCE_SPEED = 25;
    public static int RATIO_CHANCE_AMOUNT = 25;
    public static int RATIO_CHANCE_AUTOSELL = 25;
    public static int TOTAL_RATIO = RATIO_CHANCE_DRILL + RATIO_CHANCE_SELL + RATIO_CHANCE_HOITSTONE + RATIO_CHANCE_SPEED + RATIO_CHANCE_AMOUNT + RATIO_CHANCE_AUTOSELL;
    int GetRandomAblitytype()
    {
        int rand = 0;        
        rand = Random.Range(1, TOTAL_RATIO);


        ////5%
        ////드릴파워
        //if (rand < 50)
        //{
        //    rand = 3;
        //}
        ////8%
        ////전체판매
        //else if (rand < 80)
        //{
        //    rand = 4;
        //}
        ////12%
        ////호잇스톤 채굴량
        //else if (rand < 120)
        //{
        //    rand = 5;
        //}
        ////25%
        ////채굴속도
        //else if (rand < 300)
        //{
        //    rand = 0;
        //}
        ////25%
        ////채굴량
        //else if (rand < 400)
        //{
        //    rand = 1;
        //}      
        //else
        //{
        //    rand = 2;
        //}

        if ((rand -= RATIO_CHANCE_DRILL) < 0)
        {
            rand = 3;
        }
        else if ((rand -= RATIO_CHANCE_SELL) < 0)
        {
            rand = 4;
        }
        else if ((rand -= RATIO_CHANCE_HOITSTONE) < 0)
        {
            rand = 5;
        }
        else if ((rand -= RATIO_CHANCE_SPEED) < 0)
        {
            rand = 0;
        }
        else if ((rand -= RATIO_CHANCE_AMOUNT) < 0)
        {
            rand = 1;
        }
        else if ((rand -= RATIO_CHANCE_AUTOSELL) < 0)
        {
            rand = 2;
        }
        else
        {
            rand = 2;
        }
        return rand;        
    }

    public int GetTypeOfAblity(int index)
    {
        switch(index)
        {
            case 1:
                return SpeacialAblity_Type1;
                break;
            case 2:
                return SpeacialAblity_Type2;
                break;
            case 3:
                return SpeacialAblity_Type3;
                break;
        }
        return -1;
    }
    public float GetTypeOfAblityPower(int index)
    {

        switch (index)
        {
            case 1:
                return iSpeacialAblity1;
                break;
            case 2:
                return iSpeacialAblity2;
                break;
            case 3:
                return iSpeacialAblity3;
                break;
        }
        return -1;
    }
    void DeleteAblity(int type, float ablity)
    {
        switch (type)
        {
            //채굴속도
            case 1:
                MiningSpeed += ablity;                
                break;
            //채굴량
            case 2:
                MiningPower -= ablity;                
                break;
            //자동판매시간 감소
            case 3:
                MiningAutoSell += ablity;                
                break;
            //드릴파워증가
            case 4:
                gv.DrillBuffPower += ablity;                
                break;
            //전체판매증가
            case 5:
                gv.SaleBuffPower -= ablity;                
                break;
            //호잇스톤 채굴량
            case 6:
                hoitstonePower -= (int)ablity;                
                break;
        }        
    }
    public void ResetAblity(int ablityPos)
    {
        switch(ablityPos)
        {
            case 1:
                DeleteAblity(ablityPos, iSpeacialAblity1);
                iSpeacialAblity1 = 0;
                SpeacialAblity_Type1 = 0;
                break;
            case 2:
                DeleteAblity(ablityPos, iSpeacialAblity2);
                iSpeacialAblity2 = 0;
                SpeacialAblity_Type2 = 0;
                break;
            case 3:
                DeleteAblity(ablityPos, iSpeacialAblity3);
                iSpeacialAblity3 = 0;
                SpeacialAblity_Type3 = 0;
                break;
        }
        SetAblity();
    }
    public void SetAblity()
    {
        if (gv.SelectRobotIndex == 0)
            return;

        int rand = GetRandomAblitytype();
        
        string strTypeName = string.Empty;
        string MapStr = string.Empty;
        switch(gv.MapType)
        {
            case 1:
                MapStr = "Normal";
                break;
            case 2:
                MapStr = "Desert";
                break;
            case 3:
                MapStr = "Ice";
                break;
            case 4:
                MapStr = "Forest";
                break;
        }
        float RandomAblitlyPower = 1;
        switch(rand)
        {
            //채굴속도
            case 0:
                RandomAblitlyPower = GetRand(10);
                RandomAblitlyPower  = Mathf.Round((RandomAblitlyPower * 10)) * 0.1f;
                CheckAblity(1, MapStr, RandomAblitlyPower);
                SetAblityType(1, RandomAblitlyPower);
                break;
            //채굴량
            case 1:
                RandomAblitlyPower = Mathf.Round(GetRand(500));                
                CheckAblity(2, MapStr, RandomAblitlyPower);
                SetAblityType(2, RandomAblitlyPower);
                break;
            //자동판매시간 감소
            case 2:
                RandomAblitlyPower = GetRand(15);
                RandomAblitlyPower = Mathf.Round((RandomAblitlyPower * 10)) * 0.1f;
                CheckAblity(3, MapStr, RandomAblitlyPower);
                SetAblityType(3, RandomAblitlyPower);
                break;
            //드릴파워증가
            case 3:
                RandomAblitlyPower = GetRand(7);
                RandomAblitlyPower = Mathf.Round((RandomAblitlyPower * 10)) * 0.1f;
                CheckAblity(4, MapStr, RandomAblitlyPower);
                SetAblityType(4, RandomAblitlyPower);
                break;
            //전체판매증가
            case 4:
                RandomAblitlyPower = GetRand(7);
                RandomAblitlyPower = Mathf.Round((RandomAblitlyPower * 10)) * 0.1f;
                CheckAblity(5, MapStr, RandomAblitlyPower);
                SetAblityType(5, RandomAblitlyPower);
                break;
            //호잇스톤 채굴량
            case 5:                
                RandomAblitlyPower = Mathf.Round(GetRand(30));                
                CheckAblity(6, MapStr, RandomAblitlyPower);
                SetAblityType(6, RandomAblitlyPower);
                break;
        }
    }

    float GetRand(float range)
    {
        float rand = 0;
        float split = range / 10;
        rand = Random.Range(1, 1000);
        //1%
        if (rand < 10)
        {
            rand = Random.Range(split * 9, range);
        }
        //3%
        else if (rand < 30)
        {
            rand = Random.Range(split * 5, split * 9);
        }
        //5%
        else if (rand < 50)
        {
            rand = Random.Range(split * 3, split * 6);
        }
        //10%
        else if (rand < 100)
        {
            rand = Random.Range(split * 2, split * 5);
        }
        //20%
        else if (rand < 200)
        {
            rand = Random.Range(split, split * 3);
        }
        //
        else
        {
            rand = Random.Range(1, split * 2);
        }
        return rand;
    }
}
