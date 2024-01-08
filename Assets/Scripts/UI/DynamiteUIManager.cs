using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DynamiteUIManager : MonoBehaviour {

    // Use this for initialization
    public GameObject MainStatusCanvas;
    public GameObject DynamitePanelMain;
    public GameObject DynamitePanel;
    public Image DynamiteImage;
    public Image CheckImage;
    public Button DynaBtn;
    public Text DynamiteMoney;
    GlobalVariable gv;
    int DynamiteBlackCoin = 0;
    MapContorller mapController;

    public Image ProgassImg;
    public Text TextPecent;
    bool bStart = false;
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    private void OnEnable()
    {
        CheckCost();


    }
    void CheckCost()
    {
        //int nowDepth = 0;
        //if (gv.MapType == 1)
        //{
        //    nowDepth = gv.Depth;
        //}
        //if (gv.MapType == 2)
        //{
        //    nowDepth = gv.DesertDepth;
        //}
        //if (gv.MapType == 3)
        //{
        //    nowDepth = gv.IceDepth;
        //}
        //if (gv.MapType == 4)
        //{
        //    nowDepth = gv.ForestDepth;
        //}
        //float a;        

        //a = (nowDepth - 1) * (nowDepth - 1) * 13 + 15;

        //DynamiteBlackCoin = (int)a;
        //DynamiteMoney.text = DynamiteBlackCoin.ToString();
        //DynamiteImage.fillAmount = 0;
        DynamiteMoney.text = "--";
    }
    private void OnDisable()
    {
        DynamitePanelMain.SetActive(true);
        DynamitePanel.SetActive(false);
        DynamiteImage.fillAmount = 0;
        count = 0;
        courCount = 0;
        if(bStart == true)
        {
            int deptIndex = 0;
            if (gv.MapType == 1)
            {
                deptIndex = gv.Depth;
            }
            if (gv.MapType == 2)
            {
                deptIndex = gv.DesertDepth;
            }
            if (gv.MapType == 3)
            {
                deptIndex = gv.IceDepth;
            }
            if (gv.MapType == 4)
            {
                deptIndex = gv.ForestDepth;
            }

            if (gv.MapType == 1)
            {
                gv.ExpNow = gv.DepthExp[deptIndex];
                PlayerPrefs.SetFloat("ExpNow", (float)gv.ExpNow);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 2)
            {
                gv.ExpNowDesert = gv.DepthExp[deptIndex] *3;
                PlayerPrefs.SetFloat("ExpNowDesert", (float)gv.ExpNowDesert);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 3)
            {
                gv.ExpNowIce = gv.DepthExp[deptIndex ] *6;
                PlayerPrefs.SetFloat("ExpNowIce", (float)gv.ExpNowIce);
                PlayerPrefs.Save();
            }
            if (gv.MapType == 4)
            {
                gv.ExpNowForest = gv.DepthExp[deptIndex] *10;
                PlayerPrefs.SetFloat("ExpNowForest", (float)gv.ExpNowForest);
                PlayerPrefs.Save();
            }
        }
        bStart = false;

    }
    void Start() {
        mapController = GameObject.Find("MainCanvas").GetComponent<MapContorller>();
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        DecreseBlackCoin(ProgassImg.fillAmount);
    }
    
    
    double count = 0;
    int courCount = 0;
    void DecreseBlackCoin(float percent)
    {
        int nowDepth = 0;
        if (gv.MapType == 1)
        {
            nowDepth = gv.Depth;
        }
        if (gv.MapType == 2)
        {
            nowDepth = gv.DesertDepth;
        }
        if (gv.MapType == 3)
        {
            nowDepth = gv.IceDepth;
        }
        if (gv.MapType == 4)
        {
            nowDepth = gv.ForestDepth;
        }

        float a;
        a = (nowDepth - 1) * (nowDepth - 1) * 13 + 15;
        float totalPercent = 1 - percent;
        a = a * totalPercent;

        DynamiteBlackCoin = (int)a;
        if (DynamiteBlackCoin == 0)
        {
            DynamiteBlackCoin = 1;
        }
        DynamiteMoney.text = DynamiteBlackCoin.ToString();
        //DynamiteImage.fillAmount = 0;
    }
    IEnumerator Dyna()
    {
        yield return new WaitForSeconds(0.1f);

        DynamiteImage.fillAmount += 0.05f;
        
        int deptIndex = 0;
        if (gv.MapType == 1)
        {
            deptIndex = gv.Depth;
            count = gv.DepthExp[deptIndex] / 20;
        }
        if (gv.MapType == 2)
        {
            deptIndex = gv.DesertDepth;
            count = gv.DepthExp[deptIndex]*3 / 20;
        }
        if (gv.MapType == 3)
        {
            deptIndex = gv.IceDepth;
            count = gv.DepthExp[deptIndex]*6 / 20;
        }
        if (gv.MapType == 4)
        {
            deptIndex = gv.ForestDepth;
            count = gv.DepthExp[deptIndex]*10 / 20;
        }
        courCount++;
        
        count  = count * courCount;
        if (gv.MapType == 1)
        {
            gv.ExpNow = count;
            //Depth 경험치 저장
            ProgassImg.fillAmount = (float)count / (float)gv.DepthExp[deptIndex];
            if (ProgassImg.fillAmount < 1)
            {
                float lv = (float)gv.ExpNow / ((float)gv.DepthExp[deptIndex]);
                TextPecent.text = (lv * 100).ToString("N2") + " %";                

                //TextPecent.text = ((float)gv.ExpNow / (float)gv.DepthExp[deptIndex] * 100).ToString("N2") + " %";
                mapController.SetFill((float)count/ (float)gv.DepthExp[deptIndex ]);                
            }
            else
            {
                TextPecent.text = 100 + " %";                    
                ProgassImg.fillAmount = 1;                
            }     
        }
        if (gv.MapType == 2)
        {
            gv.ExpNowDesert = count;
            //Depth 경험치 저장
            ProgassImg.fillAmount = (float)count / ((float)gv.DepthExp[deptIndex] *3);
            if (ProgassImg.fillAmount < 1)
            {
                float lv = (float)gv.ExpNowDesert / ((float)gv.DepthExp[deptIndex] *3);
                TextPecent.text = (lv * 100).ToString("N2") + " %";

                //TextPecent.text = ((float)gv.ExpNowDesert / (float)gv.DepthExp[deptIndex] *3 * 100).ToString("N2") + " %";
                mapController.SetFill((float)count / ((float)gv.DepthExp[deptIndex] *3));                
            }
            else
            {
                TextPecent.text = 100 + " %";
                ProgassImg.fillAmount = 1;               
            }
        }
        if (gv.MapType == 3)
        {
            gv.ExpNowIce = count;
            //Depth 경험치 저장
            ProgassImg.fillAmount = (float)count / ((float)gv.DepthExp[deptIndex ] * 6);
            if (ProgassImg.fillAmount < 1)
            {
                float lv = (float)gv.ExpNowIce / ((float)gv.DepthExp[deptIndex] * 6);
                TextPecent.text = (lv * 100).ToString("N2") + " %";

                //TextPecent.text = ((float)gv.ExpNowIce / (float)gv.DepthExp[deptIndex] * 6 * 100).ToString("N2") + " %";
                mapController.SetFill((float)count / ((float)gv.DepthExp[deptIndex] * 6));               
            }
            else
            {
                TextPecent.text = 100 + " %";
                ProgassImg.fillAmount = 1;              
            }
        }
        if (gv.MapType == 4)
        {
            gv.ExpNowForest = count;
            //Depth 경험치 저장
            ProgassImg.fillAmount = (float)count / ((float)gv.DepthExp[deptIndex ] * 10);
            if (ProgassImg.fillAmount < 1)
            {
                float lv = (float)gv.ExpNowForest / ((float)gv.DepthExp[deptIndex] * 10);
                TextPecent.text = (lv * 100).ToString("N2") + " %";

                //TextPecent.text = ((float)gv.ExpNowForest / (float)gv.DepthExp[deptIndex ] * 10 * 100).ToString("N2") + " %";
                mapController.SetFill((float)count / ((float)gv.DepthExp[deptIndex] * 10));               
            }
            else
            {
                TextPecent.text = 100 + " %";
                ProgassImg.fillAmount = 1;               
            }
        }
        StartCoroutine("Dyna");      
    }
    public void BuyDynamite()
    {
        SIS.DBManager dbManager = GetComponent<SIS.DBManager>();
        if (SIS.DBManager.GetFunds("blackcoin") >= DynamiteBlackCoin)
        {
            SIS.DBManager.IncreaseFunds("blackcoin", -DynamiteBlackCoin);
            bStart = true; 
            DynamitePanelMain.SetActive(false);
            DynamitePanel.SetActive(true);
            DynamiteImage.fillAmount = 0;
            StartCoroutine("Dyna");
            GameObject.Find("SoundPlayManager").GetComponent<SoundPlayManager>().PlayAudio("DynamiteExpert");
        }
        else
        {
            MainStatusCanvas.GetComponent<PopUpManager>().NeedBlackCoinView(1);
            GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().PressDynamiteCanvas(0);
        }
    }
}
