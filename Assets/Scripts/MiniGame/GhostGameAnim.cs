using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GhostGameAnim : MonoBehaviour {

    // Use this for initialization
    //복구금액
    public Text Money100;
    //복구금액
    public Text Money70;
    public GameObject GhostView;
    public GameObject GhostMan1;
    public GameObject GhostMan2;

    public GameObject GhostMan1Select;
    public GameObject GhostMan2Select;

    public GameObject BoxLeft;
    public GameObject BoxRight;
    GlobalVariable gv;
    bool bWin = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetRewardGame()
    {
        int rand = Random.Range(1, 3);
        if(rand ==1)
        {
            BoxRight.SetActive(false);
            if(gv.GhostLegSelectNumber ==2)
            {
                bWin = true;
            }
            else
            {
                gv.RetrunGhostLegMoney = gv.GhostLegMoney;
                Money100.text = gv.ChangeMoney(gv.RetrunGhostLegMoney);
                Money70.text = gv.ChangeMoney(gv.RetrunGhostLegMoney*0.5);
                GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().SetRestoreMoney((float)gv.RetrunGhostLegMoney, (float)(gv.RetrunGhostLegMoney * 0.5));
            }
        }
        else if (rand ==2)
        {
            BoxLeft.SetActive(false);
            if(gv.GhostLegSelectNumber ==1)
            {
                bWin = true;
            }
            else
            {
                gv.RetrunGhostLegMoney = gv.GhostLegMoney;
                Money100.text = gv.ChangeMoney(gv.RetrunGhostLegMoney);
                Money70.text = gv.ChangeMoney(gv.RetrunGhostLegMoney*0.5);
                GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().SetRestoreMoney((float)gv.RetrunGhostLegMoney, (float)(gv.RetrunGhostLegMoney * 0.5));
            }
        }
        
    }
    
    public void EndGame()
    {
        StartCoroutine(DisableView());
    }
    IEnumerator DisableView()
    {
        if(bWin == false)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(3);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameLose");
        }
        yield return new WaitForSeconds(1f);        
        //if win
        if(bWin ==true)
        {
            //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(2);
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameWin");
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().PressWinCanvas(1);
            gv.SadariTotalWinCount++;
            string strUpgradeTotalCount = "TotalSadariWin";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.SadariTotalWinCount);
            gv.WinMarkTotal++;
            strUpgradeTotalCount = "WinMark";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.WinMarkTotal);

            PlayerPrefs.Save();

            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckSadariGameQuset());
            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckWinMarkQuest());
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 7)
                GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(7, 0);
        }
        else
        {            
            GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().PressDefeatCanvas(1);
            gv.SadariTotalLoseCount++;
            string strUpgradeTotalCount = "TotalSadariLose";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.SadariTotalLoseCount);

            gv.LoseMarkTotal++;
            strUpgradeTotalCount = "LoseMark";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LoseMarkTotal);

            PlayerPrefs.Save();
            
            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckLoseMarkQuset());
        }
        SetGhostLegMan();
        GhostView.SetActive(false);
    }
   
    public void SetGhostLegMan()
    {
        Vector2 vec = new Vector2();
        bWin = false;
        vec.x = -161.2f;
        vec.y = 375;
        GhostMan1.transform.localPosition = vec;
        vec.x = 161.2f;
        vec.y = 358.25f;
        GhostMan2.transform.localPosition = vec;
        BoxRight.SetActive(true);
        BoxLeft.SetActive(true);
        GhostMan1.SetActive(true);
        GhostMan2.SetActive(true);
        GhostMan1Select.SetActive(true);
        GhostMan2Select.SetActive(true);
    }
}
