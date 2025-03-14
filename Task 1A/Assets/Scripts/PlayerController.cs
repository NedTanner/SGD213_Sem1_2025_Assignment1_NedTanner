﻿using UnityEngine;
using UnityEngine.UI;

using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Tooltip("Controls how fast the player accelerates.")]
    public float playerSpeed;

    [Tooltip("The text that displays how many items the player ahs collected.")]
    public Text pickupText;

	[Tooltip("The image that displays the 'You Win!' text.")]
	public GameObject winScreen;

	private Rigidbody rb;
	private float pickupCounter;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		pickupCounter = 0;
		SetCountText();
	}
	// Creates local movement variable controlled by horizontal and vertical inputs, applies force to player object.
	void FixedUpdate()
	{
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
		rb.AddForce(movement * playerSpeed);
	}

	// Check if collision is a pickup, updates counter text.
	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Pick Up"))
		{
			other.gameObject.SetActive(false);
			pickupCounter += 1;
			SetCountText();
		}
	}
	// Updates counter text and checks if win state is active. If true, enables the win screen.
	void SetCountText()
	{
		pickupText.text = "Cubes Collected: " + pickupCounter.ToString();
		if (pickupCounter >= 12)
		{
			winScreen.SetActive(true);
		}
	}
}