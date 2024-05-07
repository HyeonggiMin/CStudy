using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnumerationStudy : MonoBehaviour
{
    // Short, Tall, Grande, Venti
    // CoffeeSize: small medium large
    // ErrorCode

    enum ErrorCode
    {
        NullReferenceException,
        ArrayOutOfBoundsException
    }
    enum CoffeeSize
    {
        Short,
        Tall,
        Grande,
        Venti
    }

    // Template
    enum Days
    {
        Monday,
        Tuesday,
        Wendnesday,
        Thursday,
        Friday,
        Saturday,
        Sunday
    }

    Days day = Days.Monday;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space)) 
        {
            switch (day)
            {
                case Days.Monday:
                    break;
                case Days.Tuesday:
                    break;
                case Days.Wendnesday:
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
