using UnityEngine;
using System.Collections;

public class Collide : MonoBehaviour {
	
	AudioSource[]	mAud;

	// Use this for initialization
	void Start () {
		mAud = GetComponents<AudioSource>();
	}

	void OnCollisionEnter2D(Collision2D coll) {
		mAud [1].Play ();
	}
}
