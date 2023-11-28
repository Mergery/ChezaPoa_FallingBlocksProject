using System.Collections;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
   
//----------------------------GAME OBJECTS -----------------------------------------------------------
    public GameObject [] enemyArray;
    public GameObject [] ballArray;

    [SerializeField]
    public GameObject GameManager;
     private GameManager GameManagerScript;

     [SerializeField]
     private GameObject EndGamePoint;
     private UpgradeSpawners upgradeSpawners;


//------------------------------VARIABLES---------------------------------------------------------------------
     float screenWorldUnits2X;
     float screenWorldUnits2Y;

     public bool gameStarted;
     int Blocks;  

     void Start()
     {

         GameManagerScript = GameManager.GetComponent<GameManager>();
         gameStarted= GameManagerScript.isGameStarted;

         upgradeSpawners= EndGamePoint.GetComponent<UpgradeSpawners>();
        

         // SET THE VIEWOINT OF THE CAMERA 
         screenWorldUnits2X= Camera.main.aspect* Camera.main.orthographicSize-25f;
         screenWorldUnits2Y= Camera.main.aspect* Camera.main.orthographicSize;

         InvokeRepeating("SpawnEnemies", 3.0f, 2.0f);
         InvokeRepeating("SpawnBall", 3.0f, 5.0f);
        

         // SPAWNING THE ENEMY BLOCKS 
        
     }


     void Update()
     {     
         gameStarted= GameManagerScript.isGameStarted;   
         Blocks= upgradeSpawners.blocksPassed;
         //Debug.Log(Blocks);
     }


    

      public void SpawnEnemies()
     {
         if(gameStarted)
         {
             int enemyIndex = Random.Range(0,4); 

             // TRYING TO KEEP THE BLOCKS IN SPACE 
             float spawnx= Random.Range(-screenWorldUnits2X, screenWorldUnits2X);

             //TRYING TO MOVE THE SPAWN POSITION CLOSER 
             float spawny = screenWorldUnits2Y-5f;

             Vector3 spawnLocation = new Vector3(spawnx, spawny, 0f);

             Instantiate(enemyArray[enemyIndex],spawnLocation, Quaternion.identity);

         }
        
     }


     public void SpawnBall()
     {
         if(gameStarted)
         {
             int ballIndex = Random.Range(0,2); 

             // TRYING TO KEEP THE BLOCKS IN SPACE 
             float spawnx= Random.Range(-screenWorldUnits2X, screenWorldUnits2X) - ballArray[ballIndex].transform.localScale.x;

             //TRYING TO MOVE THE SPAWN POSITION CLOSER 
             float spawny = screenWorldUnits2Y-5f;

             Vector3 spawnLocation = new Vector3(spawnx, spawny, 0f);

             Instantiate(ballArray[ballIndex],spawnLocation, Quaternion.identity);

         }
        
     }



}
