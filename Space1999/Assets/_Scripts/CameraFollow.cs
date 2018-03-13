using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GameObject target;
	private float speed = 2.0f;
	// Use this for initialization
	void Start () {
		target = GameObject.FindGameObjectWithTag ("leader");
	}
	
	// Update is called once per frame
	void Update () {
		transform.rotation = Quaternion.Lerp (transform.rotation,target.transform.rotation, speed * Time.deltaTime);
	}
}
