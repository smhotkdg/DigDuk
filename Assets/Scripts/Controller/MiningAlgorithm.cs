using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiningAlgorithm : MonoBehaviour
{

    // Use this for initialization
    public List<GameObject> m = new List<GameObject>();
    GlobalVariable gv;
    List<float> ListRandomTable = new List<float>();
    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        
    }   
    void Start()
    {
        SetRandTable();
    }

    public int GetMinersIndex()
    {
        int number = -1;
        //int number = (int)Choose(ListRandomTable);
        if(gv.MapType ==1)
        {
            number = gv.Depth - 1;
        }
        if (gv.MapType == 2)
        {
            number = gv.DesertDepth - 1;
        }
        if (gv.MapType == 3)
        {
            number = gv.IceDepth - 1;
        }
        if (gv.MapType == 4)
        {
            number = gv.ForestDepth - 1;
        }
        if(gv.listTextColor.Count-1 < number)
        {
            number = gv.listTextColor.Count-1;
        }
        return number;
        
    }
  
    public void SetRandTable()
    {
        ListRandomTable.Clear();
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

        for (int i=0; i <= deptIndex; i++)
        {
            if (i == 1) { ListRandomTable.Add(300); }
            if (i == 2) { ListRandomTable.Add(280); }
            if (i == 3) { ListRandomTable.Add(280); }
            if (i == 4) { ListRandomTable.Add(260); }
            if (i == 5) { ListRandomTable.Add(260); }
            if (i == 7) { ListRandomTable.Add(240); }
            if (i == 10) { ListRandomTable.Add(240); }
            if (i == 12) { ListRandomTable.Add(230); }
            if (i == 14) { ListRandomTable.Add(230); }
            if (i == 17) { ListRandomTable.Add(220); }
            if (i == 20) { ListRandomTable.Add(220); }
            if (i == 24) { ListRandomTable.Add(210); }
            if (i == 28) { ListRandomTable.Add(210); }
            if (i == 32) { ListRandomTable.Add(200); }
            if (i == 36) { ListRandomTable.Add(190); }
            if (i == 40) { ListRandomTable.Add(180); }
            if (i == 42) { ListRandomTable.Add(170); }
            if (i == 46) { ListRandomTable.Add(160); }
        }
    }


    float Choose(List<float> probs)
    {

        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Count; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Count - 1;
    }
}
