using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int CurrentHealth;
    public int MaxHealth;
    public PlayerMovement playerMovement;

    public HealthBar healthBar;
    void Start()
    {
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            playerMovement.animator.SetTrigger("Died");
            playerMovement.moveSpeed = 0f;

            Invoke("respawnPlayer", 1);
        }

        healthBar.SetHealth(CurrentHealth);

    }

    private void respawnPlayer()
    {
        //playerMovement.respawnPlayer();
        this.transform.position *= 0;
        playerMovement.moveSpeed = 4f;

        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        GameObject world = GameObject.Find("WorldGen");
        world.GetComponent<worldGenerator>().ResetLevel();
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        TakeDamage(10);
    }
}
