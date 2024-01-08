using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayRewardController : MonoBehaviour {

    // Use this for initialization
    public GameObject RewardBtn;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        gv.DayRewardTime = PlayerPrefs.GetInt("DayRewardTime");
        CheckReward();
        StartCoroutine(CheckRewardTime());
    }
    IEnumerator CheckRewardTime()
    {
        yield return new WaitForSeconds(20);
        if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DayRewardTime_Timer", 39600) == -1)
        {
            gv.DayRewardTime = 0;
            PlayerPrefs.SetInt("DayRewardTime", gv.DayRewardTime);
            PlayerPrefs.Save();            
        }
        CheckReward();
        StartCoroutine(CheckRewardTime());
    }
    public void CheckReward()
    {
        if(gv.DayRewardTime ==0)
        {
            RewardBtn.SetActive(true);
        }
        else
        {
            RewardBtn.SetActive(false);
        }
    }

	// Update is called once per frame
	void Update () {
		
	}
}
