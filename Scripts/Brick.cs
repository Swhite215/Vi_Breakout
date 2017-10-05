using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	public static int breakableCount = 0;
	public Sprite[] hitSprites;
	public AudioClip clip;

	private int timesHit;
	private bool isBreakable;
	private GameObject[] getCount;
	private LevelManager levelManager;
	private SpriteRenderer spriteRenderer;

	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Block");
		//Keep Track of Breakable Bricks
		if (isBreakable) {
			breakableCount++;
		}

		timesHit = 0;
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		spriteRenderer = GetComponent<SpriteRenderer> ();

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D(Collision2D collision) {

		AudioSource.PlayClipAtPoint (clip, transform.position);

		if (isBreakable) {
			HandleHits ();
		}
	}

	void HandleHits() {
		timesHit++;
		int maxHits = hitSprites.Length + 1;
		if (timesHit >= maxHits) {
			breakableCount--;
			levelManager.BrickDestroyed ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void LoadSprites() {
		if (hitSprites[timesHit - 1]) {
			spriteRenderer.sprite = hitSprites[timesHit - 1];
		}
	}

	//TODO Remove this method once we can actually win
	void SimulateWin() {
		levelManager.LoadNextLevel ();
	}
}
