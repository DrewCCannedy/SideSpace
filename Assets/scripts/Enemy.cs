using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour {
	public int health;
	public float speed;
	public float yspeed;
	public Laser laser;
	public ParticleSystem particle;

	private Spawner spawner;
	private bool canSwitch;
	private float shootTimer;
	private float ultTimer;

	// Use this for initialization
	void Start () {
		health = 1;
		if (gameObject.name == "Boss(Clone)")
			health = 8;
		speed = 5f;
		yspeed = 4f;
		shootTimer = 0f;
		ultTimer = Time.time + 2f;
		canSwitch = true;
		spawner = FindObjectOfType<Spawner>();
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 1)
			Die ();
		Shoot ();
		Move ();
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Laser") {
			if (this.gameObject.name == "Enemy1(Clone)") {
				if (col.gameObject.name == "Laser0(Clone)")
					health--;
			} else if (this.gameObject.name == "Enemy2(Clone)") {
				if (col.gameObject.name == "Laser1(Clone)")
					health--;
			} else
				health--;
		}
	}

	void Die(){
		spawner.enemiesKilled++;
		var exp = Instantiate (particle);
		exp.transform.position = transform.position;
		exp.Play ();
		Destroy (gameObject);
	}

	void Shoot(){
		if (gameObject.name == "Boss(Clone)") {
			if (shootTimer < Time.time) {
				Laser l1, l2;
				l1 = Instantiate (laser);
				l2 = Instantiate (laser);
				l1.transform.position = transform.position + new Vector3 (0, .5f, 0);
				l2.transform.position = transform.position + new Vector3 (0, -.5f, 0);
				shootTimer = Time.time + .6f;
			}
			if (ultTimer < Time.time) {
				Laser l;
				l = Instantiate (laser);
				l.transform.position = transform.position;
				l.transform.localScale += new Vector3 (5, 5, 0);
				ultTimer = Time.time + 2f;
			}
		} else {
			if (shootTimer < Time.time) {
				Laser l;
				l = Instantiate (laser);

				l.transform.position = transform.position;
				shootTimer = Time.time + .8f;
			}
		}
	}

	void Move(){
		float movementx = -1 * Time.deltaTime * speed;
		float movementy = Time.deltaTime * yspeed + transform.position.y;
		if (transform.position.y < 4 && transform.position.y > -4)
			canSwitch = true;
		if ((transform.position.y > 4 || transform.position.y < -4) && canSwitch) {
			yspeed *= -1;
			canSwitch = false;
		}
		int clamp;
		if (this.gameObject.name == "Enemy1(Clone)")
			clamp = 7;
		else
			clamp = 6;
		movementx = Mathf.Clamp (transform.position.x + movementx, clamp, 14);
		transform.position = new Vector3 (movementx, movementy, 0);
	}
}
