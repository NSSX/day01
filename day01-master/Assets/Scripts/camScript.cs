using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camScript : MonoBehaviour {

	List<GameObject> allGO;
	public GameObject claire;
	public GameObject john;
	public GameObject thomas;
	GameObject currentGO;
	Vector3 temp;

	// Use this for initialization
	void Start () {
		allGO = new List<GameObject> ();
		allGO.Add (thomas);
		allGO.Add (john);
		allGO.Add (claire);
		SwapGo (1);
		temp = currentGO.transform.position;
	}


	void SwapGo(int number){
		for (int i = 0; i < allGO.Count; i++) {
			allGO [i].GetComponent<playerScript_ex00> ().activ = false;
			allGO [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
		}

		for(int i = 0; i < 3; i++){
			if (i == number) {
				allGO [i].GetComponent<playerScript_ex00> ().activ = true;
				allGO [i].GetComponent<Rigidbody2D> ().constraints = RigidbodyConstraints2D.FreezeRotation;
				currentGO = allGO [i];
				temp = currentGO.transform.position;
				temp.z = transform.position.z;
				transform.position = temp;
				transform.parent = currentGO.transform;
			}
				
		}
	}


	bool allInactiv(){

		for (int i = 0; i < allGO.Count; i++) {
			if (allGO [i].GetComponent<playerScript_ex00> ().activ == true) {
				return false;
			}
		}
		return true;
	}
	
	// Update is called once per frame
	void Update () {
		if (allInactiv () == true) {
			SwapGo (0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			SwapGo (0);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			SwapGo (1);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			SwapGo (2);
		}

		if (Input.GetKeyDown (KeyCode.R)) {
			Application.LoadLevel (Application.loadedLevel);
		}

	}
}
