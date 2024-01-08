using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapChangeUIController : MonoBehaviour {

    // Use this for initialization
    public Text MineralInfoText;
    public GameObject DesertKey;
    public GameObject IceKey;
    public GameObject ForestKey;

    public GameObject TextGold;
    public GameObject TextKey;

    public ScrollRect myScroll;
    public GameObject DesertImg;
    public GameObject IceImg;
    public GameObject ForestImg;
    public GameObject TextDesert;
    public GameObject TextIce;
    public GameObject TextForest;
    public GameObject MainStatus;
    public GameObject LockDesert;
    public GameObject LockIce;
    public GameObject LockForest;
    public Button BtnDesert;
    public Button BtnIce;
    public Button BtnForest;

    public GameObject Panelbuy;
    public GameObject DesertObj;
    public GameObject IceObj;
    public GameObject ForestObj;
    public GameObject NeedMoneyPanel;
    public Text BuyMoneyText;
    GlobalVariable gv;
    int LockType = 0;
    double moneyDesert = 1000000 * 0.000000000000000001f;
    double moneyIce = 10000000000000 * 0.000000000000000001f;
    double moneyForeset = 1000000000000000000 * 0.000000000000000001f;
    public Text TextRibbon;
    public GameObject GetIsland;
    public Text GetText;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {
        TextDesert.GetComponent<Text>().text = gv.ChangeMoney(moneyDesert);
        TextIce.GetComponent<Text>().text = gv.ChangeMoney(moneyIce);
        TextForest.GetComponent<Text>().text = gv.ChangeMoney(moneyForeset);

    }
    //번역
    public void OnClickLock(int i)
    {
        LockType = i;
        Panelbuy.SetActive(true);
        DesertObj.SetActive(false);
        IceObj.SetActive(false);
        ForestObj.SetActive(false);
        if (i ==1)
        {
            BuyMoneyText.text = TextDesert.GetComponent<Text>().text;
            DesertObj.SetActive(true);
            TextRibbon.text = "사 막";
            if(gv.DesertKey >=1)
            {
                Color _color;
                _color = DesertKey.GetComponent<Image>().color;
                _color.a = 1; _color.r = 1; _color.g = 1; _color.b = 1;
                DesertKey.GetComponent<Image>().color = _color;                
            }
            MineralInfoText.text = "광물을 x 5 배로 판매 합니다.";
        }
        if (i == 2)
        {
            BuyMoneyText.text = TextIce.GetComponent<Text>().text;
            IceObj.SetActive(true);
            TextRibbon.text = "얼 음";
            if (gv.IceKey>= 1)
            {
                Color _color;
                _color = IceKey.GetComponent<Image>().color;
                _color.a = 1; _color.r = 1; _color.g = 1; _color.b = 1;
                IceKey.GetComponent<Image>().color = _color;
            }
            MineralInfoText.text = "광물을 x 10 배로 판매 합니다.";
        }
        if (i == 3)
        {
            BuyMoneyText.text = TextForest.GetComponent<Text>().text;
            ForestObj.SetActive(true);
            TextRibbon.text = "정 글";
            if (gv.ForestKey >= 1)
            {
                Color _color;
                _color = ForestKey.GetComponent<Image>().color;
                _color.a = 1; _color.r = 1; _color.g = 1; _color.b = 1;
                ForestKey.GetComponent<Image>().color = _color;
            }
            MineralInfoText.text = "광물을 x 100 배로 판매 합니다.";
        }
    }
    public void OnEnable()
    {
        myScroll.verticalNormalizedPosition = 0;
        if (gv.IslandDesert ==1)
        {
            BtnDesert.enabled = true;
            LockDesert.SetActive(false);
        }
        if(gv.IslandIce ==1)
        {
            BtnIce.enabled = true;
            LockIce.SetActive(false);
        }
        if(gv.IslandForest ==1)
        {
            BtnForest.enabled = true;
            LockForest.SetActive(false);
        }
    }

    private void OnDisable()
    {
        DesertImg.SetActive(false);
        IceImg.SetActive(false);
        ForestImg.SetActive(false);
        TextKey.SetActive(false);
        TextGold.SetActive(false);
    }
    // Update is called once per frame
    void Update () {
		
	}
    public void BuyIsLand()
    {
        if (LockType ==1)
        {
            if (gv.DesertKey == 0)
            {
                TextKey.SetActive(true);
                PressNeedMoney(1);
            }
            else if(gv.Money >= moneyDesert)
            {
                DesertImg.SetActive(true);
                //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(7);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MapOpen");
                gv.Money -= moneyDesert;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                gv.IslandDesert = 1;
                PlayerPrefs.SetInt("IslandDesert", gv.IslandDesert);
                PlayerPrefs.Save();

                BtnDesert.enabled = true;
                LockDesert.SetActive(false);
                PressBuyPanel(0);
                GetText.text = "사막 맵 획득!";
                GetIsLandView(1);
            }
            else
            {
                //꺼져
                
                TextGold.SetActive(true);              
                PressNeedMoney(1);
            }
        }

        if (LockType == 2)
        {
            if (gv.IceKey == 0)
            {
                TextKey.SetActive(true);
                PressNeedMoney(1);
            }
            else if (gv.Money >= moneyIce)
            {
                IceImg.SetActive(true);
                //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(7);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MapOpen");
                gv.Money -= moneyIce;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                gv.IslandIce = 1;
                PlayerPrefs.SetInt("IslandIce", gv.IslandIce);
                PlayerPrefs.Save();

                BtnIce.enabled = true;
                LockIce.SetActive(false);
                PressBuyPanel(0);
                GetText.text = "얼음 맵 획득!";
                GetIsLandView(1);
            }
            else
            {
                //꺼져
               
                TextGold.SetActive(true);
                PressNeedMoney(1);
            }
        }

        if (LockType ==3)
        {
            if (gv.ForestKey == 0)
            {
                TextKey.SetActive(true);
                PressNeedMoney(1);
            }
            else if (gv.Money >= moneyForeset)
            {
                ForestImg.SetActive(true);
                //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(7);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MapOpen");
                gv.Money -= moneyForeset;
                PlayerPrefs.SetFloat("Money", (float)gv.Money);
                gv.IslandForest = 1;
                PlayerPrefs.SetInt("IslandForest", gv.IslandForest);
                PlayerPrefs.Save();

                BtnForest.enabled = true;
                LockForest.SetActive(false);
                PressBuyPanel(0);
                GetText.text = "정글 맵 획득!";
                GetIsLandView(1);
            }
            else
            {
                //꺼져
               
                TextGold.SetActive(true);
               
                PressNeedMoney(1);
            }
        }
    }
    public void GetIsLandView(int i)
    {
        if(i ==1)
        {
            GetIsland.SetActive(true);
        }
        else
        {
            GetIsland.SetActive(false);
        }
    }
    public void PressNeedMoney(int i)
    {
        if(i ==1)
        {
            NeedMoneyPanel.SetActive(true);
        }
        else
        {
            NeedMoneyPanel.SetActive(false);
        }
    }
    public void PressBuyPanel(int i)
    {
        if(i ==1)
        {
            Panelbuy.SetActive(true);
        }
        else
        {
            Panelbuy.SetActive(false);
        }
    }
}
