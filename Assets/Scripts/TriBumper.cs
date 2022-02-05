using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriBumper : MonoBehaviour
{
    public float forceAmount = 30f;
    public int hitCounter = 0;

    private void Start()
    {
        hitCounter = 0;
    }

    public void resetCounter()
    {
        hitCounter = 0;
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Tri Collide");
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log ("APPLYING MASSIVE FORCE");
            other.rigidbody.AddForce(transform.right * forceAmount, ForceMode.Impulse);
            GameManager.Instance.hitCounter++;
        }
    }
}
