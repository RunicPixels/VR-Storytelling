using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishFeeding : MonoBehaviour {
    private bool isFishFed = false;
    public string collidableTag = "Vissenvoer";
    private AudioSource src;

    public AudioClip succeedSound;

	// Use this for initialization
	void Start () {
		if(GetComponent<AudioSource>() != null) {
            src = GetComponent<AudioSource>();
        }
        else {
            src = gameObject.AddComponent<AudioSource>();
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other) {
        if(other.tag == collidableTag && !isFishFed) {
            isFishFed = true;
            src.PlayOneShot(succeedSound);
        }
    }
}
