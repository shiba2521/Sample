using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


    

public class PlayerController : MonoBehaviour
{
    public float verticalInput;
    public float horizontalInput;
    public float speed; //character speed
    private Vector3 playerPosition;
    private Rigidbody rigid; //character Rigidbody
    public static bool gameover = false;

    

    private void Awake()
    {
        rigid = GetComponent<Rigidbody>();
        rigid.isKinematic = false;
    }


    void Start()
    {
        GetSpeed();
        playerPosition = GetComponent<Transform>().position;
        
        
    }

    
    void FixedUpdate()
    {
        
        verticalInput = Input.GetAxis("Vertical"); //input z direction
        horizontalInput = Input.GetAxis("Horizontal"); //input x direction
        MoveSeeingDirection();
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Skull"))
        {
            Debug.Log("Game Over");
            gameover = true;
            rigid.isKinematic = true;
        }
        if (other.CompareTag("Apple") && gameObject.tag == "Fox")
        {
            HitCounter.score += 2;
        }
        else if(other.CompareTag("Bone") && gameObject.tag == "Dog")
        {
            HitCounter.score += 3;
        }
        else if(other.CompareTag("Pizza") && gameObject.tag == "Human")
        {
            HitCounter.score += 4;
        }
        else
        {
            HitCounter.score++;
        }

    }

    //Change speed per character
    private void GetSpeed()
    {
        if (gameObject.tag == "Human")
        {
            speed = 10f;
        }
        if (gameObject.tag == "Dog")
        {
            speed = 20f;
        }
        if (gameObject.tag == "Fox")
        {
            speed = 15f;
        }
    }

    //Move character in facing direction
    private void MoveSeeingDirection()
    {
        //Update Rigidbody with value and move character
        rigid.velocity = new Vector3(horizontalInput * speed, 0, verticalInput * speed);
        
        //get character direction
        Vector3 diff = transform.position - playerPosition;
        if (diff.magnitude > 0.01f)
        {
            //rotate character
            transform.rotation = Quaternion.LookRotation(diff);
        }
        playerPosition = transform.position; //update character's position
    }

    


}

/*public class Human : PlayerController
{
    public GameObject player;
    public float speed;
    protected override void MovePlayer()
    {
        base.MovePlayer();
        player = GameObject.FindGameObjectWithTag("Human");
        speed = 10.0f;
        player.transform.Translate(speed * verticalInput * Time.deltaTime,0,speed * horizontalInput * Time.deltaTime);
        }
}*/

