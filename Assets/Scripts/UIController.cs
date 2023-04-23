using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    [SerializeField]
    public Image HealthBar;
    [SerializeField]
    public Image AbilityBar;
    [SerializeField]
    public TextMeshProUGUI Score;
    [SerializeField]
    public Image FleetHealth;
  
    void Update()
    {
        
    }

    public void updateHealth(float healthRemaining)
    {
        //HealthBar.value = healthRemaining;
        HealthBar.fillAmount = healthRemaining / 100f; 
    }

    public void updateAbility(float time)
    {
        AbilityBar.fillAmount = time / 100f;
    }

    public void updateScoreboard(int score)
    {
        Score.text = score.ToString();
    }

    public void updateFleetHealth(float health)
    {
        FleetHealth.fillAmount = health / 100;

    }
        


}
