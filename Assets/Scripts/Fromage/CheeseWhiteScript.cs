using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CheeseWhiteScript : MonoBehaviour
{
    public GameObject grillWhite;
    public int collectCheeseWhite = 0;
    private int requiredCheeseBlue = 1; // Nombre fromage bleu requis

    [Header("Score White")]
    public GameObject scoreCheeseWhite;
    public TextMeshProUGUI scoreText;
    public GameObject screamer;

    private void Update()
    {
        if(scoreText != null)
        {
            scoreText.text = collectCheeseWhite.ToString() + "/1";
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheeseWhite++;
            Destroy(this.gameObject, 0.1f);

            // Active le screamer après avoir manger le fromage blanc
            screamer.SetActive(true);

           

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseWhite >= requiredCheeseBlue)
            {
                Destroy(grillWhite); // Détruit la porte bleu

                Debug.Log("La grille blanche à sauter");
            }


        }
    }
}
