using UnityEngine;
using System.Collections;

public class Ball : MonoBehaviour {

	private bool hasStarted = false;
	private Paddle paddle;
	private Vector3 paddleToBallVector;

	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = this.transform.position - paddle.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		if (!hasStarted) {
			// - Lock the ball to the paddle if game has not started
			this.transform.position = paddle.transform.position + paddleToBallVector;

			// - Mouse left click to start game
			if (Input.GetMouseButtonDown(0)) {
				print ("Mouse clicked, launch ball.");
				this.GetComponent<Rigidbody2D>().velocity = new Vector2 (2f, 10f);
				hasStarted = true;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D col) {

		Vector2 tweak = new Vector2 (Random.Range(0f, 0.2f), Random.Range(0f, 0.2f));

		if (hasStarted) {
			//GetComponent<AudioSource> ().Play ();
			this.GetComponent<Rigidbody2D>().velocity += tweak;
		}
	}
}
