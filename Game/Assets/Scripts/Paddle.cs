using UnityEngine;
using System.Collections;

/// <summary>
/// Paddle movement script. Use the mouse to move.
/// </summary>
public class Paddle : MonoBehaviour {

	public bool autoPlay = false;

	private Ball ball;

	void Start() {
		ball = FindObjectOfType<Ball> ();
	}

	// Update is called once per frame
	void Update () {

		if (autoPlay) {
			AutoPlay ();
		} else {
			MoveWithMouse ();
		}
	}

	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}

	void MoveWithMouse() {
		// - Gather the new position (with mouse input)
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		// - Update paddle position with Mathf.Clamp to avoid moving outside the game scene
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}
}
