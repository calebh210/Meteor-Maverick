using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class UIController : MonoBehaviour
{

    public ProgressBar HealthBar;
    // Start is called before the first frame update
    void Start()
    {
        var root = GetComponent<UIDocument>().rootVisualElement;

        HealthBar = root.Q<ProgressBar>("HealthBar");
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updateHealth(float healthRemaining)
    {
        HealthBar.value = healthRemaining;
    }
}
