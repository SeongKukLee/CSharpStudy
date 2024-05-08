using JetBrains.Annotations;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IterationStudy : MonoBehaviour
{
    // public이 아니어도 사용할 수 있게 함 ->[SerializeFiedl]
    [SerializeField] TMP_Dropdown interestOption;
    [SerializeField] TMP_InputField balanceInput;
    [SerializeField] TMP_InputField interestRateInput;
    [SerializeField] TMP_InputField yearInput;
    [SerializeField] Text logTxt;

    public Button CalculateButton;

    // for 
    // foreach: 배열을 순회하며 값을 확인하기 위해 
    string[] names = { "신태욱", "김동균", "이현수" };

    // while
    // do-while

    void Start()
    {
        /* 반복문스터디
        // 1.초기화  2.조건  3.증감
        for(int i =0; i<10; i++)
        {
            print(i);
            
        }
        // 0 ~ 배열의 길이까지 반복
        for(int i =0; i<names.Length; i++)
        {
            print(names[i]);    
        }
        // 배열의 길이 ~ 0까지 반복
        for (int i = names.Length - 1; i >= 0 ; i--)
        {
            print(names[i]);
        }
        // 0 ~ 10까지 짝수만 출력. 
        for(int i =0; i < 10; i++)
        {
            if (i % 2 == 0)
                print(i);
        }
        // 조건을 입력할 필요가 없음. 
       
        foreach(string name in names) // names 배열을 반복하고 name을 출력
        {
            
            print(name );
        }

        //while
        int number = 0;
        while(number < 10)
        {
            number++;
        }

        while (true)
        {
            if(number ==10)
            {
                break; // 반복문을 종료시키는 키워드 
            }
        }

        //do - while: 반복문의 조건이 거짓이어도 최소 한번은 실행. 
        int num = 0;
        do //최소 한 번 이상은 실행
        {
            print("시작합니다");
            num++;
        }
        while (num < 10); // 그 다음 조건 확인
        */

        logTxt.text = "단리와 복리 중 선택하세요";
        print(interestOption.value);
    }

    void Update()
    {


    }
    public enum Options
    {
        Simple,
        Compound
    }
    public void OnCalBtnClkEvent()
    {
        logTxt.text = "";
        logTxt.text = ("년차      입금액         이자          총액 \n");
        /*
        // 실습1. 은행 적금 이자 계산(단리, 복리)
        // 열거형으로 단리, 복리 
        //입력: 초기금액, 연이율, 기간 
        // 1. Dropdown UI에서 단리/복리 선택
        // 2. 금액 입력
        // 3. 연이율 입력
        // 4. 기간 입력
        // 출력예시
        // 3년 만기 정기예금(단리) 
        // 년차   입금액    이자(10%)    총액
        // 1년차 100만원    10만원        110만원    
        // 2년차 100만원    10만원        220만원

        //   3년 만기 정기예금(복리) 
        // 년차   입금액    이자(10%)    총액
        // 1년차 100만원    10만원        110만원    
        // 2년차 110만원    11만원        221만원
        */
        float balance = float.Parse(balanceInput.text);
        float interestrate = float.Parse(interestRateInput.text);
        int year = int.Parse(yearInput.text);
        float sum = 0;

        switch (interestOption.value)
        {
            case (int)Options.Simple:
                print(balance);
                print(interestrate);
                print(year);
                for (int i = 0; i < year; i++)
                {

                    sum = (balance + (balance * (interestrate / 100))) * (i + 1);
                    logTxt.text += ($"{i + 1} 년차 {balance}원 {(balance * (interestrate / 100))}원  {sum}원 \n");

                }
                print(sum);
                break;

            case (int)Options.Compound:
                print(balance);
                print(interestrate);
                print(year);
                for (int i = 0; i < year; i++)
                {
                    sum = balance + (balance * (interestrate / 100));
                    balance = sum;
                    logTxt.text += ($"{i + 1} 년차 {balance}원 {(balance * (interestrate / 100))}원  {sum}원 \n");
                }
                print(sum);
                break;
        }
    }
}