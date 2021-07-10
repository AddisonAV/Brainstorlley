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
        //trap = GetComponent<BoxCollider2D>();
        //sound = GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D collision){

        Debug.Log("caiu na trap");
        //sound.Play();
        //sound.Play();
        //Activate trap on collision
        enableTrap.Invoke();
        //Destroy(this.gameObject, 5);

    }
}
