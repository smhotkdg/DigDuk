using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotSelectUIManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;

    public GameObject SelectObj;

    List<GameObject> ArrowClone = new List<GameObject>();
    List<GameObject> SelectCardClone = new List<GameObject>();    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void UnSetCard()
    {     
        DeleteCard();
    }

    void DeleteCard()
    {

        for (int i = 0; i < ArrowClone.Count; i++)
        {
            Destroy(ArrowClone[i]);
            Destroy(SelectCardClone[i]);            
            //Destroy(PrograssClone[i]);
        }
        //Destroy(InfoClone);
        ArrowClone.Clear();
        SelectCardClone.Clear();        
        //PrograssClone.Clear();
    }
    void SetCardView()
    {
        GameObject Arrow = SelectObj.transform.Find("Craft.0").gameObject;
        GameObject SelectCard = SelectObj.transform.Find("CraftCard.0").gameObject;        
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

        for (int i = 0; i < deptIndex; i++)
        {
            for (int j = 0; j < 2; j++)
            {
                Vector3 ArrowVec = new Vector3();
                Vector3 VectorCard = new Vector3();
                Vector3 DeleteVec = new Vector3();
                Vector3 PrograssVec = new Vector3();
                if (j == 0)
                {
                    ArrowVec.x = -215f;
                    ArrowVec.y = 75f - ((i) * 350);
                    VectorCard.x = -215f;
                    VectorCard.y = -80f - ((i) * 350);
                    DeleteVec.x = -215f;
                    DeleteVec.y = 75f - ((i) * 350);

                    PrograssVec.x = -215;
                    PrograssVec.y = -145 - ((i) * 350);
                }
                else if (j == 1)
                {
                    ArrowVec.x = 10;
                    ArrowVec.y = 75f - ((i) * 350);
                    VectorCard.x = 10;
                    VectorCard.y = -80f - ((i) * 350);
                    DeleteVec.x = 10;
                    DeleteVec.y = 75f - ((i) * 350);

                    PrograssVec.x = 10;
                    PrograssVec.y = -145 - ((i) * 350);
                }


                ArrowClone.Add(Instantiate(Arrow));
                ArrowClone[ArrowClone.Count - 1].name = "Craft." + (ArrowClone.Count - 1);
                ArrowClone[ArrowClone.Count - 1].transform.SetParent(SelectObj.transform);
                ArrowClone[ArrowClone.Count - 1].transform.localScale = Arrow.transform.localScale;
                ArrowClone[ArrowClone.Count - 1].transform.localPosition = ArrowVec;


                SelectCardClone.Add(Instantiate(SelectCard));
                SelectCardClone[SelectCardClone.Count - 1].name = "CraftCard." + (SelectCardClone.Count - 1);
                SelectCardClone[SelectCardClone.Count - 1].transform.SetParent(SelectObj.transform);
                SelectCardClone[SelectCardClone.Count - 1].transform.localScale = SelectCard.transform.localScale;
                SelectCardClone[SelectCardClone.Count - 1].transform.localPosition = VectorCard;   
            }
        }        
        InitCardSetting();
    }

    public void InitCardSetting()
    {

        //InfoPos.x = -600;
        //InfoPos.y = 0;
        //InfoObj.transform.localPosition = InfoPos;        
        for (int i = 0; i < ArrowClone.Count; i++)
        {
            {                
                ArrowClone[i].SetActive(true);

            }
        }

        if (gv.MapType == 1)
        {
            for (int i = 0; i < gv.RobotNormal.Count; i++)
            {
                if (gv.RobotNormal[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotNormal[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.RobotDesert.Count; i++)
            {
                if (gv.RobotDesert[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotDesert[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.RobotIce.Count; i++)
            {
                if (gv.RobotIce[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotIce[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.RobotForest.Count; i++)
            {
                if (gv.RobotForest[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotForest[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                    }
                }
            }
        }
    }

    public void SetDeleteCard()
    {
        SelectObj.SetActive(true);
        SetCardView();

        if (gv.MapType == 1)
        {
            for (int i = 0; i < gv.RobotNormal.Count; i++)
            {
                if (gv.RobotNormal[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotNormal[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 2)
        {
            for (int i = 0; i < gv.RobotDesert.Count; i++)
            {
                if (gv.RobotDesert[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotDesert[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 3)
        {
            for (int i = 0; i < gv.RobotIce.Count; i++)
            {
                if (gv.RobotIce[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotIce[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }
        if (gv.MapType == 4)
        {
            for (int i = 0; i < gv.RobotForest.Count; i++)
            {
                if (gv.RobotForest[i] < 0)
                {
                    int index = Mathf.Abs(gv.RobotForest[i]);
                    if (index - 1 < ArrowClone.Count)
                    {                        
                        ArrowClone[index - 1].SetActive(false);
                        SelectCardClone[index - 1].SetActive(false);
                    }
                }
            }
        }

    }
}
