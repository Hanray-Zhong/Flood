using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
    public SystemController systemController;
    public int Scene_num;
	
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            Debug.Log("get");
            systemController.GetComponent<SystemController>().LoadScene(Scene_num);
        }
    }
}
