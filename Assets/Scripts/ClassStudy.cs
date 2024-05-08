using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Person
{
    public string name; // 필드, 변수 
    public int age;
    public int id;

    public Person(string name, int age, int id) // 생성자 만들기
    {
        // 접근 제어자, 한정자, 지정자, public, private, protected -> 캡슐화(은닉, 보안, 안정성) 
        this.name = name;
        this.age = age;
        this.id = id;
    }

    // 메서드 -> 다형성 
    // 접근지정자(public), 리턴형(void), 클래스 이름(Speak)

    public void Speak()
    {

    }

    public string Speak(string message) // 메서드 오버로드 - 다형성의 예 
    {
        return message; //print(p1.Speak("Hello")); -> Hello를 리턴.  
    }
}

public class Vehicle
{


    public void Honk()
    {

    }
}



public class Bus : Vehicle
{
    public void Accelerate()
    {
        this.Honk();
    }
}

public class Truck : Vehicle
{
    public void Accelerate()
    {
        this.Honk();
    }
}

public class Car
{
    public string carNumber;
    public DateTime date;

    public Car(string carNumber, DateTime date)
    {
        this.carNumber = carNumber;
        this.date = date;
    }
}

public class ParkingLot
{
    List<Car> cars = new List<Car>();

    public void InCar(string carNumber) // parkingLot.InCar("5555");  -> 5555가 들어옴 
    {
        if (carNumber == "") //예외처리
        {
            Debug.Log("자동차 번호를 입력해주세요");
            return;
        }

        Car car = new Car(carNumber, DateTime.Now); // Car 정보 객체 만들기 

        cars.Add(car); // InCar 메서드가 실행될때 마다 cars 리스트에 들어가게 된다. 
    }

    public void OutCar(string carNumber)
    {
        if (carNumber == "")
        {
            Debug.Log("자동차 번호를 입력해주세요");
            return;
        }
        Car carFound = cars.Find(x => x.carNumber == carNumber);
        if (carFound == null)
            return;

        cars.Remove(carFound);

    }

    public void ShowCarList()
    {
        string carInfo = "";

        foreach (Car car in cars) // cars 리스트를 순회하여 car 클래스 car에 디버그 시킨다.  
        {
            carInfo += car.carNumber + "," + car.date + "\n";
        }
        Debug.Log(carInfo);
    }
}

// C#에서는 단일 상속만 가능. 
public class ClassStudy : MonoBehaviour // MonoBehaviour(부모 클래스) 를 상속받은 ClassStudy(하위 클래스) 
{
    // 1. 데이터를 저장하기 위한 컨테이너
    // 2. 기능을 정의하기 위해 사용 (캡슐화, 상속, 추상화, 다형성)
    // 3. 상속의 장점: 코드의 재사용, 유지보수가 편하다, 다형성 구현할 수 있다. 

    [SerializeField] TMP_InputField vehicleNumberInput;
    [SerializeField] Button registerBtn;
    [SerializeField] Button outBtn;

    ParkingLot parkingLot;
    void Start()
    {
        //클래스 예시 
        /*
        // 클래스의 인스턴싱, 객체화
        Person p1 = new Person("이성국", 20, 1);
        //p1.name = "이성국"; // 필드에 값을 대입. 
        //p1.age = 20;
        print(p1.Speak("Hello"));

        Car car = new Car(); // new 키워드로 메모리 상에 올려둘 수 있음. 
        */

        // 실습2. 주차장 관리시스템
        // 1. Car 클래스 정의 -> 차량번호, 입차시간을 필드로 가지는 클래스

        // 2. ParkingLot 클래스 -> Car 클래스를 넣을 수 있는 컬랙션 (List or Queue or Stack) 으로 자동차를 관리 
        //                     -> 차량 입차(메서드), 출차 기능(메서드), 현재 주차된 차량 목록 출력 기능(메서드)

        // 순서1. 플레이버튼 눌렀을 때 Start 함수에서 ParkingLot 클래스 할당 (new)
        parkingLot = new ParkingLot();
        parkingLot.InCar("5555");
        parkingLot.ShowCarList();


        // 순서2. 등록 버튼 클릭시 클릭 이벤트 메서드 실행 -> ParkingLot 클래스의 차량 입차 메서드 실행 -> input의 내용 기반 차량 등록
        // 순서3. 등록 버튼 클릭시 현재 주차된 차량 목록 출력 (Update)
        // 순서4. 출차 버튼 클릭시 현재 주차된 차량 목록에서 해당 내용 제거. 

        // 차량 입차 메서드 : 5138 입력 후 등록버튼 클릭시 실행, 차량번호, 입차시간을 가지고 있는 Car 클래스 new 키워드로 만든다. 


        // UI: 52가5345와 같이 차 번호를 input field에 입력시, 번호와 입차시간을 가지는 컬렉션이 생성
        // -> ParkingLot 객체에 저장 


    }

    public void OnRegisterBtnClkEvent()
    {
        if (parkingLot == null)
        {
            print("parkingLot을 만들어주세요.");
            return;
        }

        parkingLot.InCar(vehicleNumberInput.text);
        parkingLot.ShowCarList();
    }
    public void OutCarBtnClkEvent()
    {
        if (parkingLot == null)
        {
            print("parkingLot을 만들어주세요.");
            return;
        }

        parkingLot.InCar(vehicleNumberInput.text);
        parkingLot.ShowCarList();
    }


}