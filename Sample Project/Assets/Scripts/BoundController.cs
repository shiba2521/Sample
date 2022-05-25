using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoundController : MonoBehaviour
{
    // Start is called before the first frame update
    private float xbound = 12f;
    private float zbound = 6f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ControllBound();

    }

    //Keep character in Scene
    private void ControllBound()
    {
        if (transform.position.x < -xbound)
        {
            transform.position = new Vector3(-xbound, 0, transform.position.z);
        }
        if (transform.position.x > xbound)
        {
            transform.position = new Vector3(xbound, 0, transform.position.z);
        }
        if (transform.position.z < -zbound)
        {
            transform.position = new Vector3(transform.position.x, 0, -zbound);
        }
        if (transform.position.z > zbound)
        {
            transform.position = new Vector3(transform.position.x, 0, zbound);
        }
    }
}
