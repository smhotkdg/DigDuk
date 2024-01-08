using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
public class EventTypeWriterEffect : MonoBehaviour
{
    //변경할 변수
    public float delay;
    public float Skip_delay;
    public int cnt;

    //타이핑효과 변수
    string[] fulltext;
    int dialog_cnt;
    string currentText;

    //타이핑확인 변수
    public bool text_exit;
    public bool text_full;
    public bool text_cut;
    public GameObject Board;

    //시작과 동시에 타이핑시작
    public int Type;
    GlobalVariable gv;
    public GameObject SkipBtn;
    public bool bstart = false;
    
    private void Awake()
    {
        gv = GlobalVariable.Instance;
            
    }
    void Start()
    {    
        //Get_Typing(dialog_cnt, fulltext);
        //InitDialogue();
    }
    
    List<int> listHowTalk = new List<int>();
    bool bStartQuest = false;
    private void InitDialogue()
    {
        cnt = 0;
        listHowTalk.Clear();
        List<string> listDialogue = new List<string>();
        List<string> listDialogueText = new List<string>();
        if (gv.MapType == 1)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object1");
                    break;
                case 1:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object2");
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 11)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(11, 0);
                    break;
                case 2:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object3");
                    break;
                case 3:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object4");
                    break;
                case 4:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object5");
                    break;
                case 5:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object6");
                    break;
                case 6:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventNormalMapObject("kor", "Object7");
                    break;
            }
        }
        if (gv.MapType == 2)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object1");
                    break;
                case 1:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object2");
                    //사막신 1
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 25)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(25, 0);
                    break;
                case 2:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object3");

                    break;
                case 3:
                    //사막신 2
                    if (GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().GetCurrentPosData() == 26)
                        GameObject.Find("MainCanvas").GetComponent<MiniQuestManager>().SetMiniQuest(26, 0);
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object4");
                    break;
                case 4:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object5");
                    break;
                case 5:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object6");
                    break;
                case 6:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object7");
                    break;
                case 7:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object8");
                    break;
                case 8:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventDesertMapObject("kor", "Object9");
                    break;
            }
        }
        if (gv.MapType == 3)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object1");
                    break;
                case 1:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object2");
                    break;
                case 2:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object3");
                    break;
                case 3:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object4");
                    break;
                case 4:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object5");
                    break;
                case 5:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object6");
                    break;
                case 6:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventIceMapObject("kor", "Object7");
                    break;
            }
        }
        if (gv.MapType == 4)
        {
            switch (gv.iSelectDialogue)
            {
                case 0:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object1");
                    break;
                case 1:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object2");
                    break;
                case 2:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object3");
                    break;
                case 3:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object4");
                    break;
                case 4:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object5");
                    break;
                case 5:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object6");
                    break;
                case 6:
                    listDialogue = GameObject.Find("MainCanvas").GetComponent<TextManager>().GetListEventForestMapObject("kor", "Object7");
                    break;
            }
        }

        for (int i = 0; i < listDialogue.Count; i++)
        {
            string strTemp = listDialogue[i];
            string[] a = strTemp.Split('-');
            listHowTalk.Add(int.Parse(a[0]));
            listDialogueText.Add(a[1]);
        }
        dialog_cnt = listDialogue.Count;
        
        fulltext = new string[dialog_cnt];
        for (int i=0; i< listDialogueText.Count; i++)
        {
            fulltext[i] = listDialogueText[i];
        }
        if(listHowTalk.Count >0)
        {
            GameObject.Find("DialogueCanvas").GetComponent<EventDialogueUIManager>().SetEventObject(listHowTalk[cnt]);
            bstartText = true;
        }   
        Get_Typing(dialog_cnt, fulltext);
    }
    bool bstartText = false;
    public void Init()
    {        
        InitDialogue();
    }
    private void OnEnable()
    {
        bStartQuest = false;
    }
    private void OnDisable()
    {
        listHowTalk.Clear();
        bStartQuest = false;
    }
    //모든 텍스트 호출완료시 탈출
    void Update()
    {
    }

    //다음버튼함수
    public void End_Typing()
    {
        //다음 텍스트 호출        
        if (text_full == true)
        {
            cnt++;
            if(listHowTalk.Count >cnt)
                GameObject.Find("DialogueCanvas").GetComponent<EventDialogueUIManager>().SetEventObject(listHowTalk[cnt]);
            text_full = false;
            text_cut = false;         
            StartCoroutine(ShowText(fulltext));
        }
        //텍스트 타이핑 생략
        else
        {
            text_cut = true;
        }
    }

    //텍스트 시작호출
    public void Get_Typing(int _dialog_cnt, string[] _fullText)
    {
        //재사용을 위한 변수초기화
        text_exit = false;
        text_full = false;
        text_cut = false;
        cnt = 0;

        //변수 불러오기
        dialog_cnt = _dialog_cnt;
        fulltext = new string[dialog_cnt];
        fulltext = _fullText;

        //타이핑 코루틴시작
        StartCoroutine(ShowText(fulltext));
    }

    IEnumerator ShowText(string[] _fullText)
    {
        //모든텍스트 종료
        if (cnt >= dialog_cnt)
        {
            if(bstartText == true)
            {
                text_exit = true;                
                StopCoroutine("showText");
                this.GetComponent<Text>().text = "";
                //종료 시작
                GameObject.Find("DialogueCanvas").GetComponent<EventDialogueUIManager>().StartEndView();
                bstartText = false;
                //GameObject.Find("MainCanvas").GetComponent<MainBtnSrc>().SaveEventData(2);
                
                    
            }
        }
        else
        {
            //기존문구clear
            currentText = "";
            //타이핑 시작
            for (int i = 0; i < _fullText[cnt].Length; i++)
            {
                //타이핑중도탈출
                if (text_cut == true)
                {
                    break;
                }
                //단어하나씩출력
                currentText = _fullText[cnt].Substring(0, i + 1);
                this.GetComponent<Text>().text = currentText;
                yield return new WaitForSeconds(delay);
            }
            //탈출시 모든 문자출력
            Debug.Log("Typing 종료");
            this.GetComponent<Text>().text = _fullText[cnt];
            yield return new WaitForSeconds(Skip_delay);

            //스킵_지연후 종료
            Debug.Log("Enter 대기");
            text_full = true;
        }
    }
}

