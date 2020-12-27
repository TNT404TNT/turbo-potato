
using UnityEngine;

public class camerafollow : MonoBehaviour {
	public Touch tch;
	public Vector2 touch;
	public Transform target;
	public Vector3 offset;

	
	void LateUpdate()
	{
		touch = tch.position;
		transform.position = target.position + offset;
		transform.LookAt(target);
	}
}
