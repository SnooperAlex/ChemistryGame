using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class RobotFreeAnim : MonoBehaviour {

	Vector3 rot = Vector3.zero;
	float rotSpeed = 40f;
	Animator anim;

	public Transform Player;


	private float old_pos;

	// Use this for initialization
	void Awake()
	{
		anim = gameObject.GetComponent<Animator>();
		gameObject.transform.eulerAngles = rot;
		old_pos = transform.position.x;


	}

	// Update is called once per frame
	void Update()
	{
		CheckKey();
		gameObject.transform.eulerAngles = rot;
		
		transform.LookAt(Player.transform);
		transform.position += transform.forward * 10f * Time.deltaTime;

		if (old_pos < transform.position.x)
		{
			anim.SetBool("Walk_Anim", true);
		}
		else
		{
			anim.SetBool("Walk_Anim", false);
		}
		
		if (old_pos > transform.position.x)
		{
			anim.SetBool("Walk_Anim", true);
		}
		else
		{
			anim.SetBool("Walk_Anim", false);
		}

		old_pos = transform.position.x;
	}

	void CheckKey()
	{
		

		// Roll
		if (Input.GetKeyDown(KeyCode.Space))
		{
			if (anim.GetBool("Roll_Anim"))
			{
				anim.SetBool("Roll_Anim", false);
			}
			else
			{
				anim.SetBool("Roll_Anim", true);
			}
		}

		// Close
		if (Input.GetKeyDown(KeyCode.LeftControl))
		{
			if (!anim.GetBool("Open_Anim"))
			{
				anim.SetBool("Open_Anim", true);
			}
			else
			{
				anim.SetBool("Open_Anim", false);
			}
		}
	}

}
