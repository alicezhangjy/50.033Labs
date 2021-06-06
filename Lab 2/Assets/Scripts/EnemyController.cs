using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private float originalX;
    private float maxOffset = 5.0f; //allow enemy to patrol up to 5.0 units to left and right
    private float enemyPatroltime = 2.0f;
    private int moveRight = -1;
    private Vector2 velocity;
    private Rigidbody2D enemyBody;
    // Start is called before the first frame update
    void Start()
    {
        enemyBody = GetComponent<Rigidbody2D>();
        //get the starting position
        originalX = transform.position.x;
        ComputeVelocity();

    }
    void ComputeVelocity()
    {
        velocity = new Vector2((moveRight) * maxOffset / enemyPatroltime, 0);
    }

    void MoveGomba()
    {
        enemyBody.MovePosition(enemyBody.position + velocity * Time.fixedDeltaTime);
    }
    // Update is called once per frame
    void Update()
    {
        if (Mathf.Abs(enemyBody.position.x - originalX) < maxOffset) //if gomba isn't too far from its starting position yet, move it to its designated direction
        {// move gomba
            MoveGomba();
        }
        else //flip direction
        {
            // change direction
            moveRight *= -1;
            ComputeVelocity();
            MoveGomba();
        }
    }

}
