using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public TriggerTest trigger;
    public float MoveSpeed;
    public Vector3 MoveDir;
    public GameObject Text;

    private float stopTime = 0;

    private void Update() {
        if (trigger.Turn_On == true && stopTime <= 120) {
            transform.Translate(MoveDir * MoveSpeed * Time.deltaTime, Space.World);
            stopTime++;
        }
    }

    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag == "Player" && Input.GetKey(KeyCode.K) && !trigger.Turn_On && Text.GetComponent<CanvasGroup>().alpha == 0) {
            Text.GetComponent<Fade>().CanFade = true;
            StartCoroutine(FadeAgain());
        }
    }
    IEnumerator FadeAgain() {
        yield return new WaitForSeconds(2);
        Text.GetComponent<Fade>().CanFade = true;
    }
}
