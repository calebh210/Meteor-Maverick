using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;
    public void EndGame()
    {
        if(gameOver == false)
        {
            Debug.Log("end");
            gameOver = true;
            Restart();
        }
        
    }
  
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
