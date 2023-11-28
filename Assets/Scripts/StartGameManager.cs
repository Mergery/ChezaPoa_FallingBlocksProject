using UnityEngine;
using UnityEngine.SceneManagement;

public class StartGameManager : MonoBehaviour
{
    public GameObject StartPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }


}
