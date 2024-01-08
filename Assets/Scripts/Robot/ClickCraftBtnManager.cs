using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCraftBtnManager : MonoBehaviour {

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


    int SplitName(string name)
    {
        string strTemp = this.name;
        string[] a = strTemp.Split('.');
        int Count = int.Parse(a[1]);

        Count += -(Count * 2) - 1;

        return Count;
    }
    int SplitNameOriNumber(string name)
    {
        string strTemp = this.name;
        string[] a = strTemp.Split('.');
        int Count = int.Parse(a[1]);

        Count += -(Count * 2) - 1;

        return Mathf.Abs(Count);
    }

    public void OnClick()
    {
        int index = SplitName(this.name);
        int Oriindex = SplitNameOriNumber(this.name);
        string temp;
        switch (gv.MapType)
        {
            case 1:
                temp = "NormalRobot." + Oriindex;
                CheckAlreradPlacementMiner(gv.ListHireCount, index, temp, Oriindex);
                break;
            case 2:
                temp = "DesertRobot." + Oriindex;
                CheckAlreradPlacementMiner(gv.ListHireDesertCount, index, temp, Oriindex);
                break;
            case 3:
                temp = "IceRobot." + Oriindex;
                CheckAlreradPlacementMiner(gv.ListHireIceCount, index, temp, Oriindex);
                break;
            case 4:
                temp = "ForestRobot." + Oriindex;
                CheckAlreradPlacementMiner(gv.ListHireForestCount, index, temp, Oriindex);
                break;
        }
        
    }

    void CheckAlreradPlacementMiner(List<int> MinerList,int index,string name,int Oriindex)
    {
        gv.bPlacementMiner = false;
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == index)
            {
                gv.bPlacementMiner = true;
            }
        }
        GameObject.Find("MainCanvas").GetComponent<RobotMoveManager>().Setindex(index, name, Oriindex);
        {
            GameObject.Find("MainCanvas").GetComponent<RobotMoveManager>().PressCraftRobotPanel(1);
        }
    }
}
