using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepthRewardBoxCanvasManager : MonoBehaviour {

    // Use this for initialization
    public GameObject Box1;
    public GameObject Box2;
    public GameObject Box3;
    public GameObject Box4;

    public GameObject PanelP;
    public Button Btn;
    
    public Image BtnImage;
    List<GameObject> BoxList = new List<GameObject>();
    GlobalVariable gv;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
    private void OnEnable()
    {
        Btn.interactable = false;
        Color color = BtnImage.color;
        color.a = 0.58f;
        BtnImage.color = color;

        for (int i=0; i< 12; i++)
        {
            int range = Random.Range(0, 100);
            if (range < 80)
            {
                //1
                BoxList.Add(Instantiate(Box1 as GameObject));
                BoxList[BoxList.Count - 1].transform.SetParent(PanelP.transform);
                BoxList[BoxList.Count - 1].transform.localScale = Box1.transform.localScale;
                BoxList[BoxList.Count - 1].transform.localPosition = Box1.transform.localPosition;
                BoxList[BoxList.Count - 1].name = "1";
            }
            else if (range > 80 && range < 93)
            {
                //2
                BoxList.Add(Instantiate(Box2 as GameObject));
                BoxList[BoxList.Count - 1].transform.SetParent(PanelP.transform);
                BoxList[BoxList.Count - 1].transform.localScale = Box2.transform.localScale;
                BoxList[BoxList.Count - 1].transform.localPosition = Box2.transform.localPosition;
                BoxList[BoxList.Count - 1].name = "2";
            }
            else if (range > 93 && range < 98)
            {
                //3
                BoxList.Add(Instantiate(Box3 as GameObject));
                BoxList[BoxList.Count - 1].transform.SetParent(PanelP.transform);
                BoxList[BoxList.Count - 1].transform.localScale = Box3.transform.localScale;
                BoxList[BoxList.Count - 1].transform.localPosition = Box3.transform.localPosition;
                BoxList[BoxList.Count - 1].name = "3";
            }
            else
            {
                //4
                BoxList.Add(Instantiate(Box4 as GameObject));
                BoxList[BoxList.Count - 1].transform.SetParent(PanelP.transform);
                BoxList[BoxList.Count - 1].transform.localScale = Box4.transform.localScale;
                BoxList[BoxList.Count - 1].transform.localPosition = Box4.transform.localPosition;
                BoxList[BoxList.Count - 1].name = "4";
            }
            
            StartCoroutine(StartBox());
            
        }
    }
    public void SetBtnEnd()
    {
        Btn.interactable = true;
        Color color = BtnImage.color;
        color.a = 1f;
        BtnImage.color = color;
        gv.rewardBoxTotalCount =0;
    }

    public void immediatelyBox()
    {        
        SetBtnEnd();
        for(int i=0; i< BoxList.Count; i++)
        {
            BoxList[i].SetActive(true);
            if(BoxList[i].name == "1")
            {
                BoxList[i].GetComponent<BoxClickManager>().OnClickBox(1);
            }
            if (BoxList[i].name == "2")
            {
                BoxList[i].GetComponent<BoxClickManager>().OnClickBox(2);
            }
            if (BoxList[i].name == "3")
            {
                BoxList[i].GetComponent<BoxClickManager>().OnClickBox(3);
            }
            if (BoxList[i].name == "4")
            {
                BoxList[i].GetComponent<BoxClickManager>().OnClickBox(4);
            }
        }
    }

    IEnumerator StartBox()
    {
        for (int i = 0; i < BoxList.Count; i++)
        {
            BoxList[i].SetActive(true);
            yield return new WaitForSeconds(0.2f);
        }
    }
    private void OnDisable()
    {
        for(int i=0; i< BoxList.Count; i++)
        {
            Destroy(BoxList[i].gameObject);
        }
        BoxList.Clear();        
    }
    // Update is called once per frame
    void Update () {
		
	}
}
