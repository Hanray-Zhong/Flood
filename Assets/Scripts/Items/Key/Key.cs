using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : MonoBehaviour
{
	public bool Picked = false;
    public GameObject effect;

	private void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "Player") {
            Destroy(effect);
            gameObject.SetActive(false);
			Picked = true; 
		}
	}
}
