using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoitStoneManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusManager;
    public GameObject JooinObj;
    Vector2 Target;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StartMove()
    {
        if(isStart == false)
        {
            Target.x = 0;
            Target.y = -50;

            StartCoroutine(SetCoins(this.gameObject, Target, 0.01f, 0.06f, true));
        }
        
    }
    bool isStart = false;
    IEnumerator SetCoins(GameObject Temp, Vector2 targetpos, float speed, float coinSpeed, bool status)
    {
        yield return new WaitForSeconds(speed);
        //Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, 0.06f);
        Temp.transform.localPosition = Vector3.Lerp(Temp.transform.localPosition, targetpos, coinSpeed);
        // 벡터간 거리를 재어보고
        float dis = Vector3.Distance(Temp.transform.localPosition, targetpos);        
        // OK! 이동 완료! 멈추자.
        if(dis < 50)
        {
            this.GetComponent<Animator>().SetBool("isUnvisible", true);
        }
        if (dis < 10)
        {           
            if(isStart == false)
            {
                MainStatusManager.GetComponent<CoinParticleManager>().EndHoitStone();
                isStart = true;
            }
        }

        if (dis < 5f)
        {
            status = false;            
        }

        if (status == true)
        {
            StartCoroutine(SetCoins(Temp, targetpos, speed, coinSpeed,true));
        }

    }
}
