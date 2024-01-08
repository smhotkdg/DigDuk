/*  This file is part of the "Simple IAP System" project by Rebound Games.
 *  You are only allowed to use these resources if you've bought them from the Unity Asset Store.
 * 	You shall not license, sublicense, sell, resell, transfer, assign, distribute or
 * 	otherwise make available to any third party the Service or the Content. */

using UnityEngine;

#if UNITY_PURCHASING
using UnityEngine.Purchasing;
#endif

namespace SIS
{
    /// <summary>
    /// Script that listens to purchases and other IAP events:
    /// here we tell our game what to do when these events happen.
    /// <summary>
    public class IAPListener : MonoBehaviour
    {
        //subscribe to the most important IAP events
        GlobalVariable gv;
        private void Awake()
        {
            gv = GlobalVariable.Instance;
        }
        private void OnEnable()
        {
            IAPManager.purchaseSucceededEvent += HandleSuccessfulPurchase;
            IAPManager.purchaseFailedEvent += HandleFailedPurchase;
            ShopManager.itemSelectedEvent += HandleSelectedItem;
            ShopManager.itemDeselectedEvent += HandleDeselectedItem;
        }


        private void OnDisable()
        {
            IAPManager.purchaseSucceededEvent -= HandleSuccessfulPurchase;
            IAPManager.purchaseFailedEvent -= HandleFailedPurchase;
            ShopManager.itemSelectedEvent -= HandleSelectedItem;
            ShopManager.itemDeselectedEvent -= HandleDeselectedItem;
        }


        /// <summary>
        /// Handle the completion of purchases, be it for products or virtual currency.
        /// Most of the IAP logic is handled internally already, such as adding products or currency to the inventory.
        /// However, this is the spot for you to implement your custom game logic for instantiating in-game products etc.
        /// </summary>
        public void HandleSuccessfulPurchase(string id)
        {
            if (IAPManager.isDebug) Debug.Log("IAPListener reports: HandleSuccessfulPurchase: " + id);

            //differ between ids set in the IAP Settings editor
            bool bComplete = true;
            switch (id)
            {
                //section for in app purchases
                case "costpack":
                    gv.selectIAPitem = 1;
                    break;
                case "middlepack":
                    gv.selectIAPitem = 2;
                    break;
                case "highpack":
                    gv.selectIAPitem = 3;
                    break;
                case "ultrapack":
                    gv.selectIAPitem = 4;
                    break;

                case "starterpack":
                    gv.selectIAPitem = 5;
                    break;
                case "beginnerpack":
                    gv.selectIAPitem = 6;
                    break;
                case "middleminerpack":
                    gv.selectIAPitem = 7;
                    break;
                case "highminerpack":
                    gv.selectIAPitem = 8;
                    break;

                case "manager1":
                    gv.selectIAPitem = 9;
                    break;
                case "manager1_black":
                    gv.selectIAPitem = 9;
                    break;
                case "manager2":
                    gv.selectIAPitem = 10;
                    break;
                case "manager3":
                    gv.selectIAPitem = 11;
                    break;

                case "coinpack1":
                    gv.selectIAPitem = 12;
                    break;
                case "coinpack2":
                    gv.selectIAPitem = 13;
                    break;
                case "coinpack3":
                    gv.HoitStoneCount += 1000;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    gv.selectIAPitem = 14;
                    break;
                case "coinpack4":
                    gv.HoitStoneCount += 2500;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    gv.selectIAPitem = 15;
                    break;
                case "coinpack5":
                    gv.HoitStoneCount += 5000;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    gv.selectIAPitem = 16;
                    break;
                case "coinpack6":
                    gv.HoitStoneCount += 10000;
                    PlayerPrefs.SetInt("HoitStoneCount", gv.HoitStoneCount);
                    PlayerPrefs.Save();
                    gv.selectIAPitem = 17;
                    break;

                case "miner1":
                    gv.selectIAPitem = 18;
                    break;
                case "miner2":
                    gv.selectIAPitem = 19;
                    break;
                case "miner3":
                    gv.selectIAPitem = 20;
                    break;
                case "miner4":
                    gv.selectIAPitem = 21;
                    break;

                case "minerpotion1":
                    gv.selectIAPitem = 22;
                    break;
                case "minerpotion2":
                    gv.selectIAPitem = 23;
                    break;
                case "drillpotion1":
                    gv.selectIAPitem = 24;
                    break;
                case "drillpotion2":
                    gv.selectIAPitem = 25;
                    break;
                case "salepotion1":
                    gv.selectIAPitem = 26;
                    break;
                case "salepotion2":
                    gv.selectIAPitem = 27;
                    break;
                case "zzangpotion1":
                    gv.selectIAPitem = 28;
                    break;
                case "zzangpotion2":
                    gv.selectIAPitem = 29;
                    break;
                case "skillpotion1":
                    gv.selectIAPitem = 30;
                    break;
                case "skillpotion2":
                    gv.selectIAPitem = 31;
                    break;
                case "randompotion1":
                    gv.selectIAPitem = 32;
                    break;
                case "randompotion2":
                    gv.selectIAPitem = 33;
                    break;


                case "goldcer":
                    gv.selectIAPitem = 34;
                    break;
                case "timecer":
                    gv.selectIAPitem = 35;
                    break;

                case "gold1":
                    gv.selectIAPitem = 36;
                    break;
                case "gold2":
                    gv.selectIAPitem = 37;
                    break;
                case "Card1":
                    gv.selectIAPitem = 38;
                    break;
                case "Card2":
                    gv.selectIAPitem = 39;
                    break;
                case "Card3":
                    gv.selectIAPitem = 40;
                    break;
                case "Card4":
                    gv.selectIAPitem = 41;
                    break;
                case "Card5":
                    gv.selectIAPitem = 42;
                    break;
                case "Card6":
                    gv.selectIAPitem = 43;
                    break;
                case "Card7":
                    gv.selectIAPitem = 44;
                    break;

                case "GodStone1_bc":
                    gv.selectIAPitem = 45;
                    break;
                case "GodStone2_bc":
                    gv.selectIAPitem = 46;
                    break;
                case "drillmanager":
                    gv.selectIAPitem = 47;
                    break;
                case "managerpack":
                    gv.selectIAPitem = 48;
                    break;
                case "depthblackcoin":
                    gv.selectIAPitem = 100;
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().StartSpendBlackcoin();
                    break;
                case "sadarimoney":
                    //gv.selectIAPitem = 46;
                    GameObject.Find("MiniGameCanvas").GetComponent<MiniGameUIManager>().RestoreMoneybyBlackCoin(0);
                    break;
                case "minigamereset":
                    //gv.selectIAPitem = 47;
                    GameObject.Find("MainCanvas").GetComponent<BlackCoinSpendUIManager>().MiniGameResetByBlackCoin();
                    break;
                case "Card1_dis":
                    gv.CardGetType = 1;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card2_dis":
                    gv.CardGetType = 2;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card3_dis":
                    gv.CardGetType = 3;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card4_dis":
                    gv.CardGetType = 4;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card5_dis":
                    gv.CardGetType = 5;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card6_dis":
                    gv.CardGetType = 6;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;
                case "Card7_dis":
                    gv.CardGetType = 7;
                    bComplete = false;
                    GameObject.Find("CardGetView").GetComponent<GetCardManager>().ReGetCardRandom1();
                    break;

                case "lightpack":
                    gv.selectIAPitem = 13;
                    gv.isCoinPack1 = 1;
                    PlayerPrefs.SetInt("isCoinPack1", gv.isCoinPack1);
                    PlayerPrefs.Save();
                    GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
                    break;
                case "corepack":
                    gv.selectIAPitem = 14;
                    gv.isCoinPack2 = 1;
                    PlayerPrefs.SetInt("isCoinPack2", gv.isCoinPack2);
                    PlayerPrefs.Save();
                    GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().SetView();
                    break;
            }
            if (GameObject.Find("ShopCanvas").activeSelf == true && bComplete == true)
            {
                GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().setIAPItem(gv.selectIAPitem);
                {
                    GameObject.Find("ShopCanvas").GetComponent<ShopCanvas>().PressCompleteBuy(1);
                }
            }
        }


        //just shows a message via our ShopManager component,
        //but checks for an instance of it first
        void ShowMessage(string text)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(text);
        }

        //called when an purchaseFailedEvent happens,
        //we do the same here
        void HandleFailedPurchase(string error)
        {
            if (ShopManager.GetInstance())
                ShopManager.ShowMessage(error);
        }


        //called when a purchased shop item gets selected
        void HandleSelectedItem(string id)
        {
            if (IAPManager.isDebug) Debug.Log("Selected: " + id);
        }


        //called when a selected shop item gets deselected
        void HandleDeselectedItem(string id)
        {
            if (IAPManager.isDebug) Debug.Log("Deselected: " + id);
        }
    }
}