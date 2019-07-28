using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerScore : MonoBehaviour
{
    private Rigidbody2D myBody;
    public Text score;
    public Text highest_ScoreText;
    private int recorded_Score;
    private int instant_Score = 0;
    private int highest_Score;
    private int threeBananaScore = 5;
    private int oneBananaScore = 2;
    

    // Awake is called once for every object before the every scene 
    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        highest_ScoreText.text = PlayerPrefs.GetInt("Score") + "";
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if(target.tag == "ExtraPush")
        {
            instant_Score += threeBananaScore;
        }

        if (target.tag == "NormalPush")
        {
            instant_Score += oneBananaScore;
        }

        score.text = (instant_Score) + "";
        SaveScore();


    }

    public void SaveScore()
    {
        if (PlayerPrefs.GetInt("Score") < instant_Score)
        {
            PlayerPrefs.SetInt("Score", instant_Score);
            highest_ScoreText.text = "Highest: " + PlayerPrefs.GetInt("Score");
        }
        else
            return;
    }


} // class
