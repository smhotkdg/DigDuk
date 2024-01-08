using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TextManager : MonoBehaviour {

    // Use this for initialization
    public List<Text> CoinList ;
    public List<Text> BlackCoinList;
    public List<Text> CapaticyCoinList;

    private List<string> MinerName_kor = new List<string>();
    private List<string> MinerAblity_kor = new List<string>();
    private List<string> MinerSpecialAblity_kor = new List<string>();

    private List<string> MinerName_eng = new List<string>();
    private List<string> MinerAblity_eng = new List<string>();
    private List<string> MinerSpecialAblity_eng = new List<string>();

    private List<string> EngineName_kor = new List<string>();
    private List<string> BitName_kor = new List<string>();

    private List<string> EngineName_eng = new List<string>();
    private List<string> BitName_eng = new List<string>();

    private List<string> CapacityName_kor = new List<string>();
    private List<string> CapacityName_eng = new List<string>();

    private List<string> ShopItemName_kor = new List<string>();
    private List<string> ShopItemName_eng = new List<string>();

    private List<string> MineralsName_kor = new List<string>();
    private List<string> MineralsName_eng = new List<string>();


    private List<string> GradFatherEventDialog_kor = new List<string>();
    private List<string> MrMineEventDialog_kor = new List<string>();
    private List<string> DigDaEventDialog_kor = new List<string>();
    private List<string> EscapedprisonerEventDialog_kor = new List<string>();
    private List<string> SkeletonEventDialog_kor = new List<string>();
    private List<string> TerminatorEventDialog_kor = new List<string>();
    private List<string> FiresoulEventDialog_kor = new List<string>();


    private List<string> GradFatherEventDialog_eng = new List<string>();
    private List<string> MrMineEventDialog_eng = new List<string>();
    private List<string> DigDaEventDialog_eng = new List<string>();
    private List<string> EscapedprisonerEventDialog_eng = new List<string>();
    private List<string> SkeletonEventDialog_eng = new List<string>();
    private List<string> TerminatorEventDialog_eng = new List<string>();
    private List<string> FiresoulEventDialog_eng = new List<string>();



    private List<string> DesertEventObject1Dialogue_kor = new List<string>();
    private List<string> DesertEventObject2Dialogue_kor = new List<string>();
    private List<string> DesertEventObject3Dialogue_kor = new List<string>();
    private List<string> DesertEventObject4Dialogue_kor = new List<string>();
    private List<string> DesertEventObject5Dialogue_kor = new List<string>();
    private List<string> DesertEventObject6Dialogue_kor = new List<string>();
    private List<string> DesertEventObject7Dialogue_kor = new List<string>();
    private List<string> DesertEventObject8Dialogue_kor = new List<string>();
    private List<string> DesertEventObject9Dialogue_kor = new List<string>();


    private List<string> DesertEventObject1Dialogue_eng = new List<string>();
    private List<string> DesertEventObject2Dialogue_eng = new List<string>();
    private List<string> DesertEventObject3Dialogue_eng = new List<string>();
    private List<string> DesertEventObject4Dialogue_eng = new List<string>();
    private List<string> DesertEventObject5Dialogue_eng = new List<string>();
    private List<string> DesertEventObject6Dialogue_eng = new List<string>();
    private List<string> DesertEventObject7Dialogue_eng = new List<string>();
    private List<string> DesertEventObject8Dialogue_eng = new List<string>();
    private List<string> DesertEventObject9Dialogue_eng = new List<string>();


    private List<string> IceEventObject1Dialogue_kor = new List<string>();
    private List<string> IceEventObject2Dialogue_kor = new List<string>();
    private List<string> IceEventObject3Dialogue_kor = new List<string>();
    private List<string> IceEventObject4Dialogue_kor = new List<string>();
    private List<string> IceEventObject5Dialogue_kor = new List<string>();
    private List<string> IceEventObject6Dialogue_kor = new List<string>();
    private List<string> IceEventObject7Dialogue_kor = new List<string>();


    private List<string> IceEventObject1Dialogue_eng = new List<string>();
    private List<string> IceEventObject2Dialogue_eng = new List<string>();
    private List<string> IceEventObject3Dialogue_eng = new List<string>();
    private List<string> IceEventObject4Dialogue_eng = new List<string>();
    private List<string> IceEventObject5Dialogue_eng = new List<string>();
    private List<string> IceEventObject6Dialogue_eng = new List<string>();
    private List<string> IceEventObject7Dialogue_eng = new List<string>();



    private List<string> ForestEventObject1Dialogue_kor = new List<string>();
    private List<string> ForestEventObject2Dialogue_kor = new List<string>();
    private List<string> ForestEventObject3Dialogue_kor = new List<string>();
    private List<string> ForestEventObject4Dialogue_kor = new List<string>();
    private List<string> ForestEventObject5Dialogue_kor = new List<string>();
    private List<string> ForestEventObject6Dialogue_kor = new List<string>();
    private List<string> ForestEventObject7Dialogue_kor = new List<string>();


    private List<string> ForestEventObject1Dialogue_eng = new List<string>();
    private List<string> ForestEventObject2Dialogue_eng = new List<string>();
    private List<string> ForestEventObject3Dialogue_eng = new List<string>();
    private List<string> ForestEventObject4Dialogue_eng = new List<string>();
    private List<string> ForestEventObject5Dialogue_eng = new List<string>();
    private List<string> ForestEventObject6Dialogue_eng = new List<string>();
    private List<string> ForestEventObject7Dialogue_eng = new List<string>();


    void Start () {

        //This checks if your computer's operating system is in the French language
        if (Application.systemLanguage == SystemLanguage.French)
        {            
            Debug.Log("This system is in French. ");
        }        
        else if (Application.systemLanguage == SystemLanguage.English)
        {
            Debug.Log("This system is in English. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Korean)
        {
            Debug.Log("This system is in Korean. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Spanish)
        {
            Debug.Log("This system is in Spanish. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Portuguese)
        {
            Debug.Log("This system is in Portuguese. ");
        }
        else if (Application.systemLanguage == SystemLanguage.German)
        {
            Debug.Log("This system is in German. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Italian)
        {
            Debug.Log("This system is in Italian. ");
        }

        else if (Application.systemLanguage == SystemLanguage.Russian)
        {
            Debug.Log("This system is in Russian. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Japanese)
        {
            Debug.Log("This system is in Japanese. ");
        }
        //인도어 없음
        else if (Application.systemLanguage == SystemLanguage.ChineseSimplified)
        {
            Debug.Log("This system is in ChineseSimplified. ");
        }
        else if (Application.systemLanguage == SystemLanguage.Arabic)
        {
            Debug.Log("This system is in Arabic. ");
        }
        InitText();

    }
	
    public List<string> GetListEventNormalMapObject(string language,string type)
    {
        if(language =="kor")
        {
            switch(type)
            {
                case "Object1":
                    return GradFatherEventDialog_kor;                    
                case "Object2":
                    return MrMineEventDialog_kor;                    
                case "Object3":
                    return DigDaEventDialog_kor;
                case "Object4":
                    return EscapedprisonerEventDialog_kor;
                case "Object5":
                    return SkeletonEventDialog_kor;
                case "Object6":
                    return TerminatorEventDialog_kor;
                case "Object7":
                    return FiresoulEventDialog_kor;
            }            
        }
        if (language == "Eng")
        {
            switch (type)
            {
                case "Object1":
                    return GradFatherEventDialog_eng;
                case "Object2":
                    return MrMineEventDialog_eng;
                case "Object3":
                    return DigDaEventDialog_eng;
                case "Object4":
                    return EscapedprisonerEventDialog_eng;
                case "Object5":
                    return SkeletonEventDialog_eng;
                case "Object6":
                    return TerminatorEventDialog_eng;
                case "Object7":
                    return FiresoulEventDialog_eng;
            }            
        }
        return null;
    }

    public List<string> GetListEventDesertMapObject(string language, string type,int goodtype = -1)
    {
        if (language == "kor")
        {
            switch (type)
            {
                case "Object1":
                    return DesertEventObject1Dialogue_kor;
                case "Object2":                
                    return DesertEventObject2Dialogue_kor;              
                case "Object3":
                    return DesertEventObject3Dialogue_kor;
                case "Object4":
                    return DesertEventObject4Dialogue_kor;
                case "Object5":
                    return DesertEventObject5Dialogue_kor;
                case "Object6":
                    return DesertEventObject6Dialogue_kor;
                case "Object7":
                    return DesertEventObject7Dialogue_kor;
                case "Object8":
                    return DesertEventObject8Dialogue_kor;
                case "Object9":
                    return DesertEventObject9Dialogue_kor;
            }
        }
        if (language == "Eng")
        {
            switch (type)
            {
                case "Object1":
                    return DesertEventObject1Dialogue_eng;
                case "Object2":           
                    return DesertEventObject2Dialogue_eng;           
                case "Object3":
                    return DesertEventObject3Dialogue_eng;
                case "Object4":
                    return DesertEventObject4Dialogue_eng;
                case "Object5":
                    return DesertEventObject5Dialogue_eng;
                case "Object6":
                    return DesertEventObject6Dialogue_eng;
                case "Object7":
                    return DesertEventObject7Dialogue_eng;
                case "Object8":
                    return DesertEventObject8Dialogue_eng;
                case "Object9":
                    return DesertEventObject9Dialogue_eng;
            }
        }
        return null;
    }

    public List<string> GetListEventIceMapObject(string language, string type)
    {
        if (language == "kor")
        {
            switch (type)
            {
                case "Object1":
                    return IceEventObject1Dialogue_kor;
                case "Object2":
                    return IceEventObject2Dialogue_kor;
                case "Object3":
                    return IceEventObject3Dialogue_kor;
                case "Object4":
                    return IceEventObject4Dialogue_kor;
                case "Object5":
                    return IceEventObject5Dialogue_kor;
                case "Object6":
                    return IceEventObject6Dialogue_kor;
                case "Object7":
                    return IceEventObject7Dialogue_kor;
            }
        }
        if (language == "Eng")
        {
            switch (type)
            {
                case "Object1":
                    return IceEventObject1Dialogue_eng;
                case "Object2":
                    return IceEventObject2Dialogue_eng;
                case "Object3":
                    return IceEventObject3Dialogue_eng;
                case "Object4":
                    return IceEventObject4Dialogue_eng;
                case "Object5":
                    return IceEventObject5Dialogue_eng;
                case "Object6":
                    return IceEventObject6Dialogue_eng;
                case "Object7":
                    return IceEventObject7Dialogue_eng;
            }
        }
        return null;
    }

    public List<string> GetListEventForestMapObject(string language, string type)
    {
        if (language == "kor")
        {
            switch (type)
            {
                case "Object1":
                    return ForestEventObject1Dialogue_kor;
                case "Object2":
                    return ForestEventObject2Dialogue_kor;
                case "Object3":
                    return ForestEventObject3Dialogue_kor;
                case "Object4":
                    return ForestEventObject4Dialogue_kor;
                case "Object5":
                    return ForestEventObject5Dialogue_kor;
                case "Object6":
                    return ForestEventObject6Dialogue_kor;
                case "Object7":
                    return ForestEventObject7Dialogue_kor;
            }
        }
        if (language == "Eng")
        {
            switch (type)
            {
                case "Object1":
                    return ForestEventObject1Dialogue_eng;
                case "Object2":
                    return ForestEventObject2Dialogue_eng;
                case "Object3":
                    return ForestEventObject3Dialogue_eng;
                case "Object4":
                    return ForestEventObject4Dialogue_eng;
                case "Object5":
                    return ForestEventObject5Dialogue_eng;
                case "Object6":
                    return ForestEventObject6Dialogue_eng;
                case "Object7":
                    return ForestEventObject7Dialogue_eng;
            }
        }
        return null;
    }

    void InitText()
    {
        ///////Map1 Object
        {
            // Object1 kor
            GradFatherEventDialog_kor.Add("0-할아버지??!? 여기서 뭐 하세요??");
            GradFatherEventDialog_kor.Add("1-요즘 시대에도 땅을 파는 친구가 있구먼......");
            GradFatherEventDialog_kor.Add("0-돈 좀 벌려고요");
            GradFatherEventDialog_kor.Add("1-나도 한때 땅을 팠었지... 전설의 광물을 찾아서...");
            GradFatherEventDialog_kor.Add("1-나는 실패했다네.... 끝까지 가지 못했어.. 사고가 있었거든..");
            GradFatherEventDialog_kor.Add("1-땅의 끝에 가보게 전설의 광물이 있을 것이야....");
            GradFatherEventDialog_kor.Add("1-이걸 받게나!! 도움이 될 것이야.....");
            GradFatherEventDialog_kor.Add("1-그리고..... 60Km에 가면 나와 같이 땅을 파던 친구가 있다네..... ");
            GradFatherEventDialog_kor.Add("1-전설의 광물을 찾다 실패하고 매우 우울해하고 있는 것 같구먼....");
            GradFatherEventDialog_kor.Add("1-만나서 위로 해주고 오면 고맙겠네... 부탁하네 주인아....");
            GradFatherEventDialog_kor.Add("0-알겠어요 할아버지");
            GradFatherEventDialog_kor.Add("1-나를 1시간마다 찾아오면 자동판매 포션(소) 하나씩 주마");
            GradFatherEventDialog_kor.Add("1-마지막으로 내가 주는 선물이란다. 자동 판매 포션 (대) 유용하게 쓰길 바란다");
            // GradFatherEventDialog_kor.Add("3-22시 33분 있다가 다시 오게나 자동 판매 포션 (소) 를 주겠네");

            // Object1 eng
            GradFatherEventDialog_eng.Add("0-Oh, grandfather, What are you doing here?");
            GradFatherEventDialog_eng.Add("1-There’s someone who's digging in these days.");
            GradFatherEventDialog_eng.Add("0-I’d like to make some money here.");
            GradFatherEventDialog_eng.Add("1-I used to dig the ground to find a legendary mineral.");
            GradFatherEventDialog_eng.Add("1-But, I failed to find it.. I couldn’t make it. There was an accident....");
            GradFatherEventDialog_eng.Add("1-Please go to the end of the ground, there will be the legendary minera...");
            GradFatherEventDialog_eng.Add("1-And, please take it! It will be very helpful to find it.");
            GradFatherEventDialog_eng.Add("1-If you reach the 60km, you can find the my friend who used to dig with me.");
            GradFatherEventDialog_eng.Add("1-It looks like he failed to find the legendary mineral and he’s depressed now.");
            GradFatherEventDialog_eng.Add("1-Please offer words of consolation to him");
            GradFatherEventDialog_eng.Add("0-Oh, okay. I got it. Grandfather.");
            GradFatherEventDialog_eng.Add("1-If you come to see me every an hour, I’ll give you an Automatic sale potion(Large)");
            GradFatherEventDialog_eng.Add("1-Lastly, it’s my gift. (an Automatic sale potion(Large) I hope it will be useful.");


            // Object2 kor
            MrMineEventDialog_kor.Add("1-흐어어어어어어어어엉 ㅠㅠㅠㅠㅠ후어어어어어엉우ㅜㅜㅜ");
            MrMineEventDialog_kor.Add("0-울지 마 넌 누구니??");
            MrMineEventDialog_kor.Add("1-말 걸지 마 외계인 놈아!!");
            MrMineEventDialog_kor.Add("1-흐어어어어어어엉 ㅠㅠㅠㅠ");
            MrMineEventDialog_kor.Add("0-왜 무슨일이야?");
            MrMineEventDialog_kor.Add("1-난 예전에 할아버지와 함께 땅을 팠던 광부야 ㅠㅠㅠㅠ");
            MrMineEventDialog_kor.Add("1-우리 광산이 사고로 무너져 버렸어 ㅠㅠ");
            MrMineEventDialog_kor.Add("1-계속 땅을 파고 싶지만 이젠 너무 힘들어");
            MrMineEventDialog_kor.Add("1-나를 대신해서 땅을 계속 파주면 안되겠니? (노예처럼 부려먹어주마 ㅋㅋㅋ)");
            MrMineEventDialog_kor.Add("1-조금 더 내려가면 땅 좀 잘 파는 두더지가 살고 있어");
            MrMineEventDialog_kor.Add("1-두더지에게 도움을 받을 수 있을 거야!!");
            MrMineEventDialog_kor.Add("0-알았어 나만 믿어");
            MrMineEventDialog_kor.Add("1-그리고 나를 1시간마다 찾아오면 광부 포션(소) 1개씩 줄게");
            MrMineEventDialog_kor.Add("1-마지막으로 내가 주는 선물이야 (3 A) 잘 써~");
            // MrMineEventDialog_kor.Add("3-22시 33분 있다가 다시와~ 광부 포션(소) 를 줄게");

            // Object2 eng
            MrMineEventDialog_eng.Add("1-Boohoo.. Boohoo.. Boohoo.. :(");
            MrMineEventDialog_eng.Add("0-Stop crying please. Who are you?");
            MrMineEventDialog_eng.Add("1-Do not talk to me! Damn you alien!!");
            MrMineEventDialog_eng.Add("1-Boohoo.. :(");
            MrMineEventDialog_eng.Add("0-Hey, what’s going on?");
            MrMineEventDialog_eng.Add("1-I am a miner who used to dig with my grandfather.");
            MrMineEventDialog_eng.Add("1-By the way, our mine collapsed in an accident!");
            MrMineEventDialog_eng.Add("1-I wanna keep digging the ground. But it’s too hard now.");
            MrMineEventDialog_eng.Add("1-Would you mind if you dig the ground instead of me? (‘I'll treat you like a slave. Haha’)");
            MrMineEventDialog_eng.Add("1-When you go down further, there is a mole who digs well.");
            MrMineEventDialog_eng.Add("1-You can get some help from him!");
            MrMineEventDialog_eng.Add("0-Okay, just count on me!");
            MrMineEventDialog_eng.Add("0-If you come to see me every an hour, I’ll give you a Miner Potion(Small)");
            MrMineEventDialog_eng.Add("0-Lastly, it’s my gift. (3 A) I hope you will like it.");

            // Object3 kor
            DigDaEventDialog_kor.Add("1-디그덕~♬ 디그덕~♬ 덕트덕트 닥쳐라 !!!");
            DigDaEventDialog_kor.Add("0-뭐야 이 포켓몬 같은 놈은?");
            DigDaEventDialog_kor.Add("1-땅을 파고 있구나 하수야~~");
            DigDaEventDialog_kor.Add("1-너도 알겠지만 나는 딱 봐도 땅파기 고수지 풋");
            DigDaEventDialog_kor.Add("1-요즘 눈이 너무 부셔서 선글라스 좀 바꾸고 싶은데");
            DigDaEventDialog_kor.Add("1-골드를 좀 준다면 내가 땅 파는 법을 알려주지 풋");
            DigDaEventDialog_kor.Add("1-아 그리고! 150Km에 이상한 시체 하나 있는데 한번 확인해줘");
            DigDaEventDialog_kor.Add("1-나는 무서워서 못가겠어 풋");
            DigDaEventDialog_kor.Add("0-알았다 요놈아");
            DigDaEventDialog_kor.Add("1-나를 1시간마다 찾아오면 드릴 포션(소)를 매일 줄게");
            DigDaEventDialog_kor.Add("1-마지막으로 선물을 준비했다 풋 드릴 포션(대) 가져가~");
            //  DigDaEventDialog_kor.Add("3-22시 33분 후에 오면 드릴포션(소)를 줄게");

            // Object3 eng
            DigDaEventDialog_eng.Add("1-Digduk~♬ Digduk~♬ Ductduct Shut up!!");
            DigDaEventDialog_eng.Add("0-Who are you? You look like Pokemon.");
            DigDaEventDialog_eng.Add("1-You are digging the ground now, Newbie~~");
            DigDaEventDialog_eng.Add("1-As you know, I’m the master of the Digger.");
            DigDaEventDialog_eng.Add("1-These days, my eyes are so dazzled that I would like to change my sunglasses.");
            DigDaEventDialog_eng.Add("1-If you give me some gold, I will let you know how to dig the ground.");
            DigDaEventDialog_eng.Add("1-Is it okay to check it out the at 150km? i think, you can find the Dead body over there..");
            DigDaEventDialog_eng.Add("1-I can’t go there because I am sacred.");
            DigDaEventDialog_eng.Add("0-Okay, boy.");
            DigDaEventDialog_eng.Add("1-If you come to me, I’ll give you a Drill Potion (Small) every an hour.");
            DigDaEventDialog_eng.Add("1-Lastly, I prepared a present for you. (Drill Potion Large) Take it :)");

            // Object4 kor
            EscapedprisonerEventDialog_kor.Add("1-탈출이다!!!!!!!!!!!!!!!!!!!");
            EscapedprisonerEventDialog_kor.Add("1-헉!!! 뭐야 탈출이 아니야 !?!?!?!?!? 여긴 어디야!?!?");
            EscapedprisonerEventDialog_kor.Add("0-광산인데요???");
            EscapedprisonerEventDialog_kor.Add("1-허거덕!! 너무 깊이 팠나 보군");
            EscapedprisonerEventDialog_kor.Add("1-나는 사실 예전에 광부였었어");
            EscapedprisonerEventDialog_kor.Add("1-광물을 몰래 빼돌리다 잡혔거든 이봐 신고하지 말아 줘");
            EscapedprisonerEventDialog_kor.Add("1-선물을 줄 테니깐");
            EscapedprisonerEventDialog_kor.Add("0-알겠어 신고는 안 할게");
            EscapedprisonerEventDialog_kor.Add("1-고맙다 이걸 받아 (올랜덤 카드팩 1장)");

            // Object4 eng
            EscapedprisonerEventDialog_eng.Add("1-Finally, I have escaped!!!");
            EscapedprisonerEventDialog_eng.Add("1-Oh my gosh! Why am I in the dim place? Where am I now?!");
            EscapedprisonerEventDialog_eng.Add("0-You are still on the mine.");
            EscapedprisonerEventDialog_eng.Add("1-OMG!! I think I dug too deep.");
            EscapedprisonerEventDialog_eng.Add("1-Actually, I was a miner…");
            EscapedprisonerEventDialog_eng.Add("1-I was stealing some minerals and then I went into the prison.");
            EscapedprisonerEventDialog_eng.Add("1-Hey, don’t report me. I’ll give you a present.");
            EscapedprisonerEventDialog_eng.Add("0-Okay. I will not report you.");
            EscapedprisonerEventDialog_eng.Add("1-Thanks a lot. Take this. (all-random card pack, one for you.)");


            // Object5 kor
            SkeletonEventDialog_kor.Add("1-오 드디어 날 찾아준 사람이 있다니!");
            SkeletonEventDialog_kor.Add("0-저 사람 아닌데여 외계인인데요");
            SkeletonEventDialog_kor.Add("1-외계인이라도 좋다 나에게 왔다는 게 중요하지!");
            SkeletonEventDialog_kor.Add("0-혹시... 전설의 광물에 대해서 아시나요?");
            SkeletonEventDialog_kor.Add("1-전설의 광물을 찾고 있구만...... 그것 때문에 내가 이지경이 되었지....");
            SkeletonEventDialog_kor.Add("1-사막까지 갔었지만 찾지 못하고 돌아왔지.....");
            SkeletonEventDialog_kor.Add("1-하지만 광산이 무너져 난 이렇게 되고 말았어");
            SkeletonEventDialog_kor.Add("1-전설의 광물은 찾지 못했지만.... 나는!!! 합성의 광물을 찾았어!!");
            SkeletonEventDialog_kor.Add("1-이 합성의 광물은 광부 두 명을 합성하여 더 높은 등급의 광부를 얻을 수 있어");
            SkeletonEventDialog_kor.Add("1-광부의 레벨이 높을수록 다음 등급의 광부가 나올 확률이 높아진다고!!");
            SkeletonEventDialog_kor.Add("1-앞으로 나를 찾아오면 계속 합성할 수 있게 해줄게");
            SkeletonEventDialog_kor.Add("1-그리고 이제 너는 사막을 여행할 수 있는 능력이 충분해 이걸 가져가라 사막을 열어주는 열쇠다");
            SkeletonEventDialog_kor.Add("1-이곳에서도 400Km까지 간다면 다른 놈 들도 만날 수 있긴 하지만 조심하길 바란다");
            SkeletonEventDialog_kor.Add("0-넹 알겠습니다");
            SkeletonEventDialog_kor.Add("1-사막맵으로 갈수 있게 열쇠를 주마 (사막맵 열쇠) , (합성 가능)");


            // Object6 eng
            SkeletonEventDialog_eng.Add("1-Oh, I can’t believe there’s someone who finally found me!");
            SkeletonEventDialog_eng.Add("0-Excuse me. I am not a human. I am an alien.");
            SkeletonEventDialog_eng.Add("1-I don’t care whether you’re an alien or not. The point is you found me!");
            SkeletonEventDialog_eng.Add("0-Do you know about a Legendary Mineral?");
            SkeletonEventDialog_eng.Add("1-It looks like you are looking for a Legendary Mineral... Because of it, I became like this.");
            SkeletonEventDialog_eng.Add("1-I went to up to a desert. But I couldn’t find anything and just came back....");
            SkeletonEventDialog_eng.Add("1-But, the mine collapsed suddenly and I ended up like this.");
            SkeletonEventDialog_eng.Add("1-Even though I couldn’t find the legendary mineral, I found a Combining Minerals!!");
            SkeletonEventDialog_eng.Add("1-If you combine two miners & this mineral, you can get a higher grade of miner");
            SkeletonEventDialog_eng.Add("1-If your miner have a high level, you will get more chance to higher grade of miner");
            SkeletonEventDialog_eng.Add("1-If you come to me, I’ll let you keep compound your miners.");
            SkeletonEventDialog_eng.Add("1-And, now you have enough ability to travel in the desert. Take this. It’s the key to open the desert map.");
            SkeletonEventDialog_eng.Add("1-If you go down 400km from here, you can meet other guys. Please, be careful");
            SkeletonEventDialog_eng.Add("0-Okay, I got it.");
            SkeletonEventDialog_eng.Add("1-Here is the key to get to the desert map. (Key for Desert Map, Available, Combining available)");


            // Object7 kor
            TerminatorEventDialog_kor.Add("1-존????? 존인가??");
            TerminatorEventDialog_kor.Add("0-주인인데요?");
            TerminatorEventDialog_kor.Add("1-주인이라고?? 뭔 개소리야");
            TerminatorEventDialog_kor.Add("1-지구는 어떻게 되었지 멸망 했나?!?!?");
            TerminatorEventDialog_kor.Add("0-뭔소리야 잘만 땅 파고 있구만");
            TerminatorEventDialog_kor.Add("1-땅을 파고 있다고?? 그렇다면 아직 늦지 않았군");
            TerminatorEventDialog_kor.Add("1-얼른 미래로 돌아가야 해!!");
            TerminatorEventDialog_kor.Add("1-나 좀 도와줘!!!!!");
            TerminatorEventDialog_kor.Add("0-뭘?? 어떻게 도와줘야 되는데!!");
            TerminatorEventDialog_kor.Add("1- .........차비좀 ........부탁할게......(1 A)");
            TerminatorEventDialog_kor.Add("0-어휴.. 여기 있다...거지새끼");
            TerminatorEventDialog_kor.Add("1-고맙다 덕분에 미래로 갈 수 있게 되었어 우리 언젠가 다시 만나게 될 거야");
            TerminatorEventDialog_kor.Add("1-그땐 내가 꼭 커다란 보상을 해주지");
            TerminatorEventDialog_kor.Add("1-아! 그리고 꽤 밑으로 내려가면 무서운 몬스터가 있으니 조심해");
            TerminatorEventDialog_kor.Add("1-나는 살짝 보고 도망쳤거든 그럼 이만!!");
            TerminatorEventDialog_kor.Add("1-I'll be Back (찡긋)");
            TerminatorEventDialog_kor.Add("0-드럽게 멋있는 척하네");

            // Object7 eng
            TerminatorEventDialog_eng.Add("1-John? Are you John?");
            TerminatorEventDialog_eng.Add("0-No, I am M....r... JUIN.....");
            TerminatorEventDialog_eng.Add("1-What? Are you Juin? What are you talking about?");
            TerminatorEventDialog_eng.Add("1-What happened to the Earth? Is it destroyed?");
            TerminatorEventDialog_eng.Add("0-Huh? Look, I am digging the ground!");
            TerminatorEventDialog_eng.Add("1-Are you digging now? Oh, then it’s not too late!");
            TerminatorEventDialog_eng.Add("1-I need to go back to the future!");
            TerminatorEventDialog_eng.Add("1-Please, help me!!!!!");
            TerminatorEventDialog_eng.Add("0-How can I help you?!?!?");
            TerminatorEventDialog_eng.Add("1-...please... lend me pay the fare...");
            TerminatorEventDialog_eng.Add("0-Ugh... Here it is. what a beggar.");
            TerminatorEventDialog_eng.Add("1-Thanks to you, I can go to the future. We’ll meet again someday.");
            TerminatorEventDialog_eng.Add("1-Then, I will give you a big reward.");
            TerminatorEventDialog_eng.Add("1-Ah! And, if you go down pretty low, there’s a scary monster, so please be careful.");
            TerminatorEventDialog_eng.Add("1-I took a peak at him and ran away. Anyway, bye for now!");
            TerminatorEventDialog_eng.Add("1-I’ll be back. ");
            TerminatorEventDialog_eng.Add("0-He’s pretending to be fuxxing cool, haha.");

            // Object8 kor
            FiresoulEventDialog_kor.Add("1-누구냐!");
            FiresoulEventDialog_kor.Add("1-나는 이 땅을 지키는 정령이다");
            FiresoulEventDialog_kor.Add("1-여기까지 오는 생물체가 있다니 대단하구나");
            FiresoulEventDialog_kor.Add("1-고생했으니 내가 선물을 주마");
            FiresoulEventDialog_kor.Add("1-난 무서운사람 아니 무서운 정령이 아니란다 주인아...");
            FiresoulEventDialog_kor.Add("1-이걸 받아가렴 (A-SS 카드팩 1장)");

            // Object8 eng
            FiresoulEventDialog_eng.Add("1-Who are you?");
            FiresoulEventDialog_eng.Add("1-I am a spirit who protects this ground.");
            FiresoulEventDialog_eng.Add("1-It’s amazing that there are some creatures coming all the way here!");
            FiresoulEventDialog_eng.Add("1-I’ll give you a present, since you’ve worked hard.");
            FiresoulEventDialog_eng.Add("1-Dont be scared to me, , I am NOT a scary spirit.");
            FiresoulEventDialog_eng.Add("1-Take this. (A-SS Card Pack for one miner.)");

        }
        /////DesertMap Object
        {
            // Object1 kor
            DesertEventObject1Dialogue_kor.Add("1-잘 찾아왔다 여긴 신비로운 수수께끼들이 많은 곳이다.");
            DesertEventObject1Dialogue_kor.Add("1-땅을 깊게 팔수록 네가 원하는 것을 얻을 수 있을 것이다.");
            DesertEventObject1Dialogue_kor.Add("1-전설의 광물은 여러 곳의 끝에 존재하지");
            DesertEventObject1Dialogue_kor.Add("1-계속 내려가면서 이집트의 신들을 모두 만나게 되면 새로운 곳으로 갈 수 있는 힘을 얻게 될 것이다.");
            DesertEventObject1Dialogue_kor.Add("1-그럼 행운을 빌어주마");
            DesertEventObject1Dialogue_kor.Add("1-이걸 가져가렴 (HoitStone +1)");

            // Object1 eng
            DesertEventObject1Dialogue_eng.Add("1-It’s good to see you. Here are many mysterious riddles.");
            DesertEventObject1Dialogue_eng.Add("1-If you digging deeper and deeper you can get more anything you want.");
            DesertEventObject1Dialogue_eng.Add("1-Legendary minerals exist at various ends.");
            DesertEventObject1Dialogue_eng.Add("1-If you keep going down and meet all the Egyptian gods, you will have the power to go to a new place.");
            DesertEventObject1Dialogue_eng.Add("1-Then, I’ll wish you luck.");
            DesertEventObject1Dialogue_eng.Add("1-Take this. (HoitStone +1)");


            // Object2 kor
            DesertEventObject2Dialogue_kor.Add("1-.......");
            DesertEventObject2Dialogue_kor.Add("0-이게 신인가??");
            DesertEventObject2Dialogue_kor.Add("1-(1시간마다 자동판매 포션(소) 1개 획득 가능)");
            // DesertEventObject2Dialogue_kor.Add("3-22시 33분 후 자동판매 포션(소) 1개 획득 가능");

            // Object2 eng
            DesertEventObject2Dialogue_eng.Add("1-........");
            DesertEventObject2Dialogue_eng.Add("0-Was it God?");
            DesertEventObject2Dialogue_eng.Add("1-You can get two Automatic-sale potion(small) per an hour.");


            // Object3 kor
            DesertEventObject3Dialogue_kor.Add("1-멈춰라 대머리!!");
            DesertEventObject3Dialogue_kor.Add("1-여길 더 지나고 싶으면 통행료를 내놓으시지 (10 A)");
            DesertEventObject3Dialogue_kor.Add("1-안 그럼 죽음뿐이다");
            DesertEventObject3Dialogue_kor.Add("0-여...기... 있습니다....");
            DesertEventObject3Dialogue_kor.Add("1-오 좋았어 이젠 우리는 형제다!");
            DesertEventObject3Dialogue_kor.Add("1-좀 더 내려가면 네가 가지고 있는 광물을 비싸게 팔아주는 일당이 있다.");
            DesertEventObject3Dialogue_kor.Add("1-가서 만나 보라구 도움이 될거야");
            DesertEventObject3Dialogue_kor.Add("0-네 알겠습니다!!");
            DesertEventObject3Dialogue_kor.Add("1-우린 이제 형제니깐 1시간마다 찾아오면 약탈한 블랙 코인을 나눠 주지!");
            DesertEventObject3Dialogue_kor.Add("1-이건 선물이야 고맙다 외계인 친구 (올랜덤 5장 카드)");

            // Object3 eng
            DesertEventObject3Dialogue_eng.Add("1-Stop there!! Bald!");
            DesertEventObject3Dialogue_eng.Add("1-If you want to pass through here, pay the toll fee");
            DesertEventObject3Dialogue_eng.Add("1-If not, you will die!!");
            DesertEventObject3Dialogue_eng.Add("0-Here…you…are…");
            DesertEventObject3Dialogue_eng.Add("1-Oh, good. Now, we’re brothers!");
            DesertEventObject3Dialogue_eng.Add("1-If you go down further, there’s a group that sells your minerals at a high price.");
            DesertEventObject3Dialogue_eng.Add("1-Go and meet them. They will be helpful.");
            DesertEventObject3Dialogue_eng.Add("0-Okay, I got it.");
            DesertEventObject3Dialogue_eng.Add("1-We are now brothers, and when we come back every hour, we'll hand out the plundered black coin!");
            DesertEventObject3Dialogue_eng.Add("1-Thanks you. This is for your my dear alien friends. (5pcs all random card)");

            // Object4 kor
            DesertEventObject4Dialogue_kor.Add("1-.......");
            DesertEventObject4Dialogue_kor.Add("0-뭐야 아무일도 안 일어나네");
            DesertEventObject4Dialogue_kor.Add("1-(1시간마다 드릴 포션(소) 1개 획득 가능)");
            // DesertEventObject4Dialogue_kor.Add("3-22시 33분 후 드릴 포션 (소) 1개 획득 가능");

            // Object4 eng
            DesertEventObject4Dialogue_eng.Add("1-.......");
            DesertEventObject4Dialogue_eng.Add("0-Umm.. nothing happens.");
            DesertEventObject4Dialogue_eng.Add("1-You can get one Drill potion(small) every an hour.");

            // Object5 kor
            DesertEventObject5Dialogue_kor.Add("1-어이구 안녕하십니까~");
            DesertEventObject5Dialogue_kor.Add("1-이거 캐서 얼마에 파시나?");
            DesertEventObject5Dialogue_kor.Add("1-우리한테 맡겨주면 2배로 늘려서 팔아 줄게 어때? 같이 일해볼래?");
            DesertEventObject5Dialogue_kor.Add("0-네 어떻게 하면되죠?");
            DesertEventObject5Dialogue_kor.Add("1-1시간마다 우리를 찾아오면 판매증가 포션(소) 1개를 줄게 돈많이 벌자구");
            DesertEventObject5Dialogue_kor.Add("0-아하! 감사합니다");
            DesertEventObject5Dialogue_kor.Add("1-어어? 더 밑으로 갈 생각이면 조심하는 게 좋을 거야 230km에 이상한 사람이 있거든");
            DesertEventObject5Dialogue_kor.Add("1-이건 선물이다~ (1 D)");

            // Object5 eng
            DesertEventObject5Dialogue_eng.Add("1-Oh, hi there");
            DesertEventObject5Dialogue_eng.Add("1-How much do you get for this digging?");
            DesertEventObject5Dialogue_eng.Add("1-If you give it to us, we will make the double and sell it, how about it? Do You want to work with us?");
            DesertEventObject5Dialogue_eng.Add("0-Absolutely. What should I do?");
            DesertEventObject5Dialogue_eng.Add("1-If you come to us every hour, I will give you one sales potion(small). We all make a lot of money together.");
            DesertEventObject5Dialogue_eng.Add("0-Ah! Thanks a lot!");
            DesertEventObject5Dialogue_eng.Add("1-Uhh? If you’re thinking of going further down, you’d better be careful. There’s a strange man at 230Km.");
            DesertEventObject5Dialogue_eng.Add("1-This is a present. (1 D)");

            // Object6 kor
            DesertEventObject6Dialogue_kor.Add("1-여기까지 용케 왔구나 여행자여");
            DesertEventObject6Dialogue_kor.Add("1-당신의 소원대로 눈 덮인 산으로 보내주마!!");
            DesertEventObject6Dialogue_kor.Add("0-무슨 소리야?? 난 그런 소원 말한 적 없는데?!!?");
            // DesertEventObject6Dialogue_kor.Add("3-22시 33분 후 판매증가 포션 (소) 1개 획득 가능");

            // Object6 eng
            DesertEventObject6Dialogue_eng.Add("1-You managed to get here. Traveler.");
            DesertEventObject6Dialogue_eng.Add("1-As you wish. I’ll send you to the snow-covered mountain");
            DesertEventObject6Dialogue_eng.Add("0-I’ve never said that?!?!");

            // Object7 kor
            DesertEventObject7Dialogue_kor.Add("1-다시 만나서 반갑다.");
            DesertEventObject7Dialogue_kor.Add("1-내가 돌아온다고 했지!");
            DesertEventObject7Dialogue_kor.Add("1-이곳이라면 너가 꼭 올 거라고 생각했거든");
            DesertEventObject7Dialogue_kor.Add("1-예전에 받은 도움을 보상 주러 왔다.");
            DesertEventObject7Dialogue_kor.Add("1-조금만 더 내려가면 미이라 한 마리 있더군 너에게 도움을 줄지도 몰라");
            DesertEventObject7Dialogue_kor.Add("1-나는 아직 지구를 못 구해서 다시 미래로 가야 해!!! 그러니깐….");
            DesertEventObject7Dialogue_kor.Add("1-차비 좀 줘 (10 A)");
            DesertEventObject7Dialogue_kor.Add("0-돈 좀 가지고 다녀라 올 때는 어떻게 오는 거야 이놈은");
            DesertEventObject7Dialogue_kor.Add("1-어이쿠 매번 고마워~ 또 보자구");
            DesertEventObject7Dialogue_kor.Add("1-아참 내가 이걸 챙겨왔어 (A-SS 카드 1장)");

            // Object7 eng
            DesertEventObject7Dialogue_eng.Add("1-It’s good to see you again!");
            DesertEventObject7Dialogue_eng.Add("1-I told you I would be back.");
            DesertEventObject7Dialogue_eng.Add("1-I thought you’d come here.");
            DesertEventObject7Dialogue_eng.Add("1-I’m here to make up for the help I received in the past.");
            DesertEventObject7Dialogue_eng.Add("1-When I went a little further down, there was a mummy. It might help you.");
            DesertEventObject7Dialogue_eng.Add("1-I can’t save the Earth yet, so I have to go back to the future!! So....");
            DesertEventObject7Dialogue_eng.Add("1-Please, give me the fare....");
            DesertEventObject7Dialogue_eng.Add("0-Take some money with you!! How did you get here? This guy.. ");
            DesertEventObject7Dialogue_eng.Add("1-Oops, thank you every time. See you again!");
            DesertEventObject7Dialogue_eng.Add("1-Oh, by the way, I brought this with me. (A-SS Card for one miner.)");

            // Object8 kor
            DesertEventObject8Dialogue_kor.Add("1-크아아아아");
            DesertEventObject8Dialogue_kor.Add("0-말할줄 모르니?");
            DesertEventObject8Dialogue_kor.Add("1-쿠오오아아아아");
            DesertEventObject8Dialogue_kor.Add("0-말을 못하는군");
            DesertEventObject8Dialogue_kor.Add("1-아오 너무 오랜만에 누눈가를 만나서 그동안 말을 안 했더니 잘 안 나오는군");
            DesertEventObject8Dialogue_kor.Add("1-심심했는데 와줘서 고마워 대머리 친구");
            DesertEventObject8Dialogue_kor.Add("1-280km에 가면 스핑크스님이 계신다고 가서 보상을 받어");
            DesertEventObject8Dialogue_kor.Add("0-스핑크스는 30km에 있었는데?");
            DesertEventObject8Dialogue_kor.Add("1-무슨 소리야 280km에 계셔!!");
            DesertEventObject8Dialogue_kor.Add("0-읭? 알겠어 아무튼");
            DesertEventObject8Dialogue_kor.Add("1-내려가는 길에 이거 받아가 (올랜덤 광부팩 5장)");

            // Object8 eng
            DesertEventObject8Dialogue_eng.Add("1-KkKkekkekekkkekeahahahhaa");
            DesertEventObject8Dialogue_eng.Add("0-you can not speak???");
            DesertEventObject8Dialogue_eng.Add("1-Kuoooahah??");
            DesertEventObject8Dialogue_eng.Add("0-It seems that you’re not able to talk at all.");
            DesertEventObject8Dialogue_eng.Add("1-Oh, I haven’t spoken to someone in so long, so it doesn’t come out very well.");
            DesertEventObject8Dialogue_eng.Add("1-I’ve been bored. Thanks for coming. A bald friends");
            DesertEventObject8Dialogue_eng.Add("1-When you get at 280km, there would be Sphinx. Go and get compensation.");
            DesertEventObject8Dialogue_eng.Add("0-That Sphinx was at 30 km.");
            DesertEventObject8Dialogue_eng.Add("1-What are you talking about? He is at 280 km!");
            DesertEventObject8Dialogue_eng.Add("0-What? Okay… anyway.");
            DesertEventObject8Dialogue_eng.Add("1-Take this on your way down.(5 All Random Miner Packs)");

            // Object9 kor
            DesertEventObject9Dialogue_kor.Add("1-결국 여기까지 왔구나");
            DesertEventObject9Dialogue_kor.Add("1-대단하군 여행자여");
            DesertEventObject9Dialogue_kor.Add("1-너에게 큰 보상을 내리겠다.");
            DesertEventObject9Dialogue_kor.Add("1-나는 이 사막을 지키는 스핑크스다!!!!");
            DesertEventObject9Dialogue_kor.Add("1-(A-SS 등급 5장) 가져가라!!!!");

            // Object9 eng
            DesertEventObject9Dialogue_eng.Add("1-You’re here after all.");
            DesertEventObject9Dialogue_eng.Add("1-Good job, Traveler.");
            DesertEventObject9Dialogue_eng.Add("1-I’ll make a big reward for you.");
            DesertEventObject9Dialogue_eng.Add("1-I am Sphinx that protects this desert!!!!");
            DesertEventObject9Dialogue_eng.Add("1-Take this! (5 A-SS Class cards)");
        }
        ///// IceMap Object
        {
            // Object1 kor
            IceEventObject1Dialogue_kor.Add("1-캬~~ 콜라 너무 맛있당!!");
            IceEventObject1Dialogue_kor.Add("1-넌 뭐 하는 대머리니? 핑크 핑크 하네");
            IceEventObject1Dialogue_kor.Add("0-땅파서 돈번다 곰탱아");
            IceEventObject1Dialogue_kor.Add("1-오호 그럼 콜라 좀 더 사 먹게 돈 좀 주지 않을래? (1 B)");
            IceEventObject1Dialogue_kor.Add("0-돈 달라는 놈들 아니 동물들이 아니 기계 아니 아니 그게 왜 이렇게 거지들이 많아 (1 B) 가져가라");
            IceEventObject1Dialogue_kor.Add("1-60km에 가면 뭔가 곤란에 처한 사람이 있더라고 가서 확인해봐");
            IceEventObject1Dialogue_kor.Add("1-돈은 고마워~ 이건 선물이야 (짱짱포션 (대))");

            // Object1 eng
            IceEventObject1Dialogue_eng.Add("1-OMG, This coke is awesome!");
            IceEventObject1Dialogue_eng.Add("1-What kind of person are you? Bald!! You look pink!");
            IceEventObject1Dialogue_eng.Add("0-I make money by digging dumm ass");
            IceEventObject1Dialogue_eng.Add("1-Oh, then would you like to pay for some more coke? ");
            IceEventObject1Dialogue_eng.Add("0-Why are there so many people, oh,, animals, oh no,, machines, no..beggars asking for money? Take this.");
            IceEventObject1Dialogue_eng.Add("1-There’s someone in trouble at 60 km. Go check it out.");
            IceEventObject1Dialogue_eng.Add("1-Thank you for the money. This is a gift. (Super Buff Potion.(Large))");

            // Object2 kor
            IceEventObject2Dialogue_kor.Add("1-큰일났다 큰일났어");
            IceEventObject2Dialogue_kor.Add("0-뭔일인데?");
            IceEventObject2Dialogue_kor.Add("1-나 빨리 가야 되는데 고장 나버렸어");
            IceEventObject2Dialogue_kor.Add("0-어딜가야되는데?");
            IceEventObject2Dialogue_kor.Add("1-몰라도돼 호잇스톤만 있으면 고칠 수 있을 텐데");
            IceEventObject2Dialogue_kor.Add("1-호잇스톤 (1 개) 줄수 있겠어?");
            IceEventObject2Dialogue_kor.Add("0-여기 있어");
            IceEventObject2Dialogue_kor.Add("1-역시 호잇 스톤이야 고맙다 핑크 대머리 친구!");
            IceEventObject2Dialogue_kor.Add("1-40km 더 내려가면 아이스크림 파는 펭귄 있으니깐");
            IceEventObject2Dialogue_kor.Add("1-가서 아이스크림이라도 먹어 (1 C) 줄게");
            IceEventObject2Dialogue_kor.Add("1-이건 호잇스톤에 보답이야 (올 랜덤 카드 10장)");
            IceEventObject2Dialogue_kor.Add("1-나를 1시간마다 찾아오면 드릴포션(소)를 1개씩 줄게");
            //IceEventObject2Dialogue_kor.Add("3-22시 33분 있다가 다시오면 드릴포션 (소) 1개를 줄게");

            // Object2 eng
            IceEventObject2Dialogue_eng.Add("1-OMG, I am in big trouble!");
            IceEventObject2Dialogue_eng.Add("0-What’s going on?");
            IceEventObject2Dialogue_eng.Add("1-I’m late but it’s broken….");
            IceEventObject2Dialogue_eng.Add("0-Where should you go?");
            IceEventObject2Dialogue_eng.Add("1-You don’t need to know it. If I have a Hoit Stone, I’ll be able to fix it.");
            IceEventObject2Dialogue_eng.Add("1-Can you give me Hoit Stones?");
            IceEventObject2Dialogue_eng.Add("0-Okay, here you are.");
            IceEventObject2Dialogue_eng.Add("1-How awesome Hoit stone is! Thank you, Pink bald.");
            IceEventObject2Dialogue_eng.Add("1-There is a penguin that sells ice cream, if you did 40 km more.");
            IceEventObject2Dialogue_eng.Add("1-Go and Eat some ice cream. I’ll give you");
            IceEventObject2Dialogue_eng.Add("1-This is a reward for the Hoit Stone. (10 All Random Cards)");
            IceEventObject2Dialogue_eng.Add("1-If you come to me every an hour, I’ll give you one Drill Potion(small)");

            // Object3 kor
            IceEventObject3Dialogue_kor.Add("1-휴우우우");
            IceEventObject3Dialogue_kor.Add("0-왜 한숨이야 펭귄아?");
            IceEventObject3Dialogue_kor.Add("1-장사가 잘 안돼서");
            IceEventObject3Dialogue_kor.Add("1-대출받아서 아이스크림 냉장고도 샀는데 휴");
            IceEventObject3Dialogue_kor.Add("1-왜 이렇게 안 팔리는 거야 내 아이스크림 엄청 맛있는데…");
            IceEventObject3Dialogue_kor.Add("0-야이 멍청아 이렇게 추운데 잘도 팔리겠다");
            IceEventObject3Dialogue_kor.Add("1-뭐?? 그럼 어디서 팔아야 되는데??");
            IceEventObject3Dialogue_kor.Add("0-내가 엄청 더운데 알아 알려 줄 테니깐 거기 가서 장사해봐");
            IceEventObject3Dialogue_kor.Add("1-오 고맙다구 핑크대머리 친구~ 언제든 놀러 와 내가 공짜로 줄테니깐!");
            IceEventObject3Dialogue_kor.Add("1-1시간마다 나를 찾아와 !! 자동판매 포션(소) 1개씩 줄 테니깐!!");
            //IceEventObject3Dialogue_kor.Add("3-장사가 잘되~ 22시 33분 있다가 다시와~ 자동판매 포션(소) (소) 1개를 줄게");


            // Object3 eng
            IceEventObject3Dialogue_eng.Add("1-Hoo...");
            IceEventObject3Dialogue_eng.Add("0-Why are you signing, penguin?");
            IceEventObject3Dialogue_eng.Add("1-My business is not very well...");
            IceEventObject3Dialogue_eng.Add("1-I got a loan and bought an ice cream refrigerator, Phew..");
            IceEventObject3Dialogue_eng.Add("1-No, idea  Mine is the best. ");
            IceEventObject3Dialogue_eng.Add("0-Hey dumb!  It’s not a good place for your business, it too cold.");
            IceEventObject3Dialogue_eng.Add("1-Sorry?  where is the best places to sell my ice cream?");
            IceEventObject3Dialogue_eng.Add("0-I know the right place where it is so hot. I’ll let you know so you go and do business there.");
            IceEventObject3Dialogue_eng.Add("1-Oh thank you for the visit me,  my Pink bald head friend. And I’m Here always free for you.");
            IceEventObject3Dialogue_eng.Add("1-Visit me every an hour. I’ll give the one Small Auto-Sale Potion for every an hour.");

            // Object4 kor
            IceEventObject4Dialogue_kor.Add("1-.......?? 나를 찾아 주다니 정말 고맙다.......");
            IceEventObject4Dialogue_kor.Add("0-어? 나랑 같은 외계인!");
            IceEventObject4Dialogue_kor.Add("1-아니?!! 너는 후대 구나");
            IceEventObject4Dialogue_kor.Add("0-조상 대대로 우리는 대머리였구나… 프로페시아도 소용없어ㅠㅠ");
            IceEventObject4Dialogue_kor.Add("1-나는 틀렸 단다 이것을 줄 테니 꼭 으으윽......");
            IceEventObject4Dialogue_kor.Add("1-얼음여왕을 찾도록 하거라 너가 원하는 것을 알려 줄꺼야");
            IceEventObject4Dialogue_kor.Add("1-으으으윽….. 죽음 ");
            IceEventObject4Dialogue_kor.Add("1-(A-SS 1장) - 1시간마다 호잇스톤 1개씩 생성");
            //IceEventObject4Dialogue_kor.Add("3-22시 33분 후 호잇스톤 1개 획득가능");

            // Object4 eng
            IceEventObject4Dialogue_eng.Add("1-........? Thank you for the visiting me");
            IceEventObject4Dialogue_eng.Add("0-UH? Are you alien? Same as me?");
            IceEventObject4Dialogue_eng.Add("1-You are my descendants.");
            IceEventObject4Dialogue_eng.Add("0-I’am born to be bald, propecia is no work for me.");
            IceEventObject4Dialogue_eng.Add("1-I will die soon. hoo....");
            IceEventObject4Dialogue_eng.Add("1-Find The queen of ice, she will help you.");
            IceEventObject4Dialogue_eng.Add("1-(Death...)");
            IceEventObject4Dialogue_eng.Add("1-(one A-SS class card");

            // Object5 kor
            IceEventObject5Dialogue_kor.Add("1-어서오게나 낯선이여....");
            IceEventObject5Dialogue_kor.Add("1-나는 얼음여왕");
            IceEventObject5Dialogue_kor.Add("1-어쩐 일로 나를 찾아왔는가");
            IceEventObject5Dialogue_kor.Add("0-전설의 광물을 모으고 있어요!");
            IceEventObject5Dialogue_kor.Add("1-그렇다면 정글도 가보는 것이 좋겠구나");
            IceEventObject5Dialogue_kor.Add("1-내가 정글로 갈 수 있게 해주마");
            IceEventObject5Dialogue_kor.Add("1-나에게 찾아 온다면 매일 골드를 내려 도와주도록 해주마");
            IceEventObject5Dialogue_kor.Add("1-그리고 밑에 어린아이가 울고 있으니 내려가서 도와주도록 하거라");

            // Object5 eng
            IceEventObject5Dialogue_eng.Add("1-Hello stranger");
            IceEventObject5Dialogue_eng.Add("1-I’m the queen of ice ");
            IceEventObject5Dialogue_eng.Add("1-What do you want for me?");
            IceEventObject5Dialogue_eng.Add("0-I’m colleting the legendary Mineral");
            IceEventObject5Dialogue_eng.Add("1-oh... visit the jungle, it will be good for you.");
            IceEventObject5Dialogue_eng.Add("1-I will help you to reach at the Jungle ");
            IceEventObject5Dialogue_eng.Add("1-If you visit me every day, I will give the gold and help you.");
            IceEventObject5Dialogue_eng.Add("1-Go down there, you have to help the child who crying.");

            // Object6 kor
            IceEventObject6Dialogue_kor.Add("1-흐아아아아앙");
            IceEventObject6Dialogue_kor.Add("1-엄마 엄마 어디갔어 흐어어어엉");
            IceEventObject6Dialogue_kor.Add("0-꼬마 털복숭이야 무슨일이야?");
            IceEventObject6Dialogue_kor.Add("1-엄마가 없어졌어 대머리아저씨 흐어어어엉");
            IceEventObject6Dialogue_kor.Add("0-그래? 내가 찾아줄게 그만울어");
            IceEventObject6Dialogue_kor.Add("1-고마워요 대머리 아저씨 훌쩍. 대신 조심하세요 엄마한테 찢길 수도 있으니깐");

            // Object6 eng
            IceEventObject6Dialogue_eng.Add("1-boohoo boohoo boohoo");
            IceEventObject6Dialogue_eng.Add("1-Where is mommy?");
            IceEventObject6Dialogue_eng.Add("0-Hey little peach what are you doing?");
            IceEventObject6Dialogue_eng.Add("1-My mom is disappear,,,,, bold uncle.");
            IceEventObject6Dialogue_eng.Add("0-Really? Stop crying I will help you.");
            IceEventObject6Dialogue_eng.Add("1-Thank you my bold. But be careful, she will tear up");


            // Object7 kor
            IceEventObject7Dialogue_kor.Add("1-I’m Back!");
            IceEventObject7Dialogue_kor.Add("1-차비 값 으러 왔다!");
            IceEventObject7Dialogue_kor.Add("1-덕분에 지구를 구할 수 있었어 넌 지구의 영웅 이야");
            IceEventObject7Dialogue_kor.Add("0-뭐? 이정도로?");
            IceEventObject7Dialogue_kor.Add("1-그럼 당연하지 너가 차비를 빌려주지 않았으면 지구는.........");
            IceEventObject7Dialogue_kor.Add("1-으으으 생각만해도 끔찍해");
            IceEventObject7Dialogue_kor.Add("0-아아 그래");
            IceEventObject7Dialogue_kor.Add("1-자 이제 지구는 걱정말고 너의 여행을 떠나라 영웅이여!");
            IceEventObject7Dialogue_kor.Add("0-지구야 어떻게 되든 말든 내 고향 별도 아닌데 뭘");
            IceEventObject7Dialogue_kor.Add("1-이걸 받아가라 영웅이여!! (A-SS 1장)");

            // Object7 eng
            IceEventObject7Dialogue_eng.Add("1-I’m Back!");
            IceEventObject7Dialogue_eng.Add("1-Hey, I’m here get my money back!");
            IceEventObject7Dialogue_eng.Add("1-Because of you we can save the Earth, you are hero.");
            IceEventObject7Dialogue_eng.Add("0-Never mind");
            IceEventObject7Dialogue_eng.Add("1-If you didn’t lend the money, ...I really don’t want to think about it.");
            IceEventObject7Dialogue_eng.Add("1-oh.... that's terrible");
            IceEventObject7Dialogue_eng.Add("0-(SMH) Okay....");
            IceEventObject7Dialogue_eng.Add("1-Now, don’t worry about the Earth, let go your own trip my hero!");
            IceEventObject7Dialogue_eng.Add("0-I don’t care the Earth, no matter what not my home town.");
            IceEventObject7Dialogue_eng.Add("1-Take this my hero.");
        }
        /////// ForestMap Object
        {
            // Object1 kor
            ForestEventObject1Dialogue_kor.Add("1-깜짝이야 이놈의 앵무새 팔아버리던가 해야지");
            ForestEventObject1Dialogue_kor.Add("1-엉? 넌 뭐야 핑크괴물놈아");
            ForestEventObject1Dialogue_kor.Add("0-뭐야 손이랑 발이 없는 아이네?");
            ForestEventObject1Dialogue_kor.Add("1-그렇다! 해적질좀 하다 보니 다 잘려 나가더군");
            ForestEventObject1Dialogue_kor.Add("1-그래서 전설의 광물을 찾고 있지");
            ForestEventObject1Dialogue_kor.Add("1-소문에 의하면 전설의 광물을 얻으면 뭐든 할 수 있다고 하더군");
            ForestEventObject1Dialogue_kor.Add("0-나도 전설의 광물을 찾는중인데");
            ForestEventObject1Dialogue_kor.Add("1-오오 그렇다면 나와 거래를 하지 않겠어?");
            ForestEventObject1Dialogue_kor.Add("1-내가 매일 너의 동료 중 한 명을 공짜로 레벨업을 시켜주지!");
            ForestEventObject1Dialogue_kor.Add("1-대신 전설의 광물을 찾으면 나와 나눠 갖는 거야");
            ForestEventObject1Dialogue_kor.Add("0-오~! 좋은데? 좋아 거래 하자(전설의 광물을 찾으면 나 혼자 갖고 도망가면 되니깐 일단 좋다고 하자");
            ForestEventObject1Dialogue_kor.Add("1-다 들려 임마");
            ForestEventObject1Dialogue_kor.Add("0-거래하자;;;;");
            ForestEventObject1Dialogue_kor.Add("1-밑에 내려가면 캠핑하고 있는 사람이 있더군 가서 뭐라도 든든히 얻어먹고");
            ForestEventObject1Dialogue_kor.Add("1-전설의 광물을 꼭!! 찾도록 해!!");
            ForestEventObject1Dialogue_kor.Add("1-그리고!! 광부 무료 레벨업은 하루에 한번뿐이야!!");
            //ForestEventObject1Dialogue_kor.Add("3-22시 33분 후 업그레이드가 가능하다!!");

            // Object1 eng
            ForestEventObject1Dialogue_eng.Add("1-OMG! I have to sell the this a parrot");
            ForestEventObject1Dialogue_eng.Add("1-What? What a pink monster");
            ForestEventObject1Dialogue_eng.Add("0-What that , you don’t have a hand and feet.");
            ForestEventObject1Dialogue_eng.Add("1-Yes, I’m a pirate that’s why I don’t have a hand and feet");
            ForestEventObject1Dialogue_eng.Add("1-So, I’m looking the legendary Mineral");
            ForestEventObject1Dialogue_eng.Add("1-According to rumors if you got the legendary Mineral, I can do anything what I want it. ");
            ForestEventObject1Dialogue_eng.Add("0-Oh me too, I’m looking for the legendary Mineral");
            ForestEventObject1Dialogue_eng.Add("1-Oh, if you are why don’t you deal with me?");
            ForestEventObject1Dialogue_eng.Add("1-Every day, I will free to level up one of your colleague");
            ForestEventObject1Dialogue_eng.Add("1-Then, we will share it, if you find the legendary Mineral");
            ForestEventObject1Dialogue_eng.Add("0-Oh sounds good. Let do it, (but if you find the legendary Mineral, I will run myself) ");
            ForestEventObject1Dialogue_eng.Add("1-hey I can hear you all.");
            ForestEventObject1Dialogue_eng.Add("0-um.. mm... sorry haha. let's do it");
            ForestEventObject1Dialogue_eng.Add("1-If you go down there you can see the people who camping there, eat well,");
            ForestEventObject1Dialogue_eng.Add("1-You must find the legendary Mineral, do your best");
            ForestEventObject1Dialogue_eng.Add("1-And you have only one chance for the free level up ");

            // Object2 kor
            ForestEventObject2Dialogue_kor.Add("1-냠냠냠냠");
            ForestEventObject2Dialogue_kor.Add("1-냠냠냠냠냠");
            ForestEventObject2Dialogue_kor.Add("1-냠냠냠냠냠냠냠");
            ForestEventObject2Dialogue_kor.Add("0-야 누가 왔으면 그만 먹고 쳐다 보기라도 해라!");
            ForestEventObject2Dialogue_kor.Add("1-안녕? 냠냠 여기 와서 앉아 같이 먹자 냠냠");
            ForestEventObject2Dialogue_kor.Add("0-그럴까? 냠냠냠");
            ForestEventObject2Dialogue_kor.Add("1-이 동네는 위험 하니깐 조심해야해 계속 내려가다 보면 식인종들도 있다구 냠냠냠");
            ForestEventObject2Dialogue_kor.Add("0-나는 사람이 아니여서 안 잡아 먹을 거 같은데 냠냠");
            ForestEventObject2Dialogue_kor.Add("1-아무튼 더 갈 생각이면 조심 하라구");
            ForestEventObject2Dialogue_kor.Add("0-고맙다냠냠");
            ForestEventObject2Dialogue_kor.Add("1-1시간마다 나한테 들리면 내가 드릴버프 1개씩 줄게~");
            ForestEventObject2Dialogue_kor.Add("0-웅 고맙다냠냠!");
            //ForestEventObject2Dialogue_kor.Add("3-냠냠냠 요리중이다 냠냠... 22시 33분 후 드릴버프 (대) 1개 줄게");

            // Object2 eng
            ForestEventObject2Dialogue_eng.Add("1-yummy");
            ForestEventObject2Dialogue_eng.Add("1-yummy yummy");
            ForestEventObject2Dialogue_eng.Add("1-yummy yummy yummy");
            ForestEventObject2Dialogue_eng.Add("0-Hey stop eating! If someone here you have to look around");
            ForestEventObject2Dialogue_eng.Add("1-Hello come over there take it seat, let eat together");
            ForestEventObject2Dialogue_eng.Add("0-Okay! yummy");
            ForestEventObject2Dialogue_eng.Add("1-But this is dangerous town if you down, there are cannibal so please be careful");
            ForestEventObject2Dialogue_eng.Add("0-I think, they don’t take me, because I’m not a humanbing ");
            ForestEventObject2Dialogue_eng.Add("1-Anyway if you want to go down there, be careful");
            ForestEventObject2Dialogue_eng.Add("0-Thank you yummy");
            ForestEventObject2Dialogue_eng.Add("1-If you visit me every an hour, I will give Drill Buff one for an hour.");
            ForestEventObject2Dialogue_eng.Add("0-Thank you yummy!");


            // Object3 kor
            ForestEventObject3Dialogue_kor.Add("1-흐어어어어어어엉");
            ForestEventObject3Dialogue_kor.Add("1-흐아아아아앙");
            ForestEventObject3Dialogue_kor.Add("0-이놈의 지구는 어디 갈 때마다 꼭 우는 애들이 있네");
            ForestEventObject3Dialogue_kor.Add("1-흐엉흐엉");
            ForestEventObject3Dialogue_kor.Add("0-자자 얘들아 울지마봐 무슨일이야?");
            ForestEventObject3Dialogue_kor.Add("1-우리 신님에게 기도하고 있으니깐 방해 하지마 흐어어엉");
            ForestEventObject3Dialogue_kor.Add("0-내가 도와줄테니깐 무슨일인데 그래?");
            ForestEventObject3Dialogue_kor.Add("1-너가? (되게 약해 보이는데 속닥속닥)");
            ForestEventObject3Dialogue_kor.Add("0-다 들린다 죽고싶냐");
            ForestEventObject3Dialogue_kor.Add("1-아니아니 미안.. 사실 우리 친구가 식인종한테 잡혀가서 제발 살아 돌아 와달라고 기도 중이였어");
            ForestEventObject3Dialogue_kor.Add("1-130km에 가면 그 무시무시한 식인종이 있을거야");
            ForestEventObject3Dialogue_kor.Add("1-이걸 보상으로 줄 테니 친구좀 구해줘 흐어어엉 (올랜덤 광부 10장)");
            ForestEventObject3Dialogue_kor.Add("0-알겠어 그만 울고 나만 믿으라구");

            // Object3 eng
            ForestEventObject3Dialogue_eng.Add("1-Boohoo.. Boohoo.. Boohoo..");
            ForestEventObject3Dialogue_eng.Add("1-Boohoo.. Boohoo..");
            ForestEventObject3Dialogue_eng.Add("0-Here in the Earth, child are crying everywhere");
            ForestEventObject3Dialogue_eng.Add("1-Boohoo.. Boohoo..");
            ForestEventObject3Dialogue_eng.Add("0-Hey folks, stop crying what’s going on?");
            ForestEventObject3Dialogue_eng.Add("1-We are pray for the god, so please don’t interrupt me");
            ForestEventObject3Dialogue_eng.Add("0-I will help you, what’s going on?");
            ForestEventObject3Dialogue_eng.Add("1-Are you? (whisper : looks so weak)");
            ForestEventObject3Dialogue_eng.Add("0-I can hear you, you want to die?");
            ForestEventObject3Dialogue_eng.Add("1-Nope sorry, actually I pray for my friends who take the ");
            ForestEventObject3Dialogue_eng.Add("1-If you into the 130km, you can see the horrible cannibal");
            ForestEventObject3Dialogue_eng.Add("1-Hey this is for your reward, please help my friends");
            ForestEventObject3Dialogue_eng.Add("0-Okay, stop crying and trust me");

            // Object4 kor
            ForestEventObject4Dialogue_kor.Add("1-호로로로로! 히야! 핫! 헛! 후후후!");
            ForestEventObject4Dialogue_kor.Add("1-원주민 : 흐어어어엉 제발 절 잡아먹지 말아주세요");
            ForestEventObject4Dialogue_kor.Add("1-맛있겠다 호로로로로로롤!");
            ForestEventObject4Dialogue_kor.Add("0-야야야 잠깐!");
            ForestEventObject4Dialogue_kor.Add("1-너는 뭐냐 호로로로롤 우리는 대머리는 안 먹는다 가라");
            ForestEventObject4Dialogue_kor.Add("0-(빠직) 자 아무리 그래도 같은 지구인 끼리 먹고 그러면 안되지");
            ForestEventObject4Dialogue_kor.Add("1-그럼 우린 뭘 먹고 사냐 호로로로롤!!!");
            ForestEventObject4Dialogue_kor.Add("0-내가 요즘 땅파서 돈좀 벌거든 돈 줄테니깐 가서 빵이라도 사먹어라");
            ForestEventObject4Dialogue_kor.Add("1-호로로로롤! 빵?! 빵 맛있나? 알겠다 돈 줬으니 나도 땅을 한층 파주마 호로로로롤!");
            ForestEventObject4Dialogue_kor.Add("0-의외로 착한데?");
            ForestEventObject4Dialogue_kor.Add("1-원주민 : 고맙습니다 핑크대머리 신님 흐어어어엉");
            ForestEventObject4Dialogue_kor.Add("0-야 자꾸 대머리라고 하면 없애버린다 얼른 친구들한테 돌아가라");
            ForestEventObject4Dialogue_kor.Add("1-호로로로롤! 부자 친구여 160km에 숲의 정령님이 계신다 가보거라!");

            // Object4 eng
            ForestEventObject4Dialogue_eng.Add("1-Horrorolo! Hiya!");
            ForestEventObject4Dialogue_eng.Add("1-Jungle native : please don’t eat me please...");
            ForestEventObject4Dialogue_eng.Add("1-Horrorolo! You look so yummy");
            ForestEventObject4Dialogue_eng.Add("0-Hey hey hold on");
            ForestEventObject4Dialogue_eng.Add("1-How are you? We are not eat the bold get away");
            ForestEventObject4Dialogue_eng.Add("0-Hey Earth people should not be able to eat each other!");
            ForestEventObject4Dialogue_eng.Add("1-So what can we do eat?");
            ForestEventObject4Dialogue_eng.Add("0-Now on, I got money from the digging ,so I will give the money get some bread eat.");
            ForestEventObject4Dialogue_eng.Add("1-bread is good for you? I got it, you gave the money I will digging for you.");
            ForestEventObject4Dialogue_eng.Add("0-oh you are kind than I thought");
            ForestEventObject4Dialogue_eng.Add("1-Jungle native : Thank you my dear pink bold.... my god");
            ForestEventObject4Dialogue_eng.Add("0-If I call it bald, I kill! Go back to your friends.");
            ForestEventObject4Dialogue_eng.Add("1-My rich friends, go for the 160km Master of the Forest spirit is waiting for you");


            // Object5 kor
            ForestEventObject5Dialogue_kor.Add("1-작고 귀여운 생명체여 어쩐일인가");
            ForestEventObject5Dialogue_kor.Add("0-지구에서도 날 귀엽다고 해주는 애가 있다니?");
            ForestEventObject5Dialogue_kor.Add("1-너무 작고 핑크핑크하고 귀엽구나 그래 무슨 일인가?");
            ForestEventObject5Dialogue_kor.Add("0-전설의 광물을 찾고 있어");
            ForestEventObject5Dialogue_kor.Add("1-전설의 광물이라 힘든 모험을 하고 있었구나");
            ForestEventObject5Dialogue_kor.Add("1-여기까지 왔으니 너에게 도움을 주겠다.");
            ForestEventObject5Dialogue_kor.Add("1-매일 나를 찾아온다면 원하는 맵의 땅 게이지를 50% 채워주도록 하마");
            ForestEventObject5Dialogue_kor.Add("0-와우!! 고마워요 돌덩이!!");
            ForestEventObject5Dialogue_kor.Add("1-전설의 광물은 유적지에 묻혀있다. 아주 먼 곳에 있으니 많이 힘들 수도 있다");
            ForestEventObject5Dialogue_kor.Add("0-여기까지도 왔는걸");
            ForestEventObject5Dialogue_kor.Add("1-가는 길에 좌절한 원숭이 한 마리가 있으니 도와주고 가거라");
            //ForestEventObject5Dialogue_kor.Add("3-22시 33분 후 드릴 게이지 50% 획득 가능하다!!");

            // Object5 eng
            ForestEventObject5Dialogue_eng.Add("1-Oh my cute and little a living things, what’s going on?");
            ForestEventObject5Dialogue_eng.Add("0-Wow in the earth, someone think about to me cute,");
            ForestEventObject5Dialogue_eng.Add("1-You are small and pink pink so cute, what’s going on? ");
            ForestEventObject5Dialogue_eng.Add("0-I’m looking for the legendary Mineral");
            ForestEventObject5Dialogue_eng.Add("1-legendary Mineral…. You have an hard time for the adventure");
            ForestEventObject5Dialogue_eng.Add("1-You are here, I will help you.");
            ForestEventObject5Dialogue_eng.Add("1-if you visit me every day, I will give the drill gauge 50% of the any map you have it.");
            ForestEventObject5Dialogue_eng.Add("0-Thank you!! my rock");
            ForestEventObject5Dialogue_eng.Add("1-Legendary Mineral is buried historic site, but very far from here, it could be hard to get it");
            ForestEventObject5Dialogue_eng.Add("0-But I made it.");
            ForestEventObject5Dialogue_eng.Add("1-I think you should help the monkey ,who get discouraged on the road");


            // Object6 kor
            ForestEventObject6Dialogue_kor.Add("1-우끼우끼 휴");
            ForestEventObject6Dialogue_kor.Add("0-어이 왜 한숨이야");
            ForestEventObject6Dialogue_kor.Add("1-머리도 아프고 맘대로 돌아 다닐 수도 없고");
            ForestEventObject6Dialogue_kor.Add("0-왜?");
            ForestEventObject6Dialogue_kor.Add("1-삼장법사가 머리띠를 해놓고 가서");
            ForestEventObject6Dialogue_kor.Add("1-내가 지 맘에 안드는 행동을 할 때마다 머리를 쪼여서 너무 아파");
            ForestEventObject6Dialogue_kor.Add("0-그니깐 착하게좀 살지");
            ForestEventObject6Dialogue_kor.Add("1-난 착하게 살았다구!!! 가끔씩 사고를 칠뿐이지!!");
            ForestEventObject6Dialogue_kor.Add("1-아니 그리고 머리띠만 씌어 놓고 또 어딜 간 건지 보이질 않아서 뺄 수도 없어");
            ForestEventObject6Dialogue_kor.Add("0-내가 찾아줄까?");
            ForestEventObject6Dialogue_kor.Add("1-아이고 그렇게만 해주면 난 너무 고맙다 우끼!");
            ForestEventObject6Dialogue_kor.Add("1-내가 선물을 줄 테니 이거 받고 힘내서 꼭 삼장법사새키 꺄아아아악!!! 아프다 우끼끼");
            ForestEventObject6Dialogue_kor.Add("0-말을 이쁘게 해야지");
            ForestEventObject6Dialogue_kor.Add("1-삼장법사님을 찾아줘");
            ForestEventObject6Dialogue_kor.Add("1-우끼끼 보상 (A-SS 카드 1장)");

            // Object6 eng
            ForestEventObject6Dialogue_eng.Add("1-gibber gibber sigh~");
            ForestEventObject6Dialogue_eng.Add("0-what’s wrong with you?");
            ForestEventObject6Dialogue_eng.Add("1-I have a headache and I can’t go everywhere");
            ForestEventObject6Dialogue_eng.Add("0-How come?");
            ForestEventObject6Dialogue_eng.Add("1-The Samzang Monk put on me the hair ring .");
            ForestEventObject6Dialogue_eng.Add("1-Whenever I do bad thing,  he hate doing that and hair ring is too tight for me");
            ForestEventObject6Dialogue_eng.Add("0-You should be a good boy");
            ForestEventObject6Dialogue_eng.Add("1-I was a good boy, just sometime got the Trouble!");
            ForestEventObject6Dialogue_eng.Add("1-Where are he? I can’t find him even, he put on me the hair ring.");
            ForestEventObject6Dialogue_eng.Add("0-Can I help you for the find? ");
            ForestEventObject6Dialogue_eng.Add("1-oh really? Thank you for the help. gibber");
            ForestEventObject6Dialogue_eng.Add("1-I will give you this present, please find me a fxxkingman. AAAAAAAAAAAAA!");
            ForestEventObject6Dialogue_eng.Add("0-You should watch your mouth");
            ForestEventObject6Dialogue_eng.Add("1-Please find the Samzang Monk");
            ForestEventObject6Dialogue_eng.Add("1-Here are you one A-SS card for you reward");


            // Object7 kor
            ForestEventObject7Dialogue_kor.Add("0-(여긴가?)");
            ForestEventObject7Dialogue_kor.Add("0-(이것이 전설의 광물이군)");
            ForestEventObject7Dialogue_kor.Add("0-(색깔이 아주 예뻐.. 그런데......)");
            ForestEventObject7Dialogue_kor.Add("0-뭔가 기대 했던 것 들을 막상 다 모으니 허무 하군)");
            ForestEventObject7Dialogue_kor.Add("0-(앞으로 어떻게 할까나 지구에서 더 많은 전설의 모아갈까...?)");
            ForestEventObject7Dialogue_kor.Add("0-(아니면 또 다른 별로 떠나서 새로운 광물들을 찾아볼까?)");

            // Object7 eng
            ForestEventObject7Dialogue_eng.Add("0-Here it is?");
            ForestEventObject7Dialogue_eng.Add("0-Oh, this is the legendary Mineral");
            ForestEventObject7Dialogue_eng.Add("0-Colors good but...");
            ForestEventObject7Dialogue_eng.Add("0-I Feel empty, even I got the all what I want it.");
            ForestEventObject7Dialogue_eng.Add("0-What should I do for the next.... should I get more the legendary Mineral?");
            ForestEventObject7Dialogue_eng.Add("0-Or why don’t we move to other stars? Look for the Mineral");

        }


        MineralsName_kor.Add("석탄");
        MineralsName_kor.Add("구리");
        MineralsName_kor.Add("철");
        MineralsName_kor.Add("은");
        MineralsName_kor.Add("금");
        MineralsName_kor.Add("아연");
        MineralsName_kor.Add("석류석");
        MineralsName_kor.Add("자수정");
        MineralsName_kor.Add("토파즈");
        MineralsName_kor.Add("에메랄드");
        MineralsName_kor.Add("사파이어");
        MineralsName_kor.Add("루비");
        MineralsName_kor.Add("다이아몬드");
        MineralsName_kor.Add("월장석");
        MineralsName_kor.Add("일장석");
        MineralsName_kor.Add("크리스탈");
        MineralsName_kor.Add("흑요석");
        MineralsName_kor.Add("단백석");

        MineralsName_kor.Add("사막거북스톤");
        MineralsName_kor.Add("거북스톤");
        MineralsName_kor.Add("스테이크 스톤");
        MineralsName_kor.Add("진한초록 수정");
        MineralsName_kor.Add("삼각토양 보석");
        MineralsName_kor.Add("슈퍼 딥 다이아");
        MineralsName_kor.Add("모래 수정");
        MineralsName_kor.Add("녹주석");
        MineralsName_kor.Add("신비의 보석");
        MineralsName_kor.Add("황금 단백석");
        MineralsName_kor.Add("아쿠아마린 수정");
        MineralsName_kor.Add("에메랄드 치즈");
        MineralsName_kor.Add("포도석");
        MineralsName_kor.Add("핑크 광물");
        MineralsName_kor.Add("푸른주사위 스톤");
        MineralsName_kor.Add("밝은 초록수정");
        MineralsName_kor.Add("밤의 감귤복숭아석");
        MineralsName_kor.Add("자주보석");
        MineralsName_kor.Add("심장석");
        MineralsName_kor.Add("알려지지않은 별 석");



        MineralsName_eng.Add("Coal");
        MineralsName_eng.Add("Copper");
        MineralsName_eng.Add("Iron");
        MineralsName_eng.Add("Silver");
        MineralsName_eng.Add("Gold");
        MineralsName_eng.Add("Zinc");
        MineralsName_eng.Add("Garnet");
        MineralsName_eng.Add("Amethyst");
        MineralsName_eng.Add("Topaz");
        MineralsName_eng.Add("Emerald");
        MineralsName_eng.Add("Sapphire");
        MineralsName_eng.Add("Ruby");
        MineralsName_eng.Add("Diamond");
        MineralsName_eng.Add("Moonstone");
        MineralsName_eng.Add("Sunstone");
        MineralsName_eng.Add("Crystal");
        MineralsName_eng.Add("Obsidian");
        MineralsName_eng.Add("Opal");


        MineralsName_kor.Add("Desert turtle stone");
        MineralsName_kor.Add("Turtle stone");
        MineralsName_kor.Add("Steak stone");
        MineralsName_kor.Add("Deep green crystal");
        MineralsName_kor.Add("Triangle soil gem");
        MineralsName_kor.Add("Super deep diamond");
        MineralsName_kor.Add("Aand crystal");
        MineralsName_kor.Add("Beryl");
        MineralsName_kor.Add("Tumbled purple gem");
        MineralsName_kor.Add("Yellow world opal");
        MineralsName_kor.Add("Aquamarine crystal");
        MineralsName_kor.Add("Emerald cheese");
        MineralsName_kor.Add("Prehnite");
        MineralsName_kor.Add("Pink mineral");
        MineralsName_kor.Add("Crystal dice stone");
        MineralsName_kor.Add("Green bright crystal");
        MineralsName_kor.Add("Orange nightpeach");
        MineralsName_kor.Add("Purple gem");
        MineralsName_kor.Add("Heart stone");
        MineralsName_kor.Add("Unknown star");


        // shop item kor
        ShopItemName_kor.Add("가성비 패키지");
        ShopItemName_kor.Add("중급 스패셜 패키지");
        ShopItemName_kor.Add("고급 스패셜 패키지");
        ShopItemName_kor.Add("최고급 스패셜 패키지");

        ShopItemName_kor.Add("스타터 패키지");
        ShopItemName_kor.Add("초급광부 패키지");
        ShopItemName_kor.Add("중급광부 패키지");
        ShopItemName_kor.Add("고급광부 패키지");

        ShopItemName_kor.Add("하급 매니저");
        ShopItemName_kor.Add("중급 매니저");
        ShopItemName_kor.Add("상급 매니저");

        ShopItemName_kor.Add("블랙코인 Set 1");
        ShopItemName_kor.Add("블랙코인 Set 2");
        ShopItemName_kor.Add("블랙코인 Set 3");
        ShopItemName_kor.Add("블랙코인 Set 4");
        ShopItemName_kor.Add("블랙코인 Set 5");
        ShopItemName_kor.Add("블랙코인 Set 6");

        ShopItemName_kor.Add("닌자 1");
        ShopItemName_kor.Add("닌자 2");
        ShopItemName_kor.Add("다이너소어");
        ShopItemName_kor.Add("판다킹");

        ShopItemName_kor.Add("광부 버프 포션");
        ShopItemName_kor.Add("광부 버프 포션");

        ShopItemName_kor.Add("드릴 버프 포션");
        ShopItemName_kor.Add("드릴 버프 포션");

        ShopItemName_kor.Add("판매 버프 포션");
        ShopItemName_kor.Add("판매 버프 포션");

        ShopItemName_kor.Add("짱짱 버프 포션");
        ShopItemName_kor.Add("짱짱 버프 포션");

        ShopItemName_kor.Add("스킬 버프 포션");
        ShopItemName_kor.Add("스킬 버프 포션");

        ShopItemName_kor.Add("자동 판매 포션");
        ShopItemName_kor.Add("자동 판매 포션");

        ShopItemName_kor.Add("영구 - 골드판매 2배 인증서");
        ShopItemName_kor.Add("영구 - 미접속 보상 2배 인증서");

        ShopItemName_kor.Add("골드팩");
        ShopItemName_kor.Add("골드팩");


        ShopItemName_kor.Add("랜덤 광부 1장");
        ShopItemName_kor.Add("랜덤 광부 5장");

        ShopItemName_kor.Add("랜덤 광부 10장");        
        ShopItemName_kor.Add("유니크 광부 1장");
        ShopItemName_kor.Add("유니크 광부 5장");

        ShopItemName_kor.Add("A ~ SS 광부 1장");
        ShopItemName_kor.Add("A ~ SS 광부 5장");

        ShopItemName_kor.Add("신의 보석 5개");
        ShopItemName_kor.Add("신의 보석 12개");


        ShopItemName_kor.Add("드릴 매니저");
        ShopItemName_kor.Add("매니저 패키지");

        // shop item eng
        ShopItemName_eng.Add("Best bang for your buck");
        ShopItemName_eng.Add("Intermediate Package");
        ShopItemName_eng.Add("Highest Package");
        ShopItemName_eng.Add("Luxury Package");

        ShopItemName_eng.Add("Starter Package");
        ShopItemName_eng.Add("Beginner Miner");
        ShopItemName_eng.Add("Intermediate Miner");
        ShopItemName_eng.Add("Higher Miner");

        ShopItemName_eng.Add("Low-level Manager");
        ShopItemName_eng.Add("Middle-level Manager");
        ShopItemName_eng.Add("High-level Manager");

        ShopItemName_eng.Add("BlackCoin Set 1");
        ShopItemName_eng.Add("BlackCoin Set 2");
        ShopItemName_eng.Add("BlackCoin Set 3");
        ShopItemName_eng.Add("BlackCoin Set 4");
        ShopItemName_eng.Add("BlackCoin Set 5");
        ShopItemName_eng.Add("BlackCoin Set 6");

        ShopItemName_eng.Add("Shadow faker");
        ShopItemName_eng.Add("Shadow pick");
        ShopItemName_eng.Add("Dinosaur");
        ShopItemName_eng.Add("Panda King");

        ShopItemName_eng.Add("Miner Buff Potion");
        ShopItemName_eng.Add("Miner Buff Potion");

        ShopItemName_eng.Add("Drill Buff Potion");
        ShopItemName_eng.Add("Drill Buff Potion");

        ShopItemName_eng.Add("Sale Buff Potion");
        ShopItemName_eng.Add("Sale Buff Potion");

        ShopItemName_eng.Add("Super Buff Potion");
        ShopItemName_eng.Add("Super Buff Potion");

        ShopItemName_eng.Add("Skill Buff Potion");
        ShopItemName_eng.Add("Skill Buff Potion");

        ShopItemName_eng.Add("Automatic-sale Potion");
        ShopItemName_eng.Add("Automatic-sale Potion");

        ShopItemName_eng.Add("Eternal Mineral Sales x 2 Certificate");
        ShopItemName_eng.Add("Eternal reward for offline x 2 certificate");

        ShopItemName_eng.Add("Gold Pack");
        ShopItemName_eng.Add("Gold Pack");
        
        ShopItemName_eng.Add("Card Pack for one");
        ShopItemName_eng.Add("Card packs for 5cards");

        ShopItemName_eng.Add("Card packs for 10cards");
        ShopItemName_eng.Add("One Unique Miner");
        ShopItemName_eng.Add("Five Unique Miners");

        ShopItemName_eng.Add("One miner from class A to SS");
        ShopItemName_eng.Add("Five miners from class A to SS");

        ShopItemName_eng.Add("God's gem 5");
        ShopItemName_eng.Add("God's gem 12");


        ShopItemName_eng.Add("Drill Manager");
        ShopItemName_eng.Add("Manager Package");


        //CapacityName_kor.Add("보관함 Lv2");
        //CapacityName_kor.Add("보관함 Lv3");
        //CapacityName_kor.Add("보관함 Lv4");
        //CapacityName_kor.Add("보관함 Lv5");
        //CapacityName_kor.Add("보관함 Lv6");
        //CapacityName_kor.Add("보관함 Lv7");
        //CapacityName_kor.Add("보관함 Lv8");
        //CapacityName_kor.Add("보관함 Lv9");
        //CapacityName_kor.Add("보관함 Lv10");
        //CapacityName_kor.Add("보관함 Lv11");
        //CapacityName_kor.Add("보관함 Lv12");
        //CapacityName_kor.Add("보관함 Lv13");
        //CapacityName_kor.Add("보관함 Lv14");
        //CapacityName_kor.Add("보관함 Lv16");
        //CapacityName_kor.Add("보관함 Lv17");
        //CapacityName_kor.Add("보관함 Lv18");
        //CapacityName_kor.Add("보관함 Lv19");

        // EngineName kor
        EngineName_kor.Add("자전거 엔진");
        EngineName_kor.Add("로잉 엔진");
        EngineName_kor.Add("석탄 엔진");
        EngineName_kor.Add("드럼 엔진");
        EngineName_kor.Add("증기 엔진");
        EngineName_kor.Add("4 기통 엔진");
        EngineName_kor.Add("6 기통 엔진");
        EngineName_kor.Add("알파 엔진");
        EngineName_kor.Add("12 기통 엔진");
        EngineName_kor.Add("개구리 엔진");
        EngineName_kor.Add("레이저 엔진");
        EngineName_kor.Add("주인이꺼");
        EngineName_kor.Add("HOIT 엔진");
        EngineName_kor.Add("다이너마이트 엔진");

        EngineName_kor.Add("업데이트 예정");
        EngineName_kor.Add("업데이트 예정");
        EngineName_kor.Add("업데이트 예정");

        // EngineName eng
        EngineName_eng.Add("Bicycle engine");
        EngineName_eng.Add("Rowing engine");
        EngineName_eng.Add("Coal engine");
        EngineName_eng.Add("Drum engine");
        EngineName_eng.Add("Steam engine");
        EngineName_eng.Add("4-cylinder");
        EngineName_eng.Add("6-cylinder");
        EngineName_eng.Add("Alpha engine");
        EngineName_eng.Add("12-cylinder");
        EngineName_eng.Add("Frog engine");
        EngineName_eng.Add("Laser engine");
        EngineName_eng.Add("UFO");
        EngineName_eng.Add("HOIT engine");
        EngineName_eng.Add("Dynamite engine");

        EngineName_eng.Add("be update soon");
        EngineName_eng.Add("be update soon");
        EngineName_eng.Add("be update soon");
        
        // BitName kor
        BitName_kor.Add("녹슨 드릴");
        BitName_kor.Add("프로펠러 드릴");
        BitName_kor.Add("석탄 드릴");
        BitName_kor.Add("드럼 드릴");
        BitName_kor.Add("철 드릴");
        BitName_kor.Add("구리 드릴");
        BitName_kor.Add("강철 드릴");
        BitName_kor.Add("회전 다이아몬드 드릴");
        BitName_kor.Add("다이아몬드 드릴");
        BitName_kor.Add("올챙이 폭격");
        BitName_kor.Add("레이져 빔");
        BitName_kor.Add("파괴광선");
        BitName_kor.Add("하어퍼 울트라 액션 빔");
        BitName_kor.Add("다이너마이트");
                
        BitName_kor.Add("업데이트 예정");
        BitName_kor.Add("업데이트 예정");
        BitName_kor.Add("업데이트 예정");

        // BitName eng
        BitName_eng.Add("Rusty drill");
        BitName_eng.Add("Propeller drill");
        BitName_eng.Add("Coal drill");
        BitName_eng.Add("Drum drill");
        BitName_eng.Add("Copper drill");
        BitName_eng.Add("Iron drill");
        BitName_eng.Add("Steel drill");
        BitName_eng.Add("Rotary Dia drill");
        BitName_eng.Add("Diamond drill");
        BitName_eng.Add("Tadpole bomb");
        BitName_eng.Add("Laser Beam");
        BitName_eng.Add("Destructive ray");
        BitName_eng.Add("Hyper Ultra Action Beam");
        BitName_eng.Add("Dynamite bomb");

        BitName_eng.Add("be update soon");
        BitName_eng.Add("be update soon");
        BitName_eng.Add("be update soon");


        // Miner name kor
        MinerName_kor.Add("손땅이");
        MinerName_kor.Add("Mr.슈퍼 손");

        MinerName_kor.Add("식목일");
        MinerName_kor.Add("내년 식목일");

        MinerName_kor.Add("웰시코기");
        MinerName_kor.Add("슈나우저");

        MinerName_kor.Add("삽기사");
        MinerName_kor.Add("삽단장");

        MinerName_kor.Add("망치");
        MinerName_kor.Add("오함마");

        MinerName_kor.Add("곡괭이");
        MinerName_kor.Add("슈퍼 곡괭이");

        MinerName_kor.Add("스카이 콩콩");
        MinerName_kor.Add("하이퍼 스카이 콩콩");

        MinerName_kor.Add("드드득");
        MinerName_kor.Add("드드드드드드득");

        MinerName_kor.Add("에어 드릴");
        MinerName_kor.Add("카본 드릴");

        MinerName_kor.Add("빤짝이");
        MinerName_kor.Add("빤짝빤짝이");

        MinerName_kor.Add("근육맨");
        MinerName_kor.Add("삼손");

        MinerName_kor.Add("공업 질럿");
        MinerName_kor.Add("공발업 질럿");

        MinerName_kor.Add("바이킹");
        MinerName_kor.Add("광산의 신 토토르");

        MinerName_kor.Add("바위처럼");
        MinerName_kor.Add("단단하게");

        MinerName_kor.Add("소식이");
        MinerName_kor.Add("과식이");

        MinerName_kor.Add("탈모인의 희망");
        MinerName_kor.Add("탈모인의 배신");

        MinerName_kor.Add("Dig man Red");
        MinerName_kor.Add("Dig man Pink");

        MinerName_kor.Add("Prototype dig bot");
        MinerName_kor.Add("Dig bot");

        MinerName_kor.Add("번개 마법사");
        MinerName_kor.Add("불의 마법사");

        MinerName_kor.Add("Titanium Man DK-1");
        MinerName_kor.Add("Titanium Man DK-3");

        MinerName_kor.Add("마녀");

        MinerName_kor.Add("네크로맨서");

        MinerName_kor.Add("해골병사");

        MinerName_kor.Add("낚시왕 남바다");

        MinerName_kor.Add("약쟁이 미이라");

        MinerName_kor.Add("건곤대나잇!");

        MinerName_kor.Add("파라5");

        MinerName_kor.Add("아!누비스");

        MinerName_kor.Add("예티");

        MinerName_kor.Add("Snowman");

        MinerName_kor.Add("식인종");

        MinerName_kor.Add("부두술사");

        MinerName_kor.Add("팩맨");

        MinerName_kor.Add("코드0");

        MinerName_kor.Add("에스키모");

        MinerName_kor.Add("시추 머신");
        MinerName_kor.Add("억만장자");

        MinerName_kor.Add("응원단원");
        MinerName_kor.Add("응원단장");

        MinerName_kor.Add("냐아옹이");
        MinerName_kor.Add("와칸다 박사");

        MinerName_kor.Add("장보고");
        MinerName_kor.Add("장인");
        MinerName_kor.Add("로봇공학박사 출신 취준생");
        MinerName_kor.Add("할배");

        MinerName_kor.Add("9급 경찰 공무원");
        MinerName_kor.Add("서포터 손");

        MinerName_kor.Add("밤손님");
        MinerName_kor.Add("낙타");
        MinerName_kor.Add("쌍봉 낙타");
        MinerName_kor.Add("낙타 조련사");

        MinerName_kor.Add("우와시스");
        MinerName_kor.Add("사막 탐험가");

        MinerName_kor.Add("전갈");
        MinerName_kor.Add("클레오 파트라");

        MinerName_kor.Add("스네이크 컨트롤러");
        MinerName_kor.Add("불");

        MinerName_kor.Add("양념치킨");
        MinerName_kor.Add("간장치킨");
        MinerName_kor.Add("파닭");

        MinerName_kor.Add("우끼끼");

        MinerName_kor.Add("우끼끼 우끼끼");
        MinerName_kor.Add("치토스");
        MinerName_kor.Add("군인 원주민");

        MinerName_kor.Add("원주민");
        MinerName_kor.Add("악어");

        MinerName_kor.Add("정글 탐험가");
        MinerName_kor.Add("식충이");

        MinerName_kor.Add("눈눈이");

        MinerName_kor.Add("에스키모 유망주");

        MinerName_kor.Add("순록");
        MinerName_kor.Add("순록 사냥꾼");
        MinerName_kor.Add("순록 사냥개");

        MinerName_kor.Add("낚시왕 남빙어");

        MinerName_kor.Add("설원 탐험가");
        MinerName_kor.Add("설원 탐험카");


        MinerName_kor.Add("그림자 분신술");
        MinerName_kor.Add("그림자 곡괭이술");
        MinerName_kor.Add("다이너소어");
        MinerName_kor.Add("판다킹");

        MinerName_kor.Add("로빈훗");
        MinerName_kor.Add("에사벨");
        MinerName_kor.Add("스나이퍼");
        MinerName_kor.Add("돌덩이");
        MinerName_kor.Add("람보");
        MinerName_kor.Add("데빌");
        MinerName_kor.Add("엔젤");
        MinerName_kor.Add("호잇");
        MinerName_kor.Add("스튜");
        MinerName_kor.Add("디오");
        
        MinerName_kor.Add("업데이트 예정");
        MinerName_kor.Add("업데이트 예정");
        MinerName_kor.Add("업데이트 예정");


        // miners name eng
        MinerName_eng.Add("Mr.hand");
        MinerName_eng.Add("Mr.Super hand");
        MinerName_eng.Add("Arbor Day");
        MinerName_eng.Add("Next year Arbor Day");

        MinerName_eng.Add("Welsh corgi");
        MinerName_eng.Add("Schnauzer");
        MinerName_eng.Add("Shovel night");
        MinerName_eng.Add("Shovel leader");

        MinerName_eng.Add("MR.HAMMER");
        MinerName_eng.Add("MC.HAMMER");

        MinerName_eng.Add("Pogo stick");
        MinerName_eng.Add("Hyper pogo stick");

        MinerName_eng.Add("Bam");
        MinerName_eng.Add("BBam");

        MinerName_eng.Add("Air drill");
        MinerName_eng.Add("Carbon drill");

        MinerName_eng.Add("Laser");
        MinerName_eng.Add("Laserbeam");

        MinerName_eng.Add("Big man");
        MinerName_eng.Add("SAMSON");

        MinerName_eng.Add("Psionic claw");
        MinerName_eng.Add("Dark psionic claw");

        MinerName_eng.Add("Viking");
        MinerName_eng.Add("Thothor");

        MinerName_eng.Add("Golem");
        MinerName_eng.Add("Obsidian golem");

        MinerName_eng.Add("Marshmello man");
        MinerName_eng.Add("Marshmello god");

        MinerName_eng.Add("The hope of bald");
        MinerName_eng.Add("Pigtail");

        MinerName_eng.Add("Dig man Red");
        MinerName_eng.Add("Dig man Pink");

        MinerName_eng.Add("Prototype dig bot");
        MinerName_eng.Add("Dig bot");

        MinerName_eng.Add("Thunder wizard");
        MinerName_eng.Add("Fire wizard");

        MinerName_eng.Add("Titanium Man DK-1");
        MinerName_eng.Add("Titanium Man DK-3");

        MinerName_eng.Add("Witch");

        MinerName_eng.Add("Necromancer");

        MinerName_eng.Add("Skeleton");

        MinerName_eng.Add("Fishing king");

        MinerName_eng.Add("Drug mummy");

        MinerName_eng.Add("Martial arts mummy");

        MinerName_eng.Add("Pharaoh");

        MinerName_eng.Add("Anubis");

        MinerName_eng.Add("Yeti");

        MinerName_eng.Add("Build a snowman");

        MinerName_eng.Add("Cannibal");

        MinerName_eng.Add("Voodoo");

        MinerName_eng.Add("Packman");

        MinerName_eng.Add("Vacuum");

        MinerName_eng.Add("Eskimo");

        MinerName_eng.Add("Mining Machine");
        MinerName_eng.Add("Billionaire");

        MinerName_eng.Add("cheerleader");
        MinerName_eng.Add("Cap of cheerleader");

        MinerName_eng.Add("meeeeeeew");
        MinerName_eng.Add("Dr.Wakanda");

        MinerName_eng.Add("Madame");
        MinerName_eng.Add("Machine master");
        MinerName_eng.Add("Mechanic Doctor");
        MinerName_eng.Add("Grandpapa");

        MinerName_eng.Add("Police");
        MinerName_eng.Add("Mrs.Son");

        MinerName_eng.Add("Theif");
        MinerName_eng.Add("Camel");
        MinerName_eng.Add("Bactrian camel ");
        MinerName_eng.Add("Camel trainer");

        MinerName_eng.Add("Wowasis");
        MinerName_eng.Add("Desert explorer");

        MinerName_eng.Add("Scorpion");
        MinerName_eng.Add("Cleopatra");

        MinerName_eng.Add("Snake Controller");
        MinerName_eng.Add("Fire");

        MinerName_eng.Add("MaMa Chiken");
        MinerName_eng.Add("PaPa Chiken");
        MinerName_eng.Add("Chick");

        MinerName_eng.Add("Dumb and Dumber");

        MinerName_eng.Add("Monkey");
        MinerName_eng.Add("Cheetos");
        MinerName_eng.Add("Soldier Native");

        MinerName_eng.Add("Native");
        MinerName_eng.Add("Crocodile");

        MinerName_eng.Add("Jungle explorer");
        MinerName_eng.Add("Cannibal plant");

        MinerName_eng.Add("Snow idol");

        MinerName_eng.Add("Eskimo prospect");

        MinerName_eng.Add("Reindeer");
        MinerName_eng.Add("Reindeer hunter");
        MinerName_eng.Add("Reindeer hound");

        MinerName_eng.Add("Ice angler");

        MinerName_eng.Add("Snowy explorer");
        MinerName_eng.Add("Snowy exploration vehicle");


        MinerName_eng.Add("Shadow faker");
        MinerName_eng.Add("Shadow pick");
        MinerName_eng.Add("Dinosaur");
        MinerName_eng.Add("Panda King");

        MinerName_eng.Add("Robin Hood");
        MinerName_eng.Add("Esabel");
        MinerName_eng.Add("Sniper");
        MinerName_eng.Add("Prehistorik");
        MinerName_eng.Add("Rambo");
        MinerName_eng.Add("Devil");
        MinerName_eng.Add("Angel");
        MinerName_eng.Add("Hoit");
        MinerName_eng.Add("Stu");
        MinerName_eng.Add("Dio");

        MinerName_eng.Add("be update soon");
        MinerName_eng.Add("be update soon");
        MinerName_eng.Add("be update soon");


    }



    public void SetTextMiner(string language, List<Text> ListText)
    {
        if(language =="kor")
        {
            for(int i=0; i< ListText.Count; i++)
            {
                ListText[i].text = MinerName_kor[i];                
            }
        }        
    }

    public void SetTextMiner(string language, Text _Text, int index)
    {
        if (language == "kor")
        {
            if (MinerName_kor.Count > index)
            {
                _Text.text = MinerName_kor[index];
            }

        }
    }

    public void SetTextEngine(string language, Text ListText, int index)
    {
        if (language == "kor")
        {           
            if(EngineName_kor.Count > index)
            {
                ListText.text = EngineName_kor[index];
            }
            
        }
    }

    public void SetMineralText(string language, Text ListText, int index)
    {
        if (language == "kor")
        {
            if (MineralsName_kor.Count > index)
            {
                ListText.text = MineralsName_kor[index];
            }
        }
    }


    public void SetTextShopItem(string language, Text ListText, int index)
    {
        if (language == "kor")
        {
            if (ShopItemName_kor.Count > index)
            {
                ListText.text = ShopItemName_kor[index];
            }
        }
    }

    public string GetTextShopItem(string language, int index)
    {
        if (language == "kor")
        {
            if (ShopItemName_kor.Count > index)
            {
                return ShopItemName_kor[index];
            }
        }
        return "";
    }

    public void SetTextCapacity(string language, Text ListText, int index)
    {
        if (language == "kor")
        {
            if (CapacityName_kor.Count > index)
            {
                ListText.text = CapacityName_kor[index];
            }

        }
    }

    public void SetTextBit(string language, Text ListText, int index)
    {
        if (language == "kor")
        {
            if(BitName_kor.Count> index)
            {
                ListText.text = BitName_kor[index];
            }            
        }
    }


    public void SetStatusText()
    {
        for(int i=0; i< CoinList.Count; i++)
        {
            CoinList[i].text = "26.7 A";
        }
        for (int i = 0; i < BlackCoinList.Count; i++)
        {
            BlackCoinList[i].text = "200 A";
        }
        for (int i = 0; i < CapaticyCoinList.Count; i++)
        {
            CapaticyCoinList[i].text = "77.7 %";
        }
    }
}

