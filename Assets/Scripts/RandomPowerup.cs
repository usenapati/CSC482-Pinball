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

    public int rotateSpeed;
    public float spinTime;
    public int RespawnTime;

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
    private bool spinning;
    // Start is called before the first frame update
    void Start()
    {
        powerUpList = new List<GameObject>();
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
        Debug.Log(powerUpList.ToString());
        spinning = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spinning)
        {
            float x = Random.Range(-15, 90);
            float y = Random.Range(-15, 90);
            float z = Random.Range(-15, 90);
            //transform.GetComponent<Rigidbody>().AddTorque(new Vector3(x, y, z), ForceMode.Impulse);
            transform.Rotate(new Vector3(x, y, z) * rotateSpeed * Time.deltaTime);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            Debug.Log("inside trigger enter");
            StartCoroutine("powerUpCoroutine");
        }
    }

    IEnumerator powerUpCoroutine()
    {
        Debug.Log("made it to coroutine");
        spinning = true;
        yield return new WaitForSeconds(spinTime);
        spinning = false;
        Debug.Log("made it past first wait");
        int powerUP = Random.Range(0, numRandomPowerUps);
        //Debug.Log("random int value: " + );
        GameObject pu = powerUpList[powerUP];
        PowerUp script = pu.GetComponent<PowerUp>();
        Debug.Log("Script values: " + script.amount + " " + script.powerUpDesc);
        PowerUpManager manager = powerUpManager.GetComponent<PowerUpManager>();
        currentPowerUpValue = script.amount;
        currentPowerUpDesc = script.powerUpDesc;
        
        manager.currentValueOfPowerUp = script.amount;
        manager.currentDescOfPowerUp = script.powerUpDesc;
        manager.isDebuf = script.debuf;

        GetComponent<Collider>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;

        yield return new WaitForSeconds(RespawnTime);

        GetComponent<Collider>().enabled = true;
        GetComponent<MeshRenderer>().enabled = true;
    }
}
