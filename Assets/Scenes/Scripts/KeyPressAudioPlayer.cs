using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class KeyPressAudioPlayer : MonoBehaviour
{
    private AudioSource audioSource;
    private bool isPlaying = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else if (Input.anyKey)
        {
            if (!isPlaying)
            {
                audioSource.Play();
                isPlaying = true;
            }
        }
        else if (!Input.anyKey && isPlaying)
        {
            audioSource.Stop();
            isPlaying = false;
        }
    }
}