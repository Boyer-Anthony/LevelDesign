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

            

            // V�rifier si tous les objets requis ont �t� collect�s
            if (collectCheesePurple >= requiredCheesePurple)
            {
                Destroy(grillPurple); // D�truit la porte mauve

                Debug.Log("La grille mauve � sauter");
            }


        }
    }
}
