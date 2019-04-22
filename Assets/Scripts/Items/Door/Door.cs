using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public TriggerTest trigger;
    public float MoveSpeed;

    private float stopTime = 0;

    private void Update() {
        if (trigger.Turn_On == true && stopTime <= 120) {
            transform.Translate(new Vector3(0, -1, 0) * MoveSpeed * Time.deltaTime, Space.World);
            stopTime++;
        }
    }
}
