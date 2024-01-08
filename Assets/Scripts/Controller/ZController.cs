using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void FixedUpdate()
    {
        for(int i=0; i< this.transform.childCount; i++)
        {
            Vector3 vec;
            vec = this.transform.GetChild(i).transform.localPosition;
            vec.z = 0;
            this.transform.GetChild(i).transform.localPosition = vec;
        }
        
    }
}
