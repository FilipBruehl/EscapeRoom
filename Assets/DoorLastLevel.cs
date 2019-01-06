using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class DoorLastLevel : VRTK_InteractableObject
{
    public GameObject light;
    public GameObject speakers;
    public AudioClip fail;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    { 
        gameObject.GetComponent<DoorLastLevel>().touchHighlightColor = Color.red;
        light.GetComponentInChildren<Light>().color = Color.red;
    }

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        Debug.Log("Such weiter.");
        speakers.GetComponent<AudioSource>().clip = fail;
        if (!speakers.GetComponent<AudioSource>().isPlaying)
        {
            speakers.GetComponent<AudioSource>().Play();
        }
    }
}
