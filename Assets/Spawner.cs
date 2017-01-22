using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public	void	Spawn(int vType=-1) {
		if (vType < 0) {
			vType = Random.Range (0, 100);
		}
		GameManager.Spawn (vType);
	}
}
