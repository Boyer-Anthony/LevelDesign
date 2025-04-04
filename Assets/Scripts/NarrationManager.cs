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
                if (other.gameObject.CompareTag("Roue"))  // Exemple parfait du switch qui permet d'itÈrer plusieur Ètat d'une meme variable et Èviter la rÈpÈtition if/else if
                {
                    // DÈsactive l'UI fromageScore
                    scoreFromage.SetActive(false);

                    // Affiche le texte
                    panelRoueRat.SetActive(true);
                }
                break;

            case "Voix 1":

                // DÈsactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelVoix.SetActive(true);
                break;

            case "SiriusBlack":

                // DÈsactive l'UI fromageScore
                scoreFromage.SetActive(false);

                // Affiche le texte
                panelSiriusBlack.SetActive(true);
                break;

            case "Mort":

                // DÈsactive l'UI fromageScore
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

                // RÈActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // DÈsactive le texte
                panelRoueRat.SetActive(false);
                break;

            case "Voix 1":

                // RÈActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // DÈsactive le texte
                panelVoix.SetActive(false);
                break;

            case "SiriusBlack":

                // RÈActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // DÈsactive le texte
                panelSiriusBlack.SetActive(false);
                break;

            case "Mort":

                // RÈActive l'UI fromageScore
                scoreFromage.SetActive(true);

                // DÈsactive le texte
                panelMort.SetActive(false);
                break;


            case null:
                Debug.Log($"{other.tag} introuvable");
                break;


        }




    }
}
