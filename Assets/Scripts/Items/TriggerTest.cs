using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {
	Color color = new Color(1, 0, 0);

	private void OnTriggerStay2D(Collider2D other) {
		if (other.tag != "Player") {
			return;
		}
		Debug.Log("get trigger!");
		if (Input.GetKey(KeyCode.K)) {
			Debug.Log("get key!");
			gameObject.GetComponent<SpriteRenderer>().color = color;
		}
	}
}
