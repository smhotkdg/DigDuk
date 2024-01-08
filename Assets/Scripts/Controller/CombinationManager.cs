using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CombinationManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject Exclamationmark;
    List<bool> bCombination = new List<bool>();
    public List<int> CollectionStatus = new List<int>();
    List<bool> bListCollection = new List<bool>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    public void SetExclamationmark(bool flag)
    {
        Exclamationmark.SetActive(flag);
    }
    void Start () {
        for(int i=0; i<40; i++)
        {
            bCombination.Add(false);
        }
        for (int i = 0; i < 20; i++)
        {
            bListCollection.Add(false);
        }
        ChangeMapCombinamtion();
        CheckInitCollection();

        InitCost();
    }
    public void InitCost()
    {
        //CraftMoneyDiscount = 0;
        //HireMoneyDiscount = 0;


        if (gv.CapacityPower > 0)
        {
            for (int i = 0; i < gv.ListHireLevel.Count; i++)
            {
                gv.listMaxMinerCapacity[i] = gv.listMaxMinerCapacityDefault[i];
                for (int k = 1; k < gv.ListHireLevel[i]; k++)
                {
                    float weight = gv.GetMinerWeight(i);
                    gv.listMaxMinerCapacity[i] = gv.listMaxMinerCapacity[i] + (int)(gv.listMaxMinerCapacity[i] * weight);
                }
                gv.listMaxMinerCapacity[i] = (gv.listMaxMinerCapacity[i] * gv.CapacityPower);
            }
        }
        else
        {
            for (int i = 0; i < gv.ListHireLevel.Count; i++)
            {
                gv.listMaxMinerCapacity[i] = gv.listMaxMinerCapacityDefault[i];
                for (int k = 1; k < gv.ListHireLevel[i]; k++)
                {
                    float weight = gv.GetMinerWeight(i);                                                            
                    gv.listMaxMinerCapacity[i] = gv.listMaxMinerCapacity[i] + (int)(gv.listMaxMinerCapacity[i] * weight);                    
                }
            }
        }


        if (gv.CraftMoneyDiscount >0)
        {
            for(int i=0; i< gv.EquipmentCost.Count;i++)
            {
                gv.EquipmentCost[i] = gv.DefaulteEquipmentCost[i];
                gv.EquipmentHoitStoneCost[i] = gv.DefaultEquipmentHoitStoneCost[i];
                float temp = 0;
                temp = (float)gv.EquipmentCost[i] - (float)(gv.EquipmentCost[i] * gv.CraftMoneyDiscount);
                gv.EquipmentCost[i] = Mathf.Abs(temp);


                int tempH = (int)gv.EquipmentHoitStoneCost[i] - (int)(gv.EquipmentHoitStoneCost[i] * gv.CraftMoneyDiscount);
                gv.EquipmentHoitStoneCost[i] = (int)Mathf.Abs(tempH);
            }
        }
        else
        {
            for (int i = 0; i < gv.EquipmentCost.Count; i++)
            {
                gv.EquipmentCost[i] = gv.DefaulteEquipmentCost[i];
                gv.EquipmentHoitStoneCost[i] = gv.DefaultEquipmentHoitStoneCost[i];

            }
        }
        if (gv.HireMoneyDiscount > 0)
        {
            for (int i = 0; i < gv.ListHireCost.Count; i++)
            {
                //Mathf.Round
                gv.ListHireCost[i] = gv.ListHireCostDefault[i];
                float temp = 0;
                temp = (float)gv.ListHireCost[i] - (float)(gv.ListHireCost[i] * gv.HireMoneyDiscount);
                gv.ListHireCost[i] = Mathf.Abs(temp);
            }
        }
        else
        {
            for (int i = 0; i < gv.ListHireCost.Count; i++)
            {                
                gv.ListHireCost[i] = gv.ListHireCostDefault[i];           
            }
        }
    }
    public void DeleteCollectValue(int index)
    {
        switch(index)
        {
            case 0:
                //다이너 마이트 시간감소 20%
                gv.dynamiteReTime -= 0.2f;
                break;
            case 1:
                //미접속 보상 2.4
                gv.ReTimePower -= 2.4f;
                break;
            case 2:
                //개발자
                break;
            case 3:
                //특수능력 지속시간 20% 증가
                gv.SkillRemainTimePower -= 0.2f;
                break;
            case 4:
                //특수능력 지속시간 140% 증가
                gv.SkillRemainTimePower -= 1.4f;
                break;
            case 5:
                //전체 판매수익 2.4배
                gv.SaleBuffPower -= 2.4f;
                break;
            case 6:
                //다이너 마이트 시간감소 28%
                gv.dynamiteReTime -= 0.28f;                
                break;
            case 7:
                //광물 보관함 1.8배 증가
                gv.CapacityPower -= 1.8f;
                for (int i = 0; i < gv.listMaxMinerCapacity.Count; i++)
                {
                    gv.listMaxMinerCapacity[i] -= (gv.listMaxMinerCapacity[i] * gv.CapacityPower);
                }
                break;
            case 8:
                //특수능력 쿨감 20%
                gv.SkillCoolTimePower -= 0.2f;
                break;
            case 9:
                //특수능력 쿨감 25%
                gv.SkillCoolTimePower -= 0.25f;
                break;
            case 10:
                //드릴파워 4배
                gv.DrillBuffPower -= 4f;
                break;
            case 11:
                //채굴속도 -3.2
                for (int i = 0; i < gv.eachMiningSpeed.Count; i++)
                {
                    gv.eachMiningSpeed[i] -= 3.2f;
                }
                break;
            case 12:
                //판매수익 2.9배
                gv.SaleBuffPower -= 2.9f;
                break;
            case 13:
                //광물 보관함 1.8배
                gv.CapacityPower -= 1.8f;
                for (int i = 0; i < gv.listMaxMinerCapacity.Count; i++)
                {
                    gv.listMaxMinerCapacity[i] += (gv.listMaxMinerCapacity[i] * gv.CapacityPower);
                }
                break;
            case 14:
                //채굴량 2.8배
                gv.MiningBuffPower -= 2.8f;
                break;
        }     
    }
    public void CheckInitCollection()
    {
      
        if(gv.CollectionStatus[0] >= 1 && bListCollection[0] == false)
        {
            //다이너 마이트 시간감소 20%
            gv.dynamiteReTime += 0.2f;
            bListCollection[0] = true;
            GameObject.Find("MainCanvas").GetComponent<MapContorller>().CombiBoomTest();
        }
        if (gv.CollectionStatus[1] >= 1 && bListCollection[1] == false)
        {
            //미접속 보상 2.4
            gv.ReTimePower += 2.4f;
            bListCollection[1] = true;            
        }
        if (gv.CollectionStatus[2] >= 1 && bListCollection[2] == false)
        {
            //개발자
            //전체판매 수익 증가 8배
            bListCollection[2] = true;
            gv.SaleBuffPower += 8.0f;
        }
        if (gv.CollectionStatus[3] >= 1 && bListCollection[3] == false)
        {
            //특수능력 지속시간 20% 증가
            gv.SkillRemainTimePower += 0.2f;
            bListCollection[3] = true;
        }
        if (gv.CollectionStatus[4] >= 1 && bListCollection[4] == false)
        {
            //----////특수능력 지속시간 140% 증가
            //드릴 엔진 x5
            //gv.SkillRemainTimePower += 1.4f;
            gv.DrillBuffPower += 5f;
            bListCollection[4] = true;
        }
        if (gv.CollectionStatus[5] >= 1 && bListCollection[5] == false)
        {
            //전체 판매수익 2.4배
            gv.SaleBuffPower += 2.4f;
            bListCollection[5] = true;
        }
        if (gv.CollectionStatus[6] >= 1 && bListCollection[6] == false)
        {
            //다이너 마이트 시간감소 28%
            gv.dynamiteReTime += 0.28f;
            GameObject.Find("MainCanvas").GetComponent<MapContorller>().CombiBoomTest();
            bListCollection[6] = true;
        }
        if (gv.CollectionStatus[7] >= 1 && bListCollection[7] == false)
        {
            //광물 보관함 1.8배 증가
            gv.CapacityPower += 1.8f;
            for (int i = 0; i < gv.listMaxMinerCapacity.Count; i++)
            {
                gv.listMaxMinerCapacity[i] += (gv.listMaxMinerCapacity[i] * gv.CapacityPower);
            }
            bListCollection[7] = true;
        }
        if (gv.CollectionStatus[8] >= 1 && bListCollection[8] == false)
        {
            //특수능력 쿨감 20%
            gv.SkillCoolTimePower += 0.2f;
            bListCollection[8] = true;
        }
        if (gv.CollectionStatus[9] >= 1 && bListCollection[9] == false)
        {
            //특수능력 쿨감 25%
            gv.SkillCoolTimePower += 0.25f;
            bListCollection[9] = true;
        }
        if (gv.CollectionStatus[10] >= 1 && bListCollection[10] == false)
        {
            //드릴파워 4배
            gv.DrillBuffPower += 4f;
            bListCollection[10] = true;
        }
        if (gv.CollectionStatus[11] >= 1 && bListCollection[11] == false)
        {
            //채굴속도 -3.2
            for(int i=0; i< gv.eachMiningSpeed.Count; i++)
            {
                gv.eachMiningSpeed[i] += 3.2f;
            }
            bListCollection[11] = true;
        }
        if (gv.CollectionStatus[12] >= 1 && bListCollection[12] == false)
        {
            //판매수익 2.9배
            gv.SaleBuffPower += 2.9f;
            bListCollection[12] = true;
        }
        if (gv.CollectionStatus[13] >= 1 && bListCollection[13] == false)
        {
            //광물 보관함 1.8배
            gv.CapacityPower += 1.8f;
            for(int i=0; i< gv.listMaxMinerCapacity.Count; i++)
            {
                gv.listMaxMinerCapacity[i] += (gv.listMaxMinerCapacity[i] * gv.CapacityPower);
            }
            bListCollection[13] = true;
        }
        if (gv.CollectionStatus[14] >= 1 && bListCollection[14] == false)
        {
            //채굴량 2.8배
            gv.MiningBuffPower += 2.8f;
            bListCollection[14] = true;

        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetbCombination()
    {
        for (int i = 0; i < 40; i++)
        {
            bCombination[i] = false;
        }
    }
    public void DisableCombinationAll()
    {
        Debug.Log("전체 조합 해제");
    }
    public void ChangeMapCollection()
    {
        for (int i = 0; i < 20; i++)
        {
            bListCollection[i] = false;
        }
        CheckInitCollection();
        InitCost();
    }
    public void ChangeMapCombinamtion()
    {
        //드릴파워 1.4 조합1 
        if (gv.CombinationStatus[0] >0 && bCombination[0] == false)
        {
            gv.DrillBuffPower += 1.4f;
            bCombination[0] = true;
        }
        //채굴량 x 2.2 조합2
        if (gv.CombinationStatus[1] > 0 && bCombination[1] == false)
        {
            gv.eachMiningPower[58] += 2.2f;
            gv.eachMiningPower[2] += 2.2f;
            bCombination[1] = true;
        }

        //채굴량 x 2.2 조합3
        if (gv.CombinationStatus[2] > 0 && bCombination[2] == false)
        {
            gv.eachMiningPower[58] += 2.2f;
            gv.eachMiningPower[3] += 2.2f;
            bCombination[2] = true;
        }


        //판매 수익증가 x 1.8 조합4
        if (gv.CombinationStatus[3] > 0 && bCombination[3] == false)
        {
            gv.eachSellPower[61] += 1.8f;
            gv.eachSellPower[0] += 1.8f;
            bCombination[3] = true;
        }


        //판매 수익증가 x 1.8 조합5
        if (gv.CombinationStatus[4] > 0 && bCombination[4] == false)
        {
            gv.eachSellPower[61] += 1.8f;
            gv.eachSellPower[28] += 1.8f;
            bCombination[4] = true;
        }


        //판매 수익증가 x 1.8 조합6
        if (gv.CombinationStatus[5] > 0 && bCombination[5] == false)
        {
            gv.eachSellPower[61] += 1.8f;
            gv.eachSellPower[53] += 1.8f;
            bCombination[5] = true;
        }


        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 7
        if (gv.CombinationStatus[6] > 0 && bCombination[6] == false)
        {
            gv.eachSellPower[104] += 2.4f;
            gv.eachSellPower[10] += 2.4f;
            gv.DrillBuffPower += 2.2f;
            bCombination[6] = true;
        }


        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 8
        if (gv.CombinationStatus[7] > 0 && bCombination[7] == false)
        {
            gv.eachSellPower[104] += 2.4f;
            gv.eachSellPower[11] += 2.4f;
            gv.DrillBuffPower += 2.2f;
            bCombination[7] = true;
        }


        //채굴속도 x 2.8 조합9
        if (gv.CombinationStatus[8] > 0 && bCombination[8] == false)
        {
            gv.eachMiningSpeed[96] += 2.8f;
            gv.eachMiningSpeed[97] += 2.8f;
            bCombination[8] = true;
        }



        //물약지속시간 24% 조합10
        //호잇스톤 획득 확률 25% 증가
        if (gv.CombinationStatus[9] > 0 && bCombination[9] == false)
        {
            //gv.PotionRemainTime += 0.24f;
            //gv.PotionRemainTime += 0.24f;

            gv.HoitStoneBuffPercent += 0.25f;
            bCombination[9] = true;
        }

        //물약지속시간 24% 조합11
        //호잇스톤 획득 확률 25% 증가
        if (gv.CombinationStatus[10] > 0 && bCombination[10] == false)
        {
            //gv.PotionRemainTime += 0.24f;
            //gv.PotionRemainTime += 0.24f;

            gv.HoitStoneBuffPercent += 0.25f;
            bCombination[10] = true;
        }


        //채굴량 x2.9 조합12
        if (gv.CombinationStatus[11] > 0 && bCombination[11] == false)
        {
            gv.eachMiningPower[16] += 2.9f;
            gv.eachMiningPower[17] += 2.9f;
            bCombination[11] = true;
        }

        //다이너 마이트 시간 감소 20 % 조합13
        if (gv.CombinationStatus[12] > 0 && bCombination[12] == false)
        {
            gv.dynamiteReTime += 0.2f;            
            bCombination[12] = true;
        }

        //상자 획득 2배 조합 14
        if (gv.CombinationStatus[13] > 0 && bCombination[13] == false)
        {
            gv.BoxBuffPower += 2f;            
            bCombination[13] = true;
        }


        //전체광부 10% 할인 조합 15
        if (gv.CombinationStatus[14] > 0 && bCombination[14] == false)
        {
            gv.HireMoneyDiscount += 0.1f;            
            bCombination[14] = true;
        }


        //판매 수익 증가 x 3.8 조합 16
        if (gv.CombinationStatus[15] > 0 && bCombination[15] == false)
        {
            gv.eachSellPower[46] += 3.8f;
            gv.eachSellPower[47] += 3.8f;
            bCombination[15] = true;
        }

        //채굴량 x 4.2 조합 17
        if (gv.CombinationStatus[16] > 0 && bCombination[16] == false)
        {
            gv.eachMiningPower[40] += 4.2f;
            gv.eachMiningPower[101] += 4.2f;
            bCombination[16] = true;
        }

        //드릴파워 x 2.9 조합 18
        if (gv.CombinationStatus[17] > 0 && bCombination[17] == false)
        {
            gv.DrillBuffPower+= 2.9f;            
            bCombination[17] = true;
        }

        //전체광부 할인 20% 수익증가 x2.8 조합 19
        if (gv.CombinationStatus[18] > 0 && bCombination[18] == false)
        {
            gv.HireMoneyDiscount += 0.2f;
            //gv.HireMoneyDiscount += 0.2f;

            gv.eachSellPower[99] += 2.8f;
            gv.eachSellPower[98] += 2.8f;
            bCombination[18] = true;
        }

        //채굴속도 x2.2 조합 20
        if (gv.CombinationStatus[19] >0 && bCombination[19] == false)
        {
            gv.eachMiningSpeed[22] += 2.2f;
            gv.eachMiningSpeed[23] += 2.2f;
            bCombination[19] = true;
        }


        //제작비용감소 15% 조합 21
        if (gv.CombinationStatus[20] > 0 && bCombination[20] == false)
        {
            gv.CraftMoneyDiscount += 0.15f;
            bCombination[20] = true;
        }

        //채굴속도 x 2.1 조합 22
        if (gv.CombinationStatus[21] > 0 && bCombination[21] == false)
        {
            gv.eachMiningSpeed[74] += 2.1f;
            gv.eachMiningSpeed[44] += 2.1f;
            bCombination[21] = true;
        }

        //채굴속도 x 2.1 조합 23
        if (gv.CombinationStatus[22] > 0 && bCombination[22] == false)
        {
            gv.eachMiningSpeed[74] += 2.1f;
            gv.eachMiningSpeed[45] += 2.1f;
            bCombination[22] = true;
        }

        //전체 판매 수익증가 x 1.5 조합 24
        if (gv.CombinationStatus[23] > 0 && bCombination[23] == false)
        {
            gv.SaleBuffPower += 1.5f;
            bCombination[23] = true;
        }

        //전체 판매 수익증가 x 1.5 조합 25
        if (gv.CombinationStatus[24] > 0 && bCombination[24] == false)
        {
            gv.SaleBuffPower += 1.5f;
            bCombination[24] = true;
        }

        //전체 판매 수익증가 x 1.5 조합 26
        if (gv.CombinationStatus[25] > 0 && bCombination[25] == false)
        {
            gv.SaleBuffPower += 1.5f;
            bCombination[25] = true;
        }


        //상자버프 2.2 조합 27
        if (gv.CombinationStatus[26] > 0 && bCombination[26] == false)
        {
            gv.BoxBuffPower += 2.2f;
            bCombination[26] = true;
        }


        //판매 수익 증가 x 2.4 조합 28
        if (gv.CombinationStatus[27] > 0 && bCombination[27] == false)
        {
            gv.eachSellPower[25] += 2.4f;
            gv.eachSellPower[36] += 2.4f;
            bCombination[27] = true;
        }

        //미접속 보상 x 4.2 조합 29

        if (gv.CombinationStatus[28] > 0 && bCombination[28] == false)
        {
           if(gv.MapType ==1)
            {
                gv.NotConnectedMoney += 4.2f;
                PlayerPrefs.SetFloat("NotConnectedMoney", gv.NotConnectedMoney);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 2)
            {
                gv.NotConnectedMoney += 4.2f;
                PlayerPrefs.SetFloat("NotConnectedMoneyDesert", gv.NotConnectedMoneyDesert);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 3)
            {
                gv.NotConnectedMoney += 4.2f;
                PlayerPrefs.SetFloat("NotConnectedMoneyIce", gv.NotConnectedMoneyIce);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 4)
            {
                gv.NotConnectedMoney += 4.2f;
                PlayerPrefs.SetFloat("NotConnectedMoneyForest", gv.NotConnectedMoneyForest);
                PlayerPrefs.Save();
            }
            bCombination[28] = true;
        }

        //상자 x 2.8 조합 30
        if (gv.CombinationStatus[29] > 0 && bCombination[29] == false)
        {
            gv.BoxBuffPower += 2.8f;
            bCombination[29] = true;
        }

        //물약 지속시간 15% 조합 31
        //호잇스톤 획득량 2배
        if (gv.CombinationStatus[30] > 0 && bCombination[30] == false)
        {
            //gv.PotionRemainTime += 0.15f;
            gv.HoitStoneBuffPower += 2;
            bCombination[30] = true;
        }

        //물약 지속시간 20% 조합 32
        //호잇스톤 획득량 2배
        if (gv.CombinationStatus[31] > 0 && bCombination[31] == false)
        {
            //gv.PotionRemainTime += 0.2f;
            gv.HoitStoneBuffPower += 2;
            bCombination[31] = true;
        }

        //채굴량 x 3.8 조합 33
        if (gv.CombinationStatus[32] > 0 && bCombination[32] == false)
        {
            gv.eachMiningPower[41] += 3.8f;
            gv.eachMiningPower[42] += 3.8f;
            bCombination[32] = true;

        }
        InitCost();
    }

    public void DisableCombination(int name,int prevPos)
    {
        
        int iPos = Mathf.Abs(prevPos);
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
      
        int CombiPos = 0;

        if (prevPos % 2 == 0)
        {
            CombiPos = (-(prevPos - 1));
        }
        else
        {
            CombiPos = (-(prevPos + 1));

        }
        //드릴파워 1.4 조합1
        if (name == 0 || name == 5)
        {
            //Debug.Log("1 조합 해제");
            if(gv.CombinationStatus[0] > 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                SaveCombi(0, 0, -1);
                
                if (gv.CombinationStatus[0] < 0)
                {
                    gv.DrillBuffPower -= 1.4f;
                }
                bCombination[0] = false;
            }

        }


        //채굴량 x 2.2 조합2
        if (name == 58 || name == 2)
        {
            //Debug.Log("2 조합 해제");
            if (gv.CombinationStatus[1] > 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                SaveCombi(1, 0, -1);
                if (gv.CombinationStatus[1] < 0)
                {
                    gv.eachMiningPower[58] -= 2.2f;
                    gv.eachMiningPower[2] -= 2.2f;
                }
                bCombination[1] = false;
            }
 
        }
        //채굴량 x 2.2 조합3
        if (name == 58 || name == 3)
        {
            //Debug.Log("3 조합 해제");
            if (gv.CombinationStatus[2] > 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                SaveCombi(2, 0, -1);
            }
            if (gv.CombinationStatus[2] < 0)
            {
                gv.eachMiningPower[58] -= 2.2f;
                gv.eachMiningPower[3] -= 2.2f;
            }
            bCombination[2] = false;

        }

        //판매 수익증가 x 1.8 조합4
        if (name == 61 || name == 0)
        {
            //Debug.Log("4 조합 해제");
            if (gv.CombinationStatus[3] > 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                SaveCombi(3, 0, -1);
                if (gv.CombinationStatus[3] < 0)
                {
                    gv.eachSellPower[61] -= 1.8f;
                    gv.eachSellPower[0] -= 1.8f;
                }
                bCombination[3] = false;
            }
            
        }


        //판매 수익증가 x 1.8 조합5
        if (name == 61 || name == 28)
        {
            //Debug.Log("5 조합 해제");
            if (gv.CombinationStatus[4] > 0)
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                SaveCombi(4, 0, -1);
                if (gv.CombinationStatus[4] < 0)
                {
                    gv.eachSellPower[61] -= 1.8f;
                    gv.eachSellPower[28] -= 1.8f;
                }
                bCombination[4] = false;
            }
        }


        //판매 수익증가 x 1.8 조합6
        if (name == 61 || name == 53)
        {
            if (gv.CombinationStatus[5] > 0)
            {
                SaveCombi(5, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[5] > 0)
                {
                    gv.eachSellPower[61] -= 1.8f;
                    gv.eachSellPower[53] -= 1.8f;
                }
                bCombination[5] = false;
            }
        }


        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 7
        if (name == 104 || name == 10)
        {
            if (gv.CombinationStatus[6] > 0)
            {
                SaveCombi(6, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[6] < 0)
                {
                    gv.eachSellPower[104] -= 2.4f;
                    gv.eachSellPower[10] -= 2.4f;
                    gv.DrillBuffPower -= 2.2f;
                }
                bCombination[6] = false;
            }
        }
        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 8
        if (name == 104 || name == 11)
        {
            if (gv.CombinationStatus[7] > 0)
            {               
                SaveCombi(7, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[7] < 0)
                {
                    gv.eachSellPower[104] -= 2.4f;
                    gv.eachSellPower[11] -= 2.4f;
                    gv.DrillBuffPower -= 2.2f;
                }
                bCombination[7] = false;
            }
        }

        //채굴속도 x 2.8 조합9
        if (name == 96 || name == 97)
        {
            if (gv.CombinationStatus[8] > 0)
            {
                SaveCombi(8, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);

                if (gv.CombinationStatus[8] < 0)
                {
                    gv.eachMiningSpeed[96] -= 2.8f;
                    gv.eachMiningSpeed[97] -= 2.8f;

                }
                bCombination[8] = false;
            }
        }

        //물약지속시간 24% 조합10
        if (name == 60 || name == 38)
        {
            if (gv.CombinationStatus[9] > 0)
            {

                SaveCombi(9, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[9] < 0)
                {
                    //gv.PotionRemainTime -= 0.24f;
                    //gv.PotionRemainTime -= 0.24f;
                    gv.HoitStoneBuffPercent -= 0.25f;
                }
                bCombination[9] = false;
            }
        }
        //물약지속시간 24% 조합11
        if (name == 60 || name == 39)
        {
            if (gv.CombinationStatus[10] > 0)
            {
               
                SaveCombi(10, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[10] < 0)
                {
                    //gv.PotionRemainTime -= 0.24f;
                    //gv.PotionRemainTime -= 0.24f;
                    gv.HoitStoneBuffPercent -= 0.25f;
                }
                bCombination[10] = false;
            }
        }

        //채굴량 x2.9 조합12
        if (name == 16 || name == 17)
        {
            if (gv.CombinationStatus[11] > 0)
            {
                SaveCombi(11, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[11] < 0)
                {
                    gv.eachMiningPower[16] -= 2.9f;
                    gv.eachMiningPower[17] -= 2.9f;
                }
                bCombination[11] = false;
            }
        }

        //다이너 마이트 시간 감소 20 % 조합13
        if (name == 32 || name == 33)
        {
            if (gv.CombinationStatus[12] > 0)
            {
               

                SaveCombi(12, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);

                if (gv.CombinationStatus[12] < 0)
                {
                    gv.dynamiteReTime -= 0.2f;
                    //gv.dynamiteReTime -= 0.2f;
                }
                bCombination[12] = false;
            }
        }

        //상자 획득 2배 조합 14
        if (name == 65 || name == 67)
        {
            if (gv.CombinationStatus[13] > 0)
            {
                SaveCombi(13, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[13] < 0)
                {
                    gv.BoxBuffPower -= 2f;
                    //gv.BoxBuffPower -= 2f;
                }
                bCombination[13] = false;
            }
        }


        //전체광부 10% 할인 조합 15
        if (name == 82 || name == 91)
        {
            if (gv.CombinationStatus[14] > 0)
            {
                SaveCombi(14, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[14] < 0)
                {
                    gv.HireMoneyDiscount -= 0.1f;
                    //gv.HireMoneyDiscount -= 0.1f;
                    InitCost();
                }
                bCombination[14] = false;
            }
        }


        //판매 수익 증가 x 3.8 조합 16
        if (name == 46 || name == 47)
        {
            if (gv.CombinationStatus[15] > 0)
            {
                SaveCombi(15, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[15] < 0)
                {
                    gv.eachSellPower[46] -= 3.8f;
                    gv.eachSellPower[47] -= 3.8f;
                }
                bCombination[15] = false;
            }
        }

        //채굴량 x 4.2 조합 17
        if (name == 40 || name == 101)
        {
            if (gv.CombinationStatus[16] > 0)
            {

                SaveCombi(16, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[16] < 0)
                {
                    gv.eachMiningPower[40] -= 4.2f;
                    gv.eachMiningPower[101] -= 4.2f;
                }
                bCombination[16] = false;
            }
        }

        //드릴파워 x 2.9 조합 18
        if (name == 48 || name == 54)
        {
            if (gv.CombinationStatus[17] > 0)
            {

                SaveCombi(17, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[17] < 0)
                {
                    gv.DrillBuffPower -= 2.9f;
                    //gv.DrillBuffPower -= 2.9f;
                }
                bCombination[17] = false;
            }
        }

        //전체광부 할인 20% 수익증가 x2.8 조합 19
        if (name == 99 || name == 98)
        {
            if (gv.CombinationStatus[18] > 0)
            {
                SaveCombi(18, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[18] < 0)
                {
                    gv.HireMoneyDiscount -= 0.2f;
                    //gv.HireMoneyDiscount -= 0.2f;

                    gv.eachSellPower[99] -= 2.8f;
                    gv.eachSellPower[98] -= 2.8f;
                    InitCost();
                }
                bCombination[18] = false;
            }
        }

        //채굴속도 x2.2 조합 20
        if (name == 22 || name == 23)
        {
            if (gv.CombinationStatus[19] > 0)
            {
                SaveCombi(19, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[19] < 0)
                {
                    gv.eachMiningSpeed[22] -= 2.2f;
                    gv.eachMiningSpeed[23] -= 2.2f;
                }
                bCombination[19] = false;
            }
        }

        //제작비용감소 15% 조합 21
        if (name == 81 || name == 83)
        {
            if (gv.CombinationStatus[20] > 0)
            {
                SaveCombi(20, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[20] < 0)
                {
                    gv.CraftMoneyDiscount -= 0.15f;
                }
                bCombination[20] = false;
            }
        }

        //채굴속도 x 2.1 조합 22
        if (name == 74 || name == 44)
        {
            if (gv.CombinationStatus[21] > 0)
            {
                SaveCombi(21, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[21] < 0)
                {
                    gv.eachMiningSpeed[74] -= 2.1f;
                    gv.eachMiningSpeed[44] -= 2.1f;
                }
                bCombination[21] = false;
            }
        }
        //채굴속도 x 2.1 조합 23
        if (name == 74 || name == 45)
        {
            if (gv.CombinationStatus[22] > 0)
            {
                SaveCombi(22, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[22] < 0)
                {
                    gv.eachMiningSpeed[74] -= 2.1f;
                    gv.eachMiningSpeed[45] -= 2.1f;
                }
                bCombination[22] = false;
            }
        }

        //전체 판매 수익증가 x 1.5 조합 24
        if (name == 71 || name == 68)
        {
            if (gv.CombinationStatus[23] > 0)
            {
                SaveCombi(23, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[23] < 0)
                {
                    gv.SaleBuffPower -= 1.5f;
                }
                bCombination[23] = false;
            }
        }
        //전체 판매 수익증가 x 1.5 조합 25
        if (name == 71 || name == 69)
        {
            if (gv.CombinationStatus[24] > 0)
            {
                SaveCombi(24, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[24] < 0)
                {
                    gv.SaleBuffPower -= 1.5f;
                }
                bCombination[24] = false;
            }
        }
        //전체 판매 수익증가 x 1.5 조합 26
        if (name == 71 || name == 70)
        {
            if (gv.CombinationStatus[25] > 0)
            {
                SaveCombi(25, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[25] < 0)
                {
                    gv.SaleBuffPower -= 1.5f;
                }
                bCombination[25] = false;
            }
        }

        
        //상자버프 2.2 조합 27        
        if (name == 75 || name == 50)
        {
            if (gv.CombinationStatus[26] > 0)
            {
                SaveCombi(26, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[26] < 0)
                {
                    gv.BoxBuffPower -= 2.2f;
                    bCombination[26] = false;
                }
                
            }
        }

        //판매 수익 증가 x 2.4 조합 28
        if (name == 25 || name == 24)
        {
            if (gv.CombinationStatus[27] > 0)
            {
                SaveCombi(27, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[27] < 0)
                {
                    gv.eachSellPower[25] -= 2.4f;
                    gv.eachSellPower[36] -= 2.4f;
                    bCombination[27] = false;
                }
                
            }
        }

        //미접속 보상 x 4.2 조합 29
        if (name == 56 || name == 55)
        {
            if (gv.CombinationStatus[28] > 0)
            {
                SaveCombi(28, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[28] < 0)
                {
                    if (gv.MapType == 1)
                    {
                        gv.NotConnectedMoney -= 4.2f;
                        PlayerPrefs.SetFloat("NotConnectedMoney", gv.NotConnectedMoney);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 2)
                    {
                        gv.NotConnectedMoney -= 4.2f;
                        PlayerPrefs.SetFloat("NotConnectedMoneyDesert", gv.NotConnectedMoneyDesert);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 3)
                    {
                        gv.NotConnectedMoney -= 4.2f;
                        PlayerPrefs.SetFloat("NotConnectedMoneyIce", gv.NotConnectedMoneyIce);
                        PlayerPrefs.Save();
                    }
                    if (gv.MapType == 4)
                    {
                        gv.NotConnectedMoney -= 4.2f;
                        PlayerPrefs.SetFloat("NotConnectedMoneyForest", gv.NotConnectedMoneyForest);
                        PlayerPrefs.Save();
                    }
                    bCombination[28] = false;
                }
                
            }
        }

        //상자 x 2.8 조합 30
        if (name == 84 || name == 85)
        {
            if (gv.CombinationStatus[29] > 0)
            {
                SaveCombi(29, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[29] < 0)
                {
                    gv.BoxBuffPower -= 2.8f;
                    bCombination[29] = false;
                }
            }
        }

        //물약 지속시간 15% 조합 31
        //호잇스톤 획득량 2배
        if (name == 37 || name == 30)
        {
            if (gv.CombinationStatus[30] > 0)
            {

                SaveCombi(30, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[30] < 0)
                {
                    //gv.PotionRemainTime -= 0.15f;
                    gv.HoitStoneBuffPower -= 2;
                    bCombination[30] = false;
                }
            }
        }

        //물약 지속시간 20% 조합 32
        //호잇스톤 획득량 2배
        if (name == 43 || name == 64)
        {
            if (gv.CombinationStatus[31] > 0)
            {
                SaveCombi(31, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[31] < 0)
                {
                    //gv.PotionRemainTime -= 0.2f;
                    gv.HoitStoneBuffPower -= 2;
                    bCombination[31] = false;
                }
            }
        }

        //채굴량 x 3.8 조합 33
        if (name == 41 || name == 42)
        {
            if (gv.CombinationStatus[32] > 0)
            {
                SaveCombi(32, 0, -1);
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().UnSetCombination(depth);
                if (gv.CombinationStatus[31] < 0)
                {
                    gv.eachMiningPower[41] -= 3.8f;
                    gv.eachMiningPower[42] -= 3.8f;
                    bCombination[32] = false;
                }
            }
        }
        InitCost();
    }

    public void CheckCombination(int pos,int name)
    {        
        pos = Mathf.Abs(pos);
        int iPos = Mathf.Abs(pos);
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


        


        int CombiPos = 0;
        
        if(pos % 2 == 0)
        {
            CombiPos = (-(pos - 1));
        }
        else
        {
            CombiPos = (-(pos + 1));
        }
        //드릴파워 1.4 조합1
        if(name == 0 || name == 5)
        {
            if(Check(name, CombiPos, 0, 5,1))
            {

                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 1);
                SaveCombi(0, depth,1);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }    


        //채굴량 x 2.2 조합2
        if (name == 58 || name == 2)
        {
            if (Check(name, CombiPos, 58, 2, 2))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 2);
                SaveCombi(1, depth,2);
                ChangeMapCombinamtion();
                // Debug.Log("성공");

            }
        }    
        //채굴량 x 2.2 조합3
        if (name == 58 || name == 3)
        {
            if (Check(name, CombiPos, 58, 3, 3))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 2);
                SaveCombi(2, depth,2);
                ChangeMapCombinamtion();
                // Debug.Log("성공");

            }
        }

        //판매 수익증가 x 1.8 조합4
        if (name == 61 || name == 0)
        {
            if (Check(name, CombiPos, 61, 0, 4))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 3);
                SaveCombi(3, depth,3);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }


        //판매 수익증가 x 1.8 조합5
        if (name == 61 || name == 28)
        {
            if (Check(name, CombiPos, 61, 28, 5))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 3);
                SaveCombi(4, depth,3);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }


        //판매 수익증가 x 1.8 조합6
        if (name == 61 || name == 53)
        {
            if (Check(name, CombiPos, 61, 53, 6))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 3);
                SaveCombi(5, depth,3);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }


        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 7
        if (name == 104 || name == 10)
        {
            if (Check(name, CombiPos, 104, 10, 7))
            {

                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 4);
                SaveCombi(6, depth,4);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }
        //드릴파워 x 2.2 판매수익증가 x 2.4 조합 8
        if (name == 104 || name == 11)
        {
            if (Check(name, CombiPos, 104, 11, 8))
            {

                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 4);
                SaveCombi(7, depth,4);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //채굴속도 x 2.8 조합9
        if (name == 96 || name == 97)
        {
            if (Check(name, CombiPos, 96, 97, 9))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 5);
                SaveCombi(8, depth,5);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //물약지속시간 24% 조합10
        if (name == 60 || name == 38)
        {
            if (Check(name, CombiPos, 60, 38, 10))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 6);
                SaveCombi(9, depth,6);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }
        //물약지속시간 24% 조합11
        if (name == 60 || name == 39)
        {
            if (Check(name, CombiPos, 60, 39, 11))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 6);
                SaveCombi(10, depth,6);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //채굴량 x2.9 조합12
        if (name == 16 || name == 17)
        {
            if (Check(name, CombiPos, 16, 17, 12))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 2);
                SaveCombi(11, depth,2);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //다이너 마이트 시간 감소 20 % 조합13
        if (name == 32 || name == 33)
        {
            if (Check(name, CombiPos, 32, 33, 13))
            {

                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 7);
                SaveCombi(12, depth,7);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //상자 획득 2배 조합 14
        if (name == 65 || name == 67)
        {
            if (Check(name, CombiPos, 65, 67, 14))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 8);
                SaveCombi(13, depth,8);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }


        //전체광부 10% 할인 조합 15
        if (name == 82 || name == 91)
        {
            if (Check(name, CombiPos, 82, 91, 15))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 9);
                SaveCombi(14, depth,9);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }


        //판매 수익 증가 x 3.8 조합 16
        if (name == 46 || name == 47)
        {
            if (Check(name, CombiPos, 46, 47, 16))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 3);
                SaveCombi(15, depth,3);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //채굴량 x 4.2 조합 17
        if (name == 40 || name == 101)
        {
            if (Check(name, CombiPos, 40, 101, 17))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 2);
                SaveCombi(16, depth,2);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }

        //드릴파워 x 2.9 조합 18
        if (name == 48 || name == 54)
        {
            if (Check(name, CombiPos, 48, 54, 18))
            {
             
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 1);
                SaveCombi(17, depth,1);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //전체광부 할인 20% 수익증가 x2.8 조합 19
        if (name == 99 || name == 98)
        {
            if (Check(name, CombiPos, 99, 98, 19))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 10);
                SaveCombi(18, depth,10);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }

        //채굴속도 x2.2 조합 20
        if (name == 22 || name == 23)
        {
            if (Check(name, CombiPos, 22, 23, 20))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 5);
                SaveCombi(19, depth,5);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }

        //제작비용감소 15% 조합 21
        if (name == 81 || name == 83)
        {
            
            if (Check(name, CombiPos, 81, 83, 21))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 11);
                SaveCombi(20, depth,11);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }

        //채굴속도 x 2.1 조합 22
        if (name == 74 || name == 44)
        {
            if (Check(name, CombiPos, 74, 44, 22))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 5);
                SaveCombi(21, depth,5);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }
        //채굴속도 x 2.1 조합 23
        if (name == 74 || name == 45)
        {
            if (Check(name, CombiPos, 74, 45, 23))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 15);
                SaveCombi(22, depth,15);
                ChangeMapCombinamtion();
                // Debug.Log("성공");
            }
        }

        //전체 판매 수익증가 x 1.5 조합 24
        if (name == 71 || name == 68)
        {
            if (Check(name, CombiPos, 71, 68, 24))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 12);
                SaveCombi(23, depth,12);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }
        //전체 판매 수익증가 x 1.5 조합 25
        if (name == 71 || name == 69)
        {
            if (Check(name, CombiPos, 71, 69, 25))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 12);
                SaveCombi(24, depth,12);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }
        //전체 판매 수익증가 x 1.5 조합 26
        if (name == 71 || name == 70)
        {
            if (Check(name, CombiPos, 71, 70, 26))
            {
           
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 12);
                SaveCombi(25, depth,12);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //상자버프 2.2 27
        if (name == 75 || name == 50)
        {
            if (Check(name, CombiPos, 75, 50, 27))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 8);
                SaveCombi(26, depth,8);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //판매 수익 증가 x 2.4 조합 28
        if (name == 25 || name == 24)
        {
            if (Check(name, CombiPos, 25, 24, 28))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 3);
                SaveCombi(27, depth,3);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //미접속 보상 x 4.2 조합 29
        if (name == 56 || name == 55)
        {
            if (Check(name, CombiPos, 56, 55, 29))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 13);
                SaveCombi(28, depth,13);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //상자 x 2.8 조합 30
        if (name == 84 || name == 85)
        {
            if (Check(name, CombiPos, 84, 85, 30))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 9);
                SaveCombi(29, depth,9);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //물약 지속시간 15% 조합 31
        if (name == 37 || name == 30)
        {
            if (Check(name, CombiPos, 37, 30, 31))
            {
          
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 6);
                SaveCombi(30, depth,6);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //물약 지속시간 20% 조합 32
        if (name == 43 || name == 64)
        {
            if (Check(name, CombiPos, 43, 64, 32))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 6);
                SaveCombi(31, depth,6);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

        //채굴량 x 3.8 조합 33
        if (name == 41 || name == 42)
        {
            if (Check(name, CombiPos, 41, 42, 33))
            {
                GameObject.Find("MainCanvas").GetComponent<MapContorller>().SetCombination(depth, 2);
                SaveCombi(32,depth,2);
                ChangeMapCombinamtion();
                //Debug.Log("성공");
            }
        }

    }
    void SaveCombi(int index,int depth,int combicount)
    {
         int pos = index + 1;
        string strCombi = "Combi" + pos;
        gv.CombinationStatus[index] = combicount;
        PlayerPrefs.SetInt(strCombi, gv.CombinationStatus[index]);

        strCombi = "CombiPos" + pos;
        gv.CombinationStatusPos[index] = depth;
        PlayerPrefs.SetInt(strCombi, gv.CombinationStatusPos[index]);

        PlayerPrefs.Save();
    }
    bool Check(int name, int CombiPos, int combiPrevName, int combiName,int CombiIndex)
    {
        if(gv.MapType ==1)
        {
            if (name == combiPrevName)
            {
                if (gv.ListHireCount[combiName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] ==0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }                    
                    return true;
                }
            }
            if (name == combiName)
            {
                if (gv.ListHireCount[combiPrevName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }
                    return true;
                }
            }
        }

        if (gv.MapType == 2)
        {
            if (name == combiPrevName)
            {
                if (gv.ListHireDesertCount[combiName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }
                    return true;
                }
            }
            if (name == combiName)
            {
                if (gv.ListHireDesertCount[combiPrevName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }                    
                    return true;
                }
            }
        }

        if (gv.MapType == 3)
        {
            if (name == combiPrevName)
            {
                if (gv.ListHireIceCount[combiName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }                    
                    return true;
                }
            }
            if (name == combiName)
            {
                if (gv.ListHireIceCount[combiPrevName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }
                    return true;
                }
            }
        }

        if (gv.MapType == 4)
        {
            if (name == combiPrevName)
            {
                if (gv.ListHireForestCount[combiName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }
                    return true;
                }
            }
            if (name == combiName)
            {
                if (gv.ListHireForestCount[combiPrevName] == CombiPos)
                {
                    if (gv.CombinationStatus[CombiIndex - 1] == 0)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 1, CombiIndex - 1);
                        SetExclamationmark(true);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 10)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(10, 0);
                        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 27)
                            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(27, 0);
                    }                    
                    return true;
                }
            }
        }
        
        return false;
    }
  
    public void DeleteCheckCollection(int MinerPos)
    {

        {
            if(MinerPos == 29 || MinerPos == 28 || MinerPos == 48 || MinerPos == 26 || MinerPos == 20|| MinerPos == 21)
            {
                int CollectionCount = 0;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }
            //2
            if (MinerPos == 46 || MinerPos == 45 || MinerPos == 44 || MinerPos == 43 )
            {
                int CollectionCount = 1;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //3
            if (MinerPos == 109 || MinerPos == 108 || MinerPos == 107 )
            {
                int CollectionCount = 2;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //4
            if (MinerPos == 77 || MinerPos == 78 || MinerPos == 79)
            {
                int CollectionCount = 3;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }
            //5
            if (MinerPos == 100 || MinerPos == 102 || MinerPos == 103)
            {
                int CollectionCount = 4;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }
            //6
            if (MinerPos == 51 || MinerPos == 50)
            {
                int CollectionCount = 5;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //7
            if (MinerPos == 62 || MinerPos == 63)
            {
                int CollectionCount = 6;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }


            //8
            if (MinerPos == 32 || MinerPos == 29 || MinerPos == 30 || MinerPos == 28)
            {
                int CollectionCount = 7;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //9
            if (MinerPos == 93 || MinerPos == 43 )
            {
                int CollectionCount = 8;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //10
            if (MinerPos == 88 || MinerPos == 49)
            {
                int CollectionCount = 9;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }
            //11
            if (MinerPos == 94 || MinerPos == 72 || MinerPos == 87)
            {
                int CollectionCount = 10;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //12
            if (MinerPos == 75 || MinerPos == 99 || MinerPos == 47
                || MinerPos == 52 || MinerPos == 73 || MinerPos == 80
                || MinerPos == 82 || MinerPos == 92 || MinerPos == 90
                || MinerPos == 85 || MinerPos == 59 || MinerPos == 68 || MinerPos == 69)
            {
                int CollectionCount = 11;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //13
            if (MinerPos == 97 || MinerPos == 96 || MinerPos == 41
                || MinerPos == 101 || MinerPos == 36 || MinerPos == 40
                || MinerPos == 24 || MinerPos == 100 )
            {
                int CollectionCount = 12;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

            //14
            if (MinerPos == 105 || MinerPos == 106)
            {
                int CollectionCount = 13;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }



            //15
            if (MinerPos == 39 || MinerPos == 35 || MinerPos == 34 || MinerPos == 55
                || MinerPos == 53 || MinerPos == 38)
            {
                int CollectionCount = 14;
                if (gv.CollectionStatus[CollectionCount] == 1)
                {
                    gv.CollectionStatus[CollectionCount] = 0;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    //여기서 지워주기
                    DeleteCollectValue(0);
                }
            }

        }
    }
    public void CheckCollection()
    {    
        {
            int cnt = 0;
            if (gv.ListHireCount[29] != 0 || gv.ListHireDesertCount[29] != 0 || gv.ListHireForestCount[29] != 0 || gv.ListHireIceCount[29] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[27] != 0 || gv.ListHireDesertCount[27] != 0 || gv.ListHireForestCount[27] != 0 || gv.ListHireIceCount[27] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[48] != 0 || gv.ListHireDesertCount[48] != 0 || gv.ListHireForestCount[48] != 0 || gv.ListHireIceCount[48] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[26] != 0 || gv.ListHireDesertCount[26] != 0 || gv.ListHireForestCount[26] != 0 || gv.ListHireIceCount[26] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[20] != 0 || gv.ListHireDesertCount[20] != 0 || gv.ListHireForestCount[20] != 0 || gv.ListHireIceCount[20] != 0)
            {                
                cnt++;
            }
            if (gv.ListHireCount[21] != 0 || gv.ListHireDesertCount[21] != 0 || gv.ListHireForestCount[21] != 0 || gv.ListHireIceCount[21] != 0)
            {                
                cnt++;
            }
            if (cnt >= 6)
            {
                int CollectionCount = 0;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;

            if (gv.ListHireCount[46] != 0 || gv.ListHireDesertCount[46] != 0 || gv.ListHireForestCount[46] != 0 || gv.ListHireIceCount[46] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[44] != 0 || gv.ListHireDesertCount[40] != 0 || gv.ListHireForestCount[40] != 0 || gv.ListHireIceCount[40] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[45] != 0 || gv.ListHireDesertCount[45] != 0 || gv.ListHireForestCount[45] != 0 || gv.ListHireIceCount[45] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[74] != 0 || gv.ListHireDesertCount[74] != 0 || gv.ListHireForestCount[74] != 0 || gv.ListHireIceCount[74] != 0)
            {
                cnt++;
            }
            if (cnt >= 4)
            {
                int CollectionCount = 1;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;


            if (gv.ListHireCount[109] != 0 || gv.ListHireDesertCount[109] != 0 || gv.ListHireForestCount[109] != 0 || gv.ListHireIceCount[109] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[108] != 0 || gv.ListHireDesertCount[108] != 0 || gv.ListHireForestCount[108] != 0 || gv.ListHireIceCount[108] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[107] != 0 || gv.ListHireDesertCount[107] != 0 || gv.ListHireForestCount[107] != 0 || gv.ListHireIceCount[107] != 0)
            {
                cnt++;
            }
            if (cnt >= 3)
            {
                int CollectionCount = 2;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[77] != 0 || gv.ListHireDesertCount[77] != 0 || gv.ListHireForestCount[77] != 0 || gv.ListHireIceCount[77] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[78] != 0 || gv.ListHireDesertCount[78] != 0 || gv.ListHireForestCount[78] != 0 || gv.ListHireIceCount[78] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[79] != 0 || gv.ListHireDesertCount[79] != 0 || gv.ListHireForestCount[79] != 0 || gv.ListHireIceCount[79] != 0)
            {
                cnt++;
            }
            if (cnt >= 3)
            {
                int CollectionCount = 3;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;


            if (gv.ListHireCount[100] != 0 || gv.ListHireDesertCount[100] != 0 || gv.ListHireForestCount[100] != 0 || gv.ListHireIceCount[100] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[102] != 0 || gv.ListHireDesertCount[102] != 0 || gv.ListHireForestCount[102] != 0 || gv.ListHireIceCount[102] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[103] != 0 || gv.ListHireDesertCount[103] != 0 || gv.ListHireForestCount[103] != 0 || gv.ListHireIceCount[103] != 0)
            {
                cnt++;
            }
            if (cnt >= 3)
            {
                int CollectionCount = 4;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[51] != 0 || gv.ListHireDesertCount[51] != 0 || gv.ListHireForestCount[51] != 0 || gv.ListHireIceCount[51] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[50] != 0 || gv.ListHireDesertCount[50] != 0 || gv.ListHireForestCount[50] != 0 || gv.ListHireIceCount[50] != 0)
            {
                cnt++;
            }
            if (cnt >= 2)
            {
                int CollectionCount = 5;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[62] != 0 || gv.ListHireDesertCount[62] != 0 || gv.ListHireForestCount[62] != 0 || gv.ListHireIceCount[62] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[63] != 0 || gv.ListHireDesertCount[63] != 0 || gv.ListHireForestCount[63] != 0 || gv.ListHireIceCount[63] != 0)
            {
                cnt++;
            }
            if (cnt >= 2)
            {
                int CollectionCount = 6;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[32] != 0 || gv.ListHireDesertCount[32] != 0 || gv.ListHireForestCount[32] != 0 || gv.ListHireIceCount[32] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[29] != 0 || gv.ListHireDesertCount[29] != 0 || gv.ListHireForestCount[29] != 0 || gv.ListHireIceCount[29] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[30] != 0 || gv.ListHireDesertCount[30] != 0 || gv.ListHireForestCount[30] != 0 || gv.ListHireIceCount[30] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[28] != 0 || gv.ListHireDesertCount[28] != 0 || gv.ListHireForestCount[28] != 0 || gv.ListHireIceCount[28] != 0)
            {
                cnt++;
            }
            if (cnt >= 4)
            {
                int CollectionCount = 7;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[93] != 0 || gv.ListHireDesertCount[93] != 0 || gv.ListHireForestCount[93] != 0 || gv.ListHireIceCount[93] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[43] != 0 || gv.ListHireDesertCount[43] != 0 || gv.ListHireForestCount[43] != 0 || gv.ListHireIceCount[43] != 0)
            {
                cnt++;
            }
            if (cnt >= 2)
            {
                int CollectionCount = 8;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[88] != 0 || gv.ListHireDesertCount[88] != 0 || gv.ListHireForestCount[88] != 0 || gv.ListHireIceCount[88] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[49] != 0 || gv.ListHireDesertCount[49] != 0 || gv.ListHireForestCount[49] != 0 || gv.ListHireIceCount[49] != 0)
            {
                cnt++;
            }
            if (cnt >= 2)
            {
                int CollectionCount = 9;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[86] != 0 || gv.ListHireDesertCount[86] != 0 || gv.ListHireForestCount[86] != 0 || gv.ListHireIceCount[86] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[72] != 0 || gv.ListHireDesertCount[72] != 0 || gv.ListHireForestCount[72] != 0 || gv.ListHireIceCount[72] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[94] != 0 || gv.ListHireDesertCount[94] != 0 || gv.ListHireForestCount[94] != 0 || gv.ListHireIceCount[94] != 0)
            {
                cnt++;
            }
            if (cnt >= 3)
            {
                int CollectionCount = 10;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;








            if (gv.ListHireCount[75] != 0 || gv.ListHireDesertCount[75] != 0 || gv.ListHireForestCount[75] != 0 || gv.ListHireIceCount[75] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[99] != 0 || gv.ListHireDesertCount[99] != 0 || gv.ListHireForestCount[99] != 0 || gv.ListHireIceCount[99] != 0)
            {             
                cnt++;
            }
            if (gv.ListHireCount[47] != 0 || gv.ListHireDesertCount[47] != 0 || gv.ListHireForestCount[47] != 0 || gv.ListHireIceCount[47] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[52] != 0 || gv.ListHireDesertCount[52] != 0 || gv.ListHireForestCount[52] != 0 || gv.ListHireIceCount[52] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[73] != 0 || gv.ListHireDesertCount[73] != 0 || gv.ListHireForestCount[73] != 0 || gv.ListHireIceCount[73] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[82] != 0 || gv.ListHireDesertCount[82] != 0 || gv.ListHireForestCount[82] != 0 || gv.ListHireIceCount[82] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[92] != 0 || gv.ListHireDesertCount[92] != 0 || gv.ListHireForestCount[92] != 0 || gv.ListHireIceCount[92] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[90] != 0 || gv.ListHireDesertCount[90] != 0 || gv.ListHireForestCount[90] != 0 || gv.ListHireIceCount[90] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[85] != 0 || gv.ListHireDesertCount[85] != 0 || gv.ListHireForestCount[85] != 0 || gv.ListHireIceCount[85] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[59] != 0 || gv.ListHireDesertCount[59] != 0 || gv.ListHireForestCount[59] != 0 || gv.ListHireIceCount[59] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[68] != 0 || gv.ListHireDesertCount[68] != 0 || gv.ListHireForestCount[68] != 0 || gv.ListHireIceCount[68] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[69] != 0 || gv.ListHireDesertCount[69] != 0 || gv.ListHireForestCount[69] != 0 || gv.ListHireIceCount[69] != 0)
            {
                cnt++;
            }
            if (cnt >= 12)
            {
                int CollectionCount = 11;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[97] != 0 || gv.ListHireDesertCount[97] != 0 || gv.ListHireForestCount[97] != 0 || gv.ListHireIceCount[97] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[96] != 0 || gv.ListHireDesertCount[96] != 0 || gv.ListHireForestCount[96] != 0 || gv.ListHireIceCount[96] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[41] != 0 || gv.ListHireDesertCount[41] != 0 || gv.ListHireForestCount[41] != 0 || gv.ListHireIceCount[41] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[101] != 0 || gv.ListHireDesertCount[101] != 0 || gv.ListHireForestCount[101] != 0 || gv.ListHireIceCount[101] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[36] != 0 || gv.ListHireDesertCount[36] != 0 || gv.ListHireForestCount[36] != 0 || gv.ListHireIceCount[36] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[40] != 0 || gv.ListHireDesertCount[40] != 0 || gv.ListHireForestCount[40] != 0 || gv.ListHireIceCount[40] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[24] != 0 || gv.ListHireDesertCount[24] != 0 || gv.ListHireForestCount[24] != 0 || gv.ListHireIceCount[24] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[100] != 0 || gv.ListHireDesertCount[100] != 0 || gv.ListHireForestCount[100] != 0 || gv.ListHireIceCount[100] != 0)
            {
                cnt++;
            }
            if (cnt >= 8)
            {
                int CollectionCount = 12;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;



            if (gv.ListHireCount[105] != 0 || gv.ListHireDesertCount[105] != 0 || gv.ListHireForestCount[105] != 0 || gv.ListHireIceCount[105] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[106] != 0 || gv.ListHireDesertCount[106] != 0 || gv.ListHireForestCount[106] != 0 || gv.ListHireIceCount[106] != 0)
            {
                cnt++;
            }
            if (cnt >= 2)
            {
                int CollectionCount = 13;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;





            if (gv.ListHireCount[39] != 0 || gv.ListHireDesertCount[39] != 0 || gv.ListHireForestCount[39] != 0 || gv.ListHireIceCount[39] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[35] != 0 || gv.ListHireDesertCount[35] != 0 || gv.ListHireForestCount[35] != 0 || gv.ListHireIceCount[35] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[34] != 0 || gv.ListHireDesertCount[34] != 0 || gv.ListHireForestCount[34] != 0 || gv.ListHireIceCount[34] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[55] != 0 || gv.ListHireDesertCount[55] != 0 || gv.ListHireForestCount[55] != 0 || gv.ListHireIceCount[55] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[53] != 0 || gv.ListHireDesertCount[53] != 0 || gv.ListHireForestCount[53] != 0 || gv.ListHireIceCount[53] != 0)
            {
                cnt++;
            }
            if (gv.ListHireCount[38] != 0 || gv.ListHireDesertCount[38] != 0 || gv.ListHireForestCount[38] != 0 || gv.ListHireIceCount[38] != 0)
            {
                cnt++;
            }
            if (cnt >= 6)
            {
                int CollectionCount = 14;
                if (gv.CollectionStatus[CollectionCount] == 0)
                {
                    gv.CollectionStatus[CollectionCount] = 1;
                    int index = CollectionCount + 1;
                    string temp = "Collection" + index;                    
                    PlayerPrefs.SetInt(temp, gv.CollectionStatus[CollectionCount]);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombinationPopupCanvas(1, 2, CollectionCount);
                    SetExclamationmark(true);
                    CheckInitCollection();
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 20)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(20, 0);
                    }
                }
            }
            cnt = 0;
        }
    }
}
