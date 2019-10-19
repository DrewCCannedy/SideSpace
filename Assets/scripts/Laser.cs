using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
		speed = 12f;
		if (this.tag == "Enemy")
			speed = -12f;
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (this.tag == "Enemy") {
			if (col.gameObject.tag == "Player" || col.gameObject.tag == "Destructor")
				Destroy (this.gameObject);
		}
		if (this.tag == "Laser") {
			if (col.gameObject.tag != "Player")
				Destroy (this.gameObject);
		}
	}
}
