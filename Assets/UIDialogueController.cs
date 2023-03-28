using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogueController : MonoBehaviour
{
    [SerializeField]
    public GameObject introText;

    [SerializeField]
    public GameObject fleetHealthBar;


    public void showStartDialogue()
    {
        StartCoroutine(startDialogue());
       
    }

    IEnumerator startDialogue()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        introText.SetActive(false);
        fleetHealthBar.SetActive(true);
    }
}
