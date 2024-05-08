using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.Xml;
using TMPro;
using UnityEngine;

public class IfStudy : MonoBehaviour
{
    public TMP_Text maintxt;
    public TMP_Text subTxt;

    bool isOperClicked = false;
    bool isCalculated = false;  

    private void Start()
    {

    }

    int Add(int inputA, int inputB)
    {
        return inputA + inputB;
    }
    float Subtract(float inputA, float inputB)
    {
        return (inputA - inputB);
    }

    public void OnNumBtnClkEvent(string num)
    {
        if (isOperClicked)
        {
            maintxt.text = "";
            isOperClicked = false;
        }
        maintxt.text += num;
    }
    public void OnOperBtnClkEvent(string oper)
    {
        isOperClicked = true;
        subTxt.text += $"{maintxt.text} {oper}";




    }

    public void OnCalBtnClkEvent(string cal)
    {
        isCalculated = true;

        subTxt.text += maintxt.text;

        char[] opers = { '+', '-' , 'X' , '/'};
        string[] strings = subTxt.text.Split(opers);
        double[] numbers = new double[strings.Length];

        for(int i = 0; i < strings.Length; i++)
        {
            numbers[i] = double.Parse(strings[i]);
        }

        double result = numbers[0];

    }
}
/*
enum Options
{
    BookName,
    Author,
    Location 
}

Options options = Options.Location;
// Start is called before the first frame update
void Start()
{
    if(options == Options.BookName)
    {

    }

    if(options == Options.Location)
    {

    }

    else
    {

    }

    if()
}

*/
