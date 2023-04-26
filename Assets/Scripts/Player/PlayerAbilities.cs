using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;


[System.Serializable] public class customFloatEvent : UnityEvent<float> { } //Lets me add a float arg to event call;

public class PlayerAbilities : MonoBehaviour
{
    public customFloatEvent UpdateUI;

    public float abilityTime = 100f;

    public void UpdateAbilityTime(float time)
    {
        abilityTime += time;
        UpdateUI.Invoke(abilityTime);
        Debug.Log("UpdatingUI");
    }
}