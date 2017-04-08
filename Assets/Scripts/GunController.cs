using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour 
{
	[SerializeField] private GameObject fireParticle;
	[SerializeField] private GameObject muzzleFireParticle;
	[SerializeField] private AudioClip shotSound;
	[SerializeField] private AudioClip reloadSound;
	[SerializeField] private GameObject muzzle;
	[SerializeField] private float cycleTime;
	[SerializeField] private int magazine;
					 private int bulletSpace = 0;
	[SerializeField] private int maxBullet;
	[SerializeField] private int bulletStorage;
	[SerializeField] GameManager gameManager;

	private AudioSource audioSource;

	// Use this for initialization
	void Start () 
	{
		audioSource = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () 
	{
		cycleTime += Time.deltaTime;
	}
		
	public void Shot (RaycastHit hit)
	{
		if (cycleTime > 0.5f && magazine > 0) 
		{
			Fire (hit.point);
			TargetController target = hit.transform.GetComponent<TargetController> ();
			if (target != null) 
			{
				target.Damaged ();
				gameManager.Score (hit.point);
			}
		}
	}

	public void Reload ()
	{
		if (magazine < maxBullet && bulletStorage > 0) 
		{
			audioSource.PlayOneShot (reloadSound);
			bulletReload ();
		}
	}

	private void Fire (Vector3 hitposition)
	{
		GameObject muzzleFire = Instantiate (muzzleFireParticle, muzzle.transform.position, Quaternion.identity);
		GameObject fire = Instantiate (fireParticle, hitposition, Quaternion.identity);
		audioSource.PlayOneShot (shotSound);

		Destroy (muzzleFire, 0.3f);
		Destroy (fire, 0.3f);
		cycleTime = 0;
		magazine--;
		bulletSpace++;
	}

	private void bulletReload ()
	{
		if (bulletStorage >= bulletSpace) 
		{
			magazine += bulletSpace;
			bulletStorage -= bulletSpace;
			bulletSpace = 0;
		}
		else
		{
			magazine += bulletStorage;
			bulletStorage = 0;
			bulletSpace = 0;
		}
	}

	public int putBullet ()
	{
		return magazine;
	}
	 
	public int putStorage ()
	{
		return bulletStorage;
	}
}
