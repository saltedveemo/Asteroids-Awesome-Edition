using Unity.VisualScripting;
using UnityEngine;

public class Collection : MonoBehaviour
{
    public GameObject particle;
    public SoundManager _SM;

    void Start()
    {
        _SM = GameObject.FindAnyObjectByType<SoundManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            _SM.PlayRandomSound(_SM.collectionSounds);
            Instantiate(particle, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
