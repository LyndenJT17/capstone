using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class eHealthstat : MonoBehaviour
{
    
    [SerializeField] public TMP_Text eHealthText;
    private void Awake()
    {
        UpdateeHealthText();
        
    }

    private void Update()
    {
        
        UpdateeHealthText();
        
    }

    private void UpdateeHealthText()
    {
        EnemyHealth h = FindObjectOfType<EnemyHealth>();
        eHealthText.text = $"{h.currentHealth.ToString()}";
        if (h != null && eHealthText != null)
        {
            
        }
    }
    
}