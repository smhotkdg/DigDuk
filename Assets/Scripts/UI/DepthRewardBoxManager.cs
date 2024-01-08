using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DepthRewardBoxManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusObj;
    public GameObject Box;
    public GameObject Particle1;
    public GameObject Particle3;
    public GameObject Particle2;
    
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnEnable()
    {
        Color color = Box.GetComponent<Image>().color;
        color.a = 1;
        Box.GetComponent<Image>().color = color;
        color = this.GetComponent<Image>().color;
        color.a = 0.8f;
        this.GetComponent<Image>().color = color;
    }
    public void ClickOpenBox()
    {
        Box.GetComponent<Animator>().SetBool("isOpen", true);
        GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("DepthGiftBox");
    }
    public void StartParticle()
    {
        Particle1.SetActive(true);
        Particle2.SetActive(true);
        Particle3.SetActive(true);
        StartCoroutine(EndBox());

    }
    IEnumerator EndBox()
    {
        yield return new WaitForSeconds(1.5f);        
        Box.GetComponent<Animator>().SetBool("isOpen", false);
        StartCoroutine(FadeOut());        
    }
    IEnumerator FadeOut()
    {
        Color color;        
        yield return new WaitForSeconds(0.05f);
        color = this.GetComponent<Image>().color;
        color.a = color.a - 0.05f;
        this.GetComponent<Image>().color = color;
        
        color = Box.GetComponent<Image>().color;
        color.a = color.a - 0.05f;
        Box.GetComponent<Image>().color = color;
        
        if (color.a <=0)
        {
            Particle1.SetActive(false);
            Particle2.SetActive(false);
            Particle3.SetActive(false);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDepthRewardPanel(0);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDepthRewardBoxCanavs(1);
        }
        else
        {
            StartCoroutine(FadeOut());
        }
        
    }
}
