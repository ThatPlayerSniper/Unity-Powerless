using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int currentHealth = 100;
    [SerializeField] public int MAX_HEALTH = 100;

    //  private bool Dead = false;
    

    public void ResetHealth()
    {
        currentHealth = MAX_HEALTH;
    }

    void Start()
    {
        ResetHealth();
    }


    public void Damage(int amount)
    {
        if (amount < 0) throw new System.ArgumentOutOfRangeException("Cannot have negative Damage");

        currentHealth -= amount;

        StartCoroutine(VisualIndicator(Color.red));
        
        if (currentHealth <= 0)
        {
            Die();        
        }
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {
            throw new System.ArgumentOutOfRangeException("Cannot have negative healing");
        }

         bool wouldBeOverMaxHealth = currentHealth + amount > MAX_HEALTH;

        currentHealth = wouldBeOverMaxHealth ? MAX_HEALTH : currentHealth + amount;
        
        // Same thing as above ^
        //if (wouldBeOverMaxHealth)
        //{
        //    currentHealth = MAX_HEALTH;
        //}
        //else
        //{
        //    currentHealth += amount;
        //}
    }
    public void Die()
    {
        Debug.Log("i'm Dead! 1");
        Destroy(gameObject);
    }
   
     private IEnumerator VisualIndicator(Color color)
    {
        GetComponent<SpriteRenderer>().color = color;
        yield return new WaitForSeconds(0.15f);
        GetComponent<SpriteRenderer>().color = Color.white;
    }

/*    public IEnumerator DeathAnim()
    {
        {
            Debug.Log("I'm dead com cebolas :)");
            yield return new WaitForSeconds(3);
            Destroy(gameObject);
        }
    }*/
}
