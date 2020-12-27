using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_script : MonoBehaviour {
	public float speed;
	public float StopDistance;
	public Transform player;



	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, player.position) <= StopDistance)
        {
			transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
		
	}
}
