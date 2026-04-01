using UnityEngine;

public class Asteroid : Entity
{
    public int spawnValue;
    public float collisionDamage = 1f;
    public GameObject[] chunks;
    public int chunkMin = 1;
    public int chunkMax = 4;
    public float explodeDist = 5f;
    public float explosionForce = 50f;
    public int scoreValue = 1;

    private void Start()
    {
        InitiateSoundManager();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        SpaceShip ship = collision.gameObject.GetComponent<SpaceShip>();
        if (ship != null)
        {
            ship.TakeDamage(collisionDamage);
        }

        Bullet bullet = collision.gameObject.GetComponent<Bullet>();
        if (bullet != null)
        {
            Destroy(bullet.gameObject);
            BreakChunk();
            TakeDamage(bullet.damage);
        }
    }


    private void BreakChunk()
    {
        if (chunks.Length > 0)
        {
            int numChunks = Random.Range(chunkMin, chunkMax);
            for (int i = 0; i < numChunks; i++)
            {
                CreateAsteroidChunk();
            }
            _SM.PlayRandomSound(_SM.explosionSounds);
        }

       
    }

    private void CreateAsteroidChunk()
    {
        int rndIndex = Random.Range(0, chunks.Length);
        GameObject chunkRef = chunks[rndIndex];

        Vector2 spawnPos = transform.position;
        spawnPos.x += Random.Range(-explodeDist, explodeDist);
        spawnPos.y += Random.Range(-explodeDist, explodeDist);

        GameObject chunk = Instantiate(chunkRef, spawnPos, transform.rotation);

        
        Vector2 dir = (spawnPos - (Vector2)transform.position).normalized;

        Rigidbody2D rb = chunk.GetComponent<Rigidbody2D>();
            rb.AddForce(dir * explosionForce);
    }

    private void OnDestroy()
    {
        SpaceShip ship = FindFirstObjectByType<SpaceShip>();
        if (ship != null)
        {
            ship.score += scoreValue;
        }
    }
}
