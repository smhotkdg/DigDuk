using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BoxClickManager : MonoBehaviour
{

    // Use this for initialization
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    bool bflag = true;
    public void OnClickBox(int index)
    {
        if (bflag == true)
        {
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("DepthGiftBoxClick");
            this.GetComponent<Animator>().SetBool("isOpen", true);
            StartCoroutine(StartText());
            gv.rewardBoxTotalCount++;
            if (gv.rewardBoxTotalCount >= 12)
            {
                GameObject.Find("DepthRewardBoxCanvas").GetComponent<DepthRewardBoxCanvasManager>().SetBtnEnd();
            }
            bflag = false;


            if (index == 1)
            {
                int randomRange = Random.Range(0, 100);
                if (randomRange < 200)
                {
                    //if (gv.GetAverageMoney() == 0)
                    {
                        double cost = 0;

                        float weight = 1;
                        int depth = 0;
                        if (gv.MapType == 1)
                        {
                            depth = gv.Depth;
                        }
                        if (gv.MapType == 2)
                        {
                            depth = gv.DesertDepth;

                            weight = 5;
                        }
                        if (gv.MapType == 3)
                        {
                            depth = gv.IceDepth;
                            weight = 10;
                        }
                        if (gv.MapType == 4)
                        {
                            depth = gv.ForestDepth;
                            weight = 100;
                        }

                        if (gv.MapType == 1)
                        {
                            cost = gv.ListCostMinerals[gv.Depth - 1] * 20 * weight;
                        }
                        if (gv.MapType == 2)
                        {
                            cost = gv.ListCostMinerals[gv.DesertDepth - 1] * 20 * weight;
                        }
                        if (gv.MapType == 3)
                        {
                            cost = gv.ListCostMinerals[gv.IceDepth - 1] * 20 * weight;
                        }
                        if (gv.MapType == 4)
                        {
                            cost = gv.ListCostMinerals[gv.ForestDepth - 1] * 20 * weight;
                        }
                        gv.Money += cost;

                        PlayerPrefs.SetFloat("Money", (float)gv.Money);
                        PlayerPrefs.Save();
                        this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                    }
                    //else
                    //{
                    //    gv.Money += gv.GetAverageMoney()/10;
                    //    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10) + "\n";
                    //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    //    PlayerPrefs.Save();
                    //}
                    
                }
                else
                {
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 1));
                    {
                    }
                    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "블랙코인 + " + 1 + "\n";
                }

            }
            if (index == 2)
            {
                int randomRange = Random.Range(0, 100);
                if (randomRange < 200)
                {
                    //if (gv.GetAverageMoney() == 0)
                    {
                        double cost = 0;

                        float weight = 1;
                        int depth = 0;
                        if (gv.MapType == 1)
                        {
                            depth = gv.Depth;
                        }
                        if (gv.MapType == 2)
                        {
                            depth = gv.DesertDepth;

                            weight = 5;
                        }
                        if (gv.MapType == 3)
                        {
                            depth = gv.IceDepth;
                            weight = 10;
                        }
                        if (gv.MapType == 4)
                        {
                            depth = gv.ForestDepth;
                            weight = 100;
                        }

                        if (gv.MapType == 1)
                        {
                            cost = gv.ListCostMinerals[gv.Depth - 1] * 23 * weight;
                        }
                        if (gv.MapType == 2)
                        {
                            cost = gv.ListCostMinerals[gv.DesertDepth - 1] * 23 * weight;
                        }
                        if (gv.MapType == 3)
                        {
                            cost = gv.ListCostMinerals[gv.IceDepth - 1] * 23 * weight;
                        }
                        if (gv.MapType == 4)
                        {
                            cost = gv.ListCostMinerals[gv.ForestDepth - 1] * 23 * weight;
                        }
                        gv.Money += cost;

                        PlayerPrefs.SetFloat("Money", (float)gv.Money);
                        PlayerPrefs.Save();
                        this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                    }
                    //else
                    //{
                    //    gv.Money += gv.GetAverageMoney()/10 * 1.5f;
                    //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    //    PlayerPrefs.Save();
                    //    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 * 1.5f) + "\n";
                    //}
                }
                else
                {
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 1))
                    {
                    }
                    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "블랙코인 + " + 1 + "\n";
                }
            }
            if (index == 3)
            {
                int randomRange = Random.Range(0, 100);
                if (randomRange < 200)
                {
                    //if (gv.GetAverageMoney() == 0)
                    {
                        double cost = 0;

                        float weight = 1;
                        int depth = 0;
                        if (gv.MapType == 1)
                        {
                            depth = gv.Depth;
                        }
                        if (gv.MapType == 2)
                        {
                            depth = gv.DesertDepth;

                            weight = 5;
                        }
                        if (gv.MapType == 3)
                        {
                            depth = gv.IceDepth;
                            weight = 10;
                        }
                        if (gv.MapType == 4)
                        {
                            depth = gv.ForestDepth;
                            weight = 100;
                        }

                        if (gv.MapType == 1)
                        {
                            cost = gv.ListCostMinerals[gv.Depth - 1] * 26 * weight;
                        }
                        if (gv.MapType == 2)
                        {
                            cost = gv.ListCostMinerals[gv.DesertDepth - 1] * 26 * weight;
                        }
                        if (gv.MapType == 3)
                        {
                            cost = gv.ListCostMinerals[gv.IceDepth - 1] * 26 * weight;
                        }
                        if (gv.MapType == 4)
                        {
                            cost = gv.ListCostMinerals[gv.ForestDepth - 1] * 26 * weight;
                        }
                        gv.Money += cost;

                        PlayerPrefs.SetFloat("Money", (float)gv.Money);
                        PlayerPrefs.Save();
                        this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                    }
                    //else
                    //{
                    //    gv.Money += gv.GetAverageMoney()/10 * 1.8f;
                    //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    //    PlayerPrefs.Save();
                    //    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 * 1.8f) + "\n";
                    //}
                }
                else
                {
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 2))
                    {
                    }
                    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "블랙코인 + " + 2 + "\n";
                }
            }
            if (index == 4)
            {
                int randomRange = Random.Range(0, 100);
                if (randomRange < 200)
                {
                    //if (gv.GetAverageMoney() == 0)
                    {
                        double cost = 0;

                        float weight = 1;
                        int depth = 0;
                        if (gv.MapType == 1)
                        {
                            depth = gv.Depth;
                        }
                        if (gv.MapType == 2)
                        {
                            depth = gv.DesertDepth;

                            weight = 5;
                        }
                        if (gv.MapType == 3)
                        {
                            depth = gv.IceDepth;
                            weight = 10;
                        }
                        if (gv.MapType == 4)
                        {
                            depth = gv.ForestDepth;
                            weight = 100;
                        }

                        if (gv.MapType == 1)
                        {
                            cost = gv.ListCostMinerals[gv.Depth - 1] * 30 * weight;
                        }
                        if (gv.MapType == 2)
                        {
                            cost = gv.ListCostMinerals[gv.DesertDepth - 1] * 30 * weight;
                        }
                        if (gv.MapType == 3)
                        {
                            cost = gv.ListCostMinerals[gv.IceDepth - 1] * 30 * weight;
                        }
                        if (gv.MapType == 4)
                        {
                            cost = gv.ListCostMinerals[gv.ForestDepth - 1] * 30 * weight;
                        }
                        gv.Money += cost;

                        PlayerPrefs.SetFloat("Money", (float)gv.Money);
                        PlayerPrefs.Save();
                        this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                    }
                    //else
                    //{
                    //    gv.Money += gv.GetAverageMoney()/10 * 2;

                    //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                    //    PlayerPrefs.Save();
                    //    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 * 2) + "\n";
                    //}
                    
                }
                else
                {
                    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 2))
                    {
                    }
                    this.transform.Find("Text").gameObject.GetComponent<Text>().text = "블랙코인 + " + 2 + "\n";
                }

            }
        }
    }
    IEnumerator StartText()
    {
        yield return new WaitForSeconds(0.3f);
        this.transform.Find("Text").gameObject.SetActive(true);
    }
}
