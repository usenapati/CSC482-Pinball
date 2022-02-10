using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class GameManager : MonoBehaviour
{
    private static GameManager _instance;
    public static GameManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("Game Manager is NULL");
            }
            return _instance;
        }
    }

    private void Awake()
    {
        SoundManager.Instance.playGameMusic();
        _instance = this;
    }

    public enum gameState
    {
        startGameState,                         // Reset points, lives, multiplier, ball save, etc. -> startRoundState
        startRoundState,                        // Reset multiplier, ball save/extra save, tilt, multiball. -> pullPlungerState
        pullPlungerState,                       // Wait for player to pull plunger. -> playRoundState
        playRoundState,                         // Start round, update score, check if balls = 0. -> endRoundState || -> pauseState
        endRoundState,                          // Life - 1, check if life >= 0. -> startRoundState || -> endGameState
        endGameState,                           // Calculate final score, option to buy ball with scalinng costs(Life + 1). -> startRoundState || startGameState || Exit Game

    }

    [Header("Score is saved with this name")]
    public string highScoreName = "BestScore";
    public int highScore = 0;


    //private bool b_paused = false;
    private bool b_playerResponse = false;      // Updates when the player presses a button
    public gameState e_gameState = gameState.startGameState;

    // Gameplay Variables
    [Header("Game Objects")]
    [Header("Ball")]
    public GameObject ball;                      // Connect the ball Prefab

    [Header("Plunger")]
    public GameObject spawnBall;               // (connected automatically) The GameObject that manage the ejection after a ball respawn
    public GameObject plunger;
    public bool b_pullPlunger = false;         // Has the player pulled the plunger

    [Header("Drain")]
    public GameObject drain;

    // Flippers
    [Header("Flippers")]
    public GameObject[] flippers;

    // Bumpers
    [Header("Bumpers")]
    public GameObject[] bumpers;

    // Targets
    [Header("Targets")]
    public GameObject[] targets;

    // Round Info
    [Header("Round Info")]
    // Start Game Variables
    public bool roundStart = false;
    public int currentRound = 0;               // Current Round

    // End Game Variables
    public bool buyBall = false;               // Does the player want to buy a ball after the rounds are over
    public int ballCost = 100;
    public bool b_newGame = false;             // bool val for button clicks
    public bool b_exitGame = false;


    [Header("Player Life and Score")]
    public static int Lives = 3;                // Max Lives
    public int currentLives = 3;               // Current Lives
    private int weeksTimer = 1;                 // Track weeks the player has completed
    //public List<int> roundScore;               // Score during a round
    private int playerScore = 0;                // Player Score
    public int numBall = 0;                    // The number of balls played by the player
    public bool b_startGame = false;           // True : Player start the game . False : Game is over

    [Header("Coroutine Manager")]
    public GameObject CoroutineManager;                // Update GameObject to class

    [Header("Tilt Mode")]
    public float minTimeTilt = 1;	            // Minimum time in seconds between two shake
    private float tiltTimer = 0; 		        // Timer to know if we need to start tilt mode
    private int tilts = 0;				        // 0 : Tilt Deactivate	 	1 : Player shakes the playfield			2 : Tilt Mode Enable  

    [Header("Mode Multi Ball")]
    public GameObject obj_MultiBall;            // Object that manage the multi-ball on playfield. Manage how the ball is ejected on playfield
    public MultiBall multiBall;                 // Access MultiBall component from obj_Launcher_MultiBall gameObject;
    public int ballsOnBoard = 0;               // Know the number of board. 
    private bool b_mutiBallState = false;       // Mode Multi ball activate or not
    private int maxBallsSpawn = 3;              // Number of Balls in muti ball mode

    [Header("Bonus Extra Ball")]
    public bool b_extraBall = false;

    [Header("Bonus Ball Saver")]
    public bool b_ballSaver = false;            // True : Ball Saver is enabled
    public int startDuration = -1;


    [Header("Bonus Multiplier")]                // Bonus Multiplier = multiplier x hitCounter + mulitplierSuperBonus)
    public int multiplier = 10;                  // multiplier could be x1 x2 x4 x6 x 8 x10							
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
    public TextMeshProUGUI GUI_Txt_Timer;                 // Week Timer
    public TextMeshProUGUI GUI_Txt_Info_Event;            // Events
    public TextMeshProUGUI GUI_Txt_Info_Cost;             // Event Cost
    public TextMeshProUGUI GUI_Txt_Score;                 // Score
    public TextMeshProUGUI GUI_Txt_Lives;                 // Lives
    public TextMeshProUGUI GUI_Txt_BuyBallCost;                 // Lives
    public GameObject GUI_Game_Over;

    [Header("Button")]
    public Button btn_BuyBall;

    // Use to display text on LCD screen
    public string[] arr_Info_Txt;               // Store Events
    private float tmp_Time;
    private float TimeBetweenTwoInfo;           // Revert Text after timer is over
    private bool b_Txt_Info = true;             

    [Header("Text used during game")]
    public string[] Txt_Game;                   // Array : All the text use by the game Manager



    // SFX
    [Header("Audio : Sfx")]
    private AudioSource sound;
    public AudioClip a_LoadBall;				// play a sound when the ball respawn
    public AudioClip a_LoseBall;                // Play a sound when the player lose a ball
    public AudioClip a_BonusScreen; 			// Play a sound during the bonus score 
    public AudioClip a_GameOver;                // Play a sound during the bonus score 






    // Start is called before the first frame update
    void Start()
    {
        //roundScore = new List<int>(Lives);

        // Find all Game Objects and Managers
        // Coroutine Manager
        CoroutineManager.GetComponent<WeeklyCoroutine>();
        // Ball
        // Flippers
        flippers = GameObject.FindGameObjectsWithTag("Flipper");
        // Bumpers
        bumpers = GameObject.FindGameObjectsWithTag("Bumper");
        // Plunger 
        //plunger = GameObject.FindGameObjectWithTag("Plunger");
        //plunger.GetComponent<Plunger>().enabled = false;

        // Set Active to false on Game Objects (???)

        // Play Audio

        e_gameState = gameState.startGameState;
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(e_gameState);
        switch (e_gameState)
        {
            // State Machine Loop
            case gameState.startGameState:
                startGameState();
                break;
            case gameState.startRoundState:
                startRoundState();
                break;
            case gameState.pullPlungerState:
                pullPlungerState();
                break;
            case gameState.playRoundState:
                playRoundState();
                break;
            case gameState.endRoundState:
                endRoundState();
                break;
            case gameState.endGameState:
                endGameState();
                break;
            default:
                break;
        }
    }

    // START STATE
    private void startGameState()
    {
        // Reset Scores, Multiplier, and Lives
        currentRound = 0;
        playerScore = 0;
        //for (int i = 0; i < Lives; i++)
        //{
        //    roundScore.Add(0);
        //}
        weeksTimer = 0; // Set to WeeklyCoroutine.Week
        numBall = 0;
        multiplier = 10;
        hitCounter = 0;
        currentLives = 3;
        e_gameState = gameState.startRoundState;
    }
    private void startRoundState()
    {
        btn_BuyBall.gameObject.SetActive(false);
        GUI_Txt_BuyBallCost.gameObject.SetActive(false);
        // Reset Ball Save, Extra Ball, Multiball, Tilt
        ballsOnBoard = 0;
        roundStart = false;
        multiplier = 10;
        b_ballSaver = false;
        // Extra Ball
        b_mutiBallState = false;
        tilts = 0;
        // Enable Flippers
        foreach (GameObject flipper in flippers)
        {
            flipper.GetComponent<FlipperController>().enabled = true;
        }
        // Switch to Pull Plunger State
        b_pullPlunger = false;
        e_gameState = gameState.pullPlungerState;
    }

    // GAMEPLAY
    private void pullPlungerState()
    {
        // Spawn Ball

        // Enable Plunger
        //plunger.GetComponent<Plunger>().enabled = true;
        // When plunger is pulled, switch to Play Round State
        if (b_pullPlunger)
        {
            ballsOnBoard++;
            numBall++;
            e_gameState = gameState.playRoundState;
            b_pullPlunger = false;
            
        }
    }

    private void playRoundState()
    {
        Debug.Log("Play Round");
        if (!roundStart)
        {
            // Disable Plunger
            //plunger.GetComponent<Plunger>().enabled = false;

            // Start Coroutines
            CoroutineManager.GetComponent<WeeklyCoroutine>().startWeeklyCoroutine();
            roundStart = true;
        }

        // Check if Balls == 0
        if (ballsOnBoard > 0)
        {
            if (playerScore >= 0 || b_ballSaver)
            {
                // MAIN LOOP
                // Add Hit Counter to Global Hit Counter and Add to Round Score
                // Add Multiple to Hit Counter 

                // Add Expenses to Round Score
                

                // Check Multiball conditions (Add ball when true and set multiball bool to false)
                // Check Tilts

                // Update UI
                //playerScore = hitCounter * 10; // Multiplier
                
                
                GUI_Txt_Score.text = playerScore.ToString();
                GUI_Txt_Lives.text = currentLives.ToString();
            }
            else
            {
                // Check if money equals 0 after ball saver is false: True - Disable Flipper Movement False - Continue
                foreach (GameObject flipper in flippers)
                {
                    flipper.GetComponent<FlipperController>().enabled = false;
                }
            }
        }
        else
        {
            // Check Ball Save Timer
            if (b_ballSaver)
            {
                // Switch to Plunger State
                e_gameState = gameState.pullPlungerState;
            }
            else
            {
                // Switch to End Round State
                e_gameState = gameState.endRoundState;
            }
        }


    }


    // GAME OVER STATE
    private void endRoundState()
    {
        // Stop Coroutines
        // One time call
        

        GUI_Txt_Score.text = playerScore.ToString();
        GUI_Txt_Lives.text = currentLives.ToString();

        // Subtract Life

        // Check Life > 0: True - Next Round False - End Game
        if (currentLives <= 0)
        {
            
        }
        else
        {
            // Switch to Start Round State
            currentRound++;
            e_gameState = gameState.startRoundState;
        }
    }
    private void endGameState()
    {
        




    }

    // PAUSE MODE
    //public void pauseState()
    //{
    //}

    // DEBUG
    //public void debugPauseState()
    //{
    //}

    // EXIT GAME
    // UI MANAGER could use this
    public void ExitOnClick()
    {
        Debug.Log("Exit Button clicked");
#if UNITY_EDITOR
        // Application.Quit() does not work in the editor so
        // UnityEditor.EditorApplication.isPlaying need to be set to false to end the game
        UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
    }

    // Functions
    public void pulledPlunger()
    {
        Debug.Log("Pulled Plunger");
        b_pullPlunger = true;
        //e_gameState = gameState.playRoundState;
    }
    
    public void lostBall()
    {
        CoroutineManager.GetComponent<WeeklyCoroutine>().stopWeeklyCoroutine();
        Debug.Log("Fell into drain");
        ballsOnBoard--;
        if (ballsOnBoard <= 0)
        {
            currentLives--;
        }
        if (currentLives <= 0)
        {
            // Switch to End Game State
            e_gameState = gameState.endGameState;
            endGame();
        }
    }

    public void deductWeeklyPlayerScore(int val, string description, int weekNum)
    {
        playerScore -= val;
        GUI_Txt_Info_Event.text = description;
        GUI_Txt_Info_Cost.text = "-$" + val.ToString();
        GUI_Txt_Timer.text = weekNum.ToString();
    }
    
    public void deductRandomPlayerScore(int val, string description, bool debuff)
    {
        if (debuff)
        {
            playerScore -= val;
            GUI_Txt_Info_Cost.text = "-$" + val;
        }
        else
        {
            playerScore += val;
            GUI_Txt_Info_Cost.text = "+$" + val;
        }
        GUI_Txt_Info_Event.text = description;
        
    }

    public void addScore(int val)
    {
        playerScore += (int)Mathf.Ceil(val * multiplier); //not sure why had to cast here?
    }

    public void increaseMultiplier()
    {
        multiplier *= 2;
    }

    public void decreaseMultiplier()
    {
        multiplier /= 2;
    }

    public void BuyBall()
    {
        SoundManager.Instance.playCashRegister();
        playerScore -= ballCost;
        // If buy ball, then increase ball cost
        ballCost *= 2;
        currentLives++;
        currentRound++;
        GUI_Txt_Lives.text = currentLives.ToString();
        e_gameState = gameState.startRoundState;
    }

    public void endGame()
    {
        // Calculate Final Score
        //CoroutineManager.GetComponent<WeeklyCoroutine>().stopWeeklyCoroutine();
        GUI_Txt_Score.text = playerScore.ToString();
        GUI_Txt_Lives.text = currentLives.ToString();
        GUI_Game_Over.SetActive(true);
        

        // Compare Final Score to Best Score
        if (highScore < playerScore)
        {
            // Set Text to "New High Score"
            highScore = playerScore;
        }
        // Ask Player if they want to buy ball or save final score
        if (playerScore > ballCost)
        {
            GUI_Txt_BuyBallCost.text = "Ball Cost: $" + ballCost.ToString();
            btn_BuyBall.gameObject.SetActive(true);
            GUI_Txt_BuyBallCost.gameObject.SetActive(true);
        }
        else
        {
            // If save final score, ask Player if they want to start a new game or exit
            if (b_playerResponse && b_newGame)
            {
                e_gameState = gameState.startGameState;
                b_newGame = false;
            }
            else if (b_playerResponse && b_exitGame)
            {
                ExitOnClick();
            }
        }
    }
}
