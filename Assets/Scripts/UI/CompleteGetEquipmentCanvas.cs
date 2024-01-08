using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CompleteGetEquipmentCanvas : MonoBehaviour {

    // Use this for initialization
    public GameObject Particle;
    public List<GameObject> EngineList;
    public List<GameObject> BitList;
    GlobalVariable gv;

    public Text Title;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void SetType(int type)
    {
        if(type ==1)
        {
            EngineList[gv.EngineLv-1].SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", Title, gv.EngineLv - 1);
        }
        if(type ==2)
        {
            BitList[gv.BitLv - 1].SetActive(true);
            GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", Title, gv.BitLv - 1);
        }
    }
    private void OnEnable()
    {
        Particle.SetActive(true);
       

    }
    private void OnDisable()
    {

        for (int i = 0; i < EngineList.Count; i++)
        {
            EngineList[i].SetActive(false);            
        }
        for (int i = 0; i < BitList.Count; i++)
        {
            BitList[i].SetActive(false);            
        }
    }
}
