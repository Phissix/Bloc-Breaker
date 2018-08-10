using UnityEngine;
using System.Collections;

/// <summary>
/// Script handling the breakable and unbreakable bricks behavior
/// </summary>
public class Brik : MonoBehaviour {

	/*
	 *	Publicly exposed objects 
	 */

	/// <summary>
	/// The crack AudioClip to be played when the brick is hit.
	/// </summary>
	public AudioClip crack;

	/// <summary>
	/// Array with the brick breaking animation. This array count
	/// will determine the max hits a brick needs to be broken.
	/// </summary>
	public Sprite[] hitSprites;

	/// <summary>
	/// ParticleSystem to be fired when a brick is completely broken.
	/// </summary>
	public GameObject smoke;

	/// <summary>
	/// The breakable bricks count. Used to detect win condition.
	/// This variable is shared accross all Bricks
	/// </summary>
	public static int breakableCount = 0;

	/*
	 * Private members
	 */

	/// <summary>
	/// Number of times this brick has been hit.
	/// </summary>
	private int timesHits;

	/// <summary>
	/// LevelManager instance used to notify
	/// when a brick has been removed. LevelManager
	/// will handle the next level loading.
	/// </summary>
	private LevelManager levelManager;

	/// <summary>
	/// Flag informing if the current Brick is breakable
	/// or not.
	/// </summary>
	private bool isBreakable;

	/// <summary>
	/// Start this instance.
	/// </summary>
	void Start () {

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

	/// <summary>
	/// Raises the collision exit2 d event. Plays the 'crack' sound
	/// and handles hits (if the brick is breakable)
	/// </summary>
	/// <param name="collision">Collision.</param>
	void OnCollisionExit2D(Collision2D collision) {
		// - Playing sound at point
		AudioSource.PlayClipAtPoint (crack, transform.position);

		// - Handling hits
		if (isBreakable) {
			HandleHits ();
		}
	}

	/// <summary>
	/// Handles the hits. Fires the particle system and notifies
	/// LevelManager if required. Also, the brick sprite is modified
	/// (depending on the number of hits)
	/// </summary>
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

	/// <summary>
	/// Loads the desired sprite depending on the number of hits.
	/// </summary>
	void LoadSprites() {
		// - Calculate the sprite index by its times hits
		int spriteIndex = timesHits - 1;

		// - If the array contains an sprite in that index, update it
		if (hitSprites [spriteIndex]) {
			this.GetComponent<SpriteRenderer> ().sprite = hitSprites [spriteIndex];
		}
	}
}
