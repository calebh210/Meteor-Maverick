using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public ProgressBar HealthBar;
    public ProgressBar AbilityBar;
    public Label Scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        HealthBar = root.Q<ProgressBar>("HealthBar");
        AbilityBar = root.Q<ProgressBar>("AbilityBar");
        Scoreboard = root.Q<Label>("scoreboard");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealth(float healthRemaining)
    {
        HealthBar.value = healthRemaining;
    }

    public void updateAbility(float time)
    {
        AbilityBar.value = time;
    }

    public void updateScoreboard(int score)
    {
        Scoreboard.text = score.ToString();
    }
        


}
