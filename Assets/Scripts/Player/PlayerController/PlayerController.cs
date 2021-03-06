﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private float hl;
	private float rise;
	private Vector2 MoveDir;

	[Header("Move")]
	public float Speed;
	public float Rise_speed;
	public float Drag;
	public float RayDistance;
	public CapsuleCollider2D main_collider;
	public CapsuleCollider2D collider_1;
	public CapsuleCollider2D collider_2;
	[Header("Animation")]
	public Animator animator;
	[Header("Can Move")]
	public bool CanMove;


	void FixedUpdate () {
		HandleConfiguration ();
		GetMoveDir ();
		StartMove ();
		RiseUp();
		IsOntheGround();
	}
	/// <summary>
	/// 手柄配置
	/// </summary>
	void HandleConfiguration () {
		hl = Input.GetAxis("Horizontal");
		rise = Input.GetAxis("Rise");
	}
	void GetMoveDir () {
		if (!CanMove) return;
		MoveDir = new Vector2(0, 0);
		MoveDir = new Vector2(hl, 0).normalized;
		if (hl == 0) {
			main_collider.offset = collider_1.offset;
			main_collider.size = collider_1.size;
		}
		else {
			main_collider.offset = collider_2.offset;
			main_collider.size = collider_2.size;
		}
		if (hl > 0) {
			gameObject.GetComponent<SpriteRenderer>().flipX = true;
		}
		else if (hl < 0) {
			gameObject.GetComponent<SpriteRenderer>().flipX = false;
		}
		if (hl != 0) {
			animator.SetBool("Move", true);
			return;
		}
		else {
			animator.SetBool("Move", false);
		}
		if (rise == 0) {
			animator.SetBool("Rise", false);
			return;
		}
		else {
			animator.SetBool("Rise", true);
		}
	}
	void StartMove () {
		this.gameObject.GetComponent<Rigidbody2D>().drag = Drag;
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(MoveDir * Speed * Time.deltaTime);
	}
	void RiseUp() {
		if (!CanMove) return; 
		this.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * rise * Rise_speed * Time.deltaTime);
	}
	void IsOntheGround() {
		RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, new Vector2(0, -1), RayDistance);
		foreach (var item in hits) {
			if (item.collider.gameObject.tag == "MAP") {
				animator.SetBool("OnTheGround", true);
				return;
			}
		}
		animator.SetBool("OnTheGround", false);
	}
}

public class consumeManager : MonoBehaviour {
	public void damage() {

	}
}
public class effectBase
{
    public consumeManager ConsumeManager;    
    public virtual void func(int type)
    {
            
    } 
}
public class unNameFire : effectBase
{
    public override void func(int type)
    {
        ConsumeManager.damage();
    }
}