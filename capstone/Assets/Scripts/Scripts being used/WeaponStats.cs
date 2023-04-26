using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] public TMP_Text attackText;
    [SerializeField] public TMP_Text damageText;
    [SerializeField] public TMP_Text critText;
    [SerializeField] public TMP_Text fireforceText;
    [SerializeField] public TMP_Text movementText;
    [SerializeField] public TMP_Text HealthText;
    private void Awake()
    {
        UpdateAttackText();
        UpdateFireforceText();
        UpdateMovementText();
        UpdateHealthText();
        UpdateDamageText();
        UpdateCritText();
    }

    private void Update()
    {
        UpdateAttackText();
        UpdateFireforceText();
        UpdateMovementText();
        UpdateHealthText();
        UpdateDamageText();
        UpdateCritText();
    }

    private void UpdateHealthText()
    {
        PlayerHealth h = FindObjectOfType<PlayerHealth>();
        if (h != null && attackText != null)
        {
            HealthText.text = $"{h.currentHealth.ToString()}";
        }
    }
    private void UpdateDamageText()
    {
        bullet b = FindObjectOfType<bullet>();
        if (b != null && attackText != null)
        {
            damageText.text = $"Damage: {b.bulletDamage.ToString()}";
        }
    }
    private void UpdateCritText()
    {
        bullet b = FindObjectOfType<bullet>();
        if (b != null && attackText != null)
        {
            critText.text = $"Crit Chance: {b.criticalStrikeChance.ToString()}0%";
        }
    }
    private void UpdateAttackText()
    {
        Weapon w = FindObjectOfType<Weapon>();
        if (w != null && attackText != null)
        {
            attackText.text = $"Attack rate: {w.fireRate.ToString()}";
        }
    }

    private void UpdateFireforceText()
    {
        Weapon w = FindObjectOfType<Weapon>();
        if (w != null && fireforceText != null)
        {
            fireforceText.text = $"Bullet Speed: {w.fireForce.ToString()}";
        }
    }
    private void UpdateMovementText()
    {
        playercontroller p = FindObjectOfType<playercontroller>();
        if (p != null && movementText != null)
        {
            movementText.text = $"Movement Speed: {p.moveSpeed.ToString()}";
        }
    }
}