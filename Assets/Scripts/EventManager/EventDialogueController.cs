using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class EventDialogueController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> ListMap1Objects;
    public List<GameObject> ListMap2Objects;
    public List<GameObject> ListMap3Objects;
    public List<GameObject> ListMap4Objects;

    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        InitData();
	}
    public void ChangeMap()
    {
        for(int i=0; i< ListMap1Objects.Count;i ++)
        {
            ListMap1Objects[i].SetActive(false);
            ListMap1Objects[i].transform.Find("Exclamationmark").gameObject.SetActive(false);
            ListMap1Objects[i].transform.Find("Effect").gameObject.SetActive(false);
        }
        for (int i = 0; i < ListMap2Objects.Count; i++)
        {
            ListMap2Objects[i].SetActive(false);
            ListMap2Objects[i].transform.Find("Exclamationmark").gameObject.SetActive(false);
            ListMap2Objects[i].transform.Find("Effect").gameObject.SetActive(false);
        }
        for (int i = 0; i < ListMap3Objects.Count; i++)
        {
            ListMap3Objects[i].SetActive(false);
            ListMap3Objects[i].transform.Find("Exclamationmark").gameObject.SetActive(false);
            ListMap3Objects[i].transform.Find("Effect").gameObject.SetActive(false);
        }
        for (int i = 0; i < ListMap4Objects.Count; i++)
        {
            ListMap4Objects[i].SetActive(false);
            ListMap4Objects[i].transform.Find("Exclamationmark").gameObject.SetActive(false);
            ListMap4Objects[i].transform.Find("Effect").gameObject.SetActive(false);
        }
        InitData();
    }
    public void InitData()
    {
        if (gv.MapType == 1)
        {
            if (gv.EventObjectNormal1Status > 0)
                ListMap1Objects[0].SetActive(true);
            if (gv.EventObjectNormal2Status > 0)
                ListMap1Objects[1].SetActive(true);
            if (gv.EventObjectNormal3Status > 0)
                ListMap1Objects[2].SetActive(true);
            if (gv.EventObjectNormal4Status > 0)
                ListMap1Objects[3].SetActive(true);
            if (gv.EventObjectNormal5Status > 0)
                ListMap1Objects[4].SetActive(true);
            if (gv.EventObjectNormal6Status > 0)
                ListMap1Objects[5].SetActive(true);
            if (gv.EventObjectNormal7Status > 0)
                ListMap1Objects[6].SetActive(true);

            if (gv.EventObjectNormal1Status == 1)
            {
                ListMap1Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[0].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap1Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal2Status == 1)
            {
                ListMap1Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[1].transform.Find("Effect").gameObject.SetActive(true);
            }                
            else
                ListMap1Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal3Status == 1)
            {
                ListMap1Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[2].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap1Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal4Status == 1)
            {
                ListMap1Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[3].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap1Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal5Status == 1)
            {
                ListMap1Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[4].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap1Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal6Status == 1)
            {
                ListMap1Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[5].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap1Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectNormal7Status == 1)
            {
                ListMap1Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap1Objects[6].transform.Find("Effect").gameObject.SetActive(true);
            }

            else
                ListMap1Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(false);
        }
        if (gv.MapType == 2)
        {
            if (gv.EventObjectDesert1Status > 0)
                ListMap2Objects[0].SetActive(true);
            if (gv.EventObjectDesert2Status > 0)
                ListMap2Objects[1].SetActive(true);
            if (gv.EventObjectDesert3Status > 0)
                ListMap2Objects[2].SetActive(true);
            if (gv.EventObjectDesert4Status > 0)
                ListMap2Objects[3].SetActive(true);
            if (gv.EventObjectDesert5Status > 0)
                ListMap2Objects[4].SetActive(true);
            if (gv.EventObjectDesert6Status > 0)
                ListMap2Objects[5].SetActive(true);
            if (gv.EventObjectDesert7Status > 0)
                ListMap2Objects[6].SetActive(true);
            if (gv.EventObjectDesert8Status > 0)
                ListMap2Objects[7].SetActive(true);
            if (gv.EventObjectDesert9Status > 0)
                ListMap2Objects[8].SetActive(true);

            if (gv.EventObjectDesert1Status == 1)
            {
                ListMap2Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[0].transform.Find("Effect").gameObject.SetActive(true);
            }                
            else
                ListMap2Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert2Status == 1)
            {
                ListMap2Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[1].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert3Status == 1)
            {
                ListMap2Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[2].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert4Status == 1)
            {
                ListMap2Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[3].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert5Status == 1)
            {
                ListMap2Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[4].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert6Status == 1)
            {
                ListMap2Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[5].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert7Status == 1)
            {
                ListMap2Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[6].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert8Status == 1)
            {
                ListMap2Objects[7].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[7].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[7].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectDesert9Status == 1)
            {
                ListMap2Objects[8].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap2Objects[8].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap2Objects[8].transform.Find("Exclamationmark").gameObject.SetActive(false);
        }
        if (gv.MapType == 3)
        {
            if (gv.EventObjectIce1Status > 0)
                ListMap3Objects[0].SetActive(true);
            if (gv.EventObjectIce2Status > 0)
                ListMap3Objects[1].SetActive(true);
            if (gv.EventObjectIce3Status > 0)
                ListMap3Objects[2].SetActive(true);
            if (gv.EventObjectIce4Status > 0)
                ListMap3Objects[3].SetActive(true);
            if (gv.EventObjectIce5Status > 0)
                ListMap3Objects[4].SetActive(true);
            if (gv.EventObjectIce6Status > 0)
                ListMap3Objects[5].SetActive(true);
            if (gv.EventObjectIce7Status > 0)
                ListMap3Objects[6].SetActive(true);


            if (gv.EventObjectIce1Status == 1)
            {
                ListMap3Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[0].transform.Find("Effect").gameObject.SetActive(true);
            }            
            else
                ListMap3Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce2Status == 1)
            {
                ListMap3Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[1].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce3Status == 1)
            {
                ListMap3Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[2].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce4Status == 1)
            {
                ListMap3Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[3].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce5Status == 1)
            {
                ListMap3Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[4].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce6Status == 1)
            {
                ListMap3Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[5].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectIce7Status == 1)
            {
                ListMap3Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap3Objects[6].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap3Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(false);
        }
        if (gv.MapType == 4)
        {
            if (gv.EventObjectForest1Status > 0)
                ListMap4Objects[0].SetActive(true);
            if (gv.EventObjectForest2Status > 0)
                ListMap4Objects[1].SetActive(true);
            if (gv.EventObjectForest3Status > 0)
                ListMap4Objects[2].SetActive(true);
            if (gv.EventObjectForest4Status > 0)
                ListMap4Objects[3].SetActive(true);
            if (gv.EventObjectForest5Status > 0)
                ListMap4Objects[4].SetActive(true);
            if (gv.EventObjectForest6Status > 0)
                ListMap4Objects[5].SetActive(true);
            if (gv.EventObjectForest7Status > 0)
                ListMap4Objects[6].SetActive(true);



            if (gv.EventObjectForest1Status == 1)
            {
                ListMap4Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[0].transform.Find("Effect").gameObject.SetActive(true);
            }                
            else
                ListMap4Objects[0].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest2Status == 1)
            {
                ListMap4Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[1].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[1].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest3Status == 1)
            {
                ListMap4Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[2].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[2].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest4Status == 1)
            {
                ListMap4Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[3].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[3].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest5Status == 1)
            {
                ListMap4Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[4].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[4].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest6Status == 1)
            {
                ListMap4Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[5].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[5].transform.Find("Exclamationmark").gameObject.SetActive(false);
            if (gv.EventObjectForest7Status == 1)
            {
                ListMap4Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(true);
                ListMap4Objects[6].transform.Find("Effect").gameObject.SetActive(true);
            }
            else
                ListMap4Objects[6].transform.Find("Exclamationmark").gameObject.SetActive(false);
        }

        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().InitCheckEvent();
    }


	
	// Update is called once per frame
	void Update () {
		
	}
}
