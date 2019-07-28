using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool gameIs_Paused = false;
    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Awake()
    {
        if (instance == null)
            instance = this;
    }

    //void Update()
    //{
    //    if (PlayerScript.player_DiedReplica)
    //    {
    //        Invoke("Pause", 2f);
    //    }   
    //}

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        gameIs_Paused = false;
    }

    public void Pause()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        gameIs_Paused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
        //gameIs_Paused = false;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
