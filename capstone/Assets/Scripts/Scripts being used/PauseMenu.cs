using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;
    public static bool isPaused;
    public Weapon myWeapon;
    public CoinCounter bank;
    public double upgradeCost = 10;
    public playercontroller player;
    public bullet b;
    // Start is called before the first frame update
    void Start()
    {
        pauseMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (myWeapon.fireRate < .1f)
            myWeapon.fireRate = .05f;
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }


        }
    }

    public void PauseGame()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
        isPaused = true;
    }
    public void ResumeGame()
    {

        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void upgradeFireRate()
    {
        if (bank.currentCoins >= upgradeCost)
        {
            if (myWeapon.fireRate < .1f)
            {
                myWeapon.fireRate = .05f;

            }
            else
            {
                myWeapon.fireRate -= .1f;
                updateMoney();
            }
        }
    }
    public void upgradeFireForce()
    {
        if (bank.currentCoins >= upgradeCost)
        {
            if (myWeapon.fireForce >= 25f)
            {
                myWeapon.fireForce = 25f;

            }
            else
            {
                myWeapon.fireForce += 5f;
                updateMoney();
            }
        }
    }
    public void upgradeMoveSpeed()
    {
        if (bank.currentCoins >= upgradeCost)
        {
            if (player.moveSpeed >= 5f)
                player.moveSpeed = 5f;
            else 
            {
                player.moveSpeed += .5f;
                updateMoney();
            }
            
        }
    }
    public void upgradeDamage()
    {
        if (bank.currentCoins >= upgradeCost)
        {
            if (b.bulletDamage >= 100)
                b.bulletDamage = 100;
            else
            {
                b.bulletDamage += 15;
                updateMoney();
            }
        }
    }
    public void upgradeCritChance()
    {
        if (bank.currentCoins >= upgradeCost)
        {
            if (b.criticalStrikeChance >= 1f)
                b.criticalStrikeChance = 1f;
            else
            {
                b.criticalStrikeChance += .15f;
                updateMoney();
            }
        }
    }
    public void updateMoney()
    {
        bank.currentCoins -= upgradeCost;
        bank.coinText.text = "COINS: " + bank.currentCoins.ToString();
        upgradeCost = upgradeCost * 1.5;
    }


}