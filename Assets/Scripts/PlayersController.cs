using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class PlayersController : MonoBehaviour
{
    public float speed;
    private Rigidbody rigBod;
    public PhysicMaterial ballBounce;
    public float velocityJump;
    private int jumpAmt = 1;
    public static int myScore = 0;
    private Scene mainScene;

    void Start()
    {
        rigBod = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float horizontalMove, newHorizontalMove ;
        float verticalMove;
        
        horizontalMove = Input.GetAxis("Horizontal");
        verticalMove = Input.GetAxis("Vertical");

        newHorizontalMove = Input.GetAxis("newHorizontal");

        mainScene = SceneManager.GetActiveScene();

        if (mainScene.name != "bouncelvl3")
        {
            //Vector3 movement = new Vector3(horizontalMove, 0.0f, verticalMove);
            Vector3 movement = new Vector3(verticalMove, 0.0f, newHorizontalMove);
            rigBod.AddForce(movement * speed);
        }
        else if (mainScene.name == "bouncelvl3")
        {
            Vector3 movement = new Vector3(verticalMove, 0.0f, newHorizontalMove);
            rigBod.AddForce(movement * speed);
        }

    /*---------------------------------------------------------------------
    *              Checks if the jump amount is greater then 0
    *                  if it is, pressing the space button
    *                      will get the player to jump
    *              As well sets the r button as a reset button
    *                      that resets the level/scene
    *--------------------------------------------------------------------*/

        if (jumpAmt >= 1)
        {
            if (Input.GetKeyDown("space"))
            {
                rigBod.velocity = Vector3.up * velocityJump;
                jumpAmt = jumpAmt - 1;
            }
        }
        if (Input.GetKeyDown("r"))
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
            if (myScore != 0)
            {
                myScore = myScore - 5;
 //               Debug.Log(message: myScore);
                //CheckGivenPoint.givenPoint = false;
            }
        }
    /*-----------------------------------------------------------------------
    *                      Controls for switching off
    *                              bounciness
    *-----------------------------------------------------------------------*/
        if (Input.GetKeyDown("left shift") || Input.GetKeyDown("right shift"))
        {
            ballBounce.bounciness = 0;
        }
        else if (Input.GetKeyDown("left ctrl") || Input.GetKeyDown("right ctrl"))
        {
            ballBounce.bounciness = 1;
        }
    }


    /*----------------------------------------------------------------------------------------
     * 
     *      This function checks using the name or tag for when it hits a level
     *      changing block and a path block to either give points or switch level.
     *      As well as subtract points when hitting a reset tagged block,
     *      and helps to reset the jump counter when colliding with a block.
     * 
     *---------------------------------------------------------------------------------------*/
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.name == "purpleBlock" || collision.collider.name == "purpleBlock1" || collision.collider.name == "purpleBlock2")
        {
            SceneManager.LoadSceneAsync(2);
        }
        else if (collision.collider.name == "yellowBlock" || collision.collider.name == "yellowBlock2")
        {
            SceneManager.LoadSceneAsync(1);
        }
        else if (collision.collider.name == "redBlock")
        {
            SceneManager.LoadSceneAsync(3);
        }
        else if (collision.collider.name == "blackBlock" || collision.collider.name == "whiteBlock")
        {
            SceneManager.LoadSceneAsync(4);
        }

        if (collision.collider.name == "Cube")
        {
            jumpAmt = 1;
        }

       /* if (collision.collider.tag == "path1")
        {
            if (CheckGivenPoint.givenPoint == false)
            {
                myScore = myScore + 1;
            }
//            Debug.Log(message: myScore);
        }
        else if (collision.collider.tag == "path2")
        {
            if (CheckGivenPoint.givenPoint == false)
            {
                myScore = myScore + 2;
//                Debug.Log(message: myScore);
            }
        }
        else if (collision.collider.tag == "path3")
        {
            if (CheckGivenPoint.givenPoint == false)
            {
                myScore = myScore + 3;
//                Debug.Log(message: myScore);
            }
        }*/
        else if (collision.collider.tag == "lvlChng")
        {
            myScore = myScore + 4;
//            Debug.Log(message: myScore);
        }
        else if (collision.collider.tag == "lvlChn1")
        {
            myScore = myScore + 8;
//            Debug.Log(message: myScore);
        }
        else if (collision.collider.tag == "lvlChng2")
        {
            myScore = myScore + 12;
//            Debug.Log(message: myScore);
        }
        else if (collision.collider.tag == "reset")
        {
            if (myScore != 0)
            {
                myScore = myScore - 3;
//              Debug.Log(message: myScore);
               // CheckGivenPoint.givenPoint = false;
            }
        }
    }
}
