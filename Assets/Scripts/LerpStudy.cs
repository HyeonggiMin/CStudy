using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

/// <summary>
/// Lerp(Linear Interpoation, 선형 보간): 값 A와 값 B 사이의 값을 계산하는 방법
/// 용도1. 3D Object의 움직임을 부드럽게 표현하기 위해 사용
/// 용도2. 숫자 A와 숫자 B 값 사이를 Blending
/// </summary>
public class LerpStudy : MonoBehaviour
{
   public enum Direction
    {
        A, B, C, D, E
    }
    public Direction direction = Direction.A;

    public Light light;
    public float numA = 0;
    public float numB = 10;
    public Color colorA = Color.red;
    public Color colorB = Color.blue;
    public Transform pointA;
    public Transform pointB;
    public Transform pointC;
    public Transform pointD;
    public Transform pointE;
    public Transform obj;
    public float duration = 2;
    public float currentTime = 0;
    int options = 0;
    Vector3 originPos;
    Vector3 positionA = new Vector3(0, 0, 0);
    Vector3 positionB = new Vector3(3, 3, 3);
    bool isDirectionChanged = false;

    private void Start()
    {
        originPos = obj.position;
    }

    void Update()
    {
        currentTime += Time.deltaTime;
    
        if (currentTime > duration)
        {
            currentTime = 0;
/*          1. 밝기 변경
 *          float temp = numA;
            numA = numB;
            numB = temp;
            
            2. 컬러 변경
            Color tempColor = colorA;
            colorA = colorB;
            colorB = tempColor;
            
            3. 위치 변경
            Vector3 tempPoint = pointA.position;
            pointA.position = pointB.position;
            pointB.position = tempPoint;

            options++;

            if (options > (int)Direction.E)
                options = 0;

            direction = (Direction) options;*/

        }

        /*      1. 밝기 변경
                float value = Mathf.Lerp(numA, numB, currentTime / duration);
                //light.intensity = value;

                2. 컬러 변경
                Color newColor = Color.Lerp(colorA, colorB, currentTime / duration);
                light.color = newColor;

                3. 위치 이동
                /*Vector3 newVector = Vector3.Lerp(pointA.position, pointB.position, currentTime / duration);
                obj.position = newVector;*/

        /*      실습1. 이어달리기
                // 5개 Point A, B, C, D, E 순차적으로 Obj를 이동을 반복(각 이동의 duration은 1초)
                Vector3 newVector = Vector3.zero;

                switch (direction)
                {
                    case Direction.A:
                        newVector = Vector3.Lerp(originPos, pointA.position, currentTime / duration);                
                        break;
                    case Direction.B:
                        newVector = Vector3.Lerp(pointA.position, pointB.position, currentTime / duration);
                        break;
                    case Direction.C:
                        newVector = Vector3.Lerp(pointB.position, pointC.position, currentTime / duration);
                        break;
                    case Direction.D:
                        newVector = Vector3.Lerp(pointC.position, pointD.position, currentTime / duration);
                        break;
                    case Direction.E:
                        newVector = Vector3.Lerp(pointD.position, pointE.position, currentTime / duration);
                        break;
                }

                obj.position = newVector;*/

        // 실습2. 물체간의 거리를 계산해서 특정 거리 이내일 때, 방향을 바꾼다.

        //Vector3 newVec3 = positionB - positionA;
        //float distance = newVec3.magnitude;

        Vector3 moveVector = Vector3.Lerp(positionA, positionB, currentTime / duration);
        obj.position = moveVector;
        Vector3 newVec3 = positionB - obj.position;
        float distance = newVec3.magnitude;
        print(distance);

        if(distance < 0.5f) 
        {
            isDirectionChanged = true;
            if (isDirectionChanged)
            {
                Vector3 temp = positionA;
                positionA = positionB;
                positionB = temp;

                isDirectionChanged = false;
            }
            
        }
    }
}
