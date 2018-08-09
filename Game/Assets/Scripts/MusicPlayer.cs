using UnityEngine;
using System.Collections;

/// <summary>
/// Singleton Music Player persisted among scenes
/// </summary>
public class MusicPlayer : MonoBehaviour {

	/// <summary>
	/// The instance
	/// </summary>
	static MusicPlayer instance = null;

	void Awake() {
		if (instance != null) {
			Destroy (gameObject);
		} else {
			instance = this;
			GameObject.DontDestroyOnLoad (gameObject);
		}
	}
}
