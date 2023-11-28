using UnityEngine;


public class PlayerCollisions : MonoBehaviour
{
    public int points = 0;
    
    [SerializeField]
    private GameObject GameManagerObj;

    public GameManager gameManager;
    private AudioManager audiomanager;

    private void Start()
    {
        gameManager= GameManagerObj.GetComponent<GameManager>();
        audiomanager = FindObjectOfType<AudioManager>();
        
    }
    

    private void OnTriggerEnter2D(Collider2D triggercollision) 
   {
    if(triggercollision.tag=="Enemy")
    {
        audiomanager.Play("GameOver");
        gameManager.gameOver();
        
    }

    if(triggercollision.tag=="Ball")
    {
        audiomanager.Play("PickUp");
        Destroy(triggercollision.gameObject);
        points+=1;
        
    }
   }
}
