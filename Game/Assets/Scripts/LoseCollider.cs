using UnityEngine;
using System.Collections;

/// <summary>
/// Collider script to catch the Game Over trigger
/// </summary>
public class LoseCollider : MonoBehaviour {

	/// <summary>
	/// The level manager.
	/// </summary>
	private LevelManager levelManager;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	/// <summary>
	/// Raises the trigger enter2 d event.
	/// </summary>
	/// <param name="trigger">Trigger.</param>
	void OnTriggerEnter2D(Collider2D trigger) {
		// - When the loose collider is triggered, launch "Lose Screen" scene
		levelManager.LoadLevel ("Lose Screen");
	}
}
