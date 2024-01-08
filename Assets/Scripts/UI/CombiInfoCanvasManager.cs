using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombiInfoCanvasManager : MonoBehaviour {

    GlobalVariable gv;
    public GameObject ImgCombi;
    public GameObject MinerImg;

    public GameObject BuffMiningPower;
    public GameObject BuffDrillPower;
    public GameObject BuffMiningSpeed;
    public GameObject BuffSalePower;

    public Text TextBuff;    

    List<GameObject> ListCombi = new List<GameObject>();    
    GameObject Buff;
    // Use this for initialization
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start () {

        if (ListCombi.Count == 0)
        {
            Buff = ImgCombi.transform.Find("Buff").gameObject;
            for (int i = 1; i <= 33; i++)
            {
                string strCombi = "Combi" + i;
                ListCombi.Add(ImgCombi.transform.Find(strCombi).gameObject);
            }
        }
	}
    int SplitName(string name)
    {
        string strTemp = name;
        string[] a = strTemp.Split('v');
        int Count = int.Parse(a[1]);

        return Count;
    }
    void SetBuffSing(int index)
    {
        Buff.SetActive(true);
        
        if (index == 1)
        {
            BuffMiningPower.SetActive(true);
        }
        if (index == 2)
        {
            BuffDrillPower.SetActive(true);
        }
        if (index == 3)
        {
            BuffMiningSpeed.SetActive(true);
        }
        if (index == 4)
        {
            BuffSalePower.SetActive(true);
        }
    }
    int index = -1;

    void SetMinerView(int i)
    {
        index = i + 1;
        string name = "Miner" + index;
        
        MinerImg.transform.Find(name).gameObject.SetActive(true);
    }
    private void OnEnable()
    {
        int count = SplitName(gv.CombiPopupName);

        if(ListCombi.Count ==0)
        {
            Buff = ImgCombi.transform.Find("Buff").gameObject;
            for (int i = 1; i <= 33; i++)
            {
                string strCombi = "Combi" + i;
                ListCombi.Add(ImgCombi.transform.Find(strCombi).gameObject);
            }
        }
        for (int i = 0; i < gv.CombinationStatusPos.Count; i++)
        {
            if (gv.CombinationStatusPos[i] == count)
            {
                ListCombi[i].SetActive(true);
            }
        }
        int buffpos = -((count * 2) - 1);
        int buffpos2 = -((count * 2));
        for (int i = 0; i < gv.MiningType.Count; i++)
        {
            if (gv.MiningType[i] == 0)
            {
                if (gv.MapType == 1 && (gv.ListHireCount[i]  == buffpos || gv.ListHireCount[i] == buffpos2))
                {

                    //번역
                    if (gv.BuffType[i] == 5)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;     
                        TextBuff.text = "채굴량 증가 x " + temp.ToString() +" 배";
                        SetMinerView(i);
                        SetBuffSing(1);
                    }
                        
                    if (gv.BuffType[i] == 6)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "드릴 파워 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(2);
                        SetMinerView(i);
                    }
                        
                    if (gv.BuffType[i] == 7)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴 속도 증가 - " + temp.ToString() + " 배";
                        SetBuffSing(3);
                        SetMinerView(i);
                    }   
                    if (gv.BuffType[i] == 8)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "판매 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(4);
                        SetMinerView(i);
                    }
                        

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireCount[i] - 1;
                    }                    
                }
                if (gv.MapType == 2 && (gv.ListHireDesertCount[i] == buffpos || gv.ListHireDesertCount[i] == buffpos2))
                {
                    //번역
                    if (gv.BuffType[i] == 5)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴량 증가 x " + temp.ToString() + " 배";
                        SetMinerView(i);
                        SetBuffSing(1);
                    }

                    if (gv.BuffType[i] == 6)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "드릴 파워 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(2);
                        SetMinerView(i);
                    }

                    if (gv.BuffType[i] == 7)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴 속도 증가 - " + temp.ToString() + " 배";
                        SetBuffSing(3);
                        SetMinerView(i);
                    }
                    if (gv.BuffType[i] == 8)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "판매 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(4);
                        SetMinerView(i);
                    }

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireDesertCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireDesertCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireDesertCount[i] - 1;
                    }
                }
                if (gv.MapType ==3&& (gv.ListHireIceCount[i] == buffpos || gv.ListHireIceCount[i] == buffpos2))
                {
                    //번역
                    if (gv.BuffType[i] == 5)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴량 증가 x " + temp.ToString() + " 배";
                        SetMinerView(i);
                        SetBuffSing(1);
                    }

                    if (gv.BuffType[i] == 6)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "드릴 파워 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(2);
                        SetMinerView(i);
                    }

                    if (gv.BuffType[i] == 7)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴 속도 증가 - " + temp.ToString() + " 배";
                        SetBuffSing(3);
                        SetMinerView(i);
                    }
                    if (gv.BuffType[i] == 8)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "판매 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(4);
                        SetMinerView(i);
                    }

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireIceCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireIceCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireIceCount[i] - 1;
                    }
                }
                if (gv.MapType == 4 && (gv.ListHireForestCount[i] == buffpos || gv.ListHireForestCount[i] == buffpos2))
                {
                    //번역
                    if (gv.BuffType[i] == 5)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴량 증가 x " + temp.ToString() + " 배";
                        SetMinerView(i);
                        SetBuffSing(1);
                    }

                    if (gv.BuffType[i] == 6)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "드릴 파워 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(2);
                        SetMinerView(i);
                    }

                    if (gv.BuffType[i] == 7)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "채굴 속도 증가 - " + temp.ToString() + " 배";
                        SetBuffSing(3);
                        SetMinerView(i);
                    }
                    if (gv.BuffType[i] == 8)
                    {
                        float temp = Mathf.Round((gv.BuffPower[i] * 10)) * 0.1f;
                        TextBuff.text = "판매 증가 x " + temp.ToString() + " 배";
                        SetBuffSing(4);
                        SetMinerView(i);
                    }

                    int isBuffMinerIndex = -1;
                    if (Mathf.Abs(gv.ListHireForestCount[i]) % 2 == 0)
                    {
                        isBuffMinerIndex = gv.ListHireForestCount[i] + 1;
                    }
                    else
                    {
                        isBuffMinerIndex = gv.ListHireForestCount[i] - 1;
                    }
                }
            }
        }

    }
    private void OnDisable()
    {
        for (int i = 0; i < ListCombi.Count; i++)
        {
            ListCombi[i].SetActive(false);
        }
        Buff.SetActive(false);
        gv.CombiPopupName = string.Empty;

        BuffMiningPower.SetActive(false);
        BuffDrillPower.SetActive(false);
        BuffMiningSpeed.SetActive(false);
        BuffSalePower.SetActive(false);
        if(index >0)
        {
            string name = "Miner" + index;

            MinerImg.transform.Find(name).gameObject.SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}


}
