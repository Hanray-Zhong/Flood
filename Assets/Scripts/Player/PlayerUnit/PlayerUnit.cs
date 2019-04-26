using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUnit : MonoBehaviour {
	[Header("Death")]
	public SystemController systemController;
	public GameObject DeadEffect;
	public bool isDead = false;
	public int recnetCard;
	[Header("Energy")]
	public bool LoseEnergy;
	public float DecreaseSpeed;
	[Range(0, 100)]
	public float Energy;

	private void Update() {
		if (isDead == true) {
			if (DeadEffect != null)
				Instantiate(DeadEffect, transform.position, transform.rotation);
			systemController.GetComponent<SystemController>().LoadScene(recnetCard);
			Destroy(gameObject);
		}
		if (LoseEnergy) {
			Energy -= DecreaseSpeed * Time.deltaTime;
			if (Energy <= 0) {
				isDead = true;
			}
		}
		Color color = new Color(1, 1, 1, (Energy + 40) / 100);
		gameObject.GetComponent<SpriteRenderer>().color = color;
	}
}
