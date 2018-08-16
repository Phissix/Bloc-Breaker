using UnityEngine;
using System.Collections;

/// Script handling the breakable and unbreakable bricks behavior
public class Brik : MonoBehaviour {

	/*
	 *	Publicly exposed objects 
	 */

	
	/// The crack AudioClip to be played when the brick is hit.
	public AudioClip crack;

	
	/// Array with the brick breaking animation. This array count
	/// will determine the max hits a brick needs to be broken.
	public Sprite[] hitSprites;

	/// ParticleSystem to be fired when a brick is completely broken.
	public GameObject smoke;

	/// The breakable bricks count. Used to detect win condition.
	/// This variable is shared accross all Bricks
	public static int breakableCount = 0;

	/*
	 * Private members
	 */
	
	/// Number of times this brick has been hit.
	private int timesHits;

	
	/// LevelManager instance used to notify
	/// when a brick has been removed. LevelManager
	/// will handle the next level loading.
	private LevelManager levelManager;

	
	/// Flag informing if the current Brick is breakable or not.
	private bool isBreakable;

	/// Start this instance.
	void Start() {

		// - Get if this brick is breakable or not by its tag
		isBreakable = (this.tag == "Breakable");

		// - Keep track of breakable bricks
		if (isBreakable) {
			breakableCount++;
			print ("Breakable bricks: " + breakableCount);
		}

		// - Initialization
		timesHits = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
	}

	
	/// Raises the collision exit2 d event. Plays the 'crack' sound
	/// and handles hits (if the brick is breakable)
	/// <param name="collision">Collision.</param>

	void OnCollisionExit2D(Collision2D collision) {
		// - Playing sound at point
		AudioSource.PlayClipAtPoint (crack, transform.position);

		// - Handling hits
		if (isBreakable) {
			HandleHits ();
		}
	}

	/// Handles the hits. Fires the particle system and notifies
	/// LevelManager if required. Also, the brick sprite is modified
	/// (depending on the number of hits)
	void HandleHits() {

		// - Increase number of hits
		timesHits++;

		// - Calculate max hits
		int maxHits = hitSprites.Length + 1;

		// - If brick has to be destroyed
		if (timesHits >= maxHits) {

			// - We remove one breakable brick
			breakableCount--;
			print ("Breakable bricks: " + breakableCount);

			// - Notify level manager
			levelManager.BrickDestroyed ();

			// - Fire particle system by cloning the GameObject and modify its color to fit the bricks one
			GameObject puff = (GameObject)Instantiate (smoke, this.transform.position, Quaternion.identity);
			puff.GetComponent<ParticleSystem> ().startColor = GetComponent<SpriteRenderer> ().color;

			// - Finally, destroy the game object
			Destroy (gameObject);
		} else {
			// - If brick is not destroyed, modify its sprite
			LoadSprites ();
		}
	}

	/// Loads the desired sprite depending on the number of hits.
	void LoadSprites() {
		// - Calculate the sprite index by its times hits
		int spriteIndex = timesHits - 1;

		// - If the array contains an sprite in that index, update it
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
