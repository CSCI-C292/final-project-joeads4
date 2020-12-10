using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Pollen : MonoBehaviour
{
    //create an array of spawn points, assigned in inspector 
    public Transform[] pollenSpawnPoints = new Transform[5];

    //create an array of collectables to choose from
    public GameObject item;
    GameObject c;

    public TMP_Text pollenText;

    public int pollenCount;

    public int pollenModifier;

    private bool canPickupPollen;
    bool canDepositPollen;
    bool pollinated;
    // Use this for initialization
    void Start()
    {
        SpawnCollectables();
    }

    // Update is called once per frame
    void Update()
    {
        pollenText.text = "Current Nectar: " + Singleton.Instance.pollenTotal.ToString();

        if (canPickupPollen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("e pressed");
                canPickupPollen = false;
                

                Destroy(c);


                pollenCount = pollenCount + pollenModifier;
                Singleton.Instance.pollenTotal = pollenCount;

                StartCoroutine(Wait());
            }
        }

        if (canDepositPollen)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                Debug.Log("hive pressed");
                //canDepositPollen = false;

                Singleton.Instance.hiveTotal += pollenCount;
                Debug.Log("Hive total: " + Singleton.Instance.hiveTotal);

                pollenCount = 0;
                Singleton.Instance.pollenTotal = pollenCount;

                
            }
        }


        if (pollinated)
        {
            pollenModifier = 5;
        }
        else
        {
            pollenModifier = 3;
        }
    }

    private IEnumerator Wait()
    {
        Debug.Log("Coroutine started");
        yield return new WaitForSeconds(1f);
        SpawnCollectables();
        Debug.Log("Waited 5 secs");
    }

    //selects spawn point
    public Transform GetCollectableSpawnPoint()
    {
        //randomly selects a point out of the array
        int index = Random.Range(0, pollenSpawnPoints.Length);
        //returns the selected point
        return pollenSpawnPoints[index];
    }

    // spawns the random object on the random point
    public GameObject SpawnCollectables()
    {
    
        Transform spawnPoint = GetCollectableSpawnPoint();

        c = Instantiate(item, spawnPoint.position, spawnPoint.rotation);

        return c;
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            canPickupPollen = true;
        }
        if (collider.gameObject.tag == "Hive")
        {
            canDepositPollen = true;
        }
    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.gameObject.tag == "Pickup")
        {
            canPickupPollen = false;
        }
        if (collider.gameObject.tag == "Hive")
        {
            canDepositPollen = false;
        }
    }

    private void OnParticleTrigger()
    {
        Debug.Log("Pollinated flower");
        pollinated = true;
        
    }

  
}
