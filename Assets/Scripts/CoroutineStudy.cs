using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 1초 시간 간격으로 현재 시간을 Console에 찍어본다.
/// </summary>
public class CoroutineStudy : MonoBehaviour
{
    public Transform obj;
    public Transform obj2;
    public MeshRenderer redMeshRenderer;
    public MeshRenderer yellowMeshRenderer;
    public MeshRenderer greenMeshRenderer;
    public Transform cylinderA;
    public Transform cylinderA_end;
    public Transform cylinderA_start;
    public Transform cylinderB;
    public Transform cylinderB_end;
    public Transform cylinderB_start;

    void Start()
    {
        //StartCoroutine("CoInput");
        //StartCoroutine(CoInput());
        //StartCoroutine(CoSequence(obj));
        //StartCoroutine(CoSequence(obj2));
        StartCoroutine("CoTrafficLight");
        StartCoroutine(CoMoveCylinders());
    }

    bool isLoopActive = false;

    private void Update()
    {

        // 1. 물체A를 Vector3.Lerp를 사용하여 이동시킨다.
        // 2. 물체B를 Vector3.Lerp를 사용하여 이동시킨다.

        if(Input.GetKeyDown(KeyCode.Space))
        {
            bool isLoopActive = true;
        }
    }

/*    IEnumerator CoInput()
    {
        while (true)
        {
            print(DateTime.Now);

            yield return new WaitForSeconds(1);
        }
    }

    IEnumerator CoSequence(Transform obj)
    {
        float currentTime = 0;

        // Obj A -> B
        while(true)
        {
            currentTime += Time.deltaTime;

            if(currentTime > 2)
            {
                currentTime = 0;
                break;
            }

            obj.position = Vector3.Lerp(Vector3.zero, new Vector3(3, 3, 3), currentTime / 2);

            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(2);

        print("2초 후 특정 기능을 실행");

        yield return CoSequence2(obj2);
    }

    IEnumerator CoSequence2(Transform obj)
    {
        float currentTime = 0;

        // Obj A -> B
        while (true)
        {
            currentTime += Time.deltaTime;

            if (currentTime > 2)
            {
                currentTime = 0;
                break;
            }

            obj.position = Vector3.Lerp(Vector3.zero, new Vector3(3, 3, 3), currentTime / 2);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }
*/
 
    // 실습1. 빨강, 노랑, 초록 LAMP가 빨강 -> 노랑 -> 초록 순서로 켜진다.
    // 초기 상태 = 검정색
    // Sphere GameObject

    IEnumerator CoTrafficLight()
    {
        while (!isLoopActive)
        {
            redMeshRenderer.material.color = Color.black;
            yellowMeshRenderer.material.color = Color.black;
            greenMeshRenderer.material.color = Color.black;

            yield return new WaitForSeconds(1);

            // 실습1. 빨강, 노랑, 초록 LAMP가
            // 빨강 -> 노랑 -> 초록 순서로 1초 간격으로 켜지는 것을 무한 반복

            redMeshRenderer.material.color = Color.red;

            yield return new WaitForSeconds(1);

            redMeshRenderer.material.color = Color.black;
            yellowMeshRenderer.material.color = Color.yellow;

            yield return new WaitForSeconds(1);

            yellowMeshRenderer.material.color = Color.black;
            greenMeshRenderer.material.color = Color.green;

            yield return new WaitForSeconds(1);
        }
    }

    // 실습2. 공급 실린더(A) 전진, 후진 후 송출 실린더(B) 전진, 후진
    // 조건: 모든 시퀀스 작동시간은 1초
    // Vector3.Lerp를 사용

    IEnumerator MoveCylinder(Transform cylinder, Vector3 positionA, Vector3 positionB, float duration)
    {
        float currentTime = 0;

        while (true)
        {
            currentTime += Time.deltaTime;

            if (currentTime >= duration)
            {
                currentTime = 0;
                break;
            }

            cylinder.position = Vector3.Lerp(positionA, positionB, currentTime / duration);

            yield return new WaitForSeconds(Time.deltaTime);
        }
    }

    IEnumerator CoMoveCylinders()
    {
        for(int i = 0; i < 10; i++)
        {
            // 1. 실린더 A를 A_end로 이동(전진)
            yield return MoveCylinder(cylinderA, cylinderA_start.position, cylinderA_end.position, 1);

            // 2. 실린더 A를 A_start로 이동(후진)
            yield return MoveCylinder(cylinderA, cylinderA_end.position, cylinderA_start.position, 1);

            // 3. 실린더 B를 B_end로 이동(전진)
            yield return MoveCylinder(cylinderB, cylinderB_start.position, cylinderB_end.position, 1);

            // 4. 실린더 B를 B_start로 이동(후진)
            yield return MoveCylinder(cylinderB, cylinderB_end.position, cylinderB_start.position, 1);
        }

    }

}
