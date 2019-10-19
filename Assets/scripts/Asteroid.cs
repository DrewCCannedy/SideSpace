using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		transform.position = new Vector3 (transform.position.x, (float)Random.Range (-4, 4), 0);
		speed = -7f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Destructor") {
			transform.position = new Vector3 (13, Random.Range (-4f, 4f), 0);
		}
	}
}
