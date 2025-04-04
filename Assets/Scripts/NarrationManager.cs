using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NarrationManager : MonoBehaviour
{
    public GameObject scoreFromage;

    [Header("Narration Roue Rat")]
    public GameObject panelRoueRat;
    [Header("Narration Voix")]
    public GameObject panelVoix;
    [Header("Sirius Black")]
    public GameObject panelSiriusBlack;
    [Header("Mort")]
    public GameObject panelMort;



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

            case "Mort":

                // D�sactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelMort.SetActive(true);
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

            case "Mort":

                // R�Active l'UI fromageScore
                scoreFromage.SetActive(true);

                // D�sactive le texte
                panelMort.SetActive(false);
                break;


            case null:
                Debug.Log($"{other.tag} introuvable");
                break;


        }




    }
}
