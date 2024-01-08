using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HardCodeLab.TutorialMaster;
public class SelectCardClick : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusObj;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        
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
        string strTemp = name;
        string[] a = strTemp.Split('.');
        int Count = int.Parse(a[1]);

        return Count;
    }
    int SplitMinerName(string name)
    {
        if (name == "")
            return 0;
        string strTemp = name;
        string[] a = strTemp.Split('r');
        int Count = int.Parse(a[1]);

        return Count;
    }

    public bool CheckbetweenBuff(List<int> MinerList, int Pos)
    {
        int selectMinerNumber = SplitMinerName(gv.strCharacterSelect);
        int isBuffMinerIndex = 0;
        if (Mathf.Abs(Pos) % 2 == 0)
        {
            isBuffMinerIndex = Pos + 1;
        }
        else
        {
            isBuffMinerIndex = Pos - 1;
        }
      
        int nextPos = -1;
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBuffMinerIndex)
            {
                nextPos = i;
            }         
        }
        if (nextPos >= 0)
        {
            if (gv.MiningType[selectMinerNumber-1] == 0 && gv.MiningType[nextPos] == 0)
            {
                return true;
            }
        }

        return false;
    }
    public TutorialMasterManager tmManager;
    public bool CheckbetweenRobot(List<int> MinerList, int Pos)
    {
        int selectMinerNumber = SplitMinerName(gv.strCharacterSelect);
        int isBuffMinerIndex = 0;
        if (Mathf.Abs(Pos) % 2 == 0)
        {
            isBuffMinerIndex = Pos + 1;
        }
        else
        {
            isBuffMinerIndex = Pos - 1;
        }

        int nextPos = -1;
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBuffMinerIndex)
            {
                nextPos = i;
            }
        }
        if (nextPos >= 0)
        {
            if (gv.MiningType[selectMinerNumber - 1] == 0 && MinerList[nextPos] != 0)
            {
                return true;
            }
        }

        return false;
    }
    public void OnClick()
    {
        //if(gv.isOpening )
        {            
            if (tmManager.IsPlaying)
                tmManager.NextStage();
        }

        if (gv.bClickCard == true)
        {
            int index = SplitName(this.name);
            if (gv.MapType == 1)
            {
                if (true == CheckbetweenBuff(gv.ListHireCount, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
                if (true == CheckbetweenRobot(gv.RobotNormal, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("로봇과 버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
            }
            if (gv.MapType == 2)
            {
                if (true == CheckbetweenBuff(gv.ListHireDesertCount, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
                if (true == CheckbetweenRobot(gv.RobotDesert, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("로봇과 버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
            }
            if (gv.MapType == 3)
            {
                if (true == CheckbetweenBuff(gv.ListHireIceCount, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
                if (true == CheckbetweenRobot(gv.RobotIce, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("로봇과 버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
            }
            if (gv.MapType == 4)
            {
                if (true == CheckbetweenBuff(gv.ListHireForestCount, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
                if (true == CheckbetweenRobot(gv.RobotForest, index))
                {
                    MainStatusObj.GetComponent<StatusUpdate>().SetNotification("로봇과 버프광부는 서로\n배치할 수 없습니다.");
                    return;
                }
            }
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().ViewCardReset();
            GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitCardSetting();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();


            int MinerIndex = SplitMinerName(gv.strCharacterSelect);
            GameObject.Find("MainCanvas").GetComponent<HireSettingController>().SetHirePos(gv.strCharacterSelect, index);
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitCardSetting();
            GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();           
           
            gv.bClickCard = false;
            if (MinerIndex == 0)
                return;
            if (gv.MiningType[MinerIndex - 1] == 0)
            {
                //채굴량		5
                //드릴파워        6
                //채굴스피드       7
                //판매량     8
                if (gv.BuffType[MinerIndex - 1] == 5)
                {
                    GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetBuffSing(gv.GetDepthPos(index), 1);
                }
                if (gv.BuffType[MinerIndex - 1] == 6)
                {
                    GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetBuffSing(gv.GetDepthPos(index), 2);
                }
                if (gv.BuffType[MinerIndex - 1] == 7)
                {
                    GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetBuffSing(gv.GetDepthPos(index), 3);
                }
                if (gv.BuffType[MinerIndex - 1] == 8)
                {
                    GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetBuffSing(gv.GetDepthPos(index), 4);
                }

                int isBuffMinerIndex = -1;
                if (Mathf.Abs(index) % 2 == 0)
                {
                    isBuffMinerIndex = index + 1;
                }
                else
                {
                    isBuffMinerIndex = index - 1;
                }
                if (gv.MapType == 1)
                {
                    CheckBuff(gv.ListHireCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 2)
                {
                    CheckBuff(gv.ListHireDesertCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 3)
                {
                    CheckBuff(gv.ListHireIceCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 4)
                {
                    CheckBuff(gv.ListHireForestCount, isBuffMinerIndex, MinerIndex);
                }
            }
            if (gv.MiningType[MinerIndex - 1] == 1)
            {
                int isBuffMinerIndex = -1;
                if (Mathf.Abs(index) % 2 == 0)
                {
                    isBuffMinerIndex = index + 1;
                }
                else
                {
                    isBuffMinerIndex = index - 1;
                }
                if (gv.MapType == 1)
                {
                    CheckBuffMiner(gv.ListHireCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 2)
                {
                    CheckBuffMiner(gv.ListHireDesertCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 3)
                {
                    CheckBuffMiner(gv.ListHireIceCount, isBuffMinerIndex, MinerIndex);
                }
                if (gv.MapType == 4)
                {
                    CheckBuffMiner(gv.ListHireForestCount, isBuffMinerIndex, MinerIndex);
                }

            }

        }
        int sindex = SplitNameOriNumber(this.name);
        if (gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    if (sindex == Mathf.Abs(gv.ListHireCount[i] + 1))
                    {
                        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetInfoCanvas(sindex + 1);
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
                    if (sindex == Mathf.Abs(gv.ListHireDesertCount[i] + 1))
                    {
                        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetInfoCanvas(sindex + 1);
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
                    if (sindex == Mathf.Abs(gv.ListHireIceCount[i] + 1))
                    {
                        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetInfoCanvas(sindex + 1);
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
                    if (sindex == Mathf.Abs(gv.ListHireForestCount[i] + 1))
                    {
                        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetInfoCanvas(sindex + 1);
                    }

                }
            }
        }

        
    }

    void CheckBuff(List<int> MinerList,int isBuffMinerIndex,int MinerIndex)
    {
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBuffMinerIndex)
            {
                if (gv.BuffType[MinerIndex - 1] == 5)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex - 1] + " 채굴량 강화");
                    gv.eachMiningPower[i] += gv.BuffPower[MinerIndex - 1];
                }
                if (gv.BuffType[MinerIndex - 1] == 6)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex - 1] + " 드릴파워 강화");
                    gv.DrillBuffPower += gv.BuffPower[MinerIndex - 1];
                }
                if (gv.BuffType[MinerIndex - 1] == 7)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex - 1] + " 채굴스피드 강화");
                    gv.eachMiningSpeed[i] += gv.BuffPower[MinerIndex - 1];
                }
                if (gv.BuffType[MinerIndex - 1] == 8)
                {
                    Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex - 1] + " 판매량 강화");
                    gv.eachSellPower[i] += gv.BuffPower[MinerIndex - 1];
                }
            }
        }
    }
    void CheckBuffMiner(List<int> MinerList,int isBuffMinerIndex,int MinerIndex)
    {
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBuffMinerIndex)
            {
                if (gv.MiningType[i] == 0)
                {
                    if(gv.BuffType[i] == 5)
                    {
                        Debug.Log(MinerIndex - 1 + " 마이너 " + gv.BuffPower[i] + " 채굴량 강화");
                        gv.eachMiningPower[MinerIndex - 1] += gv.BuffPower[i];
                    }
                    if (gv.BuffType[i] == 6)
                    {
                        Debug.Log(MinerIndex - 1 + " 마이너 " + gv.BuffPower[i] + " 드릴파워 강화");
                        gv.DrillBuffPower += gv.BuffPower[i];
                    }
                    if (gv.BuffType[i] == 7)
                    {
                        Debug.Log(MinerIndex - 1 + " 마이너 " + gv.BuffPower[i] + " 채굴스피드 강화");
                        gv.eachMiningSpeed[MinerIndex - 1] += gv.BuffPower[i];
                    }
                    if (gv.BuffType[i] == 8)
                    {
                        Debug.Log(MinerIndex - 1 + " 마이너 " + gv.BuffPower[i] + " 판매량 강화");
                        gv.eachSellPower[MinerIndex - 1] += gv.BuffPower[i];
                    }

                
                }
            }
        }
    }
}
