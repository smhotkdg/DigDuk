using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntoruTouch : MonoBehaviour {

    
    private void OnMouseDown()
    {
        GameObject.Find("LevelLoder").GetComponent<LevelLoader>().LoadLevel("Mine.v1");
    }
       
}
