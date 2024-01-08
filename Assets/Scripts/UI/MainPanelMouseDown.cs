using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainPanelMouseDown : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject Coins;
    List<GameObject> ListCoins = new List<GameObject>();
    public GameObject Parent;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    public void InputGame()
    {
        if(gv.bMinerStatus ==true)
        {
            if(gv.bPlacementTutorial == false)
            {
                Vector2 vec = new Vector2();
                vec = gv.MinerStatusViewObj.transform.localPosition;
                vec.x = -1000;
                gv.MinerStatusViewObj.transform.localPosition = vec;

                gv.iMinerSelectStatus = -1;
                gv.bMinerStatus = false;

                gv.MinerStatusViewObj.SetActive(false);
            }
            GameObject.Find("MainCanvas").GetComponent<HireSettingController>().UnsetInfoBtn();
        }
        
    }
    public void UnvisibleShop()
    {
        if (gv.bPlacementTutorial == false)
        {
            if (gv.bShowDrillShop == true)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(2);
                gv.bShowDrillShop = false;
            }
            if (gv.bShowSellShop == true)
            {
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressSellCanvas(0);
                gv.bShowSellShop = false;
            }
        }
    }
}
