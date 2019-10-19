using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	public int health;
	public float speed;
	public Laser laser0;
	public Laser laser1;
	public ParticleSystem particle;
	public Text text;

	private float shootTimer;
	private bool weaponType;
	private Animator anim;

	// Use this for initialization
	void Start () {
		health = 3;
		speed = 5f;
		shootTimer = 0f;
		weaponType = true;
		anim = GetComponent<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		Move ();
		if (Input.GetKey (KeyCode.Space))
			Shoot ();
		if (Input.GetKeyDown(KeyCode.X))
			weaponType = !weaponType;
		if (health < 1)
			Die ();
	}

	void Move(){
		float movementx = Input.GetAxisRaw("Horizontal") * Time.deltaTime * speed;
		float movementy = Input.GetAxisRaw ("Vertical") * Time.deltaTime * speed;
		movementx = Mathf.Clamp (transform.position.x + movementx, -8, -2);
		movementy = Mathf.Clamp (transform.position.y + movementy, -4, 4);
		transform.position = new Vector3 (movementx, movementy, 0);
	}

	void Shoot(){
		if (shootTimer < Time.time) {
			Laser l;
			if (weaponType)
				l = Instantiate (laser0);
			else
				l = Instantiate (laser1);
			

			l.transform.position = transform.position;
			shootTimer = Time.time + .3f;
		}
	}

	void Die(){
		var exp = Instantiate (particle);
		exp.transform.position = transform.position;
		exp.Play ();
		text.text = "YOU LOSE!";
		Destroy (gameObject);
	}

	void AnimatorFunction(){
		anim.SetBool ("Hurting", false);
	}

	void OnTriggerEnter2D(Collider2D col){
		if (col.gameObject.tag == "Enemy") {
			health--;
			if(!anim.GetBool("Hurting"))
				anim.SetBool ("Hurting", true);
		}
	}
}
