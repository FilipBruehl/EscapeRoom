using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class DoorOpener : MonoBehaviour {
    

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("BLA");
        /*if(collision.transform.GetChild(1).gameObject.CompareTag(gameObject.tag))
        {
            Debug.Log("Bla");
        }*/
    }
}
