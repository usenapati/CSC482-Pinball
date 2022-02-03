using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomPowerup : MonoBehaviour
{
    public int numRandomPowerUps;
    List<GameObject> powerUpList;

    public GameObject netflix;
    public GameObject flatTire;
    public GameObject birthdayPresent;
    public GameObject doctorsVisit;
    public GameObject newPhone;
    public GameObject birthdayMoney;
    public GameObject christmasBonus;
    public GameObject sidewalkMoney;
    public GameObject taxReturn;
    public GameObject lawsuitWin;


    // Start is called before the first frame update
    void Start()
    {
        powerUpList.Add(netflix);
        powerUpList.Add(birthdayMoney);
        powerUpList.Add(flatTire);
        powerUpList.Add(christmasBonus);
        powerUpList.Add(sidewalkMoney);
        powerUpList.Add(birthdayPresent);
        powerUpList.Add(taxReturn);
        powerUpList.Add(doctorsVisit);
        powerUpList.Add(lawsuitWin);
        powerUpList.Add(newPhone);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            transform.rotation = Random.rotation;
            int powerUP = Random.Range(0, numRandomPowerUps);
            GameObject pu = powerUpList[powerUP];
        }
    }
}
