using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupGetCharacter : MonoBehaviour {

    // Use this for initialization
    public GameObject Board;
    public GameObject Anim;
    public GameObject MinerBG;
    public GameObject MinerBG2;
    public Text TextMinerName;
    public Text TextMinerName2;
    List<GameObject> ListMiner = new List<GameObject>();
    List<GameObject> ListMiner2 = new List<GameObject>();
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        InitData();
    }
    void Start () {
        
	}

    void InitData()
    {
        for(int i=0; i< 110; i++)
        {
            int index = i + 1;
            string strMiner = "Miner" +index;
            ListMiner.Add(MinerBG.transform.Find(strMiner).gameObject);
            ListMiner2.Add(MinerBG2.transform.Find(strMiner).gameObject);
        }
        
    }
	
    public void SetBoard()
    {
        Anim.SetActive(false);
        Board.SetActive(true);
    }
    public void SetAnim()
    {
        Anim.SetActive(true);
        Board.SetActive(false);
    }

    public void SetMinerImg(int iHireNumberNow)
    {
        if (ListMiner.Count > 0)
        {
            for (int i = 0; i < 110; i++)
            {
                if (iHireNumberNow > -1)
                {
                    if (i == iHireNumberNow)
                    {
                        ListMiner[i].SetActive(true);
                        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextMiner("kor", TextMinerName, iHireNumberNow);
                        ListMiner2[i].SetActive(true);
                        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextMiner("kor", TextMinerName2, iHireNumberNow);
                    }
                    else
                    {
                        if (ListMiner[i].activeSelf == true)
                        {
                            ListMiner[i].SetActive(false);
                        }
                        if (ListMiner2[i].activeSelf == true)
                        {
                            ListMiner2[i].SetActive(false);
                        }
                    }
                }
            }
        }
    }
}
