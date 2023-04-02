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
		
		if(Vector3.Distance (Player.transform.position, transform.position) > 3 && Vector3.Distance (Player.transform.position, transform.position) < 25  && anim.GetBool("Roll_Anim") == false ){
			transform.LookAt(Player.transform);
			while (rot[1] < transform.eulerAngles.y)
			{
				rot[1] += rotSpeed * Time.fixedDeltaTime;
			}
			while (rot[1] > transform.eulerAngles.y)
			{
				rot[1] -= rotSpeed * Time.fixedDeltaTime;
			}
			anim.SetBool("Walk_Anim", true);
			transform.position += transform.forward * 3f * Time.deltaTime;

		}
		else if (Vector3.Distance(Player.transform.position, transform.position) > 25 || anim.GetBool("Roll_Anim") && Vector3.Distance(Player.transform.position, transform.position) > 5)
		{
			anim.SetBool("Walk_Anim", false);
			anim.SetBool("Roll_Anim", true);
			transform.LookAt(Player.transform);
			transform.position += transform.forward * 10f * Time.deltaTime;
		}
		else if (Vector3.Distance(Player.transform.position, transform.position) < 5 && anim.GetBool("Roll_Anim"))
		{
			anim.SetBool("Roll_Anim", false);
		}
		else
		{
			anim.SetBool("Walk_Anim", false);
		}
		
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
