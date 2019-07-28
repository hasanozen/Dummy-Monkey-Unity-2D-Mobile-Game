using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    // Awake is called once for every object before the every scene
    void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    public void RestartGame()
    {
        Invoke("LoadGameplay", 2f);
    }
    void LoadGameplay()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Gameplay");
    }

} // class
