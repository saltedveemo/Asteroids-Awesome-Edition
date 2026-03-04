using UnityEngine;

public class Asteroid : Entity
{
    public float collisionDamage = 1f;

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
            TakeDamage(bullet.damage);
        }
    }
}
