using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlCanvas : MonoBehaviour
{
    public GameObject nextLevelCanvas;

    public void setNextLevelCanvas(bool show)
    {
        nextLevelCanvas.SetActive(show);
        if (show)
        {
            var worldGen = GameObject.FindGameObjectWithTag("WorldGen");
            worldGenerator world = worldGen.GetComponent<worldGenerator>();

            GameObject.FindGameObjectWithTag("Text").SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
            //GetComponentInChildren<timePlayed>().SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
            //GetComponentInChildren<timePlayed>().SendMessage("setTimePlayed", world.GetTimeFromLevelStart());
        }
    }


}
