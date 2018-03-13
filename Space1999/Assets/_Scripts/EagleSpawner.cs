using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EagleSpawner : MonoBehaviour {

	public float gap = 20;
	public float followers = 2;
	public GameObject prefab;

	private float theta;

	void Awake(){

		float thetaInc = (Mathf.PI * 2) / followers;

		for (int i = 0; i < followers; i++) {
			
			theta = thetaInc * i;
			Vector3 pos = new Vector3 (Mathf.Sin(theta)*gap ,0, Mathf.Cos(theta)*gap);
			GameObject eagle = GameObject.Instantiate<GameObject> (prefab);
			eagle.transform.position = pos;
			eagle.transform.rotation = transform.rotation;
			eagle.transform.parent = transform;
		}
	}
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
