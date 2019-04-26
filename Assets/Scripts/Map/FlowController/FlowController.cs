using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlowController : MonoBehaviour
{
    public GameObject Player;
    public bool HaveFlow;
    [Header("Flow")]
    public Vector2 FlowDir;
    public float FlowStrenth;
    public WaterFlow waterFlow;
    public float ChangeSpeed_DS;

    private void Update() {
        if (HaveFlow) {
            waterFlow.DistortStrength = Mathf.Lerp(waterFlow.DistortStrength, 0.01f, Time.deltaTime * ChangeSpeed_DS);
            Player.GetComponent<Rigidbody2D>().AddForce(FlowDir * FlowStrenth * Time.deltaTime, ForceMode2D.Force);
        }
        else {
            waterFlow.DistortStrength = Mathf.Lerp(waterFlow.DistortStrength, 0, Time.deltaTime * ChangeSpeed_DS);            
        }
        // if (HaveFlow) {
        //     waterFlow.DistortStrength = 0.01f;
        //     waterFlow.DistortTimeFactor = 0.08f;
        //     Player.GetComponent<Rigidbody2D>().AddForce(FlowDir * FlowStrenth * Time.deltaTime, ForceMode2D.Force);
        // }
        // else {
        //     waterFlow.DistortStrength = 0;
        //     waterFlow.DistortTimeFactor = 0;
        // }
    }

}
