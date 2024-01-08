using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BGMSampleSrc : MonoBehaviour {

    // Use this for initialization
    public List<AudioSource> ListBGM = new List<AudioSource>();
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SelectBGM(int number)
    {
        if(ListBGM.Count >0)
        {
            for(int i=0;i<ListBGM.Count; i++)
            {
                if(i != number)
                {
                    ListBGM[i].Stop();
                }
                else
                {
                    ListBGM[i].Play();
                }
            }
            
        }
    }
}
