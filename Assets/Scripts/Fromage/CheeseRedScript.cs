using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class CheeseRedScript : MonoBehaviour
{
    public GameObject Createur;
    public GameObject End2;
    public GameObject grillExit;
    public int collectCheeseRed = 0;
    private int requiredCheeseRed = 3; // Nombre fromage mauve requis

    public bool Force;
    public bool zoneStronger;

    public GameObject triggerZone;
    
    public GameObject TexteStronger;

   

    public AudioClip eating;
    private AudioSource son;

    [Header("Score Rouge")]
    public GameObject scoreCheeseRed;
    public TextMeshProUGUI scoreText;




    private void Start()
    {
        son = GetComponent<AudioSource>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && Force && zoneStronger)
        {
            Destroy(grillExit);
            TexteStronger.SetActive(false);
        }

        // Score Fromage rouge
        if(scoreText != null)
        {
            scoreText.text = collectCheeseRed.ToString() + "/3";
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Red"))
        {
            collectCheeseRed++;
            son.clip = eating;
            son.Play();
            Destroy(other.gameObject);

            // Affiche l'UI fromage rouge.
            scoreCheeseRed.SetActive(true);

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseRed >= requiredCheeseRed)
            {
                Debug.Log("You feel stronger..");
                Force = true;

                // Active la Grill exit pour s'enfuir
                grillExit.SetActive(true);
                End2.SetActive(true);
                Createur.SetActive(false);

            }
        }

        // Son
        if (other.gameObject.CompareTag("Fromage"))
        {
            son.clip = eating;
            son.Play();
        }

        // Si il rentre dans la zone Stronger
        if (other.gameObject.CompareTag("Stronger") && collectCheeseRed >= requiredCheeseRed)
        {
            zoneStronger = true;
            TexteStronger.SetActive(true);
            Debug.Log("TriggerZone");
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        // Si il sort de la zone Stronger
        if (other.gameObject.CompareTag("Stronger"))
        {
            zoneStronger = false;
            TexteStronger.SetActive(false);   
        }
    }




}
