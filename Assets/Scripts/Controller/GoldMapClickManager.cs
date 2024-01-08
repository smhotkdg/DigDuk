using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GoldMapClickManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Coins;
    List<GameObject> ListCoins = new List<GameObject>();
    public GameObject Parent;

    public Text TextMoney;
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    
    public void PressStartGold()
    {
        if(gv.bStartGold == true)
        {
            if (gv.ClickCount < 110)
            {
                if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 4)
                {
                    gv.ClickCount++;
                    PlayerPrefs.SetInt("ClickCount", gv.ClickCount);
                    PlayerPrefs.Save();
                    GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(4, gv.ClickCount);
                }
            }
            Vector3 spawnPostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            spawnPostion.z = 0;

            GameObject temp = Instantiate(Coins, spawnPostion, Quaternion.Euler(new Vector3(0, 0, 0)));
            temp.transform.SetParent(Parent.transform);
            temp.transform.localScale = Coins.transform.localScale;
            //temp.transform.localPosition = TouchPos;

            double cost = 0;

            float weight = 1;
            int depth =0;
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
            TextMoney.text = "+ " + gv.ChangeMoney(cost);
            gv.Money += cost;

            ListCoins.Add(temp);
            ListCoins[ListCoins.Count - 1].SetActive(true);
            StartCoroutine(DeleteCoins());
            StartCoroutine(bStartCoins());
            gv.bStartGold = false;
    
        }

        if (gv.bMinerStatus == true)
        {
            if (gv.bPlacementTutorial == false)
            {
                Vector2 vec = new Vector2();
                vec = gv.MinerStatusViewObj.transform.localPosition;
                vec.x = -1000;
                gv.MinerStatusViewObj.transform.localPosition = vec;

                gv.iMinerSelectStatus = -1;
                gv.bMinerStatus = false;

                gv.MinerStatusViewObj.SetActive(false);
            }
            GameObject.Find("MainCanvas").GetComponent<HireSettingController>().UnsetInfoBtn();
        }
        
    }
    IEnumerator bStartCoins()
    {
        yield return new WaitForSeconds(0.2f);
        gv.bStartGold = true;
    }
    IEnumerator DeleteCoins()
    {
        yield return new WaitForSeconds(2.3f);
        if (ListCoins.Count > 0)
        {
            Destroy(ListCoins[0]);
            ListCoins.RemoveAt(0);
        }
    }
}
