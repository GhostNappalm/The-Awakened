using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject GameOverUI;
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        if (player.GetComponent<PlayerMovement>().hp<=0)
        {
             Invoke("Pause",1.3f);
        }

    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
    }


    public void Pause()
    {
        GameOverUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

}
