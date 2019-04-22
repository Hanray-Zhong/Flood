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
	public void LoadScene(int i) {
		BlackImage.GetComponent<Fade>().CanFade = true;
		StartCoroutine(Load(i));
	}
	public void ReloadScene() {
		BlackImage.GetComponent<Fade>().CanFade = true;
		StartCoroutine(Reload());
	}
	IEnumerator Reload() {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(0);
	}
	IEnumerator Load(int i) {
		yield return new WaitForSeconds(2);
		SceneManager.LoadScene(i);
	}
}
