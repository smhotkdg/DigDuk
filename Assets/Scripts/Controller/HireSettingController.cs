using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HireSettingController : MonoBehaviour {

    // Use this for initialization    
    public GameObject MInerList;
    List<int> yPosList = new List<int>();
    int xPosDefault_1 = -215;
    int xPosDefault_2 = 10;
    int yPosDefaultMargin = -350;
    List<GameObject> ListMiner = new List<GameObject>();
    GlobalVariable gv;
    public GameObject RobotList;
    List<GameObject> ListRobot = new List<GameObject>();

    Dictionary<int, GameObject> NormalRobotList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> DesertRobotList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> IceRobotList = new Dictionary<int, GameObject>();
    Dictionary<int, GameObject> ForestRobotList = new Dictionary<int, GameObject>();
    int robot_xMargin = -30;
    int robot_yMargin = 105;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitData();

    }
    public GameObject GetRobot(int index)
    {
        switch (gv.MapType)
        {
            case 1:
                List<int> keyListNormal = new List<int>(NormalRobotList.Keys);
                for (int k = 0; k < keyListNormal.Count; k++)
                {
                    if((-index) == keyListNormal[k])
                        return NormalRobotList[keyListNormal[k]];
                }
                break;
            case 2:
                List<int> keyListDesert = new List<int>(DesertRobotList.Keys);
                for (int k = 0; k < keyListDesert.Count; k++)
                {
                    if ((-index) == keyListDesert[k])
                        return DesertRobotList[keyListDesert[k]];
                }
                break;
            case 3:
                List<int> keyListIce = new List<int>(IceRobotList.Keys);
                for (int k = 0; k < keyListIce.Count; k++)
                {
                    if ((-index) == keyListIce[k])
                        return IceRobotList[keyListIce[k]];
                }
                break;
            case 4:
                List<int> keyListForest = new List<int>(ForestRobotList.Keys);
                for (int k = 0; k < keyListForest.Count; k++)
                {
                    if ((-index) == keyListForest[k])
                        return ForestRobotList[keyListForest[k]];
                }
                break;
        }
        return null;
    }

    public void UnsetInfoBtn()
    {
        if(NormalRobotList.Count !=0)
        {
            switch (gv.MapType)
            {
                case 1:
                    List<int> keyListNormal = new List<int>(NormalRobotList.Keys);
                    for (int k = 0; k < keyListNormal.Count; k++)
                    {
                        NormalRobotList[keyListNormal[k]].GetComponent<RobotMining>().UnSetInfo();
                    }
                    break;
                case 2:
                    List<int> keyListDesert = new List<int>(DesertRobotList.Keys);
                    for (int k = 0; k < keyListDesert.Count; k++)
                    {
                        DesertRobotList[keyListDesert[k]].GetComponent<RobotMining>().UnSetInfo();
                    }
                    break;
                case 3:
                    List<int> keyListIce = new List<int>(IceRobotList.Keys);
                    for (int k = 0; k < keyListIce.Count; k++)
                    {
                        IceRobotList[keyListIce[k]].GetComponent<RobotMining>().UnSetInfo();
                    }
                    break;
                case 4:
                    List<int> keyListForest = new List<int>(ForestRobotList.Keys);
                    for (int k = 0; k < keyListForest.Count; k++)
                    {
                        ForestRobotList[keyListForest[k]].GetComponent<RobotMining>().UnSetInfo();
                    }
                    break;
            }
        }
    }

    public void DeleteData()
    {
        ListMiner.Clear();
        yPosList.Clear();
        ListRobot.Clear();


        List<int> keyList = new List<int>(NormalRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            NormalRobotList[keyList[k]].SetActive(false);
            Destroy(NormalRobotList[keyList[k]]);
        }
        keyList = new List<int>(DesertRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            DesertRobotList[keyList[k]].SetActive(false);
            Destroy(DesertRobotList[keyList[k]]);
        }
        keyList = new List<int>(IceRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            IceRobotList[keyList[k]].SetActive(false);
            Destroy(IceRobotList[keyList[k]]);
        }
        keyList = new List<int>(ForestRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            ForestRobotList[keyList[k]].SetActive(false);
            Destroy(ForestRobotList[keyList[k]]);
        }

        

        NormalRobotList.Clear();
        DesertRobotList.Clear();
        IceRobotList.Clear();
        ForestRobotList.Clear();
    }
    public void InitData()
    {
        DeleteData();
        InitPos();
        InitMierList();
        InitSetHirePos();
    }

    public void SetDefaultSpeed(int iMinerIndex)
    {
        if(ListMiner[iMinerIndex].activeSelf == true)
            ListMiner[iMinerIndex].GetComponent<MinerDrillMouseDown>().SetDefaultSpeed();
    }
    void InitMierList()
    {
        for(int i =0; i< 110; i++)
        {
            int index = i + 1;
            string strMiner = "Miner" +index;
            ListMiner.Add(MInerList.transform.Find(strMiner).gameObject);
        }
        ListRobot.Add(RobotList.transform.Find("NormalRobot").gameObject);
        ListRobot.Add(RobotList.transform.Find("DesertRobot").gameObject);
        ListRobot.Add(RobotList.transform.Find("IceRobot").gameObject);
        ListRobot.Add(RobotList.transform.Find("ForestRobot").gameObject);


        CheckRobotList();
    }

    public void AddRobotLIst(int Pos,int pos2)
    {
        int index = pos2 + 1;
        string strRobot = "NormalRobot." + index;
        GameObject temp;
        if (gv.MapType == 1)
        {
            temp = Instantiate(ListRobot[0]);
            temp.transform.SetParent(ListRobot[0].transform.parent);
            temp.transform.localScale = ListRobot[0].transform.localScale;
            temp.transform.name = strRobot;
            NormalRobotList.Add(Pos, temp);
        }


        if (gv.MapType ==2 )
        {
            strRobot = "DesertRobot." + index;

            temp = Instantiate(ListRobot[1]);
            temp.transform.SetParent(ListRobot[1].transform.parent);
            temp.transform.localScale = ListRobot[1].transform.localScale;
            temp.transform.name = strRobot;
            DesertRobotList.Add(Pos, temp);
        }


        if (gv.MapType == 3)
        {
            strRobot = "IceRobot." + index;
            temp = Instantiate(ListRobot[2]);
            temp.transform.SetParent(ListRobot[2].transform.parent);
            temp.transform.localScale = ListRobot[2].transform.localScale;
            temp.transform.name = strRobot;
            IceRobotList.Add(Pos, temp);
        }

        if (gv.MapType == 4)
        {
            strRobot = "ForestRobot." + index;
            temp = Instantiate(ListRobot[3]);
            temp.transform.SetParent(ListRobot[3].transform.parent);
            temp.transform.localScale = ListRobot[3].transform.localScale;
            temp.transform.name = strRobot;
            ForestRobotList.Add(Pos, temp);
        }
    }
    public void CheckRobotList()
    {        
        for (int i = 0; i < 200; i++)
        {
            int index = (i + 1);
            string strRobot = string.Empty;
            GameObject temp;
            if (gv.RobotNormal[i] <0)
            {
                strRobot = "NormalRobot." + Mathf.Abs(gv.RobotNormal[i]);
                temp = Instantiate(ListRobot[0]);
                temp.transform.SetParent(ListRobot[0].transform.parent);
                temp.transform.localScale = ListRobot[0].transform.localScale;
                temp.transform.name = strRobot;
                NormalRobotList.Add(gv.RobotNormal[i], temp);
            }


            if (gv.RobotDesert[i] < 0)
            {
                strRobot = "DesertRobot." + Mathf.Abs(gv.RobotDesert[i]);

                temp = Instantiate(ListRobot[1]);
                temp.transform.SetParent(ListRobot[1].transform.parent);
                temp.transform.localScale = ListRobot[1].transform.localScale;
                temp.transform.name = strRobot;
                DesertRobotList.Add(gv.RobotDesert[i], temp);
            }
         

            if (gv.RobotIce[i] < 0)
            {
                strRobot = "IceRobot." + Mathf.Abs(gv.RobotIce[i]); 
                temp = Instantiate(ListRobot[2]);
                temp.transform.SetParent(ListRobot[2].transform.parent);
                temp.transform.localScale = ListRobot[2].transform.localScale;
                temp.transform.name = strRobot;
                IceRobotList.Add(gv.RobotIce[i], temp);
            }
          
            if (gv.RobotForest[i] < 0)
            {
                strRobot = "ForestRobot." + Mathf.Abs(gv.RobotForest[i]);
                temp = Instantiate(ListRobot[3]);
                temp.transform.SetParent(ListRobot[3].transform.parent);
                temp.transform.localScale = ListRobot[3].transform.localScale;
                temp.transform.name = strRobot;
                ForestRobotList.Add(gv.RobotForest[i], temp);
            }
       
        }

        List<int> keyList = new List<int>(NormalRobotList.Keys);
        for (int k =0; k< keyList.Count; k++)
        {
            NormalRobotList[keyList[k]].SetActive(false);
        }
        keyList = new List<int>(DesertRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            DesertRobotList[keyList[k]].SetActive(false);
        }
        keyList = new List<int>(IceRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            IceRobotList[keyList[k]].SetActive(false);
        }
        keyList = new List<int>(ForestRobotList.Keys);
        for (int k = 0; k < keyList.Count; k++)
        {
            ForestRobotList[keyList[k]].SetActive(false);
        }
    }
   
    void InitPos()
    {
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(130);
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(130);
        yPosList.Add(80);
        yPosList.Add(80);
        yPosList.Add(120);
        yPosList.Add(110);
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(90);
        yPosList.Add(100);
        yPosList.Add(70);
        yPosList.Add(120);
        yPosList.Add(100);
        yPosList.Add(93);
        yPosList.Add(90);
        yPosList.Add(75);
        yPosList.Add(75);
        yPosList.Add(45);
        yPosList.Add(90);
        yPosList.Add(80);
        yPosList.Add(90);
        yPosList.Add(90);
        yPosList.Add(90);
        yPosList.Add(85);
        yPosList.Add(90);
        yPosList.Add(50);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(85);
        yPosList.Add(100);
        yPosList.Add(90);
        yPosList.Add(100);
        yPosList.Add(105);
        yPosList.Add(105);
        yPosList.Add(140);
        yPosList.Add(140);
        yPosList.Add(140);
        yPosList.Add(100);
        yPosList.Add(105);
        yPosList.Add(90);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(90);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);

        //여기 추기해야됨
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(100);
        yPosList.Add(110);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(100);
        yPosList.Add(125);
    }
	// Update is called once per frame

    public void InitSetHirePos(bool temp = true)
    {   

        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    int iPos = Mathf.Abs(gv.ListHireCount[i]);
                    int index = Mathf.Abs(gv.ListHireCount[i]) % 2;
                    int depth = 0;
                    if (iPos == 1 || iPos == 2)
                        depth = 1;
                    if (iPos == 3 || iPos == 4)
                        depth = 2;
                    if (iPos == 5 || iPos == 6)
                        depth = 3;
                    if (iPos == 7 || iPos == 8)
                        depth = 4;
                    if (iPos == 9 || iPos == 10)
                        depth = 5;
                    if (iPos == 11 || iPos == 12)
                        depth = 6;
                    if (iPos == 13 || iPos == 14)
                        depth = 7;
                    if (iPos == 15 || iPos == 16)
                        depth = 8;
                    if (iPos == 17 || iPos == 18)
                        depth = 9;
                    if (iPos == 19 || iPos == 20)
                        depth = 10;
                    if (iPos == 21 || iPos == 22)
                        depth = 11;
                    if (iPos == 23 || iPos == 24)
                        depth = 12;
                    if (iPos == 25 || iPos == 26)
                        depth = 13;
                    if (iPos == 27 || iPos == 28)
                        depth = 14;

                    if (iPos == 29 || iPos == 30)
                        depth = 15;
                    if (iPos == 31 || iPos == 32)
                        depth = 16;
                    if (iPos == 33 || iPos == 34)
                        depth = 17;
                    if (iPos == 35 || iPos == 36)
                        depth = 18;
                    if (iPos == 37 || iPos == 38)
                        depth = 19;
                    if (iPos == 39 || iPos == 40)
                        depth = 20;
                    if (iPos == 41 || iPos == 42)
                        depth = 21;
                    if (iPos == 43 || iPos == 44)
                        depth = 22;
                    if (iPos == 45 || iPos == 46)
                        depth = 23;
                    if (iPos == 47 || iPos == 48)
                        depth = 24;
                    if (iPos == 49 || iPos == 50)
                        depth = 25;
                    if (iPos == 51 || iPos == 52)
                        depth = 26;
                    if (iPos == 53 || iPos == 54)
                        depth = 27;
                    if (iPos == 55 || iPos == 56)
                        depth = 28;

                    if (iPos == 57 || iPos == 58)
                        depth = 29;
                    if (iPos == 59 || iPos == 60)
                        depth = 30;
                    if (iPos == 61 || iPos == 62)
                        depth = 31;
                    if (iPos == 63 || iPos == 64)
                        depth = 32;
                    if (iPos == 65 || iPos == 66)
                        depth = 33;
                    if (iPos == 67 || iPos == 68)
                        depth = 34;
                    if (iPos == 69 || iPos == 70)
                        depth = 35;
                    if (iPos == 71 || iPos == 72)
                        depth = 36;
                    if (iPos == 73 || iPos == 74)
                        depth = 37;
                    if (iPos == 75 || iPos == 76)
                        depth = 38;
                    if (iPos == 77 || iPos == 78)
                        depth = 39;
                    if (iPos == 79 || iPos == 80)
                        depth = 40;
                    if (iPos == 81 || iPos == 82)
                        depth = 41;
                    if (iPos == 83 || iPos == 84)
                        depth = 42;
                    if (iPos == 85 || iPos == 86)
                        depth = 43;
                    if (iPos == 87 || iPos == 88)
                        depth = 44;
                    if (iPos == 89 || iPos == 90)
                        depth = 45;
                    if (iPos == 91 || iPos == 92)
                        depth = 46;
                    if (iPos == 93 || iPos == 94)
                        depth = 47;
                    if (iPos == 95 || iPos == 96)
                        depth = 48;
                    if (iPos == 97 || iPos == 98)
                        depth = 49;
                    if (iPos == 99 || iPos == 100)
                        depth = 50;
                    if (iPos == 101 || iPos == 102)
                        depth = 51;
                    if (iPos == 103 || iPos == 104)
                        depth = 52;
                    if (iPos == 105 || iPos == 106)
                        depth = 53;
                    if (iPos == 107 || iPos == 108)
                        depth = 54;
                    if (iPos == 109 || iPos == 110)
                        depth = 55;
                    if (iPos == 111 || iPos == 112)
                        depth = 56;
                    if (iPos == 113 || iPos == 114)
                        depth = 57;
                    if (iPos == 115 || iPos == 116)
                        depth = 58;

                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i];
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    ListMiner[i].transform.localPosition = pos;
                    ListMiner[i].SetActive(true);
                    if(temp == true)
                        gv.AddUniqueBuff(i);
                }
                else
                {
                    if (ListMiner[i].activeSelf == true)
                    {
                        ListMiner[i].SetActive(false);
                    }                    
                }
            }
            List<int> keyList = new List<int>(NormalRobotList.Keys);
            for (int i = 0; i < gv.RobotNormal.Count; i++)
            {                
                if (gv.RobotNormal[i] < 0)
                {
                    for(int k =0; k< keyList.Count;k++)
                    {
                        if(keyList[k] == gv.RobotNormal[i])
                        {                            
                            int iPos = Mathf.Abs(gv.RobotNormal[i]);
                            int index = Mathf.Abs(gv.RobotNormal[i]) % 2;
                            int depth = 0;
                            if (iPos == 1 || iPos == 2)
                                depth = 1;
                            if (iPos == 3 || iPos == 4)
                                depth = 2;
                            if (iPos == 5 || iPos == 6)
                                depth = 3;
                            if (iPos == 7 || iPos == 8)
                                depth = 4;
                            if (iPos == 9 || iPos == 10)
                                depth = 5;
                            if (iPos == 11 || iPos == 12)
                                depth = 6;
                            if (iPos == 13 || iPos == 14)
                                depth = 7;
                            if (iPos == 15 || iPos == 16)
                                depth = 8;
                            if (iPos == 17 || iPos == 18)
                                depth = 9;
                            if (iPos == 19 || iPos == 20)
                                depth = 10;
                            if (iPos == 21 || iPos == 22)
                                depth = 11;
                            if (iPos == 23 || iPos == 24)
                                depth = 12;
                            if (iPos == 25 || iPos == 26)
                                depth = 13;
                            if (iPos == 27 || iPos == 28)
                                depth = 14;

                            if (iPos == 29 || iPos == 30)
                                depth = 15;
                            if (iPos == 31 || iPos == 32)
                                depth = 16;
                            if (iPos == 33 || iPos == 34)
                                depth = 17;
                            if (iPos == 35 || iPos == 36)
                                depth = 18;
                            if (iPos == 37 || iPos == 38)
                                depth = 19;
                            if (iPos == 39 || iPos == 40)
                                depth = 20;
                            if (iPos == 41 || iPos == 42)
                                depth = 21;
                            if (iPos == 43 || iPos == 44)
                                depth = 22;
                            if (iPos == 45 || iPos == 46)
                                depth = 23;
                            if (iPos == 47 || iPos == 48)
                                depth = 24;
                            if (iPos == 49 || iPos == 50)
                                depth = 25;
                            if (iPos == 51 || iPos == 52)
                                depth = 26;
                            if (iPos == 53 || iPos == 54)
                                depth = 27;
                            if (iPos == 55 || iPos == 56)
                                depth = 28;

                            if (iPos == 57 || iPos == 58)
                                depth = 29;
                            if (iPos == 59 || iPos == 60)
                                depth = 30;
                            if (iPos == 61 || iPos == 62)
                                depth = 31;
                            if (iPos == 63 || iPos == 64)
                                depth = 32;
                            if (iPos == 65 || iPos == 66)
                                depth = 33;
                            if (iPos == 67 || iPos == 68)
                                depth = 34;
                            if (iPos == 69 || iPos == 70)
                                depth = 35;
                            if (iPos == 71 || iPos == 72)
                                depth = 36;
                            if (iPos == 73 || iPos == 74)
                                depth = 37;
                            if (iPos == 75 || iPos == 76)
                                depth = 38;
                            if (iPos == 77 || iPos == 78)
                                depth = 39;
                            if (iPos == 79 || iPos == 80)
                                depth = 40;
                            if (iPos == 81 || iPos == 82)
                                depth = 41;
                            if (iPos == 83 || iPos == 84)
                                depth = 42;
                            if (iPos == 85 || iPos == 86)
                                depth = 43;
                            if (iPos == 87 || iPos == 88)
                                depth = 44;
                            if (iPos == 89 || iPos == 90)
                                depth = 45;
                            if (iPos == 91 || iPos == 92)
                                depth = 46;
                            if (iPos == 93 || iPos == 94)
                                depth = 47;
                            if (iPos == 95 || iPos == 96)
                                depth = 48;
                            if (iPos == 97 || iPos == 98)
                                depth = 49;
                            if (iPos == 99 || iPos == 100)
                                depth = 50;
                            if (iPos == 101 || iPos == 102)
                                depth = 51;
                            if (iPos == 103 || iPos == 104)
                                depth = 52;
                            if (iPos == 105 || iPos == 106)
                                depth = 53;
                            if (iPos == 107 || iPos == 108)
                                depth = 54;
                            if (iPos == 109 || iPos == 110)
                                depth = 55;
                            if (iPos == 111 || iPos == 112)
                                depth = 56;
                            if (iPos == 113 || iPos == 114)
                                depth = 57;
                            if (iPos == 115 || iPos == 116)
                                depth = 58;

                            Vector3 pos = new Vector3();
                            pos.y = robot_yMargin;
                            Randrobot_xMargin();
                            if (index == 1)
                            {
                                pos.x = xPosDefault_1 + robot_xMargin;
                            }
                            else
                            {
                                pos.x = xPosDefault_2 + robot_xMargin;
                            }
                            pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                            NormalRobotList[gv.RobotNormal[i]].transform.localPosition = pos;
                            NormalRobotList[gv.RobotNormal[i]].SetActive(true);
                            float randSpeed = Random.Range(0.9f, 1.1f);
                            NormalRobotList[gv.RobotNormal[i]].GetComponent<Animator>().speed = randSpeed;
                            if(temp == true)
                                gv.AddRobotBuff(i);
                        }
                    }                           
                }
              
            }


        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] < 0)
                {
                    int iPos = Mathf.Abs(gv.ListHireDesertCount[i]);
                    int index = Mathf.Abs(gv.ListHireDesertCount[i]) % 2;
                    int depth = 0;
                    if (iPos == 1 || iPos == 2)
                        depth = 1;
                    if (iPos == 3 || iPos == 4)
                        depth = 2;
                    if (iPos == 5 || iPos == 6)
                        depth = 3;
                    if (iPos == 7 || iPos == 8)
                        depth = 4;
                    if (iPos == 9 || iPos == 10)
                        depth = 5;
                    if (iPos == 11 || iPos == 12)
                        depth = 6;
                    if (iPos == 13 || iPos == 14)
                        depth = 7;
                    if (iPos == 15 || iPos == 16)
                        depth = 8;
                    if (iPos == 17 || iPos == 18)
                        depth = 9;
                    if (iPos == 19 || iPos == 20)
                        depth = 10;
                    if (iPos == 21 || iPos == 22)
                        depth = 11;
                    if (iPos == 23 || iPos == 24)
                        depth = 12;
                    if (iPos == 25 || iPos == 26)
                        depth = 13;
                    if (iPos == 27 || iPos == 28)
                        depth = 14;

                    if (iPos == 29 || iPos == 30)
                        depth = 15;
                    if (iPos == 31 || iPos == 32)
                        depth = 16;
                    if (iPos == 33 || iPos == 34)
                        depth = 17;
                    if (iPos == 35 || iPos == 36)
                        depth = 18;
                    if (iPos == 37 || iPos == 38)
                        depth = 19;
                    if (iPos == 39 || iPos == 40)
                        depth = 20;
                    if (iPos == 41 || iPos == 42)
                        depth = 21;
                    if (iPos == 43 || iPos == 44)
                        depth = 22;
                    if (iPos == 45 || iPos == 46)
                        depth = 23;
                    if (iPos == 47 || iPos == 48)
                        depth = 24;
                    if (iPos == 49 || iPos == 50)
                        depth = 25;
                    if (iPos == 51 || iPos == 52)
                        depth = 26;
                    if (iPos == 53 || iPos == 54)
                        depth = 27;
                    if (iPos == 55 || iPos == 56)
                        depth = 28;

                    if (iPos == 57 || iPos == 58)
                        depth = 29;
                    if (iPos == 59 || iPos == 60)
                        depth = 30;
                    if (iPos == 61 || iPos == 62)
                        depth = 31;
                    if (iPos == 63 || iPos == 64)
                        depth = 32;
                    if (iPos == 65 || iPos == 66)
                        depth = 33;
                    if (iPos == 67 || iPos == 68)
                        depth = 34;
                    if (iPos == 69 || iPos == 70)
                        depth = 35;
                    if (iPos == 71 || iPos == 72)
                        depth = 36;
                    if (iPos == 73 || iPos == 74)
                        depth = 37;
                    if (iPos == 75 || iPos == 76)
                        depth = 38;
                    if (iPos == 77 || iPos == 78)
                        depth = 39;
                    if (iPos == 79 || iPos == 80)
                        depth = 40;
                    if (iPos == 81 || iPos == 82)
                        depth = 41;
                    if (iPos == 83 || iPos == 84)
                        depth = 42;
                    if (iPos == 85 || iPos == 86)
                        depth = 43;
                    if (iPos == 87 || iPos == 88)
                        depth = 44;
                    if (iPos == 89 || iPos == 90)
                        depth = 45;
                    if (iPos == 91 || iPos == 92)
                        depth = 46;
                    if (iPos == 93 || iPos == 94)
                        depth = 47;
                    if (iPos == 95 || iPos == 96)
                        depth = 48;
                    if (iPos == 97 || iPos == 98)
                        depth = 49;
                    if (iPos == 99 || iPos == 100)
                        depth = 50;
                    if (iPos == 101 || iPos == 102)
                        depth = 51;
                    if (iPos == 103 || iPos == 104)
                        depth = 52;
                    if (iPos == 105 || iPos == 106)
                        depth = 53;
                    if (iPos == 107 || iPos == 108)
                        depth = 54;
                    if (iPos == 109 || iPos == 110)
                        depth = 55;
                    if (iPos == 111 || iPos == 112)
                        depth = 56;
                    if (iPos == 113 || iPos == 114)
                        depth = 57;
                    if (iPos == 115 || iPos == 116)
                        depth = 58;

                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i];
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    ListMiner[i].transform.localPosition = pos;
                    ListMiner[i].SetActive(true);
                    if (temp == true)
                        gv.AddUniqueBuff(i);
                }
                else
                {
                    if (ListMiner[i].activeSelf == true)
                    {
                        ListMiner[i].SetActive(false);
                    }
                    //gv.DeleteQniqueBuff(i);
                }
            }
            List<int> keyList = new List<int>(DesertRobotList.Keys);
            for (int i = 0; i < gv.RobotDesert.Count; i++)
            {
                if (gv.RobotDesert[i] < 0)
                {
                    for (int k = 0; k < keyList.Count; k++)
                    {
                        if (keyList[k] == gv.RobotDesert[i])
                        {
                            int iPos = Mathf.Abs(gv.RobotDesert[i]);
                            int index = Mathf.Abs(gv.RobotDesert[i]) % 2;
                            int depth = 0;
                            if (iPos == 1 || iPos == 2)
                                depth = 1;
                            if (iPos == 3 || iPos == 4)
                                depth = 2;
                            if (iPos == 5 || iPos == 6)
                                depth = 3;
                            if (iPos == 7 || iPos == 8)
                                depth = 4;
                            if (iPos == 9 || iPos == 10)
                                depth = 5;
                            if (iPos == 11 || iPos == 12)
                                depth = 6;
                            if (iPos == 13 || iPos == 14)
                                depth = 7;
                            if (iPos == 15 || iPos == 16)
                                depth = 8;
                            if (iPos == 17 || iPos == 18)
                                depth = 9;
                            if (iPos == 19 || iPos == 20)
                                depth = 10;
                            if (iPos == 21 || iPos == 22)
                                depth = 11;
                            if (iPos == 23 || iPos == 24)
                                depth = 12;
                            if (iPos == 25 || iPos == 26)
                                depth = 13;
                            if (iPos == 27 || iPos == 28)
                                depth = 14;

                            if (iPos == 29 || iPos == 30)
                                depth = 15;
                            if (iPos == 31 || iPos == 32)
                                depth = 16;
                            if (iPos == 33 || iPos == 34)
                                depth = 17;
                            if (iPos == 35 || iPos == 36)
                                depth = 18;
                            if (iPos == 37 || iPos == 38)
                                depth = 19;
                            if (iPos == 39 || iPos == 40)
                                depth = 20;
                            if (iPos == 41 || iPos == 42)
                                depth = 21;
                            if (iPos == 43 || iPos == 44)
                                depth = 22;
                            if (iPos == 45 || iPos == 46)
                                depth = 23;
                            if (iPos == 47 || iPos == 48)
                                depth = 24;
                            if (iPos == 49 || iPos == 50)
                                depth = 25;
                            if (iPos == 51 || iPos == 52)
                                depth = 26;
                            if (iPos == 53 || iPos == 54)
                                depth = 27;
                            if (iPos == 55 || iPos == 56)
                                depth = 28;

                            if (iPos == 57 || iPos == 58)
                                depth = 29;
                            if (iPos == 59 || iPos == 60)
                                depth = 30;
                            if (iPos == 61 || iPos == 62)
                                depth = 31;
                            if (iPos == 63 || iPos == 64)
                                depth = 32;
                            if (iPos == 65 || iPos == 66)
                                depth = 33;
                            if (iPos == 67 || iPos == 68)
                                depth = 34;
                            if (iPos == 69 || iPos == 70)
                                depth = 35;
                            if (iPos == 71 || iPos == 72)
                                depth = 36;
                            if (iPos == 73 || iPos == 74)
                                depth = 37;
                            if (iPos == 75 || iPos == 76)
                                depth = 38;
                            if (iPos == 77 || iPos == 78)
                                depth = 39;
                            if (iPos == 79 || iPos == 80)
                                depth = 40;
                            if (iPos == 81 || iPos == 82)
                                depth = 41;
                            if (iPos == 83 || iPos == 84)
                                depth = 42;
                            if (iPos == 85 || iPos == 86)
                                depth = 43;
                            if (iPos == 87 || iPos == 88)
                                depth = 44;
                            if (iPos == 89 || iPos == 90)
                                depth = 45;
                            if (iPos == 91 || iPos == 92)
                                depth = 46;
                            if (iPos == 93 || iPos == 94)
                                depth = 47;
                            if (iPos == 95 || iPos == 96)
                                depth = 48;
                            if (iPos == 97 || iPos == 98)
                                depth = 49;
                            if (iPos == 99 || iPos == 100)
                                depth = 50;
                            if (iPos == 101 || iPos == 102)
                                depth = 51;
                            if (iPos == 103 || iPos == 104)
                                depth = 52;
                            if (iPos == 105 || iPos == 106)
                                depth = 53;
                            if (iPos == 107 || iPos == 108)
                                depth = 54;
                            if (iPos == 109 || iPos == 110)
                                depth = 55;
                            if (iPos == 111 || iPos == 112)
                                depth = 56;
                            if (iPos == 113 || iPos == 114)
                                depth = 57;
                            if (iPos == 115 || iPos == 116)
                                depth = 58;

                            Vector3 pos = new Vector3();
                            pos.y = robot_yMargin;
                            Randrobot_xMargin();
                            if (index == 1)
                            {
                                pos.x = xPosDefault_1 + robot_xMargin; 
                            }
                            else
                            {
                                pos.x = xPosDefault_2 + robot_xMargin; 
                            }
                            pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                            DesertRobotList[gv.RobotDesert[i]].transform.localPosition = pos;
                            DesertRobotList[gv.RobotDesert[i]].SetActive(true);
                            float randSpeed = Random.Range(0.9f, 1.1f);
                            DesertRobotList[gv.RobotDesert[i]].GetComponent<Animator>().speed = randSpeed;
                            if (temp == true)
                                gv.AddRobotBuff(i);
                        }
                    }
                }

            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] < 0)
                {
                    int iPos = Mathf.Abs(gv.ListHireIceCount[i]);
                    int index = Mathf.Abs(gv.ListHireIceCount[i]) % 2;
                    int depth = 0;
                    if (iPos == 1 || iPos == 2)
                        depth = 1;
                    if (iPos == 3 || iPos == 4)
                        depth = 2;
                    if (iPos == 5 || iPos == 6)
                        depth = 3;
                    if (iPos == 7 || iPos == 8)
                        depth = 4;
                    if (iPos == 9 || iPos == 10)
                        depth = 5;
                    if (iPos == 11 || iPos == 12)
                        depth = 6;
                    if (iPos == 13 || iPos == 14)
                        depth = 7;
                    if (iPos == 15 || iPos == 16)
                        depth = 8;
                    if (iPos == 17 || iPos == 18)
                        depth = 9;
                    if (iPos == 19 || iPos == 20)
                        depth = 10;
                    if (iPos == 21 || iPos == 22)
                        depth = 11;
                    if (iPos == 23 || iPos == 24)
                        depth = 12;
                    if (iPos == 25 || iPos == 26)
                        depth = 13;
                    if (iPos == 27 || iPos == 28)
                        depth = 14;

                    if (iPos == 29 || iPos == 30)
                        depth = 15;
                    if (iPos == 31 || iPos == 32)
                        depth = 16;
                    if (iPos == 33 || iPos == 34)
                        depth = 17;
                    if (iPos == 35 || iPos == 36)
                        depth = 18;
                    if (iPos == 37 || iPos == 38)
                        depth = 19;
                    if (iPos == 39 || iPos == 40)
                        depth = 20;
                    if (iPos == 41 || iPos == 42)
                        depth = 21;
                    if (iPos == 43 || iPos == 44)
                        depth = 22;
                    if (iPos == 45 || iPos == 46)
                        depth = 23;
                    if (iPos == 47 || iPos == 48)
                        depth = 24;
                    if (iPos == 49 || iPos == 50)
                        depth = 25;
                    if (iPos == 51 || iPos == 52)
                        depth = 26;
                    if (iPos == 53 || iPos == 54)
                        depth = 27;
                    if (iPos == 55 || iPos == 56)
                        depth = 28;

                    if (iPos == 57 || iPos == 58)
                        depth = 29;
                    if (iPos == 59 || iPos == 60)
                        depth = 30;
                    if (iPos == 61 || iPos == 62)
                        depth = 31;
                    if (iPos == 63 || iPos == 64)
                        depth = 32;
                    if (iPos == 65 || iPos == 66)
                        depth = 33;
                    if (iPos == 67 || iPos == 68)
                        depth = 34;
                    if (iPos == 69 || iPos == 70)
                        depth = 35;
                    if (iPos == 71 || iPos == 72)
                        depth = 36;
                    if (iPos == 73 || iPos == 74)
                        depth = 37;
                    if (iPos == 75 || iPos == 76)
                        depth = 38;
                    if (iPos == 77 || iPos == 78)
                        depth = 39;
                    if (iPos == 79 || iPos == 80)
                        depth = 40;
                    if (iPos == 81 || iPos == 82)
                        depth = 41;
                    if (iPos == 83 || iPos == 84)
                        depth = 42;
                    if (iPos == 85 || iPos == 86)
                        depth = 43;
                    if (iPos == 87 || iPos == 88)
                        depth = 44;
                    if (iPos == 89 || iPos == 90)
                        depth = 45;
                    if (iPos == 91 || iPos == 92)
                        depth = 46;
                    if (iPos == 93 || iPos == 94)
                        depth = 47;
                    if (iPos == 95 || iPos == 96)
                        depth = 48;
                    if (iPos == 97 || iPos == 98)
                        depth = 49;
                    if (iPos == 99 || iPos == 100)
                        depth = 50;
                    if (iPos == 101 || iPos == 102)
                        depth = 51;
                    if (iPos == 103 || iPos == 104)
                        depth = 52;
                    if (iPos == 105 || iPos == 106)
                        depth = 53;
                    if (iPos == 107 || iPos == 108)
                        depth = 54;
                    if (iPos == 109 || iPos == 110)
                        depth = 55;
                    if (iPos == 111 || iPos == 112)
                        depth = 56;
                    if (iPos == 113 || iPos == 114)
                        depth = 57;
                    if (iPos == 115 || iPos == 116)
                        depth = 58;

                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i];
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    ListMiner[i].transform.localPosition = pos;
                    ListMiner[i].SetActive(true);
                    if (temp == true)
                        gv.AddUniqueBuff(i);
                }
                else
                {
                    if (ListMiner[i].activeSelf == true)
                    {
                        ListMiner[i].SetActive(false);
                    }
                    //gv.DeleteQniqueBuff(i);
                }
            }
            List<int> keyList = new List<int>(IceRobotList.Keys);
            for (int i = 0; i < gv.RobotIce.Count; i++)
            {
                if (gv.RobotIce[i] < 0)
                {
                    for (int k = 0; k < keyList.Count; k++)
                    {
                        if (keyList[k] == gv.RobotIce[i])
                        {
                            int iPos = Mathf.Abs(gv.RobotIce[i]);
                            int index = Mathf.Abs(gv.RobotIce[i]) % 2;
                            int depth = 0;
                            if (iPos == 1 || iPos == 2)
                                depth = 1;
                            if (iPos == 3 || iPos == 4)
                                depth = 2;
                            if (iPos == 5 || iPos == 6)
                                depth = 3;
                            if (iPos == 7 || iPos == 8)
                                depth = 4;
                            if (iPos == 9 || iPos == 10)
                                depth = 5;
                            if (iPos == 11 || iPos == 12)
                                depth = 6;
                            if (iPos == 13 || iPos == 14)
                                depth = 7;
                            if (iPos == 15 || iPos == 16)
                                depth = 8;
                            if (iPos == 17 || iPos == 18)
                                depth = 9;
                            if (iPos == 19 || iPos == 20)
                                depth = 10;
                            if (iPos == 21 || iPos == 22)
                                depth = 11;
                            if (iPos == 23 || iPos == 24)
                                depth = 12;
                            if (iPos == 25 || iPos == 26)
                                depth = 13;
                            if (iPos == 27 || iPos == 28)
                                depth = 14;

                            if (iPos == 29 || iPos == 30)
                                depth = 15;
                            if (iPos == 31 || iPos == 32)
                                depth = 16;
                            if (iPos == 33 || iPos == 34)
                                depth = 17;
                            if (iPos == 35 || iPos == 36)
                                depth = 18;
                            if (iPos == 37 || iPos == 38)
                                depth = 19;
                            if (iPos == 39 || iPos == 40)
                                depth = 20;
                            if (iPos == 41 || iPos == 42)
                                depth = 21;
                            if (iPos == 43 || iPos == 44)
                                depth = 22;
                            if (iPos == 45 || iPos == 46)
                                depth = 23;
                            if (iPos == 47 || iPos == 48)
                                depth = 24;
                            if (iPos == 49 || iPos == 50)
                                depth = 25;
                            if (iPos == 51 || iPos == 52)
                                depth = 26;
                            if (iPos == 53 || iPos == 54)
                                depth = 27;
                            if (iPos == 55 || iPos == 56)
                                depth = 28;

                            if (iPos == 57 || iPos == 58)
                                depth = 29;
                            if (iPos == 59 || iPos == 60)
                                depth = 30;
                            if (iPos == 61 || iPos == 62)
                                depth = 31;
                            if (iPos == 63 || iPos == 64)
                                depth = 32;
                            if (iPos == 65 || iPos == 66)
                                depth = 33;
                            if (iPos == 67 || iPos == 68)
                                depth = 34;
                            if (iPos == 69 || iPos == 70)
                                depth = 35;
                            if (iPos == 71 || iPos == 72)
                                depth = 36;
                            if (iPos == 73 || iPos == 74)
                                depth = 37;
                            if (iPos == 75 || iPos == 76)
                                depth = 38;
                            if (iPos == 77 || iPos == 78)
                                depth = 39;
                            if (iPos == 79 || iPos == 80)
                                depth = 40;
                            if (iPos == 81 || iPos == 82)
                                depth = 41;
                            if (iPos == 83 || iPos == 84)
                                depth = 42;
                            if (iPos == 85 || iPos == 86)
                                depth = 43;
                            if (iPos == 87 || iPos == 88)
                                depth = 44;
                            if (iPos == 89 || iPos == 90)
                                depth = 45;
                            if (iPos == 91 || iPos == 92)
                                depth = 46;
                            if (iPos == 93 || iPos == 94)
                                depth = 47;
                            if (iPos == 95 || iPos == 96)
                                depth = 48;
                            if (iPos == 97 || iPos == 98)
                                depth = 49;
                            if (iPos == 99 || iPos == 100)
                                depth = 50;
                            if (iPos == 101 || iPos == 102)
                                depth = 51;
                            if (iPos == 103 || iPos == 104)
                                depth = 52;
                            if (iPos == 105 || iPos == 106)
                                depth = 53;
                            if (iPos == 107 || iPos == 108)
                                depth = 54;
                            if (iPos == 109 || iPos == 110)
                                depth = 55;
                            if (iPos == 111 || iPos == 112)
                                depth = 56;
                            if (iPos == 113 || iPos == 114)
                                depth = 57;
                            if (iPos == 115 || iPos == 116)
                                depth = 58;

                            Vector3 pos = new Vector3();
                            pos.y = robot_yMargin;
                            Randrobot_xMargin();
                            if (index == 1)
                            {
                                pos.x = xPosDefault_1 + robot_xMargin; 
                            }
                            else
                            {
                                pos.x = xPosDefault_2 + robot_xMargin; 
                            }
                            pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                            IceRobotList[gv.RobotIce[i]].transform.localPosition = pos;
                            IceRobotList[gv.RobotIce[i]].SetActive(true);
                            float randSpeed = Random.Range(0.9f, 1.1f);
                            IceRobotList[gv.RobotIce[i]].GetComponent<Animator>().speed = randSpeed;
                            if (temp == true)
                                gv.AddRobotBuff(i);
                        }                       
                    }
                }

            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] < 0)
                {
                    int iPos = Mathf.Abs(gv.ListHireForestCount[i]);
                    int index = Mathf.Abs(gv.ListHireForestCount[i]) % 2;
                    int depth = 0;
                    if (iPos == 1 || iPos == 2)
                        depth = 1;
                    if (iPos == 3 || iPos == 4)
                        depth = 2;
                    if (iPos == 5 || iPos == 6)
                        depth = 3;
                    if (iPos == 7 || iPos == 8)
                        depth = 4;
                    if (iPos == 9 || iPos == 10)
                        depth = 5;
                    if (iPos == 11 || iPos == 12)
                        depth = 6;
                    if (iPos == 13 || iPos == 14)
                        depth = 7;
                    if (iPos == 15 || iPos == 16)
                        depth = 8;
                    if (iPos == 17 || iPos == 18)
                        depth = 9;
                    if (iPos == 19 || iPos == 20)
                        depth = 10;
                    if (iPos == 21 || iPos == 22)
                        depth = 11;
                    if (iPos == 23 || iPos == 24)
                        depth = 12;
                    if (iPos == 25 || iPos == 26)
                        depth = 13;
                    if (iPos == 27 || iPos == 28)
                        depth = 14;

                    if (iPos == 29 || iPos == 30)
                        depth = 15;
                    if (iPos == 31 || iPos == 32)
                        depth = 16;
                    if (iPos == 33 || iPos == 34)
                        depth = 17;
                    if (iPos == 35 || iPos == 36)
                        depth = 18;
                    if (iPos == 37 || iPos == 38)
                        depth = 19;
                    if (iPos == 39 || iPos == 40)
                        depth = 20;
                    if (iPos == 41 || iPos == 42)
                        depth = 21;
                    if (iPos == 43 || iPos == 44)
                        depth = 22;
                    if (iPos == 45 || iPos == 46)
                        depth = 23;
                    if (iPos == 47 || iPos == 48)
                        depth = 24;
                    if (iPos == 49 || iPos == 50)
                        depth = 25;
                    if (iPos == 51 || iPos == 52)
                        depth = 26;
                    if (iPos == 53 || iPos == 54)
                        depth = 27;
                    if (iPos == 55 || iPos == 56)
                        depth = 28;

                    if (iPos == 57 || iPos == 58)
                        depth = 29;
                    if (iPos == 59 || iPos == 60)
                        depth = 30;
                    if (iPos == 61 || iPos == 62)
                        depth = 31;
                    if (iPos == 63 || iPos == 64)
                        depth = 32;
                    if (iPos == 65 || iPos == 66)
                        depth = 33;
                    if (iPos == 67 || iPos == 68)
                        depth = 34;
                    if (iPos == 69 || iPos == 70)
                        depth = 35;
                    if (iPos == 71 || iPos == 72)
                        depth = 36;
                    if (iPos == 73 || iPos == 74)
                        depth = 37;
                    if (iPos == 75 || iPos == 76)
                        depth = 38;
                    if (iPos == 77 || iPos == 78)
                        depth = 39;
                    if (iPos == 79 || iPos == 80)
                        depth = 40;
                    if (iPos == 81 || iPos == 82)
                        depth = 41;
                    if (iPos == 83 || iPos == 84)
                        depth = 42;
                    if (iPos == 85 || iPos == 86)
                        depth = 43;
                    if (iPos == 87 || iPos == 88)
                        depth = 44;
                    if (iPos == 89 || iPos == 90)
                        depth = 45;
                    if (iPos == 91 || iPos == 92)
                        depth = 46;
                    if (iPos == 93 || iPos == 94)
                        depth = 47;
                    if (iPos == 95 || iPos == 96)
                        depth = 48;
                    if (iPos == 97 || iPos == 98)
                        depth = 49;
                    if (iPos == 99 || iPos == 100)
                        depth = 50;
                    if (iPos == 101 || iPos == 102)
                        depth = 51;
                    if (iPos == 103 || iPos == 104)
                        depth = 52;
                    if (iPos == 105 || iPos == 106)
                        depth = 53;
                    if (iPos == 107 || iPos == 108)
                        depth = 54;
                    if (iPos == 109 || iPos == 110)
                        depth = 55;
                    if (iPos == 111 || iPos == 112)
                        depth = 56;
                    if (iPos == 113 || iPos == 114)
                        depth = 57;
                    if (iPos == 115 || iPos == 116)
                        depth = 58;

                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i];
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    ListMiner[i].transform.localPosition = pos;
                    ListMiner[i].SetActive(true);
                    if (temp == true)
                        gv.AddUniqueBuff(i);
                }
                else
                {
                    if (ListMiner[i].activeSelf == true)
                    {
                        ListMiner[i].SetActive(false);
                    }
                    //gv.DeleteQniqueBuff(i);
                }
            }
            List<int> keyList = new List<int>(ForestRobotList.Keys);
            for (int i = 0; i < gv.RobotForest.Count; i++)
            {
                if (gv.RobotForest[i] < 0)
                {
                    for (int k = 0; k < keyList.Count; k++)
                    {
                        if (keyList[k] == gv.RobotForest[i])
                        {
                            int iPos = Mathf.Abs(gv.RobotForest[i]);
                            int index = Mathf.Abs(gv.RobotForest[i]) % 2;
                            int depth = 0;
                            if (iPos == 1 || iPos == 2)
                                depth = 1;
                            if (iPos == 3 || iPos == 4)
                                depth = 2;
                            if (iPos == 5 || iPos == 6)
                                depth = 3;
                            if (iPos == 7 || iPos == 8)
                                depth = 4;
                            if (iPos == 9 || iPos == 10)
                                depth = 5;
                            if (iPos == 11 || iPos == 12)
                                depth = 6;
                            if (iPos == 13 || iPos == 14)
                                depth = 7;
                            if (iPos == 15 || iPos == 16)
                                depth = 8;
                            if (iPos == 17 || iPos == 18)
                                depth = 9;
                            if (iPos == 19 || iPos == 20)
                                depth = 10;
                            if (iPos == 21 || iPos == 22)
                                depth = 11;
                            if (iPos == 23 || iPos == 24)
                                depth = 12;
                            if (iPos == 25 || iPos == 26)
                                depth = 13;
                            if (iPos == 27 || iPos == 28)
                                depth = 14;

                            if (iPos == 29 || iPos == 30)
                                depth = 15;
                            if (iPos == 31 || iPos == 32)
                                depth = 16;
                            if (iPos == 33 || iPos == 34)
                                depth = 17;
                            if (iPos == 35 || iPos == 36)
                                depth = 18;
                            if (iPos == 37 || iPos == 38)
                                depth = 19;
                            if (iPos == 39 || iPos == 40)
                                depth = 20;
                            if (iPos == 41 || iPos == 42)
                                depth = 21;
                            if (iPos == 43 || iPos == 44)
                                depth = 22;
                            if (iPos == 45 || iPos == 46)
                                depth = 23;
                            if (iPos == 47 || iPos == 48)
                                depth = 24;
                            if (iPos == 49 || iPos == 50)
                                depth = 25;
                            if (iPos == 51 || iPos == 52)
                                depth = 26;
                            if (iPos == 53 || iPos == 54)
                                depth = 27;
                            if (iPos == 55 || iPos == 56)
                                depth = 28;

                            if (iPos == 57 || iPos == 58)
                                depth = 29;
                            if (iPos == 59 || iPos == 60)
                                depth = 30;
                            if (iPos == 61 || iPos == 62)
                                depth = 31;
                            if (iPos == 63 || iPos == 64)
                                depth = 32;
                            if (iPos == 65 || iPos == 66)
                                depth = 33;
                            if (iPos == 67 || iPos == 68)
                                depth = 34;
                            if (iPos == 69 || iPos == 70)
                                depth = 35;
                            if (iPos == 71 || iPos == 72)
                                depth = 36;
                            if (iPos == 73 || iPos == 74)
                                depth = 37;
                            if (iPos == 75 || iPos == 76)
                                depth = 38;
                            if (iPos == 77 || iPos == 78)
                                depth = 39;
                            if (iPos == 79 || iPos == 80)
                                depth = 40;
                            if (iPos == 81 || iPos == 82)
                                depth = 41;
                            if (iPos == 83 || iPos == 84)
                                depth = 42;
                            if (iPos == 85 || iPos == 86)
                                depth = 43;
                            if (iPos == 87 || iPos == 88)
                                depth = 44;
                            if (iPos == 89 || iPos == 90)
                                depth = 45;
                            if (iPos == 91 || iPos == 92)
                                depth = 46;
                            if (iPos == 93 || iPos == 94)
                                depth = 47;
                            if (iPos == 95 || iPos == 96)
                                depth = 48;
                            if (iPos == 97 || iPos == 98)
                                depth = 49;
                            if (iPos == 99 || iPos == 100)
                                depth = 50;
                            if (iPos == 101 || iPos == 102)
                                depth = 51;
                            if (iPos == 103 || iPos == 104)
                                depth = 52;
                            if (iPos == 105 || iPos == 106)
                                depth = 53;
                            if (iPos == 107 || iPos == 108)
                                depth = 54;
                            if (iPos == 109 || iPos == 110)
                                depth = 55;
                            if (iPos == 111 || iPos == 112)
                                depth = 56;
                            if (iPos == 113 || iPos == 114)
                                depth = 57;
                            if (iPos == 115 || iPos == 116)
                                depth = 58;

                            Vector3 pos = new Vector3();
                            pos.y = robot_yMargin;
                            Randrobot_xMargin();
                            if (index == 1)
                            {
                                pos.x = xPosDefault_1 + robot_xMargin; 
                            }
                            else
                            {
                                pos.x = xPosDefault_2 + robot_xMargin; 
                            }
                            pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                            ForestRobotList[gv.RobotForest[i]].transform.localPosition = pos;
                            ForestRobotList[gv.RobotForest[i]].SetActive(true);
                            float randSpeed = Random.Range(0.9f, 1.1f);
                            ForestRobotList[gv.RobotForest[i]].GetComponent<Animator>().speed = randSpeed;
                            if (temp == true)
                                gv.AddRobotBuff(i);
                        }
                      
                    }
                }

            }
        }
    }
 


    public void SetHirePos(string name,int position)
    {
        int iPos = Mathf.Abs(position);
        int index = Mathf.Abs(position) % 2;
        int depth  = 0;

        if(gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] == position)
                {
                    gv.ListHireCount[i] = 1;
                    ListMiner[i].SetActive(false);
                    int indexMiner = i + 1;
                    string strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[i]);
                    PlayerPrefs.Save();

                    gv.DeleteQniqueBuff(i);
                }
            }      
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] == position)
                {
                    gv.ListHireDesertCount[i] = 1;
                    ListMiner[i].SetActive(false);
                    int indexMiner = i + 1;
                    string strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }
     
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] == position)
                {
                    gv.ListHireIceCount[i] = 1;
                    ListMiner[i].SetActive(false);
                    int indexMiner = i + 1;
                    string strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }
         
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] == position)
                {
                    gv.ListHireForestCount[i] = 1;
                    ListMiner[i].SetActive(false);
                    int indexMiner = i + 1;
                    string strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }

        }



        if (iPos == 1 || iPos == 2)
            depth = 1;
        if (iPos == 3 || iPos == 4)
            depth = 2;
        if (iPos == 5 || iPos == 6)
            depth = 3;
        if (iPos == 7 || iPos == 8)
            depth = 4;
        if (iPos == 9 || iPos == 10)
            depth = 5;
        if (iPos == 11 || iPos == 12)
            depth = 6;
        if (iPos == 13 || iPos == 14)
            depth = 7;
        if (iPos == 15 || iPos == 16)
            depth = 8;
        if (iPos == 17 || iPos == 18)
            depth = 9;
        if (iPos == 19 || iPos == 20)
            depth = 10;
        if (iPos == 21 || iPos == 22)
            depth = 11;
        if (iPos == 23 || iPos == 24)
            depth = 12;
        if (iPos == 25 || iPos == 26)
            depth = 13;
        if (iPos == 27 || iPos == 28)
            depth = 14;

        if (iPos == 29 || iPos == 30)
            depth = 15;
        if (iPos == 31 || iPos == 32)
            depth =16;
        if (iPos == 33 || iPos == 34)
            depth = 17;
        if (iPos == 35 || iPos == 36)
            depth = 18;
        if (iPos == 37 || iPos == 38)
            depth =19;
        if (iPos == 39 || iPos == 40)
            depth = 20;
        if (iPos == 41 || iPos == 42)
            depth =21;
        if (iPos == 43 || iPos == 44)
            depth = 22;
        if (iPos == 45 || iPos == 46)
            depth = 23;
        if (iPos == 47 || iPos == 48)
            depth = 24;
        if (iPos == 49 || iPos == 50)
            depth = 25;
        if (iPos == 51 || iPos == 52)
            depth = 26;
        if (iPos == 53 || iPos == 54)
            depth = 27;
        if (iPos == 55 || iPos == 56)
            depth = 28;

        if (iPos == 57 || iPos == 58)
            depth = 29;
        if (iPos == 59 || iPos == 60)
            depth = 30;
        if (iPos == 61 || iPos == 62)
            depth = 31;
        if (iPos == 63 || iPos == 64)
            depth = 32;
        if (iPos == 65 || iPos == 66)
            depth = 33;
        if (iPos == 67 || iPos == 68)
            depth = 34;
        if (iPos == 69 || iPos == 70)
            depth = 35;
        if (iPos == 71 || iPos == 72)
            depth = 36;
        if (iPos == 73 || iPos == 74)
            depth = 37;
        if (iPos == 75 || iPos == 76)
            depth = 38;
        if (iPos == 77 || iPos == 78)
            depth = 39;
        if (iPos == 79 || iPos == 80)
            depth = 40;
        if (iPos == 81 || iPos == 82)
            depth = 41;
        if (iPos == 83 || iPos == 84)
            depth = 42;
        if (iPos == 85 || iPos == 86)
            depth = 43;
        if (iPos == 87 || iPos == 88)
            depth = 44;
        if (iPos == 89 || iPos == 90)
            depth = 45;
        if (iPos == 91 || iPos == 92)
            depth = 46;
        if (iPos == 93 || iPos == 94)
            depth = 47;
        if (iPos == 95 || iPos == 96)
            depth = 48;
        if (iPos == 97 || iPos == 98)
            depth = 49;
        if (iPos == 99 || iPos == 100)
            depth = 50;
        if (iPos == 101 || iPos == 102)
            depth = 51;
        if (iPos == 103 || iPos == 104)
            depth = 52;
        if (iPos == 105 || iPos == 106)
            depth = 53;
        if (iPos == 107 || iPos == 108)
            depth = 54;
        if (iPos == 109 || iPos == 110)
            depth = 55;
        if (iPos == 111 || iPos == 112)
            depth = 56;
        if (iPos == 113 || iPos == 114)
            depth = 57;
        if (iPos == 115 || iPos == 116)
            depth = 58;

        if(gv.MapType ==1)
        {
            for (int i = 0; i < ListMiner.Count; i++)
            {
                if (ListMiner[i].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    ListMiner[i].transform.localPosition = pos;
                    gv.ListHireCount[i] = position;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCombination(position,i);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[i]);
                    strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    PlayerPrefs.Save();

                    gv.ListHireDesertCount[i] = 1000;
                    gv.ListHireIceCount[i] = 1000;
                    gv.ListHireForestCount[i] = 1000;

                    ListMiner[i].SetActive(true);

                    gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < ListMiner.Count; i++)
            {
                if (ListMiner[i].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    ListMiner[i].transform.localPosition = pos;
                    gv.ListHireDesertCount[i] = position;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCombination(position, i);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[i]);

                    
                    strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    PlayerPrefs.Save();

                    gv.ListHireCount[i] = 1000;
                    gv.ListHireIceCount[i] = 1000;
                    gv.ListHireForestCount[i] = 1000;

                    ListMiner[i].SetActive(true);
                    gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < ListMiner.Count; i++)
            {
                if (ListMiner[i].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    ListMiner[i].transform.localPosition = pos;
                    gv.ListHireIceCount[i] = position;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCombination(position, i);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[i]);
                    strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);

                    gv.ListHireCount[i] = 1000;
                    gv.ListHireDesertCount[i] = 1000;
                    gv.ListHireForestCount[i] = 1000;

                    PlayerPrefs.Save();

                    ListMiner[i].SetActive(true);
                    gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < ListMiner.Count; i++)
            {
                if (ListMiner[i].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = yPosList[i] + (yPosDefaultMargin * (depth - 1));
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1;
                    }
                    else
                    {
                        pos.x = xPosDefault_2;
                    }
                    ListMiner[i].transform.localPosition = pos;
                    gv.ListHireForestCount[i] = position;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCombination(position, i);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[i]);

                    strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);
                    strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, 1000);


                    gv.ListHireCount[i] = 1000;
                    gv.ListHireDesertCount[i] = 1000;
                    gv.ListHireIceCount[i] = 1000;
           

                    PlayerPrefs.Save();

                    ListMiner[i].SetActive(true);
                    gv.AddUniqueBuff(i);
                }
            }
        }

    }

    public void SetRobotPos(string name, int position)
    {
        int iPos = Mathf.Abs(position);
        int index = Mathf.Abs(position) % 2;
        int depth = 0;

        if (iPos == 1 || iPos == 2)
            depth = 1;
        if (iPos == 3 || iPos == 4)
            depth = 2;
        if (iPos == 5 || iPos == 6)
            depth = 3;
        if (iPos == 7 || iPos == 8)
            depth = 4;
        if (iPos == 9 || iPos == 10)
            depth = 5;
        if (iPos == 11 || iPos == 12)
            depth = 6;
        if (iPos == 13 || iPos == 14)
            depth = 7;
        if (iPos == 15 || iPos == 16)
            depth = 8;
        if (iPos == 17 || iPos == 18)
            depth = 9;
        if (iPos == 19 || iPos == 20)
            depth = 10;
        if (iPos == 21 || iPos == 22)
            depth = 11;
        if (iPos == 23 || iPos == 24)
            depth = 12;
        if (iPos == 25 || iPos == 26)
            depth = 13;
        if (iPos == 27 || iPos == 28)
            depth = 14;

        if (iPos == 29 || iPos == 30)
            depth = 15;
        if (iPos == 31 || iPos == 32)
            depth = 16;
        if (iPos == 33 || iPos == 34)
            depth = 17;
        if (iPos == 35 || iPos == 36)
            depth = 18;
        if (iPos == 37 || iPos == 38)
            depth = 19;
        if (iPos == 39 || iPos == 40)
            depth = 20;
        if (iPos == 41 || iPos == 42)
            depth = 21;
        if (iPos == 43 || iPos == 44)
            depth = 22;
        if (iPos == 45 || iPos == 46)
            depth = 23;
        if (iPos == 47 || iPos == 48)
            depth = 24;
        if (iPos == 49 || iPos == 50)
            depth = 25;
        if (iPos == 51 || iPos == 52)
            depth = 26;
        if (iPos == 53 || iPos == 54)
            depth = 27;
        if (iPos == 55 || iPos == 56)
            depth = 28;

        if (iPos == 57 || iPos == 58)
            depth = 29;
        if (iPos == 59 || iPos == 60)
            depth = 30;
        if (iPos == 61 || iPos == 62)
            depth = 31;
        if (iPos == 63 || iPos == 64)
            depth = 32;
        if (iPos == 65 || iPos == 66)
            depth = 33;
        if (iPos == 67 || iPos == 68)
            depth = 34;
        if (iPos == 69 || iPos == 70)
            depth = 35;
        if (iPos == 71 || iPos == 72)
            depth = 36;
        if (iPos == 73 || iPos == 74)
            depth = 37;
        if (iPos == 75 || iPos == 76)
            depth = 38;
        if (iPos == 77 || iPos == 78)
            depth = 39;
        if (iPos == 79 || iPos == 80)
            depth = 40;
        if (iPos == 81 || iPos == 82)
            depth = 41;
        if (iPos == 83 || iPos == 84)
            depth = 42;
        if (iPos == 85 || iPos == 86)
            depth = 43;
        if (iPos == 87 || iPos == 88)
            depth = 44;
        if (iPos == 89 || iPos == 90)
            depth = 45;
        if (iPos == 91 || iPos == 92)
            depth = 46;
        if (iPos == 93 || iPos == 94)
            depth = 47;
        if (iPos == 95 || iPos == 96)
            depth = 48;
        if (iPos == 97 || iPos == 98)
            depth = 49;
        if (iPos == 99 || iPos == 100)
            depth = 50;
        if (iPos == 101 || iPos == 102)
            depth = 51;
        if (iPos == 103 || iPos == 104)
            depth = 52;
        if (iPos == 105 || iPos == 106)
            depth = 53;
        if (iPos == 107 || iPos == 108)
            depth = 54;
        if (iPos == 109 || iPos == 110)
            depth = 55;
        if (iPos == 111 || iPos == 112)
            depth = 56;
        if (iPos == 113 || iPos == 114)
            depth = 57;
        if (iPos == 115 || iPos == 116)
            depth = 58;

        if (gv.MapType == 1)
        {
            List<int> keyList = new List<int>(NormalRobotList.Keys);
            for (int i = 0; i < NormalRobotList.Count; i++)
            {
                if (NormalRobotList[keyList[i]].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                    Randrobot_xMargin();
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1 + robot_xMargin;
                    }
                    else
                    {
                        pos.x = xPosDefault_2 + robot_xMargin;
                    }
                    NormalRobotList[keyList[i]].transform.localPosition = pos;
                    gv.RobotNormal[i] = position;                    
                    
                    int indexMiner = i + 1;
                    string strHireCount = "RobotNormal" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.RobotNormal[i]);
                    PlayerPrefs.Save();



                    NormalRobotList[keyList[i]].SetActive(true);

                    float randSpeed = Random.Range(0.9f, 1.1f);
                    NormalRobotList[gv.RobotNormal[i]].GetComponent<Animator>().speed = randSpeed;

                    //gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 2)
        {
            List<int> keyList = new List<int>(DesertRobotList.Keys);
            for (int i = 0; i < DesertRobotList.Count; i++)
            {
                if (DesertRobotList[keyList[i]].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                    Randrobot_xMargin();
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1 + robot_xMargin;
                    }
                    else
                    {
                        pos.x = xPosDefault_2 + robot_xMargin;
                    }
                    DesertRobotList[keyList[i]].transform.localPosition = pos;
                    gv.RobotDesert[i] = position;

                    int indexMiner = i + 1;
                    string strHireCount = "RobotDesert" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.RobotDesert[i]);
                    PlayerPrefs.Save();



                    DesertRobotList[keyList[i]].SetActive(true);

                    float randSpeed = Random.Range(0.9f, 1.1f);
                    DesertRobotList[gv.RobotDesert[i]].GetComponent<Animator>().speed = randSpeed;
                    //gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 3)
        {
            List<int> keyList = new List<int>(IceRobotList.Keys);
            for (int i = 0; i < IceRobotList.Count; i++)
            {
                if (IceRobotList[keyList[i]].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));
                    Randrobot_xMargin();
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1 + robot_xMargin;
                    }
                    else
                    {
                        pos.x = xPosDefault_2 + robot_xMargin;
                    }
                    IceRobotList[keyList[i]].transform.localPosition = pos;
                    gv.RobotIce[i] = position;

                    int indexMiner = i + 1;
                    string strHireCount = "RobotIce" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.RobotIce[i]);
                    PlayerPrefs.Save();



                    IceRobotList[keyList[i]].SetActive(true);

                    float randSpeed = Random.Range(0.9f, 1.1f);
                    IceRobotList[gv.RobotIce[i]].GetComponent<Animator>().speed = randSpeed;
                    //gv.AddUniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 4)
        {
            List<int> keyList = new List<int>(ForestRobotList.Keys);
            for (int i = 0; i < ForestRobotList.Count; i++)
            {
                if (ForestRobotList[keyList[i]].name == name)
                {
                    Vector3 pos = new Vector3();
                    pos.y = robot_yMargin + (yPosDefaultMargin * (depth - 1));

                    Randrobot_xMargin();
                    if (index == 1)
                    {
                        pos.x = xPosDefault_1 + robot_xMargin;
                    }
                    else
                    {
                        pos.x = xPosDefault_2 + robot_xMargin;
                    }
                    ForestRobotList[keyList[i]].transform.localPosition = pos;
                    gv.RobotForest[i] = position;

                    int indexMiner = i + 1;
                    string strHireCount = "RobotForest" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.RobotForest[i]);
                    PlayerPrefs.Save();



                    ForestRobotList[keyList[i]].SetActive(true);

                    float randSpeed = Random.Range(0.9f, 1.1f);
                    ForestRobotList[gv.RobotForest[i]].GetComponent<Animator>().speed = randSpeed;
                    //gv.AddUniqueBuff(i);
                }
            }
        }

    }
    void Randrobot_xMargin()
    {
        robot_xMargin = Random.Range(-25, -35);
    }
    void BuffCancel(List<int> HireList,int isBuffMinerIndex,int i)
    {
        for (int k = 0; k < HireList.Count; k++)
        {
            if (HireList[k] == isBuffMinerIndex)
            {
                if (gv.BuffType[k] == 5)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[k] + " 채굴량 취소");
                    gv.eachMiningPower[i] -= gv.BuffPower[k];
                }
                if (gv.BuffType[k] == 6)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[k] + " 드릴파워 취소");
                    gv.DrillBuffPower -= gv.BuffPower[k];
                }
                if (gv.BuffType[k] == 7)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[k] + " 채굴스피드 취소");
                    gv.eachMiningSpeed[i] -= gv.BuffPower[k];                    
                }
                if (gv.BuffType[k] == 8)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[k] + " 판매량 취소");
                    gv.eachSellPower[i] -= gv.BuffPower[k];
                }
            }
        }
    }

    void BuffCancelBuffMiner(List<int> HireList, int isBuffMinerIndex, int i)
    {
        for (int k = 0; k < HireList.Count; k++)
        {
            if (HireList[k] == isBuffMinerIndex)
            {
                if (gv.BuffType[i] == 5)
                {
                    Debug.Log(k + " 마이너 " + gv.BuffPower[i] + " 채굴량 취소");
                    gv.eachMiningPower[k] -= gv.BuffPower[i];
                }
                if (gv.BuffType[i] == 6)
                {
                    Debug.Log(k + " 마이너 " + gv.BuffPower[i] + " 드릴파워 취소");
                    gv.DrillBuffPower -= gv.BuffPower[i];
                }
                if (gv.BuffType[i] == 7)
                {
                    Debug.Log(k + " 마이너 " + gv.BuffPower[i] + " 채굴스피드 취소");
                    gv.eachMiningSpeed[k] -= gv.BuffPower[i];                    
                }
                if (gv.BuffType[i] == 8)
                {
                    Debug.Log(k + " 마이너 " + gv.BuffPower[i] + " 판매량 취소");
                    gv.eachSellPower[k] -= gv.BuffPower[i];
                }
            }
        }
    }

    public void DeleteHirePos(int position)
    {
        int isBuffMinerIndex;
        if (Mathf.Abs(position) % 2 == 0)
        {
            isBuffMinerIndex = position + 1;
        }
        else
        {
            isBuffMinerIndex = position - 1;
        }

        if (gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {                
                if (gv.ListHireCount[i] == position)
                {
                    if (gv.MiningType[i] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetBuff(gv.GetDepthPos(position));
                        BuffCancelBuffMiner(gv.ListHireCount, isBuffMinerIndex, i);
                    }
                    else
                    {
                        BuffCancel(gv.ListHireCount, isBuffMinerIndex, i);
                    }
                    
                    gv.ListHireCount[i] = 1;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DisableCombination(i,position);
                    ListMiner[i].SetActive(false);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }

 
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] == position)
                {
                    if (gv.MiningType[i] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetBuff(gv.GetDepthPos(position));
                        BuffCancelBuffMiner(gv.ListHireDesertCount, isBuffMinerIndex, i);
                    }
                    else
                    {
                        BuffCancel(gv.ListHireDesertCount, isBuffMinerIndex, i);
                    }

                    gv.ListHireDesertCount[i] = 1;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DisableCombination(i, position);
                    ListMiner[i].SetActive(false);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireDesertCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] == position)
                {
                    if (gv.MiningType[i] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetBuff(gv.GetDepthPos(position));
                        BuffCancelBuffMiner(gv.ListHireIceCount, isBuffMinerIndex, i);
                    }
                    else
                    {
                        BuffCancel(gv.ListHireIceCount, isBuffMinerIndex, i);
                    }

                    gv.ListHireIceCount[i] = 1;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DisableCombination(i, position);
                    ListMiner[i].SetActive(false);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireIceCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] == position)
                {
                    if (gv.MiningType[i] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetBuff(gv.GetDepthPos(position));
                        BuffCancelBuffMiner(gv.ListHireForestCount, isBuffMinerIndex, i);
                    }
                    else
                    {
                        BuffCancel(gv.ListHireForestCount, isBuffMinerIndex, i);
                    }


                    gv.ListHireForestCount[i] = 1;
                    GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DisableCombination(i, position);
                    ListMiner[i].SetActive(false);
                    //이동 저장
                    int indexMiner = i + 1;
                    string strHireCount = "HireForestCount" + indexMiner;
                    PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[i]);
                    PlayerPrefs.Save();
                    gv.DeleteQniqueBuff(i);
                }
            }
        }

    }

    public void DeleteAll()
    {
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().ViewCardReset();
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().DisableCombinationAll();
        if (gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    gv.ListHireCount[i] = 1;
                    ListMiner[i].SetActive(false);
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] < 0)
                {
                    gv.ListHireDesertCount[i] = 1;
                    ListMiner[i].SetActive(false);
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] < 0)
                {
                    gv.ListHireIceCount[i] = 1;
                    ListMiner[i].SetActive(false);
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] < 0)
                {
                    gv.ListHireForestCount[i] = 1;
                    ListMiner[i].SetActive(false);
                }
            }
        }


        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitCardSetting();
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();
    }
}
