using System.Collections;
using System.Collections.Generic;
using UnityEditor.SceneManagement;
using UnityEngine;

public class soundTools : MonoBehaviour
{
    public static soundTools instance;
    public AudioSource audioSource;
    public AudioSource winAudioSource;
    public AudioClip[] audioClips;
    public GameObject anySound;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        winAudioSource = gameObject.AddComponent<AudioSource>();
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void play(int id)
    {
        audioSource.clip = audioClips[id];
        audioSource.Play();
    }
    //
    public void OnChiDou()
    {
        play(0);
        anySound.gameObject.SetActive(false);
        Invoke("show", 1);
    }
    public void show()
    {
        anySound.gameObject.SetActive(true);
    }

    public void OnPickUp()
    {
        play(5);
    }

    public void OnDie()
    {
        play(4);
    }

    public void Onwin()
    {
        winAudioSource.clip = audioClips[6];
        winAudioSource.Play();
    }
}
