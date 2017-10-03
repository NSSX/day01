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
				rigibody.velocity = new Vector2(-5, rigibody.velocity.y);
			} else if (Input.GetKey (KeyCode.D)) {
				rigibody.velocity = new Vector2(5, rigibody.velocity.y);
			} else if (rigibody.velocity.x != 0) {
				Vector2 temp = rigibody.velocity;
				temp.x = 0;
				rigibody.velocity = temp;
			}

			if (Input.GetKeyDown (KeyCode.Space) && grounded) {
				//jump
				rigibody.AddForce (transform.up * 8f, ForceMode2D.Impulse);
				grounded = false;
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
