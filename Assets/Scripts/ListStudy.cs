using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

/// <summary>
/// 컬렉션 스터디를 위한 클래스
/// </summary>
/// 
public class ListStudy : MonoBehaviour
{
    public InputField input;
    public Text output;
    int a = 0;

    // 컬렉션의 특징 및 장점
    // 1. 데이터 관리를 효율적으로 할 수 있다. -> 가변형 데이터 구조
    // 2. 데이터 검색 및 정렬을 위한 매서드(기능)들이 존재
    // 3. 다양한 데이터 유형을 저장할 수 있다.

    List<string> names = new List<string>();                            // 배열과 같이 객체화 해줘야 한다.
    Dictionary<string, int> library = new Dictionary<string, int>();    // 딕셔너리 Key, Value가 한 쌍, Key는 중복이 안됨
    Stack<string> exeStack = new Stack<string>();                       // 순서대로 쌓은 후, 마지막 아이템부터 꺼낸다.
    Queue<string> exeQueue = new Queue<string>();                       // 순서대로 넣은 후, 넣을 순서대로 꺼낸다.
    HashSet<string> hashNames = new HashSet<string>();                     // List와 같은 역할, 내용은 중복 불가

    void Start()
    {
        names.Clear();
        library.Clear();
        exeStack.Clear();
        exeQueue.Clear();
        hashNames.Clear();

/*      names.Add("민형기");                     // 해당 값을 추가한다.
        names.Remove("민형기");                  // 해당 값으로 찾아 해당 값을 제거한다.
        int length = names.Capacity;             // 리스트의 크기
        names.RemoveAt(0);                       // 해당 인덱스(번호)로 찾고 해당 인덱스의 값을 제거한다.
        bool isExist = names.Contains("민형기"); // 해당 값이 있는지 확인한다.
        names.AddRange(names2);                  // 특정 자료형의 컬렉션을 추가
        names.Sort();                            // 오름차순 정렬
        names.Reverse();                         // 역순으로 정렬
        names.Insert(0, "민형기");               // 특정 위치에 값 추가
        names.InsertRange(0, names2);            // 특정 위치에 특정 자료형의 컬렉션을 추가*/

        //names.Add("민형기");
        //names.Insert(0, "김현수");
        //print(names[0]);
        //print(names[1]); // 기존에 있던 데이터는 뒤로 밀림

        //Dictionary
        library.Add("책1", 1);                   // 컬렉션 추가
        bool isExist = library.TryAdd("책1", 2); // Key가 있는지 확인하고, 없다면 추가
        library.ContainsKey("책1");              // Key가 있는지 확인
        library.ContainsValue(1);                // Value가 있는지 확인

        // Stack
        exeStack.Push("책1");                // 컬렉션 추가
        string st = exeStack.Pop();          // 마지막 넣은 값 꺼내기
        //print(exeStack.Peek());              // 마지막으로 넣은 값을 확인
        //string name = "민형기";
        //exeStack.TryPeek(out name);          // 마지막으로 넣은 값을 반환
        //print(name);
        //exeStack.TryPop(out name);           // 마지막으로 넣은 값 반환 및 제거

        // Queue
        exeQueue.Enqueue("민형기");          // 컬렉션 추가
        string name2 = exeQueue.Dequeue();   // 처음 넣은 값 꺼내기
        exeQueue.TryPeek(out name2);         // 마지막 값 반환
        exeQueue.TryDequeue(out name2);      // 처음 값 반환 및 제거

        // HaseSet: 내용 중복 X {"민형기", "조형기", "김주엽"}
        hashNames.Add("민형기");
        HashSet<string> newNames = new HashSet<string> { "김주엽", "조형기", "함우진"};
        hashNames.IntersectWith(newNames); // 교집합: { "김주엽", "조형기'}
        newNames.IsSubsetOf(hashNames);    // 부분집합: true;
        newNames.IsProperSupersetOf(hashNames);  // 진부분집합 인지 확인
        // 집합 {1, 2}는 {1, 2, 3}의 부분집합이지만,
        // {1, 2}는  {1, 2, 3}과 같지 않기 때문에 진부분집합
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.Space))
        {
            string value = input.text;
            //print(value);
        }

        // 실습1. 학급 명단 관리
        // 1. 새 학생의 이름을 추가        (add: a + space)
        // 2. 특정 학생을 명단에서 삭제    (delete: d + space)
        // 2-1. 없으면 정보없음을 출력
        // 3. 전체 학생 명단을 출력        (show: s + space)
        // 4. 특정 학생이 명단의 위치 확인 (check: c + space)

        실습1();

        void 실습1()
        {
            
            int index = 0;
            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.A))
            {
                names.Add(input.text);

                output.text += "                  " + names[a] + " 추가되었습니다.\n";

                a++;
            }

            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.D))
            {
                if(names.Contains(input.text) == true)
                {
                    names.Remove(input.text);
                    
                    print("지웠습니다.");
                }
                else
                {
                    print("정보가 없습니다.");
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.S))
            {
                for(int i = 0; i < names.Count; i++)
                {
                    print(names[i]);
                }
            }

            if (Input.GetKeyDown(KeyCode.Space) && Input.GetKey(KeyCode.C))
            {
                index = names.IndexOf(input.text);
                print(index);
            }
        }
    }
}
