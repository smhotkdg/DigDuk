using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventDialogueUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public EventTypeWriterEffect eventeffect;
    public GameObject PanelObj;
    public GameObject Jooin;
    public GameObject ObjectEvent;
    public List<GameObject> Map1EventObjectList;
    public List<GameObject> Map2EventObjectList;
    public List<GameObject> Map3EventObjectList;
    public List<GameObject> Map4EventObjectList;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
 
    void Start () {        
	}
    private void OnEnable()
    {
        PanelObj.SetActive(true);        
    }
    public void InitSetting()
    {
        eventeffect.Init();
    }
    public void SetEventObject(int number)
    {
        if(gv.MapType ==1)
        {
            if(number == 0)
            {
                Jooin.SetActive(true);
                ObjectEvent.SetActive(false);
                for (int i=0; i< Map1EventObjectList.Count; i++)
                {
                    Map1EventObjectList[i].SetActive(false);
                }
            }
            if(number ==1)
            {
                ObjectEvent.SetActive(true);
                Jooin.SetActive(false);
                Map1EventObjectList[gv.iSelectDialogue].SetActive(true);
            }
        }
        if (gv.MapType == 2)
        {
            if (number == 0)
            {
                Jooin.SetActive(true);
                ObjectEvent.SetActive(false);
                for (int i = 0; i < Map2EventObjectList.Count; i++)
                {
                    Map2EventObjectList[i].SetActive(false);
                }
            }
            if (number == 1)
            {
                ObjectEvent.SetActive(true);
                Jooin.SetActive(false);
                Map2EventObjectList[gv.iSelectDialogue].SetActive(true);
            }
        }
        if (gv.MapType == 3)
        {
            if (number == 0)
            {
                Jooin.SetActive(true);
                ObjectEvent.SetActive(false);
                for (int i = 0; i < Map3EventObjectList.Count; i++)
                {
                    Map3EventObjectList[i].SetActive(false);
                }
            }
            if (number == 1)
            {
                ObjectEvent.SetActive(true);
                Jooin.SetActive(false);
                Map3EventObjectList[gv.iSelectDialogue].SetActive(true);
            }
        }
        if (gv.MapType == 4)
        {
            if (number == 0)
            {
                Jooin.SetActive(true);
                ObjectEvent.SetActive(false);
                for (int i = 0; i < Map4EventObjectList.Count; i++)
                {
                    Map4EventObjectList[i].SetActive(false);
                }
            }
            if (number == 1)
            {
                ObjectEvent.SetActive(true);
                Jooin.SetActive(false);
                Map4EventObjectList[gv.iSelectDialogue].SetActive(true);
            }
        }
    }
    private void OnDisable()
    {
        PanelObj.SetActive(false);
        for (int i=0; i< Map1EventObjectList.Count; i++)
        {
            Map1EventObjectList[i].SetActive(false);
        }
        for (int i = 0; i < Map2EventObjectList.Count; i++)
        {
            Map2EventObjectList[i].SetActive(false);
        }
        for (int i = 0; i < Map3EventObjectList.Count; i++)
        {
            Map3EventObjectList[i].SetActive(false);
        }
        for (int i = 0; i < Map4EventObjectList.Count; i++)
        {
            Map4EventObjectList[i].SetActive(false);
        }

    }
    // Update is called once per frame
    void Update () {
		
	}
    public void StartEndView()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDialoguePanee(0, gv.isFirstDialogue);
    }    
}
