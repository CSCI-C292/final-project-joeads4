using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollination : MonoBehaviour
{
    bool particleCollided;
    bool pollinated;
    public Collider collider;
    public List<GameObject> pollinatedFlowers =  new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    private void OnParticleTrigger()
    {
        Debug.Log("Pollinated flower");
        particleCollided = true;

    }



    private void OnTriggerEnter(Collider col)
    {
        col = collider;
        if (particleCollided)
        {
           
            Debug.Log("Colliding after particles");
            pollinatedFlowers.Add(gameObject);

            //pollinated = true;

            for (int i = 0; i < pollinatedFlowers.Count; i++)
            {
                pollinated = true;

            }
        }


    }

    //private void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        //canPickup = false;
    //    }

    //}



}
