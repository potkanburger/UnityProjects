using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

	private Rigidbody rb;
	public float speed;
	private int score;
	public Text scoreText;
	public Text winText;
	private GameObject[] gos;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
		score = 0;
		SetCountText ();
		winText.text = "";
		gos = GameObject.FindGameObjectsWithTag("EndButton");
		foreach (GameObject go in gos) {
			go.SetActive (false);
		}
	}

	void SetCountText(){
		scoreText.text = "Score: " + score.ToString ();
	}

	void FixedUpdate(){

		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");
		/*if (Input.accelerationEventCount > 0) {
			moveHorizontal = Input.acceleration.x;
			moveVertical = Input.acceleration.y;
		}*/

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);

		rb.AddForce (movement * speed);
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Pick Up")) {
			other.gameObject.SetActive (false);
			score++;
			SetCountText ();
			if (score >= 16) {
				winText.text = "You win !";
				foreach (GameObject go in gos) {
					go.SetActive (true);
				}
			}
		}
	}
}
