using UnityEngine;

public class Entity : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 1;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }

}
