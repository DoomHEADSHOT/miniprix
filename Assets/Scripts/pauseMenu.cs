using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class pauseMenu : MonoBehaviour
{
    public GameObject Canvas;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Time.timeScale = 0;
            Canvas.SetActive(true);
        }


    }
        public void resumeGame()
        {
        Time.timeScale = 1;
        Canvas.SetActive(false);
    }

    public void BacktoMain()
    {
        SceneManager.LoadScene(0);
        Time.timeScale = 1;
    }
    public void QuitGame()
    {
        Application.Quit();
    }

}
