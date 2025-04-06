using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None; // Curseur est libre non verrouiller au centre de l'écran
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
