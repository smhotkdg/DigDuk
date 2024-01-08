using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffController : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        SetInitData();
	}
    void SetInitData()
    {

    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
