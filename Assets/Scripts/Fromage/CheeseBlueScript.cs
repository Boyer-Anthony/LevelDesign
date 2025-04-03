using System.Collections;
using System.Collections.Generic;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class CheeseBlueScript : MonoBehaviour
{
    public GameObject grillBlue;
    public int collectCheeseBlue = 0;
    private int requiredCheeseBlue = 1; // Nombre fromage bleu requis

  


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheeseBlue++;
            Destroy(this.gameObject);

          

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseBlue >= requiredCheeseBlue)
            {
                Destroy(grillBlue); // Détruit la porte bleu
               
                Debug.Log("La grille bleu à sauter");
            }


        }
    }

   

}
