using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPController : MonoBehaviour
{

	[SerializeField] GunController gun;
	[SerializeField] private GameObject snipeImage;
	[SerializeField] private Camera camera;
	private bool isSnipe = false;

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
			if (Input.GetMouseButton (0)) gun.Shot (hit);
		}
		if (Input.GetKey (KeyCode.R)) gun.Reload ();
		if (Input.GetMouseButton (1)) SwitchSniperMode ();
	}

	private void SwitchSniperMode ()
	{
		if (isSnipe == false)
		{
			isSnipe = true;
			snipeImage.SetActive (true);
			camera.fieldOfView = 20.0f;
		}
		else
		{
			isSnipe = false;
			snipeImage.SetActive (false);
			camera.fieldOfView = 60.0f;
		}
	}
}
