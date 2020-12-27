using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tree : MonoBehaviour {
	public Text text;
	public float hits;
	public float maxhits;
	public float respawntime;
	public GameObject target;
	public Vector3 spawn;
	public GameObject targetcopy;
	// Use this for initialization
	void Start () {
		target = gameObject;
		spawn = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (hits >= maxhits)
        {
			target.SetActive(false);
			text.GetComponent<textui>().woodAmount++;
			Invoke("respawn", respawntime);
			hits = 0f;
		}
	}
	void OnCollisionEnter(Collision col)
    {
		if (col.collider.tag == "Player")
        {
			hits++;
        }
    }
	void respawn()
    {
		targetcopy = (GameObject)Instantiate(target);
		targetcopy.transform.position = spawn;
		hits = 0f;
		targetcopy.SetActive(true);
		Destroy(target, 0f);
	}
}
