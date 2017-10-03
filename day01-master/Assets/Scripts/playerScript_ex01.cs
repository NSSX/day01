using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex01 : MonoBehaviour {

	public int playerNumber;
	public bool activ;
	bool grounded;
	Rigidbody2D rigibody;
	public float speedHorizontal;
	public float speedJump;
	public bool win;


	// Use this for initialization
	void Start () {
		win = false;
		playerNumber = 0;
		grounded = false;
		activ = false;	
		rigibody = GetComponent<Rigidbody2D> ();
		speedHorizontal = 5f;
		speedJump = 8f;
	}

	// Update is called once per frame
	void Update () {

		if (activ == true) {

			if (Input.GetKey (KeyCode.A)) {
				rigibody.velocity = new Vector2(-speedHorizontal, rigibody.velocity.y);
			} else if (Input.GetKey (KeyCode.D)) {
				rigibody.velocity = new Vector2(speedHorizontal, rigibody.velocity.y);
			} else if (rigibody.velocity.x != 0) {
				Vector2 temp = rigibody.velocity;
				temp.x = 0;
				rigibody.velocity = temp;
			}

			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				//jump
				rigibody.AddForce (transform.up * speedJump, ForceMode2D.Impulse);
				grounded = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (playerNumber == 0) {
			if (other.tag == "redExit")
				win = true;
		} else if (playerNumber == 1) {
			if (other.tag == "yellowExit")
				win = true;
		} else if (playerNumber == 2) {
			if (other.tag == "blueExit")
				win = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (playerNumber == 0) {
			if (other.tag == "redExit")
				win = false;
		} else if (playerNumber == 1) {
			if (other.tag == "yellowExit")
				win = false;
		} else if (playerNumber == 2) {
			if (other.tag == "blueExit")
				win = false;
		}
	}


	void OnCollisionEnter2D(Collision2D coll) {

		if(coll.contacts.Length > 0)
		{
			ContactPoint2D contact = coll.contacts[0];

			if(Vector3.Dot(contact.normal, Vector3.up) > 0.5)
			{
				//collision bas
				grounded = true;
			}
		}

	}

}
