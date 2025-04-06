using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.SceneManagement;

public class NarrationManager : MonoBehaviour
{
    public GameObject scoreFromage;


    [Header("SlenderMan")]
    public GameObject triggerSlenderman;
    public GameObject SlenderMan;
    [Header("Pièges")]
    public GameObject Lettre;
    public GameObject WallPiege;
    public GameObject lightSpot;
    public GameObject spotGhost;
    public GameObject triggerPiege;
    [Header("Lettre")]
    public GameObject panelLettre;
    [Header("Fin")]
    public GameObject transition;
    [Header("Narration Roue Rat")]
    public GameObject panelRoueRat;
    [Header("Narration Voix")]
    public GameObject panelVoix;
    [Header("Sirius Black")]
    public GameObject panelSiriusBlack;
    public GameObject panelSiriusBlackDead;
    [Header("Mort")]
    public GameObject panelMort;
    [Header("Screamer")]
    public GameObject panelScreamer;
    public GameObject triggerScreamer;
    public Animator moveScreamer;
    [Header("Audio")]
    public AudioClip whiteNoice;
    private AudioSource son;

    private void Start()
    {
        son = GetComponent<AudioSource>();

    }



    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {

            case "Roue":
                if (other.gameObject.CompareTag("Roue"))  // Exemple parfait du switch qui permet d'itérer plusieur état d'une meme variable et éviter la répétition if/else if
                {
                    // Désactive l'UI fromageScore
                    scoreFromage.SetActive(false);

                    // Affiche le texte
                    panelRoueRat.SetActive(true);
                }
                break;

            case "Voix 1":

                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelVoix.SetActive(true);
                break;

            case "SiriusBlack":

                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelSiriusBlack.SetActive(true);
                break;

            case "SiriusBlackDead":

                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelSiriusBlackDead.SetActive(true);
                break;


            case "Mort":

                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelMort.SetActive(true);
                break;

            case "Screamer":


                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelScreamer.SetActive(true);

                // Joue le son du screamer
                AudioManager.Instance.ScreamerAudioPlay();
                break;

            case "ScreamMove":

                // Attendre quelque seconde avant de jouer l'animation
                StartCoroutine(Waiting());
                break;

            case "EndOne":

                transition.SetActive(true);
                StartCoroutine(WaitingEndOne());
                break;

            case "EndTwo":

                transition.SetActive(true);
                StartCoroutine(WaitingEndTwo());
                break;

            case "Lettre":

                // Désactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelLettre.SetActive(true);
                break;

            case "Piège":

                // Active le Mur invisible
                WallPiege.SetActive(true);

                // Désactive la lumière de la pièce
                lightSpot.SetActive(false);

                // Active le spot ghost
                spotGhost.SetActive(true);

                // Activer trigger Slenderman
                triggerSlenderman.SetActive(true);

                Lettre.SetActive(false);
                break;

            case "SlenderMan":

                // Active le SlenderMan
                SlenderMan.SetActive(true);

                // Active son
                AudioManager.Instance.ScreamerPlay();
                break;


            case null:
                Debug.Log("Rien ne se passe...");
                break;


        }



    }

    private void OnTriggerExit(Collider other)
    {
        switch (other.tag)
        {
            case "Roue":

                // RéActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive le texte
                panelRoueRat.SetActive(false);
                break;

            case "Voix 1":

                // RéActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive le texte
                panelVoix.SetActive(false);
                break;

            case "SiriusBlack":

                // RéActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive le texte
                panelSiriusBlack.SetActive(false);
                break;

            case "SiriusBlackDead":

                // RéActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive le texte
                panelSiriusBlackDead.SetActive(false);
                break;

            case "Mort":

                // RéActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive le texte
                panelMort.SetActive(false);
                break;

            case "Screamer":

                // Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // Désactive l'ui screamer
                panelScreamer.SetActive(false);

                // Désactive le son
                AudioManager.Instance.ScreamerAudioStop();
                //son.Stop();

                // Détruit la trigger
                Destroy(triggerScreamer);
                break;

            case "Lettre":

                // Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // Affiche le texte
                panelLettre.SetActive(false);
                break;

            case "Piège": 

                // Désactive la trigger.
                triggerPiege.SetActive(false);
                break;

            case "SlenderMan":

                // Désactive le slenderman
                SlenderMan.SetActive(false);

                // Désactive la trigger
                triggerSlenderman.SetActive(false);

                // Désactive le son
                AudioManager.Instance.ScreamerStop();

                // Désactive le Wall
                WallPiege.SetActive(false);
                spotGhost.SetActive(false);
                break;


            case null:
                Debug.Log($"{other.tag} introuvable");
                break;


        }


    }

    private IEnumerator Waiting()
    {

        yield return new WaitForSeconds(1f);

        // Animation Screamer
        moveScreamer.SetBool("Move", true);
    }

    private IEnumerator WaitingEndOne()
    {
        yield return new WaitForSeconds(3.30f);
        SceneManager.LoadScene(2);
    }

    private IEnumerator WaitingEndTwo()
    {
        yield return new WaitForSeconds(3.30f);
        SceneManager.LoadScene(3);
    }
}
