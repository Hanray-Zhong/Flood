using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowTrigger : MonoBehaviour
{
    public FlowController flowController;
    public bool StartOrStop;
    public Vector2 FLowDir;
    private void OnTriggerStay2D(Collider2D other) {
        if (other.tag != "Player")
            return;
        flowController.FlowDir = FLowDir;
        flowController.HaveFlow = true;
    }
    private void OnTriggerExit2D(Collider2D other) {
        if (other.tag != "Player")
            return;
        flowController.HaveFlow = false;
    }
}
