using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GetCardManager : MonoBehaviour {

    // Use this for initialization
    GlobalVariable gv;
    public GameObject BtnIm1;
    public GameObject BtnIm5;
    public GameObject BtnIm10;
    public GameObject Random1;
    public GameObject Random3;
    public GameObject Random5;
    public GameObject Random10;
    public GameObject MinerList;
    public GameObject BtnDis1_1;
    public GameObject BtnDis1_4;
    public GameObject BtnDis1_6;
    public GameObject BtnDis5_2;
    public GameObject BtnDis5_5;
    public GameObject BtnDis5_7;

    public GameObject BtnDis10;
    List<GameObject> ListMiner = new List<GameObject>();

    public List<GameObject> GradeParticle;
    List<float> ListRandomTable = new List<float>();
    private void Awake()
    {
        gv = GlobalVariable.Instance;
    }
    void Start() {

    }
    private void OnDisable()
    {
        gv.CardGetType = 0;
    }
    // Update is called once per frame
    void Update() {

    }
    
    public void UnsetCard()
    {
        imCount = 0;
        Random1.SetActive(false);
        Random5.SetActive(false);
        Random10.SetActive(false);
        Random1.GetComponent<Animator>().SetBool("isCard", false);
        Random5.GetComponent<Animator>().SetBool("isCard", false);
        Random10.GetComponent<Animator>().SetBool("isCard", false);

        for (int i = 0; i < ListMiner.Count; i++)
        {
            ListMiner[i].SetActive(false);
        }
        if (gv.CardGetType == 1 || gv.CardGetType == 4 || gv.CardGetType == 6)
        {
            Destroy(MinerRandom1);

            GradeParticle[0].SetActive(false);
            GradeParticle[1].SetActive(false);
            GradeParticle[2].SetActive(false);
            GradeParticle[3].SetActive(false);
        }
        if (gv.CardGetType == 2 || gv.CardGetType == 5 || gv.CardGetType == 7)
        {
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(false);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(false);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(false);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(false);
                Destroy(Rand5Miner[i]);
            }
            Rand5Miner.Clear();
        }
        if (gv.CardGetType == 3)
        {
            for (int i = 0; i < 10; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(false);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(false);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(false);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(false);
                Destroy(Rand10Miner[i]);
            }
            Rand10Miner.Clear();
        }
        

        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckHireQuest());
        GameObject.Find("MainCanvas").GetComponent<QuestManager>().SetExclamationmark(GameObject.Find("MainCanvas").GetComponent<QuestManager>().CheckBuyUniqueMinerQuest());
        GameObject.Find("MainCanvas").GetComponent<CombinationManager>().CheckCollection();

        BtnDis1_1.SetActive(false);
        BtnDis1_1.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis1_4.SetActive(false);
        BtnDis1_4.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis1_6.SetActive(false);
        BtnDis1_6.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis5_2.SetActive(false);
        BtnDis5_2.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis5_5.SetActive(false);
        BtnDis5_5.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis5_7.SetActive(false);
        BtnDis5_7.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnDis10.SetActive(false);
        BtnDis10.transform.Find("Button").gameObject.GetComponent<Button>().interactable = false;

        BtnIm1.GetComponent<Button>().interactable = true;
        BtnIm5.GetComponent<Button>().interactable = true;
        BtnIm10.GetComponent<Button>().interactable = true;
        click5Count = 0;
        click10Count = 0;
    }
    int imCount = 0;
    IEnumerator Immediately10()
    {
        yield return new WaitForSeconds(0.25f);
        if(imCount <10)
        {
            ClickRandom10(imCount);
            StartCoroutine(Immediately10()); 
        }
        else
        {
            BtnDis10.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
        }
        imCount++;
    }
    bool bStartImmedi = false;
    IEnumerator Immediately5()
    {
        yield return new WaitForSeconds(0.25f);
        if(imCount < 5)
        {
            ClickRandom5(imCount);
            StartCoroutine(Immediately5());
        }
        else
        {
            if(gv.CardGetType ==2)
            {
                BtnDis5_2.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
            if (gv.CardGetType == 5)
            {
                BtnDis5_5.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
            if (gv.CardGetType == 7)
            {
                BtnDis5_7.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
        }
        imCount++;
    }
    public void ClickImmediately10()
    {      
        StartCoroutine(Immediately10());
    }
    public void ClickImmediately5()
    {
        StartCoroutine(Immediately5());
    }
    void ListTableSetting()
    {
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(500);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(400);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(20);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(2);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.5f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
        ListRandomTable.Add(0.001f);
    }
    public void SetCard(int type)
    {
        //gv.CardGetType = Random.Range(1, 7);
        gv.CardGetType = type;
        if (ListMiner.Count <= 0)
        {
            for (int i = 1; i <= 110; i++)
            {
                string name = "Miner" + i;
                ListMiner.Add(MinerList.transform.Find(name).gameObject);
            }
        }
        if (ListRandomTable.Count <= 0)
        {
            ListTableSetting();
        }

        //올랜덤 1장
        if (gv.CardGetType == 1)
        {
            InitRandom1Card();
            Random1.SetActive(true);
            Random1.transform.Find("Card").gameObject.SetActive(true);
            Random1.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom1Anim());
            BtnDis1_1.SetActive(true);
        }
        //올랜덤 5장
        if (gv.CardGetType == 2)
        {
            InitRandom5Card();
            Random5.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random5.transform.Find(cardname).gameObject.SetActive(true);
            }
            Random5.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom5Anim());
            BtnDis5_2.SetActive(true);
        }
        //올랜덤 10장
        if (gv.CardGetType == 3)
        {
            InitRandom10Card();
            Random10.SetActive(true);
            for (int i = 0; i < 10; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random10.transform.Find(cardname).gameObject.SetActive(true);

            }
            Random10.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom10Anim());
            BtnDis10.SetActive(true);
        }
        //A ~ SS  1장
        if (gv.CardGetType == 4)
        {
            InitRandom1SCard();
            Random1.SetActive(true);
            Random1.transform.Find("Card").gameObject.SetActive(true);
            Random1.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom1Anim());
            BtnDis1_4.SetActive(true);
        }
        //A ~ SS  5장
        if (gv.CardGetType == 5)
        {
            InitRandom5SCard();
            Random5.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random5.transform.Find(cardname).gameObject.SetActive(true);
            }
            Random5.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom5Anim());
            BtnDis5_5.SetActive(true);
        }
        //유니크  1장
        if (gv.CardGetType == 6)
        {
            InitRandom1UCard();
            Random1.SetActive(true);
            Random1.transform.Find("Card").gameObject.SetActive(true);
            Random1.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom1Anim());
            BtnDis1_6.SetActive(true);
        }
        //유니크  5장
        if (gv.CardGetType == 7)
        {
            InitRandom5UCard();
            Random5.SetActive(true);
            for (int i = 0; i < 5; i++)
            {
                int index = i + 1;
                string cardname = "Card" + index;
                Random5.transform.Find(cardname).gameObject.SetActive(true);
            }
            Random5.GetComponent<Animator>().SetBool("isCard", true);
            StartCoroutine(EndRandom5Anim());
            BtnDis5_7.SetActive(true);
        }
        
    }
    IEnumerator EndRandom5Anim()
    {
        yield return new WaitForSeconds(0.1f);
        Random5.GetComponent<Animator>().SetBool("isCard", false);
    }
    IEnumerator EndRandom10Anim()
    {
        yield return new WaitForSeconds(0.1f);
        Random10.GetComponent<Animator>().SetBool("isCard", false);
    }
    IEnumerator EndRandom1Anim()
    {
        yield return new WaitForSeconds(0.2f);
        Random1.GetComponent<Animator>().SetBool("isCard", false);
    }
    GameObject MinerRandom1;
    public void ClickRandom1()
    {
        Random1.GetComponent<Animator>().SetBool("isCard", true);
        Random1.transform.Find("Card").gameObject.GetComponent<Animator>().SetBool("isClick", true);
 
    }
    public void Random1Get()
    {
        MinerRandom1.SetActive(true);
        Random1.transform.Find("Card").gameObject.SetActive(false);        
        Random1.transform.Find("Card").gameObject.GetComponent<Animator>().SetBool("isClick", false);
        if (gv.CardGetType == 1)
        {
            BtnDis1_1.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
        }
        if (gv.CardGetType == 4)
        {
            BtnDis1_4.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
        }
        if (gv.CardGetType == 6)
        {
            BtnDis1_6.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
        }
        BtnIm1.GetComponent<Button>().interactable = false;
    }
    int click5Count = 0;
    int select5Count = -1;
    List<int> Select5List = new List<int>();
    public void ClickRandom5(int i)
    {
        select5Count = i;
        Select5List.Add(i);
        Random5.GetComponent<Animator>().SetBool("isCard", true);
        int index = select5Count + 1;
        string strName = "Card" + index;
        Random5.transform.Find(strName).gameObject.GetComponent<Animator>().SetBool("isClick", true);
        //StartCoroutine(StartRandom5Anim(i));
        //StartCoroutine(EndRandom5Anim());

    }
    public void Random5Get()
    {
        int selectNum = Select5List[0];
        Select5List.RemoveAt(0);
        int index = selectNum + 1;
        string cardname = "Card" + index;
        
        Rand5Miner[selectNum].SetActive(true);
        Random5.transform.Find(cardname).gameObject.SetActive(false);
        Random5.transform.Find(cardname).gameObject.GetComponent<Animator>().SetBool("isClick", false);
        Random5.GetComponent<Animator>().SetBool("isCard", false);

        click5Count++;
        if (click5Count >= 5)
        {
            if (gv.CardGetType == 2)
            {
                BtnDis5_2.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
            if (gv.CardGetType == 5)
            {
                BtnDis5_5.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
            if (gv.CardGetType == 7)
            {
                BtnDis5_7.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;
            }
            click5Count = 0;
        }
        BtnIm5.GetComponent<Button>().interactable = false;
    }
    int click10Count =0;
    List<int> Select10List = new List<int>();
    public void ClickRandom10(int i)
    {
        Random10.GetComponent<Animator>().SetBool("isCard", true);
        Select10List.Add(i);        
        int index = i + 1;
        string strName = "Card" + index;
        Random10.transform.Find(strName).gameObject.GetComponent<Animator>().SetBool("isClick", true);

    }

    public void Random10Get()
    {
        //StartCoroutine(StartRandom10Anim(i));
        //StartCoroutine(EndRandom10Anim());
        int selectNum = Select10List[0];
        Select10List.RemoveAt(0);
        int index = selectNum + 1;
        string cardname = "Card" + index;
        click10Count++;
        Rand10Miner[selectNum].SetActive(true);
        Random10.transform.Find(cardname).gameObject.SetActive(false);
        Random10.transform.Find(cardname).gameObject.GetComponent<Animator>().SetBool("isClick", false);
        Random10.GetComponent<Animator>().SetBool("isCard", false);


        if (click10Count >= 10)
        {

            BtnDis10.transform.Find("Button").gameObject.GetComponent<Button>().interactable = true;

            click10Count = 0;
        }
        BtnIm10.GetComponent<Button>().interactable = false;
    }
    IEnumerator StartRandom5Anim(int i)
    {
        yield return new WaitForSeconds(0.1f);
        int index = i + 1;
        string cardname = "Card" + index;
        Rand5Miner[i].SetActive(true);
        Random5.transform.Find(cardname).gameObject.SetActive(false);
    }

    IEnumerator StartRandom10Anim(int i)
    {
        yield return new WaitForSeconds(0.1f);
        int index = i + 1;
        string cardname = "Card" + index;
        Rand10Miner[i].SetActive(true);
        Random10.transform.Find(cardname).gameObject.SetActive(false);
    }

    List<GameObject> Rand5Miner = new List<GameObject>();
    List<GameObject> Rand10Miner = new List<GameObject>();
    

    public void ReGetCardRandom1()
    {
        UnsetCard();
        SetCard(gv.CardGetType);
    }
    void InitRandom5Card()
    {
        for (int i = 0; i < 5; i++)
        {
            int rand = (int)Choose(ListRandomTable);
            int index = i + 1;
            string cardname = "Card" + index;
            Rand5Miner.Add(Instantiate(ListMiner[gv.ListMinerClass[rand].m_position - 1] as GameObject));
            Rand5Miner[i].transform.SetParent(Random5.transform.Find("RandomCard").gameObject.transform);
            Rand5Miner[i].transform.localScale = Random5.transform.Find(cardname).gameObject.transform.localScale;
            Rand5Miner[i].transform.localPosition = Random5.transform.Find(cardname).gameObject.transform.localPosition;
            Rand5Miner[i].SetActive(false);
            SaveHireCount(gv.ListMinerClass[rand].m_position - 1);
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 1 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 2)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 3 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 4)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 5)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 6)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 7)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
        }

    }
    void InitRandom5SCard()
    {
        List<int> gradeList = new List<int>();
        for (int k = 0; k < gv.listMinerGrade.Count; k++)
        {
            if (gv.listMinerGrade[k] >= 4 && gv.listMinerGrade[k] < 7)
            {
                gradeList.Add(k);
            }
        }

        for (int i = 0; i < 5; i++)
        {         
            int randGrade = Random.Range(0, gradeList.Count);
            int rand = (int)Choose(ListRandomTable);
            int index = i + 1;
            string cardname = "Card" + index;
            Rand5Miner.Add(Instantiate(ListMiner[gradeList[randGrade]] as GameObject));
            Rand5Miner[i].transform.SetParent(Random5.transform.Find("RandomCard").gameObject.transform);
            Rand5Miner[i].transform.localScale = Random5.transform.Find(cardname).gameObject.transform.localScale;
            Rand5Miner[i].transform.localPosition = Random5.transform.Find(cardname).gameObject.transform.localPosition;
            Rand5Miner[i].SetActive(false);
            SaveHireCount(gradeList[randGrade]);
            if (gv.listMinerGrade[gradeList[randGrade]] == 1 || gv.listMinerGrade[gradeList[randGrade]] == 2)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 3 || gv.listMinerGrade[gradeList[randGrade]] == 4)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 5)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 6)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 7)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
        }

    }
    void InitRandom5UCard()
    {
        List<int> gradeList = new List<int>();
        for (int k = 0; k < gv.listMinerGrade.Count; k++)
        {
            if (gv.listMinerGrade[k] == 7)
            {
                gradeList.Add(k);
            }
        }

        for (int i = 0; i < 5; i++)
        {
            int randGrade = Random.Range(0, gradeList.Count);
            int rand = (int)Choose(ListRandomTable);
            int index = i + 1;
            string cardname = "Card" + index;
            Rand5Miner.Add(Instantiate(ListMiner[gradeList[randGrade]] as GameObject));
            Rand5Miner[i].transform.SetParent(Random5.transform.Find("RandomCard").gameObject.transform);
            Rand5Miner[i].transform.localScale = Random5.transform.Find(cardname).gameObject.transform.localScale;
            Rand5Miner[i].transform.localPosition = Random5.transform.Find(cardname).gameObject.transform.localPosition;
            Rand5Miner[i].SetActive(false);
            SaveHireCount(gradeList[randGrade]);
            if (gv.listMinerGrade[gradeList[randGrade]] == 1 || gv.listMinerGrade[gradeList[randGrade]] == 2)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 3 || gv.listMinerGrade[gradeList[randGrade]] == 4)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 5)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 6)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gradeList[randGrade]] == 7)
            {
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
                Random5.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
        }

    }

    void InitRandom1Card()
    {
        //GradeParticle
        // 0   //listMinerGrade 1 2
        //1    //listMinerGrade 3 4
        // 2   // listMinerGrade 5  
        // 3   // listMinerGrade 6 
        // 0 1 2 3  // listMinerGrade  7

        int rand = (int)Choose(ListRandomTable);

        MinerRandom1 = Instantiate(ListMiner[gv.ListMinerClass[rand].m_position - 1] as GameObject);
        MinerRandom1.transform.SetParent(Random1.transform.Find("RandomCard").gameObject.transform);
        MinerRandom1.transform.localScale = Random1.transform.Find("Card").gameObject.transform.localScale;
        MinerRandom1.transform.localPosition = Random1.transform.Find("Card").gameObject.transform.localPosition;
        SaveHireCount(gv.ListMinerClass[rand].m_position - 1);
        MinerRandom1.SetActive(false);
        if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 1 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 2)
        {
            GradeParticle[0].SetActive(true);
        }
        if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 3 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 4)
        {
            GradeParticle[1].SetActive(true);
        }
        if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 5)
        {
            GradeParticle[2].SetActive(true);
        }
        if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 6)
        {
            GradeParticle[3].SetActive(true);
        }
        if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 7)
        {
            GradeParticle[0].SetActive(true);
            GradeParticle[1].SetActive(true);
            GradeParticle[2].SetActive(true);
            GradeParticle[3].SetActive(true);
        }
    }
    void InitRandom1SCard()
    {
        //GradeParticle
        // 0   //listMinerGrade 1 2
        //1    //listMinerGrade 3 4
        // 2   // listMinerGrade 5  
        // 3   // listMinerGrade 6 
        // 0 1 2 3  // listMinerGrade  7
        List<int> gradeList = new List<int>();
        for(int i=0; i < gv.listMinerGrade.Count; i++)
        {
            if(gv.listMinerGrade[i] >=4 && gv.listMinerGrade[i] < 7)
            {
                gradeList.Add(i);
            }
        }
        int randGrade = Random.Range(0, gradeList.Count);
        int rand = (int)Choose(ListRandomTable);

        MinerRandom1 = Instantiate(ListMiner[gradeList[randGrade]] as GameObject);
        MinerRandom1.transform.SetParent(Random1.transform.Find("RandomCard").gameObject.transform);
        MinerRandom1.transform.localScale = Random1.transform.Find("Card").gameObject.transform.localScale;
        MinerRandom1.transform.localPosition = Random1.transform.Find("Card").gameObject.transform.localPosition;
        SaveHireCount(gradeList[randGrade]);
        MinerRandom1.SetActive(false);
        if (gv.listMinerGrade[gradeList[randGrade]] == 1 || gv.listMinerGrade[gradeList[randGrade]] == 2)
        {
            GradeParticle[0].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 3 || gv.listMinerGrade[gradeList[randGrade]] == 4)
        {
            GradeParticle[1].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 5)
        {
            GradeParticle[2].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 6)
        {
            GradeParticle[3].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 7)
        {
            GradeParticle[0].SetActive(true);
            GradeParticle[1].SetActive(true);
            GradeParticle[2].SetActive(true);
            GradeParticle[3].SetActive(true);
        }
    }
    void InitRandom1UCard()
    {
        //GradeParticle
        // 0   //listMinerGrade 1 2
        //1    //listMinerGrade 3 4
        // 2   // listMinerGrade 5  
        // 3   // listMinerGrade 6 
        // 0 1 2 3  // listMinerGrade  7
        List<int> gradeList = new List<int>();
        for (int i = 0; i < gv.listMinerGrade.Count; i++)
        {
            if ( gv.listMinerGrade[i] == 7)
            {
                gradeList.Add(i);
            }
        }
        int randGrade = Random.Range(0, gradeList.Count);
        int rand = (int)Choose(ListRandomTable);

        MinerRandom1 = Instantiate(ListMiner[gradeList[randGrade]] as GameObject);
        MinerRandom1.transform.SetParent(Random1.transform.Find("RandomCard").gameObject.transform);
        MinerRandom1.transform.localScale = Random1.transform.Find("Card").gameObject.transform.localScale;
        MinerRandom1.transform.localPosition = Random1.transform.Find("Card").gameObject.transform.localPosition;
        SaveHireCount(gradeList[randGrade]);
        MinerRandom1.SetActive(false);
        if (gv.listMinerGrade[gradeList[randGrade]] == 1 || gv.listMinerGrade[gradeList[randGrade]] == 2)
        {
            GradeParticle[0].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 3 || gv.listMinerGrade[gradeList[randGrade]] == 4)
        {
            GradeParticle[1].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 5)
        {
            GradeParticle[2].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 6)
        {
            GradeParticle[3].SetActive(true);
        }
        if (gv.listMinerGrade[gradeList[randGrade]] == 7)
        {
            GradeParticle[0].SetActive(true);
            GradeParticle[1].SetActive(true);
            GradeParticle[2].SetActive(true);
            GradeParticle[3].SetActive(true);
        }
    }

    void InitRandom10Card()
    {
        for (int i = 0; i < 10; i++)
        {
            int rand = (int)Choose(ListRandomTable);
            int index = i + 1;
            string cardname = "Card" + index;
            Rand10Miner.Add(Instantiate(ListMiner[gv.ListMinerClass[rand].m_position - 1] as GameObject));
            Rand10Miner[i].transform.SetParent(Random10.transform.Find("RandomCard").gameObject.transform);
            Rand10Miner[i].transform.localScale = Random10.transform.Find(cardname).gameObject.transform.localScale;
            Rand10Miner[i].transform.localPosition = Random10.transform.Find(cardname).gameObject.transform.localPosition;
            SaveHireCount(gv.ListMinerClass[rand].m_position - 1);
            Rand10Miner[i].SetActive(false);
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 1 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 2)
            {
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 3 || gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 4)
            {
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 5)
            {
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 6)
            {
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
            if (gv.listMinerGrade[gv.ListMinerClass[rand].m_position - 1] == 7)
            {
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleD_C").gameObject.SetActive(true);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleB_A").gameObject.SetActive(true);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleS").gameObject.SetActive(true);
                Random10.transform.Find(cardname).gameObject.transform.Find("ParticleSS").gameObject.SetActive(true);
            }
        }
    }

    void SaveHireCount(int pos)
    {
        int index = pos + 1;
        if (gv.MapType ==1)
        {
            if (gv.ListHireCount[pos] == 0)
                gv.ListHireCount[pos] = 1;            
            string strHireCount = "HireCount" + index;
            PlayerPrefs.SetInt(strHireCount, gv.ListHireCount[pos]);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 2)
        {
            if (gv.ListHireDesertCount[pos] == 0)
                gv.ListHireDesertCount[pos] = 1;
            string strHireCount = "HireDesertCount" + index;
            PlayerPrefs.SetInt(strHireCount, gv.ListHireDesertCount[pos]);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 3)
        {
            if (gv.ListHireIceCount[pos] == 0)
                gv.ListHireIceCount[pos] = 1;
            string strHireCount = "HireIceCount" + index;
            PlayerPrefs.SetInt(strHireCount, gv.ListHireIceCount[pos]);
            PlayerPrefs.Save();
        }
        if (gv.MapType == 4)
        {
            if (gv.ListHireForestCount[pos] == 0)
                gv.ListHireForestCount[pos] = 1;
            string strHireCount = "HireForestCount" + index;
            PlayerPrefs.SetInt(strHireCount, gv.ListHireForestCount[pos]);
            PlayerPrefs.Save();
        }

        gv.ListHireCardOwnCount[pos] += 1;
        int indexCard = pos + 1;
        string strHireCardCount = "HireCardCount" + indexCard;

        PlayerPrefs.SetInt(strHireCardCount, gv.ListHireCardOwnCount[pos]);
        PlayerPrefs.Save();

        if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 16)
        {
            int index2 = 0;
            for (int k = 0; k < gv.ListHireCount.Count; k++)
            {
                if (gv.ListHireCount[k] != 0)
                {
                    index2++;
                }
            }
            GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(16, index2);

        }

    }
    float Choose(List<float> probs)
    {

        float total = 0;
        foreach (float elem in probs)
        {
            total += elem;
        }
        float randomPoint = Random.value * total;
        for (int i = 0; i < probs.Count; i++)
        {
            if (randomPoint < probs[i])
            {
                return i;
            }
            else
            {
                randomPoint -= probs[i];
            }
        }
        return probs.Count - 1;
    }
}




