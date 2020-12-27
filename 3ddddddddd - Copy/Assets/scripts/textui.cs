using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class textui : MonoBehaviour {
	public float woodAmount;
	public int woodAmountRounded;
	public string wood;
	public Text woodText;

	// Use this for initialization
	void Start () {
		wood = "wood: " + woodAmountRounded;

	}
	
	// Update is called once per frame
	void Update () {
		woodAmountRounded = Mathf.RoundToInt(woodAmount);
		wood = "wood: " + woodAmountRounded;
		woodText.text = wood;
	}
}
