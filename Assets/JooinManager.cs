using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JooinManager : MonoBehaviour {

    // Use this for initialization
    //x 88 ~ 240
    //y -100
    int speed = 2; //스피드     
    GlobalVariable gv;
    public GameObject BtnObj;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    private void FixedUpdate()
    {
        BtnObj.transform.localPosition = this.transform.localPosition;
    }
    Vector2 jooinMove = new Vector2();
	void Start () {
        StartCoroutine(JooinController());
	}
    IEnumerator JooinController()
    {
        yield return new WaitForSeconds(1f);
        if(gv.isOpening ==0)
        {
            StartCoroutine(JooinController());
        }
        else
        {
            int rand = Random.Range(0, 7);
            if (rand == 0)
            {
                this.GetComponent<Animator>().SetBool("isIdle1", true);
                yield return new WaitForSeconds(5f);
                this.GetComponent<Animator>().SetBool("isIdle1", false);
                StartCoroutine(JooinController());
            }
            if (rand == 1)
            {
                this.GetComponent<Animator>().SetBool("isIdle2", true);
                yield return new WaitForSeconds(5f);
                this.GetComponent<Animator>().SetBool("isIdle2", false);
                StartCoroutine(JooinController());
            }
            if (rand == 2)
            {
                transform.rotation = Quaternion.Euler(0, 0, 0);
                StartCoroutine(WalkLeft());
            }
            if (rand == 3)
            {
                transform.rotation = Quaternion.Euler(0, 180, 0);
                StartCoroutine(WalkRight());
            }
            if (rand == 4)
            {
                this.GetComponent<Animator>().SetBool("isIdle3", true);
                yield return new WaitForSeconds(5f);
                this.GetComponent<Animator>().SetBool("isIdle3", false);
                StartCoroutine(JooinController());
            }
            if (rand == 5)
            {
                this.GetComponent<Animator>().SetBool("isIdle4", true);
                yield return new WaitForSeconds(3f);
                this.GetComponent<Animator>().SetBool("isIdle4", false);
                StartCoroutine(JooinController());
            }
            if (rand == 6)
            {
                this.GetComponent<Animator>().SetBool("isIdle5", true);
                yield return new WaitForSeconds(7f);
                this.GetComponent<Animator>().SetBool("isIdle5", false);
                StartCoroutine(JooinController());
            }
        }


    } 
    // Update is called once per frame
    IEnumerator WalkLeft()
    {
        yield return new WaitForSeconds(0.1f);               
        this.GetComponent<Animator>().SetBool("IsWalk", true);
        jooinMove = transform.localPosition;
        jooinMove.x -= speed;
        transform.localPosition = jooinMove;
        int rand = Random.Range(0, 100);
        if(jooinMove.x >88 && rand >5)
        {
            StartCoroutine(WalkLeft());
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsWalk", false);
            StartCoroutine(JooinController());
        }
        

    }
    IEnumerator WalkRight()
    {
        yield return new WaitForSeconds(0.1f);  
        this.GetComponent<Animator>().SetBool("IsWalk", true);
        jooinMove = transform.localPosition;
        jooinMove.x += speed;
        transform.localPosition = jooinMove;
        int rand = Random.Range(0, 100);
        if (jooinMove.x < 240&& rand > 5)
        {
            StartCoroutine(WalkRight());
        }
        else
        {
            this.GetComponent<Animator>().SetBool("IsWalk", false);
            StartCoroutine(JooinController());
        }
    }

    public void ClickJooin()
    {
        GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressInventoryCanvas(1);
    }
}
