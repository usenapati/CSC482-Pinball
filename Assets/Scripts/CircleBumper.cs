using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleBumper : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colliding");
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Explosion Force");
            other.rigidbody.AddExplosionForce(30f, transform.position, 3f, 0, ForceMode.Impulse);
        }
    }
}
