using UnityEngine;
using UnityEngine.Rendering;

public class ImpactGlobalVolume : MonoBehaviour
{
    private Volume volume;
    public float ease = 0.1f;


    void Start()
    {
        volume = GetComponent<Volume>();
    }

    private void Update()
    {
        volume.weight = Mathf.Lerp(volume.weight, 0f, ease);
    }

    public void Impact()
    {
        volume.weight = 1f;
    }
}
