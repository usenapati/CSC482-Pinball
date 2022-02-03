using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomPowerup : MonoBehaviour
{
    public int numRandomPowerUps;

    [Header("Values to be used for Game Manager")]
    public int currentPowerUpValue;
    public string currentPowerUpDesc = "";

    [Header("Power Up Manager")]
    public GameObject powerUpManager;

    [Header("PowerUps")]
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

    private List<GameObject> powerUpList;
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
            PowerUp script = pu.GetComponent<PowerUp>();
            PowerUpManager manager = powerUpManager.GetComponent<PowerUpManager>();
            manager.currentValueOfPowerUp = script.amount;
            manager.currentDescOfPowerUp = script.powerUpDesc;    
            manager.isDebuf = true;
            
        }
    }
}
