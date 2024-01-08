using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectGhostLegMan : MonoBehaviour {

    public Animator MainGame;
    public Animator Man1;
    public Animator Man2;
    public GameObject Man1Obj;
    public GameObject Man2Obj;
    public GameObject Select1;
    public GameObject Select2;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnMouseDown()
    {
        if(this.name == "GhostMan1")
        {            
            Man2Obj.SetActive(false);
            gv.GhostLegSelectNumber = 1;
        }
        if (this.name == "GhostMan2")
        {            
            Man1Obj.SetActive(false);
            gv.GhostLegSelectNumber = 2;
        }
        Select1.SetActive(false);
        Select2.SetActive(false);
        MainGame.SetBool("isStart", true);
        Man1.SetBool("isStart", true);
        Man2.SetBool("isStart", true);
    }
}

