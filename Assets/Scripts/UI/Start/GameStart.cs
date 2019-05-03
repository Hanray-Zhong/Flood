using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public SystemController systemController;
    void Update()
    {
        if (Input.anyKeyDown) {
            PlayerPrefs.SetInt("Reload", 0);
            PlayerPrefs.SetInt("Revive Point", -1);
            systemController.LoadScene(6);
        }
    }
}
