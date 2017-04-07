using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : MonoBehaviour {


	[SerializeField] Animator animator;
	private int DamageCount = 0;

	public void Damaged()
	{
		DamageCount++;
		if (DamageCount >= 5) 
		{
			Killed ();
			Invoke ("Rebirth", 3.0f);
		}
	}

	private void Killed ()
	{
		animator.SetBool ("broken", true);
	}

	private void Rebirth ()
	{
		DamageCount = 0;
		animator.SetBool ("broken", false);
	}
}
