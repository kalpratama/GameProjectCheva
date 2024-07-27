using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;
    private Rigidbody rb;

    public Slider healthSlider;
    public Text fallDamageText;

    private void Start()
    {
        currentHealth = maxHealth;
        UpdateHealthUI();
        rb = GetComponent<Rigidbody>();
    }

    // ... (other methods)

    private void Update()
    {
        if (rb.velocity.y < -10f) // Adjust the threshold as needed
        {
            TakeFallDamage();
        }
    }

    private void TakeFallDamage()
    {
        int damageAmount = Mathf.RoundToInt(-rb.velocity.y); // Convert fall speed to damage
                                                             // Apply damage to the player (call your existing TakeDamage method)
        TakeDamage(damageAmount);

        // Update UI text
        fallDamageText.text = $"Fall Damage: {damageAmount}";
    }


    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        UpdateHealthUI();
        // Handle any other effects (e.g., screen flash, sound) here
    }

    // ... (other methods)

    private void UpdateHealthUI()
    {
        healthSlider.value = currentHealth;
    }
}
