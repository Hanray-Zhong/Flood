using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowTrigger : MonoBehaviour
{
    public GameObject shadow;
    public Camera main_camera;
    private bool change = false;
    private float speed = 0;

    private void Update() {
        ChangeSize();
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            change = true;
            main_camera.GetComponent<Fog>().enabled = true;
            main_camera.GetComponent<Follow>().smoothing = new Vector2(2, 2);
        }
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            change = true;
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
            Debug.Log("get!");
            change = false;
        }
    }

}
