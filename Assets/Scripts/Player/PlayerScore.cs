using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Rendering;

[System.Serializable] public class customIntEvent : UnityEvent<int> { }
public class PlayerScore : MonoBehaviour
{
    int score = 0;
    public customIntEvent updateUIScore;

    private void Start()
    {
        score = PlayerPrefs.GetInt("score");
        UpdateScore(score);
    }

    public void UpdateScore(int points)
    {
        this.score += points;
        updateUIScore.Invoke(score);
    }

    public void SaveScore()
    {
        PlayerPrefs.SetInt("score", score);
    }
}
