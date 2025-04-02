using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheesePurpleScript : MonoBehaviour
{
    public GameObject grillPurple;
    public int collectCheesePurple = 0;
    private int requiredCheesePurple = 1; // Nombre fromage mauve requis



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheesePurple++;
            Destroy(this.gameObject);

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheesePurple >= requiredCheesePurple)
            {
                Destroy(grillPurple); // Détruit la porte mauve

                Debug.Log("La grille mauve à sauter");
            }


        }
    }
}
