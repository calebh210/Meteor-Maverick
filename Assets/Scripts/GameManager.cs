using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameOver = false;

    public void PauseGame()
    {

    }

    public void ResumeGame()
    {

    }

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

    void Level1()
    {

    }
    void Level2()
    {

    }
    void Level3()
    {

    }
}
