using UnityEngine;
using System.Collections;

/// Collider script to catch the Game Over trigger
public class LoseCollider : MonoBehaviour {

	/// The level manager.
	private LevelManager levelManager;

	/// Start this instance.
	void Start() {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	
	/// Raises the trigger enter2 d event.
	/// <param name="trigger">Trigger.</param>
	void OnTriggerEnter2D(Collider2D trigger) {
		// - When the loose collider is triggered, launch "Lose Screen" scene
		levelManager.LoadLevel ("Lose Screen");
	}
}
