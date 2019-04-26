using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyUI : MonoBehaviour {
    public GameObject Player;
    private float energy; 

    private void Update() {
        if (Player == null) return;
        energy = Player.GetComponent<PlayerUnit>().Energy;
        gameObject.GetComponent<RectTransform>().offsetMax = new Vector2(-285 * (100 - energy) / 100, 0);
    }
}