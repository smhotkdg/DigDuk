using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameUIManager : MonoBehaviour {

    // Use this for initialization
    public Text PercentRewardMoney;
    public Text RewardMoney;
    public GameObject MinigameRewardMoneyPanel;
    public GameObject MainStatusObj;
    public GameObject SpinWheelGameResultObj;
    public GameObject LottoRewardObj;
    public GameObject LottoGameObj;
    public GameObject DefeatCanvasObj;
    public GameObject MainStatusCanvas;    
    public GameObject WinCanvasObj;
    public GameObject LottoPanel;
    public GameObject GhostLegPanel;
    public GameObject SpinWheelPanel;
    public GameObject MinigameLosePanel;
    public GameObject GhostLegGamePanel;

    public Button GhostLegWinBtn;
    public Image GhostLegInwImage;
    public Text GhostLegMoneyText;

    public Text TextGhostLegCount;
    public Text TextLottoCount;
    public Text TextSpinwheelCount;

    GlobalVariable gv;
    float Restoremoney;
    float Restoremoney70;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetRestoreMoney(float money,float money70)
    {
        Restoremoney = money;
        Restoremoney70 = money70;
    }
    public void RestoreMoneybyAds()
    {
        GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().PressMinigameRewardMoneyPanel(1, Restoremoney70, 50);       
        PressDefeatCanvas(0);
        Restoremoney = 0;
        Restoremoney70 = 0;
    }
    public void RestoreMoneybyAdsRandom()
    {
        float randomMoney = Random.Range(0.1f, 1f);
        float ResultMoney = Restoremoney * randomMoney;
        float Percent = randomMoney * 100;
        GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().PressMinigameRewardMoneyPanel(1, ResultMoney, Percent);
        PressDefeatCanvas(0);
        Restoremoney = 0;
        Restoremoney70 = 0;
    }
    public void RestoreMoneybyBlackCoin(int money)
    {
        //if (gv.BlackCoinCount >= 10)
        {
            gv.BlackCoinCount -= 10;
            gv.Money += Restoremoney;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.SetInt("BlackCoin", gv.BlackCoinCount);
            PlayerPrefs.Save();
            PressDefeatCanvas(0);
            Restoremoney = 0;
            Restoremoney70 = 0;
        }
        //else
        //{
        //    MainStatusObj.GetComponent<PopUpManager>().NeedBlackCoinView(1);
        //}
    }

    private void FixedUpdate()
    {
        if (gv.GhostLegCount < 3)
        {
            TextGhostLegCount.text = "(" + gv.GhostLegCount +"/3"+ ")" + "\n" + "Play Count";
        }
        else
        {
            if(GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("GhostLegTimer", TextGhostLegCount, 21600) == -1)
            {
                gv.GhostLegCount = 0;
                PlayerPrefs.SetInt("GhostLegCount", gv.GhostLegCount);
                PlayerPrefs.Save();
            }
        }

        if (gv.LottoCount < 3)
        {
            TextLottoCount.text = "(" + gv.LottoCount + "/3" + ")" + "\n" + "Play Count"; ;
        }
        else
        {
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("LottoTimer", TextLottoCount, 21600) == -1)
            {
                gv.LottoCount = 0;
                PlayerPrefs.SetInt("LottoCount", gv.LottoCount);
                PlayerPrefs.Save();
            }
        }


        if (gv.SpinwheelCount < 3)
        {
            TextSpinwheelCount.text = "(" + gv.SpinwheelCount + "/3" + ")" + "\n" + "플레이 횟수"; ;
        }
        else
        {
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("SpinWheelTimer", TextSpinwheelCount, 21600) == -1)
            {
                gv.SpinwheelCount = 0;
                PlayerPrefs.SetInt("SpinwheelCount", gv.SpinwheelCount);
                PlayerPrefs.Save();
            }
        }
    }
    private void OnDisable()
    {
        PressLotto(0);
        PressGhostLeg(0);
        PressSpinWheel(0);
        PressMinigameLose(0);
        PressGhostLegGame(0);
        PressWinCanvas(0);
        PressDefeatCanvas(0);
        PressLottoGameCanvas(0);
    }
    public void PressLotto(int i)
    {
        if(i ==1)
        {
            gv.SelectMiniGame = 2;
            if (gv.LottoCount <3)
            {
                LottoPanel.SetActive(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(1);
            }
            
        }
        else
        {
            LottoPanel.SetActive(false);
            this.GetComponent<LottoGameManager>().InitData();
        }
    }
    public void PressGhostLeg(int i)
    {
        if(i==1)
        {
            gv.SelectMiniGame = 1;
            if (gv.GhostLegCount <3)
            {
                gv.GhostLegMoney = 0;
                GhostLegPanel.SetActive(true);
                this.GetComponent<GhostGameManager>().DefaultGameSetting();
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(1);
            }
            
        }
        else
        {           
            GhostLegPanel.SetActive(false);            
            //게임을 실행 안하고 종료할경우만 
            this.GetComponent<GhostGameManager>().ReSetMoney();
        }
    }
    public void PressSpinWheel(int i)
    {
        if(i == 1)
        {
            gv.SelectMiniGame = 3;
            if (gv.SpinwheelCount <3)
            {
                SpinWheelPanel.SetActive(true);
                this.GetComponent<SpinWheelGameManager>().StartUpdate(true);
            }
            else
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(1);
            }
        }
        else
        {
            this.GetComponent<SpinWheelGameManager>().ResetGame();
            this.GetComponent<SpinWheelGameManager>().StartUpdate(false);
            SpinWheelPanel.SetActive(false);
        }
    }
    public void PressMinigameLose(int i)
    {
        if(i==1)
        {
            MinigameLosePanel.SetActive(true);
        }
        else
        {
            MinigameLosePanel.SetActive(false);
        }
    }
    public void PressGhostLegGame(int i)
    {
        if(i ==1)
        {
            //if 돈 걸었을때만 
            if(gv.GhostLegMoney >0)
            {
                gv.GhostLegCount++;
                PlayerPrefs.SetInt("GhostLegCount",gv.GhostLegCount);
                PlayerPrefs.Save();
                if(gv.GhostLegCount <=3)
                {
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("GhostLegTimer", 21600);
                }
                GhostLegGamePanel.SetActive(true);
                this.GetComponent<GhostGameManager>().SetMoney();
                PressGhostLeg(0);
            }
            else
            {
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "도전 금액이 필요합니다.");
            }
          
        }
        else
        {
            GhostLegGamePanel.SetActive(false);
        }
    }

    public void PressWinCanvas(int i)
    {
        if(i ==1)
        {
            GhostLegMoneyText.text = gv.ChangeMoney(gv.GhostLegMoney * 2);
            GhostLegWinBtn.interactable = false;
            Color _color = GhostLegInwImage.color;
            _color.a = 0.2f;
            GhostLegInwImage.color = _color;
            WinCanvasObj.SetActive(true);
            StartCoroutine(StartParticle());
        }
        else
        {
            WinCanvasObj.SetActive(false);
        }
    }

    public void PressDefeatCanvas(int i)
    {
        if (i == 1)
        {
            DefeatCanvasObj.SetActive(true);
        }
        else
        {
            DefeatCanvasObj.SetActive(false);
        }
    }

    
    public void PressLottoGameCanvas(int i)
    {
        if(i ==1)
        {
            if(this.GetComponent<LottoGameManager>().GetSelectCount() == 4)
            {
                //블랙코인 확인하고 블랙코인 뺸다음에

                //
                SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                if (SIS.DBManager.GetFunds("blackcoin") >=2)
                {
                    SIS.DBManager.IncreaseFunds("blackcoin", -2);
                    gv.LottoCount++;
                    PlayerPrefs.SetInt("LottoCount", gv.LottoCount);
                    PlayerPrefs.Save();
                    if (gv.LottoCount <= 3)
                    {
                        GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("LottoTimer", 21600);
                    }
                    LottoGameObj.SetActive(true);
                    this.GetComponent<LottoGameManager>().StartLottoGameView();
                }
                else
                {
                    MainStatusCanvas.GetComponent<PopUpManager>().NeedBlackCoinView(1);
                }             
             
              
            }
            else
            {
                MainStatusCanvas.GetComponent<PopUpManager>().PopupNotice(1, "번호를 선택 하세요.");
            }
            
        }
        else
        {

            PressLotto(0);
            LottoGameObj.SetActive(false);
        }
    }
    IEnumerator StartParticle()
    {
        yield return new WaitForSeconds(0.7f);
        MainStatusCanvas.GetComponent<CoinParticleManager>().StartCoinParticleMoney(10, (gv.GhostLegMoney * 2));
    }

    public void PressLottoReward(int i)
    {
        if(i ==1)
        {

            LottoRewardObj.SetActive(true);
            this.GetComponent<LottoGameManager>().SetReward();

            gv.WinMarkTotal++;
            string strUpgradeTotalCount = "WinMark";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.WinMarkTotal);
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckLottoGameQuest());
            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckWinMarkQuest());
            PressLottoGameCanvas(0);
        }
        else
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(3);
          
            LottoRewardObj.SetActive(false);
            gv.LottoCorrectCount = 0;   
        }
    }
    public void PressSpinWheelResult(int i)
    {
        if(i ==1)
        {
            SpinWheelGameResultObj.SetActive(true);
            this.GetComponent<SpinWheelGameManager>().ResultGame();
        }
        else
        {
            SpinWheelGameResultObj.SetActive(false);
            PressSpinWheel(0);
        }
    }

    public void PressMinigameRewardMoneyPanel(int i)
    {
        if(i ==1)
        {
            MinigameRewardMoneyPanel.SetActive(true);
        }
        else
        {
            MinigameRewardMoneyPanel.SetActive(false);
            gv.Money += RewardMoney_result;
            PlayerPrefs.SetFloat("Money", (float)gv.Money);
            PlayerPrefs.Save();
            RewardMoney_result = 0;
        }
    }
    float RewardMoney_result = 0;
    public void PressMinigameRewardMoneyPanel(int i,float money, float percent)
    {
        if (i == 1)
        {
            string temp = percent.ToString("N1") + " %";
            PercentRewardMoney.text = temp;
            RewardMoney.text = gv.ChangeMoney(money);
            MinigameRewardMoneyPanel.SetActive(true);
            RewardMoney_result = money;
        }
        else
        {
            MinigameRewardMoneyPanel.SetActive(false);           
        }
    }
}
