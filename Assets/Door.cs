using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using VRTK;

public class Door : VRTK_InteractableObject
{
    public GameObject key;
    public GameObject inventory;
    public GameObject light;
    public GameObject speakers;
    public AudioClip succes;
    public AudioClip fail;
    public string nextSceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key))
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.green;
            light.GetComponentInChildren<Light>().color = Color.green;
            speakers.GetComponent<AudioSource>().clip = succes;
        } else
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.red;
            light.GetComponentInChildren<Light>().color = Color.red;
            speakers.GetComponent<AudioSource>().clip = fail;
        }
	}

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        speakers.GetComponent<AudioSource>().Play();
        if(GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key)) {
            Debug.Log("Won");
            if (nextSceneName.Length > 0)
            {
                StartCoroutine(LoadNewLevelAfter(2.5f));
            }
        } else
        {
            Debug.Log("Such weiter.");
        }
    }

    IEnumerator LoadNewLevelAfter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(nextSceneName);
    }
}
