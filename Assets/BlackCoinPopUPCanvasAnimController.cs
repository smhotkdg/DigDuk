using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HardCodeLab.TutorialMaster;
public class BlackCoinPopUPCanvasAnimController : MonoBehaviour {

    // Use this for initialization
    public TutorialMasterManager tmManager;
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void EndAnim()
    {
        if(tmManager!=null)
        {
            if (tmManager.IsPlaying)
            {
                Tutorial t = tmManager.ActiveTutorial;
                if (t.Name == "Dynamite")
                {
                    t.NextStage();
                }
            }
        }
    }

}
