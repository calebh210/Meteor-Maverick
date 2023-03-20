using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour
{
    int score = 0;
    UIController playerUI;

    private void Start()
    {
        playerUI = GameObject.Find("UIDocument").GetComponent<UIController>();
    }

    public void UpdateScore(int points)
    {
        this.score += points;
        playerUI.updateScoreboard(score);
    }
}
