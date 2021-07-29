using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapLogic : MonoBehaviour
{
    public BoxCollider2D trap;
    public AudioSource sound;
    public UnityEvent enableTrap;
    //Start is called before the first frame update

    void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D player) { 
        if (player.tag == "Player")
        {
            enableTrap.Invoke();

        }

    }

}
