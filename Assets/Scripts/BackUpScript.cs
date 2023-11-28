
using UnityEngine;

public class BackUpScript : MonoBehaviour
{
    //    // Start is called before the first frame updat
    // [SerializeField]
    // private GameObject GameManagerObj;
    // private GameManager gameManager;

    // float horizontalInput;
    // float screenWorldUnits;
    // float sideSpeed = 5.0f;
    // bool gameStarted;//
    // void Start()
    // {
    //     //transform.position= new Vector3(0, 0, -4.0f);
    //     gameManager = GameManagerObj.GetComponent<GameManager>();
    //     float playerHalfWidth= transform.localScale.x;
    //     screenWorldUnits= Camera.main.aspect* Camera.main.orthographicSize+ playerHalfWidth;
    // }

    // // Update is called once per frame
    // void Update()
    // {
    //     gameStarted= gameManager.isGameStarted;

    //     if(gameStarted)
    //     {
    //         //MOVEMENT
    //     horizontalInput= Input.GetAxis("Horizontal");
    //     transform.Translate(Vector3.right*horizontalInput*Time.deltaTime* sideSpeed);

    //     if(transform.position.x< -screenWorldUnits)
    //     {
    //         transform.position= new Vector3(screenWorldUnits, transform.position.y, transform.position.z);
    //     }

    //     if(transform.position.x>screenWorldUnits)
    //     {
    //         transform.position= new Vector3(-screenWorldUnits, transform.position.y, transform.position.z);
    //     }
    //     }
        
    // }







   // -------------------------------------------CODE FOR ARDUINO-----------------------------------------------------------------------------------------------------

//    [SerializeField]
//     private GameObject GameManagerObj;
//     private GameManager gameManager;

//     float screenWorldUnits;
//     float sideSpeed = 5.0f;
//     bool gameStarted;

//     SerialPort serialPort = new SerialPort("COM4", 1115200); // Adjust the port and baud rate as needed

//     void Start()
//     {
//         gameManager = GameManagerObj.GetComponent<GameManager>();
//         float playerHalfWidth = transform.localScale.x;
//         screenWorldUnits = Camera.main.aspect * Camera.main.orthographicSize + playerHalfWidth;

//         try
//         {
//             serialPort.Open();
//         }
//         catch (System.Exception e)
//         {
//             Debug.LogError("Error opening serial port: " + e.Message);
//         }
//     }

//     void Update()
//     {
//         gameStarted = gameManager.isGameStarted;

//         if (gameStarted)
//         {
//             if (serialPort.IsOpen)
//             {
//                 try
//                 {
//                     string data = serialPort.ReadLine();
//                     ParseArduinoData(data);
//                 }
//                 catch (System.Exception e)
//                 {
//                     Debug.LogError("Error reading from serial port: " + e.Message);
//                 }
//             }
//         }
//     }

//     void ParseArduinoData(string data)
//     {
//         // Assuming the Arduino sends data in the format "ax,ay,az"
//         string[] values = data.Split(',');

//         if (values.Length == 3)
//         {
//             float ax = float.Parse(values[0]);
//             float ay = float.Parse(values[1]);
//             float az = float.Parse(values[2]);

//             // Use the data to control the player's movement
//             // Example: transform.Translate(Vector3.right * ax * Time.deltaTime * sideSpeed);

//             float movement = ax * Time.deltaTime * sideSpeed;

//             // Move the player left or right based on accelerometer data
//             transform.Translate(Vector3.right * movement);

//             // Limit player movement within the screen bounds
//             transform.position = new Vector3(Mathf.Clamp(transform.position.x, -screenWorldUnits, screenWorldUnits), transform.position.y, transform.position.z);
//         }
//     }

//     void OnApplicationQuit()
//     {
//         if (serialPort.IsOpen)
//             serialPort.Close();
//     }
}