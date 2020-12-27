using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class movement : MonoBehaviour {
	public bool grounded = false;
	public float speed;
	private Rigidbody rigidbody;
	public float Yjump;
	public float yspeed;
	public GameObject Block1;
	public GameObject blockcopy;
	public FixedJoystick move;
	public float tst;
	Vector3 rot;
	Collision col;

	[SerializeField]
	KeyCode KeyJump;

	

	private int thisscene;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
		// respawning

		thisscene = SceneManager.GetActiveScene().buildIndex;
		rigidbody = GetComponent<Rigidbody>();
		yspeed = rigidbody.velocity.y;
		
		
		// moving(move.v/h are just the joystick value)
		transform.position += new Vector3(move.Horrizontal * speed, 0f, move.Vertical * speed);
		

	}
	//this method is not called bec it is called by the button
	public void jump()
	{
		if (grounded == true)
		{
			rigidbody.velocity = new Vector3(rigidbody.velocity.x, Yjump, rigidbody.velocity.z);
		}
	}

	public void stop()
    {
		rigidbody.velocity = new Vector3(0f, yspeed, 0f);
    }
	//checking the ground
	void OnCollisionEnter(Collision col)
	{
		if (col.collider.tag == "floor")
		{
			grounded = true;
		}
		if (col.collider.tag == "LAVA")
		{
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

		}
	}

	void OnCollisionExit(Collision col)
	{
		if (col.collider.tag == "floor")
		{
			grounded = false;
		}

	}

}
