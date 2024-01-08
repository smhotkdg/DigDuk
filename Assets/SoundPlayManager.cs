using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundPlayManager : MonoBehaviour {

    // Use this for initialization
    public List<AudioSource> AudioList;
    GlobalVariable gv;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    public void StopAudio(string Soundname)
    {
        switch (Soundname)
        {
            case "UpgradeSuccess":
                AudioList[0].Stop();
                break;
            case "UpgradeFail":
                AudioList[1].Stop();
                break;
            case "MinigameWin":
                AudioList[2].Stop();
                break;
            case "MinigameLose":
                AudioList[3].Stop();
                break;
            case "Open":
                AudioList[4].Stop();
                break;
            case "UsePotion":
                AudioList[5].Stop();
                break;
            case "Depth":
                AudioList[6].Stop();
                break;
            case "MapOpen":
                AudioList[7].Stop();
                break;
            case "Collection":
                AudioList[8].Stop();
                break;
            case "GetKey":
                AudioList[9].Stop();
                break;
            case "DynamiteExpert":
                AudioList[10].Stop();
                break;
            case "DepthGiftBox":
                AudioList[11].Stop();
                break;
            case "DepthGiftBoxClick":
                AudioList[12].Stop();
                break;
            case "BGKingMineralNormal":
                if (gv.isOnBGM == 1)
                {
                    AudioList[13].Stop();
                    AudioList[19].Play();
                }
                break;
            case "BGKingMineralDesert":
                if (gv.isOnBGM == 1)
                {
                    AudioList[14].Stop();
                    AudioList[20].Play();
                }
                break;
            case "BGKingMineralIce":
                if (gv.isOnBGM == 1)
                {
                    AudioList[15].Stop();
                    AudioList[21].Play();
                }
                break;
            case "BGKingMineralForest":
                if (gv.isOnBGM == 1)
                {
                    AudioList[16].Stop();
                    AudioList[22].Play();
                }
                break;
            case "BGKingMineralWin":
                AudioList[17].Stop();                
                break;
            case "BGKingMineralLose":
                AudioList[18].Stop();                
                break;
            case "Collect":
                AudioList[23].Stop();
                break;
            case "AddSpecial":
                AudioList[24].Stop();
                break;
            case "AddSpecialStart":
                AudioList[25].Stop();
                break;
            case "AddSpecialLoop":
                AudioList[26].Stop();
                break;
            case "RobotGet":
                AudioList[27].Stop();
                break;
        }
    }

    public void PlayAudio(string Soundname)
    {
        switch(Soundname)
        {
            case "UpgradeSuccess":
                if (gv.isOnEffectBGM == 1)
                    AudioList[0].Play();
                break;
            case "UpgradeFail":
                if (gv.isOnEffectBGM == 1)
                    AudioList[1].Play();
                break;
            case "MinigameWin":
                if (gv.isOnEffectBGM == 1)
                    AudioList[2].Play();
                break;
            case "MinigameLose":
                if (gv.isOnEffectBGM == 1)
                    AudioList[3].Play();
                break;
            case "Open":
                if (gv.isOnEffectBGM == 1)
                    AudioList[4].Play();
                break;
            case "UsePotion":
                if (gv.isOnEffectBGM == 1)
                    AudioList[5].Play();
                break;
            case "Depth":
                if (gv.isOnEffectBGM == 1)
                    AudioList[6].Play();
                break;
            case "MapOpen":
                if (gv.isOnEffectBGM == 1)
                    AudioList[7].Play();
                break;
            case "Collection":
                if (gv.isOnEffectBGM == 1)
                    AudioList[8].Play();
                break;
            case "GetKey":
                if (gv.isOnEffectBGM == 1)
                    AudioList[9].Play();
                break;
            case "DynamiteExpert":
                if (gv.isOnEffectBGM == 1)
                    AudioList[10].Play();
                break;
            case "DepthGiftBox":
                if (gv.isOnEffectBGM == 1)
                    AudioList[11].Play();
                break;
            case "DepthGiftBoxClick":
                if (gv.isOnEffectBGM == 1)
                    AudioList[12].Play();
                break;
            case "BGKingMineralNormal":
                if (gv.isOnBGM == 1)
                {
                    AudioList[13].Play();
                    AudioList[19].Stop();
                }
                break;
            case "BGKingMineralDesert":
                if (gv.isOnBGM == 1)
                {
                    AudioList[14].Play();
                    AudioList[20].Stop();
                }
                break;
            case "BGKingMineralIce":
                if (gv.isOnBGM == 1)
                {
                    AudioList[15].Play();
                    AudioList[21].Stop();
                }
                break;
            case "BGKingMineralForest":
                if (gv.isOnBGM == 1)
                {
                    AudioList[16].Play();
                    AudioList[22].Stop();
                }
                break;
            case "BGKingMineralWin":
                if (gv.isOnEffectBGM == 1)
                {
                    AudioList[17].Play();
                }
                break;
            case "BGKingMineralLose":
                if (gv.isOnEffectBGM == 1)
                    AudioList[18].Play();
                break;
            case "Collect":
                if (gv.isOnEffectBGM == 1)
                    AudioList[23].Play();
                break;
            case "AddSpecial":
                if (gv.isOnEffectBGM == 1)
                    AudioList[24].Play();
                break;
            case "AddSpecialStart":
                if (gv.isOnEffectBGM == 1)
                    AudioList[25].Play();
                break;
            case "AddSpecialLoop":
                if (gv.isOnEffectBGM == 1)
                    AudioList[26].Play();
                break;
            case "RobotGet":
                if (gv.isOnEffectBGM == 1)
                    AudioList[27].Play();
                break;
        }
    }
    public void PlayAudio(int i)
    {
        if(AudioList.Count >i)
        {
            AudioList[i].Play();
        }
    }
}
