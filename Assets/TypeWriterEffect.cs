using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TypeWriterEffect : MonoBehaviour
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
    private void Awake()
    {
        gv = GlobalVariable.Instance;
        if (Type ==0)
        {
            dialog_cnt = 3;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "안녕 난 주인이라고 한다 \n\n주인이다 이xx야\n";
            fulltext[1] = "신비한 광물을 찾아 \n\n호이짜호이짜 별에서 \n\n지구까지 오게 되었어\n";
            fulltext[2] = "먼저 노예를 \n\n구하는 방법을 알려줄께\n";
        }
        if (Type == 1)
        {
            dialog_cnt = 2;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "잘했어 \n\n드디어 첫 번째 노예를 구했네\n";
            fulltext[1] = "노예가 광물을 구해오도록\n\n광산에 배치해야돼\n";            
        }
        if (Type == 2)
        {
            dialog_cnt = 2;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "좋았어 훌륭한 노예가 한명 생겼어\n\n첫 번째 배치 기념으로 선물을 준비했어\n";
            fulltext[1] = "첫 선물은 개xx야\n";
        }
        if (Type == 3)
        {
            dialog_cnt = 2;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "새로운 강아지 xx 노예가 생겼어!!\n";
            fulltext[1] = "손으로 파는애랑 조합을 한번 보여줄께\n";
        }
        if (Type == 4)
        {
            dialog_cnt = 3;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "노예 조합으로 강력한 힘을 얻었어!!\n";
            fulltext[1] = "더 많은 조합을 찾아봐\n";
            fulltext[2] = "다음은 노예를 관리하는 방법을 알려줄게\n";
        }
        if (Type == 5)
        {
            dialog_cnt = 1;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "노예를 클릭하면\n\n노예가 지금까지 모은\n\n돈... 특수능력... 레벨....을\n\n확인할 수 있어!!\n"; 
        }
        if (Type == 6)
        {
            dialog_cnt = 1;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "지금까지 모은 돈을 \n\n클릭해서 얻을 수 있어\n\n깊이가 깊어질 수록 \n\n돈을 더 많이 가져올꺼야!!\n";
        }
        if (Type == 7)
        {
            dialog_cnt = 1;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "이 버튼을 통해 노예가\n\n 더 빠르게 일하기 만들수있어\n";
        }
        if (Type ==8)
        {
            dialog_cnt = 1;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "노예 정보를 볼 수 있어\n\n나중에 심심하면 들어가봐\n";
        }
        if (Type == 9)
        {
            dialog_cnt = 9;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "땅을 더 깊게 파려면\n\n여기가 100% 됬을때\n";
            fulltext[1] = "다이너마이트를 누르면\n\n폭파 시킬수 있어\n";
            fulltext[2] = "시작 버튼을 누르면\n\n\n폭파를 시작하는거야";
            fulltext[3] = "시간이 얼마나 필요한지\n\n여기 나와있어";            
            fulltext[4] = "처음이니까 내가 돈을 줄께\n\n즉시 폭파 해보자";
            fulltext[5] = "즉시 버튼을 눌러봐";
            fulltext[6] = "즉시 버튼을 눌러봐";
            fulltext[7] = "즉시 버튼을 눌러봐";
            fulltext[8] = "즉시 버튼을 눌러봐";
        }

        if (Type == 10)
        {
            dialog_cnt = 1;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "땅을 더 깊게 팔려면\n\n엔진과 드릴을\n\n업그레이드 해야돼";
    
        }

        if (Type == 11)
        {
            dialog_cnt = 3;
            fulltext = new string[dialog_cnt];
            fulltext[0] = "드릴은 비싸니깐\n\n돈 벌어서 사봐";
            fulltext[1] = "마지막으로\n\n나를 클릭해봐";
            fulltext[2] = "선물을 준비했어";
        }
    }
    void Start()
    {
        Get_Typing(dialog_cnt, fulltext);
    }

    private void OnEnable()
    {
        Get_Typing(dialog_cnt, fulltext);
    }
    //모든 텍스트 호출완료시 탈출
    void Update()
    {
        if (text_exit == true)
        {
            gameObject.SetActive(false);            
        }

    }

    //다음버튼함수
    public void End_Typing()
    {
        //다음 텍스트 호출        
        if (text_full == true)
        {
            cnt++;
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
            text_exit = true;
            StopCoroutine("showText");
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

