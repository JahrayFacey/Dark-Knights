using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerData : MonoBehaviour
{
    public float DialougeNumber;
    public int questNumber;


    [Header("PlayerStats")]
    public float MaxHealth;
    public float CurrHealth;

    [Header("UIComponents")]
    public Slider HealthSlider;
    public TextMeshProUGUI HealthText;
    public void Start()
    {
        HealthSlider.maxValue = MaxHealth;
        CurrHealth = MaxHealth;
        HealthSlider.value = CurrHealth;
        HealthText.text = MaxHealth.ToString("F0") + "/" + CurrHealth.ToString("F0");
    }

    public void TakeDamage(float Damage)
    {
        CurrHealth -= Damage;
        HealthSlider.value = CurrHealth;
        if(CurrHealth <= 0)
        {
            Application.LoadLevel("S");
        }
        HealthText.text = MaxHealth.ToString("F0") + "/" + CurrHealth.ToString("F0");
    }
    public void Heal(float Heal)
    {
        CurrHealth += Heal;
        if(CurrHealth > MaxHealth)
        {
            CurrHealth = MaxHealth;

        }    
        HealthSlider.value = CurrHealth;
        HealthText.text = MaxHealth.ToString("F0") + "/" + MaxHealth.ToString("F0");
    }
}

