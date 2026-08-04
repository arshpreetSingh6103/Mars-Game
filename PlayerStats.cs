using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [Header("Health")]
    public float maxHealth = 100f;
    public float currentHealth = 100f;

    [Header("Stamina")]
    public float maxStamina = 100f;
    public float currentStamina = 100f;

    [Header("Stamina Settings")]
    public float sprintDrainPerSecond = 3f;
    public float jumpCost = 5f;
    public float regenPerSecond = 10f;
    public float regenDelay = 1f;

    private float regenTimer;

    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {
        // Wait before stamina starts regenerating
        if (regenTimer > 0)
        {
            regenTimer -= Time.deltaTime;
        }
        else
        {
            if (currentStamina < maxStamina)
            {
                currentStamina += regenPerSecond * Time.deltaTime;
                currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
            }
        }
    }

    public bool CanSprint()
    {
        return currentStamina > 0;
    }

    public bool CanJump()
    {
        return currentStamina >= jumpCost;
    }

    private float sprintTimer = 0f;

    public void DrainSprint()
    {
        sprintTimer += Time.deltaTime;

        // Free sprint for the first 2 seconds
        if (sprintTimer > 2f)
        {
            currentStamina -= sprintDrainPerSecond * Time.deltaTime;
            currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
        }

        regenTimer = regenDelay;
    }

    public void UseJump()
    {
        currentStamina -= jumpCost;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);

        regenTimer = regenDelay;
    }
}