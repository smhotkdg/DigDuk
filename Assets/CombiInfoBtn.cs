using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CombiInfoBtn : MonoBehaviour {

    // Use this for initialization
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
    public void Click()
    {
        gv.CombiPopupName = this.transform.parent.transform.parent.name;
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressCombiInfo(this.transform.parent.transform.parent.name, 1);
    }
}
