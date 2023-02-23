using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaBar : MonoBehaviour
{
    [Range(0, 4000)]
    public int stamina;
    public int maxStamina = 2000;

    public RectTransform uiBar;

    private void Update()
    {
        if (stamina > maxStamina) stamina = maxStamina;
        else if (stamina < 0) stamina = 0;
    }

    private void OnValidate()
    {
        if (stamina > maxStamina) stamina = maxStamina;
        else if (stamina < 0) stamina = 0;
    }
}
//WIP