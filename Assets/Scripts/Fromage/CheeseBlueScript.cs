using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.AI.Navigation;
using Unity.VisualScripting;
using UnityEngine;

public class CheeseBlueScript : MonoBehaviour
{
   
    public GameObject titan;
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

            // Active le son
            AudioManager.Instance.TitanAudio();
            AudioManager.Instance.TitanSpawn();

            

          

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseBlue >= requiredCheeseBlue)
            {
                Destroy(grillBlue); // Détruit la porte bleu

                CheeseManager.Instance.FinNumberOne();

                Debug.Log("La grille bleu à sauter");
            }


        }
    }

    

   

}
