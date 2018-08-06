using UnityEngine;
using System.Collections;

/// <summary>
/// Collider script to catch the Game Over trigger
/// </summary>
public class LoseCollider : MonoBehaviour {

	private LevelManager levelManager;

	void Start () {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	void OnTriggerEnter2D(Collider2D trigger) {
		levelManager.LoadLevel ("Lose Screen");
	}
}
