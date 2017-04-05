using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{

	[SerializeField] GunController gun;

	// Use this for initialization
	void Start () 
	{
	}
	
	// Update is called once per frame
	void Update () 
	{
		Ray ray = new Ray (transform.position, transform.forward);
		RaycastHit hit;

		if (Physics.Raycast (ray, out hit)) 
		{
			if (Input.GetMouseButton (0)) 
			{
				gun.Shot (hit);
			}
		}
	}
}
