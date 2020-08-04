using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//This sccript will be used to move the platform. For this mechanic to work we will need to make a sepereate script for each moving platform
//This is because the corrdinate points for each platform will be different.
//I think it is possible to make a single script that can be used for all oving platforms and can have manually inputed x and y maximums
public class MovingPlatform1 : MonoBehaviour
{
    //Move speed if public for testing purposes
    public float dirX, moveSpeed = 3f;
    //The moveRight bool will be used to check if the platoform has reached its maximum or minmum value (x or Y)
    bool moveRight = true;

    // Update is called once per frame
    void Update()
    {


        Debug.Log(moveRight);
        Debug.Log(transform.position.x);

        //Here we are essentially trapiing the object's x value to be within a certain range
        if (transform.position.x > -14f) //if the objects x position is too big, move it to the left
            moveRight = false;
        if (transform.position.x < -21f) //if the objects x position is too small, move it to the right
            moveRight = false;



        if (moveRight)
        {
            Debug.Log("move Right");
            transform.position = new Vector2(transform.position.x + moveSpeed * Time.deltaTime, transform.position.y);
        }
        else
        {
            Debug.Log("move Left");
            transform.position = new Vector2(transform.position.x - moveSpeed * Time.deltaTime, transform.position.y);
        }


    }
}
