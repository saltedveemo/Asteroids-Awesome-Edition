using UnityEngine;



public class SpaceShip : Entity
{
    public float enginePower = 10f;
    public float turnPower = 10f;



    private Rigidbody2D rb2D;

    public GameObject bulletReference;
    public float bulletSpeed;
    public float bulletLifeTime = 1f;
    public float fireRate = 0.33f;
    public float fireTimer = 0f;
    public float fireOffset = 10f;
    public GameObject firingPoint;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        InitiateSoundManager();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        ApplyThrust(vInput);
        ApplyTorque(-hInput);
        UpdateFiring();
    }



    private void ApplyThrust(float amount)
    {
        Vector2 thrust = transform.up * enginePower * amount * Time.deltaTime;
        rb2D.AddForce(thrust);
    }
    private void ApplyTorque(float amount)
    {
        float torque = turnPower * amount * Time.deltaTime;
        rb2D.AddTorque(torque);
    }







    public void FireBullet()
    {
       // float offset = transform.up + fireOffset;
        GameObject bullet = Instantiate(bulletReference, firingPoint.transform.position, transform.rotation);
        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

        Vector2 force = transform.up * bulletSpeed;
        rb.AddForce(force);
        Destroy(bullet, bulletLifeTime);
    }

    private void UpdateFiring()
    {
        bool isFiring = Input.GetButton("Fire1");
        fireTimer -= Time.deltaTime;
        if (isFiring && fireTimer <= 0f)
        {
            FireBullet();
            fireTimer = fireRate;
        }
    }
}
