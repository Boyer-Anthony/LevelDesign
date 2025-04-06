using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinManager : MonoBehaviour
{
    [Header("Fin 1")]
    public GameObject createur;
    public GameObject textCreateur;
    public GameObject textNarration;
    public Button skip;

    private void Start()
    {
        skip.enabled = false;
        StartCoroutine(WaitingFin1());
    }

    private IEnumerator WaitingFin1()
    {
        yield return new WaitForSeconds(2f);
        createur.SetActive(true);
        yield return new WaitForSeconds(1f);
        textCreateur.SetActive(true);
        yield return new WaitForSeconds(3f);
        textNarration.SetActive(true);
        skip.enabled = true;


    }

    public void Exit()
    {
        Debug.Log("Sortir");
    }
}
