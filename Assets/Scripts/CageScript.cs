using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    public Animator anim;

    public GameObject Cage; // L'objet à détruire
    public int collectedObjects = 0;
    private int requiredObjects = 5; // Nombre d'objets requis

    [Header("Porte bleu")]
    public GameObject porteBleu;
    public int collectCheeseBlue = 0;
    //private int requiredCheeseBlue = 1; // Nombre fromage bleu requis



    private void OnTriggerEnter(Collider other)
    {
        // Vérifier si l'objet collecté est un des objets spécifiques
        if (other.CompareTag("Collectible"))
        {
            collectedObjects++;
            Destroy(other.gameObject); // Détruit l'objet collecté

            
            // Vérifier si tous les objets requis ont été collectés
            if (collectedObjects >= requiredObjects && Cage != null)
            {
                Destroy(Cage); // Détruit l'objet cible
                anim.SetBool("Finish", true);
                Debug.Log("Tous les objets ont été collectés. Objet cible détruit !");
            }
        }
    }

    private void CheeseBlue()
    {
        if (gameObject.CompareTag("BlueCheese"))
        {
            collectCheeseBlue++;
            
        }
    }
}
