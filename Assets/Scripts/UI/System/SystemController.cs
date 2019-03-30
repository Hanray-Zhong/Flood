using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SystemController : MonoBehaviour {	
	public GameObject BlackImage;

	void Update () {
		if (Input.GetKey(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	public void ReloadScene() {
		BlackImage.GetComponent<Fade>().CanFade = true;
		StartCoroutine(Reload());
	}
	IEnumerator Reload() {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
}
