using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GhostGameManager : MonoBehaviour {

    // Use this for initialization
    public Text Money1;
    public GameObject MainStatusObj;

    public List<Button> BtnPercentList;
    public List<Text> BtnPercentTextList;
    public Button CheckBtn;
    public Image CheckImg;

    public Button BtnExit;

    double DealMoney = 0;
    GlobalVariable gv;
    bool bStart = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        
    }
    void Start () {
        
    }
    private void Update()
    {
        if(gv.ParticleCount == 10 && bStart == false)
        {
            bStart = true;
            StartCoroutine("StartButton");
        }
        if(gv.ParticleCount >10)
        {
            gv.ParticleCount = 0;
        }
    }
    IEnumerator StartButton()
    {
        yield return new WaitForSeconds(0.1f);        
        CheckBtn.interactable = true;
        BtnExit.interactable = true;
        Color a;
        a = CheckImg.color;
        a.a = 1f;
        CheckImg.color = a;
        gv.ParticleCount = 0;
        bStart = false;
    }
    public void ReSetMoney()
    {
        //if (gv.GhostLegSplitMoney > 0)
        //{
        //    gv.Money += gv.GhostLegSplitMoney * 10;
        //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
        //    PlayerPrefs.Save();
        //}
        if (gv.GhostLegGamePercentIndex > 0)
        {
            gv.Money += gv.GhostLegGamePercentIndex;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
        gv.GhostLegGamePercentIndex = -1;
        gv.GhostLegSplitMoney = -1;
    }
    public void DefaultGameSetting()
    {
        for (int i = 0; i < BtnPercentList.Count; i++)
        {
            Color SelectColor = new Color();  
            SelectColor = BtnPercentTextList[i].color;
            SelectColor.a = 1f;
            BtnPercentTextList[i].color = SelectColor;
            BtnPercentTextList[i].color = SelectColor;
            BtnPercentList[i].interactable = true;           
        }
        Money1.text = gv.ChangeMoney(0);
       
    }
    public void SetMoney()
    {
        if(Money1 !=null)
        {
            DealMoney = gv.GhostLegMoney;
            gv.Money = gv.Money - gv.GhostLegMoney;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
    }
    public void DealPercent(int number)
    {
        // 0 //1 //2
        //if (gv.GhostLegSplitMoney > 0)
        if(gv.GhostLegGamePercentIndex >0)
        {
            gv.Money += gv.GhostLegGamePercentIndex;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
        }
        
        if (gv.Money <= 0)
        {
            MainStatusObj.GetComponent<StatusUpdate>().SetNotification("돈이 부족합니다. !!");
        }
        else
        {
           
            gv.GhostLegGamePercentIndex = 0;
            gv.GhostLegMoney = 0;
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameCoinParticleManager>().StartCoinParticle(10, 5, number);

            CheckBtn.interactable = false;
            BtnExit.interactable = false;
            Color a;
            a = CheckImg.color;
            a.a = 0.5f;
            CheckImg.color = a;


            for (int i = 0; i < BtnPercentList.Count; i++)
            {
                Color SelectColor = new Color();
                if (i == number)
                {
                    SelectColor = BtnPercentTextList[i].color;
                    SelectColor.a = 0.3f;
                    BtnPercentTextList[i].color = SelectColor;
                    BtnPercentTextList[i].color = SelectColor;
                    BtnPercentList[i].interactable = false;
                }
                else
                {

                    SelectColor = BtnPercentTextList[i].color;
                    SelectColor.a = 1f;
                    BtnPercentTextList[i].color = SelectColor;
                    BtnPercentTextList[i].color = SelectColor;
                    BtnPercentList[i].interactable = true;
                }
            }
        }
       
    }
}
