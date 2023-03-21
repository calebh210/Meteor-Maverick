using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[System.Serializable] public class customIntEvent : UnityEvent<int> { }
public class PlayerScore : MonoBehaviour
{
    int score = 0;
    public customIntEvent updateUIScore;

    public void UpdateScore(int points)
    {
        this.score += points;
        updateUIScore.Invoke(score);
    }
}
