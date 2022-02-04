using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{

    [Header("The end point of the teleporter")]
    public GameObject destination;

    [Header("Amount of time the teleport will take before the ball reapears")]
    public float teleportDelay;

    [Header("Force Modifiers")]
    public float forceAmount;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ball"))
        {
            other.gameObject.GetComponent<MeshRenderer>().enabled = false;
            other.transform.position = destination.transform.position;
            other.transform.rotation = destination.transform.rotation;
            new WaitForSeconds(teleportDelay);
            other.gameObject.GetComponent<MeshRenderer>().enabled = true;
            other.GetComponent<Rigidbody>().AddForce(transform.forward * forceAmount, ForceMode.Impulse);
        }
    }
}
