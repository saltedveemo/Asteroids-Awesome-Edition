using UnityEngine;

public class SpaceshipMouseControls : Entity
{
    public float moveSpeed = 10f;
    public bool instantRotation = false;
    public float rotationSpeed;
    private Camera camera;
    private Rigidbody2D rb;
    private Vector2 inputMove;
    private float targetAngleDeg;



    public GameObject bulletReference;
    public float bulletSpeed;
    public float bulletLifeTime = 1f;
    public float fireRate = 0.33f;
    public float fireTimer = 0f;
    public float fireOffset = 10f;
    public GameObject firingPoint;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        camera = Camera.main;

    }

    private void Start()
    {
        currentHealth = maxHealth;
    }

    void Update()
    {
        UpdateFiring();

        inputMove = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        inputMove = Vector2.ClampMagnitude(inputMove, 1f);

        if (camera != null)
        {
            Vector3 mouseWorld3 = camera.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mouseWorld = new Vector2(mouseWorld3.x, mouseWorld3.y);

            Vector2 dir = mouseWorld - (Vector2)transform.position;

            if(dir.sqrMagnitude > 0.0001f)
            {
                if (instantRotation)
                {
                    transform.up = dir.normalized;
                }
                else
                {
                    targetAngleDeg = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg - 90;
                }
            }
        }
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

    private void FixedUpdate()
    {
        rb.linearVelocity = inputMove * moveSpeed;

        if (!instantRotation)
        {
       //     float newAngle = Mathf.MoveTowardsAngle(rb.rotation, targetAngleDeg, rotationSpeed * Time.fixedDeltaTime);
            float newAngle = Mathf.LerpAngle(rb.rotation, targetAngleDeg, 0.1f);
            rb.MoveRotation(newAngle);
        }
    }
}
