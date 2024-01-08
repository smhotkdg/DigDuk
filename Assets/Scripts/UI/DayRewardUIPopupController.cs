using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DayRewardUIPopupController : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject BG;

    List<GameObject> ListDays = new List<GameObject>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        for (int i = 0; i < 20; i++)
        {
            int count = i + 1;
            string strDay = "Day" + count;
            ListDays.Add(BG.transform.Find(strDay).gameObject);
        }
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        ListDays[gv.DayRewardNext].SetActive(true);     
      
    }
    private void OnDisable()
    {
        for(int i=0; i< ListDays.Count; i++)
        {
            ListDays[i].SetActive(false);
        }      
    }
    // Update is called once per frame
    void Update () {
		
	}
}
