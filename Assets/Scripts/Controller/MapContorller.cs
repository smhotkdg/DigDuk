using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MapContorller : MonoBehaviour {

    // Use this for initialization

    public GameObject BtnEnd;
    public GameObject BtnStart;
    public Text Text_boom;
    public GameObject BottomMap;
    public GameObject MainScroll;
    public ScrollRect mainScrollRect;
    GlobalVariable gv;
    public GameObject MainStatusCanvas;
    List<GameObject> ListMap = new List<GameObject>();
    GameObject LvMap;
    bool bstart = false;
    GameObject BoomObj;
    Image BoomImg;
    Text TimerBoom;
    GameObject FillEffect;
    
    public GameObject TopImage;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {
        InitDepth();
        SetBoomObj();

        SetCombination();
        SetBuffInit();
        SetTop();
        StartCoroutine(TextRoutine());
        InitButton();
    }

    void InitButton()
    {


        if (gv.MapType == 1)
        {
            int nowDepth = gv.Depth;
            if (gv.isStartTimeDepth > 0 || nowDepth % 10 != 0)
            {
                ChangeBoomBtn();
            }
            else
            {
                ChangeBoomBtnRevesrs();
            }
        }
        if (gv.MapType ==2)
        {
            int nowDepth = gv.DesertDepth;
            if (gv.isStartTimeDepthDesert > 0 || nowDepth % 10 != 0)
            {
                ChangeBoomBtn();
            }
            else
            {
                ChangeBoomBtnRevesrs();
            }
        }
        if (gv.MapType ==3)
        {
            int nowDepth = gv.IceDepth;
            if (gv.isStartTimeDepthIce > 0 || nowDepth % 10 != 0)
            {
                ChangeBoomBtn();
            }
            else
            {
                ChangeBoomBtnRevesrs();
            }
        }
        if (gv.MapType == 4)
        {
            int nowDepth = gv.ForestDepth;
            if (gv.isStartTimeDepthForest > 0 || nowDepth % 10 != 0)
            {
                ChangeBoomBtn();
            }
            else
            {
                ChangeBoomBtnRevesrs();
            }
        }
       

    }

    public void SetCombination()
    {
        for (int i = 0; i < gv.CombinationStatus.Count; i++)
        {
            if (gv.CombinationStatus[i] > 0)
            {
                SetCombination(gv.CombinationStatusPos[i], gv.CombinationStatus[i]);
            }
        }
    }
    public void CheckBuff(List<int> MinerList, int isBuffMinerIndex, int MinerIndex)
    {
        //for (int i = 0; i < MinerList.Count; i++)
        //{
        //    if (MinerList[i] == isBuffMinerIndex)
        //    {
        //        if (gv.BuffType[MinerIndex ] == 5)
        //        {
        //            Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex ] + " 채굴량 강화");
        //            gv.eachMiningPower[i] += gv.BuffPower[MinerIndex];
        //        }
        //        if (gv.BuffType[MinerIndex ] == 6)
        //        {
        //            Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex ] + " 드릴파워 강화");
        //            gv.DrillBuffPower += gv.BuffPower[MinerIndex];
        //        }
        //        if (gv.BuffType[MinerIndex ] == 7)
        //        {
        //            Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex ] + " 채굴스피드 강화");
        //            gv.eachMiningSpeed[i] += gv.BuffPower[MinerIndex];
        //        }
        //        if (gv.BuffType[MinerIndex ] == 8)
        //        {
        //            Debug.Log(i + " 마이너 " + gv.BuffPower[MinerIndex ] + " 판매량 강화");
        //            gv.eachSellPower[i] += gv.BuffPower[MinerIndex];
        //        }
        //    }
        //}
    }
    public void CheckBuffUpgrade(List<int> MinerList, int isBUffMinerIndex, int MinerIndex)
    {
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBUffMinerIndex)
            {
                if (MinerList[i] == isBUffMinerIndex)
                {

                    if (gv.BuffType[MinerIndex - 1] == 5)
                    {
                        //for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            //gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachMiningPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 6)
                    {
                        //for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            //gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.DrillBuffPower += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 7)
                    {
                        //for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            //gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachMiningSpeed[i] += gv.BuffPower[MinerIndex - 1];
                    }
                    if (gv.BuffType[MinerIndex - 1] == 8)
                    {
                        //for (int k = 0; k < gv.ListHireLevel[MinerIndex - 1]; k++)
                        {
                            //gv.BuffPower[MinerIndex - 1] = gv.BuffPower[MinerIndex - 1] + (gv.BuffPower[MinerIndex - 1] * 0.2f);
                        }
                        gv.eachSellPower[i] += gv.BuffPower[MinerIndex - 1];
                    }
                }
            }
        }
    }
    void CheckBuffMiner(List<int> MinerList, int isBuffMinerIndex, int MinerIndex)
    {
        for (int i = 0; i < MinerList.Count; i++)
        {
            if (MinerList[i] == isBuffMinerIndex)
            {
                if (gv.MiningType[i] == 0)
                {
                    if (gv.BuffType[i] == 5)
                    {
                        Debug.Log(MinerIndex  + " 마이너 " + gv.BuffPower[i] + " 채굴량 강화");
                    }
                    if (gv.BuffType[i] == 6)
                    {
                        Debug.Log(MinerIndex  + " 마이너 " + gv.BuffPower[i] + " 드릴파워 강화");
                    }
                    if (gv.BuffType[i] == 7)
                    {
                        Debug.Log(MinerIndex  + " 마이너 " + gv.BuffPower[i] + " 채굴스피드 강화");
                    }
                    if (gv.BuffType[i] == 8)
                    {
                        Debug.Log(MinerIndex  + " 마이너 " + gv.BuffPower[i] + " 판매량 강화");
                    }
                }
            }
        }
    }
    public void SetBuffInit()
    {
        for (int i = 0; i < gv.MiningType.Count; i++)
        {
            if (gv.MiningType[i]== 0)
            {
                if (gv.MapType == 1 && gv.ListHireCount[i] <0)
                {
                    if(gv.BuffType[i] == 5)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireCount[i]), 1);
                    if (gv.BuffType[i] == 6)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireCount[i]), 2);
                    if (gv.BuffType[i] == 7)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireCount[i]), 3);
                    if (gv.BuffType[i] == 8)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireCount[i]), 4);

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireCount[i] - 1;
                    }
                    CheckBuff(gv.ListHireCount, isBuffMinerIndex, i);
                    CheckBuffUpgrade(gv.ListHireCount, isBuffMinerIndex, i+1);
                }
                if (gv.MapType == 2 && gv.ListHireDesertCount[i] < 0)
                { 
                    if (gv.BuffType[i] == 5)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireDesertCount[i]), 1);
                    if (gv.BuffType[i] == 6)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireDesertCount[i]), 2);
                    if (gv.BuffType[i] == 7)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireDesertCount[i]), 3);
                    if (gv.BuffType[i] == 8)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireDesertCount[i]), 4);

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireDesertCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireDesertCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireDesertCount[i] - 1;
                    }
                    CheckBuff(gv.ListHireDesertCount, isBuffMinerIndex, i);
                    CheckBuffUpgrade(gv.ListHireDesertCount, isBuffMinerIndex, i + 1);
                }
                if (gv.MapType == 3 && gv.ListHireIceCount[i] < 0)
                {
                    if (gv.BuffType[i] == 5)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireIceCount[i]), 1);
                    if (gv.BuffType[i] == 6)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireIceCount[i]), 2);
                    if (gv.BuffType[i] == 7)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireIceCount[i]), 3);
                    if (gv.BuffType[i] == 8)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireIceCount[i]), 4);

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireIceCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireIceCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireIceCount[i] - 1;
                    }
                    CheckBuff(gv.ListHireIceCount, isBuffMinerIndex, i);
                    CheckBuffUpgrade(gv.ListHireIceCount, isBuffMinerIndex, i + 1);
                }
                if (gv.MapType == 4 && gv.ListHireForestCount[i] < 0)
                {
                    if (gv.BuffType[i] == 5)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireForestCount[i]), 1);
                    if (gv.BuffType[i] == 6)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireForestCount[i]), 2);
                    if (gv.BuffType[i] == 7)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireForestCount[i]), 3);
                    if (gv.BuffType[i] == 8)
                        SetBuffSing(gv.GetDepthPos(gv.ListHireForestCount[i]), 4);

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireForestCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireForestCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireForestCount[i] - 1;
                    }
                    CheckBuff(gv.ListHireForestCount, isBuffMinerIndex, i);
                    CheckBuffUpgrade(gv.ListHireForestCount, isBuffMinerIndex, i + 1);
                }
            }         
        }
    }
    public void SetBuffSing(int mapIndex, int index)
    {
        if (mapIndex == 1)
        {
            //GameObject CombinationSign = LvMap.transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            LvMap.transform.Find("PanelBuff").gameObject.SetActive(true);
            CombinationSign.SetActive(true);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);

            //GameObject WoodenBuffSing = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            //WoodenBuffSing.SetActive(true);
            if (index == 1)
            {
                CombinationSign.transform.Find("ImageCap").gameObject.SetActive(true);
            }
            if (index == 2)
            {
                CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(true);
            }
            if (index == 3)
            {
                CombinationSign.transform.Find("ImageMine").gameObject.SetActive(true);
            }
            if (index == 4)
            {
                CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(true);
            }
        }
        else
        {
            //GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.SetActive(true);
            CombinationSign.SetActive(true);

            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);

            if (index == 1)
            {
                CombinationSign.transform.Find("ImageCap").gameObject.SetActive(true);
            }
            if (index == 2)
            {
                CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(true);
            }
            if (index == 3)
            {
                CombinationSign.transform.Find("ImageMine").gameObject.SetActive(true);
            }
            if (index == 4)
            {
                CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(true);
            }
           
        }

    }

    public void SetCombination(int mapIndex, int index)
    {
        if (mapIndex == 1)
        {
            //GameObject CombinationSign = LvMap.transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject;
            LvMap.transform.Find("PanelBuff").gameObject.SetActive(true);
            CombinationSign.SetActive(true);

            //GameObject WoodenBuffSing = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            //WoodenBuffSing.SetActive(true);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);

            if (index == 1)
            {
                CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(true);
            }
            if (index == 2)
            {
                CombinationSign.transform.Find("ImageCap").gameObject.SetActive(true);
            }
            if (index == 3)
            {
                CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(true);
            }
            if (index == 4)
            {
                CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(true);
            }
            if (index == 5)
            {
                CombinationSign.transform.Find("ImageMine").gameObject.SetActive(true);
            }
            if (index == 6)
            {
                CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(true);
            }
            if (index == 7)
            {
                CombinationSign.transform.Find("ImageDina").gameObject.SetActive(true);
            }
            if (index == 8)
            {
                CombinationSign.transform.Find("ImageBox").gameObject.SetActive(true);
            }
            if (index == 9)
            {
                CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(true);
            }
            if (index == 10)
            {
                CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(true);
            }
            if (index == 11)
            {
                CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(true);
            }
            if (index == 12)
            {
                CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(true);
            }
            if (index == 13)
            {
                CombinationSign.transform.Find("ImageTime").gameObject.SetActive(true);
            }
        }
        else
        {
            //GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject;
            ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.SetActive(true);
            CombinationSign.SetActive(true);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);


            if (index == 1)
            {
                CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(true);
            }
            if (index == 2)
            {
                CombinationSign.transform.Find("ImageCap").gameObject.SetActive(true);
            }
            if (index == 3)
            {
                CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(true);
            }
            if (index == 4)
            {
                CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(true);
            }
            if (index == 5)
            {
                CombinationSign.transform.Find("ImageMine").gameObject.SetActive(true);
            }
            if (index == 6)
            {
                CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(true);
            }
            if (index == 7)
            {
                CombinationSign.transform.Find("ImageDina").gameObject.SetActive(true);
            }
            if (index == 8)
            {
                CombinationSign.transform.Find("ImageBox").gameObject.SetActive(true);
            }
            if (index == 9)
            {
                CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(true);
            }
            if (index == 10)
            {
                CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(true);
            }
            if (index == 11)
            {
                CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(true);
            }
            if (index == 12)
            {
                CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(true);
            }
            if (index == 13)
            {
                CombinationSign.transform.Find("ImageTime").gameObject.SetActive(true);
            }
        }

    }

    public void UnSetBuff(int mapIndex)
    {
        if (mapIndex == 1)
        {
            //GameObject CombinationSign = LvMap.transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            CombinationSign.SetActive(false);
            LvMap.transform.Find("PanelBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);
        }
        else
        {
            //GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
            CombinationSign.SetActive(false);
            ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);
        }


    }
    public void UnSetCombination(int mapIndex)
    {
        if (mapIndex == 1)
        {
            //GameObject CombinationSign = LvMap.transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject;
            CombinationSign.SetActive(false);
            LvMap.transform.Find("PanelBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);
        }
        else
        {
            //GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("WoodenCombinationSign").gameObject;
            GameObject CombinationSign = ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject;
            CombinationSign.SetActive(false);
            ListMap[mapIndex - 2].transform.Find("PanelBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCap").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoin").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCoinNDrill").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMine").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBuff").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageDina").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageBox").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerDiscount").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageMinerNMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageCraftMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTotalMoney").gameObject.SetActive(false);
            CombinationSign.transform.Find("ImageTime").gameObject.SetActive(false);
        }


    }
    public float GetFill()
    {
        return BoomImg.fillAmount;
    }
    public void SetFill(float a)
    {
        if (BoomImg != null)
        {
            if (BoomImg.fillAmount >= 1)
                FillEffect.SetActive(true);
            BoomImg.fillAmount = a;
        }
    }
    public void CombiBoomTest()
    {
        int nowDepth = 0;
        if (gv.MapType == 1)
        {
            nowDepth = gv.Depth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 2)
        {
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 3)
        {
            nowDepth = gv.IceDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 4)
        {
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
    }
    public void SetBoomObj()
    {
        for (int i = 0; i < ListMap.Count; i++)
        {
            if (ListMap[i].transform.Find("ImgBoom").gameObject.activeSelf == true)
            {
                BoomObj = ListMap[i].transform.Find("ImgBoom").gameObject;
                BoomImg = BoomObj.GetComponent<Image>();
                FillEffect = BoomObj.transform.Find("FillEffect").gameObject;
                TimerBoom = ListMap[i].transform.Find("BoomTimeImg").gameObject.transform.Find("TextBoomTime").gameObject.GetComponent<Text>();
            }
        }
        int nowDepth = 0;
        if (gv.MapType == 1)
        {
            nowDepth = gv.Depth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 2)
        {
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 3)
        {
            nowDepth = gv.IceDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
        if (gv.MapType == 4)
        {
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, TimerBoom);
            GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTextTime(time, Text_boom);
        }
    }
    public void SetTop()
    {
        Sprite Top = null;
        if (gv.MapType == 1)
        {
            Top = Resources.Load<Sprite>("Top1");
        }
        if(gv.MapType ==2)
        {
            Top = Resources.Load<Sprite>("Top2");
        }
        if (gv.MapType == 3)
        {
            Top = Resources.Load<Sprite>("Top3");
        }
        if (gv.MapType == 4)
        {
            Top = Resources.Load<Sprite>("Top4");
        }
        TopImage.GetComponent<Image>().sprite = Top;
    }
    public void ChangeMap()
    {
        DestoryMapList();
        //GameObject CombinationSign = LvMap.transform.Find("WoodenCombinationSign").gameObject;
        GameObject CombinationSign = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject;
        GameObject BuffSing = LvMap.transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject;
        CombinationSign.SetActive(false);
        BuffSing.SetActive(false);
        LvMap.transform.Find("PanelBuff").gameObject.SetActive(false);
        for (int i=0; i< ListMap.Count;i++)
        {
            //ListMap[i].transform.Find("WoodenCombinationSign").gameObject.SetActive(false);            
            ListMap[i].transform.Find("PanelBuff").gameObject.transform.Find("WoodenCombinationSign").gameObject.SetActive(false);
            ListMap[i].transform.Find("PanelBuff").gameObject.transform.Find("WoodenBuffSing").gameObject.SetActive(false);
            ListMap[i].transform.Find("PanelBuff").gameObject.SetActive(false);
        }        
        InitDepth();
        SetBoomObj();
        GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().SetDrillPos();
        SetCombination();
        SetBuffInit();
        InitButton();        
    }

    // Update is called once per frame
    private void ScrollheightChange()
    {
        RectTransform rt = MainScroll.GetComponent<RectTransform>();
        int width = 0;
        rt.sizeDelta = new Vector2(800, 1772.4f + width);
        Vector3 pos = new Vector3();        
        pos.x = 0;
        MainScroll.transform.localPosition = pos;

        if (gv.MapType ==1)
        {
            if (gv.Depth > 2)
            {
                rt = MainScroll.GetComponent<RectTransform>();
                width = (gv.Depth - 3) * 350;
                rt.sizeDelta = new Vector2(800, 1772.4f + width);
                pos = new Vector3();
                //pos.y = MainScroll.transform.localPosition.y - ((350 * width) / 2);
                pos.x = 0;
                MainScroll.transform.localPosition = pos;
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.DesertDepth > 2)
            {
                rt = MainScroll.GetComponent<RectTransform>();
                width = (gv.DesertDepth - 3) * 350;
                rt.sizeDelta = new Vector2(800, 1772.4f + width);
                pos = new Vector3();
                //pos.y = MainScroll.transform.localPosition.y - ((350 * width) / 2);
                pos.x = 0;
                MainScroll.transform.localPosition = pos;
            }
        }

        if (gv.MapType == 3)
        {
            if (gv.IceDepth > 2)
            {
                rt = MainScroll.GetComponent<RectTransform>();
                width = (gv.IceDepth - 3) * 350;
                rt.sizeDelta = new Vector2(800, 1772.4f + width);
                pos = new Vector3();
                //pos.y = MainScroll.transform.localPosition.y - ((350 * width) / 2);
                pos.x = 0;
                MainScroll.transform.localPosition = pos;
            }
        }

        if (gv.MapType == 4)
        {
            if (gv.ForestDepth > 2)
            {
                rt = MainScroll.GetComponent<RectTransform>();
                width = (gv.ForestDepth - 3) * 350;
                rt.sizeDelta = new Vector2(800, 1772.4f + width);
                pos = new Vector3();
                //pos.y = MainScroll.transform.localPosition.y - ((350 * width) / 2);
                pos.x = 0;
                MainScroll.transform.localPosition = pos;
            }
        }

    }
    IEnumerator DisableEffect(int i)
    {
        yield return new WaitForSeconds(2);
        {
            ListMap[i].transform.Find("MapBurstEffect").gameObject.SetActive(false);
        }
    }

    private void MapSetting()
    {
        if (gv.MapType == 1)
        {
            int DepthControllCnt = gv.Depth - 1;
            int index = 0;
            if (gv.Depth < 5)
            {

                for (int i = 0; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-4");
                    }
                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back1-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.Depth >= 5 && gv.Depth < 10)
            {

                for (int i = 0; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill2");
                    if (gv.Depth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-4");
                        }
                    }

                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back2");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back2-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = 0; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.Depth == 10)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }

            }
        }
        if (gv.MapType == 2)
        {
            
            int DepthControllCnt = gv.DesertDepth - 1;

            int index = 0;
            if (gv.DesertDepth < 5)
            {

                for (int i = 0; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("DesertDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-4");
                    }
                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back4");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back4-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.DesertDepth >= 5 && gv.DesertDepth < 10)
            {

                for (int i = 0; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("DesertDrill2");
                    if (gv.DesertDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-4");
                        }
                    }

                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back5");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back5-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = 0; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.DesertDepth == 10)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }

            }
        }
        if (gv.MapType == 3)
        {
            int DepthControllCnt = gv.IceDepth - 1;
            int index = 0;
            if (gv.IceDepth < 5)
            {

                for (int i = 0; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("IceDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-4");
                    }
                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back6");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back6-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.IceDepth >= 5 && gv.IceDepth < 10)
            {

                for (int i = 0; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("IceDrill2");
                    if (gv.IceDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-4");
                        }
                    }

                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back7");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back7-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = 0; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.IceDepth == 10)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }

            }
        }
        if (gv.MapType == 4)
        {
            int DepthControllCnt = gv.ForestDepth - 1;
            int index = 0;
            if (gv.ForestDepth < 5)
            {

                for (int i = 0; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("ForestDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-4");
                    }
                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back8");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back8-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.ForestDepth >= 5 && gv.ForestDepth < 10)
            {

                for (int i = 0; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("ForestDrill2");
                    if (gv.ForestDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-4");
                        }
                    }

                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back9");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back9-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = 0; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.ForestDepth == 10)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }

            }
        }

    }

    public void DestoryMapList()
    {
        for (int i = 0; i < ListMap.Count; i++)
        {
            Destroy(ListMap[i]);
        }
        ListMap.Clear();
    }
    private void InitDepth()
    {
        
        if (gv.MapType ==1)
        {
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            Color DefaultBackgroundColor = new Color();
            DefaultBackgroundColor.r = 0.258f;
            DefaultBackgroundColor.g = 0.235f;
            DefaultBackgroundColor.b = 0.223f;
            DefaultBackgroundColor.a = 1;
            LvMap.GetComponent<Image>().color = DefaultBackgroundColor;
            ScrollheightChange();

            if (gv.Depth < 2)
            {
                for (int i = 0; i < gv.Depth + 4; i++)
                {
                    Sprite Back1 = null;
                    Back1 = Resources.Load<Sprite>("NormalLv1-1");
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill1");
                    Sprite DrillBackTemp = null;
                    DrillBackTemp = Resources.Load<Sprite>("NormalDrill1");
                    LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;


                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                }
            }
            else
            {
                for (int i = 0; i < gv.Depth + 3; i++)
                {

                    LvMap = BottomMap.transform.Find("Lv1").gameObject;

                    Sprite Back1 = null;
                    Back1 = Resources.Load<Sprite>("NormalLv1-1");
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill1");
                    Sprite DrillBackTemp = null;
                    DrillBackTemp = Resources.Load<Sprite>("NormalDrill1");
                    LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;


                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                }
            }
            MapSetting();


            int realDepth = gv.Depth;
            for (int k = 2; k <= realDepth; k++)
            {
                gv.Depth = k;
                MapSetting(gv.Depth - 2);
            }

            mainScrollRect.verticalNormalizedPosition = 1;
        }

        if(gv.MapType ==2)
        {
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            Color DefaultBackgroundColor = new Color();
            DefaultBackgroundColor.r = 0.294f;
            DefaultBackgroundColor.g = 0.18f;
            DefaultBackgroundColor.b = 0.156f;
            DefaultBackgroundColor.a = 1;
            LvMap.GetComponent<Image>().color = DefaultBackgroundColor;
            ScrollheightChange();

            if (gv.DesertDepth < 2)
            {                
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("DesertLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("DesertDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("DesertDrill1");
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                for (int i = 0; i < gv.DesertDepth + 4; i++)
                {
                    
                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                }
            }
            else
            {
                LvMap = BottomMap.transform.Find("Lv1").gameObject;
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("DesertLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("DesertDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("DesertDrill1");
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                
                for (int i = 0; i < gv.DesertDepth + 3; i++)
                {
                    
                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                    DrillBackTemp = null;
                    DrillBackTemp = Resources.Load<Sprite>("DesertDrill1");
                    ListMap[ListMap.Count - 1].transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                }
            }
            MapSetting();


            int realDepth = gv.DesertDepth;
            for (int k = 2; k <= realDepth; k++)
            {
                gv.DesertDepth = k;
                MapSetting(gv.DesertDepth - 2);
            }

            mainScrollRect.verticalNormalizedPosition = 1;
        }

        if (gv.MapType == 3)
        {
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            Color DefaultBackgroundColor = new Color();
            DefaultBackgroundColor.r = 0.333f;
            DefaultBackgroundColor.g = 0.352f;
            DefaultBackgroundColor.b = 0.352f;
            DefaultBackgroundColor.a = 1;
            LvMap.GetComponent<Image>().color = DefaultBackgroundColor;

            ScrollheightChange();

            if (gv.IceDepth < 2)
            {                
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("IceLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("IceDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("IceDrill1");
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                for (int i = 0; i < gv.IceDepth + 4; i++)
                {

                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                }
            }
            else
            {
                LvMap = BottomMap.transform.Find("Lv1").gameObject;
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("IceLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("IceDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("IceDrill1");
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;

                for (int i = 0; i < gv.IceDepth + 3; i++)
                {

                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                    DrillBackTemp = null;
                    DrillBackTemp = Resources.Load<Sprite>("IceDrill1");
                    ListMap[ListMap.Count - 1].transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                }
            }
            MapSetting();


            int realDepth = gv.IceDepth;
            for (int k = 2; k <= realDepth; k++)
            {
                gv.IceDepth = k;
                MapSetting(gv.IceDepth - 2);
            }

            mainScrollRect.verticalNormalizedPosition = 1;
        }

        if (gv.MapType == 4)
        {
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            Color DefaultBackgroundColor = new Color();
            DefaultBackgroundColor.r = 0.258f;
            DefaultBackgroundColor.g = 0.235f;
            DefaultBackgroundColor.b = 0.223f;
            DefaultBackgroundColor.a = 1;
            LvMap.GetComponent<Image>().color = DefaultBackgroundColor;
            ScrollheightChange();

            if (gv.ForestDepth < 2)
            {                
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("ForestLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("ForestDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("ForestDrill1");
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                for (int i = 0; i < gv.ForestDepth + 4; i++)
                {

                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                }
            }
            else
            {
                LvMap = BottomMap.transform.Find("Lv1").gameObject;
                Sprite Back1 = null;
                Back1 = Resources.Load<Sprite>("ForestLv1-1");
                Sprite DrillBack = null;
                DrillBack = Resources.Load<Sprite>("ForestDrill1");
                Sprite DrillBackTemp = null;
                DrillBackTemp = Resources.Load<Sprite>("ForestDrill1");
                LvMap.transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                LvMap.transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                LvMap.transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;

                for (int i = 0; i < gv.ForestDepth + 3; i++)
                {

                    ListMap.Add(Instantiate(LvMap) as GameObject);
                    int index = i + 2;
                    ListMap[ListMap.Count - 1].name = "Lv" + index;
                    ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
                    ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

                    Vector3 pos = new Vector3();
                    ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
                    pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
                    pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (i + 1));
                    ListMap[ListMap.Count - 1].transform.localPosition = pos;
                    DrillBackTemp = null;
                    DrillBackTemp = Resources.Load<Sprite>("ForestDrill1");
                    ListMap[ListMap.Count - 1].transform.Find("DrillGround1temp").gameObject.GetComponent<Image>().sprite = DrillBackTemp;
                }
            }
            MapSetting();


            int realDepth = gv.ForestDepth;
            for (int k = 2; k <= realDepth; k++)
            {
                gv.ForestDepth = k;
                MapSetting(gv.ForestDepth - 2);
            }

            mainScrollRect.verticalNormalizedPosition = 1;
        }

       
    }

    private void MapSetting(int number)
    {
        if(gv.MapType ==1 )
        {
            int DepthControllCnt = gv.Depth - 1;
            int index = 0;

            if (gv.Depth < 5)
            {
                for (int i = number; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-4");
                    }
                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back1-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.Depth >= 5 && gv.Depth <= 10)
            {

                for (int i = number; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill2");
                    if (gv.Depth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv2-4");
                        }
                    }

                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back2");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back2-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = number; i < gv.Depth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.Depth == 11)
                    {
                        Back1 = Resources.Load<Sprite>("NormalLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.Depth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.Depth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
        }

        if(gv.MapType ==2)
        {
            int DepthControllCnt = gv.DesertDepth - 1;
            int index = 0;

            if (gv.DesertDepth < 5)
            {
                for (int i = number; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;

                    DrillBack = Resources.Load<Sprite>("DesertDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-4");
                    }
                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back4");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back4-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.DesertDepth >= 5 && gv.DesertDepth <= 10)
            {

                for (int i = number; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("DesertDrill2");
                    if (gv.DesertDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("DesertLv2-4");
                        }
                    }

                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back5");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back5-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = number; i < gv.DesertDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.DesertDepth == 11)
                    {
                        Back1 = Resources.Load<Sprite>("DesertLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.DesertDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.DesertDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
        }

        if (gv.MapType == 3)
        {
            int DepthControllCnt = gv.IceDepth - 1;
            int index = 0;

            if (gv.IceDepth < 5)
            {
                for (int i = number; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;

                    DrillBack = Resources.Load<Sprite>("IceDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-4");
                    }
                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back6");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back6-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.IceDepth >= 5 && gv.IceDepth <= 10)
            {

                for (int i = number; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("IceDrill2");
                    if (gv.IceDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("IceLv2-4");
                        }
                    }

                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back7");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back7-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = number; i < gv.IceDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.IceDepth == 11)
                    {
                        Back1 = Resources.Load<Sprite>("IceLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.IceDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.IceDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
        }

        if (gv.MapType == 4)
        {
            int DepthControllCnt = gv.ForestDepth - 1;
            int index = 0;

            if (gv.ForestDepth < 5)
            {
                for (int i = number; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;

                    DrillBack = Resources.Load<Sprite>("ForestDrill1");
                    if (rand == 1)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-1");
                    }
                    else if (rand == 2)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-2");
                    }
                    else if (rand == 3)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-3");
                    }
                    else if (rand == 4)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-4");
                    }
                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back8");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back8-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else if (gv.ForestDepth >= 5 && gv.ForestDepth <= 10)
            {

                for (int i = number; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("ForestDrill2");
                    if (gv.ForestDepth == 5)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv1-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("ForestLv2-4");
                        }
                    }

                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back9");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back9-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
            else
            {
                for (int i = number; i < gv.ForestDepth - 1; i++)
                {

                    int rand = Random.Range(1, 5);
                    Sprite Back1 = null;
                    Sprite DrillBack = null;
                    DrillBack = Resources.Load<Sprite>("NormalDrill3");
                    if (gv.ForestDepth == 11)
                    {
                        Back1 = Resources.Load<Sprite>("ForestLv2-5");
                    }
                    else
                    {
                        if (rand == 1)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-1");
                        }
                        else if (rand == 2)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-2");
                        }
                        else if (rand == 3)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-3");
                        }
                        else if (rand == 4)
                        {
                            Back1 = Resources.Load<Sprite>("NormalLv3-4");
                        }
                    }

                    if (gv.ForestDepth == 2)
                    {
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);

                    }
                    if (i == gv.ForestDepth - 2)
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(true);
                    }
                    else
                    {
                        ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                        LvMap.transform.Find("DrillGround").gameObject.SetActive(false);
                    }


                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(true);
                    ListMap[i].transform.Find("BackGround").gameObject.GetComponent<Image>().sprite = Back1;
                    ListMap[i].transform.Find("DrillGround").gameObject.GetComponent<Image>().sprite = DrillBack;
                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(false);
                    if (i > 0)
                    {
                        ListMap[i - 1].transform.Find("DrillGround").gameObject.SetActive(false);
                    }

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(true);
                    int ikm = (i + 2) * 10;
                    string strkm = ikm + " km";
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").GetComponent<Text>().text = strkm;
                    ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth2").GetComponent<Text>().text = strkm;

                    ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                    ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                }
                for (int i = DepthControllCnt; i < ListMap.Count; i++)
                {
                    ListMap[i].transform.Find("DrillGround").gameObject.SetActive(false);
                    ListMap[i].transform.Find("BackGround").gameObject.SetActive(false);

                    ListMap[i].transform.Find("BackGroundEmpty").gameObject.SetActive(true);

                    ListMap[i].transform.Find("WoodenSign").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);
                    //ListMap[i].transform.Find("WoodenSign").gameObject.transform.Find("TextDepth1").gameObject.SetActive(false);



                    if (index == 0)
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(true);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(true);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(true);
                    }
                    else
                    {
                        Sprite Back1 = Resources.Load<Sprite>("Back3-1");
                        ListMap[i].transform.Find("BackGroundEmpty").gameObject.GetComponent<Image>().sprite = Back1;
                        ListMap[i].transform.Find("ImgBoom").gameObject.SetActive(false);
                        ListMap[i].transform.Find("ImgBoomBack").gameObject.SetActive(false);
                        ListMap[i].transform.Find("BoomTimeImg").gameObject.SetActive(false);
                    }
                    index++;
                }
            }
        }



        bstart = true;
    }

    IEnumerator EffectRoutine()
    {
        //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(6);
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
        yield return new WaitForSeconds(0.5f);
        DepthSetting();
        SetBoomObj();
        //yield return new WaitForSeconds(0.5f);        
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
    }

    void DepthSetting()
    {        
        if(gv.MapType ==1)
        {
            MapSetting(gv.Depth - 2);
        }
        if(gv.MapType ==2)
        {
            MapSetting(gv.DesertDepth - 2);
        }
        if (gv.MapType == 3)
        {
            MapSetting(gv.IceDepth- 2);
        }
        if (gv.MapType == 4)
        {
            MapSetting(gv.ForestDepth - 2);
        }

        GameObject.Find("MainCanvas").GetComponent<Hire_Drill_Manager>().SetDrillPos();
        GameObject.Find("Main Camera").GetComponent<MiningAlgorithm>(). SetRandTable();
        
    }
    public void ScrollTop(int i)
    {
        if(i ==1)
            mainScrollRect.verticalNormalizedPosition = 1;
        else      
            mainScrollRect.verticalNormalizedPosition = 0;
        
    }
    
    void DepthFirstStep()
    {
        if(gv.MapType ==1)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupDepthBlackCoinCanvas(0);


            GameObject LvMap;
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            ListMap.Add(Instantiate(LvMap) as GameObject);
            int index = ListMap.Count +1;
            ListMap[ListMap.Count - 1].name = "Lv" + index;
            UnSetCombination(ListMap.Count - 1);
            UnSetBuff(ListMap.Count - 1);
            ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
            ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

            ListMap[gv.Depth - 2].transform.Find("MapBurstEffect").gameObject.SetActive(true);
            StartCoroutine(DisableEffect(gv.Depth - 2));

            Vector3 pos = new Vector3();
            ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
            pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
            pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (gv.Depth + 4));
            ListMap[ListMap.Count - 1].transform.localPosition = pos;
            ScrollheightChange();
            mainScrollRect.verticalNormalizedPosition = 0;
        }
        if(gv.MapType ==2)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupDepthBlackCoinCanvas(0);


            GameObject LvMap;
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            ListMap.Add(Instantiate(LvMap) as GameObject);
            int index = ListMap.Count + 1;
            ListMap[ListMap.Count - 1].name = "Lv" + index;
            UnSetCombination(ListMap.Count - 1);
            UnSetBuff(ListMap.Count - 1);
            ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
            ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

            ListMap[gv.DesertDepth - 2].transform.Find("MapBurstEffect").gameObject.SetActive(true);
            StartCoroutine(DisableEffect(gv.DesertDepth - 2));

            Vector3 pos = new Vector3();
            ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
            pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
            pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (gv.DesertDepth + 4));
            ListMap[ListMap.Count - 1].transform.localPosition = pos;
            ScrollheightChange();
            mainScrollRect.verticalNormalizedPosition = 0;
        }
        if (gv.MapType == 3)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupDepthBlackCoinCanvas(0);


            GameObject LvMap;
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            ListMap.Add(Instantiate(LvMap) as GameObject);
            int index = ListMap.Count + 1;
            ListMap[ListMap.Count - 1].name = "Lv" + index;
            UnSetCombination(ListMap.Count - 1);
            UnSetBuff(ListMap.Count - 1);
            ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
            ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

            ListMap[gv.IceDepth - 2].transform.Find("MapBurstEffect").gameObject.SetActive(true);
            StartCoroutine(DisableEffect(gv.IceDepth - 2));

            Vector3 pos = new Vector3();
            ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
            pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
            pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (gv.IceDepth + 4));
            ListMap[ListMap.Count - 1].transform.localPosition = pos;
            ScrollheightChange();
            mainScrollRect.verticalNormalizedPosition = 0;
        }
        if (gv.MapType == 4)
        {
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressPopupDepthBlackCoinCanvas(0);


            GameObject LvMap;
            LvMap = BottomMap.transform.Find("Lv1").gameObject;
            ListMap.Add(Instantiate(LvMap) as GameObject);
            int index = ListMap.Count + 1;
            ListMap[ListMap.Count - 1].name = "Lv" + index;
            UnSetCombination(ListMap.Count - 1);
            UnSetBuff(ListMap.Count - 1);
            ListMap[ListMap.Count - 1].transform.SetParent(BottomMap.transform);
            ListMap[ListMap.Count - 1].transform.localScale = LvMap.transform.localScale;

            ListMap[gv.ForestDepth - 2].transform.Find("MapBurstEffect").gameObject.SetActive(true);
            StartCoroutine(DisableEffect(gv.ForestDepth - 2));

            Vector3 pos = new Vector3();
            ListMap[ListMap.Count - 1].transform.localPosition = LvMap.transform.localPosition;
            pos.x = ListMap[ListMap.Count - 1].transform.localPosition.x;
            pos.y = ListMap[ListMap.Count - 1].transform.localPosition.y - (350 * (gv.ForestDepth + 4));
            ListMap[ListMap.Count - 1].transform.localPosition = pos;
            ScrollheightChange();
            mainScrollRect.verticalNormalizedPosition = 0;
        }
    }
    public void SetDepthTime()
    {
        if (gv.MapType == 1)
        {
            gv.DynamiteAdsCount =0;
            PlayerPrefs.SetInt("DynamiteAdsCount", gv.DynamiteAdsCount);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.DynamiteAdsCountDesert = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountDesert", gv.DynamiteAdsCountDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.DynamiteAdsCountIce = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountIce", gv.DynamiteAdsCountIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.DynamiteAdsCountForest = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountForest", gv.DynamiteAdsCountForest);
            PlayerPrefs.Save();
        }

        if (gv.MapType == 1)
        {
            gv.isStartTimeDepth = 0;
            PlayerPrefs.SetInt("isStartTimeDepth", gv.isStartTimeDepth);
            PlayerPrefs.Save();
            BtnEnd.GetComponent<Button>().interactable = false;
        }
        if (gv.MapType == 2)
        {
            gv.isStartTimeDepthDesert = 0;
            PlayerPrefs.SetInt("isStartTimeDepthDesert", gv.isStartTimeDepthDesert);
            PlayerPrefs.Save();
            BtnEnd.GetComponent<Button>().interactable = false;
        }
        if (gv.MapType == 3)
        {
            gv.isStartTimeDepthIce = 0;
            PlayerPrefs.SetInt("isStartTimeDepthIce", gv.isStartTimeDepthIce);
            PlayerPrefs.Save();
            BtnEnd.GetComponent<Button>().interactable = false;
        }
        if (gv.MapType == 4)
        {
            gv.isStartTimeDepthForest = 0;
            PlayerPrefs.SetInt("isStartTimeDepthForest", gv.isStartTimeDepthForest);
            PlayerPrefs.Save();
            BtnEnd.GetComponent<Button>().interactable = false;

        }

        if (gv.MapType == 1)
        {
            gv.Depth++;
            gv.ExpNow = 0;
            //깊이 저장
            PlayerPrefs.SetInt("Depth", gv.Depth);
            PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
            PlayerPrefs.Save();
            DepthFirstStep();
            if (bstart == true)
            {
                StartCoroutine(EffectRoutine());
            }

            else
            {
                DepthSetting();
                SetBoomObj();
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
            }

            gv.isStartTimeDepth = 0;
            PlayerPrefs.SetInt("isStartTimeDepth", gv.isStartTimeDepth);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.DesertDepth++;
            if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 22)
            {             
                if (gv.DesertDepth >=4)
                {
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(22, 0);
                }                
            }
            gv.ExpNowDesert = 0;
            //깊이 저장
            PlayerPrefs.SetInt("DesertDepth", gv.DesertDepth);
            PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
            PlayerPrefs.Save();
            DepthFirstStep();
            if (bstart == true)
            {
                StartCoroutine(EffectRoutine());
            }

            else
            {
                DepthSetting();
                SetBoomObj();
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
            }
            gv.isStartTimeDepthDesert = 0;
            PlayerPrefs.SetInt("isStartTimeDepthDesert", gv.isStartTimeDepthDesert);
            PlayerPrefs.Save();
        }

        if (gv.MapType == 3)
        {
            gv.IceDepth++;
            gv.ExpNowIce = 0;
            //깊이 저장
            PlayerPrefs.SetInt("IceDepth", gv.IceDepth);
            PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
            PlayerPrefs.Save();
            DepthFirstStep();
            if (bstart == true)
            {
                StartCoroutine(EffectRoutine());
            }

            else
            {
                DepthSetting();
                SetBoomObj();
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
            }
            gv.isStartTimeDepthIce = 0;
            PlayerPrefs.SetInt("isStartTimeDepthIce", gv.isStartTimeDepthIce);
            PlayerPrefs.Save();
        }

        if (gv.MapType == 4)
        {
            gv.ForestDepth++;
            gv.ExpNowForest = 0;
            //깊이 저장
            PlayerPrefs.SetInt("ForestDepth", gv.ForestDepth);
            PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
            PlayerPrefs.Save();
            DepthFirstStep();
            if (bstart == true)
            {
                StartCoroutine(EffectRoutine());
            }

            else
            {
                DepthSetting();
                SetBoomObj();
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
            }
            gv.isStartTimeDepthForest = 0;
            PlayerPrefs.SetInt("isStartTimeDepthForest", gv.isStartTimeDepthForest);
            PlayerPrefs.Save();
        }

  

        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckDIgDepthQuest());
        BtnStart.SetActive(true);
        BtnEnd.SetActive(false);

        
    }
    public float GetTimePercent()
    {
        int nowDepth = 0;
        float Percent =0;
        if (gv.MapType == 1)
        {
            if(gv.DynamiteAdsCount >2)
            {
                gv.DynamiteAdsCount =0;
                PlayerPrefs.SetInt("DynamiteAdsCount", gv.DynamiteAdsCount);
                PlayerPrefs.Save();
            }

            int decreaseTime = (1800 * gv.DynamiteAdsCount);
            nowDepth = gv.Depth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            else
            {
                ChangeBoomBtn();
                BtnEnd.GetComponent<Button>().interactable = true;
            }
            if (gv.isStartTimeDepth == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time- decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepth", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }
        if (gv.MapType == 2)
        {
            if (gv.DynamiteAdsCountDesert > 2)
            {
                gv.DynamiteAdsCountDesert = 0;
                PlayerPrefs.SetInt("DynamiteAdsCountDesert", gv.DynamiteAdsCountDesert);
                PlayerPrefs.Save();
            }

            int decreaseTime = (1800 * gv.DynamiteAdsCountDesert);
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            else
            {
                ChangeBoomBtn();
                BtnEnd.GetComponent<Button>().interactable = true;
            }
            if (gv.isStartTimeDepthDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthDesert", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }
        if (gv.MapType == 3)
        {
            if (gv.DynamiteAdsCountIce > 2)
            {
                gv.DynamiteAdsCountIce = 0;
                PlayerPrefs.SetInt("DynamiteAdsCountIce", gv.DynamiteAdsCountIce);
                PlayerPrefs.Save();
            }

            int decreaseTime = (1800 * gv.DynamiteAdsCountIce);
            nowDepth = gv.IceDepth;
            int time = 0;
            if(nowDepth %10 ==0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            else
            {
                ChangeBoomBtn();
                BtnEnd.GetComponent<Button>().interactable = true;
            }
            if (gv.isStartTimeDepthIce== 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthIce", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }
        if (gv.MapType == 4)
        {
            if (gv.DynamiteAdsCountForest > 2)
            {
                gv.DynamiteAdsCountForest = 0;
                PlayerPrefs.SetInt("DynamiteAdsCountForest", gv.DynamiteAdsCountForest);
                PlayerPrefs.Save();
            }            
            int decreaseTime = (1800 * gv.DynamiteAdsCountForest);
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            else
            {
                ChangeBoomBtn();
                BtnEnd.GetComponent<Button>().interactable = true;
            }
            if (gv.isStartTimeDepthForest == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthForest", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }
        return Percent;
    }
    public void SetDepthFree()
    {

        //Blackcoin이 더 많으면 슉슉 진행
        //if
        if (gv.MapType == 1)
        {
            gv.DynamiteAdsCount = 0;
            PlayerPrefs.SetInt("DynamiteAdsCount", gv.DynamiteAdsCount);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.DynamiteAdsCountDesert = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountDesert", gv.DynamiteAdsCountDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.DynamiteAdsCountIce = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountIce", gv.DynamiteAdsCountIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.DynamiteAdsCountForest = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountForest", gv.DynamiteAdsCountForest);
            PlayerPrefs.Save();
        }

        int nowDepth = 0;
        float Percent = 0;
        if (gv.MapType == 1)
        {
            nowDepth = gv.Depth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepth == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = (time - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepth", time))) / time;
                }
            }
            else
            {
                Percent = 0;
            }

        }
        if (gv.MapType == 2)
        {
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepthDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = (time - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthDesert", time))) / time;
                }
            }
            else
            {
                Percent = 0;
            }

        }
        if (gv.MapType == 3)
        {
            nowDepth = gv.IceDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }

            if (gv.isStartTimeDepthIce == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = (time - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthIce", time))) / time;
                }
            }
            else
            {
                Percent = 0;
            }
        }
        if (gv.MapType == 4)
        {
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepthForest == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = (time - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthForest", time))) / time;
                }
            }
            else
            {
                Percent = 0;
            }
        }


        float a;
        a = (nowDepth - 1) * (nowDepth - 1) * 15 + 10;
        a = a * (1 - Percent);


        int BlackcoinCount = (int)a;
        if (BlackcoinCount == 0)
        {
            BlackcoinCount = 1;
        }
        //SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        //if (0 != SIS.DBManager.IncreaseFunds("blackcoin", -BlackcoinCount))
        {
            if (gv.MapType == 1)
            {
                gv.Depth++;
                gv.ExpNow = 0;
                //깊이 저장
                PlayerPrefs.SetInt("Depth", gv.Depth);
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }
            if (gv.MapType == 2)
            {
                gv.DesertDepth++;
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 22)
                {
                    if (gv.DesertDepth >= 4)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(22, 0);
                    }
                }
                gv.ExpNowDesert = 0;
                //깊이 저장
                PlayerPrefs.SetInt("DesertDepth", gv.DesertDepth);
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            if (gv.MapType == 3)
            {
                gv.IceDepth++;
                gv.ExpNowIce = 0;
                //깊이 저장
                PlayerPrefs.SetInt("IceDepth", gv.IceDepth);
                PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            if (gv.MapType == 4)
            {
                gv.ForestDepth++;
                gv.ExpNowForest = 0;
                //깊이 저장
                PlayerPrefs.SetInt("ForestDepth", gv.ForestDepth);
                PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckDIgDepthQuest());

            if (gv.MapType == 1)
            {
                gv.isStartTimeDepth = 0;
                PlayerPrefs.SetInt("isStartTimeDepth", gv.isStartTimeDepth);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
            }
            if (gv.MapType == 2)
            {
                gv.isStartTimeDepthDesert = 0;
                PlayerPrefs.SetInt("isStartTimeDepthDesert", gv.isStartTimeDepthDesert);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
            }
            if (gv.MapType == 3)
            {
                gv.isStartTimeDepthIce = 0;
                PlayerPrefs.SetInt("isStartTimeDepthIce", gv.isStartTimeDepthIce);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;

            }
            if (gv.MapType == 4)
            {
                gv.isStartTimeDepthForest = 0;
                PlayerPrefs.SetInt("isStartTimeDepthForest", gv.isStartTimeDepthForest);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
                //BtnEnd.GetComponent<Button>().interactable = true;

            }
            BtnStart.SetActive(true);
            BtnEnd.SetActive(false);
        }     

     

    }
    public void SetDepth()
    {
        //Blackcoin이 더 많으면 슉슉 진행
        //if
        if (gv.MapType == 1)
        {
            gv.DynamiteAdsCount = 0;
            PlayerPrefs.SetInt("DynamiteAdsCount", gv.DynamiteAdsCount);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            gv.DynamiteAdsCountDesert = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountDesert", gv.DynamiteAdsCountDesert);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            gv.DynamiteAdsCountIce = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountIce", gv.DynamiteAdsCountIce);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            gv.DynamiteAdsCountForest = 0;
            PlayerPrefs.SetInt("DynamiteAdsCountForest", gv.DynamiteAdsCountForest);
            PlayerPrefs.Save();
        }

        int nowDepth = 0;
        float Percent=0;
        if(gv.MapType ==1)
        {
            int decreaseTime = (1800 * gv.DynamiteAdsCount);
            nowDepth = gv.Depth;            
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepth ==1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepth", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
           
        }
        if (gv.MapType == 2)
        {
            int decreaseTime = (1800 * gv.DynamiteAdsCountDesert);
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepthDesert == 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthDesert", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
           
        }
        if (gv.MapType == 3)
        {
            int decreaseTime = (1800 * gv.DynamiteAdsCountIce);
            nowDepth = gv.IceDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }

            if (gv.isStartTimeDepthIce== 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time - decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthIce", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }
        if (gv.MapType == 4)
        {
            int decreaseTime = (1800 * gv.DynamiteAdsCountForest);
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            if (gv.isStartTimeDepthForest== 1)
            {
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time- decreaseTime) == -1)
                {
                    Percent = 1;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", time - decreaseTime) == 2)
                {
                    Percent = 0;
                }
                else
                {
                    Percent = ((time - decreaseTime) - (float)(GameObject.Find("MainCanvas").
                        GetComponent<TimerManager>().GetRemantsTime("StartTimeDepthForest", time - decreaseTime))) / (time - decreaseTime);
                }
            }
            else
            {
                Percent = 0;
            }
        }


        float a;
        a = (nowDepth - 1) * (nowDepth - 1) * 15 + 10;
        a = a * (1 - Percent);


        int BlackcoinCount = (int)a;
        if(BlackcoinCount ==0)
        {
            BlackcoinCount = 1;
        }
        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        if (0 != SIS.DBManager.IncreaseFunds("blackcoin", -BlackcoinCount))
        {
            if (gv.MapType == 1)
            {
                gv.Depth++;
                gv.ExpNow = 0;
                //깊이 저장
                PlayerPrefs.SetInt("Depth", gv.Depth);
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }
            if (gv.MapType == 2)
            {
                gv.DesertDepth++;
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 22)
                {
                    if (gv.DesertDepth >= 4)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(22, 0);
                    }
                }
                gv.ExpNowDesert = 0;
                //깊이 저장
                PlayerPrefs.SetInt("DesertDepth", gv.DesertDepth);
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            if (gv.MapType == 3)
            {
                gv.IceDepth++;
                gv.ExpNowIce = 0;
                //깊이 저장
                PlayerPrefs.SetInt("IceDepth", gv.IceDepth);
                PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            if (gv.MapType == 4)
            {
                gv.ForestDepth++;
                gv.ExpNowForest = 0;
                //깊이 저장
                PlayerPrefs.SetInt("ForestDepth", gv.ForestDepth);
                PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
                PlayerPrefs.Save();
                DepthFirstStep();
                if (bstart == true)
                {
                    StartCoroutine(EffectRoutine());
                }

                else
                {
                    DepthSetting();
                    SetBoomObj();
                    GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Depth");
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressNewMineralsPanel(1);
                }
            }

            GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckDIgDepthQuest());

            if (gv.MapType == 1 )
            {
                gv.isStartTimeDepth = 0;
                PlayerPrefs.SetInt("isStartTimeDepth", gv.isStartTimeDepth);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
            }
            if (gv.MapType == 2 )
            {
                gv.isStartTimeDepthDesert = 0;
                PlayerPrefs.SetInt("isStartTimeDepthDesert", gv.isStartTimeDepthDesert);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
            }
            if (gv.MapType == 3)
            {
                gv.isStartTimeDepthIce = 0;
                PlayerPrefs.SetInt("isStartTimeDepthIce", gv.isStartTimeDepthIce);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;

            }
            if (gv.MapType == 4 )
            {
                gv.isStartTimeDepthForest = 0;
                PlayerPrefs.SetInt("isStartTimeDepthForest", gv.isStartTimeDepthForest);
                PlayerPrefs.Save();
                BtnEnd.GetComponent<Button>().interactable = false;
                //BtnEnd.GetComponent<Button>().interactable = true;

            }
            BtnStart.SetActive(true);
            BtnEnd.SetActive(false);
        }
        else
        {
            MainStatusCanvas.GetComponent<PopUpManager>().NeedBlackCoinView(1);
        }
   

    }


    void ChangeBoomBtn()
    {
        BtnStart.SetActive(false);
        BtnEnd.SetActive(true);
    }
    void ChangeBoomBtnRevesrs()
    {
        BtnStart.SetActive(true);
        BtnEnd.SetActive(false);
    }

    public void StartDepth()
    {
        int nowDepth = 0;
        if (gv.MapType == 1)
        {
            nowDepth = gv.Depth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }

            //if (gv.isStartTimeDepth ==0)
            {
                gv.isStartTimeDepth = 1;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepth", time);
                PlayerPrefs.SetInt("isStartTimeDepth", gv.isStartTimeDepth);
                PlayerPrefs.Save();
                ChangeBoomBtn();
            }   
        }
        if (gv.MapType == 2)
        {
            nowDepth = gv.DesertDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            //if (gv.isStartTimeDepthDesert == 0)
            {
                gv.isStartTimeDepthDesert = 1;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthDesert", time);
                PlayerPrefs.SetInt("isStartTimeDepthDesert", gv.isStartTimeDepthDesert);
                PlayerPrefs.Save();
                ChangeBoomBtn();
            }
        }
        if (gv.MapType == 3)
        {
            nowDepth = gv.IceDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            //if (gv.isStartTimeDepthIce == 0)
            {
                gv.isStartTimeDepthIce = 1;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthIce", time);
                PlayerPrefs.SetInt("isStartTimeDepthIce", gv.isStartTimeDepthIce);
                PlayerPrefs.Save();
                ChangeBoomBtn();
            }
        }
        if (gv.MapType == 4)
        {
            nowDepth = gv.ForestDepth;
            int time = 0;
            if (nowDepth % 10 == 0)
            {
                if (gv.dynamiteReTime == 0)
                {
                    time = 90 + ((nowDepth - 4) * 600);
                }
                else
                {
                    time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                }
            }
            //if (gv.isStartTimeDepthForest == 0)
            {
                gv.isStartTimeDepthForest = 1;
                GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthForest", time);
                PlayerPrefs.SetInt("isStartTimeDepthForest", gv.isStartTimeDepthForest);
                PlayerPrefs.Save();
                ChangeBoomBtn();
            }
        }
        
    }
    IEnumerator TextRoutine()
    {
        yield return new WaitForSeconds(1);
        TextSetting();        
        StartCoroutine(TextRoutine());
    }
    private void TextSetting()
    {
        if(TimerBoom !=null)
        {
            int nowDepth = 0;

            if (gv.MapType == 1 && gv.isStartTimeDepth > 0)
            {
                int decreaseTime = (1800 * gv.DynamiteAdsCount);
                nowDepth = gv.Depth;
                int time = 0;
                if (nowDepth % 10 == 0)
                {
                    if (gv.dynamiteReTime == 0)
                    {
                        time = 90 + ((nowDepth - 4) * 600);
                    }
                    else
                    {
                        time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                    }
                }
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", TimerBoom, time -decreaseTime) == -1 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", Text_boom, time -decreaseTime) == -1)
                {
                    BtnEnd.GetComponent<Button>().interactable = true;
                    Text_boom.text = TimerBoom.text;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", TimerBoom, time -decreaseTime) == 2 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepth", Text_boom, time -decreaseTime) == 2)
                {
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepth", time);
                }
                else
                {
                    BtnEnd.GetComponent<Button>().interactable = false;
                }
                
            }
            if (gv.MapType == 2 && gv.isStartTimeDepthDesert > 0)
            {
                int decreaseTime = (1800 * gv.DynamiteAdsCountDesert);
                nowDepth = gv.DesertDepth;

                int time = 0;
                if (nowDepth % 10 == 0)
                {
                    if (gv.dynamiteReTime == 0)
                    {
                        time = 90 + ((nowDepth - 4) * 600);
                    }
                    else
                    {
                        time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                    }
                }
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", TimerBoom, time -decreaseTime) == -1 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", Text_boom, time - decreaseTime) ==-1)
                {
                    BtnEnd.GetComponent<Button>().interactable = true;
                    Text_boom.text = TimerBoom.text;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", TimerBoom, time - decreaseTime) == 2 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthDesert", Text_boom, time - decreaseTime) == 2)
                {
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthDesert", time);
                }
                else
                {
                    BtnEnd.GetComponent<Button>().interactable = false;
                }
            }
            if (gv.MapType == 3 && gv.isStartTimeDepthIce > 0)
            {
                int decreaseTime = (1800 * gv.DynamiteAdsCountIce);
                nowDepth = gv.IceDepth;

                int time = 0;
                if (nowDepth % 10 == 0)
                {
                    if (gv.dynamiteReTime == 0)
                    {
                        time = 90 + ((nowDepth - 4) * 600);
                    }
                    else
                    {
                        time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                    }
                }
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", TimerBoom, time - decreaseTime) == -1 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", Text_boom, time - decreaseTime) ==-1)
                {   
               
                    BtnEnd.GetComponent<Button>().interactable = true;
                    Text_boom.text = TimerBoom.text;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", TimerBoom, time - decreaseTime) == 2 ||
                  GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthIce", Text_boom, time - decreaseTime) == 2)
                {
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthIce", time);
                }
                else
                {
                    BtnEnd.GetComponent<Button>().interactable = false;
                }
            }
            if (gv.MapType == 4 && gv.isStartTimeDepthForest > 0)
            {
                int decreaseTime = (1800 * gv.DynamiteAdsCountForest);
                nowDepth = gv.ForestDepth;

                int time = 0;
                if (nowDepth % 10 == 0)
                {
                    if (gv.dynamiteReTime == 0)
                    {
                        time = 90 + ((nowDepth - 4) * 600);
                    }
                    else
                    {
                        time = (90 + ((nowDepth - 4) * 600)) - (int)((90 + ((nowDepth - 4) * 600)) * gv.dynamiteReTime);
                    }
                }
                if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", TimerBoom, time- decreaseTime) == -1 ||
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", Text_boom, time-decreaseTime) ==-1)
                {                    
                  
                    BtnEnd.GetComponent<Button>().interactable = true;
                    Text_boom.text = TimerBoom.text;
                }
                else if (GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", TimerBoom, time- decreaseTime) == 2 ||
                 GameObject.Find("MainCanvas").GetComponent<TimerManager>().SetTimerText("StartTimeDepthForest", Text_boom, time- decreaseTime) == 2)
                {
                    GameObject.Find("MainCanvas").GetComponent<TimerManager>().StartTimer("StartTimeDepthForest", time);
                }
                else
                {
                    BtnEnd.GetComponent<Button>().interactable = false;
                }
            }
        }
    }
}

