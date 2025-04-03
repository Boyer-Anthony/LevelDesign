using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseWhiteScript : MonoBehaviour
{
    public GameObject grillWhite;
    public int collectCheeseWhite = 0;
    private int requiredCheeseBlue = 1; // Nombre fromage bleu requis

    

   



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheeseWhite++;
            Destroy(this.gameObject);

           

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseWhite >= requiredCheeseBlue)
            {
                Destroy(grillWhite); // Détruit la porte bleu

                Debug.Log("La grille blanche à sauter");
            }


        }
    }
}
