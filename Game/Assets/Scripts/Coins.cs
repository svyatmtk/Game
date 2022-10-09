using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using TMPro;
using UnityEngine;

public class Coins : MonoBehaviour
{
    private static int coinsAmount;
    public TextMeshProUGUI coinInfo;
    public GameObject winPanel;
    public GameObject[] coins;

    private void Start()
    {
        coins = GameObject.FindGameObjectsWithTag("Coin");
        coinsAmount = 0;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            coinsAmount++;
            Destroy(gameObject);
            Debug.Log(coinsAmount);
            coinInfo.text = coinsAmount.ToString() + " coins collected";
            coins = GameObject.FindGameObjectsWithTag("Coin");
            if (coins.Length - 1 == 0)
            {
                winPanel.SetActive(true);
                collision.GetComponent<PlayerMovement>().enabled = false;
            }
        }
    }
}
