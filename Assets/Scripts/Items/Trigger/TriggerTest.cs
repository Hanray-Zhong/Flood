using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerTest : MonoBehaviour {
	
	public GameObject handle_off;
	public GameObject handle_on;
	public bool Turn_On = false;

	private void OnTriggerStay2D(Collider2D other) {
		if (other.tag != "Player") {
			return;
		}
		if (Input.GetKey(KeyCode.K)) {
			handle_off.SetActive(false);
			handle_on.SetActive(true);
			Turn_On = true;
		}
	}
}
