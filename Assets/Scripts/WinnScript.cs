using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinnScript : MonoBehaviour
{
    public GameObject Transition;
    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Transition.SetActive(true);
            StartCoroutine(WaitingEnd1());
            
        }
        else if (this.gameObject.CompareTag("EndTwo") && other.gameObject.CompareTag("Player"))
        {
            Transition.SetActive(true);
            StartCoroutine(WaitingEnd2());
            
        }
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private IEnumerator WaitingEnd1()
    {
        yield return new WaitForSeconds(3.30f);
        SceneManager.LoadScene(1);
    }
    private IEnumerator WaitingEnd2()
    {
        yield return new WaitForSeconds(3.30f);
        SceneManager.LoadScene(2);
    }
}
