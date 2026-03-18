using UnityEngine;

public class Entity : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 1;

    public SoundManager _SM;

    public AudioClip impactSound;
    public AudioClip deathSound;

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Death();
            _SM.PlaySound(deathSound);
        } 
        else
        {
            _SM.PlaySound(impactSound);
        }
    }
    public void Death()
    {
        Destroy(gameObject);
    }

    public void InitiateSoundManager()
    {
        _SM = FindAnyObjectByType<SoundManager>();
    }
}
