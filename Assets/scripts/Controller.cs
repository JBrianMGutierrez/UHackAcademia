using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {


	public float CharacterSpeed;

	public float cellSpeed;

	public float maxPos = 2.1f;

	Vector3 position;

    bool currentPlatformAndroid = false;

    Rigidbody2D rb;

    void Awake() {

        rb = GetComponent<Rigidbody2D> ();

        #if UNITY_ANDROID 
                currentPlatformAndroid = true;
        #else
                currentPlatformAndroid = false;
        #endif
    }

	// Use this for initialization
	void Start () {
		position = transform.position;

        if (currentPlatformAndroid == true)
        {
            Debug.Log("Android");
        }
        else {
            Debug.Log("Windows");
        }

	}
	
	// Update is called once per frame
	void Update () {
		
		position.x += Input.GetAxis ("Horizontal") * CharacterSpeed * Time.deltaTime;


        if (currentPlatformAndroid == true)
        {
            //android specific code
            TouchMove();
        }
        else {
            position.x += Input.GetAxis("Horizontal") * cellSpeed * Time.deltaTime;

            position.x = Mathf.Clamp(position.x, -2.1f, 2.1f);

            transform.position = position;
        }
        position = transform.position;

        position.x = Mathf.Clamp(position.x, -2.1f, 2.1f);

        transform.position = position;

    }

    void TouchMove() {

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            float middle = Screen.width / 2;

            if (touch.position.x < middle && touch.phase == TouchPhase.Began)
            {
                MoveLeft();
            }

            else if (touch.position.x > middle && touch.phase == TouchPhase.Began)
            {
                MoveRight();
            }
        }
        else {
            SetVelocityZero();
        }

    }

    public void MoveLeft() {
        rb.velocity = new Vector2(-cellSpeed, 0);

    }
    public void MoveRight()
    {
        rb.velocity = new Vector2(cellSpeed, 0);

    }
    public void SetVelocityZero()
    {
        rb.velocity = Vector2.zero;
    }



}
