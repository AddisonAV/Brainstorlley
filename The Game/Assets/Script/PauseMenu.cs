using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour

{
    public GameObject pauseMenu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            if (Time.timeScale == 1)
            {
                pauseMenu.SetActive(true);
                Time.timeScale = 0 ;
            }
            else
            {
                pauseMenu.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1 ;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void BackMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);

    }

}

