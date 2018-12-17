using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Key : VRTK_InteractableObject {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public override void Grabbed(VRTK_InteractGrab currentGrabbingObject = null)
    {
        base.Grabbed(currentGrabbingObject);
        Debug.Log(gameObject.name + " grabbed " + currentGrabbingObject.transform.childCount);
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        GameObject.FindGameObjectWithTag("Inventory").GetComponent("Inventory").AddItem(gameObject);
    }

    public override void StopUsing(VRTK_InteractUse previousUsingObject = null)
    {
        base.StopUsing(previousUsingObject);
        Debug.Log(gameObject.name + " stop using");
    }
}
