using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    public int health;
    public int currentHealth;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Destroy(gameObject);
        }
    }

    public void damagePlayer(int damage)
    {
        currentHealth -= damage;
    }

}