using UnityEngine;
using System.Collections;

public class Reset : MonoBehaviour {

	public	void	Clear() {
		GameObject[] tItems = GameObject.FindGameObjectsWithTag ("Player");
		foreach (GameObject tGO in tItems) {
			GameObject.Destroy (tGO);
		}
	}
}
