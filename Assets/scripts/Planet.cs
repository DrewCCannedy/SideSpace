using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet : MonoBehaviour {

	float speed;

	// Use this for initialization
	void Start () {
		speed = -1f;
	}

	// Update is called once per frame
	void Update () {
		transform.position += new Vector3 (speed * Time.deltaTime, 0, 0);
	}
}
