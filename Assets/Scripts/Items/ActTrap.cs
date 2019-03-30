using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActTrap : MonoBehaviour {
	public GameObject BulletPrefab;
	public GameObject ShootPos;

	public float ShootSpeed;
	public float interval;
	private float i;

	private void Update() {
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
