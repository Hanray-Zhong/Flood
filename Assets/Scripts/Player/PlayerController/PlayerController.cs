using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float hl;
	private float rise;
	private Vector2 		MoveDir;

	[Header("Move")]
	public float Speed;
	public float Rise_speed;
	public float Drag;

	void FixedUpdate () {
		HandleConfiguration ();
		GetMoveDir ();
		StartMove ();
		RiseUp();
	}
	/// <summary>
	/// 手柄配置
	/// </summary>
	void HandleConfiguration () {
		hl = Input.GetAxis("Horizontal");
		rise = Input.GetAxis("Rise");
	}
	void GetMoveDir () {
		MoveDir = new Vector2(0, 0);
		MoveDir = new Vector2(hl, 0).normalized;
	}
	void StartMove () {
		this.gameObject.GetComponent<Rigidbody2D>().drag = Drag;
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(MoveDir * Speed * Time.deltaTime);
	}
	void RiseUp() {
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * rise * Rise_speed * Time.deltaTime);
	}
}
