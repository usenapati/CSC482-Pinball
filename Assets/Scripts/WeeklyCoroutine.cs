using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeeklyCoroutine : MonoBehaviour
{

    [Header("Final Values for GameManager")]
    public int currentDeduction;                //the current value of the weekly deduction to be subtracted from the player's score
    public string deductionDescription = "";    //the description of the deduction
    public int currentWeek;

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
    //private bool running = true;

    private void Start()
    {
        currentWeek = 1;
        //startWeeklyCoroutine();
    }
    public void startWeeklyCoroutine()          //this method can be called to start the coroutine
    {
        StartCoroutine(weeklyCoroutine(null));
    }

    public void stopWeeklyCoroutine()           //stops the runnint coroutine    
    {
        //running = false;
        StopAllCoroutines();
    }

    IEnumerator weeklyCoroutine(Transform target)
    {
        yield return new WaitForSeconds(weekTimer);
        while (true)
        {
            switch (currWeek)
            {
                case 1:
                    weekOne();
                    currentWeek = 1;
                    currWeek++;
                    break;
                case 2:
                    weekTwo();
                    currentWeek = 2;
                    currWeek++;
                    break;
                case 3:
                    weekThree();
                    currentWeek = 3;
                    currWeek++;
                    break;
                case 4:
                    weekFour();
                    currentWeek = 4;
                    currWeek = 1;
                    break;
            }
            SoundManager.Instance.playCoinClink();
            GameManager.Instance.deductWeeklyPlayerScore(currentDeduction, deductionDescription, currWeek);
            yield return new WaitForSeconds(weekTimer);
        }
    }

    private void weekOne()
    {
        Debug.Log("deducting week one cost");
        currentDeduction = rent;
        deductionDescription = rentDesc;
    }

    private void weekTwo()
    {
        Debug.Log("deducting week two cost");
        currentDeduction = insurance;
        deductionDescription = insuranceDesc;
    }

    private void weekThree()
    {
        Debug.Log("deducting week three cost");
        currentDeduction = groceries;
        deductionDescription = groceriesDesc;
    }

    private void weekFour()
    {
        Debug.Log("deducting week four cost");
        currentDeduction = carPayment;
        deductionDescription = carPaymentDesc;
    }

}
