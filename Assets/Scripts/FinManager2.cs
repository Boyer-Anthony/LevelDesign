using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinManager2 : MonoBehaviour
{
    [Header("Fin 1")]
    public GameObject elderMouse;
    public GameObject textMouse;
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
        elderMouse.SetActive(true);
        yield return new WaitForSeconds(1f);
        textMouse.SetActive(true);
        yield return new WaitForSeconds(3f);
        textNarration.SetActive(true);
        skip.enabled = true;


    }
}
