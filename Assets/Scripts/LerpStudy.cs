using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Lerp(Linear Interpolation, 선형 보간) : 값 A, 값 B 사이의 값을 계산하는 방법
/// 용도 1. 3D Object의 움직임을 부드럽게 표현하기 위해 사용
/// 용도 2. 숫자 A와 숫자 B값 사이를 Blending
/// </summary>
public class LerpStudy : MonoBehaviour
{
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
    public Transform Obj; 
    public float duration = 2;
    public float currentTime = 0;


    Vector3 positionA = new Vector3(0, 0, 0);
    Vector3 positionB = new Vector3(3, 3, 3);

    
    void Update()
    {
        currentTime += Time.deltaTime;
        print(currentTime);

        if (currentTime > duration)
        {
            currentTime = 0;
            /*
            float temp = numA;
            numA = numB;
            numB = temp;

            Color tempcolor = colorA;
            colorA = colorB;
            colorB = tempcolor;

            Vector3 tempPoint = pointA.position;
            pointA.position = pointB.position;
            pointB.position = pointC.position;
            pointC.position = pointD.position;
            pointD.position = pointE.position;
            pointE.position = tempPoint;*/
        }
        // 실습1. 이어달리기
        // point A, B, C, D, E 순차적으로 Obj를 이동(각 이동의 duration은 1초)
        /*    
        // 1. 밝기
        float value = Mathf.Lerp(numA, numB, currentTime / duration);
        //light.intensity = value;

        // 2. 컬러
        Color newColor = Color.Lerp(colorA, colorB, currentTime / duration);
        light.color = newColor;

        // 3. 위치이동
        Vector3 newVector = Vector3. Lerp(pointA.position, pointB.position, currentTime / duration);
        Vector3 newVector1 = Vector3. Lerp(pointB.position, pointC.position, currentTime / duration);
        Vector3 newVector2 = Vector3. Lerp(pointC.position, pointD.position, currentTime / duration);
        Vector3 newVector3 = Vector3. Lerp(pointD.position, pointE.position, currentTime / duration);
        Obj.position = newVector;*/



        // 실습2. 물체간의 거리를 계산해서 특정거리 이내일 때 방향을 바꾼다 
        
        //Vector3 newVec3 = positionB - positionA;
        //float distance = newVec3.magnitude;

        Vector3 moveVector = Vector3.Lerp(positionA, positionB, currentTime / duration);
        Obj.position = moveVector;        
        Vector3 newVec3 = positionB - Obj.position;
        float distance = newVec3.magnitude;
        print(distance);

        if(distance < 0.5f)
        {
            Vector3 temp = positionA;
            positionA = positionB;
            positionB = temp;
        }
        

    }


}
