using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rabbit_ai : MonoBehaviour {
	public float speed;
	public float hits;
	public float maxhits;
	public float respawntime;
	public GameObject target;
	public Vector3 spawn;
	public GameObject targetcopy;
	Vector3 targetmove;

	// wander variables
	public float rotspeed;
	private bool wandering = false;
	private bool rotateleft = false;
	private bool rotateright = false;
	private bool walking = false;

	// Use this for initialization
	void Start()
	{
		targetmove = transform.position;
		target = gameObject;
		spawn = transform.position;
	}

	// Update is called once per frame
	void Update()
	{
		
		if (hits >= maxhits)
		{
			
			target.SetActive(false);
			Invoke("respawn", respawntime);
			hits = 0f;
		}
		if (wandering == false)
        {
			StartCoroutine(move());
        }
		if (rotateright == true)
        {
			transform.Rotate(transform.up * Time.deltaTime * rotspeed);
        }
		if (rotateleft == true)
		{
			transform.Rotate(transform.up * Time.deltaTime * -rotspeed);
		}
		if (walking == true)
        {
			transform.position += transform.forward * speed * Time.deltaTime;
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
	IEnumerator move()
    {
		int rottime = Random.Range(1, 3);
		int rotwait = Random.Range(1, 4);
		int rotLorR = Random.Range(1, 2);
		int walkwait = Random.Range(1, 4);
		int walktime = Random.Range(1, 5);

		wandering = true;

		yield return new WaitForSeconds(walkwait);

		walking = true;

		yield return new WaitForSeconds(walktime);

		walking = false;

		yield return new WaitForSeconds(rotwait);

		if (rotLorR == 1)
        {
			rotateright = true;
			yield return new WaitForSeconds(rottime);
			rotateright = false;
		}

		if (rotLorR == 2)
		{
			rotateleft = true;
			yield return new WaitForSeconds(rottime);
			rotateleft = false;
		}
		wandering = false;
	}

}
