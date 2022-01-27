using UnityEngine;


public class BallController : MonoBehaviour
{

    public float speed;
    public AudioSource audioPlayer;
    public AudioClip bounceClip;
    // Create private references to the rigidbody component on the ball
    private Rigidbody rb;


    // At the start of the game..
    void Start()
    {
        // Assign the Rigidbody component to our private rb variable
        rb = GetComponent<Rigidbody>();

        audioPlayer = GetComponent<AudioSource>();
    }

    // Each physics step..
    void FixedUpdate()
    {

    }

    void OnCollisionEnter(Collision myCollision)
    {

        Debug.Log(myCollision.relativeVelocity.magnitude);
        //only generate collision sound on harder hits
        if (myCollision.relativeVelocity.magnitude > 10)
        {
            audioPlayer.PlayOneShot(bounceClip);
        }
    }
}