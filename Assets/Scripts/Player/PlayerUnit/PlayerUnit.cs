using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour {
	public SystemController systemController;
	public GameObject DeadEffect;
	
	public bool isDead = false;
	public int recnetCard;

	private void Update() {
		if (isDead == true) {
			if (DeadEffect != null)
				Instantiate(DeadEffect, transform.position, transform.rotation);
			systemController.GetComponent<SystemController>().LoadScene(recnetCard);
			Destroy(gameObject);
		}
	}
}
