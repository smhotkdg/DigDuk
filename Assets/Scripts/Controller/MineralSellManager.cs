using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MineralSellManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusCanvas;
    GlobalVariable gv;
    public GameObject Btn;
    public GameObject GetMoneyText;

    public GameObject Manager1;
    public GameObject Manager2;
    public GameObject Manager3;
    bool bstartManager1 = false;
    bool bstartManager2 = false;
    bool bstartManager3 = false;
    bool bRutine = false;
    public Image AutoSellImage;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        AutoSell();
        InitRutin();
        StartCoroutine(AutoSellPotion());
    }
 
    IEnumerator AutoSellPotion()
    {
        if ((gv.ManagerStatus3 == 1 || gv.ManagerStatus2 == 1 || gv.ManagerStatus1 == 1))
        {

        }
        else
        {
            if (gv.AutoSellPower > 0)
            {
                
                AutoSellFillindex = 0;
                AutoSellImage.fillAmount = 0;
                AutoSellTime = 30;
                bFill = true;
                _time = 0;
                //StartCoroutine(AutoSellFillImage());
                AutoSellImage.fillAmount = 1;                
                MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("자동 판매!!");
                if (gv.MapType == 1)
                {
                    for (int i = 0; i < gv.ListHireCount.Count; i++)
                    {
                        if (gv.ListHireCount[i] < 0)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                        }
                        if (gv.ListMoney[i] > 0 && gv.ListHireCount[i] < 0)
                        {

                            yield return new WaitForSeconds(0.2f);

                            GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                            GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                            GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                            GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                            GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                            GetText_Temp[GetText_Temp.Count - 1].SetActive(true);
                            float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                            if (Power <= 0)
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                                gv.Money += gv.ListMoney[i];
                            }
                            else
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                                gv.Money += gv.ListMoney[i] * Power;
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                            }
                            gv.ListMoney[i] = 0;
                            gv.ListCapacityNow[i] = 0;

                            string MoneyCount = "Money" + i;
                            string strCapacityNow = "Capacity" + i;

                            PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                            PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                            PlayerPrefs.Save();
                        }
                    }
                }
                if (gv.MapType == 2)
                {
                    for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
                    {
                        if (gv.ListHireDesertCount[i] < 0)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                        }
                        if (gv.ListMoney[i] > 0 && gv.ListHireDesertCount[i] < 0)
                        {

                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                            yield return new WaitForSeconds(0.2f);

                            GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                            GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                            GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                            GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                            GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                            GetText_Temp[GetText_Temp.Count - 1].SetActive(true);
                            float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                            if (Power <= 0)
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                                gv.Money += gv.ListMoney[i];
                            }
                            else
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                                gv.Money += gv.ListMoney[i] * Power;
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                            }

                            gv.ListMoney[i] = 0;
                            gv.ListCapacityNow[i] = 0;

                            string MoneyCount = "Money" + i;
                            string strCapacityNow = "Capacity" + i;

                            PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                            PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                            PlayerPrefs.Save();
                        }
                    }
                }
                if (gv.MapType == 3)
                {
                    for (int i = 0; i < gv.ListHireIceCount.Count; i++)
                    {
                        if (gv.ListHireIceCount[i] < 0)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                        }
                        if (gv.ListMoney[i] > 0 && gv.ListHireIceCount[i] < 0)
                        {

                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                            yield return new WaitForSeconds(0.2f);

                            GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                            GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                            GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                            GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                            GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                            GetText_Temp[GetText_Temp.Count - 1].SetActive(true);

                            float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                            if (Power <= 0)
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                                gv.Money += gv.ListMoney[i];
                            }
                            else
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                                gv.Money += gv.ListMoney[i] * Power;
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                            }

                            gv.ListMoney[i] = 0;
                            gv.ListCapacityNow[i] = 0;

                            string MoneyCount = "Money" + i;
                            string strCapacityNow = "Capacity" + i;

                            PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                            PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                            PlayerPrefs.Save();
                        }
                    }
                }
                if (gv.MapType == 4)
                {
                    for (int i = 0; i < gv.ListHireForestCount.Count; i++)
                    {
                        if (gv.ListHireForestCount[i] < 0)
                        {
                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                        }
                        if (gv.ListMoney[i] > 0 && gv.ListHireForestCount[i] < 0)
                        {

                            GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                            yield return new WaitForSeconds(0.2f);

                            GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                            GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                            GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                            GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                            GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                            GetText_Temp[GetText_Temp.Count - 1].SetActive(true);

                            float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                            if (Power <= 0)
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                                gv.Money += gv.ListMoney[i];
                            }
                            else
                            {
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                                gv.Money += gv.ListMoney[i] * Power;
                                GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                            }

                            gv.ListMoney[i] = 0;
                            gv.ListCapacityNow[i] = 0;

                            string MoneyCount = "Money" + i;
                            string strCapacityNow = "Capacity" + i;

                            PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                            PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                            PlayerPrefs.Save();
                        }
                    }
                }
                AutoSellImage.fillAmount = 0;
                StartCoroutine(ListTextCler());
            }
            else
            {
                bFill = false;
                AutoSellImage.fillAmount = 1;
            }
            yield return new WaitForSeconds(30);
            StartCoroutine(AutoSellPotion());
            if (gv.AutoSellPower > 0)
            {
                bFill = true;
            }
            else
            {
                bFill = false;
            }
        }

    }
    IEnumerator ListTextCler()
    {
        yield return new WaitForSeconds(2);
        for(int i=0; i< GetText_Temp.Count; i++)
        {
            Destroy(GetText_Temp[i]);
        }
        GetText_Temp.Clear();
    }
    List<GameObject> GetText_Temp = new List<GameObject>();
  
	IEnumerator AutoSellRoutine(int sec)
    {
        AutoSellFillindex = 0;
        AutoSellImage.fillAmount = 0;
        AutoSellTime = sec;
        bFill = true;        
        //StartCoroutine(AutoSellFillImage());
        yield return new WaitForSeconds(sec);
        AutoSellImage.fillAmount = 1;
        bFill = false;
        MainStatusCanvas.GetComponent<StatusUpdate>().SetNotification("자동 판매!!");
        if (gv.MapType ==1)
        {
            for (int i = 0; i < gv.ListHireCount.Count; i++)
            {
                if (gv.ListHireCount[i] < 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                }
                if (gv.ListMoney[i] > 0 && gv.ListHireCount[i] <0)
                {                   
                    
                    yield return new WaitForSeconds(0.2f);

                    GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                    GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                    GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                    GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                    GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                    GetText_Temp[GetText_Temp.Count - 1].SetActive(true);
                    float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                    if (Power <= 0)
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                        gv.Money += gv.ListMoney[i];
                    }
                    else
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                        gv.Money += gv.ListMoney[i] * Power;
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                    }
                    gv.ListMoney[i] = 0;
                    gv.ListCapacityNow[i] = 0;
                    
                    string MoneyCount = "Money" + i;
                    string strCapacityNow = "Capacity" + i;

                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                    PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                    PlayerPrefs.Save();
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.ListHireDesertCount.Count; i++)
            {
                if (gv.ListHireDesertCount[i] < 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                }
                if (gv.ListMoney[i] > 0 && gv.ListHireDesertCount[i] < 0)
                {
                    
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                    yield return new WaitForSeconds(0.2f);

                    GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                    GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                    GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                    GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                    GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                    GetText_Temp[GetText_Temp.Count - 1].SetActive(true);
                    float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                    if (Power <= 0)
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                        gv.Money += gv.ListMoney[i];
                    }
                    else
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                        gv.Money += gv.ListMoney[i] * Power;
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                    }

                    gv.ListMoney[i] = 0;
                    gv.ListCapacityNow[i] = 0;

                    string MoneyCount = "Money" + i;
                    string strCapacityNow = "Capacity" + i;

                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                    PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                    PlayerPrefs.Save();
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.ListHireIceCount.Count; i++)
            {
                if (gv.ListHireIceCount[i] < 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                }
                if (gv.ListMoney[i] > 0 && gv.ListHireIceCount[i] < 0)
                {
                  
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                    yield return new WaitForSeconds(0.2f);

                    GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                    GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                    GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                    GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                    GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                    GetText_Temp[GetText_Temp.Count - 1].SetActive(true);

                    float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                    if (Power <= 0)
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                        gv.Money += gv.ListMoney[i];
                    }
                    else
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                        gv.Money += gv.ListMoney[i] * Power;
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                    }

                    gv.ListMoney[i] = 0;
                    gv.ListCapacityNow[i] = 0;

                    string MoneyCount = "Money" + i;
                    string strCapacityNow = "Capacity" + i;

                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                    PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                    PlayerPrefs.Save();
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.ListHireForestCount.Count; i++)
            {
                if (gv.ListHireForestCount[i] < 0)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                }
                if (gv.ListMoney[i] > 0 && gv.ListHireForestCount[i] < 0)
                {
                    
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(i, true);
                    yield return new WaitForSeconds(0.2f);

                    GetText_Temp.Add(Instantiate(GetMoneyText as GameObject));
                    GetText_Temp[GetText_Temp.Count - 1].transform.SetParent(MainStatusCanvas.transform);
                    GetText_Temp[GetText_Temp.Count - 1].transform.localScale = GetMoneyText.transform.localScale;
                    GetText_Temp[GetText_Temp.Count - 1].transform.localPosition = GetMoneyText.transform.localPosition;
                    GetText_Temp[GetText_Temp.Count - 1].GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[i]);
                    GetText_Temp[GetText_Temp.Count - 1].SetActive(true);

                    float Power = gv.SaleBuffPower + gv.eachSellPower[i];

                    if (Power <= 0)
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "";
                        gv.Money += gv.ListMoney[i];
                    }
                    else
                    {
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString();
                        gv.Money += gv.ListMoney[i] * Power;
                        GetText_Temp[GetText_Temp.Count - 1].transform.Find("Text").gameObject.SetActive(true);
                    }

                    gv.ListMoney[i] = 0;
                    gv.ListCapacityNow[i] = 0;

                    string MoneyCount = "Money" + i;
                    string strCapacityNow = "Capacity" + i;

                    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[i]);
                    PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[i]);
                    PlayerPrefs.Save();
                }
            }
        }
        //StartCoroutine(AutoSellFillImage());
        AutoSellImage.fillAmount = 0;
        
        StartCoroutine(ListTextCler());
        StartCoroutine(AutoSellRoutine(sec));
    }
    int AutoSellFillindex = 0;
    bool bFill = false;
    float _time;
    private void Update()
    {
        if(bFill == true)
        {
            float index;
            _time += Time.deltaTime;
            index = _time / (float)AutoSellTime;            
            AutoSellImage.fillAmount = index;            
        }
        else
        {
            _time = 0;
        }
    }
    //IEnumerator AutoSellFillImage()
    //{
        //if(bFill == true)
        //{
        //    AutoSellFillindex++;
        //    if (AutoSellFillindex < AutoSellTime * 5)
        //    {
        //        float index = 0;
        //        index = 0.2f / (float)AutoSellTime;
        //        Debug.Log(AutoSellTime);
        //        AutoSellImage.fillAmount += index;
        //        yield return new WaitForSeconds(0.2f);
        //        StartCoroutine(AutoSellFillImage());
        //    }
        //    else
        //    {
        //        bFill = false;
        //    }
        //}
    //}
    int AutoSellTime = 0;
    public void ChangeMap()
    {
        bstartManager1 = false;
        bstartManager2 = false;
        bstartManager3 = false; 
    }
    public void InitRutin()
    {
        if (gv.ManagerStatus3 == 1)
        {
            //상급 매니저
            AutoSellTime = 10;
            _time = 0;
            StartCoroutine(AutoSellRoutine(10));            
        }
        else if (gv.ManagerStatus2 == 1)
        {
            //중급 매니저
            AutoSellTime = 30;
            _time = 0;
            StartCoroutine(AutoSellRoutine(30));            
        }
        else if (gv.ManagerStatus1 == 1 )
        {
            //하급 매니저
            AutoSellTime = 60;
            _time = 0;
            StartCoroutine(AutoSellRoutine(60));
        }        
    }
    public void AutoSell()
    {       
        if(gv.ManagerStatus1 ==1 && bstartManager1 == false)
        {
            Manager1.SetActive(true);
            gv.SaleBuffPower += 2;
            bstartManager1 = true;
        }
        if (gv.ManagerStatus2 == 1 && bstartManager2 ==  false)
        {
            Manager2.SetActive(true);
            gv.SaleBuffPower += 4;
            bstartManager2 = true;
        }
        if (gv.ManagerStatus3 == 1 && bstartManager3 == false)
        {
            Manager3.SetActive(true);
            gv.SaleBuffPower += 8;
            bstartManager3 = true;
        }
    }
    public void SellMineralRobot(GameObject obj,float money)
    {
        MainStatusCanvas.GetComponent<CoinParticleManager>().StartCoinsRobot(2, obj.transform.localPosition, 5, money);    
        Vector2 vec;
        vec = this.transform.localPosition;
        vec.x -= 1000;

    }
    public void SellMineral()
    {
        if(gv.selectNumber > -1)
        {
            //gv.Money += gv.ListMoney[gv.selectNumber];
            if(gv.ListMoney[gv.selectNumber] >0)
            {
                MainStatusCanvas.GetComponent<CoinParticleManager>().StartCoinParticle(5, Btn.transform.localPosition, 5);
                gv.BtnSell.GetComponent<Animator>().SetBool("isSell", true);                

                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetMinerAnim(gv.selectNumber, true);
                {
                    //gv.MInerspeechObj.SetActive(false);
                    Vector2 vec;
                    vec = this.transform.localPosition;
                    vec.x -= 1000;
                    //gv.MInerspeechObj.transform.localPosition = vec;
                }

            }
        }
    }
}
