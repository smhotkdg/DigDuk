using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class logoManager : MonoBehaviour {

    // Use this for initialization
    public GameObject LogoCanvas;
    public Animator CanvasAnim;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndLogo()
    {
        CanvasAnim.SetBool("isLogo", true);        
    }
    public void EndCanvas()
    {
        LogoCanvas.SetActive(false);
    }
}
