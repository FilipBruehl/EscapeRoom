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
    public AudioClip[] succes;
    public AudioClip[] fail;
    public string nextSceneName;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key))
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.green;
            light.GetComponentInChildren<Light>().color = Color.green;
        } else
        {
            gameObject.GetComponent<Door>().touchHighlightColor = Color.red;
            light.GetComponentInChildren<Light>().color = Color.red;
        }
	}

    public override void StartUsing(VRTK_InteractUse currentUsingObject = null)
    {
        base.StartUsing(currentUsingObject);
        Debug.Log(gameObject.name + " start using");
        if(GameObject.Find(key.name).GetComponent<Key>().IsGrabbed() || inventory.GetComponent<Inventory>().HasItem(key)) {
            speakers.GetComponent<AudioSource>().clip = succes[Random.Range(0, succes.Length)];
            Debug.Log("Won");
            if (nextSceneName.Length > 0)
            {
                StartCoroutine(LoadNewLevelAfter(speakers.GetComponent<AudioSource>().clip.length));
            }
        } else
        {
            Debug.Log("Such weiter.");
            speakers.GetComponent<AudioSource>().clip = fail[Random.Range(0, succes.Length)];
        }
        if (!speakers.GetComponent<AudioSource>().isPlaying)
        {
            speakers.GetComponent<AudioSource>().Play();
        }
    }


    IEnumerator LoadNewLevelAfter(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        SceneManager.LoadScene(nextSceneName);
    }
}
