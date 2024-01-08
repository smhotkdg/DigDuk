using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingCanvasManager : MonoBehaviour {

    // Use this for initialization
    public GameObject GuidePanel;
    public GameObject SaveConfirmObj;
    public GameObject SoundSettingObj;
    public GameObject CreditsObj;
    public GameObject LanguageObj;
    public GameObject AppQuitObj;
    public GameObject DayrewardObj;
    public List<GameObject> GuidList;

    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start () {
		
	}
	
    public void ChangeLangueage(int index)
    {
        switch(index)
        {
            case 1:
                //한국어
                break;
            case 2:
                //영어
                break;
            case 3:
                //스페인어
                break;
            case 4:
                //포루투갈어
                break;
            case 5:
                //독일어
                break;
            case 6:
                //프랑스어
                break;
            case 7:
                //이탈리아어
                break;
            case 8:
                //일본어
                break;
            case 9:
                //인도어
                break;
            case 10:
                //태국(중국)어
                break;
            case 11:
                //아랍어
                break;
        }
    }
	// Update is called once per frame
	void Update () {
		
	}
    public void FaceBookLink()
    {
        Application.OpenURL("https://www.facebook.com/pages/category/Computer-Company/HoitStudio-320002755073939/");
    }

    public void PressSOundSetting(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(SoundSettingObj, "SoundSettingObj");
            SoundSettingObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SoundSettingObj");
            SoundSettingObj.SetActive(false);
        }
    }
    public void PressCreditObj(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(CreditsObj, "CreditsObj");
            CreditsObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("CreditsObj");
            CreditsObj.SetActive(false);
        }
    }
    public void PressLanguageObj(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(LanguageObj, "LanguageObj");
            LanguageObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("LanguageObj");
            LanguageObj.SetActive(false);
        }
    }
    public void PressAppQuit(int i)
    {
        if (i ==1)
        {
            gv.AddPanelPopup(AppQuitObj, "AppQuitObj");
            AppQuitObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("AppQuitObj");
            AppQuitObj.SetActive(false);
        }
    }

    public void PressSaveConfirm(int i)
    {
        if(i==1)
        {
            gv.AddPanelPopup(SaveConfirmObj, "SaveConfirmObj");
            SaveConfirmObj.SetActive(true);
        }
        else
        {
            gv.DeletePanelPopup("SaveConfirmObj");
            SaveConfirmObj.SetActive(false);
        }
    }
    public void PressDayReward(int i)
    {
        if(i ==1)
        {
            //gv.AddPanelPopup(DayrewardObj, "DayrewardObj");
            DayrewardObj.SetActive(true);
        }
        else
        {
            //gv.DeletePanelPopup("DayrewardObj");
            DayrewardObj.SetActive(false);
        }
    }

    public void PressGuidePanel(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(GuidePanel, "GuidePanel");
            GuidePanel.SetActive(true);
            ClickGuideImage(0);
        }
        else
        {
            gv.DeletePanelPopup("GuidePanel");
            GuidePanel.SetActive(false);
            GuideCount = 0;
        }
    }
    int GuideCount = 0;
    public void ClickGuideImage(int count)
    {
        for(int i=0; i < GuidList.Count; i++)
        {
            GuidList[i].SetActive(false);
        }
        if (GuidList.Count == GuideCount)
            PressGuidePanel(0);
        else
        {
            GuidList[count].SetActive(true);
            GuideCount++;
        }
    }
}
