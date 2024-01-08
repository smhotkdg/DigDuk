using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSelectMove : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}

    private void OnMouseDown()
    {
        gv.bClickCard = true;
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().UnSetCard();
        GameObject.Find("MainCanvas").GetComponent<CharacterListControll>().SetCard(this.name);    
    }
    
}
