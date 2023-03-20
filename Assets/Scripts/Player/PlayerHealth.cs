using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth = 10000f;
    UIController playerUI;
    void Start()
    {
        //Linking the playerUI to the UI script, look for ways to optimize this
        playerUI = GameObject.Find("UIDocument").GetComponent<UIController>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        updateHealth(-50f);
    }
    public void updateHealth(float damage)
    {

        playerHealth += damage;
        playerUI.updateHealth(playerHealth);


        if (playerHealth <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
