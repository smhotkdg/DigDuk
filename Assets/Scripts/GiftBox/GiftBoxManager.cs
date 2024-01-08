using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiftBoxManager : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> listBox;
    public List<GameObject> listBoxText = new List<GameObject>();
    //depth = -350
    //default Y = 590
    //0 depth x -> -240 ~ 240
    //1 이상 depth -> x1 = -350 x2 = -115
    int index = -1;
    Vector2 defaultvec = new Vector2();
    bool StartBox = false;
    GlobalVariable gv;
    Vector2 Vec = new Vector2();
    int boxtype = -1;
    bool bOpen = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        defaultvec.x = 730;
        defaultvec.y = 340;
        StartCoroutine(BoxRoutine());
	}

    IEnumerator BoxRoutine()
    {
        //yield return new WaitForSeconds(41);
        yield return new WaitForSeconds(2);
        Vector2 PosVec = new Vector2();
        int deptIndex = 0;
        if (gv.MapType == 1)
        {
            deptIndex = gv.Depth;
        }
        if (gv.MapType == 2)
        {
            deptIndex = gv.DesertDepth;
        }
        if (gv.MapType == 3)
        {
            deptIndex = gv.IceDepth;
        }
        if (gv.MapType == 4)
        {
            deptIndex = gv.ForestDepth;
        }

        if (StartBox == false)
        {
            int PositionRand = Random.Range(1, deptIndex + 1);
            
            int margin = 0;
            if (deptIndex - 4 >= 0)
            {
                margin = (deptIndex - 3) * 175;            
            }
            
            if (PositionRand == 0)
            {
                int xPosRand = Random.Range(-240, 241);              
                PosVec.y = 610 + margin;
                PosVec.x = xPosRand;
            }
            else
            {
                PosVec.y = -((PositionRand-1) * 350) + 220 + margin; 
                int xPosRand2 = Random.Range(0, 2);
                if (xPosRand2 == 0)
                {
                    PosVec.x = -115;
                    //PosVec.x = -350;
                }
                else
                {
                    PosVec.x = -115;
                }
            }
            
            //여기 가중치 줘서 랜덤발생
            int BoxRand = Random.Range(0, 7);

            //if(BoxRand %5 ==0)
            if (BoxRand == 1)
            {
                boxtype = 1;
                listBox[0].transform.localPosition = PosVec;
                StartBox = true;
                bOpen = false;
            }
            //else if(BoxRand %10 ==0)
            else if (BoxRand == 2)
            {
                boxtype = 2;
                listBox[1].transform.localPosition = PosVec;
                StartBox = true;
                bOpen = false;
            }
            //else if(BoxRand > 45)
            else if (BoxRand == 3)
            {
                boxtype = 3;
                listBox[2].transform.localPosition = PosVec;
                StartBox = true;
                bOpen = false;
            }
            //else if(BoxRand ==11)
            else if (BoxRand == 4)
            {
                boxtype = 4;
                listBox[3].transform.localPosition = PosVec;
                StartBox = true;
                bOpen = false;
            }
            else
            {
                StartCoroutine(BoxRoutine());
            }
            
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ClickBox(int i)
    {
        if(bOpen == false)
        {
            int AdsBoxRand = Random.Range(0, 100);            
            bOpen = true;
            if( i >0)
            {
                listBox[i - 1].GetComponent<Animator>().SetBool("isOpen", true);
                index = i;
                //GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio(4);
                GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("Open");
                //if (AdsBoxRand < 150)
                if (AdsBoxRand < 7)                
                {
                    int rand = 0;
                    if(gv.MapType ==1)
                    {
                        if(gv.DynamiteAdsCount < 2 && gv.DynamiteAdsCount > 2)
                        {
                            rand = Random.Range(0, 7);
                        }
                        else
                        {
                            rand = Random.Range(0, 6);
                        }
                    }
                    if (gv.MapType == 2)
                    {
                        if (gv.DynamiteAdsCountDesert < 2 && gv.DynamiteAdsCountDesert > 2)
                        {
                            rand = Random.Range(0, 7);
                        }
                        else
                        {
                            rand = Random.Range(0, 6);
                        }
                    }
                    if (gv.MapType == 3)
                    {
                        if (gv.DynamiteAdsCountIce < 2 && gv.DynamiteAdsCountIce > 2)
                        {
                            rand = Random.Range(0, 7);
                        }
                        else
                        {
                            rand = Random.Range(0, 6);
                        }
                    }
                    if (gv.MapType == 4)
                    {
                        if (gv.DynamiteAdsCountForest < 2 && gv.DynamiteAdsCountForest > 2)
                        {
                            rand = Random.Range(0, 7);
                        }
                        else
                        {
                            rand = Random.Range(0, 6);
                        }
                    }
                    gv.iSelectAdsBox = rand;
                    //gv.iSelectAdsBox = 6;
                    GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressAdsBoxCanavsObj(1);
                }
                else
                {
                    if (boxtype == 1)
                    {
                        int randomRange = Random.Range(0, 100);
                        if (randomRange < 200)
                        {
                            //if (gv.GetAverageMoney() == 0)
                            {
                                //gv.Money += 20 * gv.scaleFactor;

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
                                listBoxText[boxtype - 1].gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                            }
                            //else
                            //{
                            //    //gv.Money += gv.GetMoneyPos() / 40;
                            //    gv.Money += gv.GetAverageMoney()/10 ;
                            //    listBoxText[boxtype - 1].GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney() /10 ) + "\n";
                            //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            //    PlayerPrefs.Save();
                            //}
                         
                        }
                        //else
                        //{
                        //    SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                        //    if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 1))
                        //    {
                        //    }
                        //    listBoxText[boxtype - 1].GetComponent<Text>().text = "블랙코인 + " + 1 + "\n";
                        //}

                        listBoxText[boxtype - 1].SetActive(true);

                    }
                    if (boxtype == 2)
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
                                listBoxText[boxtype - 1].gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                              
                            }
                            //else
                            //{
                            //    gv.Money += gv.GetAverageMoney() /10 * 1.5f;
                            //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            //    PlayerPrefs.Save();
                            //    listBoxText[boxtype - 1].GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 *1.5f) + "\n";
                            //}
                            
                        }
                        else
                        {
                            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                            if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 1))
                            {
                            }
                            listBoxText[boxtype - 1].GetComponent<Text>().text = "블랙코인 + " + 1 + "\n";
                        }

                        listBoxText[boxtype - 1].SetActive(true);
                    }
                    if (boxtype == 3)
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
                                listBoxText[boxtype - 1].gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                            }
                            //else
                            //{
                            //    gv.Money += gv.GetAverageMoney()/10 *1.8f;
                            //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            //    PlayerPrefs.Save();
                            //    listBoxText[boxtype - 1].GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 * 1.8f) + "\n";
                            //}
                            
                        }
                        else
                        {
                            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                            if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 2))
                            {
                            }
                            listBoxText[boxtype - 1].GetComponent<Text>().text = "블랙코인 + " + 2 + "\n";
                        }

                        listBoxText[boxtype - 1].SetActive(true);
                    }
                    if (boxtype == 4)
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
                                listBoxText[boxtype - 1].gameObject.GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(cost) + "\n";
                            }
                            //else
                            //{
                            //    gv.Money += gv.GetAverageMoney()/10 * 2;
                            //    PlayerPrefs.SetFloat("Money", (float)gv.Money);
                            //    PlayerPrefs.Save();
                            //    listBoxText[boxtype - 1].GetComponent<Text>().text = "골드 + " + gv.ChangeMoney(gv.GetAverageMoney()/10 * 2) + "\n";
                            //}
                        }
                        else
                        {
                            SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
                            if (0 != SIS.DBManager.IncreaseFunds("blackcoin", 2))
                            {
                            }
                            listBoxText[boxtype - 1].GetComponent<Text>().text = "블랙코인 + " + 2 + "\n";
                        }

                        listBoxText[boxtype - 1].SetActive(true);
                    }
                }
             
            }
            StartCoroutine(ReSetBox());            
        }      
    }
    public void ResetBox()
    {
        for (int i = 0; i < listBoxText.Count; i++)
        {
            if (listBoxText[i].activeSelf == true)
                listBoxText[i].SetActive(false);
            listBox[i].transform.localPosition = defaultvec;
            listBox[i].GetComponent<Animator>().SetBool("isOpen", false);
        }
      
        StartBox = false;
        StartCoroutine(BoxRoutine());
    }
    
    IEnumerator ReSetBox()
    {
        yield return new WaitForSeconds(1.5f);
        for(int i=0;i< listBoxText.Count; i++)
        {
            if(listBoxText[i].activeSelf == true)
                listBoxText[i].SetActive(false);
        }
        listBox[index -1].transform.localPosition = defaultvec;
        listBox[index - 1].GetComponent<Animator>().SetBool("isOpen", false);
        StartBox = false;
        StartCoroutine(BoxRoutine());
    }
}
