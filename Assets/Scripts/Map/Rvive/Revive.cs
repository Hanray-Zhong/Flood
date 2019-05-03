using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Revive : MonoBehaviour
{
    public GameObject Player;
    public GameObject MainCamera;
    public GameObject[] Energy;

    private void Start() {
        int index = PlayerPrefs.GetInt("Revive Point");
        if (index != -1) {
            Player.transform.SetPositionAndRotation(new Vector3(Energy[index].transform.position.x, Energy[index].transform.position.y, 1), Player.transform.rotation);
            MainCamera.transform.SetPositionAndRotation(new Vector3(Energy[index].transform.position.x, Energy[index].transform.position.y, 0), MainCamera.transform.rotation);
        }
        Destroy(Energy[index]);
    }
}
