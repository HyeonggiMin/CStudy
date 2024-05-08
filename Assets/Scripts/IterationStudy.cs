using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class IterationStudy : MonoBehaviour
{
    enum Options
    {
        Simple,
        Compound
    }

    [SerializeField] TMP_Dropdown interestOption;
    [SerializeField] TMP_InputField balanceInput;
    [SerializeField] TMP_InputField interestRateInput;
    [SerializeField] TMP_InputField yearInput;
    [SerializeField] Text logTxt;

    //for
    //foreach
    string[] names = { "민형기", "김주엽", "김덕기" };

    //while
    //do-while

    void Start()
    {
        /*  반복문 스터디
         *      // 1.초기화   2.조건  3.증감
                for(int i = 0; i < 10; i++)
                    print(i);

                // 0 ~ 배열의 길이까지 반복
                for(int i = 0; i < name.Length; i++) 
                    print(names[i]);

                // 배열의 길이 ~ 0까지 반복
                for (int i = (name.Length - 1); i > 0; i--)
                    print(names[i]);

                // 짝수만 출력하는 반복문
                for(int i = 0; i < 10; i++)
                {
                    if(i % 2 == 0)
                        print(i);

                    if (i > 5)
                        break;
                }

                // 조건을 입력할 필요가 없음
                foreach (string name in names)
                    print(name);

                // while
                int number = 0;
                while (number < 10)
                {
                    number++;
                }

                // while 무한반복
                while (true)
                {
                    if(number == 10)
                    {
                        break; // 무한반복문을 종료시키는 키워드
                    }
                }

                int m0 = 0;
                while(m0 == 0)
                {

                }

                // do-while: 반복문의 조건이 거짓이어도 최소 한번은 실행
                int num = 0;
                do
                {
                    print(num);
                    num++;
                }
                while (num < 10);*/

        logTxt.text = string.Empty;
    }

    void Update()
    {
        //실습1. 은행 적금 이자 계산(단리, 복리)
        //열거형으로 단리, 복리
/*      입력: 초기금액, 연이율, 기간
        1. Dropdown UI에서 단리/복리 선택
        2. 금액 입력
        3. 연이율 입력
        4. 기간 입력
        출력 예시
        3년 만기 정기예금(단리)
        년차  입금액  이자    총액
        1년차 100만원 10만원  110만원
        2년차 100만원 10만원  220만원

        3년 만기 정기예금(복리)
        년차  입금액  이자    총액
        1년차 100만원 10만원  110만원
        2년차 110만원 11만원  231만원
*/

    }

    public void OnCalBtnClkEvent()
    {
        float balance = float.Parse(balanceInput.text);
        float interestRate = float.Parse(interestRateInput.text);
        int year = int.Parse(yearInput.text);
        double result = 0;
        double amount = 0;

        logTxt.text = string.Empty;
        logTxt.text += "연차/입금액/이자/총액\n\n";

        // 실습1. 은행 적금 이자 계산(단리, 복리)
        switch (interestOption.value)
        {
            case (int)Options.Simple:
                amount = balance;
                for (int i = 0; i < year; i++)
                {
                    double newInterestRate = (amount * (interestRate / 100));
                    result += amount + newInterestRate;

                    logTxt.text += $"{i + 1}년 차/{balance}원/{newInterestRate}원/{result}원\n";
                }
                break;
            case (int)Options.Compound:
                amount = balance;
                for (int i = 0; i < year; i++)
                {
                    double newInterestRate = (amount * (interestRate / 100));
                    result += balance + newInterestRate;
                    amount = result;

                    logTxt.text += $"{i + 1}년 차/{balance}원/{newInterestRate}원/{result}원\n";
                }
                break;
        }
    }
}
