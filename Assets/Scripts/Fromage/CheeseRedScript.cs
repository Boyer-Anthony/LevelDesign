using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Scripting;

public class CheeseRedScript : MonoBehaviour
{
    public GameObject grillExit;
    public int collectCheeseRed = 0;
    private int requiredCheeseRed = 3; // Nombre fromage mauve requis

    public bool Force;
    public bool zoneStronger;

    public GameObject triggerZone;
    
    public GameObject TexteStronger;

    public Animator arrowFinish;
    public Animator arrowFinish2;

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

            // Vérifier si tous les objets requis ont été collectés
            if (collectCheeseRed >= requiredCheeseRed)
            {
                Debug.Log("You feel stronger..");
                Force = true;     
                arrowFinish.SetBool("Finish", true);
                arrowFinish2.SetBool("Finish", true);
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
