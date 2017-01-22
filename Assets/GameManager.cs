using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public	GameObject[]	ObjectPrefabs;

	static	public	GameManager GM;

	void Awake () {			//Singleton GameManager
		if (GM == null) {
			GM = this;
			DontDestroyOnLoad (gameObject);
		} else if (GM != this) {
			Destroy (gameObject);
		}
	}

	static	public	void	Spawn(int vType) {
		vType %= GM.ObjectPrefabs.Length;
		Instantiate (GM.ObjectPrefabs [vType]);
	}
}
