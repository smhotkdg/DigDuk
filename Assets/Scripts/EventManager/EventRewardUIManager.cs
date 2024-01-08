using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventRewardUIManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Gold;
    public GameObject BlackCoin;
    public GameObject MinerPotion;
    public GameObject AutoSellPotion;
    public GameObject AutoSellDouublePotion;
    public GameObject DrillPotion;
    public GameObject DrillDoublePotion;
    public GameObject SallBuff;
    public GameObject SallBuffDouble;
    public GameObject ZzangDoublePotion;
    public GameObject AllRandomMiner1;
    public GameObject AllRandomMiner2;
    public GameObject AllRandomMIner3;
    public GameObject UniqueMiner5;
    public GameObject A_SSMiner1;
    public GameObject PlusDepth;
    public GameObject HoitStone;
    public GameObject Sadari;
    public GameObject Lotto;
    public GameObject DesertMapKey;
    public GameObject IceMapKey;
    public GameObject ForestMapKey;

    public GameObject PlusDepthDaily;
    public GameObject FreeLVUp;

    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        if(gv.MapType ==1)
        {
            switch(gv.iSelectDialogue)
            {
                case 0:
                    AutoSellDouublePotion.SetActive(true);
                    gv.AutoSellDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellDoublePotionTotalCount", gv.AutoSellDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 1:
                    Gold.SetActive(true);
                    Gold.transform.Find("Count").gameObject.GetComponent<Text>().text = gv.ChangeMoney(0.000000000000003f);
                    gv.Money += 0.000000000000003f;
                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    DrillDoublePotion.SetActive(true);                    
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 3:
                    AllRandomMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 1;
                    break;
                case 4:
                    gv.DesertKey = 1;
                    string strUpgradeTotalCount = "DesertKey";
                    PlayerPrefs.SetInt(strUpgradeTotalCount, gv.DesertKey);
                    DesertMapKey.SetActive(true);
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("GetKey");
                    break;                                    
                case 6:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
            }
        }
        if (gv.MapType ==2)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    HoitStone.SetActive(true);

                    gv.HoitStoneCount++;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    break;
                case 1:
                    AutoSellPotion.SetActive(true);
                    gv.AutoSellPotionTotalCount++;
                    PlayerPrefs.SetInt("AutoSellPotionTotalCount", gv.AutoSellPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    AllRandomMiner2.SetActive(true);
                    gv.iSelectEventRewardMiner = 2;
                    break;
                case 3:
                    DrillPotion.SetActive(true);
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 4:
                    Gold.SetActive(true);
                    Gold.transform.Find("Count").gameObject.GetComponent<Text>().text = gv.ChangeMoney(0.000001f);
                    gv.Money += 0.000001f;
                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.Save();
                    break;
                case 5:
                    gv.IceKey = 1;
                    string strUpgradeTotalCount = "IceKey";
                    PlayerPrefs.SetInt(strUpgradeTotalCount, gv.IceKey);
                    IceMapKey.SetActive(true);
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("GetKey");
                    break;
                case 6:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
                case 7:
                    DrillDoublePotion.SetActive(true);
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 8:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    ZzangDoublePotion.SetActive(true);
                    gv.ZzangDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("ZzangDoublePotionTotalCount", gv.ZzangDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 1:
                    AllRandomMIner3.SetActive(true);
                    gv.iSelectEventRewardMiner = 3;
                    break;
                case 2:
                    SallBuffDouble.SetActive(true);
                    gv.SalePotionTotalCount++;
                    PlayerPrefs.SetInt("SalePotionTotalCount", gv.SalePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 3:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
                case 4:
                    gv.ForestKey = 1;
                    string strUpgradeTotalCount = "ForestKey";
                    PlayerPrefs.SetInt(strUpgradeTotalCount, gv.ForestKey);
                    ForestMapKey.SetActive(true);
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("GetKey");
                    break;
                case 5:
                    DrillDoublePotion.SetActive(true);
                    gv.DrillDoublePotionTotalCount++;
                    PlayerPrefs.SetInt("DrillDoublePotionTotalCount", gv.DrillDoublePotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 6:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    //매일 렙업 꽁짜
                    FreeLVUp.SetActive(true);
                    break;
                case 1:
                    DrillPotion.SetActive(true);
                    gv.DrillPotionTotalCount++;
                    PlayerPrefs.SetInt("DrillPotionTotalCount", gv.DrillPotionTotalCount);
                    PlayerPrefs.Save();
                    break;
                case 2:
                    AllRandomMIner3.SetActive(true);
                    gv.iSelectEventRewardMiner = 3;
                    break;
                case 3:
                    //한층 파줌
                    //++                    
                    PlusDepth.SetActive(true);
                    gv.iSelectEventRewardMiner = 99;
                    break;
                case 4:
                    //드릴 능력치 +50%
                    PlusDepthDaily.SetActive(true);
                    break;
                case 5:
                    A_SSMiner1.SetActive(true);
                    gv.iSelectEventRewardMiner = 4;
                    break;
                case 6:
                    UniqueMiner5.SetActive(true);
                    gv.iSelectEventRewardMiner = 5;
                    break;
            }
        }
    }
    private void OnDisable()
    {
        IceMapKey.SetActive(false);
        DrillDoublePotion.SetActive(false);
        Gold.SetActive(false);
        BlackCoin.SetActive(false);
        MinerPotion.SetActive(false);
        AutoSellPotion.SetActive(false);
        AutoSellDouublePotion.SetActive(false);
        DrillPotion.SetActive(false);
        SallBuff.SetActive(false);
        SallBuffDouble.SetActive(false);
        ZzangDoublePotion.SetActive(false);
        AllRandomMiner1.SetActive(false);
        AllRandomMiner2.SetActive(false);
        AllRandomMIner3.SetActive(false);
        UniqueMiner5.SetActive(false);
        A_SSMiner1.SetActive(false);
        PlusDepth.SetActive(false);
        HoitStone.SetActive(false);
        Sadari.SetActive(false);
        Lotto.SetActive(false);
        DesertMapKey.SetActive(false);
        ForestMapKey.SetActive(false);

        PlusDepthDaily.SetActive(false);
        FreeLVUp.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
}
