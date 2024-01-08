using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TestSrc : MonoBehaviour
{

    private static TestSrc _instance = null;

    public static TestSrc Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("cSingleton == null");
            }            
            return _instance;
        }
    }
    ~TestSrc() { }
    

    void Awake()
    {
        //DontDestroyOnLoad(this);
        _instance = this;
    }
 

    private void Start()    {      


    }

    public string ChangeMoney(double haveGold)
    {
        if (haveGold >= 1000000000000000000)
            return string.Format("{0:#.###} F", (float)haveGold / 1000000000000000000);
        else if (haveGold >= 1000000000000000)
            return string.Format("{0:#.###} E", (float)haveGold / 1000000000000000);
        else if (haveGold >= 1000000000000)
            return string.Format("{0:#.###} D", (float)haveGold / 1000000000000);
        else if (haveGold >= 1000000000)
            return string.Format("{0:#.###} C", (float)haveGold / 1000000000);
        else if (haveGold >= 1000000)
            return string.Format("{0:#.###} B", (float)haveGold / 1000000);
        else if (haveGold >= 1000)
            return string.Format("{0:#.###} A", (float)haveGold / 1000);
        else if (haveGold == 0)
            return haveGold.ToString();
        else
            return string.Format("{0:#.##}", haveGold);
        //return haveGold.ToString();

    }
}
