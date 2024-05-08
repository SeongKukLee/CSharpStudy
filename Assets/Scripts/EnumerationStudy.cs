using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enumeration : MonoBehaviour
{
    enum ErrorCode
    {
        NullReferenceExcepotion,
    }
    enum CoffeeSize
    {
        tall,
        grande,
        Venti,
    }
    enum Days
    {
        Monday,
        Tuesday, 
        Wednesday,
        Thursday,
        Friday,
        Saturday,
        Sunday,
    }

    Days day = Days.Monday;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            switch(day)
            {
                case Days.Monday:
                    break;
                case Days.Tuesday:
                    break;
                case Days.Wednesday:
                    break;
                case Days.Thursday:
                    break;
                case Days.Friday:
                    break;
                case Days.Saturday:
                    break;
                case Days.Sunday:
                    break;


            }

        }
    }
}
