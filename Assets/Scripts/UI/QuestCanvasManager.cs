using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class QuestCanvasManager : MonoBehaviour {

    // Use this for initialization
    public GameObject QuestPopup;
    public Text _text;
    public GameObject BlackCoin;
    public GameObject MinerPotion;
    public GameObject Money;
    public GameObject DrillPotion;
    public GameObject MinerCard;
    public GameObject GoodPotion;
    public GameObject WinMark;
    public GameObject LoseMark;
    public GameObject SellPotion;
    public GameObject SellBuffPotion;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnEnable()
    {
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckView();
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(false);
    }
    bool bCard = false;
    public void SetQuesetPopup(int i,string _str,string type)
    {
        if(i==1)
        {
            gv.AddPanelPopup(QuestPopup, "QuestPopup");
            QuestPopup.SetActive(true);
            _text.text = _str;

            if(type == "BlackCoin")
                BlackCoin.SetActive(true);
            if (type == "MinerPotion")
                MinerPotion.SetActive(true);
            if (type == "Money")
                Money.SetActive(true);
            if (type == "DrillPotion")
                DrillPotion.SetActive(true);
            if (type == "MinerCard")
            {
                MinerCard.SetActive(true);
                bCard = true;
            }   
            if (type == "GoodPotion")
                GoodPotion.SetActive(true);
            if (type == "WinMark")
                WinMark.SetActive(true);
            if (type == "LoseMark")
                LoseMark.SetActive(true);
            if (type == "AutoSell")
                SellPotion.SetActive(true);
            if (type == "SellBuff")
                SellBuffPotion.SetActive(true);

        }
        else
        {
            gv.DeletePanelPopup("QuestPopup");
            QuestPopup.SetActive(false);
        }
    }

    public void SetQuesetPopup(int i)
    {
        if (i == 1)
        {
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Open");
            QuestPopup.SetActive(true);
            gv.AddPanelPopup(QuestPopup, "QuestPopup");
        }
        else
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(4);          
            gv.DeletePanelPopup("QuestPopup");
            if (bCard ==true)
            {
                bCard = false;
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCardGetView(1, 3);
            }
            BlackCoin.SetActive(false);
            MinerPotion.SetActive(false);
            Money.SetActive(false);
            DrillPotion.SetActive(false);
            MinerCard.SetActive(false);
            GoodPotion.SetActive(false);
            WinMark.SetActive(false);
            LoseMark.SetActive(false);
            QuestPopup.SetActive(false);
            SellPotion.SetActive(false);
            SellBuffPotion.SetActive(false);
        }
    }
}
