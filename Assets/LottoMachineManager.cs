using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class LottoMachineManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MiniGameObj;
    public List<GameObject> Ball;
    public List<GameObject> ParticleList;
    public GameObject BtnExit;
    public GameObject BtnReward;
    List<int> SelectNumberList;
    int CorrectCount =0;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        SelectNumberList = MiniGameObj.GetComponent<LottoGameManager>().GetSelectNumberList();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        for(int i=0; i< Ball.Count; i++)
        {
            for(int k =0; k< SelectNumberList.Count; k++)
            {
                if (Ball[i].activeSelf == true)
                {
                    if (Ball[i].transform.Find("Text").GetComponent<Text>().text == SelectNumberList[k].ToString())
                    {                        
                        ParticleList[k].SetActive(true);
                        CorrectCount++;                        
                    }
                }
            }            
        }
    } 
    public void SetBall(int i)
    {
        Ball[i].SetActive(true);
        int[] arrLottoNum = MiniGameObj.GetComponent<LottoGameManager>().GetLottoNumberList();
        Ball[i].transform.Find("Text").gameObject.GetComponent<Text>().text = arrLottoNum[i].ToString();        
    }
    private void OnDisable()
    {
        for(int i=0; i<Ball.Count; i++)
        {
            Ball[i].SetActive(false);
            ParticleList[i].SetActive(false);
        }
        BtnExit.SetActive(false);   
        BtnReward.SetActive(false);
        CorrectCount = 0;
    }

    public void EndGame()
    {
        for(int i=0; i< ParticleList.Count; i++)
        {
            if (ParticleList[i].activeSelf == true)
            {
                gv.LottoCorrectCount++;
            }
        }
        if(CorrectCount ==0)
        {
            BtnExit.SetActive(true);

            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("MinigameLose");
            gv.LottoTotalLoseCount++;
            string strUpgradeTotalCount = "TotalLottoLose";
            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LottoTotalLoseCount);
            gv.LoseMarkTotal++;
            strUpgradeTotalCount = "LoseMark";

            PlayerPrefs.SetInt(strUpgradeTotalCount, gv.LoseMarkTotal);
            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckLoseMarkQuset());
            PlayerPrefs.Save();
        }
        else
        {
            BtnReward.SetActive(true);
        }
        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 8)
            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(8, 0);
    }
}
