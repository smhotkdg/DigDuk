using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MapLoadingContorller : MonoBehaviour
{

    // Use this for initialization

   
    void Start()
    {
        
        
    }



    public void StartLoading()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetLoadingView();
    }
    public void BackGroundEnd()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SetEndView();        
    }
    public void EndLoading()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressLoadingCanvas(0);        
    }
   
}
