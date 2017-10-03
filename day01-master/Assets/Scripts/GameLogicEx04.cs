using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicEx04 : MonoBehaviour {
	
	public GameObject yellowPlayer;
	public GameObject bluePlayer;
	public GameObject redPlayer;
	public bool redWin;
	public bool blueWin;
	public bool yellowWin;

	bool alreadyWin;
	List<string> allScene;
	int levelNumber;

	public GameObject t3OUT;
	public GameObject i1;
	public GameObject i2;

	public GameObject i1Wall;
	public GameObject i2Wall;

	public GameObject wallDisapear;

	// Use this for initialization
	void Start () {

		levelNumber = 3;
		allScene = new List<string> ();
		allScene.Add ("ex01");
		allScene.Add ("ex02");
		allScene.Add ("ex03");
		allScene.Add ("ex04");
		redWin = false;
		blueWin = false;
		yellowWin = false;
		alreadyWin = false;
	}

	public void i1Pressed(){
		i1Wall.GetComponent<SpriteRenderer> ().color = Color.red;
		i1Wall.layer = 9;
	}

	public void i1UnPressed(){
		i1Wall.GetComponent<SpriteRenderer> ().color = Color.yellow;
		i1Wall.layer = 10;
	}


	public void i2Pressed(int playerNumber){

		if (playerNumber == 0) {
			i2Wall.GetComponent<SpriteRenderer> ().color = Color.red;
			i2Wall.layer = 9;
			i2.GetComponent<SpriteRenderer> ().color = Color.red;
			i2.layer = 9;
		} else if (playerNumber == 1) {
			i2Wall.GetComponent<SpriteRenderer> ().color = Color.yellow;
			i2Wall.layer = 10;
			i2.GetComponent<SpriteRenderer> ().color = Color.yellow;
			i2.layer = 10;
		} else if (playerNumber == 2) {
			i2Wall.GetComponent<SpriteRenderer> ().color = Color.blue;
			i2Wall.layer = 8;
			i2.GetComponent<SpriteRenderer> ().color = Color.blue;
			i2.layer = 8;
		}
	}

	public void i2UnPressed(){
		i2Wall.GetComponent<SpriteRenderer> ().color = Color.white;
		i2Wall.layer = 0;
		i2.GetComponent<SpriteRenderer> ().color = Color.white;
		i2.layer = 0;
	}

	// Update is called once per frame
	void Update () {
		if (alreadyWin == false) {
			if (redPlayer.GetComponent<playerScript_ex04>().win && bluePlayer.GetComponent<playerScript_ex04>().win && yellowPlayer.GetComponent<playerScript_ex04>().win ) {
				Debug.Log ("YOU WIN NICE");
				alreadyWin = true;
				levelNumber++;
				Application.LoadLevel(allScene[levelNumber % 4]);
			}
			if (bluePlayer.GetComponent<playerScript_ex04>().win  == true && wallDisapear.activeSelf == true)
				wallDisapear.SetActive (false);
			else if (bluePlayer.GetComponent<playerScript_ex04>().win  == false && wallDisapear.activeSelf == false)
				wallDisapear.SetActive (true);
		}

	}
}
