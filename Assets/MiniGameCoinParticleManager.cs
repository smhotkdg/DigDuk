using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MiniGameCoinParticleManager : MonoBehaviour {

    public GameObject CoinParticleObj;
    public Text Money1;

    Vector2 targetpos;

    GlobalVariable gv;
    public AudioSource Audio;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {
        targetpos.x = -48;
        targetpos.y = 208f;
    }

    // Update is called once per frame
    void Update()
    {

    }

    IEnumerator MoneySetting()
    {
        if (gv.GhostLegSplitMoney < 1)
        {
            Audio.Play();
            //gv.Money += gv.SplitMoney;

            Money1.text = gv.ChangeMoney(gv.GhostLegGamePercentIndex);
            
            yield return new WaitForSeconds(0.01f); //스코어 올라가는 시간 조절 
        }
        else
        {
            
            //for (int i = 0; i < gv.SplitMoney; i = i + gv.splitNumber)
            {
                if(gv.GhostLegSplitMoney >0)
                {
                    //gv.Money -= gv.GhostLegSplitMoney;
                    //PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    //PlayerPrefs.Save();
                    //gv.GhostLegMoney += gv.GhostLegSplitMoney;
                    //Money1.text = gv.ChangeMoney(gv.GhostLegMoney);
                }
            
                
                yield return new WaitForSeconds(0.01f); //스코어 올라가는 시간 조절 
            }
        }
        gv.ParticleCount++;

        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckMoneyQuest());
    }

    //startPos -64 659
    //EndPos -43 154
    public void StartCoinParticle(int number,  int index,int percentIndex)
    {
        

        if (percentIndex == 0)
        {
            gv.GhostLegGamePercentIndex = (float)(gv.Money * 0.3);
            //gv.GhostLegSplitMoney = gv.GhostLegGamePercentIndex/10;

        }
        else if (percentIndex == 1)
        {
            gv.GhostLegGamePercentIndex = (float)(gv.Money * 0.5);
            //gv.GhostLegSplitMoney = gv.GhostLegGamePercentIndex / 10;
        }
        else
        {
            gv.GhostLegGamePercentIndex = (float)(gv.Money);
            //gv.GhostLegSplitMoney = gv.GhostLegGamePercentIndex / 10;
        }

        gv.Money -= gv.GhostLegGamePercentIndex;
        gv.GhostLegMoney = gv.GhostLegGamePercentIndex;
        PlayerPrefs.SetFloat("Money", (float)gv.Money);
        PlayerPrefs.Save();        
        Money1.text = gv.ChangeMoney(gv.GhostLegGamePercentIndex);

        List<GameObject> Coinlist = new List<GameObject>();

        for (int i = 0; i < number; i++)
        {
            Coinlist.Add(Instantiate(CoinParticleObj) as GameObject);

            Coinlist[i].transform.SetParent(CoinParticleObj.transform.parent);
            Coinlist[i].transform.localScale = CoinParticleObj.transform.localScale;

            Coinlist[i].SetActive(true);

        }
    
        Vector3[] ve = new Vector3[number];
        for (int i = 0; i < number; i++)
        {
            float randx = -93f;//Random.Range(-590, 520);
            float randy = 751;// Random.Range(-300f, 0);
            ve[i].x = randx; ve[i].y = randy;
            Coinlist[i].transform.localPosition = ve[i];
        }
        float Speed = Random.Range(0.01f, 0.03f);
        float CoinSpeed = Random.Range(0.03f, 0.06f);
        for (int i = 0; i < number; i++)
        {
            Speed = Random.Range(0.01f, 0.06f);
            CoinSpeed = Random.Range(0.13f, 0.56f);
            StartCoroutine(SetCoins(Coinlist[i], true, targetpos, Speed, CoinSpeed, gv.splitNumber));
        }
    }


    IEnumerator SetCoins(GameObject Temp, bool status, Vector2 targetpos, float speed, float coinSpeed, int number)
    {
        yield return new WaitForSeconds(speed);

        //Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, 0.06f);
        Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, coinSpeed);
        // 벡터간 거리를 재어보고
        float dis = Vector3.Distance(Temp.transform.localPosition, targetpos);
        if (dis < 50.0f)
        {
            coinSpeed = coinSpeed * 2;
        }
        // OK! 이동 완료! 멈추자.
        if (dis < 15.0f)
        {
            Temp.GetComponent<Animator>().SetBool("isSpin", false);

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
            StartCoroutine(SetCoins(Temp, true, targetpos, speed, coinSpeed, number));
        }

    }
}

