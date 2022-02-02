using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GameManager : MonoBehaviour
{
    [Header("Score is saved with this name")]
    public string BestScoreName = "BestScore";


    private bool paused = false;

    // Gameplay Variables
    [Header("Player Life and Score")]
    public int Lives = 3;                       // Max Lives
    private int currentLives = 0;               // Current Lives
    private int playerScore = 0;                // Player Score
    private int numBall;                        // The number of ballss played by the player
    private bool startGame;                     // True : Player start the game . False : Game is over

    [Header("Tilt Mode")]
    public float minTimeTilt = 1;	            // Minimum time in seconds between two shake
    private float tiltTimer = 0; 		        // Timer to know if we need to start tilt mode
    private int tilts = 0;				        // 0 : Tilt Deactivate	 	1 : Player shakes the playfield			2 : Tilt Mode Enable  


    [Header("Mode Multi Ball")]
    public GameObject objMultiBall;             // Object that manage the multi-ball on playfield. Manage how the ball is ejected on playfield
    public MultiBall multiBall;                 // Access MultiBall component from obj_Launcher_MultiBall gameObject;
    private int ballsOnBoard = 0;               // Know the number of board. 
    private bool mutiBallState = false;         // Mode Multi ball activate or not
    private int maxBallsSpawn = 3;              // Number of Balls in muti ball mode

    [Header("Bonus Extra Ball")]
    public bool extraBall = false;

    [Header("Bonus Ball Saver")]
    public bool startGameWithBallSaver = false; // If true : player start a new ball with BallSaver
    public int startDuration = -1;
    public bool ballSaver = false;              // True : Ball Saver is enabled

    [Header("Bonus Multiplier")]                // Bonus Multiplier = multiplier x hitCounter + mulitplierSuperBonus)
    public int multiplier = 1;                  // multiplier could be x1 x2 x4 x6 x 8 x10							
    public int mulitplierSuperBonus = 1000000;  // Add points if multiplier = 10
    public int hitCounter = 0;                  // Record the number of object that hit the ball during the current ball



    // UI



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // START STATE
    public void startState()
    {

    }

    // PAUSE MODE
    public void pauseState()
    {

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
