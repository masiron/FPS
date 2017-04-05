using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private GameObject muzzleFireParticle;
	[SerializeField] private AudioClip shotSound;
	[SerializeField] private GameObject muzzle;
	[SerializeField] private float cycleTime;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (cycleTime <= 0.5f) 
		{
			cycleTime += Time.deltaTime;
		}
	}
		
	public void Shot (RaycastHit hit)
	{
		if (cycleTime > 0.5f) 
		{
			Fire (hit.point);	
		}
	}

	public void Fire (Vector3 hitposition)
	{
		GameObject muzzleFire = Instantiate (muzzleFireParticle, muzzle.transform.position, Quaternion.identity);
		GameObject fire = Instantiate (fireParticle, hitposition, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);

		Destroy (muzzleFire, 0.2f);
		Destroy (fire, 0.5f);
		cycleTime = 0;
	}
}
