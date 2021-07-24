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
            playerMovement.changeMoveSpeed(0);

            Invoke("respawnPlayer", 1);
        }

        healthBar.SetHealth(CurrentHealth);

    }

    public void respawnPlayer()
    {
        //playerMovement.respawnPlayer();
        this.transform.position *= 0;
        playerMovement.resetMoveSpeed();

        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);

        GameObject world = GameObject.Find("WorldGen");
        world.GetComponent<worldGenerator>().ResetLevel();
    }

    public void respawnPlayer(bool nextLevel)
    {
        this.transform.position *= 0;
        playerMovement.resetMoveSpeed();
        MaxHealth += 10;
        CurrentHealth = MaxHealth;
        healthBar.SetMaxHealth(MaxHealth);
    }

    public void UnablePlayer()
    {
        this.playerMovement.changeMoveSpeed(0);
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        if(collider.tag == "realTrap") TakeDamage(10);
    }
}
