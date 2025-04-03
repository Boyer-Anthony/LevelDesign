using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class CheeseBlueScript : MonoBehaviour
{
    public GameObject grillBlue;
    public int collectCheeseBlue = 0;
    private int requiredCheeseBlue = 1; // Nombre fromage bleu requis

    [Header("Score Blue")]
    public GameObject scoreCheeseBlue;
    public TextMeshProUGUI scoreText;


    private void Update()
    {
        scoreText.text = collectCheeseBlue.ToString() + "/1";
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            collectCheeseBlue++;
            Destroy(this.gameObject, 0.1f);

          

            // V�rifier si tous les objets requis ont �t� collect�s
            if (collectCheeseBlue >= requiredCheeseBlue)
            {
                Destroy(grillBlue); // D�truit la porte bleu
               
                Debug.Log("La grille bleu � sauter");
            }


        }
    }

   

}
