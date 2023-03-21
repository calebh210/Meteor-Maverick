using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    private ProgressBar HealthBar;
    private ProgressBar AbilityBar;
    private Label Scoreboard;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        this.HealthBar = root.Q<ProgressBar>("HealthBar");
        this.AbilityBar = root.Q<ProgressBar>("AbilityBar");
        this.Scoreboard = root.Q<Label>("scoreboard");
       
    }
    //look into events
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
