using System.Collections.Generic; //this is necessary for when calling lists
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class GameManager : MonoBehaviour
{
    bool gameStarted = false;
    private InputAction spacePress;
    float gameTimer = 5.0f;
    public GameObject gameStartPanel;
    public GameObject gameOverPanel;
    public TMP_Text timerText;
    //public AudioSource bombSounds;
    //public AudioSource Temp;
    [SerializeField] private List<GameObject> spawnableObjects;
    public ScoreManager scoreManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        spacePress = InputSystem.actions.FindAction("Start");

        //InvokeRepeating("RandomItemSpawn", 0f, 0.75f);
    }

    // Update is called once per frame
    void Update()
    {
        if(gameStarted == false && spacePress.IsPressed())
        {
            gameStarted = true;
            gameStartPanel.SetActive(false);
            Debug.Log("Game Started!");
        }

        if (gameStarted == true)
        {
            TimerCountdown();
            if (!IsInvoking("RandomItemSpawn"))
            {
                InvokeRepeating("RandomItemSpawn", 0f, 0.75f);
            }

        }
    }

    void RandomItemSpawn() //Randomly spawns GameObjects in the random range
    {
        GameObject randomObject = spawnableObjects[Random.Range(0, spawnableObjects.Count)];

        float spawnPointX = Random.Range(-7.5f, 7.5f);
        float spawnPointY = 6.5f;

        Vector2 spawnPosition = new Vector2(spawnPointX, spawnPointY);
        
        Instantiate(randomObject, spawnPosition, Quaternion.identity);
        Debug.Log("Spawning Items");
    }

    void TimerCountdown() //Controls the timer and stops game when timer hits 0
    {
        gameTimer -= Time.deltaTime;
        timerText.text = "Timer: " + Mathf.RoundToInt(gameTimer).ToString();

        if(gameTimer < 0)
        {
            gameTimer = 0;
            Time.timeScale = 0;
            gameOverPanel.SetActive(true);

            //Call HighScoreUpdate
            //scoreManager.HighScoreUpdate();
        }
    }
}
