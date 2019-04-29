using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public Key[] keys;
    public float MoveSpeed;
    public Vector3 MoveDir;
    public GameObject Text;

    private bool turn_on = false;
    private float stopTime = 0;

    private void Update() {
        if (turn_on == true && stopTime <= 120) {
            transform.Translate(MoveDir * MoveSpeed * Time.deltaTime, Space.World);
            stopTime++;
        }
    }
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag != "Player") {
			return;
		}
		if (Input.GetKey(KeyCode.K)) {
            foreach (var item in keys) {
                if (!item.Picked) {
                    if (Text != null) {
                        Text.GetComponent<Fade>().CanFade = true;
                        StartCoroutine(FadeAgain());
                    }
                    return;
                }
            }
			turn_on = true;
		}
    }
    IEnumerator FadeAgain() {
        yield return new WaitForSeconds(2);
        Text.GetComponent<Fade>().CanFade = true;
    }
}
