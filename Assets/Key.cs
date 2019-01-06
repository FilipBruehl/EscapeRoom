using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class Key : VRTK_InteractableObject {
    public AudioClip keyGrabbed;
    public GameObject speaker;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        base.Grabbed(currentGrabbingObject);
        if(!speaker.GetComponent<AudioSource>().isPlaying)
        {
            speaker.GetComponent<AudioSource>().clip = keyGrabbed;
            speaker.GetComponent<AudioSource>().Play();
        }
        Debug.Log(gameObject.name + " grabbed " + currentGrabbingObject.transform.childCount);
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        GameObject.Find("Inventory").GetComponent<Inventory>().AddItem(gameObject);
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    {
        base.StopUsing(previousUsingObject);
        Debug.Log(gameObject.name + " stop using");
    }
}
