using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MineAnimController : MonoBehaviour {

    // Use this for initialization
    public List<GameObject> MinerList;
    public List<GameObject> EngineList;
    public List<GameObject> DrillList;
    
    public GameObject Jooin;
    
	void Start () {
		
	}
	

    public void SetAnim(bool flag)
    {
        for(int i=0; i< MinerList.Count; i++)
        {
            MinerList[i].GetComponent<Animator>().SetBool("isMine", flag);
        }
      
    }

    public void SetSpeed(int index, float _speed)
    {   
        MinerList[index].GetComponent<Animator>().speed = _speed;
        MinerList[index].GetComponent<MinerDrillMouseDown>().StartSkill();     
    }
    public void SetSpeedEnd(int index, float _speed)
    {
        MinerList[index].GetComponent<Animator>().speed = _speed;
    }
    public void SetSkillEffect(int index , bool flag)
    {
        MinerList[index].GetComponent<_2dxFX_Shiny_Reflect>().enabled = flag;
    }

    public bool SetMinerAnim(int index , bool flag)
    {
        if(MinerList[index].GetComponent<Animator>().GetBool("isMine") !=flag)
        {
            MinerList[index].GetComponent<Animator>().SetBool("isMine", flag);
            return !flag;
        }
        else
        {
            return flag;
        }
            
    }
   
    public void SetDrillAnim(bool flag)
    {
        for (int i = 0; i < EngineList.Count; i++)
        {
            EngineList[i].GetComponent<Animator>().SetBool("isMine", flag);
        }
        for (int i = 0; i < DrillList.Count; i++)
        {
            DrillList[i].GetComponent<Animator>().SetBool("isMine", flag);
        }
    }

    public void SetCollider(bool flag)
    {
        //for(int i=0; i < MinerList.Count; i++)
        {            
            //MinerList[i].GetComponent<BoxCollider2D>().enabled = flag;
        }

        //for (int i = 0; i < EngineList.Count; i++)
        {
            
            //EngineList[i].GetComponent<BoxCollider2D>().enabled = flag;
        }
        //Jooin.GetComponent<BoxCollider2D>().enabled = flag;
    }
    public void JooinSetCollider(bool flag)
    {
        //Jooin.GetComponent<BoxCollider2D>().enabled = flag;
    }
}
