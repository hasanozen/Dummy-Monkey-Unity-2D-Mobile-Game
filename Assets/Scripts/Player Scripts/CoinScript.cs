using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinScript : MonoBehaviour
{
    private Rigidbody2D myBody;
    //public CoinScript instance;
    public Text coinCollected;
    private int coin_Collected = 1;
    private int coin_Saved;

    // Start is called before the first frame update
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        coinCollected.text = PlayerPrefs.GetInt("Coin") + "";
    }

    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "CoinTag")
        {
            target.gameObject.SetActive(false);
            coin_Saved = PlayerPrefs.GetInt("Coin");
            coin_Saved += coin_Collected;
            SaveCoin();

            // Sound Manager
            SoundManager.instance.CoinTakeSoundFX();

            coinCollected.text = PlayerPrefs.GetInt("Coin") + "";
        }
    }

    public void SaveCoin()
    {
        PlayerPrefs.SetInt("Coin", coin_Saved);
        //Debug.Log("Saved " + PlayerPrefs.GetInt("Coin"));
    }
}
