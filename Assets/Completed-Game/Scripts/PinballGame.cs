using UnityEngine;

// Include the namespace required to use Unity UI
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class PinballGame : MonoBehaviour
{

    public Text scoreText;
    public Text highScoreText;
    public Text winText;
    public Text ballsText;

    public int maxBalls = 3;
    public int score = 0;
    private int highscore = 0;

    public float plungerSpeed = 100;

    public AudioSource audioPlayer;
    public AudioClip plungerClip;
    public AudioClip soundtrackClip;
    public AudioClip gameoverClip;

    public KeyCode newGameKey;
    public KeyCode plungerKey;
    public KeyCode puzzlecameraKey;


    private int ballsLeft = 3;
    private bool gameOver = false;
    private GameObject ball;
    private GameObject plunger;
    private GameObject drain;

    private GameObject maincam;
    private GameObject puzzleCamera;

    // At the start of the game..
    void Start()
    {
        plunger = GameObject.Find("Plunger");
        drain = GameObject.Find("Drain");
        ball = GameObject.Find("Ball");
        maincam = GameObject.FindGameObjectWithTag("MainCamera");

        ball.SetActive(false);

        audioPlayer = GetComponent<AudioSource>();

        audioPlayer.loop = true;
        audioPlayer.clip = soundtrackClip;
        audioPlayer.volume = 0.3f;
        audioPlayer.Play(); 
    }

    void OnPlunger()
    {
        Debug.Log("Plunger");
        GameManager.Instance.pulledPlunger();
        Plunger();
    }

    void OnChangeCameras()
    {
        switchCamera();
    }

    private void Update()
    {

        //if (Input.GetKey(newGameKey) == true) NewGame();
        //if (Input.GetKey(plungerKey) == true) Plunger();
        //if (Input.GetKey(puzzlecameraKey) == true) switchCamera();

        // detect ball going past flippers into "drain"
        if ((ball.activeSelf == true) && (ball.transform.position.z < drain.transform.position.z))
        {
            ball.SetActive(false);
        }

    }

    void Plunger()
    {
        if ((ballsLeft > 0) && (ball.activeSelf == false))
        {
            ball.SetActive(true);

            Rigidbody rb = ball.GetComponent<Rigidbody>();
            Vector3 movement = new Vector3(0.0f, 0.0f, 1.0f);
            rb.AddForce(movement * plungerSpeed);

            // set ball position to location of plunger
            ball.transform.position = plunger.transform.position;
            ballsLeft = ballsLeft - 1;

            audioPlayer.PlayOneShot(plungerClip);
        }
    }

    void switchCamera()
    {

        if (maincam.activeSelf == true)
        {
            maincam.SetActive(false);
            puzzleCamera.SetActive(true);
        }
        else
        {
            puzzleCamera.SetActive(false);
            maincam.SetActive(true);

        }
    }
}


