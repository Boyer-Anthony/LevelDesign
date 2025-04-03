using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageScript : MonoBehaviour
{
    public Animator anim;

    public GameObject Cage; // L'objet � d�truire
    public int collectedObjects = 0;
    private int requiredObjects = 5; // Nombre d'objets requis

    [Header("Porte bleu")]
    public GameObject porteBleu;
    public int collectCheeseBlue = 0;
    //private int requiredCheeseBlue = 1; // Nombre fromage bleu requis



    private void OnTriggerEnter(Collider other)
    {
        // V�rifier si l'objet collect� est un des objets sp�cifiques
        if (other.CompareTag("Collectible"))
        {
            collectedObjects++;
            Destroy(other.gameObject); // D�truit l'objet collect�

            
            // V�rifier si tous les objets requis ont �t� collect�s
            if (collectedObjects >= requiredObjects && Cage != null)
            {
                Destroy(Cage); // D�truit l'objet cible
                anim.SetBool("Finish", true);
                Debug.Log("Tous les objets ont �t� collect�s. Objet cible d�truit !");
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
