using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// 자료형과 형변환에 대한 스터디 클래스입니다..
/// </summary>
public class DataTypeStudy : MonoBehaviour
{
// 갑(Value)형 변수
// 자료형    변수명      값
    bool    isEnable = false; // 1Byte, ture/false의 값
    int     number   = 100; // 4Byte(32bit), 정수형 최대 -2,147,483,6478 ~ 2,147,483,647
    // uint numberUint = 4294967296; //  4Byte(32bit), 정수형 최대 0 ~ 4294967296 or
    float   number2  = 35.5f; // 4Byte(32bit), 실수형 자료형
    double  number3  = 35.5; // 8Byte(64bit), 실수형 자료형
    char    data     = 'c'; // IByte, 하나의 문자를 저장하는 자료형
    string name      = "Herry"; // 문자열, 문자의 크기에 따라 크기가 변하는 자료형

    int number4; // 값을 할당하지 않으면 자동으로 0 값으로 초기화

    const int age = 27; // 상수: 읽기전용, 값을 runtime시 값을 변경하지 못함

    // Start is called before the first frame update
    void Start()
    {
        print(isEnable);
        print(typeof(string));
        print(number4);

        // age = 60; //상수로 runtime시 값을 변경하지 못함

 // 형변환 = Type Casting
        int myInt = 10;
        double myDouble = 55.4;

// 방식1. 암시적, 명시적 형변환
        myDouble = myInt;       // 암시적 형변환
        /// myInt = myDouble;   // 명시적 형변환 불가: myDouble의 크기가 더 크기 때문에
        myInt = (int)myDouble;  // 명시적 형변환: 크기가 큰 변수를 크기가 작은 변수로 변환 -> 55

// 방식2. 형변환 내장 매소드
        myInt.ToString();       // Int형 변수 -> string형 변수로 변환
        string age = "27";
        age.ToIntArray();       // string -> int형 배열로 변환
        int.Parse(age);         // string -> int형으로 변환
        print(int.MaxValue);    // int의 최대값
        float.Parse(age);       // string -> float형으로 변환
        double.Parse(age);      // string -> double형으로 변환
        bool.Parse(age);        // string -> bool형으로 변환
    }
}
