using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextTrigger : MonoBehaviour
{
    public GameObject Text;

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Text.SetActive(true);
        }
    }
}
