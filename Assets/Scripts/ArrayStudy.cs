using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 배열 스터디를 위한 클래스
/// </summary>
public class ArrayStudy : MonoBehaviour
{
    // 배열: 자료형을 여러개 저장할 수 있는 데이터 구조
    // 데이터를 효율적으로 관리하기 위해 사용

    // 배열 키워드
    int[] numbers; // NullRefrenceException 오류
    int[] numbers2 = new int[5]; // new 키워드로 인스턴스화, int형 변수 0,1,2,3,4 인덱스의 5개 공간을 만듦
    string[] names = new string[3];
    string[,] library = { { "책1", "책2" },{ "책3", "책4" } };

    void Start()
    {
        // int a = numbers[0]; // NullRefrenceException 오류
        print(numbers2[0]); // 0으로 초기화
        //print(numbers2[5]); // 배열의 범위를 벗어난 인덱스 사용으로 IndexOutOfRangeException 오류 발생

        // 배열의 속성
        print(numbers2.Length); // 배열의 크기
        print(numbers2.Rank);   // 배열의 차원 수

        // 배열의 메서드
        names[0] = "이성국";
        names[1] = "이성국1";
        names[2] = "이성국2";

        Array.Sort(names);
        Array.Sort<string>(names);
        print(names[0]);
        Array.Reverse(names);
        print(names[0]);

        string[,] library = new string[2, 2];
        library[0, 0] = "퓨처셀프";
        library[0, 1] = "드래곤볼";
        library[1, 0] = "원피스";
        library[1, 1] = "습관의힘";

        실습1();
        // 실습 1. 24년 5월 3일 기온 데이터 다뤄보기
        // 데이터 예시 1시, 2시, 23시까지 {25,12,13,14,15,16,17,18,19,20,20,21,22,....}
        // 1. 하루 평균 기온 계산
        // 2. 하루 최고 기온 출력
        // 3. 평균 기온보다 높은 시간대 출력
        void 실습1()
        {
            int[] temperture = { 25, 26, 27, 27, 26, 24, 21, 20, 19, 18, 18 };

            int sum = 0;
            int maxvalue = 0;
            for (int i = 0; i < temperture.Length; i++)
            {
                sum += temperture[i];

                if (temperture[i] > maxvalue)
                    maxvalue = temperture[i];
            }

            float averageTemperture = sum / temperture.Length;

            print("평균기온 : " + averageTemperture);
            print("최고기온 : " + maxvalue);

            string temp = "";
            for (int i = 0; i < temperture.Length; i++)
            {
                if (temperture[i] > averageTemperture)
                {
                    temp += i.ToString() + "시 , ";
                }

            }
            print("평균온도보다 높은 시간대 : " + temp);
        // 출력 1,2,3
        }


        실습2();
        // 실습2. 물품 재고관리 데이터 다뤄보기
        // inventory
        // 매장 재고관리
        // 0: 로션 1
        // 1: 선크림 1
        // 2: 향수 1
        // 3: 아이브로우 1
        // 4: 스낵 1

        // 1. 재고가 10개 미만인 모든 아이템과 그 재고를 출력
        // 2. 재고량 합계 출력
        // 3. 가장 재고량이 많은 아이템 출력
        // 4. 평균 재교량 출력
        // 5. 재고량이 평균 이하인 아이템을 찾기

        // 출력 예시
        // 1. Low Stock items : 1,2,3,4
        // 2. Total inventory : xx
        // 3. Most biggest stock item : 2(향수1)
        // 4. Average Stock : xx
        // 5. Below Average items : 1(선크림), 3(아이브로우)
        void 실습2()
        {
            int[] inventory = { 50, 10, 2, 10, 5 };

            string lowStockItems = "";
            int totalInventory = 0;
            int mostBiggestStockItem = 0;
            int mostBiggestStockItemIndex = 0;
            int averageStock = 0;
            string belowAverage = "";

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] > 10) // 1. 재고가 10개 미만인 모든 아이템과 그 재고를 출력 
                {
                    lowStockItems += i.ToString() + ", ";
                }



                totalInventory += inventory[i]; // 2. 재고량 합계 출력 

                if (inventory[i] > mostBiggestStockItem)  // 3. 가장 재고량이 많은 아이템 출력: 2(향수1)
                {
                    mostBiggestStockItem = inventory[i];
                    mostBiggestStockItemIndex = i;
                }
            }
            averageStock = totalInventory / inventory.Length; // 4. Average Stock: XX 

            for (int i = 0; i < inventory.Length; i++)
            {
                if (inventory[i] < averageStock)// 5. Below Average items : 1(선크림1) , 3(아이브로우1)

                {
                    belowAverage += i + "(" + inventory[i] + "개), ";
                }
            }
            print("Low Stock Items :" + lowStockItems);
            print("Total Inventory :" + totalInventory);
            print("Most Biggest Stock Item: " + mostBiggestStockItem);
            print("Below Average :" + belowAverage);



            // 출력 예시 
            // 1. LOW Stock items: 1, 2, 3, 4
            // 2. Total inventory : XX
            // 3. Most biggest stock item : 2 (향수 1)
            // 4. Avergae Stock: XX 
            // 5. Below Average items : 1(선크림1), 3(아이브로우1)


            // 2번 아이템이 2개 이하로 줄었을 때 -> 3개 주문
            void CheckItem()
            {
                if (inventory[2] == 2)
                {
                    // 2개 주문 
                }
            }

        }

    }
}

