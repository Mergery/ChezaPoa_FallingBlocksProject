using UnityEngine;
using System.IO.Ports;
using UnityEngine.Animations;



public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private GameObject GameManagerObj;
    private GameManager gameManager;

    public Rigidbody2D playerRb;

    float screenWorldUnits;
    float sideSpeed = 0.2f;
    
    bool gameStarted;
    float smoothing;

    public SerialPort serialPort = new SerialPort("COM12", 115200); 

    void Start()
    {
        gameManager = GameManagerObj.GetComponent<GameManager>();
        float playerHalfWidth = transform.localScale.x;
        screenWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;

        try
        {
            serialPort.Open();
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error opening serial port: " + e.Message);
        }
    }

    void Update()
    {
        gameStarted = gameManager.isGameStarted;

        if (gameStarted)
        {
            if (serialPort.IsOpen)
            {
                try
                {
                    string data = serialPort.ReadLine();
                    ParseArduinoData(data);
                }
                catch (System.Exception e)
                {
                    Debug.LogError("Error reading from serial port: " + e.Message);
                }
            }
        }
    }

    void ParseArduinoData(string data)
    {
        // Arduino sends data in the format "ax,ay,az"
        string[] values = data.Split(',');

        if (values.Length == 3)
        {
            float ax = float.Parse(values[0]);
            float ay = float.Parse(values[1]);
            float az = float.Parse(values[2]);


            float movement = ax * Time.deltaTime * sideSpeed;

            // Move the player left or right based on accelerometer data
           transform.Translate(-Vector3.right * movement);

            // Limit player movement within the screen bounds
            transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenWorldUnits, screenWorldUnits), transform.position.y, transform.position.z);
        }
    }

    void OnApplicationQuit()
    {
        if (serialPort.IsOpen)
            serialPort.Close();
    }

    public void SmoothMovement(float a)
    {
        float targetX = Mathf.Clamp(transform.position.x + a, -screenWorldUnits, screenWorldUnits);
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // Use Mathf.Lerp to interpolate between the current position and the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);


    }
}

