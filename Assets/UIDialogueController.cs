using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIDialogueController : MonoBehaviour
{
    [SerializeField]
    GameObject introText;

    [SerializeField]
    GameObject finishingText;

    [SerializeField]
    public GameObject fleetHealthBar;


    public void showStartDialogue()
    {
        StartCoroutine(startDialogue());
       
    }

    public void showFinishingDialogue()
    {
        StartCoroutine(finishingDialogue());
    }

    IEnumerator startDialogue()
    {
        introText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        introText.SetActive(false);
        fleetHealthBar.SetActive(true);
    }

    IEnumerator finishingDialogue()
    {
        finishingText.SetActive(true);
        yield return new WaitForSeconds(3.0f);
        finishingText.SetActive(false);
    }
}
