using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyDoor : MonoBehaviour
{
    public Key key;
    public float MoveSpeed;
    public Vector3 MoveDir;

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
		if (Input.GetKey(KeyCode.K) && key.Picked) {
			turn_on = true;
		}
    }
}
