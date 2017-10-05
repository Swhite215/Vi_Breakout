using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	float mousePosInBlocks;
	public bool autoPlay = false;
	private Ball ball;

	void Start() {
		ball = GameObject.FindObjectOfType<Ball>();
	}

	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();	
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16 - 8);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3 (0.5f, this.transform.position.y, 0f);
		Vector3 ballPos = ball.transform.position;
		paddlePos.x = Mathf.Clamp (ballPos.x, -7.5f, 7.5f);
		this.transform.position = paddlePos;
	}
}
