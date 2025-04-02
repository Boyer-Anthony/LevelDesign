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

            // V�rifier si tous les objets requis ont �t� collect�s
            if (collectCheesePurple >= requiredCheesePurple)
            {
                Destroy(grillPurple); // D�truit la porte mauve

                Debug.Log("La grille mauve � sauter");
            }


        }
    }
}
