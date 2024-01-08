using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompleteIAPBuy : MonoBehaviour {

	// Use this for initialization
    
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        //GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().setIAPItem(1);
    }
    private void OnDisable()
    {
        GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().setIAPItem(0);
    }
}
