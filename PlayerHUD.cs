using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHUD : MonoBehaviour
{
    public PlayerStats stats;

    public Image healthFill;
    public Image staminaFill;

    public TMP_Text healthText;
    public TMP_Text staminaText;

    void Update()
    {
        healthFill.fillAmount = stats.currentHealth / stats.maxHealth;
        staminaFill.fillAmount = stats.currentStamina / stats.maxStamina;

        healthText.text = Mathf.RoundToInt(stats.currentHealth) + "%";
        staminaText.text = Mathf.RoundToInt(stats.currentStamina) + "%";
    }
}