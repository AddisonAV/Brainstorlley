using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ControlCanvas : MonoBehaviour
{
    public TextMeshProUGUI currentDifficulty;
    public GameObject nextLevelCanvas;

    public void setNextLevelCanvas(bool show)
    {
        var worldGen = GameObject.FindGameObjectWithTag("WorldGen");
        worldGenerator world = worldGen.GetComponent<worldGenerator>();
        nextLevelCanvas.SetActive(show);
        if (show)
        {

            GameObject.FindGameObjectWithTag("Text").SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
            //GetComponentInChildren<timePlayed>().SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
            //GetComponentInChildren<timePlayed>().SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
        }

        //GetComponentInChildren<timePlayed>().SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
        currentDifficulty.text = "Level: " + world.getCurrentLevel();

    }



}
