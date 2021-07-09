using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TrapLogic : MonoBehaviour
{
    public BoxCollider2D trap;
    public UnityEvent enableTrap;
    //Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){

        Debug.Log("caiu na trap");
        
        //Activate trap on collision
        enableTrap.Invoke();
        
    }
}
