using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdsUIManager : MonoBehaviour {

    // Use this for initialization
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

    public void ResetMiniGameByAds()
    {
        if (gv.SelectMiniGame == 1)
        {
            gv.GhostLegCount = 0;            
            PlayerPrefs.SetInt("GhostLegCount", gv.GhostLegCount);            
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
        if (gv.SelectMiniGame == 2)
        {
            gv.LottoCount = 0;            
            PlayerPrefs.SetInt("LottoCount", gv.GhostLegCount);            
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
        if (gv.SelectMiniGame == 3)
        {
            gv.SpinwheelCount = 0;            
            PlayerPrefs.SetInt("SpinwheelCount", gv.GhostLegCount);            
            PlayerPrefs.Save();
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLimitMiniGame(0);
        }
    }
}
   


