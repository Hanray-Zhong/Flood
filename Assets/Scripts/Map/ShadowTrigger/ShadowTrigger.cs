using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTrigger : MonoBehaviour
{
    public GameObject shadow;
    public Camera main_camera;
    private bool change = false;
    public bool CanFade = false;
    private float speed = 0;
    private float fadeSpeed = 0;

    private void Update() {
        ChangeSize();
        ShadowFade();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            change = true;
            CanFade = true;
            main_camera.GetComponent<Fog>().enabled = true;
            main_camera.GetComponent<Follow>().smoothing = new Vector2(2, 2);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            change = true;
            CanFade = true;
            main_camera.GetComponent<Fog>().enabled = false;
            main_camera.GetComponent<Follow>().smoothing = new Vector2(0.5f, 0.5f);
        }
    }

    private void ChangeSize() {
        if (change) {
            if (main_camera.orthographicSize >= 5) {
                speed = -0.1f;
            }
            if (main_camera.orthographicSize <= 2.5f) {
                speed = 0.1f;
            }
        }
        else {
            speed = 0;
        }
        main_camera.orthographicSize += speed;
        if (main_camera.orthographicSize <= 2.5f || main_camera.orthographicSize >= 5) {
            change = false;
        }
    }

    private void ShadowFade() {
        Color shadow_color = shadow.GetComponent<SpriteRenderer>().color;
        if (CanFade) {
			if (shadow_color.a == 0) {
				fadeSpeed = 0.05f;
			}
			else if (shadow_color.a == 1) {
				fadeSpeed = -0.05f;
			}
		}
		else {
			fadeSpeed = 0;
		}
		shadow_color.a += fadeSpeed;
        shadow_color.a = Mathf.Clamp(shadow_color.a, 0, 1);
        shadow.GetComponent<SpriteRenderer>().color = shadow_color;
		if (CanFade && (shadow_color.a <= 0 || shadow_color.a >= 1)) {
			CanFade = false;
		}
    }
}
