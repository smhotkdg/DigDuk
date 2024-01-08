using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SoundManager : MonoBehaviour {

    // Use this for initialization
    public Toggle BackBGM;
    public Toggle EffectBGM;
    GlobalVariable gv;

    public List<AudioSource> ListBGM;

    public List<AudioSource> ListFx;

    private AudioSource MainBGM;

    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    public void ChageMap()
    {

        for (int i = 0; i < ListBGM.Count; i++)
        {
            ListBGM[i].Stop();
            //MainBGM.Stop();
        }

        if (gv.MapType ==1)
        {
            MainBGM = ListBGM[0];
        }
        if (gv.MapType == 2)
        {
            MainBGM = ListBGM[1];
        }
        if (gv.MapType == 3)
        {
            MainBGM = ListBGM[2];
        }
        if (gv.MapType == 4)
        {
            MainBGM = ListBGM[3];
        }
        if (gv.isOnBGM == 1)
        {
            BackBGM.isOn = true;
            MainBGM.mute = false;
            MainBGM.Play();
        }
        else
        {
            BackBGM.isOn = false;
            MainBGM.mute = true;
        }
    }
    void Start () {
        ChageMap();
       

        if (gv.isOnEffectBGM == 1)
        {
            EffectBGM.isOn = true;
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = false;
            }
        }
        else
        {
            EffectBGM.isOn = false;
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = true;
            }
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    public void ConfirmSound()
    {
        if(BackBGM.isOn == true)
        {
            //for(int i=0; i< ListBGM.Count; i++)
            //{
            //    ListBGM[i].mute = false;
            //}
            MainBGM.Play();
            MainBGM.mute = false;
            gv.isOnBGM = 1;
            PlayerPrefs.SetInt("isOnBGM", gv.isOnBGM);
            PlayerPrefs.Save();
        }
        else
        {
            //for (int i = 0; i < ListBGM.Count; i++)
            //{
            //    ListBGM[i].mute = true;
            //}
            MainBGM.Stop();
            MainBGM.mute = true;
            gv.isOnBGM = 0;
            PlayerPrefs.SetInt("isOnBGM", gv.isOnBGM);
            PlayerPrefs.Save();
        }


        if (EffectBGM.isOn == true)
        {
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = false;
            }
            gv.isOnEffectBGM = 1;
            PlayerPrefs.SetInt("isOnEffectBGM", gv.isOnEffectBGM);
            PlayerPrefs.Save();
        }
        else
        {
            for (int i = 0; i < ListFx.Count; i++)
            {
                ListFx[i].mute = true;
            }
            gv.isOnEffectBGM = 0;
            PlayerPrefs.SetInt("isOnEffectBGM", gv.isOnEffectBGM);
            PlayerPrefs.Save();
        }
    }
    private void OnEnable()
    {
        if(gv.isOnBGM == 1)
        {
            BackBGM.isOn = true;
        }
        else
        {
            BackBGM.isOn = false;
        }

        if(gv.isOnEffectBGM==1)
        {
            EffectBGM.isOn = true;
        }
        else
        {
            EffectBGM.isOn = false;
        }
    }

}
