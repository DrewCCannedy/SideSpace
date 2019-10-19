using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spawner : MonoBehaviour {
	public int enemiesKilled = 0;
	public GameObject enemy1;
	public GameObject enemy2;
	public GameObject enemy3;
	public Text text;

	private bool wave1, wave2, wave3, wave4;


	// Use this for initialization
	void Start () {
		GameObject e = Instantiate (enemy1);
		e.transform.position = new Vector3 (12, 3, 0);
		wave1 = true;
		wave2 = true;
		wave3 = true;
		wave4 = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (enemiesKilled == 1 && wave1) {
			GameObject e = Instantiate (enemy2);
			e.transform.position = new Vector3 (12, 3, 0);
			wave1 = false;
		}
		if (enemiesKilled == 2 && wave2) {
			GameObject e = Instantiate (enemy2);
			e.transform.position = new Vector3 (12, 3, 0);
			GameObject f = Instantiate (enemy1);
			f.transform.position = new Vector3 (12, -3, 0);
			wave2 = false;
		}
		if (enemiesKilled == 4 && wave3) {
			GameObject e = Instantiate (enemy2);
			e.transform.position = new Vector3 (12, 2, 0);
			GameObject f = Instantiate (enemy1);
			f.transform.position = new Vector3 (12, -2, 0);
			wave3 = false;
			GameObject g = Instantiate (enemy2);
			g.transform.position = new Vector3 (12, 4, 0);
			GameObject h = Instantiate (enemy1);
			h.transform.position = new Vector3 (12, -4, 0);
			wave3 = false;
		}
		if (enemiesKilled == 8 && wave4) {
			GameObject e = Instantiate (enemy3);
			e.transform.position = new Vector3 (12, 0, 0);
			wave4 = false;
		}
		if (enemiesKilled == 9)
			text.text = "YOU WIN!";
	}
}
