using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plunger : MonoBehaviour
{
    public float plungerSpeed = 50000;
    public GameObject ball;
    // Start is called before the first frame update
    void Start()
    {
        //ball.transform.position = this.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPlunger()
    {
        if (GameManager.Instance.e_gameState == GameManager.gameState.pullPlungerState)
        {
            ball.SetActive(true);



            // set ball position to location of plunger
            ball.transform.position = this.transform.position;

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            SoundManager.Instance.playPlunger();
            rb.AddForce(movement * plungerSpeed);
            GameManager.Instance.pulledPlunger();
            Debug.Log("Pulled Plunger");

        }
    }
}
