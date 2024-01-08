using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KingMineralsGameSrc : MonoBehaviour {

    // Use this for initialization
    public GameObject WinObj;
    public GameObject Loseobj;
    public GameObject RewardBG;
    public GameObject StartPanel;
    public Text MineralEnergyText;
    public GameObject PauseObj;
    public Image FillImage;
    GlobalVariable gv;
    float time = 60;
    public Text TimeText;
    float defaultEnergy;
    public List<GameObject> ParticleList;
    public GameObject MineralsBG;
    public GameObject MinersContent;
    public List<GameObject> MinerPosList;
    List<GameObject> CloneMiner = new List<GameObject>();    
    public List<GameObject> MapList = new List<GameObject>();
    public GameObject TouchText;
    public GameObject BGMinerals;
    public GameObject TextDamage;
    List<GameObject> TextDamageList = new List<GameObject>();
    public GameObject Buffobj;
    public GameObject BuffPowerObj;
    public GameObject BuffSpeedObj;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {
        
    }
    bool bTouch = false;
    public void TouchMineral()
    {
        if(bTouch == false)
        {
            bTouch = true;
            GameObject temp = Instantiate(TextDamage);
            temp.transform.SetParent(TextDamage.transform.parent);
            temp.transform.localScale = TextDamage.transform.localScale;
            temp.transform.localPosition = TextDamage.transform.localPosition;
            temp.SetActive(true);            
            if(gv.kingBuffPower >0)
            {
                float index = 1 + gv.kingBuffPower;
                gv.KingDps += index;
                temp.GetComponent<Text>().text = "-" + index.ToString("N0");
            }
            else
            {
                gv.KingDps += 1;
            }
            TextDamageList.Add(temp);
            TouchText.SetActive(false);
            StartCoroutine(TouchbTrue());
            StartCoroutine(DeleteText());
        }        
    }
    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(TextDamageList[0]);
        TextDamageList.RemoveAt(0);
    }
    IEnumerator TouchbTrue()
    {
        yield return new WaitForSeconds(0.1f);
        bTouch = false;
    }
    public void ViewGame()
    {
        bStartPopup = false;
        StartPanel.SetActive(false);
        //time = 60;
        //string niceTime = FloatToTime(time, "00.00");
        gv.isKingGameStart = 1;
        TimeText.text = time +":00";
        if (gv.kingBuffPower >0 || gv.kingBuffSpeed >0)
        {
            Buffobj.SetActive(true);
            if(gv.kingBuffPower >0)
            {
                BuffPowerObj.SetActive(true);
                BuffPowerObj.GetComponent<Text>().text = "채굴량 x" + gv.kingBuffPower.ToString("N1");

            }
            if(gv.kingBuffSpeed >0)
            {
                BuffSpeedObj.SetActive(true);
                BuffSpeedObj.GetComponent<Text>().text = "채굴속도 -"+gv.kingBuffSpeed.ToString("N1");
            }
        }
        for(int i=0; i< MapList.Count; i++)
        {
            MapList[i].SetActive(false);
        }
        switch(gv.MapType)
        {
            case 1:
                if(gv.KingMineralsStage < 20)
                {
                    MapList[0].SetActive(true);
                }
                else if (gv.KingMineralsStage < 60)
                {
                    MapList[1].SetActive(true);
                }
                else
                {
                    MapList[MapList.Count -1].SetActive(true);
                }
                break;
            case 2:
                if (gv.KingMineralsStage < 20)
                {
                    MapList[2].SetActive(true);
                }
                else if (gv.KingMineralsStage < 60)
                {
                    MapList[3].SetActive(true);
                }
                else
                {
                    MapList[MapList.Count - 1].SetActive(true);
                }
                break;
            case 3:
                if (gv.KingMineralsStage < 20)
                {
                    MapList[4].SetActive(true);
                }
                else if (gv.KingMineralsStage < 60)
                {
                    MapList[5].SetActive(true);
                }
                else
                {
                    MapList[MapList.Count - 1].SetActive(true);
                }
                break;
            case 4:
                if (gv.KingMineralsStage < 20)
                {
                    MapList[6].SetActive(true);
                }
                else if (gv.KingMineralsStage < 60)
                {
                    MapList[7].SetActive(true);
                }
                else
                {
                    MapList[MapList.Count - 1].SetActive(true);
                }
                break;
        }
        FillImage.fillAmount = 1;
        MineralEnergyText.text = gv.NowMineralEnergy.ToString("N0");
        defaultEnergy = gv.NowMineralEnergy;

        //int index = (gv.KingMineralsStage - 1) % 38;
        int index = (gv.KingMineralsStage) / 5;
        index = index + 1;
        string strMinerals = "Mineral" + index;
        MineralsBG.transform.Find(strMinerals).gameObject.SetActive(true);

        StartCoroutine(startRoutine());

    }
    IEnumerator startRoutine()
    {
        yield return new WaitForSeconds(0.3f);
        for (int i = 0; i < ParticleList.Count; i++)
        {
            ParticleList[i].SetActive(true);
            yield return new WaitForSeconds(0.05f);
        }
        yield return new WaitForSeconds(0.1f);
        for (int i = 0; i < 6; i++)
        {            
            int indexMiner = gv.KingMineralMiners[i];
            string strMinername = "Miner" + indexMiner;

            GameObject temp = Instantiate(MinersContent.transform.Find(strMinername).gameObject);
            temp.transform.SetParent(MinerPosList[i].transform);
            temp.transform.localScale = MinersContent.transform.Find(strMinername).gameObject.transform.localScale;
            Vector2 myVec = new Vector2();
            myVec.x = 0; myVec.y = 0;
            temp.transform.localPosition = myVec;
            temp.name = MinersContent.transform.Find(strMinername).gameObject.name;
            temp.SetActive(true);

            temp.GetComponent<Animator>().SetBool("isMine", false);
            CloneMiner.Add(temp);
        }
        StartPanel.SetActive(true);
    }
    public string FloatToTime(float toConvert, string format)
    {
        switch (format)
        {
            case "00.0":
                return string.Format("{0:00}:{1:0}",
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 10) % 10));//miliseconds
                break;
            case "#0.0":
                return string.Format("{0:#0}:{1:0}",
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 10) % 10));//miliseconds
                break;
            case "00.00":
                return string.Format("{0:00}:{1:00}",
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 100) % 100));//miliseconds
                break;
            case "00.000":
                return string.Format("{0:00}:{1:000}",
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                break;
            case "#00.000":
                return string.Format("{0:#00}:{1:000}",
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                break;
            case "#0:00":
                return string.Format("{0:#0}:{1:00}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60);//seconds
                break;
            case "#00:00":
                return string.Format("{0:#00}:{1:00}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60);//seconds
                break;
            case "0:00.0":
                return string.Format("{0:0}:{1:00}.{2:0}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 10) % 10));//miliseconds
                break;
            case "#0:00.0":
                return string.Format("{0:#0}:{1:00}.{2:0}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 10) % 10));//miliseconds
                break;
            case "0:00.00":
                return string.Format("{0:0}:{1:00}.{2:00}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 100) % 100));//miliseconds
                break;
            case "#0:00.00":
                return string.Format("{0:#0}:{1:00}.{2:00}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 100) % 100));//miliseconds
                break;
            case "0:00.000":
                return string.Format("{0:0}:{1:00}.{2:000}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                break;
            case "#0:00.000":
                return string.Format("{0:#0}:{1:00}.{2:000}",
                    Mathf.Floor(toConvert / 60),//minutes
                    Mathf.Floor(toConvert) % 60,//seconds
                    Mathf.Floor((toConvert * 1000) % 1000));//miliseconds
                break;
        }
        return "error";
    }
    // Update is called once per frame
    void Update() {
        if (gv.bStartKingGame == true)
        {
            if (time > 0)
                time -= Time.deltaTime;
            else
            {
                ShowLoseGame();                                
            }
                
            if(time <=0)
            {
                time = 0;
            }
            string niceTime = FloatToTime(time, "00.00");
            TimeText.text = niceTime;

            if (gv.KingDps > 0)
            {
                FillImage.fillAmount = (defaultEnergy - gv.KingDps) / gv.NowMineralEnergy;
            }
            else
            {
                FillImage.fillAmount = 1;
            }
            if (defaultEnergy - gv.KingDps <= 0)
            {
                MineralEnergyText.text = (0).ToString("N0");
                //성공!!!!               
                ShowWinGame();                
            }
            else
            {
                MineralEnergyText.text = (defaultEnergy - gv.KingDps).ToString("N0");
            }
        }
    }
    void SetWinReward()
    {
        SetReward(true);
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralWin");
    }
    void CheckDefaultChip(int type, int chiptype)
    {
        switch (type)
        {
            //칩셋
            case 1:
                if (chiptype != 0)
                {
                    gv.RewardKingMineralsChip2 = 0;
                }
                else
                {
                    gv.RewardKingMineralsChip1 = 0;
                    
                }
                break;
            //호잇스톤
            case 2:
                gv.RewardKingMineralsHoitstone = 1;
                break;
        }
    }
    string GetRewardCount(int type, int chiptype = 0)
    {        
        string strReward = string.Empty;
        //int defaultValue = gv.KingMineralsStage / 11;
        int defaultValue = 10;
        //defaultValue += 1;
        //defaultValue = defaultValue * 10;
        defaultValue = 10;
        switch (gv.MapType)
        {
            case 1:
                if (gv.KingMineralStageNormal > gv.KingMineralsStage)
                {
                    CheckDefaultChip(type, chiptype);
                    if(type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
            case 2:
                if (gv.KingMineralStageDesert > gv.KingMineralsStage )
                {
                    CheckDefaultChip(type, chiptype);                    
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
            case 3:
                if (gv.KingMineralStageIce > gv.KingMineralsStage )
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
            case 4:
                if (gv.KingMineralStageForest > gv.KingMineralsStage )
                {
                    CheckDefaultChip(type, chiptype);
                    if (type == 2)
                    {
                        strReward = 1.ToString("N0");
                    }
                    else
                    {
                        strReward = 0.ToString("N0");
                    }
                    return strReward;
                }
                break;
        }
        switch (type)
        {
            //칩셋
            case 1:
                if (chiptype != 0)
                {
                    gv.RewardKingMineralsChip2 = 10;
                    strReward = gv.RewardKingMineralsChip2.ToString("N0");
                }
                else
                {
                    gv.RewardKingMineralsChip1 = 10;
                    strReward = gv.RewardKingMineralsChip1.ToString("N0");
                }
                break;
            //호잇스톤
            case 2:
                gv.RewardKingMineralsHoitstone = 2;
                strReward = gv.RewardKingMineralsHoitstone.ToString("N0");
                break;
        }

        return strReward;
    }
    void SetReward(bool flag)
    {        
        switch (gv.MapType)
        {
            case 1:
                RewardBG.transform.Find("Reward1").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward1").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 2:
                RewardBG.transform.Find("Reward1").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward2").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward1").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward2").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1, 2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 3:
                RewardBG.transform.Find("Reward2").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward3").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward2").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward3").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1, 2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
            case 4:
                RewardBG.transform.Find("Reward3").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward4").gameObject.SetActive(flag);
                RewardBG.transform.Find("Reward5").gameObject.SetActive(flag);
                if (flag == true)
                {
                    RewardBG.transform.Find("Reward3").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1);
                    RewardBG.transform.Find("Reward4").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(1, 2);
                    RewardBG.transform.Find("Reward5").gameObject.transform.Find("TextReward").GetComponent<Text>().text = GetRewardCount(2);
                }
                break;
        }
    }
    void SetKingGameFlag(bool flag)
    {
        gv.bStartKingGame = flag;        
    }
    public void ShowLoseGame()
    {
        //게임 패배창
        SetKingGameFlag(false);
        Loseobj.SetActive(true);
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("BGKingMineralLose");
        //패배~!~!~!~!
    }
    public void ShowWinGame()
    {
        //게임 승리창
        SetKingGameFlag(false);

        //보상 획득!!

        //
        switch(gv.MapType)
        {
            case 1:
                gv.Semiconductor1 += 10;
                gv.HoitStoneCount += 2;
                PlayerPrefs.SetInt("Semiconductor1", gv.Semiconductor1);
                PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                break;
            case 2:
                gv.Semiconductor1 += 10;
                gv.Semiconductor2 += 10;
                gv.HoitStoneCount += 2;
                PlayerPrefs.SetInt("Semiconductor1", gv.Semiconductor1);
                PlayerPrefs.SetInt("Semiconductor2", gv.Semiconductor1);
                PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                break;
            case 3:
                gv.Semiconductor2 += 10;
                gv.Semiconductor3 += 10;
                gv.HoitStoneCount += 2;
                PlayerPrefs.SetInt("Semiconductor2", gv.Semiconductor1);
                PlayerPrefs.SetInt("Semiconductor3", gv.Semiconductor1);
                PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                break;
            case 4:
                gv.Semiconductor3 += 10;
                gv.Semiconductor4 += 10;
                gv.HoitStoneCount += 2;
                PlayerPrefs.SetInt("Semiconductor3", gv.Semiconductor1);
                PlayerPrefs.SetInt("Semiconductor4", gv.Semiconductor1);
                PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                break;
        }
        gv.RewardKingMineralsChip1 = 0;
        gv.RewardKingMineralsChip2 = 0;
        gv.RewardKingMineralsHoitstone = 0;
        PlayerPrefs.Save();
        WinObj.SetActive(true);
        SetWinReward();

        switch (gv.MapType)
        {
            case 1:
                if (gv.KingMineralStageNormal > gv.KingMineralsStage)
                {                    
                }
                else
                {
                    GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().SetLvUp();
                }
                break;
            case 2:
                if (gv.KingMineralStageDesert > gv.KingMineralsStage)
                {                    
                }
                else
                {
                    GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().SetLvUp();
                }
                break;
            case 3:
                if (gv.KingMineralStageIce > gv.KingMineralsStage)
                {                    
                }
                else
                {
                    GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().SetLvUp();
                }
                break;
            case 4:
                if (gv.KingMineralStageForest > gv.KingMineralsStage)
                {                    
                }
                else
                {
                    GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().SetLvUp();
                }
                break;
        }
        
    }

    public void EndGame()
    {
        ExitGame();        
    }
    public void ExitGame()
    {
        Buffobj.SetActive(false);
        BuffPowerObj.SetActive(false);
        BuffSpeedObj.SetActive(false);
        for (int i=0; i < TextDamageList.Count; i++)
        {
            Destroy(TextDamageList[i]);
        }
        TextDamageList.Clear();
        time = 60;
        string niceTime = FloatToTime(time, "00.00");
        TimeText.text = niceTime;
        WinObj.SetActive(false);
        Loseobj.SetActive(false);
        SetReward(false);
        //int index = (gv.KingMineralsStage - 1) % 38;
        int index = (gv.KingMineralsStage) / 5;
        index = index + 1;
        string strMinerals = "Mineral" + index;        
        MineralsBG.transform.Find(strMinerals).gameObject.SetActive(false);

        SetKingGameFlag(false);
        

        for(int i=0; i< CloneMiner.Count; i++)
        {
            Destroy(CloneMiner[i]);
        }
        CloneMiner.Clear();
        gv.DeletePanelPopup("PauseObj");
        PauseObj.SetActive(false);
        TouchText.SetActive(false);
        StartPanel.SetActive(false);
        bStartPopup = false;
        GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().PressKingMineralsGamePanel(0);
        //게임 종료
    }
    public void PressPause()
    {
        SetKingGameFlag(false);
        PauseObj.SetActive(true);
        gv.AddPanelPopup(PauseObj, "PauseObj");        
    }
    bool bStartPopup = false;
    public void StartGame()
    {
        bStartPopup = true;
        StartPanel.SetActive(false);
        TouchText.SetActive(true);
        SetKingGameFlag(true);
    }
    public void ReStartGame()
    {
        gv.DeletePanelPopup("PauseObj");
        PauseObj.SetActive(false);
        if (bStartPopup == true)
        {            
            SetKingGameFlag(true);
        }
    }
}
