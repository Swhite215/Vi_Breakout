using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	private bool active = false;

	private Paddle paddle;
	private Vector3 paddleToBallVector;
	private Rigidbody2D rb;
	private AudioSource source;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;

		//Access used components of our gameObject.
		rb = GetComponent<Rigidbody2D> ();
		source = GetComponent<AudioSource> ();
	}

	// Update is called once per frame
	void Update () {
		//Ball is waiting for mousepress.
		if (!active) {
			this.transform.position = paddle.transform.position + paddleToBallVector;

			//On mouse press the ball then flys away.
			if (Input.GetMouseButtonDown(0)) {
				source.Play();
				active = true;
				rb.velocity = new Vector2 (2f, 10f);
			}

		}
	}

	void OnCollisionEnter2D(Collision2D collision) {

		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (active) {
			source.Play ();
			rb.velocity += tweak;
		}
	}
}
