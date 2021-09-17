using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class nextLevel : MonoBehaviour
{
    public void PrepareNextLevel()
    {
        var worldGen = GameObject.FindGameObjectWithTag("WorldGen");
        worldGen.SendMessage("NextLevel");
        GetComponentInParent<ControlCanvas>().SendMessage("setNextLevelCanvas",false);
    }
}
