using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinScript : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collider)
    {
        var canvas = GameObject.FindGameObjectWithTag("Canvas");
        var player = GameObject.FindGameObjectWithTag("Player");

        canvas.SendMessage("setNextLevelCanvas", true);
        player.SendMessage("UnablePlayer");
    }
}
