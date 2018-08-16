using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

/// Level manager class used to handle scene changes.
public class LevelManager : MonoBehaviour {

	
	/// Loads the desired scene.
	/// <param name="name">The name of the scene as string.</param>
	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	}

	
	/// Quits the application (if application can be quitted).
	public void QuitRequest() {
		Application.Quit();
	}

	/// Loads the next level set in the BuildSettings
	public void LoadNextLevel() {
		Application.LoadLevel (Application.loadedLevel + 1);
	}

	/// Notifies a brick has been destroyed and decides to load next level.
	public void BrickDestroyed() {
		// - Detect level win condition
		if (Brik.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}
}
