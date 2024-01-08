using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DepthRewardBoxSrc : MonoBehaviour {

    // Use this for initialization
    public GameObject DepthRewardPanel;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndOpenBox()
    {
        DepthRewardPanel.GetComponent<DepthRewardBoxManager>().StartParticle();
    }
}
