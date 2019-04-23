using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public TriggerTest trigger;
    public float MoveSpeed;
    public Vector3 MoveDir;

    private float stopTime = 0;

    private void Update() {
        if (trigger.Turn_On == true && stopTime <= 120) {
            transform.Translate(MoveDir * MoveSpeed * Time.deltaTime, Space.World);
            stopTime++;
        }
    }
}
