using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimCheckSrc : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    bool bStartAnim = false;
    bool bStartDrillAnim = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
    public void SetbStart(bool flag)
    {
        bStartAnim = flag;
        bStartDrillAnim = flag;
    }
    public void SetBDrillStart(bool flag)
    {
        bStartDrillAnim = flag;
    }
	void Update () {
        if(gv.listMaxCapacity.Count >0)
        {
            int deptIndex = 0;
            if (gv.MapType == 1)
            {
                deptIndex = gv.Depth;                
            }
            if (gv.MapType == 2)
            {
                deptIndex = gv.DesertDepth;
            }
            if (gv.MapType == 3)
            {
                deptIndex = gv.IceDepth;
            }
            if (gv.MapType == 4)
            {
                deptIndex = gv.ForestDepth;
            }
      
            if(gv.MapType ==1)
            {
                if (gv.isEnableUnderConstructionCanvas == true)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                }
                else
                {
                    if (gv.isStartCraftEngineNormal == 1 || gv.isStartCraftBitNormal == 1)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                    }
                    else
                    {
                        if (gv.ExpNow >= gv.DepthExp[deptIndex])
                        {
                            //if (bStartDrillAnim)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                                bStartDrillAnim = false;
                            }
                        }
                        else
                        {
                            //if (bStartDrillAnim == false)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                                bStartDrillAnim = true;
                            }
                        }
                    }
                }
               
               
            }

            if (gv.MapType == 2)
            {
                if(gv.isEnableUnderConstructionCanvas == true)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                }
                else
                {
                    if (gv.isStartCraftEngineDesert == 1 || gv.isStartCraftBitDesert == 1)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                    }
                    else
                    {
                        if (gv.ExpNowDesert >= gv.DepthExp[deptIndex] *3)
                        {
                            if (bStartDrillAnim)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                                bStartDrillAnim = false;
                            }
                        }
                        else
                        {
                            if (bStartDrillAnim == false)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                                bStartDrillAnim = true;
                            }
                        }
                    }
                }               
           
            }




            if (gv.MapType == 3)
            {
                if (gv.isEnableUnderConstructionCanvas == true)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                }
                else
                {
                    if (gv.isStartCraftEngineIce == 1 || gv.isStartCraftBitIce == 1)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                    }
                    else
                    {
                        if (gv.ExpNowIce >= gv.DepthExp[deptIndex] * 6)
                        {
                            if (bStartDrillAnim)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                                bStartDrillAnim = false;
                            }
                        }
                        else
                        {
                            if (bStartDrillAnim == false)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                                bStartDrillAnim = true;
                            }
                        }
                    }
                }
                
             
            }


            if (gv.MapType == 4)
            {
                if (gv.isEnableUnderConstructionCanvas == true)
                {
                    GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                }
                else
                {
                    if (gv.isStartCraftEngineForest == 1 || gv.isStartCraftBitForest == 1)
                    {
                        GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                    }
                    else
                    {
                        if (gv.ExpNowForest >= gv.DepthExp[deptIndex]* 10)
                        {
                            if (bStartDrillAnim)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(false);
                                bStartDrillAnim = false;
                            }
                        }
                        else
                        {
                            if (bStartDrillAnim == false)
                            {
                                GameObject.Find("MainCanvas").GetComponent<MineAnimController>().SetDrillAnim(true);
                                bStartDrillAnim = true;
                            }
                        }
                    }
                }
              
               
            }
        }

    }
    
}
