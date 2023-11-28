using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;
using System.IO.Ports;


public class GameManager : MonoBehaviour
{
    // -------------------GAME OBJECTS----------------------------
    [SerializeField]
    private GameObject Player;
    private PlayerCollisions playercollisions;
    private PlayerController playerController;

    private AudioManager audiomanager;

    SerialPort serialPort2;


    ////public SerialPort serialPort = new SerialPort("COM12", 115200); // Adjust the port and baud rate as needed

    //---------------UI------------------------
    [SerializeField]
    private GameObject LevelPanel;

    [SerializeField]
    private GameObject GameOverPanel;

    [SerializeField]
    private Text scoreText;

    [SerializeField]
    private Text highScoreText;


    //VARIABLES
    public bool isGameStarted ;
    int score;
    int highScore; 
     

    private void Awake() 
    {
        isGameStarted= true;
    }
    
    void Start()
    {
        playercollisions= Player.GetComponent<PlayerCollisions>();
        playerController= Player.GetComponent<PlayerController>();

        audiomanager = FindObjectOfType<AudioManager>();
        serialPort2= playerController.serialPort;

        audiomanager.Play("Background");

        LoadHighScore();
        UpdateUI();
    }

    // Update is called once per frame
    void Update()
    {
        score = playercollisions.points;

        UpdateUI();
        
    }

    void UpdateUI()
    {
        scoreText.text= "Score: " + score.ToString();
        highScoreText.text= "High Score : " + highScore.ToString();
    }

    public void gameOver()
    {
        serialPort2.Close();
        UpdateHighScore();
        Time.timeScale= 0f;
        GameOverPanel.SetActive(true);
        LevelPanel.SetActive(false);
        
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(1);
        Time.timeScale= 1f;
        // try
        // {
        //     serialPort.Open();
        // }
        // catch (System.Exception e)
        // {
        //     Debug.LogError("Error opening serial port: " + e.Message);
        // }
    }

    public void LoadHighScore()
    {
        highScore= PlayerPrefs.GetInt("HighScore", 0);
    }

    public void  UpdateHighScore()
    {
        if(score> highScore)
        {
            highScore= score;
            PlayerPrefs.SetInt("High Score", highScore);
            PlayerPrefs.Save();
        }
    }


   
}
