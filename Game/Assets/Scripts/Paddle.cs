using UnityEngine;
using System.Collections;

/// Paddle movement script. Use the mouse to move.
public class Paddle : MonoBehaviour {

	/*
	 *	Publicly exposed members
	 */

	/// The auto play boolean. The pad will follow the ball.
	/// This allows us to test edge cases of our game.
	public bool autoPlay = false;

	/*
	 * Private members
	 */

	
	/// The ball object. Required for autoplay mode.
	private Ball ball;

	/// Start this instance.
	void Start() {
		// - Find the ball object
		ball = FindObjectOfType<Ball> ();
	}

	/// Update this instance.
	void Update() {

		if (autoPlay) {
			AutoPlay ();
		} else {
			MoveWithMouse ();
		}
	}

	/// Make the Paddle follow the Ball movement
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}

	/// Make the Paddle follow the mouse movements
	void MoveWithMouse() {
		// - Gather the new position (with mouse input)
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		// - Update paddle position with Mathf.Clamp to avoid moving outside the game scene
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}
}
