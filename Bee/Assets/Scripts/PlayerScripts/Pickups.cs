using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Pickups : MonoBehaviour
{

    public GameObject item;
    public Transform spawnPoint;

    private GameObject spawnedItem;

    //int pollenModifier;
    public int nectarCount;

    public TMP_Text colliderText;

    public List<GameObject> spawnedList = new List<GameObject>();

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
            if (spawnedList.Count >= 1)
            {
                colliderText.gameObject.SetActive(true);
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Debug.Log("e pressed");
                    canPickup = false;


                    Singleton.Instance.nectarCount += Singleton.Instance.pollenModifier;
                    colliderText.gameObject.SetActive(false);
                    Destroy(spawnedItem);
                    spawnedList.Clear();

                    StartCoroutine(Wait());
                }
            }
            
        }

        
    }
    private IEnumerator Wait()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(30f);


        SpawnCollectables();
        Debug.Log("Waited 5 secs");
    }

    public GameObject SpawnCollectables()
    {

        spawnedItem = Instantiate(item, spawnPoint.position, spawnPoint.rotation);

        spawnedList.Add(spawnedItem);
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
            colliderText.gameObject.SetActive(false);
        }

    }


    
}
