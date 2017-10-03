using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerScript_ex00 : MonoBehaviour {


	public bool activ;
	bool grounded;
	Rigidbody2D rigibody;

	// Use this for initialization
	void Start () {
		grounded = false;
		activ = false;	
		rigibody = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		if (activ == true) {

			if (Input.GetKey (KeyCode.A)) {
				//left
				if (rigibody.velocity.x > 0) {
					Vector2 temp = rigibody.velocity;
					temp.x = 0;
					rigibody.velocity = temp;
				}
				//rigibody.AddForce(new Vector2(rigibody.velocity.x,0));
				rigibody.AddForce (new Vector2 (-10, 0));
			} else if (Input.GetKey (KeyCode.D)) {
				//right
				if (rigibody.velocity.x < 0) {
					Vector2 temp = rigibody.velocity;
					temp.x = 0;
					rigibody.velocity = temp;
				}
				//	rigibody.AddForce(new Vector2(-rigibody.velocity.x,0));
				rigibody.AddForce (new Vector2 (10, 0));
			} else if (rigibody.velocity.x != 0) {
				Vector2 temp = rigibody.velocity;
				temp.x = 0;
				rigibody.velocity = temp;
			}

			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				//jump
				rigibody.AddForce (transform.up * 5f, ForceMode2D.Impulse);
				grounded = false;
			}
		} else {
			if (grounded == true) {
				rigibody.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezePositionY | RigidbodyConstraints2D.FreezeRotation;
			} else {
				rigibody.constraints =  RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
			}
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
