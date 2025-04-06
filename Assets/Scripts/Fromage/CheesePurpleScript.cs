using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheesePurpleScript : MonoBehaviour
{
    public GameObject grillPurple;
    public int collectCheesePurple = 0;
    private int requiredCheesePurple = 1; // Nombre fromage mauve requis

    [Header("Score Purle")]
    public GameObject scoreCheesePurple;
    public TextMeshProUGUI scoreText;

    [Header("SiriusBlack")]
    public GameObject SiriusAlive;
    public GameObject SiriusDead;

    private void Update()
    {
        // Score Fromage Purple
        if (scoreText != null)
        {
            scoreText.text = collectCheesePurple.ToString() + "/1";
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheesePurple++;
            Destroy(this.gameObject, 0.1f);

            SiriusAlive.SetActive(false);
            SiriusDead.SetActive(true);

            

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheesePurple >= requiredCheesePurple)
            {
                Destroy(grillPurple); // Détruit la porte mauve

                CheeseManager.Instance.FinNumberOne();

                Debug.Log("La grille mauve à sauter");
            }


        }
    }
}
