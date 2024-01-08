using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DynaManSrc : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
    public void Click()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDynamiteCanvas(1);
    }
}
