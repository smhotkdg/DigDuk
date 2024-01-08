void CheckUpgradeCapacity()
{
    for (int i = 0; i < UpgradeCapacityCount; i++)
    {
        SetUpgradeCapacity(false);
    }

    SetMoneyText();
    StartCoroutine(ChangeCapacityValue(OwnMinerals / MaxCapacity));
    float numCapacity = FillICapacitymage.value * 100;
    int resultCapacity = (int)numCapacity;
    MacpacityPerText.text = resultCapacity.ToString() + "%";
    SetCapacityText(OwnMinerals);
}   

    void SetZeroCapacity()
    {
        FillICapacitymage.value = 0;
        float numCapacity = FillICapacitymage.value * 100;
        int resultCapacity = (int)numCapacity;
        MacpacityPerText.text = resultCapacity.ToString() + "%";

        CapacityCountText.text = "0/" + MaxCapacity;
    }
    public void SetUpgradeCapacity(bool flag = true)
    {
        if (flag == true)
        {
            if (GameManager.Instance.TotalMoney >= UpgradeCapacityCost)
            {
                GameManager.Instance.TotalMoney -= UpgradeCapacityCost;
                StatusManager.Instance.SetMoneyText();
                MaxCapacity += upgradeCapacityValue;
                SetUpgradeText();
                SetCapacityText();
                UpgradeCapacityCount++;


                FillICapacitymage.value = OwnMinerals / MaxCapacity;
                float numCapacity = FillICapacitymage.value * 100;
                numCapacity = Mathf.Round(numCapacity);
                int resultCapacity = (int)numCapacity;
                MacpacityPerText.text = resultCapacity.ToString() + "%";
            }
        }
        else
        {
            MaxCapacity += upgradeCapacityValue;
            SetUpgradeText();
            SetCapacityText();
        }
    }


        void SetCapacityText(float value)
    {
        CapacityCountText.text = value.ToString("N0") + "/" + MaxCapacity;
    }
    void SetCapacityText()
    {
        CapacityCountText.text = OwnMinerals.ToString() + "/" + MaxCapacity;
    }


        IEnumerator SetMoneyValue(int SetMoneyValue)
    {
        float temp = (float)SetMoneyValue / 20;
        float ownValue = OwnMinerals;
        for (int i = 0; i < 20; i++)
        {
            ownValue += temp;
            //SetCapacityText(ownValue);
            yield return new WaitForSeconds(0.001f);
        }
    }



        public void SellMinerals(bool bFlag = true)
    {
        //GameManager.Instance.TotalMoney += OwnMoney;
        if (bFlag == true)
        {
            GameManager.Instance.SetMoney(OwnMoney);
            StatusManager.Instance.SetMoneyText(OwnMinerals);

            GameManager.Instance.MineralCount[MineralType] -= (int)OwnMinerals;
            OwnMinerals = 0;
            OwnMoney = 0;
            SetMoneyText();
        }

        FillICapacitymage.value = 0;
        float numCapacity = FillICapacitymage.value * 100;
        int resultCapacity = (int)numCapacity;
        MacpacityPerText.text = resultCapacity.ToString() + "%";
        SetCapacityText(0);
        if (FingerObj != null)
            FingerObj.SetActive(false);
    }



        IEnumerator ChangeCapacityValue(float value)
    {
        value = Mathf.Abs(value - FillICapacitymage.value);
        float valueTemp = value / 50;
        float resultMoney = 0;
        for (int i = 0; i < 50; i++)
        {
            FillICapacitymage.value += valueTemp;
            float numCapacity = FillICapacitymage.value * 100;
            numCapacity = Mathf.Round(numCapacity);
            int resultCapacity = (int)numCapacity;
            MacpacityPerText.text = resultCapacity.ToString() + "%";
            yield return new WaitForSeconds(0.001f);
        }
    }