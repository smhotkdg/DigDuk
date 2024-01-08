using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KingMineralSelectMinerSrc : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public Text PowerText;
    public Text PowerText2;
    public GameObject OwnMinerContent;
    public List<GameObject> SelectMinerListObj;
    public GameObject SelectMinerContent;

    List<GameObject> OwnMinerList = new List<GameObject>();
    List<GameObject> SelectMinerList = new List<GameObject>();

    List<int> SelectMinerCount = new List<int>();    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        for(int i =0; i <6; i++)
        {
            SelectMinerCount.Add(-1);
        }
    }
    void Start () {
		
	}
    private void OnEnable()
    {        
        InitData();        
    }
    public void SetMiner()
    {    
        for(int i=0; i< SelectMinerCount.Count; i++)
        {
            if(SelectMinerCount[i] >=0)
                UnSelectMiner(SelectMinerCount[i],true);
        }
        for(int i=0; i< SelectMinerCount.Count; i++)
        {
            SelectMinerCount[i] = -1;
        }
        for (int i = 0; i < 6; i++)
        {
            if (gv.KingMineralMiners[i] > 0)
            {
                SelectMiner(gv.KingMineralMiners[i] - 1);
            }
        }
    }
    public void InitData()
    {
        if(OwnMinerList.Count ==0)
        {
            for (int i = 0; i < 110; i++)
            {
                int index = i + 1;
                string strMinerName = "Miner" + index;
                OwnMinerList.Add(OwnMinerContent.transform.Find(strMinerName).gameObject);
                OwnMinerList[OwnMinerList.Count - 1].transform.Find("ImageLevel").gameObject.GetComponent<Image>().color =   gv.lvColorList[gv.ListHireLevel[i] - 1];

                OwnMinerList[OwnMinerList.Count - 1].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                OwnMinerList[OwnMinerList.Count - 1].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                if (gv.ListHireCount[i] != 0)
                    OwnMinerList[OwnMinerList.Count - 1].SetActive(true);


                SelectMinerList.Add(SelectMinerContent.transform.Find(strMinerName).gameObject);
                SelectMinerList[SelectMinerList.Count - 1].transform.Find("ImageLevel").gameObject.GetComponent<Image>().color =  gv.lvColorList[gv.ListHireLevel[i] - 1];
                SelectMinerList[SelectMinerList.Count - 1].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                SelectMinerList[SelectMinerList.Count - 1].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];

            }
        }
        else
        {
            for(int i=0; i< 110; i++)
            {
                if (gv.ListHireCount[i] != 0)
                {
                    int index = i + 1;
                    string strMinerName = "Miner" + index;
                    OwnMinerList[i].transform.Find("ImageLevel").gameObject.GetComponent<Image>().color = gv.lvColorList[gv.ListHireLevel[i] - 1];

                    OwnMinerList[i].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                    OwnMinerList[i].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];               
                    
                    
                    SelectMinerList[i].transform.Find("ImageLevel").gameObject.GetComponent<Image>().color =  gv.lvColorList[gv.ListHireLevel[i] - 1];
                    SelectMinerList[i].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];
                    SelectMinerList[i].transform.Find("ImageLevel").gameObject.transform.Find("TextLevel2").GetComponent<Text>().text = "Lv. " + gv.ListHireLevel[i];

                    if (gv.ListHireCount[i] != 0)
                        OwnMinerList[i].SetActive(true);
                }
                    
            }
        }

        CheckPowerText();
    }

    int selectindex = 0;
    bool bstartSelect = false;
    public void SelectMiner(int i)
    {                
        if(bstartSelect ==false)
        {
            bstartSelect = true;
            for (int k = 0; k < SelectMinerCount.Count; k++)
            {
                if (SelectMinerCount[k] < 0)
                {
                    SelectMinerCount[k] = i;
                    OwnMinerList[i].SetActive(false);
                    SelectMinerList[i].transform.SetParent(SelectMinerListObj[k].transform);
                    Vector3 _vec = new Vector3();
                    _vec.x = 1; _vec.y = 1; _vec.z = 1;
                    SelectMinerList[i].transform.localScale = _vec;
                    _vec.x = 0; _vec.y = 0; _vec.z = 1;
                    SelectMinerList[i].transform.localPosition = _vec;
                    SelectMinerList[i].SetActive(true);
                    

                    gv.KingMineralMiners[k] = i + 1;
                    int index = k + 1;
                    string strTemp = "KingMineralMiners" + index;
                    PlayerPrefs.SetInt(strTemp, gv.KingMineralMiners[k]);
                    PlayerPrefs.Save();
                    CheckPowerText();
                    bstartSelect = false;
                    return;
                }
            }
            bstartSelect = false;
        }         
    }
    IEnumerator Startfalse()
    {
        yield return new WaitForSeconds(0.1f);
        bstartSelect = false;
    }
    public void UnSelectMiner(int i,bool temp)
    {
        for (int k = 0; k < SelectMinerCount.Count; k++)
        {
            if (SelectMinerCount[k] == i)
            {
                if (selectindex < 0)
                {
                    selectindex = 0;
                }
                SelectMinerList[i].transform.SetParent(SelectMinerContent.transform);
                Vector3 _vec = new Vector3();
                _vec.x = 1; _vec.y = 1; _vec.z = 1;
                SelectMinerList[i].transform.localScale = _vec;
                _vec.x = 0; _vec.y = 0; _vec.z = 1;
                SelectMinerList[i].transform.localPosition = _vec;

                OwnMinerList[i].SetActive(true);
                SelectMinerList[i].SetActive(false);
                SelectMinerCount[k] = -1;
                CheckPowerText();
                return;
            }
        }
    }
    public void UnSelectMiner(int i)
    {
        for(int k=0;k< SelectMinerCount.Count; k++)
        {
            if(SelectMinerCount[k] == i)
            {                
                if(selectindex <0)
                {
                    selectindex = 0;
                }
                SelectMinerList[i].transform.SetParent(SelectMinerContent.transform);
                Vector3 _vec = new Vector3();
                _vec.x = 1; _vec.y = 1; _vec.z = 1;
                SelectMinerList[i].transform.localScale = _vec;
                _vec.x = 0; _vec.y = 0; _vec.z = 1;
                SelectMinerList[i].transform.localPosition = _vec;


                for (int j = 0; j < 6; j++)
                {
                    if (gv.KingMineralMiners[j] == SelectMinerCount[k] +1)
                    {
                        gv.KingMineralMiners[j] = 0;
                        int index = j + 1;
                        string strTemp = "KingMineralMiners" + index;
                        PlayerPrefs.SetInt(strTemp, gv.KingMineralMiners[j]);
                        PlayerPrefs.Save();
                        selectindex--;
                    }
                }


                OwnMinerList[i].SetActive(true);
                SelectMinerList[i].SetActive(false);
                SelectMinerCount[k] = -1;
                CheckPowerText();
              
              
                return;
            }
        }   
    }
    void CheckPowerText()
    {
        float power = 0;
        gv.kingBuffPower = 0;
        gv.kingBuffSpeed = 0;
        for (int i = 0; i < 6; i++)
        {
            if(gv.KingMineralMiners[i] >0)
            {
                if (gv.MiningType[gv.KingMineralMiners[i]-1] == 1)
                {
                    power += gv.ListMiningMax[gv.KingMineralMiners[i]-1];
                }
                else
                {
                    //채굴량		5
                    //드릴파워        6
                    //채굴스피드       7
                    //판매량     8
                    switch (gv.BuffType[gv.KingMineralMiners[i]-1])
                    {
                        //채굴량
                        case 5:
                            power = power * gv.BuffPower[gv.KingMineralMiners[i]-1];
                            gv.kingBuffPower += gv.BuffPower[gv.KingMineralMiners[i]-1];
                            break;
                        case 6:
                            break;
                        //채굴 스피드
                        case 7:
                            power = power * gv.BuffPower[gv.KingMineralMiners[i]-1];
                            gv.kingBuffSpeed += gv.BuffPower[gv.KingMineralMiners[i]-1];
                            break;
                        case 8:
                            break;
                    }
                }
            }
        }
        PowerText.text = power.ToString("N0");
        PowerText2.text = power.ToString("N0");
    }
    public void OnDisable()
    {
        selectindex = 0;
    }

    // Update is called once per frame
    void Update () {
		
	}
}
