using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewEventPanelUIManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> Map1EventList;
    public List<GameObject> Map2EventList;
    public List<GameObject> Map3EventList;
    public List<GameObject> Map4EventList;
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
    private void OnEnable()
    {
        if(gv.MapType ==1)
        {
            for(int i=0; i< gv.EventDepthNormal.Count; i++)
            {
                if(gv.Depth == gv.EventDepthNormal[i])
                {
                    Map1EventList[i].SetActive(true);
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.EventDepthDesert.Count; i++)
            {
                if (gv.DesertDepth == gv.EventDepthDesert[i])
                {
                    Map2EventList[i].SetActive(true);
                }
            }

        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.EventDepthIce.Count; i++)
            {
                if (gv.IceDepth == gv.EventDepthIce[i])
                {
                    Map3EventList[i].SetActive(true);
                }
            }

        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.EventDepthForest.Count; i++)
            {
                if (gv.ForestDepth == gv.EventDepthForest[i])
                {
                    Map4EventList[i].SetActive(true);
                }
            }
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < Map1EventList.Count; i++)
        {
            Map1EventList[i].SetActive(false);
        }
        for (int i = 0; i < Map2EventList.Count; i++)
        {
            Map2EventList[i].SetActive(false);
        }
        for (int i = 0; i < Map3EventList.Count; i++)
        {
            Map3EventList[i].SetActive(false);
        }
        for (int i = 0; i < Map4EventList.Count; i++)
        {
            Map4EventList[i].SetActive(false);
        }
    }
}
