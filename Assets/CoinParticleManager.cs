using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CoinParticleManager : MonoBehaviour {

    // Use this for initialization
    public GameObject HoitStoneParnet;
    public GameObject HoitStone;
    List<GameObject> ListHoitStone = new List<GameObject>();

    public GameObject CoinParticleObj;
    public Text Money1;
    public Text Money2;
    public Text GhostLegText;
    public Button GhostLegBtn;
    public Image GhostLegBtnImage;
    Vector2 targetpos;
    public GameObject GetMoneyText;
    GlobalVariable gv;
    public AudioSource Audio;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
       //targetpos.x = -64.6f;
        //targetpos.y = 659.4f;

        targetpos.x = -93.0f;
        targetpos.y = 677.0f;
        GhostLegText.text = "0";
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    int count = 0;
    IEnumerator MoneySetting()
    { 
        if(gv.SplitMoney < gv.scaleFactor)
        {
            Audio.Play();
            //gv.Money += gv.SplitMoney;
            //돈저장
            //PlayerPrefs.SetFloat("Money", (float)gv.Money);
            //PlayerPrefs.Save();

            //Money1.text = gv.ChangeMoney(gv.Money);
            //Money2.text = gv.ChangeMoney(gv.Money);
            yield return new WaitForSeconds(0.01f); //스코어 올라가는 시간 조절 
        }
        else
        {
         
            //for (int i = 0; i < 10; i++)
            {

                //gv.Money += gv.SplitMoney;// /10;
                //PlayerPrefs.SetFloat("Money", (float)gv.Money);
                //PlayerPrefs.Save();
                gv.GhostLegMoney -= gv.SplitMoney;// / 10;         
                count++;
                if (gv.GhostLegMoney < gv.scaleFactor || count ==10)
                {
                    GhostLegBtn.interactable = true;
                    Color _color = GhostLegBtnImage.color;
                    _color.a = 1f;
                    GhostLegBtnImage.color = _color;
                    gv.GhostLegMoney = 0;
                    GhostLegText.text = "0";
                    count = 0;
                }
                else
                {
                    GhostLegText.text = gv.ChangeMoney(gv.GhostLegMoney);
                }
                Money1.text = gv.ChangeMoney(gv.Money);
                Money2.text = gv.ChangeMoney(gv.Money);
                yield return new WaitForSeconds(0.01f); //스코어 올라가는 시간 조절 
            }
        };


        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckMoneyQuest());
    }
    
    public void StartCoinParticle(int number, Vector2 StartPos,int index)
    {

        //StartPos.x = StartPos.x;
        GameObject GetText_temp;
        GetText_temp = Instantiate(GetMoneyText as GameObject);

        GetText_temp.transform.SetParent(this.transform);
        GetText_temp.transform.localScale = GetMoneyText.transform.localScale;
        GetText_temp.transform.localPosition = GetMoneyText.transform.localPosition;
        GetText_temp.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[gv.selectNumber]);


        float Power = gv.SaleBuffPower + gv.eachSellPower[gv.selectNumber];

        if(Power <= 0)
        {
            GetText_temp.transform.Find("Text").GetComponent<Text>().text = "";
            //gv.SplitMoney = (float)gv.ListMoney[gv.selectNumber] / number;
            gv.SplitMoney = (float)gv.ListMoney[gv.selectNumber] ;

        }
        else
        {
            GetText_temp.transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString("N1");
            //gv.SplitMoney = (float)(gv.ListMoney[gv.selectNumber] * Power) / number;
            gv.SplitMoney = (float)(gv.ListMoney[gv.selectNumber] * Power) ;
            GetText_temp.transform.Find("Text").gameObject.SetActive(true);
        }


        gv.Money += gv.SplitMoney;
        //돈저장
        PlayerPrefs.SetFloat("Money", (float)gv.Money);
        PlayerPrefs.Save();
        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 2)
            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(2, (float)gv.Money);

        Money1.text = gv.ChangeMoney(gv.Money);
        Money2.text = gv.ChangeMoney(gv.Money);


        gv.ListMoney[gv.selectNumber] = 0;
        gv.ListCapacityNow[gv.selectNumber] = 0;

        string MoneyCount = "Money" + gv.selectNumber;
        string strCapacityNow = "Capacity" + gv.selectNumber;

        PlayerPrefs.SetFloat(strCapacityNow, (float)gv.ListCapacityNow[gv.selectNumber]);
        PlayerPrefs.SetFloat(MoneyCount, (float)gv.ListMoney[gv.selectNumber]);
        PlayerPrefs.Save();

        gv.listOwnMinerals[index - 1] = 0;
        int indexM = index;
        

        //광물 저장
        //if(gv.MapType ==1)
        //{
        //    string strMinerals = "MineralNormal" + indexM;
        //    PlayerPrefs.SetFloat(strMinerals, (float)gv.listOwnMinerals[index - 1]);
        //    PlayerPrefs.Save();
        //}
        //if (gv.MapType == 2)
        //{
        //    string strMinerals = "MineralDesert" + indexM;
        //    PlayerPrefs.SetFloat(strMinerals, (float)gv.listOwnMinerals[index - 1]);
        //    PlayerPrefs.Save();
        //}
        //if (gv.MapType == 3)
        //{
        //    string strMinerals = "MineralIce" + indexM;
        //    PlayerPrefs.SetFloat(strMinerals, (float)gv.listOwnMinerals[index - 1]);
        //    PlayerPrefs.Save();
        //}
        //if (gv.MapType == 4)
        //{
        //    string strMinerals = "MineralForest" + indexM;
        //    PlayerPrefs.SetFloat(strMinerals, (float)gv.listOwnMinerals[index - 1]);
        //    PlayerPrefs.Save();
        //}



        List<GameObject> Coinlist = new List<GameObject>();
        
        Vector2 vec = StartPos;
        vec.y -= 330;
        //CoinParticleObj.transform.localPosition = vec;

        
        for (int i = 0; i < number; i++)
        {
            Coinlist.Add(Instantiate(CoinParticleObj) as GameObject);

            Coinlist[i].transform.SetParent(this.transform);
            Coinlist[i].transform.localScale = CoinParticleObj.transform.localScale;

            Coinlist[i].SetActive(true);
            
        }


        gv.splitNumber = 1;
        if (gv.SplitMoney > 10)
        {
            gv.splitNumber = 10;
        }
        if (gv.SplitMoney > 100)
        {
            gv.splitNumber = 100;
        }

        if (gv.SplitMoney > 1000)
        {
            gv.splitNumber =  1000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber =  10000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber = 10000;
        }
        if (gv.SplitMoney > 100000)
        {
            gv.splitNumber = 100000;
        }
        if (gv.SplitMoney > 1000000)
        {
            gv.splitNumber = 1000000;
        }
        if (gv.SplitMoney > 10000000)
        {
            gv.splitNumber = 10000000;
        }
        if (gv.SplitMoney > 100000000)
        {
            gv.splitNumber = 100000000;
        }
        Vector3[] ve = new Vector3[number];
        for (int i = 0; i < number; i++)
        {
            float randx = Random.Range(-340 , 340);
            float randy = Random.Range(-300, 300);
            ve[i].x = randx; ve[i].y = randy;
            Coinlist[i].transform.localPosition = ve[i];
        }
        float Speed = Random.Range(0.01f, 0.03f);
        float CoinSpeed = Random.Range(0.03f, 0.16f);
        for(int i=0; i< number; i++)
        {
            Speed = Random.Range(0.025f, 0.03f);
            CoinSpeed = Random.Range(0.10f, 0.16f);
            StartCoroutine(SetCoins(Coinlist[i], true, targetpos, Speed, CoinSpeed, gv.splitNumber, GetText_temp));        
        }
    }

    public void StartCoinsRobot(int number, Vector2 StartPos, int index,float money_in)
    {

        //StartPos.x = StartPos.x;
        GameObject GetText_temp;
        GetText_temp = Instantiate(GetMoneyText as GameObject);

        GetText_temp.transform.SetParent(this.transform);
        GetText_temp.transform.localScale = GetMoneyText.transform.localScale;
        GetText_temp.transform.localPosition = GetMoneyText.transform.localPosition;
        GetText_temp.GetComponent<Text>().text = gv.ChangeMoney(money_in);


        float Power = gv.SaleBuffPower ;

        if (Power <= 0)
        {
            GetText_temp.transform.Find("Text").GetComponent<Text>().text = "";
            //gv.SplitMoney = (float)gv.ListMoney[gv.selectNumber] / number;
            gv.SplitMoney = (float)money_in;

        }
        else
        {
            GetText_temp.transform.Find("Text").GetComponent<Text>().text = "x " + Power.ToString("N1");
            //gv.SplitMoney = (float)(gv.ListMoney[gv.selectNumber] * Power) / number;
            gv.SplitMoney = (float)(money_in * Power);
            GetText_temp.transform.Find("Text").gameObject.SetActive(true);
        }


        gv.Money += gv.SplitMoney;
        //돈저장
        PlayerPrefs.SetFloat("Money", (float)gv.Money);
        PlayerPrefs.Save();
        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 2)
            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(2, (float)gv.Money);

        Money1.text = gv.ChangeMoney(gv.Money);
        Money2.text = gv.ChangeMoney(gv.Money);
                

        string MoneyCount = "Money" + gv.selectNumber;
        string strCapacityNow = "Capacity" + gv.selectNumber;

        gv.listOwnMinerals[index - 1] = 0;
        int indexM = index;




        List<GameObject> Coinlist = new List<GameObject>();

        Vector2 vec = StartPos;
        vec.y -= 330;
        //CoinParticleObj.transform.localPosition = vec;


        for (int i = 0; i < number; i++)
        {
            Coinlist.Add(Instantiate(CoinParticleObj) as GameObject);

            Coinlist[i].transform.SetParent(this.transform);
            Coinlist[i].transform.localScale = CoinParticleObj.transform.localScale;

            Coinlist[i].SetActive(true);

        }


        gv.splitNumber = 1;
        if (gv.SplitMoney > 10)
        {
            gv.splitNumber = 10;
        }
        if (gv.SplitMoney > 100)
        {
            gv.splitNumber = 100;
        }

        if (gv.SplitMoney > 1000)
        {
            gv.splitNumber = 1000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber = 10000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber = 10000;
        }
        if (gv.SplitMoney > 100000)
        {
            gv.splitNumber = 100000;
        }
        if (gv.SplitMoney > 1000000)
        {
            gv.splitNumber = 1000000;
        }
        if (gv.SplitMoney > 10000000)
        {
            gv.splitNumber = 10000000;
        }
        if (gv.SplitMoney > 100000000)
        {
            gv.splitNumber = 100000000;
        }
        Vector3[] ve = new Vector3[number];
        for (int i = 0; i < number; i++)
        {
            float randx = Random.Range(-340, 340);
            float randy = Random.Range(-300, 300);
            ve[i].x = randx; ve[i].y = randy;
            Coinlist[i].transform.localPosition = ve[i];
        }
        float Speed = Random.Range(0.01f, 0.03f);
        float CoinSpeed = Random.Range(0.03f, 0.16f);
        for (int i = 0; i < number; i++)
        {
            Speed = Random.Range(0.025f, 0.03f);
            CoinSpeed = Random.Range(0.10f, 0.16f);
            StartCoroutine(SetCoins(Coinlist[i], true, targetpos, Speed, CoinSpeed, gv.splitNumber, GetText_temp));
        }
    }


    public void StartCoinParticleMoney(int number,  double Money)
    {
        GhostLegText.text = gv.ChangeMoney(Money);
        gv.GhostLegMoney = Money;
        gv.SplitMoney = Money / number;

        gv.Money += Money;
        PlayerPrefs.SetFloat("Money", (float)gv.Money);
        PlayerPrefs.Save();

        List<GameObject> Coinlist = new List<GameObject>();

        Vector2 vec = new Vector2();
        vec.y -= 330;
        //CoinParticleObj.transform.localPosition = vec;
        GameObject GetText_temp;
        GetText_temp = Instantiate(GetMoneyText as GameObject);

        GetText_temp.transform.SetParent(this.transform);
        GetText_temp.transform.localScale = GetMoneyText.transform.localScale;
        GetText_temp.transform.localPosition = GetMoneyText.transform.localPosition;
        if(gv.selectNumber >-1)
        {
            GetText_temp.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[gv.selectNumber]);
        }
        
        GetText_temp.transform.Find("Text").GetComponent<Text>().text = "x " +1;

        for (int i = 0; i < number; i++)
        {
            Coinlist.Add(Instantiate(CoinParticleObj) as GameObject);

            Coinlist[i].transform.SetParent(this.transform);
            Coinlist[i].transform.localScale = CoinParticleObj.transform.localScale;

            Coinlist[i].SetActive(true);

        }
        gv.splitNumber = 1;
        if (gv.SplitMoney > 10)
        {
            gv.splitNumber = 10;
        }
        if (gv.SplitMoney > 100)
        {
            gv.splitNumber = 100;
        }

        if (gv.SplitMoney > 1000)
        {
            gv.splitNumber = 1000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber = 10000;
        }
        if (gv.SplitMoney > 10000)
        {
            gv.splitNumber = 10000;
        }
        if (gv.SplitMoney > 100000)
        {
            gv.splitNumber = 100000;
        }
        if (gv.SplitMoney > 1000000)
        {
            gv.splitNumber = 1000000;
        }
        if (gv.SplitMoney > 10000000)
        {
            gv.splitNumber = 10000000;
        }
        if (gv.SplitMoney > 100000000)
        {
            gv.splitNumber = 100000000;
        }
        Vector3[] ve = new Vector3[number];
        for (int i = 0; i < number; i++)
        {
            //float randx = Random.Range(-590, 520);
            float randx = -5;
            float randy = 130f;
            ve[i].x = randx; ve[i].y = randy;
            Coinlist[i].transform.localPosition = ve[i];
        }
        float Speed = Random.Range(0.01f, 0.03f);
        float CoinSpeed = Random.Range(0.03f, 0.16f);
        for (int i = 0; i < number; i++)
        {
            Speed = Random.Range(0.005f, 0.03f);
            CoinSpeed = Random.Range(0.03f, 0.16f);
            StartCoroutine(SetCoins(Coinlist[i], true, targetpos, Speed, CoinSpeed, gv.splitNumber, GetText_temp));
        }
    }


    IEnumerator SetCoins(GameObject Temp, bool status, Vector2 targetpos,float speed,float coinSpeed,int number,GameObject GetText)
    {
        yield return new WaitForSeconds(speed);
       
        //Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, 0.06f);
        Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, coinSpeed);
        // 벡터간 거리를 재어보고
        float dis = Vector3.Distance(Temp.transform.localPosition, targetpos);
        if(dis < 50.0f)
        {
            coinSpeed = coinSpeed * 2;
        }
        // OK! 이동 완료! 멈추자.
        if (dis < 15.0f)
        {
            Temp.GetComponent<Animator>().SetBool("isSpin", false);
            if(GetText != null)
                GetText.SetActive(true);
            StartCoroutine(DestoryText(GetText));
        }

        if (dis < 5.1f)
        {        
            Destroy(Temp.gameObject, 0.2f);            
            status = false;
            
            Audio.Play();
            
            StartCoroutine(MoneySetting());
        }

     

        if (status == true)
        {
            StartCoroutine(SetCoins(Temp, true, targetpos, speed, coinSpeed,number,GetText));
        }
    
    }

    IEnumerator DestoryText(GameObject temp)
    {
        yield return new WaitForSeconds(0.5f);
        {
            Destroy(temp.gameObject, 0.2f);
        }
    }


    public void HoitStoneStart(Vector2 startPos,Transform trans)
    {
        ListHoitStone.Add(Instantiate(HoitStone));
        Vector2 vec;

        ListHoitStone[ListHoitStone.Count - 1].transform.SetParent(trans);
        vec.x = 1; vec.y = 1;
        ListHoitStone[ListHoitStone.Count - 1].transform.localScale = vec;
        vec.x = startPos.x;
        vec.y = startPos.y;
        ListHoitStone[ListHoitStone.Count - 1].transform.localPosition = vec;
        ListHoitStone[ListHoitStone.Count - 1].SetActive(true);
    }
    IEnumerator EndHoitStoneR()
    {
        yield return new WaitForSeconds(0.5f);
        if(ListHoitStone.Count >0)
        {
            Destroy(ListHoitStone[0]);
            ListHoitStone.RemoveAt(0);
        }        
    }
    public void EndHoitStone()
    {
        StartCoroutine(EndHoitStoneR());
    }
}
