using UnityEngine;
using System.Collections;

/// <summary>
/// Paddle movement script. Use the mouse to move.
/// </summary>
public class Paddle : MonoBehaviour {

	/*
	 *	Publicly exposed members
	 */

	/// <summary>
	/// The auto play boolean. The pad will follow the ball.
	/// This allows us to test edge cases of our game.
	/// </summary>
	public bool autoPlay = false;

	/*
	 * Private members
	 */

	/// <summary>
	/// The ball object. Required for autoplay mode.
	/// </summary>
	private Ball ball;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start() {
		// - Find the ball object
		ball = FindObjectOfType<Ball> ();
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		if (autoPlay) {
			AutoPlay ();
		} else {
			MoveWithMouse ();
		}
	}

	/// <summary>
	/// Make the Paddle follow the Ball movement
	/// </summary>
	void AutoPlay() {
		Vector3 paddlePos = new Vector3(ball.transform.position.x, this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}

	/// <summary>
	/// Make the Paddle follow the mouse movements
	/// </summary>
	void MoveWithMouse() {
		// - Gather the new position (with mouse input)
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;

		// - Update paddle position with Mathf.Clamp to avoid moving outside the game scene
		Vector3 paddlePos = new Vector3(Mathf.Clamp(mousePosInBlocks, 0.5f, 15.5f), this.transform.position.y, this.transform.position.z);
		this.transform.position = paddlePos;
	}
}
