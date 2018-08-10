using UnityEngine;
using System.Collections;

/// <summary>
/// Script  handling the ball behavior.
/// </summary>
public class Ball : MonoBehaviour {

	/// <summary>
	/// Flag informing if the game has been started
	/// </summary>
	private bool hasStarted = false;

	/// <summary>
	/// The paddle script. Used to anchor the ball to the paddle while the
	/// game is not started.
	/// </summary>
	private Paddle paddle;

	/// <summary>
	/// The paddle to ball vector.
	/// </summary>
	private Vector3 paddleToBallVector;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		// - Find the paddle object and calculate the vector
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}

	/// <summary>
	/// Update this instance.
	/// </summary>
	void Update () {

		if (!hasStarted) {
			// - Lock the ball to the paddle if game has not started
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// - Mouse left click to start game
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball.");
				hasStarted = true;

				// - Launch ball by applying a velocity vector to it
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
			}
		}
	}

	/// <summary>
	/// Raises the collision enter2 d event and tweaks the ball velocity
	/// with a randomized vector. This will prevent infinte loops to happen.
	/// </summary>
	/// <param name="col">Col.</param>
	void OnCollisionEnter2D(Collision2D col) {

		// - Random vector
		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			// - Apply tweak velocity
			this.GetComponent<Rigidbody2D>().velocity += tweak;

			/*
			 * Plays the associated sound. Commented because
			 * is very annoying ^^'
			 * 
			 * GetComponent<AudioSource> ().Play ();
			 */ 
		}
	}
}
