using Palmmedia.ReportGenerator.Core.Reporting.Builders;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 자료형과 형변환에 대한 스터디 클래스 입니다. 
/// </summary>
public class DataTypeStudy : MonoBehaviour
{
    // 자료형     변수명     값 
    bool isEnable = false;      // 1Byte, true/false 의 값
    // uint       number   = 100;        // 4Byte(32bit), 정수형 최대 0 ~ 4,294,967,296 or -2,147,483,648 ~ 2,147,483,647
    float number2 = 35.5f;      // 4Byte, 실수형 자료형
    double number3 = 35.5;       // 8Byte(64bit), 실수형 자료형 
    char data = 'C';        // 1Byte, 1개의 문자를 저장하는 자료형 
    string naem = "Henry";           // 문자열, 문자의 크기에 따라 크기가 변하는 자료형 

    int number4; // 값을 할당하지 않는 경우 자동으로 0으로 값을 초기화 

    const int age = 20; // 상수: 읽기 전용, runtime 시 값을 변경하지 못함 


    // Start is called before the first frame update
    void Start()
    {
        print(isEnable);
        print(typeof(bool));
        print(number4);

        // age = 60; // 상수로 runtime 시 값을 변경하지 못함

        // 형변환 = Type Casting
        int myInt = 10;
        double myDouble = 55.4;

        // 방식 1. 암시적, 명시적 형변환
        myDouble = myInt;        // 암시적 형변환
        // myInt = myDouble;        // 암시적 형변환 불가 myDouble의 크기가 더 크기 때문에 
        myInt = (int)myDouble;   // 명시적 형변환: 크기가 큰 변수를 크기가 작은 변수로 변환

        // 방식 2. 형변환 내장 메소드 
        myInt.ToString();           // int형 변수 -> string 형 변수로 변환 
        string name2 = "이재형";
        string age = "36";
        name2.ToIntArray();         // string -> int 형 배열로 변환. 
        age.ToIntArray();           // string -> int 형 배열로 변환. 
        int.Parse(age);             // string -> int 형 변수로 변환. 
        double.Parse(age);          // string -> double 형 변수로 변환.
        bool.Parse(age);            // string -> bool 형으로 변환. 

    }

}