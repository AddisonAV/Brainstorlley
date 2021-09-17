using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Player : MonoBehaviour
{
    [FormerlySerializedAs("CurrentHealth")] public int currentHealth;
    [FormerlySerializedAs("MaxHealth")] public int maxHealth;
    public PlayerMovement playerMovement;
    public AudioSource dorzinha;
    public AudioSource death;
    public HealthBar healthBar;
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        playerMovement = this.gameObject.GetComponent<PlayerMovement>();
    }

    public void TakeDamage(int damage)
    {
        if (currentHealth > 0)
        {
            SoundManager.PlaySound(SoundManager.Sound.PlayerHurt,0.8f);
        }

        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            currentHealth = 0;
            playerMovement.animator.SetTrigger("Died");
            playerMovement.changeMoveSpeed(0);
            SoundManager.PlaySound(SoundManager.Sound.PlayerDie,1f);
            
            Invoke("respawnPlayer", 2.1f);
        }

        healthBar.SetHealth(currentHealth);

    }

    public void respawnPlayer()
    {
        //playerMovement.respawnPlayer();
        this.transform.position *= 0;
        playerMovement.resetMoveSpeed();

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

        GameObject world = GameObject.Find("WorldGen");
        world.GetComponent<worldGenerator>().ResetLevel();
    }

    public void respawnPlayer(bool nextLevel)
    {
        this.transform.position *= 0;
        playerMovement.resetMoveSpeed();
        maxHealth += 10;
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
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
