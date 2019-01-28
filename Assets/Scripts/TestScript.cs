using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	Rigidbody rb;
	float speed;

	void Start () {
		rb = this.gameObject.GetComponent<Rigidbody>();
		speed = Random.Range(4,8);
		rb.velocity = this.transform.forward * speed;
	}

	void Update () {
		
	}
}
