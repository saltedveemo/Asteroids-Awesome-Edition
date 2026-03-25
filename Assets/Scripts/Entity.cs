using UnityEngine;
using UnityEngine.Rendering;
using static UnityEngine.ParticleSystem;

public class Entity : MonoBehaviour
{
    public float currentHealth;
    public float maxHealth = 1;

    public SoundManager _SM;

    public AudioClip impactSound;
    public AudioClip deathSound;

    public bool isPlayer = false;

    public ParticleSystem deathParticle;
    public ParticleSystem hitParticle;

    public void TakeDamage(float damage)
    {
        if (isPlayer) //impact fx
        {
            //volume impact
            ImpactGlobalVolume igv = FindAnyObjectByType<ImpactGlobalVolume>();
            Volume igvv = igv.GetComponent<Volume>();
            igvv.weight = 1f;

            //panel flash
            var _sf = FindAnyObjectByType<ScreenFlash>();
            _sf.Flash();

            var _cam = FindAnyObjectByType<CameraImpact>();
            _cam.Impact();
        }


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
        Instantiate(deathParticle, transform.position, transform.rotation);
        Destroy(gameObject);
    }

    public void InitiateSoundManager()
    {
        _SM = FindAnyObjectByType<SoundManager>();
    }
}
