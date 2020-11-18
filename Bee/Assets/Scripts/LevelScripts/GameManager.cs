using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public Collider flowerCollider;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {

        flowerCollider = collision.collider;
        if (Input.GetKeyDown("space"))
        {
            Destroy(gameObject);
        }
    }
}
