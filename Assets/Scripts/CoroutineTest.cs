using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineTest : MonoBehaviour
{
    public float weekTimer = 45;
    public int insurance;
    public int rent;
    public int groceries;

    private int numWeeks = 4;
    private int currWeek = 1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(weeklyCoroutine(null));
    }

    // Update is called once per frame
    void Update()
    {
        
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
        Debug.Log("Deduct cost from total for Week one expenses");
    }

    private void weekTwo()
    {
        Debug.Log("Deduct cost from total for Week two expenses");
    }

    private void weekThree()
    {
        Debug.Log("Deduct cost from total for Week three expenses");
    }

    private void weekFour()
    {
        Debug.Log("Deduct cost from total for Week four expenses");
    }

}
