using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectDeleteClick : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        
    }
	


    int SplitName(string name)
    {
        string strTemp = this.name;
        string[] a = strTemp.Split('.');
        int Count = int.Parse(a[1]);

        Count += -(Count * 2) - 1;

        return Count;
    }
    int SplitMinerName(string name)
    {
        if (name == "")
            return 0;
        string strTemp = name;
        string[] a = strTemp.Split('r');
        int Count = int.Parse(a[1]);

        return Count;
    }
    
    public void OnClick()
    {

        int index = SplitName(this.name);
        
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().ViewCardReset();
        GameObject.Find("MainCanvas").GetComponent<HireSettingController>().DeleteHirePos(index);
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitCardSetting();
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().InitSettingCard();
        
    }
}
