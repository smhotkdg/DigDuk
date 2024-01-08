using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCardAnim : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void EndCard(int type)
    {
        if (gv.CardGetType == 1 || gv.CardGetType == 4 || gv.CardGetType == 6)
        {
            GameObject.Find("CardGetView").GetComponent<GetCardManager>().Random1Get();
        }

        if (gv.CardGetType == 2 || gv.CardGetType == 5 || gv.CardGetType == 7)
        {
            GameObject.Find("CardGetView").GetComponent<GetCardManager>().Random5Get();
        }
        if(gv.CardGetType ==3)
        {
            GameObject.Find("CardGetView").GetComponent<GetCardManager>().Random10Get();
        }
    }
}
