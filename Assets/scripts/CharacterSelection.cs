using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelection : MonoBehaviour {
	private List<GameObject> characters;
	private int selectionIndex = 0;
	// Use this for initialization
	void Start () {
        selectionIndex = PlayerPrefs.SetInt("CharacterSelected");
        characters = new List<GameObject> ();
		foreach (Transform sprites in transform) {
			characters.Add (sprites.gameObject);
			sprites.gameObject.SetActive (false);
		}
		characters[selectionIndex].SetActive (true);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Select(int index)
	{
		if (index == selectionIndex) {
			return;
		}
		if (index < 0 || index >= characters.Count) {
			return;
		}
		characters [selectionIndex].SetActive (false);
		Debug.Log ("Index " + index);
		selectionIndex = index;
		characters [selectionIndex].SetActive (true);
		//Set the Values to be Passed to the Next Scene here!
	}

    public void PlayGame()
    {
        PlayerPrefs.SetInt("CharacterSelected", selectionIndex);
        SceneManager.LoadScene("Level 1");
    }
}
