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
    [Header("Pi�ges")]
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
                if (other.gameObject.CompareTag("Roue"))  // Exemple parfait du switch qui permet d'it�rer plusieur �tat d'une meme variable et �viter la r�p�tition if/else if
                {
                    // D�sactive l'UI fromageScore
                    scoreFromage.SetActive(false);

                    // Affiche le texte
                    panelRoueRat.SetActive(true);
                }
                break;

            case "Voix 1":

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelVoix.SetActive(true);
                break;

            case "SiriusBlack":

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelSiriusBlack.SetActive(true);
                break;

            case "SiriusBlackDead":

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelSiriusBlackDead.SetActive(true);
                break;


            case "Mort":

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelMort.SetActive(true);
                break;

            case "Screamer":


                // D�sactive l'UI fromageScore
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

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelLettre.SetActive(true);
                break;

            case "Pi�ge":

                // Active le Mur invisible
                WallPiege.SetActive(true);

                // D�sactive la lumi�re de la pi�ce
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

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelRoueRat.SetActive(false);
                break;

            case "Voix 1":

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelVoix.SetActive(false);
                break;

            case "SiriusBlack":

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelSiriusBlack.SetActive(false);
                break;

            case "SiriusBlackDead":

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelSiriusBlackDead.SetActive(false);
                break;

            case "Mort":

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelMort.SetActive(false);
                break;

            case "Screamer":

                // Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive l'ui screamer
                panelScreamer.SetActive(false);

                // D�sactive le son
                AudioManager.Instance.ScreamerAudioStop();
                //son.Stop();

                // D�truit la trigger
                Destroy(triggerScreamer);
                break;

            case "Lettre":

                // Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // Affiche le texte
                panelLettre.SetActive(false);
                break;

            case "Pi�ge": 

                // D�sactive la trigger.
                triggerPiege.SetActive(false);
                break;

            case "SlenderMan":

                // D�sactive le slenderman
                SlenderMan.SetActive(false);

                // D�sactive la trigger
                triggerSlenderman.SetActive(false);

                // D�sactive le son
                AudioManager.Instance.ScreamerStop();

                // D�sactive le Wall
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
