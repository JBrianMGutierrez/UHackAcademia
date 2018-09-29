using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Controller : MonoBehaviour {
	
	public int currentScore = 0;
	public Button[] characterButtons;
	// Use this for initialization
	void Start () {
		currentScore = PlayerPrefs.GetInt ("ScorePoints");
		if (currentScore >= 50) {
			characterButtons[1].gameObject.SetActive(true);
			//unlock button
		}
		if (currentScore >= 100) {
			characterButtons[2].gameObject.SetActive(true);
			//unlock second button
		}
		if (currentScore >= 150) {
			//unlock third button
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
