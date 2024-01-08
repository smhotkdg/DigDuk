using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageButtonManager : MonoBehaviour {

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
    int GetPosPosition(string name)
    {
        string strTemp = name;
        string[] a = strTemp.Split('s');
        int Count = int.Parse(a[1]);
        return Count;
    }
    int GetStageMapPostion(string name)
    {
        string strTemp = name;
        string[] a = strTemp.Split('p');
        int Count = int.Parse(a[1]);
        return Count;
    }
    public void OnClick()
    {
        int Pos = GetPosPosition(this.name);
        int MapPos = GetStageMapPostion(this.transform.parent.name);

        int stageIndex = (MapPos -1) * 11;

        Pos = Pos + stageIndex;
        int PosnameIndex;
        PosnameIndex = Pos;

        string strPosName;
        strPosName = "Stage " + PosnameIndex;

        gv.KingMineralsStage = PosnameIndex;
        GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().SetStageText(strPosName);
        GameObject.Find("KingMineralsCanvas").GetComponent<KingMineralUIManager>().PressStartStagePanel(1);        
    }
}
