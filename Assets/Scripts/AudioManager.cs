using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    [Header("Audio")]
    public AudioClip whiteNoice;
    private AudioSource son;

    private void Awake()
    {
        //Configurer le GameManager comme singleton

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); //Empeche les doublons
        }
    }
    private void Start()
    {
        son = GetComponent<AudioSource>();
    }

    public void ScreamerPlay()
    {
        son.clip = whiteNoice;
        son.Play();
    }
    
    public void ScreamerStop()
    {
        son.Stop();
    }
}
