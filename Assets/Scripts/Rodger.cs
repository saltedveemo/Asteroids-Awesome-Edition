using UnityEngine;

public class Rodger : TennisPlayer
{
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            Swing("Rodger swings");
        }
    }
}
