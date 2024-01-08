using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StoryManager : MonoBehaviour {

    // Use this for initialization
    public GameObject txtEngineDesertCar;
    public GameObject txtEngineDesertMac;
    

	void Start () {
		
	}
	


    public void SetTextEngine()
    {   
        //txtEngineDesertMac.GetComponent<UITextTypeWriter>().SetStory("씨부럴 새끼들아 /\n 썩 꺼져라!!!");
        txtEngineDesertCar.GetComponent<UITextTypeWriter>().SetStory("메롱 메롱!!!");        
    } 
}
