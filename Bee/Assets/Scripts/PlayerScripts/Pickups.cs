using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pickups : MonoBehaviour
{

    public GameObject item;
    public Transform spawnPoint;

    private GameObject spawnedItem;

    //int pollenModifier;
    public int nectarCount;

    bool canPickup;
    bool pollinated;

    // Start is called before the first frame update
    void Start()
    {
        SpawnCollectables();
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickup)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("e pressed");
                canPickup = false;

                Singleton.Instance.nectarCount += Singleton.Instance.pollenModifier;

                Destroy(spawnedItem);

                StartCoroutine(Wait());
            }
        }

        
    }
    private IEnumerator Wait()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(5f);


        SpawnCollectables();
        Debug.Log("Waited 5 secs");
    }

    public GameObject SpawnCollectables()
    {

        spawnedItem = Instantiate(item, spawnPoint.position, spawnPoint.rotation);

        return spawnedItem;
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            Debug.Log("Colliding with player");
            canPickup = true;
        }

    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            canPickup = false;
        }

    }


    
}
