using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class NewMineralUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public List<GameObject> MineralsList;
    public Text MineralName;
    public Text MineralCost;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        int depth = 0;
        float weight = 1;
        if(gv.MapType ==1)
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

        MineralsList[depth - 1].SetActive(true);
        Color color,outlineColor;
        color = gv.listTextColor[depth - 1];
        outlineColor = gv.listTextOutlineColor[depth - 1];
        MineralName.GetComponent<Text>().color = color;
        MineralName.GetComponent<Outline>().effectColor = outlineColor;
        GameObject.Find("MainCanvas").GetComponent<TextManager>().SetMineralText("kor", MineralName, depth - 1);
        MineralCost.text = gv.ChangeMoney(gv.ListCostMinerals[depth - 1] *weight);
    }
    private void OnDisable()
    {
        for(int i=0; i< MineralsList.Count; i++)
        {
            MineralsList[i].SetActive(false);
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
