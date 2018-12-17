using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VRTK;

public class Door : VRTK_InteractableObject
{
    public GameObject key;
    public GameObject inventory;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key))
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.green;
        } else
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.red;
        }
	}

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        if(GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key)) {
            Debug.Log("Won");
        } else
        {
            Debug.Log("Such weiter.");
        }
    }
}
