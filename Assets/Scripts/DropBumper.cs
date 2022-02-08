using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropBumper : MonoBehaviour
{

    public float forceAmount = 35f;

    public float dropSpeed = 10f;

    public bool respawn = false;

    private bool hit = false;
    private Vector3 targetPos;
    private Vector3 originalPos;

    public int hitCounter = 0;

    public void resetCounter()
    {
        hitCounter = 0;
    }

    void Start()
    {
        hitCounter = 0;
        originalPos = transform.position;
        targetPos = new Vector3(transform.position.x, transform.position.y - 10, transform.position.z);
    }

    void FixedUpdate()
    {
        if (hit)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPos, dropSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, originalPos, dropSpeed * Time.deltaTime);
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("Colliding");
        if (other.gameObject.CompareTag("Ball"))
        {
            Debug.Log("Explosion Force");
            other.rigidbody.AddExplosionForce(forceAmount, transform.position, 3f, 0, ForceMode.Impulse);
            hit = true;
            GameManager.Instance.addScore(1);

            if (respawn)
            {
                StartCoroutine("Respawn");
            }
        }
    }

    IEnumerator Respawn()
    {
        yield return new WaitForSeconds(30);
        hit = false;
    }
}
