using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectEngine : MonoBehaviour {

    // Use this for initialization

    public GameObject Prograss;
    public GameObject PrograssBack;

    public GameObject TimePrograss;
    public GameObject TimePrograssBack;

    public GameObject Equipment;
    List<GameObject> EngineList = new List<GameObject>();
    List<GameObject> BitList = new List<GameObject>();
    GlobalVariable gv;
    List<int> listYPrograssPos = new List<int>();

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitData();
	}
	
    void InitData()
    {

        EngineList.Add(Equipment.transform.Find("DrillDefault").gameObject);
        BitList.Add(Equipment.transform.Find("BitDefault").gameObject);
        for (int i= 0; i< 14; i++)
        {
            int index = i + 1;
            string strEngineName = "Drill" + index;
            string strBitName = "Bit" + index;
            EngineList.Add(Equipment.transform.Find(strEngineName).gameObject);
            BitList.Add(Equipment.transform.Find(strBitName).gameObject);
        }
        SetYPrograssPos();
        SetEngine();
        SetDrill();
    }
    void SetYPrograssPos()
    {
        listYPrograssPos.Add(317);
        listYPrograssPos.Add(355); //1
        listYPrograssPos.Add(400); //2

        listYPrograssPos.Add(317); //3
        listYPrograssPos.Add(330); //4
        listYPrograssPos.Add(340); //5
        listYPrograssPos.Add(395); //6
        listYPrograssPos.Add(340); //7
        listYPrograssPos.Add(300); //8
        listYPrograssPos.Add(290); //9
        listYPrograssPos.Add(370); //10

        listYPrograssPos.Add(340); //11
        listYPrograssPos.Add(310); //12

        listYPrograssPos.Add(330); //13
        listYPrograssPos.Add(310); //14
    }


    public void SetEngine()
    {
        for(int i=0; i < EngineList.Count; i++)
        {
            if(i ==gv.EngineLv)
            {
                EngineList[i].SetActive(true);
            }
            else
            {
                EngineList[i].SetActive(false);
            }
        }
        SetDrill();
        SetPrograss();
    }

    void SetPrograss()
    {
        if(EngineList.Count>0)
        {
            Vector2 vec = new Vector2();
            vec.y = listYPrograssPos[gv.EngineLv];
            vec.x = 246;

            Prograss.transform.localPosition = vec;
            PrograssBack.transform.localPosition = vec;

            TimePrograss.transform.localPosition = vec;
            TimePrograssBack.transform.localPosition = vec;
        }
    }

    public void SetDrill()
    {
        for (int i = 0; i < BitList.Count; i++)
        {
            if (i == gv.BitLv)
            {
                BitList[i].SetActive(true);
            }
            else
            {
                BitList[i].SetActive(false);
            }
        }
    }
}
