using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{
    private Vector3 deltaPos = Vector3.zero;

    void Update () {
        transform.localPosition -= deltaPos;
        deltaPos = Random.insideUnitSphere / 3.0f;
        transform.localPosition += deltaPos;
    }
}
