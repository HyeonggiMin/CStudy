using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

/// <summary>
/// �ڷ����� ����ȯ�� ���� ���͵� Ŭ�����Դϴ�.
/// </summary>
public class DataTypeStudy : MonoBehaviour
{
// ��(Value)�� ����
// �ڷ���    ������      ��
    bool    isEnable = false; // 1Byte, ture/false�� ��
    int     number   = 100; // 4Byte(32bit), ������ �ִ� -2,147,483,6478 ~ 2,147,483,647
    // uint numberUint = 4294967296; //  4Byte(32bit), ������ �ִ� 0 ~ 4294967296 or
    float   number2  = 35.5f; // 4Byte(32bit), �Ǽ��� �ڷ���
    double  number3  = 35.5; // 8Byte(64bit), �Ǽ��� �ڷ���
    char    data     = 'c'; // IByte, �ϳ��� ���ڸ� �����ϴ� �ڷ���
    string name      = "Herry"; // ���ڿ�, ������ ũ�⿡ ���� ũ�Ⱑ ���ϴ� �ڷ���

    int number4; // ���� �Ҵ����� ������ �ڵ����� 0 ������ �ʱ�ȭ

    const int age = 27; // ���: �б�����, ���� runtime�� ���� �������� ����

    // Start is called before the first frame update
    void Start()
    {
        print(isEnable);
        print(typeof(string));
        print(number4);

        // age = 60; //����� runtime�� ���� �������� ����

 // ����ȯ = Type Casting
        int myInt = 10;
        double myDouble = 55.4;

// ���1. �Ͻ���, ����� ����ȯ
        myDouble = myInt;       // �Ͻ��� ����ȯ
        /// myInt = myDouble;   // ����� ����ȯ �Ұ�: myDouble�� ũ�Ⱑ �� ũ�� ������
        myInt = (int)myDouble;  // ����� ����ȯ: ũ�Ⱑ ū ������ ũ�Ⱑ ���� ������ ��ȯ -> 55

// ���2. ����ȯ ���� �żҵ�
        myInt.ToString();       // Int�� ���� -> string�� ������ ��ȯ
        string age = "27";
        age.ToIntArray();       // string -> int�� �迭�� ��ȯ
        int.Parse(age);         // string -> int������ ��ȯ
        print(int.MaxValue);    // int�� �ִ밪
        float.Parse(age);       // string -> float������ ��ȯ
        double.Parse(age);      // string -> double������ ��ȯ
        bool.Parse(age);        // string -> bool������ ��ȯ
    }
}
