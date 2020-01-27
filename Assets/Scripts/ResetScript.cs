using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetScript : MonoBehaviour {

    public Collider coll;

    void Start()
    {
        coll = GetComponent<Collider>();
        coll.isTrigger = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.attachedRigidbody)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
