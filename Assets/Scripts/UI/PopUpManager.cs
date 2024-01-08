using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PopUpManager : MonoBehaviour {

    // Use this for initialization
    public GameObject NotifiStatusCanvas;
    public GameObject MiniQuest;
    public GameObject AdPopupDrill;
    public GameObject AdPopupSale;
    public GameObject AdZone;
    public GameObject NeedToBlackCoinCanvasObj;
    public GameObject NoticeObj;
    public GameObject BuffObj;
    public Text NoticeText;
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

    public void PopupNotice(int i, string _text)
    {
        if(i ==1)
        {
            NotifiStatusCanvas.SetActive(true);
            gv.AddPanelPopup(NoticeObj, "NoticeObj");
            NoticeObj.SetActive(true);
            NoticeText.text = _text;
        }
        else
        {
            gv.DeletePanelPopup("NoticeObj");
            NotifiStatusCanvas.SetActive(false);
            NoticeText.text = "";
            NoticeObj.SetActive(false);
        }
    }

    public void PopupNotice(int i)
    {
        if (i == 1)
        {
            NotifiStatusCanvas.SetActive(true);
            gv.AddPanelPopup(NoticeObj, "NoticeObj");
            NoticeObj.SetActive(true);         
        }
        else
        {
            NotifiStatusCanvas.SetActive(false);
            gv.DeletePanel("NoticeObj");
            NoticeObj.SetActive(false);
        }
    }

    public void NeedBlackCoinView(int i)
    {
        if( i==1)
        {
            NotifiStatusCanvas.SetActive(true);
            gv.AddPanelPopup(NeedToBlackCoinCanvasObj, "NeedToBlackCoinCanvasObj");
            NeedToBlackCoinCanvasObj.SetActive(true);
        }
        else
        {
            NotifiStatusCanvas.SetActive(false);
            gv.DeletePanel("NeedToBlackCoinCanvasObj");
            NeedToBlackCoinCanvasObj.SetActive(false);
        }
    }

    public void PressAdPopupDrill(int i)
    {
        if(i ==1)
        {
            gv.AddPanelPopup(AdPopupDrill, "AdPopupDrill");
            AdPopupDrill.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(true);
        }
        else
        {
            gv.DeletePanel("AdPopupDrill");
            AdPopupDrill.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(false);
        }
    }

    public void PressAdPopupSale(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(AdPopupSale, "AdPopupSale");
            AdPopupSale.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(true);
        }
        else
        {
            gv.DeletePanel("AdPopupSale");
            AdPopupSale.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(false);
        }
    }

    public void PressAdZone(int i)
    {
        if (i == 1)
        {
            gv.AddPanelPopup(AdZone, "AdZone");
            AdZone.SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(true);
        }
        else
        {
            gv.DeletePanel("AdZone");
            AdZone.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetCollider(false);
        }
    }

    public void PressBuffObj(int i)
    {
        if(GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().isActiveRobotview() == true)
        {
            MiniQuest.SetActive(false);
            BuffObj.SetActive(false);
            return;
        }
        if (i ==1 )
        {
            if(gv.bStartMiniQuest == true)
                MiniQuest.SetActive(true);
            BuffObj.SetActive(true);
        }
        else
        {
            MiniQuest.SetActive(false);
            BuffObj.SetActive(false);
        }
    }
}
