using UnityEngine;

public class MoveEnemy : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private GameObject EnemyManager;
    public EnemyBehaviour enemyBehaviour;
    float enemySpeed=4.0f;

    public int blocksPassed;


    float zBoundary ;
    void Start()
    {
        zBoundary= Camera.main.aspect* Camera.main.orthographicSize -5.0f;
       // EnemyManager= GameObject.FindWithTag("EnemyManager");
        //enemyBehaviour= EnemyManager.GetComponent<EnemyBehaviour>();
    }

    // Update is called once per frame
    void Update()
    {
       // enemySpeed= enemyBehaviour.EnemySpeed;
        transform.Translate(Vector3.down*enemySpeed*Time.deltaTime);

        DestroyOutOfBounds();
    }

    public void DestroyOutOfBounds()
    {
        if(transform.position.y< -zBoundary )
        {
            blocksPassed=1;

            Destroy(gameObject);
            
        }
    }
}
