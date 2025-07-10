using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundFXManager : MonoBehaviour
{
    public static SoundFXManager instance;
    [SerializeField] private AudioSource soundFXObject;

    private void Awake() 
    {
        {
            if (instance == null)
            {
                instance = this;
            }
        }
    }

    public void PlayerSoundFXClip(AudioClip audioclip, Transform spawnTransform, float volume, float minPitch, float maxPitch)
    {
        AudioSource audioSource = Instantiate(soundFXObject, spawnTransform.position, Quaternion.identity);

        audioSource.clip = audioclip;
        audioSource.volume = volume;

        // Randomize pitch within the given range
        audioSource.pitch = Random.Range(minPitch, maxPitch);

        audioSource.Play();
        float clipLength = audioSource.clip.length / audioSource.pitch;;

        Destroy(audioSource.gameObject, clipLength);
    }
}
