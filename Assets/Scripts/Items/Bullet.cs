using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	public GameObject BoomEffect;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "MAP") {
			if (BoomEffect != null)
				Instantiate(BoomEffect, transform.position, transform.rotation);
			Destroy(gameObject);
			return;
		}
		if (other.tag == "Player") {
			if (BoomEffect != null)
				Instantiate(BoomEffect, transform.position, transform.rotation);
			other.GetComponent<PlayerUnit>().isDead = true;
			Destroy(gameObject);
			return;
		}
	}
	
}
