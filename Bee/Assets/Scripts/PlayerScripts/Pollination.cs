using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pollination : MonoBehaviour
{
    bool particleCollided;
    bool pollinated;
    bool toggle;

    private ParticleSystem pSystem;

    public List<GameObject> pollinatedFlowers =  new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        pSystem = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            toggle = !toggle;

            if (toggle)
            {
                pSystem.Play();
                print("Toggled ON");
            }

            else
            {
                pSystem.Stop();
                print("Toggled OFF");
            }

        }

        if (pollinated)
        {
            Singleton.Instance.pollenModifier = 5;
        }
        else
        {
            Singleton.Instance.pollenModifier = 3;
        }
    }

    private void LateUpdate()
    {
        pollinated = false;
    }



    private void OnParticleTrigger()
    {
        Debug.Log("Pollinated flower");
        pollinated = true;

    }



    //private void OnTriggerEnter(Collider col)
    //{
    //    if (particleCollided)
    //    {

    //        if (col.gameObject.tag == "Pickup")
    //        {
    //            Debug.Log("Colliding after particles");
    //            pollinatedFlowers.Add(gameObject);

    //            pollinated = true;

    //            for (int i = 0; i < pollinatedFlowers.Count; i++)
    //            {
    //                pollinated = true;

    //            }
    //        }


    //    }


    //}

    //private void OnTriggerExit(Collider collider)
    //{
    //    if (collider.gameObject.tag == "Player")
    //    {
    //        //canPickup = false;
    //    }

    //}



}
