using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraContoller : MonoBehaviour {

    public GameObject thePlayer;
    public GameObject myCamera;
    public float rotating;
    public float panOut;
    private Vector3 offsetPlayer, posOne, posTwo, PosThree, PosFour;
    
   
	void Start()
    {
        offsetPlayer = transform.position - thePlayer.transform.position;
        //offsetCamera = transform.position - myCamera.transform.position;
    }

    void Update()
    {
        if (Input.GetKeyDown("q"))
        {
            //transform.position = 
        }
        else if (Input.GetKeyDown("e"))
        {
           // transform.position = thePlayer.transform + offsetCamera;
        } 

        transform.position = thePlayer.transform.position + offsetPlayer;

    }
}
