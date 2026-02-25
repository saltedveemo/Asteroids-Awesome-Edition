using UnityEngine;

public class SpaceShip : MonoBehaviour
{
    public float enginePower = 10f;
    public float turnPower = 10f;

    private Rigidbody2D rb2D;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float hInput = Input.GetAxis("Horizontal");
        float vInput = Input.GetAxis("Vertical");

        Debug.Log(hInput);

        ApplyThrust(vInput);
        ApplyTorque(-hInput);
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
}
