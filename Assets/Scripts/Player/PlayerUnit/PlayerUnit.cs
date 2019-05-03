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


	private bool CanFade;
	private float fadeSpeed;

	private void Update() {
		Death();
		EnergyController();
		PlayerFade();
	}
	private void Death() {
		if (isDead == true) {
			if (DeadEffect != null)
				DeadEffect.SetActive(true);
			PlayerPrefs.SetInt("Reload", 1);
			systemController.GetComponent<SystemController>().LoadScene(recnetCard);
			CanFade = true;
			gameObject.GetComponent<PlayerController>().CanMove = false;
		}
	}
	private void EnergyController() {
		if (isDead) return;
		if (LoseEnergy) {
			Energy -= DecreaseSpeed * Time.deltaTime;
			if (Energy <= 0) {
				isDead = true;
			}
		}
		Color color = new Color(1, 1, 1, (Energy + 40) / 100);
		gameObject.GetComponent<SpriteRenderer>().color = color;
	}
	private void PlayerFade() {
        Color player_color = gameObject.GetComponent<SpriteRenderer>().color;
        if (CanFade) {
			fadeSpeed = -0.05f;
		}
		else {
			fadeSpeed = 0;
		}
		player_color.a += fadeSpeed;
        player_color.a = Mathf.Clamp(player_color.a, 0, 1);
        gameObject.GetComponent<SpriteRenderer>().color = player_color;
    }
}
