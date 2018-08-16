using UnityEngine;
using System.Collections;

/// Singleton Music Player persisted among scenes
public class MusicPlayer : MonoBehaviour {

	/// The instance (singleton)
	static MusicPlayer instance = null;

	/// Awake this instance.
	void Awake() {

		// - If we already created a MusicPlayer, destroy the current one
		if (instance != null) {
			Destroy (gameObject);
		} else {
			// - The first time this script is created, save its instance
			instance = this;

			// - Avoid this object to be destroyed along the scenes
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
