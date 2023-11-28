using UnityEngine;

public class UpgradeSpawners : MonoBehaviour
{
    // Start is called be//fore the first frame update
    //// hello
    public int blocksPassed;
    
    private void OnTriggerEnter2D(Collider2D triggercollision) 
   {
    if(triggercollision.tag=="Enemy")
    {
        blocksPassed += 1;
    }

   }
}
