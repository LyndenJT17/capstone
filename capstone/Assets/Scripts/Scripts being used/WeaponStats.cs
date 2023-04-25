using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] public TMP_Text attackText;
    [SerializeField] public TMP_Text fireforceText;
    [SerializeField] public TMP_Text movementText;
    private void Awake()
    {
        UpdateAttackText();
        UpdateFireforceText();
        UpdateMovementText();
    }

    private void Update()
    {
        UpdateAttackText();
        UpdateFireforceText();
        UpdateMovementText();
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