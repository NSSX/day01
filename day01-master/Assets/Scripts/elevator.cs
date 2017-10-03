using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevator : MonoBehaviour {

	float counter;
	float interval;
	bool directionTop;

	// Use this for initialization
	void Start () {
		counter = 0;
		interval = 3.4f;
		directionTop = true;
	}
	
	// Update is called once per frame
	void Update () {
		counter += Time.deltaTime;
		if (counter >= interval) {
			counter = 0;
			directionTop = !directionTop;
		}

		if (directionTop) {
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, 2);
		} 
		//	transform.Translate (new Vector3(0,5,0) * Time.deltaTime);
		if (!directionTop)
			GetComponent<Rigidbody2D>().velocity = new Vector2(GetComponent<Rigidbody2D>().velocity.x, -2);
			//	transform.Translate (new Vector3(0,-5,0) * Time.deltaTime);
	}
}
