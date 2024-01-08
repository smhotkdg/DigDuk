using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombinatnionCanvasManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject TabSelectCombinatnon;
    public GameObject TabNonSelectCombinatnon;

    public GameObject TabSelectCollection;
    public GameObject TabNonSelectCollection;

    public GameObject ScrollCombinatnion;
    public GameObject ScrollCollection;

    public List<GameObject> ListCollection1;
    public List<GameObject> ListCollection2;
    public List<GameObject> ListCollection3;
    public List<GameObject> ListCollection4;
    public List<GameObject> ListCollection5;
    public List<GameObject> ListCollection6;
    public List<GameObject> ListCollection7;
    public List<GameObject> ListCollection8;
    public List<GameObject> ListCollection9;
    public List<GameObject> ListCollection10;
    public List<GameObject> ListCollection11;
    public List<GameObject> ListCollection12;
    public List<GameObject> ListCollection13;
    public List<GameObject> ListCollection14;
    public List<GameObject> ListCollection15;

    public List<GameObject> CheckList;

    public Text TotalText;
    
    List<GameObject> CombiList = new List<GameObject>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {

        GameObject ScrollImage = ScrollCombinatnion.transform.Find("ScrollImage").gameObject;
        for (int i=1; i<=33; i++)
        {
            string strCombi = "Combi" + i;
            CombiList.Add(ScrollImage.transform.Find(strCombi).gameObject);
        }

    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void EnableCombination(int index)
    {
        Color tureColor = new Color();
        tureColor.a = 1; tureColor.r = 1; tureColor.g = 1; tureColor.b = 1;
        if (CombiList.Count >0)
        {
            CombiList[index].transform.Find("Miner1").gameObject.transform.Find("Miner").gameObject.GetComponent<Image>().color = tureColor;
            //CombiList[index].transform.Find("Miner1").gameObject.transform.Find("Question").gameObject.SetActive(false);
            CombiList[index].transform.Find("Miner2").gameObject.transform.Find("Miner").gameObject.GetComponent<Image>().color = tureColor;
            //CombiList[index].transform.Find("Miner2").gameObject.transform.Find("Question").gameObject.SetActive(false);
        }
        else
        {
            GameObject ScrollImage = ScrollCombinatnion.transform.Find("ScrollImage").gameObject;
            for (int i = 1; i <= 33; i++)
            {
                string strCombi = "Combi" + i;
                CombiList.Add(ScrollImage.transform.Find(strCombi).gameObject);
            }
            CombiList[index].transform.Find("Miner1").gameObject.transform.Find("Miner").GetComponent<Image>().color = tureColor;
            //CombiList[index].transform.Find("Miner1").gameObject.transform.Find("Question").gameObject.SetActive(false);
            CombiList[index].transform.Find("Miner2").gameObject.transform.Find("Miner").GetComponent<Image>().color = tureColor;
            //CombiList[index].transform.Find("Miner2").gameObject.transform.Find("Question").gameObject.SetActive(false);
        }
    }

    int totlaCollectionCount = 0;
    int totalCombiCount = 0;
    private void OnEnable()
    {
        totlaCollectionCount = 0;
        totalCombiCount = 0;

        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().SetExclamationmark(false);
        
        for (int i = 0; i < gv.CombinationStatus.Count; i++)
        {
            if (gv.CombinationStatus[i] != 0 || gv.CombinationStatusDesert[i] !=0 || gv.CombinationStatusForest[i] !=0 || gv.CombinationStatusNormal[i] !=0)
            {
                EnableCombination(i);
                totalCombiCount++;
            }
        }
        
        Color _color = new Color();
        _color.a = 1; _color.r = 1; _color.g = 1; _color.b = 1;
        Color _colorDelete = new Color();
        _colorDelete.a = 1; _colorDelete.r = 0; _colorDelete.g = 0; _colorDelete.b = 0;
        for(int i=0; i < ListCollection1.Count; i++)
        {
            ListCollection1[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection2.Count; i++)
        {
            ListCollection2[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection3.Count; i++)
        {
            ListCollection3[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection4.Count; i++)
        {
            ListCollection4[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection5.Count; i++)
        {
            ListCollection5[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection6.Count; i++)
        {
            ListCollection6[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection7.Count; i++)
        {
            ListCollection7[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection8.Count; i++)
        {
            ListCollection8[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection9.Count; i++)
        {
            ListCollection9[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection10.Count; i++)
        {
            ListCollection10[i].GetComponent<Image>().color = _colorDelete;
        }

        for (int i = 0; i < ListCollection11.Count; i++)
        {
            ListCollection11[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection12.Count; i++)
        {
            ListCollection12[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection13.Count; i++)
        {
            ListCollection13[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection14.Count; i++)
        {
            ListCollection14[i].GetComponent<Image>().color = _colorDelete;
        }
        for (int i = 0; i < ListCollection15.Count; i++)
        {
            ListCollection15[i].GetComponent<Image>().color = _colorDelete;
        }
        //1
        int cnt = 0;
        if(gv.ListHireCount[29] != 0 || gv.ListHireDesertCount[29] !=0 || gv.ListHireForestCount[29]!=0 || gv.ListHireIceCount[29] !=0)
        {
            ListCollection1[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[27] != 0 || gv.ListHireDesertCount[27] != 0 || gv.ListHireForestCount[27] != 0 || gv.ListHireIceCount[27] != 0)
        {
            ListCollection1[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[48] != 0 || gv.ListHireDesertCount[48] != 0 || gv.ListHireForestCount[48] != 0 || gv.ListHireIceCount[48] != 0)
        {
            ListCollection1[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[26] != 0 || gv.ListHireDesertCount[26] != 0 || gv.ListHireForestCount[26] != 0 || gv.ListHireIceCount[26] != 0)
        {
            ListCollection1[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[20] != 0 || gv.ListHireDesertCount[20] != 0 || gv.ListHireForestCount[20] != 0 || gv.ListHireIceCount[20] != 0)
        {
            ListCollection1[4].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[21] != 0 || gv.ListHireDesertCount[21] != 0 || gv.ListHireForestCount[21] != 0 || gv.ListHireIceCount[21] != 0)
        {
            ListCollection1[5].GetComponent<Image>().color = _color;
            cnt++;
        }
        if(cnt >= 6)
        {
            CheckList[0].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;
        //2
        if (gv.ListHireCount[46] != 0 || gv.ListHireDesertCount[46] != 0 || gv.ListHireForestCount[46] != 0 || gv.ListHireIceCount[46] != 0)
        {
            ListCollection2[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[44] != 0 || gv.ListHireDesertCount[40] != 0 || gv.ListHireForestCount[40] != 0 || gv.ListHireIceCount[40] != 0)
        {
            ListCollection2[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[45] != 0 || gv.ListHireDesertCount[45] != 0 || gv.ListHireForestCount[45] != 0 || gv.ListHireIceCount[45] != 0)
        {
            ListCollection2[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[74] != 0 || gv.ListHireDesertCount[74] != 0 || gv.ListHireForestCount[74] != 0 || gv.ListHireIceCount[74] != 0)
        {
            ListCollection2[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 4)
        {
            CheckList[1].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;

        //3
        if (gv.ListHireCount[107] != 0 || gv.ListHireDesertCount[109] != 0 || gv.ListHireForestCount[109] != 0 || gv.ListHireIceCount[109] != 0)
        {
            ListCollection3[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[108] != 0 || gv.ListHireDesertCount[108] != 0 || gv.ListHireForestCount[108] != 0 || gv.ListHireIceCount[108] != 0)
        {
            ListCollection3[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[109] != 0 || gv.ListHireDesertCount[107] != 0 || gv.ListHireForestCount[107] != 0 || gv.ListHireIceCount[107] != 0)
        {
            ListCollection3[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 3)
        {
            CheckList[2].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;



        //4
        if (gv.ListHireCount[77] != 0 || gv.ListHireDesertCount[77] != 0 || gv.ListHireForestCount[77] != 0 || gv.ListHireIceCount[77] != 0)
        {
            ListCollection4[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[78] != 0 || gv.ListHireDesertCount[78] != 0 || gv.ListHireForestCount[78] != 0 || gv.ListHireIceCount[78] != 0)
        {
            ListCollection4[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[79] != 0 || gv.ListHireDesertCount[79] != 0 || gv.ListHireForestCount[79] != 0 || gv.ListHireIceCount[79] != 0)
        {
            ListCollection4[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 3)
        {
            CheckList[3].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;

        //5
        if (gv.ListHireCount[100] != 0 || gv.ListHireDesertCount[100] != 0 || gv.ListHireForestCount[100] != 0 || gv.ListHireIceCount[100] != 0)
        {
            ListCollection5[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[102] != 0 || gv.ListHireDesertCount[102] != 0 || gv.ListHireForestCount[102] != 0 || gv.ListHireIceCount[102] != 0)
        {
            ListCollection5[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[103] != 0 || gv.ListHireDesertCount[103] != 0 || gv.ListHireForestCount[103] != 0 || gv.ListHireIceCount[103] != 0)
        {
            ListCollection5[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 3)
        {
            CheckList[4].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;


        //6
        if (gv.ListHireCount[51] != 0 || gv.ListHireDesertCount[51] != 0 || gv.ListHireForestCount[51] != 0 || gv.ListHireIceCount[51] != 0)
        {
            ListCollection6[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[50] != 0 || gv.ListHireDesertCount[50] != 0 || gv.ListHireForestCount[50] != 0 || gv.ListHireIceCount[50] != 0)
        {
            ListCollection6[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 2)
        {
            CheckList[5].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;


        //7
        if (gv.ListHireCount[62] != 0 || gv.ListHireDesertCount[62] != 0 || gv.ListHireForestCount[62] != 0 || gv.ListHireIceCount[62] != 0)
        {
            ListCollection7[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[63] != 0 || gv.ListHireDesertCount[63] != 0 || gv.ListHireForestCount[63] != 0 || gv.ListHireIceCount[63] != 0)
        {
            ListCollection7[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 2)
        {
            CheckList[6].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;


        //8
        if (gv.ListHireCount[32] != 0 || gv.ListHireDesertCount[32] != 0 || gv.ListHireForestCount[32] != 0 || gv.ListHireIceCount[32] != 0)
        {
            ListCollection8[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[29] != 0 || gv.ListHireDesertCount[29] != 0 || gv.ListHireForestCount[29] != 0 || gv.ListHireIceCount[29] != 0)
        {
            ListCollection8[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[30] != 0 || gv.ListHireDesertCount[30] != 0 || gv.ListHireForestCount[30] != 0 || gv.ListHireIceCount[30] != 0)
        {
            ListCollection8[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[28] != 0 || gv.ListHireDesertCount[28] != 0 || gv.ListHireForestCount[28] != 0 || gv.ListHireIceCount[28] != 0)
        {
            ListCollection8[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 4)
        {
            CheckList[7].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;


        //9
        if (gv.ListHireCount[93] != 0 || gv.ListHireDesertCount[93] != 0 || gv.ListHireForestCount[93] != 0 || gv.ListHireIceCount[93] != 0)
        {
            ListCollection9[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[43] != 0 || gv.ListHireDesertCount[43] != 0 || gv.ListHireForestCount[43] != 0 || gv.ListHireIceCount[43] != 0)
        {
            ListCollection9[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 2)
        {
            CheckList[8].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;


        //10
        if (gv.ListHireCount[88] != 0 || gv.ListHireDesertCount[88] != 0 || gv.ListHireForestCount[88] != 0 || gv.ListHireIceCount[88] != 0)
        {
            ListCollection10[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[49] != 0 || gv.ListHireDesertCount[49] != 0 || gv.ListHireForestCount[49] != 0 || gv.ListHireIceCount[49] != 0)
        {
            ListCollection10[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 2)
        {
            CheckList[9].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;



        if (gv.ListHireCount[86] != 0 || gv.ListHireDesertCount[86] != 0 || gv.ListHireForestCount[86] != 0 || gv.ListHireIceCount[86] != 0)
        {
            ListCollection11[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[72] != 0 || gv.ListHireDesertCount[72] != 0 || gv.ListHireForestCount[72] != 0 || gv.ListHireIceCount[72] != 0)
        {
            ListCollection11[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[94] != 0 || gv.ListHireDesertCount[94] != 0 || gv.ListHireForestCount[94] != 0 || gv.ListHireIceCount[94] != 0)
        {
            ListCollection11[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 3)
        {
            CheckList[10].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;







        if (gv.ListHireCount[75] != 0 || gv.ListHireDesertCount[75] != 0 || gv.ListHireForestCount[75] != 0 || gv.ListHireIceCount[75] != 0)
        {
            ListCollection12[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[99] != 0 || gv.ListHireDesertCount[99] != 0 || gv.ListHireForestCount[99] != 0 || gv.ListHireIceCount[99] != 0)
        {
            ListCollection12[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[47] != 0 || gv.ListHireDesertCount[47] != 0 || gv.ListHireForestCount[47] != 0 || gv.ListHireIceCount[47] != 0)
        {
            ListCollection12[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[52] != 0 || gv.ListHireDesertCount[52] != 0 || gv.ListHireForestCount[52] != 0 || gv.ListHireIceCount[52] != 0)
        {
            ListCollection12[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[73] != 0 || gv.ListHireDesertCount[73] != 0 || gv.ListHireForestCount[73] != 0 || gv.ListHireIceCount[73] != 0)
        {
            ListCollection12[4].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[82] != 0 || gv.ListHireDesertCount[82] != 0 || gv.ListHireForestCount[82] != 0 || gv.ListHireIceCount[82] != 0)
        {
            ListCollection12[5].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[92] != 0 || gv.ListHireDesertCount[92] != 0 || gv.ListHireForestCount[92] != 0 || gv.ListHireIceCount[92] != 0)
        {
            ListCollection12[6].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[90] != 0 || gv.ListHireDesertCount[90] != 0 || gv.ListHireForestCount[90] != 0 || gv.ListHireIceCount[90] != 0)
        {
            ListCollection12[7].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[85] != 0 || gv.ListHireDesertCount[85] != 0 || gv.ListHireForestCount[85] != 0 || gv.ListHireIceCount[85] != 0)
        {
            ListCollection12[8].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[59] != 0 || gv.ListHireDesertCount[59] != 0 || gv.ListHireForestCount[59] != 0 || gv.ListHireIceCount[59] != 0)
        {
            ListCollection12[9].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[68] != 0 || gv.ListHireDesertCount[68] != 0 || gv.ListHireForestCount[68] != 0 || gv.ListHireIceCount[68] != 0)
        {
            ListCollection12[10].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[69] != 0 || gv.ListHireDesertCount[69] != 0 || gv.ListHireForestCount[69] != 0 || gv.ListHireIceCount[69] != 0)
        {
            ListCollection12[11].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 12)
        {
            CheckList[11].SetActive(true);
            totlaCollectionCount++;
        }
        
        cnt = 0;



        if (gv.ListHireCount[97] != 0 || gv.ListHireDesertCount[97] != 0 || gv.ListHireForestCount[97] != 0 || gv.ListHireIceCount[97] != 0)
        {
            ListCollection13[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[96] != 0 || gv.ListHireDesertCount[96] != 0 || gv.ListHireForestCount[96] != 0 || gv.ListHireIceCount[96] != 0)
        {
            ListCollection13[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[41] != 0 || gv.ListHireDesertCount[41] != 0 || gv.ListHireForestCount[41] != 0 || gv.ListHireIceCount[41] != 0)
        {
            ListCollection13[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[101] != 0 || gv.ListHireDesertCount[101] != 0 || gv.ListHireForestCount[101] != 0 || gv.ListHireIceCount[101] != 0)
        {
            ListCollection13[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[36] != 0 || gv.ListHireDesertCount[36] != 0 || gv.ListHireForestCount[36] != 0 || gv.ListHireIceCount[36] != 0)
        {
            ListCollection13[4].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[40] != 0 || gv.ListHireDesertCount[40] != 0 || gv.ListHireForestCount[40] != 0 || gv.ListHireIceCount[40] != 0)
        {
            ListCollection13[5].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[24] != 0 || gv.ListHireDesertCount[24] != 0 || gv.ListHireForestCount[24] != 0 || gv.ListHireIceCount[24] != 0)
        {
            ListCollection13[6].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[100] != 0 || gv.ListHireDesertCount[100] != 0 || gv.ListHireForestCount[100] != 0 || gv.ListHireIceCount[100] != 0)
        {
            ListCollection13[7].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 8)
        {
            CheckList[12].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;



        if (gv.ListHireCount[105] != 0 || gv.ListHireDesertCount[105] != 0 || gv.ListHireForestCount[105] != 0 || gv.ListHireIceCount[105] != 0)
        {
            ListCollection14[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[106] != 0 || gv.ListHireDesertCount[106] != 0 || gv.ListHireForestCount[106] != 0 || gv.ListHireIceCount[106] != 0)
        {
            ListCollection14[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 2)
        {
            CheckList[13].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;





        if (gv.ListHireCount[39] != 0 || gv.ListHireDesertCount[39] != 0 || gv.ListHireForestCount[39] != 0 || gv.ListHireIceCount[39] != 0)
        {
            ListCollection15[0].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[35] != 0 || gv.ListHireDesertCount[35] != 0 || gv.ListHireForestCount[35] != 0 || gv.ListHireIceCount[35] != 0)
        {
            ListCollection15[1].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[34] != 0 || gv.ListHireDesertCount[34] != 0 || gv.ListHireForestCount[34] != 0 || gv.ListHireIceCount[34] != 0)
        {
            ListCollection15[2].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[55] != 0 || gv.ListHireDesertCount[55] != 0 || gv.ListHireForestCount[55] != 0 || gv.ListHireIceCount[55] != 0)
        {
            ListCollection15[3].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[53] != 0 || gv.ListHireDesertCount[53] != 0 || gv.ListHireForestCount[53] != 0 || gv.ListHireIceCount[53] != 0)
        {
            ListCollection15[4].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (gv.ListHireCount[38] != 0 || gv.ListHireDesertCount[38] != 0 || gv.ListHireForestCount[38] != 0 || gv.ListHireIceCount[38] != 0)
        {
            ListCollection15[5].GetComponent<Image>().color = _color;
            cnt++;
        }
        if (cnt >= 6)
        {
            CheckList[14].SetActive(true);
            totlaCollectionCount++;
        }
        cnt = 0;

        if(ScrollCombinatnion.activeSelf == true)
        {
            TotalText.text = totalCombiCount + " / 33";
        }
        if(ScrollCollection.activeSelf == true)
        {
            TotalText.text = totlaCollectionCount + " / 15";
        }
    }

    private void OnDisable()
    {
        for(int i=0; i< CheckList.Count; i++)
        {
            CheckList[i].SetActive(false);
        }
    }

    public void SelectCombination()
    {
        TabSelectCombinatnon.SetActive(true);
        TabNonSelectCombinatnon.SetActive(false);

        TabSelectCollection.SetActive(false);
        TabNonSelectCollection.SetActive(true);

        ScrollCombinatnion.SetActive(true);
        ScrollCollection.SetActive(false);
        if (ScrollCombinatnion.activeSelf == true)
        {
            TotalText.text = totalCombiCount + " / 33";
        }
        if (ScrollCollection.activeSelf == true)
        {
            TotalText.text = totlaCollectionCount + " / 15";
        }
    }
    public void SelectCollection()
    {
        TabSelectCombinatnon.SetActive(false);        
        TabNonSelectCombinatnon.SetActive(true);

        TabSelectCollection.SetActive(true);
        TabNonSelectCollection.SetActive(false);

        ScrollCombinatnion.SetActive(false);
        ScrollCollection.SetActive(true);

        if (ScrollCombinatnion.activeSelf == true)
        {
            TotalText.text = totalCombiCount + " / 33";
        }
        if (ScrollCollection.activeSelf == true)
        {
            TotalText.text = totlaCollectionCount + " / 15";
        }
    }
}
