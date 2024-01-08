using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillShopAnim : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	

    public void CloseCanvas()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDrilShop(0);
    }
}
