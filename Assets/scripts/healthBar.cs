using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{

    public Slider slider;
    public TextMeshProUGUI healthText;
    public TextMeshProUGUI corruptionText;

    public void setCorruption(int corruption)
    {
        corruptionText.text = corruption.ToString();
    }
    public void SetHealth(int health)
    {
        slider.value = health;
        healthText.text = health.ToString();
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
        healthText.text = health.ToString();
    }
}
