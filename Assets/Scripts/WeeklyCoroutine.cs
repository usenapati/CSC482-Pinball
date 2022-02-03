using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyCoroutine : MonoBehaviour
{

    [Header("Final Values for GameManager")]
    public int currentDeduction;                //the current value of the weekly deduction to be subtracted from the player's score
    public string deductionDescription = "";    //the description of the deduction

    [Header("Values for weekly deductions")]
    public float weekTimer;                     //the amount of time a week will last
    public int insurance;                       //the dollar amount that the insurance cost will deduct
    public string insuranceDesc;                //the description for insurance
    public int rent;                            //the dollar amount for the rent
    public string rentDesc;                     //the description for rent
    public int groceries;                       //the dollar amount for groceries
    public string groceriesDesc;                //the description for groceries
    public int carPayment;                      //the dollar amount for the car payment
    public string carPaymentDesc;               //the description for the car payment

   
    private int numWeeks = 4;                   //the number of weeks in a month
    private int currWeek = 1;                   //the current week we are on

    public void startWeeklyCoroutine()          //this method can be called to start the coroutine
    {
        StartCoroutine(weeklyCoroutine(null));
    }

    public void stopWeeklyCoroutine()           //stops the runnint coroutine    
    {
        StopCoroutine(weeklyCoroutine(null));
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
        currentDeduction = rent;
        deductionDescription = rentDesc;
    }

    private void weekTwo()
    {
        currentDeduction = insurance;
        deductionDescription = insuranceDesc;
    }

    private void weekThree()
    {
        currentDeduction = groceries;
        deductionDescription = groceriesDesc;
    }

    private void weekFour()
    {
        currentDeduction = carPayment;
        deductionDescription = carPaymentDesc;
    }

}
