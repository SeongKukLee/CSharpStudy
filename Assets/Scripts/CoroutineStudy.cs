using System;
using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

/// <summary>
/// 1초 시간 간격으로 현재 시간을 Console에 찍어본다. 
/// </summary>

public class CoroutineStudy : MonoBehaviour
{

    public Transform obj;
    public Transform obj2;

    public Transform cylinderA;
    public Transform cylinderA_start;
    public Transform cylinderA_end;
    public Transform cylinderB;
    public Transform cylinderB_start;
    public Transform cylinderB_end;
    
    public MeshRenderer redMeshRenderer;
    public MeshRenderer yellowMeshRenderer;
    public MeshRenderer greenMeshRenderer;



    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine("CoInput");
        //StartCoroutine(CoInput());
        //StartCoroutine(CoSequence(obj));
        //StartCoroutine(CoSequence(obj2));

        StartCoroutine(CoTrraficLight());
        StartCoroutine(CoMoveCylinders());
    }

    /*
    IEnumerator CoInput()
    {
        
        while (true)
        {
            print(DateTime.Now);

            // yield return null; // 아무것도 리턴하지 않겠다
            yield return new WaitForSeconds(1); // 1초에 한번씩 리턴
            

        }
        
    }
    

    
    IEnumerator CoSequence(Transform obj)
    {

        float currentTime = 0;
        // Obj A -> Obj B 
        while(true)
        {
            currentTime += Time.deltaTime;

            if(currentTime > 2) // 이동이 완료했을 때 
            {
                currentTime = 0;
                break;
            }
            obj.position = Vector3.Lerp(Vector3.zero, new Vector3(3, 3, 3), currentTime / 2);


            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(2); // 2초마다 리턴함으로써 딜레이 걸어줌. 

        print("2초 후 특정 기능을 실행");

        yield return CoSequence2(obj2); // 2초 후에 CoSequence2가 실행된다. 
        
    }

    IEnumerator CoSequence2(Transform obj)
    {
        float currentTime = 0;
        // Obj A -> Obj B 
        while (true)
        {
            currentTime += Time.deltaTime;

            if (currentTime > 2) // 이동이 완료했을 때 
            {
                currentTime = 0;
                break;
            }
            obj.position = Vector3.Lerp(Vector3.zero, new Vector3(3, 3, 3), currentTime / 2);


            yield return new WaitForSeconds(Time.deltaTime);
        }

        yield return new WaitForSeconds(2); // 2초마다 리턴함으로써 딜레이 걸어줌. 

        print("2초 후 특정 기능을 실행");

    }
    */
    // 실습1. 빨강, 노랑, 초록 LAMP가 빨강 ->  노랑 -> 초록 순서로 켜진다. 
    // 초기 상태 = 검은색
    IEnumerator CoTrraficLight()
    {

        redMeshRenderer.material.color = Color.black;
        yellowMeshRenderer.material.color = Color.black;
        greenMeshRenderer.material.color = Color.black;



        yield return new WaitForSeconds(1);

        yield return Red();


    }

    IEnumerator Red()
    {
        redMeshRenderer.material.color = Color.red;

        yield return new WaitForSeconds(1);

        redMeshRenderer.material.color = Color.black;
        yield return Yellow();
    }

    IEnumerator Yellow()
    {
        yellowMeshRenderer.material.color = Color.yellow;

        yield return new WaitForSeconds(1);

        yellowMeshRenderer.material.color = Color.black;
        yield return Green();
    }
    IEnumerator Green()
    {
        greenMeshRenderer.material.color = Color.green;

        yield return new WaitForSeconds(1);
        greenMeshRenderer.material.color = Color.black;


        yield return Red();
    }

    // 실습 2. 공급실린더A 전,후진 후 송출실린더B 전,후진
    // 조건 : 모든 시퀀스 작동시간은 1초
    // Vector3.Lerp 사용

    IEnumerator MoveCylinders(Transform cylinder, Vector3 positionA, Vector3 positionB, float duration)
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

        // 1. 실린더 A를 A_end로 이동 전진
        yield return MoveCylinders(cylinderA, cylinderA_start.position, cylinderA_end.position, 1);

        // 2. 실린더 A를 A_start로 이동 후진
        yield return MoveCylinders(cylinderA, cylinderA_end.position, cylinderA_start.position, 1);

        // 3. 실린더 B를 B_end로 이동 전진
        yield return MoveCylinders(cylinderB, cylinderB_start.position, cylinderB_end.position, 1);

        // 4. 실린더 B를 B_start로 이동 후진
        yield return MoveCylinders(cylinderB, cylinderB_end.position, cylinderB_start.position, 1);
    }


}


