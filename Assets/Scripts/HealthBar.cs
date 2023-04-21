using System;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void SetHealth(float percentage)
    {
        slider.value = percentage * slider.maxValue;
    }

    internal void InializarBarraDeVida(float vida)
    {
        throw new NotImplementedException();
    }

    internal void CambiarVidaActual(float vida)
    {
        throw new NotImplementedException();
    }
}