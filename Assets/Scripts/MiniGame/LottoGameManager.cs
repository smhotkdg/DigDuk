using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LottoGameManager : MonoBehaviour {

    // Use this for initialization
    public List<Text> CheckNumber;
    public List<Text> LottoNumber;

    public Text LottoGetBlackCoinCount;
    public Text LottoTitle;

    public GameObject CheckMarkObj;    
    List<GameObject> listCheckMark = new List<GameObject>();


    int xPos = 0;
    int yPos = 500;
    int xMargin = 100;
    int yMargin = -100;
    Vector2 pos = new Vector2();
    int SelectCout = 0;
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    public List<Text> SelectText1;
    List<int> ListSelectNumber = new List<int>();

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void SelectNumber(int number)
    {
        if(SelectCout == -1)
        {
            InitData();    
        }
        for (int i=0; i< SelectText1.Count; i++ )
        {
            if(SelectText1[i].text ==number.ToString())
            {   
                return;
            }
        }
        if (ListSelectNumber.Count == 4)
        {
            ListSelectNumber.RemoveAt(0);
        }
        ListSelectNumber.Add(number);     
        
       
        int count = ((number - 1) / 6);
        pos.y = count * yMargin + yPos;
        pos.x = ((number - 1) -(count * 6)) * xMargin + xPos;
      
        if(listCheckMark.Count < 4)
        {
            
            Transform trasParent;
            GameObject checkMark;
            trasParent = CheckMarkObj.transform.parent;
            checkMark = Instantiate(CheckMarkObj);
            checkMark.transform.parent = trasParent;
            checkMark.transform.localScale = CheckMarkObj.transform.localScale;
            listCheckMark.Add(checkMark);
        }
        if(SelectCout ==4)
        {
            SelectCout = 0;
        }
        if(listCheckMark.Count >0)
        {   
            listCheckMark[SelectCout].transform.localPosition = pos;
            listCheckMark[SelectCout].SetActive(false);
            listCheckMark[SelectCout].SetActive(true);
            SelectCout++;
        }
        for(int i=0; i< ListSelectNumber.Count; i++)
        {
            SelectText1[i].text = ListSelectNumber[i].ToString();
        }

    }

    private void OnDisable()
    {
        for(int i=0; i< listCheckMark.Count; i++)
        {
            Destroy(listCheckMark[i]);
        }
        for(int i=0; i< SelectText1.Count; i++)
        {
            SelectText1[i].text = "";
        }
        listCheckMark.Clear();
    }
    public void InitData()
    {
        for (int i = 0; i < listCheckMark.Count; i++)
        {
            Destroy(listCheckMark[i]);
        }
        for (int i = 0; i < SelectText1.Count; i++)
        {
            SelectText1[i].text = "";
        }
        SelectCout = 0;
        listCheckMark.Clear();
        ListSelectNumber.Clear();
    }

    public void SelectRandom()
    {
        ListSelectNumber.Clear();
        if (listCheckMark.Count < 4)
        {
            for (int i = 0; i < 4; i++)
            {
                Transform trasParent;
                GameObject checkMark;
                trasParent = CheckMarkObj.transform.parent;
                checkMark = Instantiate(CheckMarkObj);
                checkMark.transform.parent = trasParent;
                checkMark.transform.localScale = CheckMarkObj.transform.localScale;
                listCheckMark.Add(checkMark);

            }
        }
        int[] rand = GetRandomInt(4,1,31);

        for(int i=0; i <4; i++)
        {
            ListSelectNumber.Add(rand[i]);
            int count = ((rand[i] -1) / 6);
            pos.y = count * yMargin + yPos;
            pos.x = ((rand[i] -1) - (count * 6)) * xMargin + xPos;
            listCheckMark[i].transform.localPosition = pos;
            listCheckMark[i].SetActive(false);
            listCheckMark[i].SetActive(true);
            SelectText1[i].text = rand[i].ToString();
        }
        SelectCout = -1;

    }

    public int[] GetRandomInt (int lenght, int min, int max)
    {
        int[] randArray = new int[lenght];
        bool isSame;
        for(int i=0; i< lenght; i++)
        {
            while(true)
            {
                randArray[i] = Random.Range(min, max);
                isSame = false;

                for(int j =0; j<i; ++j)
                {
                    if(randArray[j] == randArray[i])
                    {
                        isSame = true;
                        break;
                    }
                }
                if (!isSame) break;
            }
        }
        return randArray;
    
    }
    public int GetSelectCount()
    {
        return ListSelectNumber.Count;
    }
    public int[] GetLottoNumberList()
    {
        return getRandLotto;
    }
    int[] getRandLotto;
    public List<int> GetSelectNumberList()
    {
        return ListSelectNumber;
    }
    public void StartLottoGameView()
    {
        getRandLotto = GetRandomInt(4, 1, 31);
        for(int i=0; i< 4; i++)
        {
            LottoNumber[i].text = getRandLotto[i].ToString();
        }
        for (int i=0;i < ListSelectNumber.Count; i++)
        {
            CheckNumber[i].text = ListSelectNumber[i].ToString();
        }
    }

    public void SetReward()
    {
        if(gv.LottoCorrectCount ==1)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(2);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameWin");
            LottoGetBlackCoinCount.text = "2";
            LottoTitle.text = "4등 당첨";
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", 2);

            
            gv.LottoTotalWinCount++;
            string strUpgradeTotalCount = "TotalLottoWin";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LottoTotalWinCount);
            PlayerPrefs.Save();
        }
        if (gv.LottoCorrectCount == 2)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(2);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameWin");
            LottoGetBlackCoinCount.text = "20";
            LottoTitle.text = "3등 당첨";
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", 20);
            gv.LottoTotalWinCount++;
            string strUpgradeTotalCount = "TotalLottoWin";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LottoTotalWinCount);
            PlayerPrefs.Save();
        }
        if (gv.LottoCorrectCount == 3)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(2);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameWin");
            LottoGetBlackCoinCount.text = "200";
            LottoTitle.text = "2등 당첨";
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", 200);
            gv.LottoTotalWinCount++;
            string strUpgradeTotalCount = "TotalLottoWin";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LottoTotalWinCount);
            PlayerPrefs.Save();
        }
        if (gv.LottoCorrectCount == 4)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(2);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameWin");
            LottoGetBlackCoinCount.text = "2000";
            LottoTitle.text = "1등 당첨";
            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
            SIS.DBManager.IncreaseFunds("blackcoin", 2000);
            gv.LottoTotalWinCount++;
            string strUpgradeTotalCount = "TotalLottoWin";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LottoTotalWinCount);
            PlayerPrefs.Save();
        }

    }
}
