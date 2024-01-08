using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayRewardUIController : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusObj;
    GlobalVariable gv;
    public GameObject BG;
    public GameObject Btn;
    public GameObject Text_Click;
    public GameObject RewardPopupObj;
    public Text TimeText;
    List<GameObject> ListDays = new List<GameObject>();
    bool bStart = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        for (int i = 0; i < 20; i++)
        {
            int count = i + 1;
            string strDay = "Day" + count;
            ListDays.Add(BG.transform.Find(strDay).gameObject);
        }
    }
    void Start () {
		
	}
    private void OnDisable()
    {
        bStart = false;
    }
    public void ReSetData()
    {
        for (int i = 0; i < ListDays.Count; i++)
        {            
            ListDays[i].transform.Find("ArrowImg").gameObject.SetActive(false);
        }
    }
    private void OnEnable()
    {
        bStart = true;
        if (gv.DayRewardNext >0)
        {
            for (int i = 0; i < gv.DayRewardNext; i++)
            {
                ListDays[i].transform.Find("ArrowImg").gameObject.GetComponent<Animator>().SetBool("isSelect", false);                
                ListDays[i].transform.Find("ArrowImg").gameObject.SetActive(true);
                Vector2 vec;
                vec = ListDays[i].transform.Find("ArrowImg").gameObject.transform.localPosition;
                vec.y = 0;
                ListDays[i].transform.Find("ArrowImg").gameObject.transform.localPosition = vec;

            }
        }
        if(gv.DayRewardTime ==0)
        {
            ListDays[gv.DayRewardNext].transform.Find("ArrowImg").gameObject.SetActive(true);
            ListDays[gv.DayRewardNext].transform.Find("ArrowImg").gameObject.GetComponent<Animator>().SetBool("isSelect", true);
        }
    }
    public void setButton(bool flag)
    {
        if (flag == false)
        {
            Text_Click.SetActive(true);
            Btn.SetActive(false);
        }
        else
        {
            Text_Click.SetActive(false);
            Btn.SetActive(true);
        }
    }
    //여기가 리워드 주는데
    public void ClickDayReward(int i)
    {
        if(gv.DayRewardTime ==0)
        {
            if (gv.DayRewardNext == i && gv.ListDayRewardCount[i] == 0)
            {
                //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(4);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Open");
                RewardPopupObj.SetActive(true);
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressSettingCanvas(0);
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDayReward(0);
                string strday = "DayReward" + i;
                gv.ListDayRewardCount[i] = 2;

                gv.DayRewardNext++;
                gv.DayRewardTime = 1;
                PlayerPrefs.SetInt("DayRewardNext", gv.DayRewardNext);
                PlayerPrefs.SetInt("DayRewardTime", gv.DayRewardTime); 
                PlayerPrefs.SetInt(strday, gv.ListDayRewardCount[i]);
                PlayerPrefs.Save();

                MainStatusObj.GetComponent<DayRewardController>().CheckReward();
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("DayRewardTime_Timer", 39600);
            }
        }
   
    }

    // Update is called once per frame
    void Update () {
        if(bStart == true)
        {
            //39600
            if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("DayRewardTime_Timer", TimeText, 39600) ==-1)
            {
                gv.DayRewardTime = 0;
                PlayerPrefs.SetInt("DayRewardTime", gv.DayRewardTime);
                PlayerPrefs.Save();                
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(39600, TimeText);
            }
        }
	}
}
