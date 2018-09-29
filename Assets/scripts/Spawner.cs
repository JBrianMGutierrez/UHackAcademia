using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {


	//public GameObject[] germ;

	public List<GameObject> germy = new List<GameObject>();

	int germNo;

	public float maxPos = 2.1f;
	public float delayTimer = 1f;

	float timer;

	// Use this for initialization
	void Start () {
		#if UNITY_ANDROID
		delayTimer = 0.8f;
		#endif
		timer = delayTimer;

	}
	
	// Update is called once per frame
	void Update () {

		timer -= Time.deltaTime;
		if (timer <= 0) {

			Vector3 carPos = new Vector3 (Random.Range (-2.1f, 2.1f), transform.position.y, transform.position.z);
			germNo = Random.Range (0, germy.Count);
			Instantiate (germy[germNo], carPos, transform.rotation);
			timer = delayTimer;
		}
			
	}
}
