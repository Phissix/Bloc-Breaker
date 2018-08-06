using UnityEngine;
using System.Collections;

public class Brik : MonoBehaviour {

	public int maxHits;

	private int timesHits;

	private LevelManager levelManager;

	// Use this for initialization
	void Start () {
		timesHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision) {
		timesHits++;

		SimulateWin ();
	}

	// TODO: Remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel ();
	}
}
