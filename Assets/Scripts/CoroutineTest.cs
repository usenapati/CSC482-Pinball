using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class CoroutineTest : MonoBehaviour
{

    public Text scoreObj;

    public float weekTimer;
    public int startScore;
    public int insurance;
    public int rent;
    public int groceries;
    public int carPayment;

    private int numWeeks = 4;
    private int currWeek = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(weeklyCoroutine(null));
        scoreObj.text = "$" + startScore.ToString();
    }


    // Update is called once per frame
    void Update()
    {
        scoreObj.text = "$" + startScore.ToString();
    }

    IEnumerator weeklyCoroutine(Transform target)
    {
        yield return new WaitForSeconds(10f);
        while (true)
        {
            switch (currWeek)
            {
                case 1:
                    weekOne();
                    currWeek++;
                    break;
                case 2:
                    weekTwo();
                    currWeek++;
                    break;
                case 3:
                    weekThree();
                    currWeek++;
                    break;
                case 4:
                    weekFour();
                    currWeek = 1;
                    break;
            }
            yield return new WaitForSeconds(weekTimer);
        }
    }

    private void weekOne()
    {
        startScore = startScore - rent;
        scoreObj.text = "$" + startScore.ToString();
    }

    private void weekTwo()
    {
        startScore = startScore - groceries;
        scoreObj.text = "$" + startScore.ToString();
    }

    private void weekThree()
    {
        startScore = startScore - insurance;
        scoreObj.text = "$" + startScore.ToString();
    }

    private void weekFour()
    {
        startScore = startScore - carPayment;
        scoreObj.text = "$" + startScore.ToString();
    }

}
