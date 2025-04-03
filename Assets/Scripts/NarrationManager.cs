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

            case null:
                Debug.Log($"{other.tag} introuvable");
                break;


        }




    }
}
