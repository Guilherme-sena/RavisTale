using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
   public static bool JogoPausado = false;

   public GameObject pauseMenuUI;
   
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (JogoPausado) {
                Resumir();
            } 
            else {
                Pausar();
            }
        }
        
    }

    public void Resumir()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        JogoPausado=false;
    }

    void Pausar()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        JogoPausado = true;
    }

    public void LoadMenu()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1f;

    }

    public void FecharJogo()
    {
        Application.Quit();
    }

}
