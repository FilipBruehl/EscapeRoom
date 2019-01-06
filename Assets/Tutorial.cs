using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {
    public AudioClip[] TutAudio;
    public GameObject speaker;

	// Use this for initialization
	void Start () {
        StartCoroutine(TutSound());
    }
	
	// Update is called once per frame
	void Update () {
	}

    IEnumerator TutSound()
    {
        yield return new WaitForSeconds(5);

        foreach(AudioClip audio in TutAudio)
        {
            while (speaker.GetComponent<AudioSource>().isPlaying)
            {
                yield return new WaitForSeconds(0.1f);
            }
            speaker.GetComponent<AudioSource>().clip = audio;
            speaker.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(audio.length+1);
        }
    }
}
