using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsummableMushroomController : MonoBehaviour
{

    private Rigidbody2D rigidBody;
    
    private float speed;
    private int moveRight = -1;
    private Vector2 velocity;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        rigidBody.AddForce(Vector2.up * 20, ForceMode2D.Impulse); //using Impulse not Force because the upward force using Force will be applied over 1 second (not immediate)

        //ForceMode2D.Impulse == i want this force NOW 
        //ForceMode2D.Force == I want to apply this much force IF we called the addForce() method continuously for 50 times over 1 second means (same force spread out for ONE second)

        speed = 4f;
        ComputeVelocity();

    }

    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * speed, 0);
        // Debug.Log(velocity);
    }

    // Update is called once per frame
    void Update()
    {
        MoveMushroom();
    }

    void MoveMushroom()
    {
        //this is just a simple moving to the left calculation. need to check if mushroom hits obstacles then change direction in compute velocity
        rigidBody.MovePosition(rigidBody.position + velocity * Time.fixedDeltaTime);
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Pipe"))
        {
            Debug.Log("Collided with Pipe");
            moveRight = moveRight * -1;
            ComputeVelocity();
            MoveMushroom();
        }
        if(col.gameObject.CompareTag("Player")){
            speed = 0.0f;
            ComputeVelocity();
            MoveMushroom();
        }

    }
    void OnBecameInvisible(){
        Destroy(gameObject);
    }
}
