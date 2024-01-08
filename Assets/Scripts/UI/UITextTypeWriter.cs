using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UITextTypeWriter : MonoBehaviour {

    // Use this for initialization
    Text txt;
    string story;
    public float Speed = 0.075f;
    public int flag; 
    void Awake()
    {
        if(flag ==0)
        {
            txt = GetComponent<Text>();
            story = "Hoit";
            StartCoroutine("PlayText");
        }
        else if(flag ==1)
        {
            txt = GetComponent<Text>();
            story = txt.text;
            txt.text = "";
            StartCoroutine("PlayText");
        }
    }
    void Start()
    {
  
    }

    public void SetStory(string _story)
    {
        //현재 상태가 비활성화라 코루틴을 실행 할 수 없음.
        //story = _story;
        //txt = GetComponent<Text>();        
        //txt.text = "";
        //StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(Speed);
        } 
    }
}
