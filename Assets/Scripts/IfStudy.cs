using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class IfStudy : MonoBehaviour
{
    public TMP_Text mainTxt;
    public TMP_Text subTxt;
    bool isOperClicked = false;
    private void Start()
    {
        mainTxt.text = string.Empty;
        subTxt.text = string.Empty; 
    }
    

    /* If 연습
     * enum Options
        {
            BookName,
            Author,
            Location
        }

        Options option = Options.Location;
        int number = 5;

        void Start()
        {
            if (option == Options.BookName)
            {

            }

            // 위 조건 이후에 실행되는 기능

            if (option == Options.Location)
            {

            }
            else
            {

            }

            if(number > 10)
            {

            }
            else  if (number < 10)
            {
                // 기능
            }
            else if(number >= 5 && number <= 8)
            {

            }

            switch (number)
            {
                case 0:
                    break;
                case 10:
                    break;
            }
        }*/

    double Add(int inputA, int inputB)
    {
        return inputA + inputB; 
    }

    double Subtract(int inputA, int inputB)
    {
        return inputA - inputB;
    }

    public void OnNumBtnClkEvent(string num)
    {
        if (isOperClicked)
        {
            mainTxt.text = string.Empty;
            isOperClicked = false;
        }
        mainTxt.text += num;
    }

    public void OnOperClkEvent(string oper)
    {
        isOperClicked =  true;
        subTxt.text += $"{mainTxt.text} {oper}";
    }

    public void OnCalBtnClkEvent()
    {
        // 문자열을 연산자 기준으로 나눠서
        // ex) 123 + 456 -> 123, +, 456
        double.Parse(mainTxt.text);
    }
}
