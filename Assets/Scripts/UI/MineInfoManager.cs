using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MineInfoManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;

    public Text MiningSpeed;

    public Text SalePower;
    public Text MiningAmount;
    public Text DrillPower;
    public Text PotionTime;
    public Text DynaTime;
    public Text BoxPower;
    public Text MinerSale;
    public Text DrillDis;
    public Text RewardTime;
    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }

    void Start () {
		
	}
    private void OnEnable()
    {

        if (gv.SaleBuffPower == 0)
        {
            SalePower.text = "x 1.0";
        }
        else
        {
            SalePower.text = "x " + gv.SaleBuffPower.ToString("N1");
        }

        if (gv.MiningBuffPower == 0)
        {
            MiningAmount.text = "x 1.0";
        }
        else
        {
            MiningAmount.text = "x " + gv.MiningBuffPower.ToString("N1");
        }

        if (gv.DrillBuffPower ==0)
        {
            DrillPower.text = "x 1.0";
        }
        else
        {
            DrillPower.text = "x " + gv.DrillBuffPower.ToString("N1");
        }

        if (gv.PotionRemainTime == 0)
        {
            PotionTime.text = "0 %";
        }
        else
        {
            float count = gv.PotionRemainTime * 100;
            PotionTime.text = "+ " + count + " %";
        }

        if (gv.dynamiteReTime == 0)
        {
            DynaTime.text = "0 %";
        }
        else
        {
            float count = gv.dynamiteReTime * 100;
            DynaTime.text = "- " + count + " %";
        }

        if (gv.BoxBuffPower == 0)
        {
            BoxPower.text = "x 1.0";
        }
        else
        {
            BoxPower.text = "x " + gv.BoxBuffPower.ToString("N1");
        }

        if (gv.HireMoneyDiscount == 0)
        {
            MinerSale.text = "0 %";
        }
        else
        {
            float count = gv.HireMoneyDiscount * 100;
            MinerSale.text = "- " + count + " %";
        }

        if (gv.CraftMoneyDiscount == 0)
        {
            DrillDis.text = "0 %";
        }
        else
        {
            float count = gv.CraftMoneyDiscount * 100;
            DrillDis.text = "- " + count + " %";
        }

        if (gv.ReTimePower == 0)
        {
            RewardTime.text = "x 1.0";
        }
        else
        {
            RewardTime.text = "x " + gv.ReTimePower.ToString("N1");
        }



    }

    // Update is called once per frame
    void Update () {
		
	}
}
