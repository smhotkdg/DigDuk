using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
//using TMPro;
public class StatusUpdate : MonoBehaviour {

    // Use this for initialization
    public Text HoitStoneText;
    public GameObject Notificationobj;
    public Text NotificationoText1;
    public Text NotificationoText2;

    public GameObject InfoNotification;
    public Text TextInfoNotifi;

    public Text TextCap;
    public Text TextCap1;

    public Text TextCoin;
    public Text TextCoin1;

    public Text BlackCoinText;
    //public TextMeshPro blackCoinTextPro;
    GlobalVariable gv;

    bool bCapacityNotifi = false;

    
    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
        SetMoney();

    }
	

	// Update is called once per frame

    public void SetInfoNotification(string Info)
    {
        if (InfoNotification.activeSelf == false)
        {
            InfoNotification.SetActive(true);
            TextInfoNotifi.text = Info;
            StartCoroutine("NotifiInfoEnd");
        }
    }

    IEnumerator NotifiInfoEnd()
    {
        yield return new WaitForSeconds(2.4f);
        InfoNotification.GetComponent<Animator>().SetBool("isNotifi", true);
        yield return new WaitForSeconds(0.6f);
        InfoNotification.SetActive(false);
        InfoNotification.GetComponent<Animator>().SetBool("isNotifi", false);
    }

    public void SetNotification(string title)
    {
        if(Notificationobj.activeSelf == false)
        {
            Notificationobj.SetActive(true);
            NotificationoText1.text = title;
            NotificationoText2.text = title;
            StartCoroutine("NotifiEnd");
        } 
    }

    IEnumerator NotifiEnd()
    {
        
        yield return new WaitForSeconds(1.4f);
        Notificationobj.GetComponent<Animator>().SetBool("isBack", true);
        yield return new WaitForSeconds(0.6f);
        Notificationobj.SetActive(false);
    }

    public void SetMoney()
    {
 
    }
    public void SetCapacityText()
    {

    }
    IEnumerator bCapacityCheck()
    {
        yield return new WaitForSeconds(5);
        bCapacityNotifi = false;
    }

	void Update () {
      
        if(gv.listMaxCapacity.Count >0)
        {
            if (Mathf.Abs((float)gv.Money) <= 0.0000000000000000001f)
            {
                gv.Money = 0;
            }
            if (gv.Money < 0)
            {
                gv.Money = 0;
            }
            TextCoin.text = gv.ChangeMoney(gv.Money);
            TextCoin1.text = gv.ChangeMoney(gv.Money);
            HoitStoneText.text = gv.HoitStoneCount.ToString();
        }        
    }
}

