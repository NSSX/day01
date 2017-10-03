using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogicEx02 : MonoBehaviour {


	public GameObject wallDisapear;
	public GameObject yellowPlayer;
	public GameObject bluePlayer;
	public GameObject redPlayer;
	public bool redWin;
	public bool blueWin;
	public bool yellowWin;

	bool alreadyWin;
	List<string> allScene;
	int levelNumber;

	// Use this for initialization
	void Start () {

		levelNumber = 1;
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
			if (redPlayer.GetComponent<playerScript_ex01>().win && bluePlayer.GetComponent<playerScript_ex01>().win && yellowPlayer.GetComponent<playerScript_ex01>().win ) {
				Debug.Log ("YOU WIN NICE");
				alreadyWin = true;
				levelNumber++;
				Application.LoadLevel(allScene[levelNumber % 4]);
			}
			if (bluePlayer.GetComponent<playerScript_ex01>().win  == true && wallDisapear.activeSelf == true)
				wallDisapear.SetActive (false);
			else if (bluePlayer.GetComponent<playerScript_ex01>().win  == false && wallDisapear.activeSelf == false)
				wallDisapear.SetActive (true);
		}

	}
}
