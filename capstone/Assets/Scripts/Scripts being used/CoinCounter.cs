using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CoinCounter : MonoBehaviour
{
    public static CoinCounter instance;
    public TMP_Text coinText;
    public TMP_Text upCost;
    public double currentCoins = 0;
    public PauseMenu pMenu;
    void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        coinText.text = "COINS: " + currentCoins.ToString();
        upCost.text = "Amount needed to upgrade: " + pMenu.upgradeCost.ToString();
    }
    void Update()
    {
        upCost.text = "Amount needed to upgrade: " + pMenu.upgradeCost.ToString();
    }

    // Update is called once per frame
    public void IncreaseCoins(int v)
    {
        currentCoins += v;
        coinText.text = "COINS: " + currentCoins.ToString();
    }
}
