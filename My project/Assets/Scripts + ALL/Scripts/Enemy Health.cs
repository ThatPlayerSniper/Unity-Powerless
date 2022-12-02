using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int health = 100;

    private int MAX_HEALTH = 100;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            //Damage(10); 
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            //Heal(10);
        }
    }

    public void SetHealthEnemy(int maxHealth, int health)
    {
        this.MAX_HEALTH = maxHealth;
        this.health = health;
    }


    public void EnemyDamage(int amount)
    {

        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");
        }

        this.health -= amount;

        if (health <= 0)
        {
            Die();
        }
    }

    public void EnemyHeal(int amount)
    {
        {

            if (amount < 0)
            {
                throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
            }

            bool wouldBeOverMaxHealth = health + amount > MAX_HEALTH;

            if (wouldBeOverMaxHealth)
            {
                this.health = MAX_HEALTH;
            }
            else
            {
                this.health += amount;
            }
        }
    }

    private void Die()
    {
        Debug.Log("i'm Dead!");
        Destroy(gameObject);
    }
}
