using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActTrap : MonoBehaviour {
	public GameObject BulletPrefab;
	public GameObject ShootPos;

	public float ShootSpeed;
	public float interval;
	public float StartOffset;
	private float i = 0;
	private float j = 0;

	private void Update() {
		j++;
		if (j >= StartOffset)
			i++;
		if (i >= interval) {
			Shoot();
			i = 0;
		}
	}

	void Shoot() {
		GameObject newBullet = Instantiate(BulletPrefab, ShootPos.transform.position, BulletPrefab.transform.rotation);
		newBullet.GetComponent<Rigidbody2D>().AddForce(ShootSpeed * (new Vector2(ShootPos.transform.up.x, ShootPos.transform.up.y).normalized), ForceMode2D.Impulse);
	}
	
}
