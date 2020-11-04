using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

	public float speed;
	public float jumpForce;
	public float gravityScale;
	public CharacterController controller;

	private Vector3 direction;

	//Use this for initialization
	void Start()
	{
		controller = GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void Update()
	{
		direction = new Vector3(Input.GetAxis("Horizontal") * speed,direction.y, Input.GetAxis("Vertical") * speed);

		//direction.x = Input.GetAxis("Horizontal") * speed;
		//direction.y = Input.GetAxis("Vertical") * speed;
		// Y movement
		if (controller.isGrounded)
		{
			// Jump
			if (Input.GetButtonDown("Jump"))
			{
				direction.y = jumpForce; // Jump
			}
			else
			{
				direction.y = -1; // Ensures contact with the ground
			}
		}
		else
		{
			// Apply Gravity
			direction.y = direction.y + (Physics.gravity.y * gravityScale * Time.deltaTime);
		}
		controller.Move(direction * Time.deltaTime);
	}
}
