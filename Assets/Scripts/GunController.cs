using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private GameObject muzzleFireParticle;
	[SerializeField] private AudioClip shotSound;
	[SerializeField] private GameObject muzzle;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		
	}
		
	public void Shot (Vector3 hitposition)
	{
		GameObject muzzleFire = Instantiate (muzzleFireParticle, muzzle.transform.position, Quaternion.identity);
		GameObject fire = Instantiate (fireParticle, hitposition, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);

		Destroy (muzzleFire, 0.2f);
		Destroy (fire, 0.5f);
	}
}
