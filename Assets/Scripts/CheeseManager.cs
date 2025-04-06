using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheeseManager : MonoBehaviour
{
    public static CheeseManager Instance;

    public int compteur = 0;
    public int declancheur = 3;
    public GameObject Fin1;

    public Animator arrowFinish;
    public Animator arrowFinish2;

    private void Awake()
    {
        //Configurer le GameManager comme singleton

        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject); //Empeche les doublons
        }
    }
    
    public void FinNumberOne()
    {
        compteur++;

        if (compteur >= declancheur)
        {
            Fin1.SetActive(true);
            arrowFinish.SetBool("Finish", true);
            arrowFinish2.SetBool("Finish", true);
        }
    }
}
