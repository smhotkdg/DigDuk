using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class KingMineralsMinerController : MonoBehaviour
{

    // Use this for initialization    
    public GameObject MainStaus;
    GameObject TextCountObj = null;
    GameObject MineralsObj = null;

    List<GameObject> ListMinerals = new List<GameObject>();
    GlobalVariable gv;
    bool bSplit = false;
    int iMinerNumber = -1;
    float iTime = 0;
    public GameObject MiningAlgorithm;
    MiningAlgorithm myMining;
    bool bStartMinerAnim = false;
    float DefaultSpeed;

    List<Image> PrograssImg = new List<Image>();
    Text TextRemainTime = null;
    bool bMiningComplete = false;
    GameObject ZzImage;
    //List<GameObject> TextMineralCountObj = new List<GameObject>();
    List<Text> TextMineralCount = new List<Text>();
    List<GameObject> MineralsProgass = new List<GameObject>();
    float m_RemainTime = 0;
    bool bStartProgass = false;
    int PrevIndex = -1;
    Vector2 Pos;
    private void Awake()
    {
        gv = GlobalVariable.Instance;

        if (tag == "Miner")
        {
            MineralsObj = this.transform.Find("MineralsObj").gameObject;
            TextCountObj = this.transform.Find("TextMiningCount").gameObject;
            myMining = MiningAlgorithm.GetComponent<MiningAlgorithm>();
            ZzImage = this.transform.Find("ZzImg").gameObject;
            for (int i = 1; i <= 38; i++)
            {
                string Name = "Mineral" + i;
                ListMinerals.Add(MineralsObj.transform.Find(Name).gameObject);
                MineralsProgass.Add(ListMinerals[ListMinerals.Count - 1].transform.Find("Mineral1Prograss").gameObject);
                MineralsProgass[MineralsProgass.Count - 1].SetActive(true);
                PrograssImg.Add(ListMinerals[ListMinerals.Count - 1].transform.Find("Mineral1Prograss").GetComponent<Image>());
                TextMineralCount.Add(ListMinerals[ListMinerals.Count - 1].transform.Find("TextTime").GetComponent<Text>());
            }

        }

    }
    void Start()
    {

    }

    int iMineralIndex = -1;
    private void OnEnable()
    {
        bStartMinerAnim = false;
    }
    private void OnDisable()
    {
    }
    public void SetDefaultSpeed()
    {
        DefaultSpeed = gv.ListMiningTime[iMinerNumber - 1];
    }
    private void FixedUpdate()
    {
        if (tag == "Miner")
        {
            if (bSplit == false)
            {
                iMinerNumber = SplitName(this.name);
                DefaultSpeed = gv.ListMiningTime[iMinerNumber - 1];
                bSplit = true;
            }
            if (gv.bStartKingGame == false)
            {
                if (iMinerNumber > 0)
                {
                    this.GetComponent<Animator>().SetBool("isMine", false);
                }
            }
            else
            {
                this.GetComponent<Animator>().SetBool("isMine", true);
            }
            if (iMinerNumber > 0 && gv.MiningType[iMinerNumber - 1] == 1 && gv.bStartKingGame == true)
            {
                //if (gv.ListCapacityNow[iMinerNumber - 1] < gv.listMaxMinerCapacity[iMinerNumber - 1])
                {
                    //ZzImage.SetActive(false);
                    MineralsObj.SetActive(true);
                    //if (gv.ListbStartMineralAnim.Count > 0 && iMinerNumber > -1)
                    {
                        //if (gv.ListbStartMineralAnim[iMinerNumber - 1] == false)
                        {
                            if (PrevIndex > -1)
                            {
                                for (int i = 0; i < ListMinerals.Count; i++)
                                {
                                    if (ListMinerals[i].activeSelf == true)
                                        ListMinerals[i].SetActive(false);
                                }

                            }
                        }
                        //else
                        {
                            if (iMineralIndex > -1)
                            {
                                //for (int i = 0; i < ListMinerals.Count; i++)
                                //{
                                //    if (ListMinerals[i].activeSelf == true)
                                //        ListMinerals[i].SetActive(false);
                                //}
                                //ListMinerals[iMineralIndex].SetActive(true);
                                StartMineralAnim(iMineralIndex);
                            }

                        }
                    }

                    if (iMinerNumber > 0 && gv.bStartMine == true)
                    {
                        float speed = 0.5f;
                        //float RemainTime = gv.ListMiningTime[iMinerNumber - 1];
                        if (gv.kingBuffSpeed > 0)
                        {
                            speed = DefaultSpeed;
                            speed = gv.ListMiningTime[iMinerNumber - 1] - gv.kingBuffSpeed;
                            if (gv.ListMiningTime[iMinerNumber - 1] <= 0)
                                speed = 0.5f;

                        }
                        else
                        {
                            speed = DefaultSpeed;
                        }
                        m_RemainTime = speed;
                        if (iTime == 0)
                        {
                            int index = (gv.KingMineralsStage) / 5;
                            iMineralIndex = index;
                            if (bMiningComplete == true)
                            {
                                bMiningComplete = false;

                            }
                            bStartMinerAnim = false;
                        }
                        if (iMineralIndex > -1)
                        {
                            bStartProgass = true;
                            bMiningComplete = true;
                            if (bStartMinerAnim == false)
                            {
                                //if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                StartMineralAnim(iMineralIndex);
                                bStartMinerAnim = true;
                            }
                            iTime += Time.deltaTime;

                            if (m_RemainTime < iTime)
                            {
                                //StartCoroutine("DeleteText");
                                PrograssImg[iMineralIndex].fillAmount = 1;
                                //int Rand = Random.Range(gv.ListMiningMin[iMinerNumber - 1], gv.ListMiningMax[iMinerNumber - 1]);
                                int Rand = gv.ListMiningMax[iMinerNumber - 1];

                                //if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                {

                                    Vector2 vec = new Vector2();
                                    vec = this.transform.localPosition;
                                    vec.x = 0;
                                    vec.y = 25;
                                    TextCountObj.SetActive(false);
                                    TextCountObj.SetActive(true);
                                    TextCountObj.GetComponent<Text>().color = gv.listTextColor[iMineralIndex];
                                    TextCountObj.GetComponent<Outline>().effectColor = gv.listTextOutlineColor[iMineralIndex];
                                    TextCountObj.transform.localPosition = vec;
                                    //채굴완료 !!
                                    if (gv.kingBuffPower > 0)
                                    {
                                        TextCountObj.GetComponent<Text>().text = "+ " + Rand.ToString() + "  + " + (Rand * gv.kingBuffPower).ToString();
                                    }
                                    else
                                    {
                                        TextCountObj.GetComponent<Text>().text = "+ " + Rand.ToString();
                                    }
                                }

                                int depth = 0;
                                float weight = 1;
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

                                if (gv.kingBuffPower != 0)
                                {
                                    gv.KingDps += Rand + (Rand * gv.kingBuffPower);
                                }
                                else
                                {
                                    gv.KingDps += Rand;
                                }



                                iTime = 0;
                                iMineralIndex = -1;
                                bStartProgass = false;
                            }
                            else
                            {
                                if (iMineralIndex > -1)
                                {
                                    if (gv.ListbStartMineralAnim[iMinerNumber - 1] == true)
                                    {
                                        PrograssImg[iMineralIndex].fillAmount = iTime / m_RemainTime;
                                        SetRemainTime(m_RemainTime - (float)iTime);
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
    private void Update()
    {
        if (iMinerNumber > 0 && gv.bStartKingGame == true)
        {
            if (bStartProgass == true)
            {
                iTime += Time.deltaTime;
                if (iMineralIndex > -1)
                {
                    if (gv.bStartKingGame == true)
                    {
                        PrograssImg[iMineralIndex].fillAmount = iTime / m_RemainTime;
                        SetRemainTime(m_RemainTime - (float)iTime);
                    }
                }
            }

            if (gv.bStartKingGame == true)
            {
                gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = (float)gv.ListCapacityNow[iMinerNumber - 1] / (float)gv.listMaxMinerCapacity[iMinerNumber - 1];
                if ((float)gv.ListCapacityNow[iMinerNumber - 1] <= 0)
                {
                    //gv.MinerCapacityProgass.GetComponent<Image>().fillAmount = 0;
                }
                gv.MinerCapacityProgassText.GetComponent<Text>().text = gv.ListCapacityNow[iMinerNumber - 1].ToString() + " / " + gv.listMaxMinerCapacity[iMinerNumber - 1].ToString();
                gv.TextBtnMoney.GetComponent<Text>().text = gv.ChangeMoney(gv.ListMoney[iMinerNumber - 1]);
            }
        }
    }


    void StartMineralAnim(int i)
    {
        Vector2 vec = new Vector2();
        if (PrevIndex > -1)
        {
            ListMinerals[PrevIndex].SetActive(false);
        }
        PrevIndex = i;



        vec = this.transform.localPosition;


        vec.x = 0;

        vec.y = 150;
        int index = (gv.KingMineralsStage) / 5;
        ListMinerals[index].SetActive(true);
        ListMinerals[index].transform.localPosition = vec;

        TextRemainTime = TextMineralCount[index];


    }

    int SplitName(string name)
    {
        string strTemp = this.name;
        string[] a = strTemp.Split('r');
        int Count = int.Parse(a[1]);
        return Count;
    }

    void SetRemainTime(float iRemainTime)
    {
        if (gv.bStartKingGame == true)
        {
            int seconds = (int)(iRemainTime % 60);
            float fraction = iRemainTime * 1000;
            fraction = (fraction % 1000);
            fraction = fraction / 10;
            if (fraction <= 0)
            {
                fraction = 0;
            }
            string niceTime = string.Format("{0:00}:{1:00}", seconds, fraction);
            if (TextRemainTime != null)
                TextRemainTime.text = niceTime;
        }
    }

}
