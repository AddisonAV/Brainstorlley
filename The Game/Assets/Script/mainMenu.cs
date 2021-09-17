using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainMenu : MonoBehaviour
{
    void Start()
    {
        SoundManager.PlaySound(SoundManager.Sound.MenuSound, 0.1f);
    }

    public void playGame()
    {
        GameAsset.Instance.LoadLevel("Game");
    }
    public void QuitGame()
    {
        Application.Quit();
    }


}
