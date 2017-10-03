using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicex03 : MonoBehaviour {

	public GameObject yellowPlayer;
	public GameObject bluePlayer;
	public GameObject redPlayer;
	public bool redWin;
	public bool blueWin;
	public bool yellowWin;

	bool alreadyWin;
	List<string> allScene;
	int levelNumber;

	public GameObject t1OUT;
	public GameObject t2OUT;

	// Use this for initialization
	void Start () {

		levelNumber = 2;
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

	// Update is called once per frame
	void Update () {
		if (alreadyWin == false) {
			if (redPlayer.GetComponent<playerScript_ex03>().win && bluePlayer.GetComponent<playerScript_ex03>().win && yellowPlayer.GetComponent<playerScript_ex03>().win ) {
				Debug.Log ("YOU WIN NICE");
				alreadyWin = true;
				levelNumber++;
				Application.LoadLevel(allScene[levelNumber % 4]);
			}
		}

	}
}
