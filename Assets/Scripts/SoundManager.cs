using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] collectionSounds;
    public AudioSource[] sfxAudioSources;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayRandomSound()
    {
        float minPitch = 0.8f;
        float maxPitch = 1.2f;
        int rnd = Random.Range(0, collectionSounds.Length);
        AudioSource availableAudioSource = GetAvailableAudioSource();
        availableAudioSource.clip = collectionSounds[rnd];
        availableAudioSource.pitch = Random.Range(minPitch, maxPitch);
        availableAudioSource.Play();
    }

    public AudioSource GetAvailableAudioSource()
    {
        AudioSource[] sources = sfxAudioSources;
        for (int i = 0; i < sources.Length; i++)
        {
            if (!sources[i].isPlaying)
                return sources[i];
        }

        return null;
    }
}
