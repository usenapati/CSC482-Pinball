using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Score is saved with this name")]
    public string BestScoreName = "BestScore";


    private bool b_paused = false;

    // Gameplay Variables
    [Header("Game Objects")]
    [Header("Ball")]
    public GameObject ball;                      // Connect the ball Prefab

    [Header("Plunger")]
    private GameObject spawnBall;               // (connected automatically) The GameObject that manage the ejection after a ball respawn
    public GameObject plunger;

    [Header("Drain")]
    public GameObject drain;

    // Flippers
    [Header("Flippers")]
    public GameObject[] flippers;

    // Bumpers
    [Header("Bumpers")]
    public GameObject[] bumpers;


    [Header("Player Life and Score")]
    public int Lives = 3;                       // Max Lives
    private int weeksCompleted = 0;             // Track weeks the player has completed
    private int currentLives = 0;               // Current Lives
    private int roundScore = 0;                 // Score during a round
    private int playerScore = 0;                // Player Score
    private int numBall;                        // The number of ballss played by the player
    private bool b_startGame;                   // True : Player start the game . False : Game is over

    [Header("Coroutine Manager")]
    GameObject CoroutineManager;                // Update GameObject to class

    [Header("Tilt Mode")]
    public float minTimeTilt = 1;	            // Minimum time in seconds between two shake
    private float tiltTimer = 0; 		        // Timer to know if we need to start tilt mode
    private int tilts = 0;				        // 0 : Tilt Deactivate	 	1 : Player shakes the playfield			2 : Tilt Mode Enable  

    [Header("Mode Multi Ball")]
    public GameObject obj_MultiBall;             // Object that manage the multi-ball on playfield. Manage how the ball is ejected on playfield
    public MultiBall multiBall;                 // Access MultiBall component from obj_Launcher_MultiBall gameObject;
    private int ballsOnBoard = 0;               // Know the number of board. 
    private bool b_mutiBallState = false;         // Mode Multi ball activate or not
    private int maxBallsSpawn = 3;              // Number of Balls in muti ball mode

    [Header("Bonus Extra Ball")]
    public bool extraBall = false;

    [Header("Bonus Ball Saver")]
    public bool b_startGameWithBallSaver = false; // If true : player start a new ball with BallSaver
    public int startDuration = -1;
    public bool b_ballSaver = false;              // True : Ball Saver is enabled

    [Header("Bonus Multiplier")]                // Bonus Multiplier = multiplier x hitCounter + mulitplierSuperBonus)
    public int multiplier = 1;                  // multiplier could be x1 x2 x4 x6 x 8 x10							
    public int mulitplierSuperBonus = 1000000;  // Add points if multiplier = 10
    public int hitCounter = 0;                  // Record the number of object that hit the ball during the current ball

    [Header("Ball Lost")]
    // Ball Out
    public float timeBallout = 2;               // Duration of ball lost
    private float tmpBalloutTime = 0;
    // Bonus Calculation 
    // Next Ball or Game Over

    // UI
    [Header("UI ")]
    [Header("Board Text")]
    private Text GUI_Txt_Timer;
    private Text GUI_Txt_Info_Ball;
    private Text GUI_Txt_Score;

    // Use to display text on LCD screen
    public string[] arr_Info_Txt;
    private float tmp_Time;
    private float TimeBetweenTwoInfo;
    private bool b_Txt_Info = true;

    [Header("Text used during game")]
    public string[] Txt_Game;                   // Array : All the text use by the game Manager



    // SFX
    [Header("Audio : Sfx")]
    private AudioSource sound;
    public AudioClip s_Load_Ball;					// play a sound when the ball respawn
    public AudioClip a_LoseBall;                // Play a sound when the player lose a ball
    public AudioClip a_Bonus_Screen;			// Play a sound during the bonus score 
    public AudioClip a_GameOver;			    // Play a sound during the bonus score 
    

    



    // Start is called before the first frame update
    void Start()
    {
        // Find all Game Objects

        // Set Active to false on Game Objects


        // Play Audio

    }

    // Update is called once per frame
    void Update()
    {

    }

    // START STATE
    public void startState()
    {
        // Reset Scores and Lives
    }

    // PAUSE MODE
    public void pauseState()
    {
        // Set TimeScale to 0
        // Open UI
    }
    public void unpauseState()
    {
        // Set TimeScale to 1
        // Open UI
    }

    // GAMEPLAY
    public void gamePlayState()
    {

    }

    public void multiBallState()
    {

    }

    // GAME OVER STATE
    public void gameOverState()
    {

    }

    // DEBUG
    public void debugPauseState()
    {

    }
}
