using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;
using UnityEngine.SocialPlatforms.Impl;

public class GameManager : MonoBehaviour
{
    [System.Serializable] public class customIntEvent : UnityEvent<int> { }
    bool gameOver = false;
    private GameStates.State GameState;

    //Scoring vars
    int score = 0;
    public customIntEvent updateUIScore;

    [SerializeField] //Adding the pause menu instance
    GameObject PauseMenu;
    
    public void Start()
    {
        //get the score from prefs
        score = PlayerPrefs.GetInt("score");
        UpdateScore(score);

        //Set the default state
        GameState = new GameStates.PlayState(PauseMenu);
        GameState.OnEnter();
    }

    public void Update()
    {
        HandleNewState(GameState.OnUpdate(), GameState);
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

    public void LoadNextLevel()
    {
        SaveScore();
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    void HandleNewState(GameStates.State newState, GameStates.State oldState)
    {
        if (newState != oldState)
        {
            GameState = newState;
            GameState.OnEnter();
        }
    }

    //Below are all of the scoring functions

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);
    }

    public void UpdateScore(int points)
    {
        this.score += points;
        updateUIScore.Invoke(score);
    }

}
