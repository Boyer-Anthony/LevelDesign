using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCManager : MonoBehaviour
{
    [SerializeField] private GameObject npcPrefabs;
    [SerializeField] private Vector3 spawnOffset;

    // File (Queue)
    private Queue<GameObject> file = new Queue<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        spawnOffset = npcPrefabs.transform.position;
        

        // Instancier 5 NPC en file

        for (int i = 0; i < 4; i++)
        {
            spawnOffset.z += 1;

            GameObject newObject = Instantiate(npcPrefabs, spawnOffset, Quaternion.identity);
            newObject.name = "NPC" + i;

            // Ajouter NPC dans la file
            file.Enqueue(newObject);


            

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
