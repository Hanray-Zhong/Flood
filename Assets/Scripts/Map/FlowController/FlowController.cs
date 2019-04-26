using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    public GameObject Player;
    public bool HaveFlow;
    [Header("Flow")]
    public Vector3 FlowDir;
    public float FlowStrenth;
    public WaterFlow waterFlow;

    private void Update() {
        if (HaveFlow) {
            waterFlow.DistortStrength = 0.01f;
            waterFlow.DistortTimeFactor = 0.08f;
            Player.GetComponent<Rigidbody2D>().AddForce(FlowDir * FlowStrenth * Time.deltaTime, ForceMode2D.Force);
        }
    }

}
