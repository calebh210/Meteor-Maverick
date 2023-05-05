using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Level4Manager : MonoBehaviour
{
    public UnityEvent ShowStartDialogue;
    void Start()
    {
        ShowStartDialogue.Invoke();
    }


    public void EndLevel()
    {
        StartCoroutine(EndOfLevel());
    }

    public IEnumerator EndOfLevel()
    {
        yield return new WaitForSeconds(5f);
        FindObjectOfType<GameManager>().LoadNextLevel();
    }

}
