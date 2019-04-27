using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    public SystemController systemController;
    void Update()
    {
        if (Input.anyKeyDown) {
            systemController.LoadScene(1);
        }
    }
}
