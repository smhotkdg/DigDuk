using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MinerSkillManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;

    public Text TimeText;
    public GameObject Buff;
    public GameObject TextBuff;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(gv.MinerStatusViewObj.activeSelf == true)
        {
            string number = "Skill" + gv.selectNumber;
            string SkillTime = "SkillTime" + gv.selectNumber;
            int iSkillCooTime = 0;
            if (gv.SkillCoolTimePower == 0)
            {
                iSkillCooTime = 1800;
            }
            else
            {
                iSkillCooTime = 1800 - (int)(1800 * gv.SkillCoolTimePower);
            }

            if (gv.MinerSkillIndex[gv.selectNumber] ==1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText(SkillTime, TimeText, iSkillCooTime) == -1)
                {
                    Buff.SetActive(true);
                    TextBuff.SetActive(false);

                    gv.MinerSkillIndex[gv.selectNumber] = 0;
                    PlayerPrefs.SetInt(number, gv.MinerSkillIndex[gv.selectNumber]);
                    PlayerPrefs.Save();

                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText(SkillTime, TimeText, iSkillCooTime) == 2)
                {
                    Buff.SetActive(true);
                    TextBuff.SetActive(false);
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText(SkillTime, TimeText, iSkillCooTime) == 1)
                {
                    Buff.SetActive(false);
                    TextBuff.SetActive(true);
                }
            }
            else
            {
                Buff.SetActive(true);
                TextBuff.SetActive(false);
            }
           
        }
	}

    public void StartSkill()
    {
        string number = "Skill" + gv.selectNumber;
        string SkillTime = "SkillTime" + gv.selectNumber;
        int iSkillCooTime = 0;
        if (gv.SkillCoolTimePower ==0)
        {
            iSkillCooTime = 1800;
        }
        else
        {
            iSkillCooTime =  1800 - (int)(1800 * gv.SkillCoolTimePower) ;
        }
        
        if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText(SkillTime, TimeText, iSkillCooTime) ==-1
            || GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText(SkillTime, TimeText, iSkillCooTime) == 2 || gv.MinerSkillIndex[gv.selectNumber] ==0)
        {
            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetSpeed(gv.selectNumber, 2);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer(SkillTime, iSkillCooTime);
            
            gv.MinerSkillIndex[gv.selectNumber] = 1;
            PlayerPrefs.SetInt(number, gv.MinerSkillIndex[gv.selectNumber]);                    
            PlayerPrefs.Save();

            Buff.SetActive(false);
            TextBuff.SetActive(true);
            gv.BtnBuff.GetComponent<Animator>().SetBool("isBuff", true);
        }
        else
        {
            Buff.SetActive(true);
            TextBuff.SetActive(false);
        }
    }

    public void InitSkill()
    {
        for(int i=0; i< 110; i++)
        {
            string minerSkill = "Skill" + i;
            gv.MinerSkillIndex[i] = 0;
            PlayerPrefs.SetInt(minerSkill, gv.MinerSkillIndex[i]);            
        }
        PlayerPrefs.Save();
        Buff.SetActive(true);
        TextBuff.SetActive(false);
    }
}
