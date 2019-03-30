﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticTrap : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
			other.GetComponent<PlayerUnit>().isDead = true;
			Debug.Log("Player");
			return;
		}
	}
}
