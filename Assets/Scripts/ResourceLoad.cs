using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ResourceLoad : MonoBehaviour {

    // Use this for initialization
        
	void Start () {
        ResourceLoadByPath();

    }
	


    void ResourceLoadByPath()
    {
        Sprite FULLHP = Resources.Load<Sprite>("Back");
        this.GetComponent<Image>().sprite = FULLHP;
    }
}
