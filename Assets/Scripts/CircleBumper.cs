using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBumper : MonoBehaviour
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
        //Debug.Log("Colliding");
        if (other.gameObject.CompareTag("Ball"))
        {
            //Debug.Log("Explosion Force");
            other.rigidbody.AddExplosionForce(forceAmount, transform.position, 3f, 0, ForceMode.Impulse);
            GameManager.Instance.hitCounter++;
        }
    }
}
