using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeaponStats : MonoBehaviour
{
    [SerializeField] public TMP_Text attackText;

    public Weapon w;

    void Awake()
    {
        w = GetComponent<Weapon>();

        if (attackText != null)
        {
            attackText.text = $"Attack rate: {w.fireRate.ToString()}";
        }
    }

    private void Update()
    {
        if (w != null && attackText != null)
        {
            attackText.text = $"Attack rate: {w.fireRate.ToString()}";
        }
    }
}