using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioClip[] collectionSounds;
    public AudioClip[] explosionSounds;
    public AudioClip[] impactSounds;


    public AudioSource[] sfxAudioSources;



    public void PlayRandomSound(AudioClip[] soundCollection)
    {
        float minPitch = 0.8f;
        float maxPitch = 1.2f;
        int rnd = Random.Range(0, soundCollection.Length);
        AudioSource availableAudioSource = GetAvailableAudioSource(sfxAudioSources);
        availableAudioSource.clip = soundCollection[rnd];
        availableAudioSource.pitch = Random.Range(minPitch, maxPitch);
        availableAudioSource.Play();
    }
    
    public void PlaySound(AudioClip soundCollection)
    {
        float minPitch = 0.8f;
        float maxPitch = 1.2f;
        AudioSource availableAudioSource = GetAvailableAudioSource(sfxAudioSources);
        availableAudioSource.clip = soundCollection;
        availableAudioSource.pitch = Random.Range(minPitch, maxPitch);
        availableAudioSource.Play();
    }

    public AudioSource GetAvailableAudioSource(AudioSource[] sources)
    {
        for (int i = 0; i < sources.Length; i++)
        {
            if (!sources[i].isPlaying)
                return sources[i];
        }

        return null;
    }
}
