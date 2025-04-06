using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public GameObject lightening;
    public GameObject titan;

    [Header("Audio")]
    public AudioClip whiteNoice;
    public AudioClip audioTitan;
    public AudioClip souricière;
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
    public void ScreamerAudioPlay()
    {
        son.clip = souricière;
        son.Play();
    }
    
    public void ScreamerStop()
    {
        son.Stop();
    }
    
    public void ScreamerAudioStop()
    {
        son.Stop();
    }

    public void TitanAudio()
    {
        son.clip = audioTitan;
        son.Play();
    }

    public void TitanSpawn()
    {
        StartCoroutine(TitanWait());
    }


    private IEnumerator TitanWait()
    {
        yield return new WaitForSeconds(6f);

        // Active le titan
        lightening.SetActive(true);

        yield return new WaitForSeconds(1f);

        lightening.SetActive(false);
        titan.SetActive(true);

    }
}
