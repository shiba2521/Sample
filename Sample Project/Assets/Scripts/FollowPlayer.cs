using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    private GameObject target;
    private float speed;
    void Start()
    {
        speed = 0.01f;
        target = GameObject.FindGameObjectWithTag(MenuController.character.tag);
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.transform);
        transform.position += transform.forward * speed;
    }
}
