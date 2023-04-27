using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EnemyHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;

    public GameObject item;
    public Transform transform;

    public string spawnPointTag = "sometag";
    public bool alwaysSpawn = true;
    public List<GameObject> prefabsToSpawn;

    private TextMeshProUGUI healthText; // Reference to the TMP Text component

    void Start()
    {
        currentHealth = health;

        // Instantiate a new TMP object and set it as a child of the enemy game object
        GameObject textObj = new GameObject("Health Text");
        textObj.transform.SetParent(transform);
        textObj.transform.localPosition = Vector3.zero;

        // Add a TMP component to the new object
        healthText = textObj.AddComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            DropItem();
        }

        // Update the health text to display the current health value
        healthText.text = currentHealth.ToString();
        healthText.transform.position = Camera.main.WorldToScreenPoint(transform.position + Vector3.up * 0.2f);
    }

    public void damageEnemy(int damage)
    {
        currentHealth -= damage;
    }

    void DropItem()
    {
        Vector2 pos = transform.position;

        int randomPrefab = Random.Range(0, prefabsToSpawn.Count);
        GameObject pts = Instantiate(prefabsToSpawn[randomPrefab]);
        pts.transform.position = pos;
    }
}
