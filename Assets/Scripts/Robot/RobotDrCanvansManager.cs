using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RobotDrCanvansManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public Text Semiconductor1;
    public Text Semiconductor2;
    public Text Semiconductor3;
    public Text Semiconductor4;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        if(gv.Semiconductor1 <0)
        {
            gv.Semiconductor1 = 0;            
            PlayerPrefs.SetInt("Semiconductor1", gv.Semiconductor1);            
            PlayerPrefs.Save();
        }
        if (gv.Semiconductor2 < 0)
        {
            gv.Semiconductor2 = 0;
            PlayerPrefs.SetInt("Semiconductor2", gv.Semiconductor2);
            PlayerPrefs.Save();
        }
        if (gv.Semiconductor3 < 0)
        {
            gv.Semiconductor3 = 0;
            PlayerPrefs.SetInt("Semiconductor3", gv.Semiconductor3);
            PlayerPrefs.Save();
        }
        if (gv.Semiconductor4 < 0)
        {
            gv.Semiconductor4 = 0;
            PlayerPrefs.SetInt("Semiconductor4", gv.Semiconductor4);
            PlayerPrefs.Save();
        }
        Semiconductor1.text = gv.Semiconductor1.ToString();
        Semiconductor2.text = gv.Semiconductor2.ToString();
        Semiconductor3.text = gv.Semiconductor3.ToString();
        Semiconductor4.text = gv.Semiconductor4.ToString();
    }
    // Update is called once per frame
    void Update () {
		
	}
}
