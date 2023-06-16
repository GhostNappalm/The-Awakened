using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FineGioco : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject FineGiocoUI;
    private bool attivato = false;

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("enemy").Length == 0 && attivato==false)
        {
            GameObject.Find("player").GetComponent<Inventario>().Inc_Punt_finegioco();
            Pause();
        }
    }

    public void Resume()
    {
        FineGiocoUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
    public void Pause()
    {
        attivato = true;
        FineGiocoUI.SetActive(true);
        GameObject.Find("PunteggioFG").GetComponent<TMPro.TextMeshProUGUI>().text = GameObject.Find("player").GetComponent<Inventario>().punteggio.ToString();
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void Restart()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
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
