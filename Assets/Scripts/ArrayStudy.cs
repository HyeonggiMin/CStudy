using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// 배열 스터디를 위한 클래스입니다.
/// </summary>
public class ArrayStudy : MonoBehaviour
{
    // 배열: 자료형을 여러개 저장할 수 있는 데이터 구조
    // 데이터를 효율적으로 관리하기 위해 사용

    // 배열 키워드
    int[] numbers; // 인스턴스로 만들어 주지 않아 오류 발생 -> NullReferenceException: Object reference not set to an instance of an object
    int[] numbers2 = new int[5]; // new 키워드로 인스턴스화, int형 변수 0, 1, 2, 3, 4 인덱스의 5개 공간을 만듦
    string[] names = new string[3];
    string[] names2 = { "김주엽", "배진우" };
    string[,] library = { { "책1", "책2" }, { "책3", "책4" } };

    void Start()
    {
        //int a = numbers[0]; // NullReferenceException
        print(numbers2[0]); // 0으로 초기화
        //print(numbers2[5]); // 배열의 범위를 벗어난 인덱스 사용으로 오류 발생 -> IndexOutOfRangeException: Index was outside the bounds of the array

        //배열의 속성
        print(numbers2.Length); // 배열의 크기
        print(numbers2.Rank);   // 배열의 차원 수

        //배열의 매서드
        names[0] = "민형기";
        names[1] = "김현수";
        names[2] = "장재원";

        Array.Sort(names);
        Array.Sort<string>(names); // 가나다 순으로 정렬 "김현수", "민형기", "장재원"
        print(names[0]); // "김현수"
        Array.Reverse(names); // 역순으로 정렬 "장재원", "민형기", "김현수"
        print(names[0]); // "장재원"

        string a = String.Join(", ", names); // 장재원, 민형기, 김현수
        print(a);

        //다차원 배열
        //2차원 배열
        string[,] library = new string[2, 2];
        library[0, 0] = "퓨쳐셀프";
        library[0, 1] = "드래곤볼";
        library[1, 0] = "원피스";
        library[1, 1] = "나루토";

        실습1();
        // 실습1. 24년 5월 3일 기온 데이터 다뤄보기
        // 데이터 예시 1시, 2시... 23시까지 { 13, 12, 13, 14, 15, 16, 17, 18, 19, 20, 20, 21, 22, ...}
        // 1. 하루 평균 기온 계산 후 출력
        // 2. 하루 최고 기온 출력
        // 3. 평균 기온보다 높은 시간대 출력

        void 실습1()
        { 

            int[] TodayTemperture = { 14, 14, 13, 12, 12, 12, 14, 17, 20, 22, 24, 25, 26, 26, 26, 26, 26, 26, 24, 21, 19, 18, 17, 15 };
            int sum = 0;
            int maxValue = 0;
            int minValue = 30;

            for (int i = 0; i < TodayTemperture.Length; i++)
            {
                sum += TodayTemperture[i];

                if (TodayTemperture[i] > maxValue)
                {
                    maxValue = TodayTemperture[i];
                }

                if (TodayTemperture[i] < minValue)
                {
                    minValue = TodayTemperture[i];
                }
            }

            float averageTemperture = sum / TodayTemperture.Length;
            print("평균기온: " + averageTemperture);
            print("최고기온: " + maxValue);
            print("최저기온: " + minValue);


            string temp = "";
            for (int i = 0; i < TodayTemperture.Length; i++)
            {
                if (TodayTemperture[i] > averageTemperture)
                {
                    temp += (i + 1).ToString() + "시, ";
                }
            }

            print("평균 온도보다 높은 시간대: " + temp);
        }

        실습2();

        // 실습2. 물품 재고 관리 데이터 다뤄보기

        void 실습2()
        {
            // inventory
            // 매장 재고관리
            // 0: 로션
            // 1: 선크림
            // 2: 향수
            // 3; 아이브로우
            // 4: 스낵1
            int[] inventory = { 50, 10, 2, 10, 5 };

            // 1. 재고가 10개 미만인 모든 아이템과 그 재고를 출력
            // 2. 총 재고량의 합계 출력
            // 3. 가장 재고량이 많은 아이템을 출력
            // 4. 평균 재고량 출력
            // 5. 재고량이 평균 이하인 아이템을 찾아서 다른 배열로 만들기

            // 출력 예시
            // 1. Low Stock items: 1, 2, 3, 4
            // 2. Total inventory: XX
            // 3. Most biggest stock itme: 2(함수1)
            // 4. Average Stock: XX
            // 5. Below Average items: 1(선크림1), 3(아이브로우1) 

            // 2번 아이템이 2개 이하로 줄었을 때 -> 3개 주문
            //string[] items = { "로션", "선크림", "향수", "아이브로우", "스낵" };
            string lowStockItems = "";
            int totalInventory = 0;
            int mostBiggestStockItem = 0;
            int mostBiggestStockItemIndex = 0;
            int averageStock = 0;
            string belowAverage = "";

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] < 10) // 1. 재고가 10개 미만인 모든 아이템과 그 재고를 출력
                {
                    lowStockItems += i.ToString() + ", ";
                }

                totalInventory += inventory[i];  // 2. 총 재고량의 합계 출력

                if (inventory[i] > mostBiggestStockItem) // 3. Most biggest stock itme: 2(함수1)
                {
                    mostBiggestStockItem = inventory[i];
                    mostBiggestStockItemIndex = i;
                }
            }

            averageStock = totalInventory / inventory.Length; // 4. 평균 재고량 출력

            for (int i = 0; i < inventory.Length; i++) 
            {
                if (inventory[i] < averageStock) // 5. Below Average items: 1(선크림1), 3(아이브로우1) 
                {
                    belowAverage += i+ "(" + inventory[i] + "개), ";
                }
            }

            print("Low Stock Items: " + lowStockItems);
            print("Totla Inventory: " + totalInventory);
            print("Most Biggest Stock Item: " + mostBiggestStockItemIndex + "번(" + mostBiggestStockItem + "개)");
            print("Average Stocks: " +  averageStock);
            print("Below Average: " + belowAverage);
        }
    }
}
