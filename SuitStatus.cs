using UnityEngine;
using TMPro;

public class SuitStatusUI : MonoBehaviour
{
    [Header("UI Text")]
    public TMP_Text oxygenText;
    public TMP_Text powerText;
    public TMP_Text habitatText;

    [Header("Status Values")]
    [Range(0,100)] public int oxygen = 98;
    [Range(0,100)] public int power = 87;
    [Range(0,100)] public int habitat = 82;

    void Update()
    {
        oxygenText.text = oxygen + "%";
        powerText.text = power + "%";
        habitatText.text = habitat + "%";
    }
}