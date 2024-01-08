using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PopupGetEngine : MonoBehaviour {

    // Use this for initialization
    public GameObject BG;
    List<GameObject> ListEngine = new List<GameObject>();
    List<GameObject> ListDrill = new List<GameObject>();
    List<GameObject> ListCapacity = new List<GameObject>();

    public Text TextName;
    public Text Title1;
    public Text Title2;

    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        InitSetting();
    }
    void InitSetting()
    {

        for(int i=0; i <14; i++)
        {
            string strEngine = "Drill";
            string strBit = "Bit";            
            int index = 0;
            index = i + 1;
            strEngine = strEngine + index;
            strBit = strBit + index;
            ListEngine.Add(BG.transform.Find(strEngine).gameObject);
            ListDrill.Add(BG.transform.Find(strBit).gameObject);
        }
        for(int i=0; i< 17; i++)
        {
            string strCapacity = "Capacity";
            int index = 0;
            index = i + 1;
            strCapacity = strCapacity + index;
            ListCapacity.Add(BG.transform.Find(strCapacity).gameObject);
        }
    }
    void Start () {
		
	}
	


    public void SetEngine()
    {
        InitBit();
        //번역
        //Title1.text = "새로운 엔진 제작 가능!!";
        //Title2.text = "새로운 엔진 제작 가능!!";
        for (int i=0; i< ListEngine.Count; i++)
        {
            if(gv.EngineLv-1 == i)
            {
                ListEngine[i].SetActive(true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextEngine("kor", TextName, gv.EngineLv-1);
            }
            else
            {
                if(ListEngine[i].activeSelf == true)
                {
                    ListEngine[i].SetActive(false);
                }
                ListDrill[i].SetActive(false);
            }
        }
        for(int i=0; i< ListCapacity.Count; i++)
        {
            if(ListCapacity[i].activeSelf == true)
            {
                ListCapacity[i].SetActive(false);
            }
        }
    }
    void InitEngine()
    {
        for (int i = 0; i < ListEngine.Count; i++)
        {            
            if (ListEngine[i].activeSelf == true)
            {
                ListEngine[i].SetActive(false);
            }
        }
    }

    void InitBit()
    {
        for (int i = 0; i < ListDrill.Count; i++)
        {
            if (ListDrill[i].activeSelf == true)
            {
                ListDrill[i].SetActive(false);
            }
        }
    }

    public void SetBit()
    {
        InitEngine();
        //번역
        //Title1.text = "새로운 드릴 제작 가능 !!";
        //Title2.text = "새로운 드릴 제작 가능 !!";
        for (int i = 0; i < ListDrill.Count; i++)
        {
            if (gv.BitLv - 1 == i)
            {
                ListDrill[i].SetActive(true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextBit("kor", TextName, gv.BitLv-1);
            }
            else
            {
                if (ListDrill[i].activeSelf == true)
                {
                    ListDrill[i].SetActive(false);
                }                
            }
        }
        for (int i = 0; i < ListCapacity.Count; i++)
        {
            if (ListCapacity[i].activeSelf == true)
            {
                ListCapacity[i].SetActive(false);
            }
        }
    }

    public void SetCapacity()
    {
        InitEngine();
        //Title1.text = "새로운 보관함 획득 !!";
        //Title2.text = "새로운 보관함 획득 !!";
        for (int i = 0; i < ListCapacity.Count; i++)
        {
            if (gv.iCapacityIndex == i)
            {
                ListCapacity[i].SetActive(true);
                GameObject.Find("MainCanvas").GetComponent<TextManager>().SetTextCapacity("kor", TextName, gv.iCapacityIndex);
            }
            else
            {
                if (ListCapacity[i].activeSelf == true)
                {
                    ListCapacity[i].SetActive(false);
                }
            }
        }

        for (int i = 0; i < ListDrill.Count; i++)
        {           
            if (ListDrill[i].activeSelf == true)
            {
                ListDrill[i].SetActive(false);
            }
            if (ListEngine[i].activeSelf == true)
            {
                ListEngine[i].SetActive(false);
            }
        }
    }
}
