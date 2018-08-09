using UnityEngine;
using System.Collections;

public class Brik : MonoBehaviour {

	public AudioClip crack;
	public Sprite[] hitSprites;
	public static int breakableCount = 0;

	private int timesHits;
	private LevelManager levelManager;
	private bool isBreakable;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		// - Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print ("Breakable bricks: " + breakableCount);
		}

		timesHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionExit2D(Collision2D collision) {
		AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHits++;

		int maxHits = hitSprites.Length + 1;
		if (timesHits >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			print ("Breakable bricks: " + breakableCount);
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites() {
		int spriteIndex = timesHits - 1;

		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
