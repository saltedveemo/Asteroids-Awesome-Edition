using UnityEngine;

public class TennisPlayer : MonoBehaviour
{
    public int playerNumber;
    public float speed;
    public float hitPower;
    

    void Start()
    {
        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Swing("Swing");
        }
    }

    public void Swing(string _text)
    {
        Debug.Log(_text);
    }
}
